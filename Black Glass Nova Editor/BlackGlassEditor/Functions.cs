using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace BlackGlassEditor
{
    static class BlackGlassDirClass
    {
        private static string m_globalVar = "";

        public static string Path
        {
            get { return m_globalVar; }
            set { m_globalVar = value; }
        }
    }

    public class MPplugin
    {
        private int _hyperlink;
        private string _name;
        private string _hover;

        public int Hyperlink
        {
            get { return _hyperlink; }
            set { _hyperlink = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Hover
        {
            get { return _hover; }
            set { _hover = value; }
        }

        public MPplugin() { }
        public MPplugin(int hyperlink, string name, string hover)
        {
            this._hyperlink = hyperlink;
            this._name = name;
            this._hover = hover;
        }
    }
    
    class Functions
    {

        public static Bitmap resizeImage(Bitmap imgToResize, Size size)
        {
            Bitmap b = new Bitmap(size.Width, size.Height);
            Graphics g = Graphics.FromImage((Image)b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.DrawImage(imgToResize, 0, 0, size.Width, size.Height);
            g.Dispose();
            return (Bitmap)b;
        }

        public enum ChannelARGB
        {
            Blue = 0,
            Green = 1,
            Red = 2,
            Alpha = 3
        }

        public enum TransparencyMode
        {
            ColorKeyTransparent,
            ColorKeyOpaque
        }

        public static void transferOneARGBChannelFromOneBitmapToAnother(Bitmap source, Bitmap dest, ChannelARGB sourceChannel, ChannelARGB destChannel)
        {

            if (source.Size != dest.Size) throw new ArgumentException();
            Rectangle r = new Rectangle(Point.Empty, source.Size);
            BitmapData bdSrc = source.LockBits(r, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            BitmapData bdDst = dest.LockBits(r, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);

            unsafe
            {
                byte* bpSrc = (byte*)bdSrc.Scan0.ToPointer();
                byte* bpDst = (byte*)bdDst.Scan0.ToPointer();
                bpSrc += (int)sourceChannel;
                bpDst += (int)destChannel;
                for (int i = r.Height * r.Width; i > 0; i--)
                {
                    *bpDst = *bpSrc;
                    bpSrc += 4;
                    bpDst += 4;
                }
            }
            source.UnlockBits(bdSrc);
            dest.UnlockBits(bdDst);
        }

        public unsafe static Region BitmapToRegion(Bitmap bitmap, Color transparencyKey,
            TransparencyMode mode)
        {
            //sanity check
            if (bitmap == null)
                throw new ArgumentNullException("Bitmap", "Bitmap cannot be null!");

            //flag = true means the color key represents the opaque color
            bool modeFlag = (mode == TransparencyMode.ColorKeyOpaque);

            GraphicsUnit unit = GraphicsUnit.Pixel;
            RectangleF boundsF = bitmap.GetBounds(ref unit);
            Rectangle bounds = new Rectangle((int)boundsF.Left, (int)boundsF.Top,
                (int)boundsF.Width, (int)boundsF.Height);

            uint key = (uint)((transparencyKey.A << 24) | (transparencyKey.R << 16) |
                (transparencyKey.G << 8) | (transparencyKey.B << 0));


            //get access to the raw bits of the image
            BitmapData bitmapData = bitmap.LockBits(bounds, ImageLockMode.ReadOnly,
                PixelFormat.Format32bppArgb);
            uint* pixelPtr = (uint*)bitmapData.Scan0.ToPointer();

            //avoid property accessors in the for
            int yMax = (int)boundsF.Height;
            int xMax = (int)boundsF.Width;

            //to store all the little rectangles in
            GraphicsPath path = new GraphicsPath();

            for (int y = 0; y < yMax; y++)
            {
                //store the pointer so we can offset the stride directly from it later
                //to get to the next line
                byte* basePos = (byte*)pixelPtr;

                for (int x = 0; x < xMax; x++, pixelPtr++)
                {
                    //is this transparent? if yes, just go on with the loop
                    if (modeFlag ^ (*pixelPtr == key))
                        continue;

                    //store where the scan starts
                    int x0 = x;

                    //not transparent - scan until we find the next transparent byte
                    while (x < xMax && !(modeFlag ^ (*pixelPtr == key)))
                    {
                        ++x;
                        pixelPtr++;
                    }

                    //add the rectangle we have found to the path
                    path.AddRectangle(new Rectangle(x0, y, x - x0, 1));
                }
                //jump to the next line
                pixelPtr = (uint*)(basePos + bitmapData.Stride);
            }

            //now create the region from all the rectangles
            Region region = new Region(path);

            //clean up
            path.Dispose();
            bitmap.UnlockBits(bitmapData);

            return region;
        }

        public static Image SetImgOpacity(Image imgPic, float imgOpac)
        {
            Bitmap bmpPic = new Bitmap(imgPic.Width, imgPic.Height);
            Graphics gfxPic = Graphics.FromImage(bmpPic);
            ColorMatrix cmxPic = new ColorMatrix();
            cmxPic.Matrix33 = imgOpac;

            ImageAttributes iaPic = new ImageAttributes();
            iaPic.SetColorMatrix(cmxPic, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            gfxPic.DrawImage(imgPic, new Rectangle(0, 0, bmpPic.Width, bmpPic.Height), 0, 0, imgPic.Width, imgPic.Height, GraphicsUnit.Pixel, iaPic);
            gfxPic.Dispose();

            return bmpPic;
        }

        public static ImageCodecInfo GetEncoder(ImageFormat format)
        {

            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();

            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }

        public static Image MakeGrayscale(Image original)
        {
            //create a blank bitmap the same size as original
            Bitmap newBitmap = new Bitmap(original.Width, original.Height);

            //get a graphics object from the new image
            Graphics g = Graphics.FromImage(newBitmap);

            //create the grayscale ColorMatrix
            ColorMatrix colorMatrix = new ColorMatrix(
               new float[][] 
      {
         new float[] {.3f, .3f, .3f, 0, 0},
         new float[] {.59f, .59f, .59f, 0, 0},
         new float[] {.11f, .11f, .11f, 0, 0},
         new float[] {0, 0, 0, 1, 0},
         new float[] {0, 0, 0, 0, 1}
      });

            //create some image attributes
            ImageAttributes attributes = new ImageAttributes();

            //set the color matrix attribute
            attributes.SetColorMatrix(colorMatrix);

            //draw the original image on the new image
            //using the grayscale color matrix
            g.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height),
               0, 0, original.Width, original.Height, GraphicsUnit.Pixel, attributes);

            //dispose the Graphics object
            g.Dispose();
            return newBitmap;
        }

    }


}
