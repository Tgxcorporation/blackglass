using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;

namespace ImageHuer
{
    public class ImageManipulator : IDisposable
    {
        private Image image;

        public ImageManipulator(Image img)
        {
            this.image = img;
        }

        public Image RotateHue(float hue)
        {
            Image workingImg = this.image.Clone() as Image;
            Bitmap bmp = new Bitmap(workingImg);
            for (int w = 0; w < bmp.Width; w++)
            {
                for (int h = 0; h < bmp.Height; h++)
                {
                    Color oldColor = bmp.GetPixel(w, h);
                    Color newColor = CalculateHueChange(oldColor, hue);
                    bmp.SetPixel(w, h, newColor);
                }
            }
            return bmp;
        }

        private Color CalculateHueChange(Color oldColor, float hue)
        {
            HLSRGB colorConverter = new HLSRGB(oldColor.R, oldColor.G, oldColor.B);
            float startHue = colorConverter.Hue;
            colorConverter.Hue = startHue + hue;
            return Color.FromArgb(colorConverter.Red, colorConverter.Green, colorConverter.Blue);
        }

        private struct HLSRGB
        {
            private int red;
            private int green;
            private int blue;

            private float hue;
            private float luminance;
            private float saturation;

            public int Red
            {
                get
                {
                    return red;
                }
                set
                {
                    red = value;
                    UpdateHLS();
                }
            }

            public int Green
            {
                get
                {
                    return green;
                }
                set
                {
                    green = value;
                    UpdateHLS();
                }
            }

            public int Blue
            {
                get
                {
                    return blue;
                }
                set
                {
                    blue = value;
                    UpdateHLS();
                }
            }

            public float Luminance
            {
                get
                {
                    return luminance;
                }
                set
                {
                    luminance = value;
                    UpdateRGB();
                }
            }

            public float Hue
            {
                get
                {
                    return hue;
                }
                set
                {
                    hue = value;
                    UpdateRGB();
                }
            }

            public float Saturation
            {
                get
                {
                    return saturation;
                }
                set
                {
                    if ((saturation < 0.0f) || (saturation > 1.0f))
                    {
                        throw new ArgumentOutOfRangeException("Saturation", "Saturation must be between 0.0 and 1.0");
                    }
                    saturation = value;
                    UpdateRGB();
                }
            }

            public HLSRGB(float hue, float luminance, float saturation)
            {
                this.red = 0;
                this.green = 0;
                this.blue = 0;
                this.hue = hue;
                this.luminance = luminance;
                this.saturation = saturation;
                UpdateRGB();
            }

            public HLSRGB(int red, int green, int blue)
            {
                this.hue = 0;
                this.luminance = 0;
                this.saturation = 0;
                this.red = red;
                this.green = green;
                this.blue = blue;
                UpdateHLS();
            }

            private void UpdateHLS()
            {
                int minval = Math.Min(red, Math.Min(green, blue));
                int maxval = Math.Max(red, Math.Max(green, blue));

                float mdiff = (float)(maxval - minval);
                float msum = (float)(maxval + minval);

                luminance = msum / 510.0f;

                if (maxval == minval)
                {
                    saturation = 0.0f;
                    hue = 0.0f;
                }
                else
                {
                    float rnorm = (maxval - red) / mdiff;
                    float gnorm = (maxval - green) / mdiff;
                    float bnorm = (maxval - blue) / mdiff;

                    saturation = (luminance <= 0.5f) ? (mdiff / msum) : (mdiff / (510.0f - msum));

                    if (red == maxval)
                    {
                        hue = 60.0f * (6.0f + bnorm - gnorm);
                    }
                    if (green == maxval)
                    {
                        hue = 60.0f * (2.0f + rnorm - bnorm);
                    }
                    if (blue == maxval)
                    {
                        hue = 60.0f * (4.0f + gnorm - rnorm);
                    }
                    if (hue > 360.0f)
                    {
                        hue = hue - 360.0f;
                    }
                }
            }

            private void UpdateRGB()
            {
                if (saturation == 0.0)
                {
                    red = (int)(luminance * 255.0F);
                    green = red;
                    blue = red;
                }
                else
                {
                    float rm1;
                    float rm2;

                    if (luminance <= 0.5f)
                    {
                        rm2 = luminance + luminance * saturation;
                    }
                    else
                    {
                        rm2 = luminance + saturation - luminance * saturation;
                    }
                    rm1 = 2.0f * luminance - rm2;
                    red = ToRGB1(rm1, rm2, hue + 120.0f);
                    green = ToRGB1(rm1, rm2, hue);
                    blue = ToRGB1(rm1, rm2, hue - 120.0f);
                }
            }

            private int ToRGB1(float rm1, float rm2, float rh)
            {
                if (rh > 360.0f)
                {
                    rh -= 360.0f;
                }
                else if (rh < 0.0f)
                {
                    rh += 360.0f;
                }

                if (rh < 60.0f)
                {
                    rm1 = rm1 + (rm2 - rm1) * rh / 60.0f;
                }
                else if (rh < 180.0f)
                {
                    rm1 = rm2;
                }
                else if (rh < 240.0f)
                {
                    rm1 = rm1 + (rm2 - rm1) * (240.0f - rh) / 60.0f;
                }

                return (int)(rm1 * 255);
            }
        }

        public void Dispose()
        {
            this.image.Dispose();
        }
    }
}
