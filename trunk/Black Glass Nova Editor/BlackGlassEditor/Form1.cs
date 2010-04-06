using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Web;
using System.Drawing.Imaging;
using System.IO;
using QuadrilateralDistortion;
using System.Reflection;
using BlackGlassEditor;
using System.Security;
using System.Xml;

namespace BlackGlassEditor
{
    public partial class Form1 : Form
    {
        public List<MPplugin> plugins = new List<MPplugin>();

        public Form1()
        {
            InitializeComponent();

            plugins.Add(new MPplugin(6001, "Anime", "hover_my anime"));
            plugins.Add(new MPplugin(760, "Burner", "hover_my burner"));
            //  plugins.Add(new MPplugin(1987, "Clipta Video Search"));
            //   plugins.Add(new MPplugin(63453335, "EarthTV"));
            plugins.Add(new MPplugin(330099, "Email Manager", "hover_email"));
            plugins.Add(new MPplugin(2497, "Emulators", "hover_myEmulators"));
            // plugins.Add(new MPplugin(800, "Extensions"));
            plugins.Add(new MPplugin(1666, "FANatic Monitor", "hover_FANatic Monitor"));
            plugins.Add(new MPplugin(7986, "Films", "hover_Films"));
            plugins.Add(new MPplugin(557311, "File Explorer", "hover_file explorer"));
            //  plugins.Add(new MPplugin(464554871, "FritzManager"));
            plugins.Add(new MPplugin(30885, "Global Search", "hover_search music"));
            plugins.Add(new MPplugin(7972, "HTPCInfo", "hover_htpcinfo"));
            plugins.Add(new MPplugin(16001, "Infoservice RSS", "hover_infoservice"));
            plugins.Add(new MPplugin(16003, "Infoservice Twitter", "hover_twitter"));
            // plugins.Add(new MPplugin(6912, "Justin.tv"));
            plugins.Add(new MPplugin(7890, "Last.fm", "hover_LastFmRadio"));
            plugins.Add(new MPplugin(90478, "Lyrics", "hover_my lyrics"));
            plugins.Add(new MPplugin(8765, "Media Slayer", "hover_mediaslayer"));
            plugins.Add(new MPplugin(96742, "Moving Pictures", "hover_moving pictures"));
            plugins.Add(new MPplugin(3847, "MpNZB", "hover_mpnzb"));
            //plugins.Add(new MPplugin(0, "Multishortcut"));
            plugins.Add(new MPplugin(501, "Music", "hover_my music"));
            plugins.Add(new MPplugin(504, "Music Genres", "hover_my music"));
            plugins.Add(new MPplugin(880, "Music Videos", "hover_musicvids"));
            // plugins.Add(new MPplugin(10099, "Netflix"));
            plugins.Add(new MPplugin(2700, "News RSS", "hover_my news"));
            // plugins.Add(new MPplugin(30050, "Online Photos and Friends"));
            plugins.Add(new MPplugin(4755, "Online Videos", "hover_OnlineVideos"));
            plugins.Add(new MPplugin(2, "Pictures", "hover_my pictures"));
            plugins.Add(new MPplugin(34, "Plugins", "hover_my plugins"));
            //plugins.Add(new MPplugin(3, "Programs"));
            plugins.Add(new MPplugin(30, "Radio", "hover_my radio"));
            plugins.Add(new MPplugin(25650, "RadioTime", "hover_radiotime"));
            plugins.Add(new MPplugin(42000, "Score Center", "hover_score center"));
            plugins.Add(new MPplugin(4, "Settings", "hover_settings"));
            plugins.Add(new MPplugin(2345, "Shoutcast", "hover_shoutcast"));
            plugins.Add(new MPplugin(7111992, "Showtimes", "hover_showtimes"));
            // plugins.Add(new MPplugin(1911, "Skype"));
            plugins.Add(new MPplugin(7969, "Sleep Control", "hover_sleepcontrol"));
            //plugins.Add(new MPplugin(45678, "Smart Playlists"));
            plugins.Add(new MPplugin(15634330, "Stream Radio", "hover_my streamradio"));
            plugins.Add(new MPplugin(7777, "Sudoku", "hover_mynumberplace"));
            plugins.Add(new MPplugin(7700, "Teletext", "hover_my tv"));
            plugins.Add(new MPplugin(7776, "Tetris", "hover_tetris"));
            plugins.Add(new MPplugin(5900, "Trailers", "hover_my trailers"));
            plugins.Add(new MPplugin(1, "TV", "hover_my tv"));
            // plugins.Add(new MPplugin(6799, "TV Gemist"));
            plugins.Add(new MPplugin(9811, "TV Series", "hover_my tv series"));
            plugins.Add(new MPplugin(5678, "Torrents", "hover_mytorrents"));
            plugins.Add(new MPplugin(6, "Videos", "hover_my videos"));
            plugins.Add(new MPplugin(25, "Video Titles", "hover_my videos"));
            plugins.Add(new MPplugin(2959, "Video Editor", "hover_videoeditor"));
            plugins.Add(new MPplugin(7971, "Volume Control", "hover_volumecontrol"));
            plugins.Add(new MPplugin(2600, "Weather", "hover_my weather"));
            plugins.Add(new MPplugin(4711, "Wikipedia", "hover_wikipedia"));
            plugins.Add(new MPplugin(7978, "World Clock", "hover_worldclock"));
            plugins.Add(new MPplugin(10234, "WorldMap", "hover_myworldmap"));
            plugins.Add(new MPplugin(29050, "Youtube.fm", "hover_youtubefm"));



            foreach (MPplugin p in plugins)
            {
                comboBox100.Items.Add(p.Name);
                comboBox101.Items.Add(p.Name);
                comboBox102.Items.Add(p.Name);
                comboBox103.Items.Add(p.Name);
                comboBox104.Items.Add(p.Name);
                comboBox105.Items.Add(p.Name);
                comboBox106.Items.Add(p.Name);
            }




            string path = System.IO.Path.Combine(Application.StartupPath, "settings.xml");
            FileStream READER = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            System.Xml.XmlDocument Buttons = new System.Xml.XmlDocument();
            Buttons.Load(READER);
            System.Xml.XmlNodeList NodeList = Buttons.GetElementsByTagName("Buttons");


            XmlNodeList name = Buttons.GetElementsByTagName("name");
            XmlNodeList plugin = Buttons.GetElementsByTagName("plugin");
            XmlNodeList hover = Buttons.GetElementsByTagName("hover");

            comboBox100.SelectedItem = findPluginName(Int32.Parse(plugin[0].InnerText));
            comboBox101.SelectedItem = findPluginName(Int32.Parse(plugin[1].InnerText));
            comboBox102.SelectedItem = findPluginName(Int32.Parse(plugin[2].InnerText));
            comboBox103.SelectedItem = findPluginName(Int32.Parse(plugin[3].InnerText));
            comboBox104.SelectedItem = findPluginName(Int32.Parse(plugin[4].InnerText));
            comboBox105.SelectedItem = findPluginName(Int32.Parse(plugin[5].InnerText));
            comboBox106.SelectedItem = findPluginName(Int32.Parse(plugin[6].InnerText));


            textBox100.Text = name[0].InnerText;
            textBox101.Text = name[1].InnerText;
            textBox102.Text = name[2].InnerText;
            textBox103.Text = name[3].InnerText;
            textBox104.Text = name[4].InnerText;
            textBox105.Text = name[5].InnerText;
            textBox106.Text = name[6].InnerText;

            textBoxid100.Text = plugin[0].InnerText;
            textBoxid101.Text = plugin[1].InnerText;
            textBoxid102.Text = plugin[2].InnerText;
            textBoxid103.Text = plugin[3].InnerText;
            textBoxid104.Text = plugin[4].InnerText;
            textBoxid105.Text = plugin[5].InnerText;
            textBoxid106.Text = plugin[6].InnerText;

            textBoxhover100.Text = hover[0].InnerText;
            textBoxhover101.Text = hover[1].InnerText;
            textBoxhover102.Text = hover[2].InnerText;
            textBoxhover103.Text = hover[3].InnerText;
            textBoxhover104.Text = hover[4].InnerText;
            textBoxhover105.Text = hover[5].InnerText;
            textBoxhover106.Text = hover[6].InnerText;



            BlackGlassDirClass.Path = findBlackGlassSkinDir();


            textBoxTarget.Text = BlackGlassDirClass.Path;

        }

        private void buttonLoad100_Click(object sender, EventArgs e)
        {
            Stream myStream = null;

            if (DialogOpen.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = DialogOpen.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            Bitmap img = (Bitmap)Bitmap.FromFile(DialogOpen.FileName);



                            Size newsize = new Size(230, 266);

                            Point topleft = new Point(25, 4);
                            Point topright = new Point(222, 18);
                            Point bottomleft = new Point(5, 182);
                            Point bottomright = new Point(211, 161);

                            img = QuadDistort.Distort((Bitmap)Functions.resizeImage((Bitmap)img, newsize), topleft, topright, bottomleft, bottomright);


                            Bitmap reflectedImg = (Bitmap)Bitmap.FromFile(DialogOpen.FileName);
                            reflectedImg.RotateFlip(RotateFlipType.RotateNoneFlipY);

                            topleft = new Point(17, 30);
                            topright = new Point(222, 0);
                            bottomleft = new Point(0, 166);
                            bottomright = new Point(210, 123);

                            reflectedImg = QuadDistort.Distort((Bitmap)Functions.resizeImage((Bitmap)reflectedImg, newsize), topleft, topright, bottomleft, bottomright);

                            Bitmap dummyImage = new Bitmap(230, 266);
                            Graphics ga = Graphics.FromImage(dummyImage);
                            ga.DrawImage(img, new System.Drawing.Rectangle(0, 0, img.Width, img.Height));
                            ga.DrawImage(reflectedImg, new System.Drawing.Rectangle(-12, 166, reflectedImg.Width, reflectedImg.Height));
                            pictureBox100.Image = dummyImage;

                            img.Dispose();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }

        }
        private void buttonLoad101_Click(object sender, EventArgs e)
        {
            Stream myStream = null;

            if (DialogOpen.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = DialogOpen.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            Bitmap img = (Bitmap)Bitmap.FromFile(DialogOpen.FileName);

                            Size newsize = new Size(204, 204);

                            Point topleft = new Point(13, 2);
                            Point topright = new Point(194, 10);
                            Point bottomleft = new Point(2, 139);
                            Point bottomright = new Point(189, 127);

                            img = QuadDistort.Distort((Bitmap)Functions.resizeImage((Bitmap)img, newsize), topleft, topright, bottomleft, bottomright);


                            Bitmap reflectedImg = (Bitmap)Bitmap.FromFile(DialogOpen.FileName);
                            reflectedImg.RotateFlip(RotateFlipType.RotateNoneFlipY);

                            topleft = new Point(11, 17);
                            topright = new Point(197, 1);
                            bottomleft = new Point(5, 134);
                            bottomright = new Point(193, 120);

                            reflectedImg = QuadDistort.Distort((Bitmap)Functions.resizeImage((Bitmap)reflectedImg, newsize), topleft, topright, bottomleft, bottomright);

                            Bitmap dummyImage = new Bitmap(204, 204);
                            Graphics ga = Graphics.FromImage(dummyImage);
                            ga.DrawImage(img, new System.Drawing.Rectangle(0, 0, img.Width, img.Height));
                            ga.DrawImage(reflectedImg, new System.Drawing.Rectangle(-9, 133, reflectedImg.Width, reflectedImg.Height));
                            pictureBox101.Image = dummyImage;

                            img.Dispose();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }

        }
        private void buttonLoad102_Click(object sender, EventArgs e)
        {
            Stream myStream = null;

            if (DialogOpen.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = DialogOpen.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            Bitmap img = (Bitmap)Bitmap.FromFile(DialogOpen.FileName);

                            Size newsize = new Size(178, 191);

                            Point topleft = new Point(7, 1);
                            Point topright = new Point(166, 6);
                            Point bottomleft = new Point(3, 117);
                            Point bottomright = new Point(165, 112);

                            img = QuadDistort.Distort((Bitmap)Functions.resizeImage((Bitmap)img, newsize), topleft, topright, bottomleft, bottomright);


                            Bitmap reflectedImg = (Bitmap)Bitmap.FromFile(DialogOpen.FileName);
                            reflectedImg.RotateFlip(RotateFlipType.RotateNoneFlipY);

                            topleft = new Point(9, 6);
                            topright = new Point(171, 0);
                            bottomleft = new Point(4, 111);
                            bottomright = new Point(170, 104);

                            reflectedImg = QuadDistort.Distort((Bitmap)Functions.resizeImage((Bitmap)reflectedImg, newsize), topleft, topright, bottomleft, bottomright);

                            Bitmap dummyImage = new Bitmap(178, 191);
                            Graphics ga = Graphics.FromImage(dummyImage);
                            ga.DrawImage(img, new System.Drawing.Rectangle(0, 0, img.Width, img.Height));
                            ga.DrawImage(reflectedImg, new System.Drawing.Rectangle(-6, 116, reflectedImg.Width, reflectedImg.Height));
                            pictureBox102.Image = dummyImage;

                            img.Dispose();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }

        }
        private void buttonLoad103_Click(object sender, EventArgs e)
        {
            Stream myStream = null;

            if (DialogOpen.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = DialogOpen.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            Bitmap img = (Bitmap)Bitmap.FromFile(DialogOpen.FileName);

                            Size newsize = new Size(168, 183);

                            Point topleft = new Point(4, 3);
                            Point topright = new Point(154, 3);
                            Point bottomleft = new Point(3, 108);
                            Point bottomright = new Point(156, 108);

                            img = QuadDistort.Distort((Bitmap)Functions.resizeImage((Bitmap)img, newsize), topleft, topright, bottomleft, bottomright);


                            Bitmap reflectedImg = (Bitmap)Bitmap.FromFile(DialogOpen.FileName);
                            reflectedImg.RotateFlip(RotateFlipType.RotateNoneFlipY);

                            topleft = new Point(3, 8);
                            topright = new Point(155, 8);
                            bottomleft = new Point(3, 103);
                            bottomright = new Point(156, 103);

                            reflectedImg = QuadDistort.Distort((Bitmap)Functions.resizeImage((Bitmap)reflectedImg, newsize), topleft, topright, bottomleft, bottomright);

                            Bitmap dummyImage = new Bitmap(168, 183);
                            Graphics ga = Graphics.FromImage(dummyImage);
                            ga.DrawImage(img, new System.Drawing.Rectangle(0, 0, img.Width, img.Height));
                            ga.DrawImage(reflectedImg, new System.Drawing.Rectangle(0, 104, reflectedImg.Width, reflectedImg.Height));
                            pictureBox103.Image = dummyImage;

                            img.Dispose();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }

        }
        private void buttonLoad104_Click(object sender, EventArgs e)
        {
            Stream myStream = null;

            if (DialogOpen.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = DialogOpen.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            Bitmap img = (Bitmap)Bitmap.FromFile(DialogOpen.FileName);

                            Size newsize = new Size(178, 191);

                            Point topleft = new Point(4, 7);
                            Point topright = new Point(162, 2);
                            Point bottomleft = new Point(6, 112);
                            Point bottomright = new Point(167, 117);

                            img = QuadDistort.Distort((Bitmap)Functions.resizeImage((Bitmap)img, newsize), topleft, topright, bottomleft, bottomright);


                            Bitmap reflectedImg = (Bitmap)Bitmap.FromFile(DialogOpen.FileName);
                            reflectedImg.RotateFlip(RotateFlipType.RotateNoneFlipY);

                            topleft = new Point(3, 9);
                            topright = new Point(166, 15);
                            bottomleft = new Point(6, 113);
                            bottomright = new Point(168, 118);

                            reflectedImg = QuadDistort.Distort((Bitmap)Functions.resizeImage((Bitmap)reflectedImg, newsize), topleft, topright, bottomleft, bottomright);

                            Bitmap dummyImage = new Bitmap(178, 191);
                            Graphics ga = Graphics.FromImage(dummyImage);
                            ga.DrawImage(img, new System.Drawing.Rectangle(0, 0, img.Width, img.Height));
                            ga.DrawImage(reflectedImg, new System.Drawing.Rectangle(2, 108, reflectedImg.Width, reflectedImg.Height));
                            pictureBox104.Image = dummyImage;

                            img.Dispose();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }

        }

        private void buttonLoad105_Click(object sender, EventArgs e)
        {
            Stream myStream = null;

            if (DialogOpen.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = DialogOpen.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            Bitmap img = (Bitmap)Bitmap.FromFile(DialogOpen.FileName);

                            Size newsize = new Size(204, 211);

                            Point topleft = new Point(4, 12);
                            Point topright = new Point(182, 2);
                            Point bottomleft = new Point(8, 128);
                            Point bottomright = new Point(193, 139);

                            img = QuadDistort.Distort((Bitmap)Functions.resizeImage((Bitmap)img, newsize), topleft, topright, bottomleft, bottomright);


                            Bitmap reflectedImg = (Bitmap)Bitmap.FromFile(DialogOpen.FileName);
                            reflectedImg.RotateFlip(RotateFlipType.RotateNoneFlipY);

                            topleft = new Point(3, 14);
                            topright = new Point(188, 30);
                            bottomleft = new Point(8, 129);
                            bottomright = new Point(195, 141);

                            reflectedImg = QuadDistort.Distort((Bitmap)Functions.resizeImage((Bitmap)reflectedImg, newsize), topleft, topright, bottomleft, bottomright);

                            Bitmap dummyImage = new Bitmap(204, 211);
                            Graphics ga = Graphics.FromImage(dummyImage);
                            ga.DrawImage(img, new System.Drawing.Rectangle(0, 0, img.Width, img.Height));
                            ga.DrawImage(reflectedImg, new System.Drawing.Rectangle(6, 119, reflectedImg.Width, reflectedImg.Height));
                            pictureBox105.Image = dummyImage;

                            img.Dispose();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }

        }
        private void buttonLoad106_Click(object sender, EventArgs e)
        {
            Stream myStream = null;

            if (DialogOpen.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = DialogOpen.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            Bitmap img = (Bitmap)Bitmap.FromFile(DialogOpen.FileName);

                            Size newsize = new Size(226, 256);

                            Point topleft = new Point(2, 18);
                            Point topright = new Point(194, 1);
                            Point bottomleft = new Point(15, 159);
                            Point bottomright = new Point(216, 179);

                            img = QuadDistort.Distort((Bitmap)Functions.resizeImage((Bitmap)img, newsize), topleft, topright, bottomleft, bottomright);


                            Bitmap reflectedImg = (Bitmap)Bitmap.FromFile(DialogOpen.FileName);
                            reflectedImg.RotateFlip(RotateFlipType.RotateNoneFlipY);

                            topleft = new Point(2, 17);
                            topright = new Point(204, 47);
                            bottomleft = new Point(16, 155);
                            bottomright = new Point(218, 180);

                            reflectedImg = QuadDistort.Distort((Bitmap)Functions.resizeImage((Bitmap)reflectedImg, newsize), topleft, topright, bottomleft, bottomright);

                            Bitmap dummyImage = new Bitmap(226, 256);
                            Graphics ga = Graphics.FromImage(dummyImage);
                            ga.DrawImage(img, new System.Drawing.Rectangle(0, 0, img.Width, img.Height));
                            ga.DrawImage(reflectedImg, new System.Drawing.Rectangle(14, 149, reflectedImg.Width, reflectedImg.Height));
                            pictureBox106.Image = dummyImage;

                            img.Dispose();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }

        }



        private void buttonSave100f_Click(object sender, EventArgs e)
        {
            if (!checkTargetPicture("100") && checkTargetPath())
            {
                String path = BlackGlassDirClass.Path + "\\Media\\basichome_100_focus.png";
                saveImage(path, pictureBox100.Image, "100", 1);
                deleteBlackGlassCacheDir();
            }
        }

        private void buttonSave100u_Click(object sender, EventArgs e)
        {
            if (!checkTargetPicture("100") && checkTargetPath())
            {

                String path = BlackGlassDirClass.Path + "\\Media\\basichome_100_nofocus.png";
                saveImage(path, pictureBox100.Image, "100", 0);
                deleteBlackGlassCacheDir();
            }
        }
        private void buttonSave101f_Click(object sender, EventArgs e)
        {
            if (!checkTargetPicture("101") && checkTargetPath())
            {

                String path = BlackGlassDirClass.Path + "\\Media\\basichome_101_focus.png";
                saveImage(path, pictureBox101.Image, "101", 1);
                deleteBlackGlassCacheDir();
            }
        }

        private void buttonSave101u_Click(object sender, EventArgs e)
        {
            if (!checkTargetPicture("101") && checkTargetPath())
            {

                String path = BlackGlassDirClass.Path + "\\Media\\basichome_101_nofocus.png";
                saveImage(path, pictureBox101.Image, "101", 0);
                deleteBlackGlassCacheDir();
            }
        }
        private void buttonSave102f_Click(object sender, EventArgs e)
        {
            if (!checkTargetPicture("102") && checkTargetPath())
            {

                String path = BlackGlassDirClass.Path + "\\Media\\basichome_102_focus.png";
                saveImage(path, pictureBox102.Image, "102", 1);
                deleteBlackGlassCacheDir();
            }
        }

        private void buttonSave102u_Click(object sender, EventArgs e)
        {
            if (!checkTargetPicture("102") && checkTargetPath())
            {

                String path = BlackGlassDirClass.Path + "\\Media\\basichome_102_nofocus.png";
                saveImage(path, pictureBox102.Image, "102", 0);
                deleteBlackGlassCacheDir();
            }
        }
        private void buttonSave103f_Click(object sender, EventArgs e)
        {
            if (!checkTargetPicture("103") && checkTargetPath())
            {

                String path = BlackGlassDirClass.Path + "\\Media\\basichome_103_focus.png";
                saveImage(path, pictureBox103.Image, "103", 1);
                deleteBlackGlassCacheDir();
            }
        }

        private void buttonSave103u_Click(object sender, EventArgs e)
        {
            if (!checkTargetPicture("103") && checkTargetPath())
            {

                String path = BlackGlassDirClass.Path + "\\Media\\basichome_103_nofocus.png";
                saveImage(path, pictureBox103.Image, "103", 0);
                deleteBlackGlassCacheDir();
            }
        }
        private void buttonSave104f_Click(object sender, EventArgs e)
        {
            if (!checkTargetPicture("104") && checkTargetPath())
            {

                String path = BlackGlassDirClass.Path + "\\Media\\basichome_104_focus.png";
                saveImage(path, pictureBox104.Image, "104", 1);
                deleteBlackGlassCacheDir();
            }
        }

        private void buttonSave104u_Click(object sender, EventArgs e)
        {
            if (!checkTargetPicture("104") && checkTargetPath())
            {

                String path = BlackGlassDirClass.Path + "\\Media\\basichome_104_nofocus.png";
                saveImage(path, pictureBox104.Image, "104", 1);
                deleteBlackGlassCacheDir();
            }
        }

        private void buttonSave105f_Click(object sender, EventArgs e)
        {
            if (!checkTargetPicture("105") && checkTargetPath())
            {

                String path = BlackGlassDirClass.Path + "\\Media\\basichome_105_focus.png";
                saveImage(path, pictureBox105.Image, "105", 1);
                deleteBlackGlassCacheDir();
            }
        }

        private void buttonSave105u_Click(object sender, EventArgs e)
        {
            if (!checkTargetPicture("105") && checkTargetPath())
            {

                String path = BlackGlassDirClass.Path + "\\Media\\basichome_105_nofocus.png";
                saveImage(path, pictureBox105.Image, "105", 0);
                deleteBlackGlassCacheDir();
            }
        }

        private void buttonSave106f_Click(object sender, EventArgs e)
        {
            if (!checkTargetPicture("106") && checkTargetPath())
            {

                String path = BlackGlassDirClass.Path + "\\Media\\basichome_106_focus.png";
                saveImage(path, pictureBox106.Image, "106", 1);
                deleteBlackGlassCacheDir();
            }
        }

        private void buttonSave106u_Click(object sender, EventArgs e)
        {
            if (!checkTargetPicture("106") && checkTargetPath())
            {

                String path = BlackGlassDirClass.Path + "\\Media\\basichome_106_nofocus.png";
                saveImage(path, pictureBox106.Image, "106", 0);
                deleteBlackGlassCacheDir();
            }
        }







        private void saveImage(string path, Image img, String buttonRif, int focus)
        {
            int myWidth = 0;
            int myHeight = 0;

            switch (buttonRif)
            {
                case "100":
                    myWidth = 230;
                    myHeight = 266;
                    break;
                case "101":
                    myWidth = 204;
                    myHeight = 204;
                    break;
                case "102":
                    myWidth = 178;
                    myHeight = 191;
                    break;
                case "103":
                    myWidth = 168;
                    myHeight = 183;
                    break;
                case "104":
                    myWidth = 178;
                    myHeight = 191;
                    break;
                case "105":
                    myWidth = 204;
                    myHeight = 211;
                    break;
                case "106":
                    myWidth = 226;
                    myHeight = 256;
                    break;


            }

            Bitmap finalImage = new Bitmap(myWidth, myHeight);
            Bitmap clipImage = new Bitmap(myWidth, myHeight);

            Graphics gfx = Graphics.FromImage(finalImage);
            Graphics gfxClip = Graphics.FromImage(clipImage);
            gfx.SmoothingMode = SmoothingMode.AntiAlias;
            gfxClip.SmoothingMode = SmoothingMode.HighQuality;
            gfxClip.PixelOffsetMode = PixelOffsetMode.HighQuality;
            gfxClip.InterpolationMode = InterpolationMode.HighQualityBicubic;

            gfxClip.ResetClip();

            Assembly myAssembly = Assembly.GetExecutingAssembly();

            Stream myStream = myAssembly.GetManifestResourceStream("BlackGlassEditor.Images.basichome_" + buttonRif + "_shadow.png");
            Bitmap shadow = new Bitmap(myStream);

            myStream = myAssembly.GetManifestResourceStream("BlackGlassEditor.Images.basichome_" + buttonRif + "_mask.png");
            Bitmap mask = new Bitmap(myStream);


            Region myregion = new Region();
            Color col = mask.GetPixel(1, 1);
            myregion = Functions.BitmapToRegion(mask, col, Functions.TransparencyMode.ColorKeyTransparent);

            gfxClip.SetClip(myregion, CombineMode.Replace);

            Functions.transferOneARGBChannelFromOneBitmapToAnother((Bitmap)mask, (Bitmap)img, Functions.ChannelARGB.Blue, Functions.ChannelARGB.Alpha);


            if (focus == 0)
            {
                shadow = (Bitmap)Functions.SetImgOpacity(shadow, 0.70f);
                img = Functions.SetImgOpacity(img, 0.70f);
            }

            gfxClip.DrawImage(img, new System.Drawing.Rectangle(0, 0, img.Width, img.Height));


            gfx.DrawImage(shadow, new System.Drawing.Rectangle(0, 0, shadow.Width, shadow.Height));

            myStream = myAssembly.GetManifestResourceStream("BlackGlassEditor.Images.basichome_" + buttonRif + "_contour.png");
            Bitmap contour = new Bitmap(myStream);

            if (focus == 0)
            {
                contour = (Bitmap)Functions.SetImgOpacity(contour, 0.70f);
            }

            gfx.DrawImage(contour, new System.Drawing.Rectangle(0, 0, contour.Width, contour.Height));

            gfx.DrawImage(clipImage, new System.Drawing.Rectangle(0, 0, clipImage.Width, clipImage.Height));


            try
            {
                finalImage.Save(path, System.Drawing.Imaging.ImageFormat.Png);
                toolStripStatusLabel1.Text = "Button File Saved Succesfully";
                //MessageBox.Show("File Saved!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Could not save file from disk. Original error: " + ex.Message);
            }




        }


        private Bitmap buildImage(Image img, String buttonRif, int focus)
        {
            int myWidth = 0;
            int myHeight = 0;

            switch (buttonRif)
            {
                case "100":
                    myWidth = 230;
                    myHeight = 266;
                    break;
                case "101":
                    myWidth = 204;
                    myHeight = 204;
                    break;
                case "102":
                    myWidth = 178;
                    myHeight = 191;
                    break;
                case "103":
                    myWidth = 168;
                    myHeight = 183;
                    break;
                case "104":
                    myWidth = 178;
                    myHeight = 191;
                    break;
                case "105":
                    myWidth = 204;
                    myHeight = 211;
                    break;
                case "106":
                    myWidth = 226;
                    myHeight = 256;
                    break;


            }

            Bitmap finalImage = new Bitmap(myWidth, myHeight);
            Bitmap clipImage = new Bitmap(myWidth, myHeight);

            Graphics gfx = Graphics.FromImage(finalImage);
            Graphics gfxClip = Graphics.FromImage(clipImage);
            gfx.SmoothingMode = SmoothingMode.AntiAlias;
            gfxClip.SmoothingMode = SmoothingMode.HighQuality;
            gfxClip.PixelOffsetMode = PixelOffsetMode.HighQuality;
            gfxClip.InterpolationMode = InterpolationMode.HighQualityBicubic;

            gfxClip.ResetClip();

            Assembly myAssembly = Assembly.GetExecutingAssembly();

            Stream myStream = myAssembly.GetManifestResourceStream("BlackGlassEditor.Images.basichome_" + buttonRif + "_shadow.png");
            Bitmap shadow = new Bitmap(myStream);

            myStream = myAssembly.GetManifestResourceStream("BlackGlassEditor.Images.basichome_" + buttonRif + "_mask.png");
            Bitmap mask = new Bitmap(myStream);


            Region myregion = new Region();
            Color col = mask.GetPixel(1, 1);
            myregion = Functions.BitmapToRegion(mask, col, Functions.TransparencyMode.ColorKeyTransparent);

            gfxClip.SetClip(myregion, CombineMode.Replace);

            Functions.transferOneARGBChannelFromOneBitmapToAnother((Bitmap)mask, (Bitmap)img, Functions.ChannelARGB.Blue, Functions.ChannelARGB.Alpha);


            if (focus == 0)
            {
                shadow = (Bitmap)Functions.SetImgOpacity(shadow, 0.70f);
                img = Functions.SetImgOpacity(img, 0.70f);
            }

            gfxClip.DrawImage(img, new System.Drawing.Rectangle(0, 0, img.Width, img.Height));


            gfx.DrawImage(shadow, new System.Drawing.Rectangle(0, 0, shadow.Width, shadow.Height));

            myStream = myAssembly.GetManifestResourceStream("BlackGlassEditor.Images.basichome_" + buttonRif + "_contour.png");
            Bitmap contour = new Bitmap(myStream);

            if (focus == 0)
            {
                contour = (Bitmap)Functions.SetImgOpacity(contour, 0.70f);
            }

            gfx.DrawImage(contour, new System.Drawing.Rectangle(0, 0, contour.Width, contour.Height));


            gfx.DrawImage(clipImage, new System.Drawing.Rectangle(0, 0, clipImage.Width, clipImage.Height));


            try
            {
                return finalImage;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Could not build image. Original error: " + ex.Message);
                return finalImage;
            }

        }



        private void comboBox100_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox100.Text = comboBox100.Text;
            textBoxid100.Text = findPlugin(comboBox100.Text).ToString();
            textBoxhover100.Text = findPluginHover(Int32.Parse(textBoxid100.Text));
        }

        private void comboBox101_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox101.Text = comboBox101.Text;
            textBoxid101.Text = findPlugin(comboBox101.Text).ToString();
            textBoxhover101.Text = findPluginHover(Int32.Parse(textBoxid101.Text));
        }
        private void comboBox102_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox102.Text = comboBox102.Text;
            textBoxid102.Text = findPlugin(comboBox102.Text).ToString();
            textBoxhover102.Text = findPluginHover(Int32.Parse(textBoxid102.Text));
        }
        private void comboBox103_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox103.Text = comboBox103.Text;
            textBoxid103.Text = findPlugin(comboBox103.Text).ToString();
            textBoxhover103.Text = findPluginHover(Int32.Parse(textBoxid103.Text));
        }
        private void comboBox104_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox104.Text = comboBox104.Text;
            textBoxid104.Text = findPlugin(comboBox104.Text).ToString();
            textBoxhover104.Text = findPluginHover(Int32.Parse(textBoxid104.Text));
        }
        private void comboBox105_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox105.Text = comboBox105.Text;
            textBoxid105.Text = findPlugin(comboBox105.Text).ToString();
            textBoxhover105.Text = findPluginHover(Int32.Parse(textBoxid105.Text));
        }
        private void comboBox106_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox106.Text = comboBox106.Text;
            textBoxid106.Text = findPlugin(comboBox106.Text).ToString();
            textBoxhover106.Text = findPluginHover(Int32.Parse(textBoxid106.Text));
        }



        public int findPlugin(string pluginName)
        {
            int hyperlink = 0;
            foreach (MPplugin p in plugins)
            {
                if (p.Name == pluginName)
                    hyperlink = p.Hyperlink;
            }
            return hyperlink;
        }

        public string findPluginName(int pluginId)
        {
            string Name = "";
            foreach (MPplugin p in plugins)
            {
                if (p.Hyperlink == pluginId)
                    Name = p.Name;
            }
            return Name;
        }

        public string findPluginHover(int pluginId)
        {
            string Hover = "";
            foreach (MPplugin p in plugins)
            {
                if (p.Hyperlink == pluginId)
                    Hover = p.Hover;
            }
            return Hover;
        }

        public int checkpictures()
        {
            int errors = 0;

            if (pictureBox100.Image == null) errors++;
            if (pictureBox101.Image == null) errors++;
            if (pictureBox102.Image == null) errors++;
            if (pictureBox103.Image == null) errors++;
            if (pictureBox104.Image == null) errors++;
            if (pictureBox105.Image == null) errors++;
            if (pictureBox106.Image == null) errors++;

            return errors;

        }


        public Boolean checkTargetPicture(String id)
        {
            Boolean errors = false;

            if (((PictureBox)((GroupBox)this.Controls["groupBox" + id]).Controls["pictureBox" + id]).Image == null)
            {
                errors = true;
                MessageBox.Show("Error: Button ID " + id + " is empty!");
            }
            if (BlackGlassDirClass.Path == "")
            {
                errors = true;
                MessageBox.Show("Error: Target path is not set!");
            }

            return errors;
        }



        public int checktextboxes()
        {
            int errors = 0;

            if (textBox100.Text == "") errors++;
            if (textBox101.Text == "") errors++;
            if (textBox102.Text == "") errors++;
            if (textBox103.Text == "") errors++;
            if (textBox104.Text == "") errors++;
            if (textBox105.Text == "") errors++;
            if (textBox106.Text == "") errors++;


            if (textBoxid100.Text == "") errors++;
            if (textBoxid101.Text == "") errors++;
            if (textBoxid102.Text == "") errors++;
            if (textBoxid103.Text == "") errors++;
            if (textBoxid104.Text == "") errors++;
            if (textBoxid105.Text == "") errors++;
            if (textBoxid106.Text == "") errors++;


            if (textBoxhover100.Text == "") errors++;
            if (textBoxhover101.Text == "") errors++;
            if (textBoxhover102.Text == "") errors++;
            if (textBoxhover103.Text == "") errors++;
            if (textBoxhover104.Text == "") errors++;
            if (textBoxhover105.Text == "") errors++;
            if (textBoxhover106.Text == "") errors++;

            return errors;
        }

        private void buttonXml_Click(object sender, EventArgs e)
        {
            if (checkTargetPath())
            {

                saveXML();
                saveSettings();

                deleteBlackGlassCacheDir();

                //MessageBox.Show("XML Creation Complete!");
                toolStripStatusLabel1.Text = "XML Creation Complete!";
            }
        }

        private void buttonXMLButtons_Click(object sender, EventArgs e)
        {
            if (checktextboxes() > 0) MessageBox.Show("Error: At least a textbox is empty! All the Button Names and IDs must be filled up!");
            else if (checkpictures() > 0) MessageBox.Show("Error: At least a picture is empty! All the pictures must be filled up!");
            else if (!checkTargetPath()) MessageBox.Show("Error: Target Path not set!");
            else
            {


                // INIZIALIZZAZIONE

                Bitmap finalImage = new Bitmap(1280, 720);
                Bitmap clipImage = new Bitmap(1280, 720);

                Graphics gfx = Graphics.FromImage(finalImage);
                gfx.SmoothingMode = SmoothingMode.AntiAlias;



                Assembly myAssembly = Assembly.GetExecutingAssembly();

                // CARICAMENTO background
                Stream myStream = myAssembly.GetManifestResourceStream("BlackGlassEditor.Images.background.png");
                Bitmap background = new Bitmap(myStream);


                // CARICAMENTO gradient
                myStream = myAssembly.GetManifestResourceStream("BlackGlassEditor.Images.gradient.png");
                Bitmap gradient = new Bitmap(myStream);


                // CARICAMENTO splash
                myStream = myAssembly.GetManifestResourceStream("BlackGlassEditor.Images.splash.png");
                Bitmap splash = new Bitmap(myStream);


                // CARICAMENTO preview
                myStream = myAssembly.GetManifestResourceStream("BlackGlassEditor.Images.preview.png");
                Bitmap preview = new Bitmap(myStream);


                // CREA pulsanti
                Bitmap buttonImage100 = new Bitmap(buildImage(pictureBox100.Image, "100", 0));
                saveImage(BlackGlassDirClass.Path + "\\Media\\basichome_100_nofocus.png", pictureBox100.Image, "100", 0);
                saveImage(BlackGlassDirClass.Path + "\\Media\\basichome_100_focus.png", pictureBox100.Image, "100", 1);

                Bitmap buttonImage101 = new Bitmap(buildImage(pictureBox101.Image, "101", 0));
                saveImage(BlackGlassDirClass.Path + "\\Media\\basichome_101_nofocus.png", pictureBox101.Image, "101", 0);
                saveImage(BlackGlassDirClass.Path + "\\Media\\basichome_101_focus.png", pictureBox101.Image, "101", 1);

                Bitmap buttonImage102 = new Bitmap(buildImage(pictureBox102.Image, "102", 0));
                saveImage(BlackGlassDirClass.Path + "\\Media\\basichome_102_nofocus.png", pictureBox102.Image, "102", 0);
                saveImage(BlackGlassDirClass.Path + "\\Media\\basichome_102_focus.png", pictureBox102.Image, "102", 1);

                Bitmap buttonImage103 = new Bitmap(buildImage(pictureBox103.Image, "103", 0));
                saveImage(BlackGlassDirClass.Path + "\\Media\\basichome_103_nofocus.png", pictureBox103.Image, "103", 0);
                saveImage(BlackGlassDirClass.Path + "\\Media\\basichome_103_focus.png", pictureBox103.Image, "103", 1);

                Bitmap buttonImage104 = new Bitmap(buildImage(pictureBox104.Image, "104", 0));
                saveImage(BlackGlassDirClass.Path + "\\Media\\basichome_104_nofocus.png", pictureBox104.Image, "104", 0);
                saveImage(BlackGlassDirClass.Path + "\\Media\\basichome_104_focus.png", pictureBox104.Image, "104", 1);

                Bitmap buttonImage105 = new Bitmap(buildImage(pictureBox105.Image, "105", 0));
                saveImage(BlackGlassDirClass.Path + "\\Media\\basichome_105_nofocus.png", pictureBox105.Image, "105", 0);
                saveImage(BlackGlassDirClass.Path + "\\Media\\basichome_105_focus.png", pictureBox105.Image, "105", 1);

                Bitmap buttonImage106 = new Bitmap(buildImage(pictureBox106.Image, "106", 0));
                saveImage(BlackGlassDirClass.Path + "\\Media\\basichome_106_nofocus.png", pictureBox106.Image, "106", 0);
                saveImage(BlackGlassDirClass.Path + "\\Media\\basichome_106_focus.png", pictureBox106.Image, "106", 1);




                // Setta il colore trasparente
                Color col = splash.GetPixel(1, 1);


                //CREA bg.jpg

                //gfx.DrawImage(bg, new System.Drawing.Rectangle(0, 0, 1280, 720));




                //CREA basichome_bg.jpg

                gfx.DrawImage(background, new System.Drawing.Rectangle(0, 0, 1280, 720));



                // CREA bg_homefull.jpg 
                gfx.DrawImage(gradient, new System.Drawing.Rectangle(0, 0, 1280, 720));

                gfx.DrawImage(buttonImage100, new System.Drawing.Rectangle(-34, 427, buttonImage100.Width, buttonImage100.Height));
                gfx.DrawImage(buttonImage101, new System.Drawing.Rectangle(188, 444, buttonImage101.Width, buttonImage101.Height));
                gfx.DrawImage(buttonImage102, new System.Drawing.Rectangle(387, 454, buttonImage102.Width, buttonImage102.Height));
                gfx.DrawImage(buttonImage103, new System.Drawing.Rectangle(561, 458, buttonImage103.Width, buttonImage103.Height));
                gfx.DrawImage(buttonImage104, new System.Drawing.Rectangle(722, 454, buttonImage104.Width, buttonImage104.Height));
                gfx.DrawImage(buttonImage105, new System.Drawing.Rectangle(894, 444, buttonImage105.Width, buttonImage105.Height));
                gfx.DrawImage(buttonImage106, new System.Drawing.Rectangle(1090, 427, buttonImage106.Width, buttonImage106.Height));



                //CREA preview.png
                gfx.DrawImage(preview, new System.Drawing.Rectangle(0, 0, 1280, 720));

                try
                {
                    finalImage.Save(BlackGlassDirClass.Path + "\\Media\\preview.png", System.Drawing.Imaging.ImageFormat.Png);
                    toolStripStatusLabel1.Text = "Theme Files Saved Succesfully";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not save preview.jpg to disk. Original error: " + ex.Message);
                }

                //CREA splash.jpg
                gfx.DrawImage(splash, new System.Drawing.Rectangle(0, 0, 1280, 720));

                try
                {
                    ImageCodecInfo jgpEncoder = Functions.GetEncoder(ImageFormat.Jpeg);

                    System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;
                    EncoderParameters myEncoderParameters = new EncoderParameters(1);

                    EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 90L);
                    myEncoderParameters.Param[0] = myEncoderParameter;

                    finalImage.Save(BlackGlassDirClass.Path + "\\Media\\splash.jpg", jgpEncoder, myEncoderParameters);
                    toolStripStatusLabel1.Text = "Theme Files Saved Succesfully";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not save splash.jpg to disk. Original error: " + ex.Message);
                }


                saveXML();
                saveSettings();

                deleteBlackGlassCacheDir();

                //MessageBox.Show("Theme Creation Complete!");
                toolStripStatusLabel1.Text = "Theme Creation Complete!";

            }

        }



        private void buttonPath_Click(object sender, EventArgs e)
        {
            String path = "";
            FolderBrowserDialog DialogFolder = new FolderBrowserDialog();

            if (DialogFolder.ShowDialog() == DialogResult.OK)
            {
                path = DialogFolder.SelectedPath;
                if (path != "") BlackGlassDirClass.Path = path;
            }
        }

        public String findBlackGlassSkinDir()
        {
            String path = "";
            // MP 1.0.2 
            if (Directory.Exists(ProgramFilesx86() + @"\Team MediaPortal\MediaPortal\skin\Black Glass Nova")) path = ProgramFilesx86() + @"\Team MediaPortal\MediaPortal\skin\Black Glass Nova";

            // MP 1.1 
            if (Directory.Exists(Environment.GetEnvironmentVariable("ALLUSERSPROFILE") + @"\Team MediaPortal\MediaPortal\skin\Black Glass Nova")) path = Environment.GetEnvironmentVariable("ALLUSERSPROFILE") +@"\Team MediaPortal\MediaPortal\skin\Black Glass Nova";

            if (path == "") MessageBox.Show("Error: Could not find Black Glass Nova Skin");


            return path;
        }

        static string ProgramFilesx86()
        {
            if (8 == IntPtr.Size || (!String.IsNullOrEmpty(Environment.GetEnvironmentVariable("PROCESSOR_ARCHITEW6432"))))
            {
                return Environment.GetEnvironmentVariable("ProgramFiles(x86)");
            }

            return Environment.GetEnvironmentVariable("ProgramFiles");
        }

        public Boolean checkTargetPath()
        {
            Boolean result = true;

            if (BlackGlassDirClass.Path == "") { result = false; }
            else
            {
                if (!Directory.Exists(BlackGlassDirClass.Path + "\\Media"))
                {
                    Directory.CreateDirectory(BlackGlassDirClass.Path + "\\Media");
                }
            }

            if (result == false) MessageBox.Show("Error: No valid target folder selected!");
            return result;
        }

        public void deleteBlackGlassCacheDir()
        {
            String path = "";
            
            if (Directory.Exists(Environment.GetEnvironmentVariable("ALLUSERSPROFILE") + @"\Team MediaPortal\MediaPortal\Cache\Black Glass Nova")) path = Environment.GetEnvironmentVariable("ALLUSERSPROFILE") + @"\Team MediaPortal\MediaPortal\Cache\Black Glass Nova";
            
            if (path != "") Directory.Delete(path, true);
        }

        public void saveXML()
        {
            if (checktextboxes() > 0) MessageBox.Show("Error: At least a textbox is empty! All the Button Names and IDs must be filled up!");
            else if (BlackGlassDirClass.Path == "") MessageBox.Show("Error: Target Path is not set!");
            else
            {

                String weather_button = "";

                if (textBoxid100.Text == "2600") weather_button = "100";
                if (textBoxid101.Text == "2600") weather_button = "101";
                if (textBoxid102.Text == "2600") weather_button = "102";
                if (textBoxid103.Text == "2600") weather_button = "103";
                if (textBoxid104.Text == "2600") weather_button = "104";
                if (textBoxid105.Text == "2600") weather_button = "105";
                if (textBoxid106.Text == "2600") weather_button = "106";



                String tvseries_button = "";

                if (textBoxid100.Text == "9811") tvseries_button = "100";
                if (textBoxid101.Text == "9811") tvseries_button = "101";
                if (textBoxid102.Text == "9811") tvseries_button = "102";
                if (textBoxid103.Text == "9811") tvseries_button = "103";
                if (textBoxid104.Text == "9811") tvseries_button = "104";
                if (textBoxid105.Text == "9811") tvseries_button = "105";
                if (textBoxid106.Text == "9811") tvseries_button = "106";


                String movingpictures_button = "";

                if (textBoxid100.Text == "96742") movingpictures_button = "100";
                if (textBoxid101.Text == "96742") movingpictures_button = "101";
                if (textBoxid102.Text == "96742") movingpictures_button = "102";
                if (textBoxid103.Text == "96742") movingpictures_button = "103";
                if (textBoxid104.Text == "96742") movingpictures_button = "104";
                if (textBoxid105.Text == "96742") movingpictures_button = "105";
                if (textBoxid106.Text == "96742") movingpictures_button = "106";


                string txt = @"<?xml version=""1.0"" encoding=""utf-8"" standalone=""yes""?>
<window>
  <controls>
        
        <!-- ID 100 -->
		<control>
			<description>100 button</description>
			<type>button</type>
			<id>100</id>
			<posX>-34</posX>
			<posY>427</posY>
			<width>230</width>
			<height>266</height>
			<label>" + SecurityElement.Escape(textBox100.Text) + @"</label>
			<textXOff>3000</textXOff>
			<hyperlink>" + SecurityElement.Escape(textBoxid100.Text) + @"</hyperlink>
			<onleft>106</onleft>
			<onright>101</onright>
			<onup>18</onup>
			<ondown>1111</ondown>
			<textureFocus>basichome_100_focus.png</textureFocus>
			<textureNoFocus>basichome_100_nofocus.png</textureNoFocus>
			<animation effect=""zoom"" start=""100,100"" end=""110,110"" time=""250"">focus</animation>
			<animation effect=""slide"" end=""0,-4"" time=""250"">focus</animation>
		</control>
		<control>
			<description>100 hover label</description>
			<type>label</type>
			<id>0</id>
			<posX>0</posX>
			<posY>625</posY>
			<label>" + SecurityElement.Escape(textBox100.Text) + @"</label>
			<width>1280</width>
			<font>font40</font>
			<align>center</align>
			<visible>control.hasfocus(100)</visible>
			<textcolor>ffffffff</textcolor>
			<animation effect=""fade"" time=""250"">VisibleChange</animation>
		</control>


        <!-- ID 101 -->
		<control>
			<description>101 button</description>
			<type>button</type>
			<id>101</id>
			<posX>188</posX>
			<posY>444</posY>
			<width>204</width>
			<height>204</height>
			<label>" + SecurityElement.Escape(textBox101.Text) + @"</label>
			<textXOff>3000</textXOff>
			<hyperlink>" + SecurityElement.Escape(textBoxid101.Text) + @"</hyperlink>
			<onleft>100</onleft>
			<onright>102</onright>
			<onup>18</onup>
			<ondown>1111</ondown>
			<textureFocus>basichome_101_focus.png</textureFocus>
			<textureNoFocus>basichome_101_nofocus.png</textureNoFocus>
			<animation effect=""zoom"" start=""100,100"" end=""110,110"" time=""250"">focus</animation>
			<animation effect=""slide"" end=""0,-4"" time=""250"">focus</animation>
		</control>
		<control>
			<description>101 hover label</description>
			<type>label</type>
			<id>0</id>
			<posX>0</posX>
			<posY>625</posY>
			<label>" + SecurityElement.Escape(textBox101.Text) + @"</label>
			<width>1280</width>
			<font>font40</font>
			<align>center</align>
			<visible>control.hasfocus(101)</visible>
			<textcolor>ffffffff</textcolor>
			<animation effect=""fade"" time=""250"">VisibleChange</animation>
		</control>


		<!-- ID 102 -->
		<control>
			<description>102 button</description>
			<type>button</type>
			<id>102</id>
			<posX>387</posX>
			<posY>454</posY>
			<width>178</width>
			<height>191</height>
			<label>" + SecurityElement.Escape(textBox102.Text) + @"</label>
			<textXOff>3000</textXOff>
			<hyperlink>" + SecurityElement.Escape(textBoxid102.Text) + @"</hyperlink>
			<onleft>101</onleft>
			<onright>103</onright>
			<onup>18</onup>
			<ondown>1111</ondown>
			<textureFocus>basichome_102_focus.png</textureFocus>
			<textureNoFocus>basichome_102_nofocus.png</textureNoFocus>
			<animation effect=""zoom"" start=""100,100"" end=""108,108"" time=""250"">focus</animation>
			<animation effect=""slide"" end=""0,-2"" time=""250"">focus</animation>
		</control>
		<control>
			<description>102 hover label</description>
			<type>label</type>
			<id>0</id>
			<posX>0</posX>
			<posY>625</posY>
			<label>" + SecurityElement.Escape(textBox102.Text) + @"</label>
			<width>1280</width>
			<font>font40</font>
			<align>center</align>
			<visible>control.hasfocus(102)</visible>
			<textcolor>ffffffff</textcolor>
			<animation effect=""fade"" time=""250"">VisibleChange</animation>
		</control>


		<!-- ID 103 -->
		<control>
			<description>103 button</description>
			<type>button</type>
			<id>103</id>
			<posX>561</posX>
			<posY>458</posY>
			<width>168</width>
			<height>183</height>
			<label>" + SecurityElement.Escape(textBox103.Text) + @"</label>
			<textXOff>3000</textXOff>
			<hyperlink>" + SecurityElement.Escape(textBoxid103.Text) + @"</hyperlink>
			<onleft>102</onleft>
			<onright>104</onright>
			<onup>18</onup>
			<ondown>1111</ondown>
			<textureFocus>basichome_103_focus.png</textureFocus>
			<textureNoFocus>basichome_103_nofocus.png</textureNoFocus>
			<animation effect=""zoom"" start=""100,100"" end=""107,107"" time=""250"">focus</animation>
			<animation effect=""slide"" end=""0,-1"" time=""250"">focus</animation>
		</control>
		<control>
			<description>103 hover label</description>
			<type>label</type>
			<id>0</id>
			<posX>0</posX>
			<posY>625</posY>
			<label>" + SecurityElement.Escape(textBox103.Text) + @"</label>
			<width>1280</width>
			<font>font40</font>
			<align>center</align>
			<visible>control.hasfocus(103)</visible>
			<textcolor>ffffffff</textcolor>
			<animation effect=""fade"" time=""250"">VisibleChange</animation>
		</control>


		<!-- ID 104 -->
		<control>
			<description>104 button</description>
			<type>button</type>
			<id>104</id>
			<posX>722</posX>
			<posY>454</posY>
			<width>178</width>
			<height>191</height>
			<label>" + SecurityElement.Escape(textBox104.Text) + @"</label>
			<textXOff>3000</textXOff>
			<hyperlink>" + SecurityElement.Escape(textBoxid104.Text) + @"</hyperlink>
			<onleft>103</onleft>
			<onright>105</onright>
			<onup>18</onup>
			<ondown>1111</ondown>
			<textureFocus>basichome_104_focus.png</textureFocus>
			<textureNoFocus>basichome_104_nofocus.png</textureNoFocus>
			<animation effect=""zoom"" start=""100,100"" end=""108,108"" time=""250"">focus</animation>
			<animation effect=""slide"" end=""0,-2"" time=""250"">focus</animation>
		</control>
		<control>
			<description>104 hover label</description>
			<type>label</type>
			<id>0</id>
			<posX>0</posX>
			<posY>625</posY>
			<label>" + SecurityElement.Escape(textBox104.Text) + @"</label>
			<width>1280</width>
			<font>font40</font>
			<align>center</align>
			<visible>control.hasfocus(104)</visible>
			<textcolor>ffffffff</textcolor>
			<animation effect=""fade"" time=""250"">VisibleChange</animation>
		</control>


		<!-- ID 105 -->
		<control>
			<description>105 button</description>
			<type>button</type>
			<id>105</id>
			<posX>894</posX>
			<posY>444</posY>
			<width>204</width>
			<height>211</height>
			<label>" + SecurityElement.Escape(textBox105.Text) + @"</label>
			<textXOff>3000</textXOff>
			<hyperlink>" + SecurityElement.Escape(textBoxid105.Text) + @"</hyperlink>
			<onleft>104</onleft>
			<onright>106</onright>
			<onup>18</onup>
			<ondown>1111</ondown>
			<textureFocus>basichome_105_focus.png</textureFocus>
			<textureNoFocus>basichome_105_nofocus.png</textureNoFocus>
			<animation effect=""zoom"" start=""100,100"" end=""110,110"" time=""250"">focus</animation>
			<animation effect=""slide"" end=""0,-4"" time=""250"">focus</animation>
		</control>
		<control>
			<description>105 hover label</description>
			<type>label</type>
			<id>0</id>
			<posX>0</posX>
			<posY>625</posY>
			<label>" + SecurityElement.Escape(textBox105.Text) + @"</label>
			<width>1280</width>
			<font>font40</font>
			<align>center</align>
			<visible>control.hasfocus(105)</visible>
			<textcolor>ffffffff</textcolor>
			<animation effect=""fade"" time=""250"">VisibleChange</animation>
		</control>


		<!-- ID 106 -->
		<control>
			<description>106 button</description>
			<type>button</type>
			<id>106</id>
			<posX>1090</posX>
			<posY>427</posY>
			<width>226</width>
			<height>256</height>
			<label>" + SecurityElement.Escape(textBox106.Text) + @"</label>
			<textXOff>3000</textXOff>
			<hyperlink>" + SecurityElement.Escape(textBoxid106.Text) + @"</hyperlink>
			<onleft>105</onleft>
			<onright>100</onright>
			<onup>18</onup>
			<ondown>1111</ondown>
			<textureFocus>basichome_106_focus.png</textureFocus>
			<textureNoFocus>basichome_106_nofocus.png</textureNoFocus>
			<animation effect=""zoom"" start=""100,100"" end=""110,110"" time=""250"">focus</animation>
			<animation effect=""slide"" end=""0,-4"" time=""250"">focus</animation>
		</control>
		<control>
			<description>106 hover label</description>
			<type>label</type>
			<id>0</id>
			<posX>0</posX>
			<posY>625</posY>
			<label>" + SecurityElement.Escape(textBox106.Text) + @"</label>
			<width>1280</width>
			<font>font40</font>
			<align>center</align>
			<visible>control.hasfocus(106)</visible>
			<textcolor>ffffffff</textcolor>
			<animation effect=""fade"" time=""250"">VisibleChange</animation>
		</control>



		


        <!-- SUBTITLES -->";

                if (weather_button != "") txt = txt
                 + @"
        <control>
			<description>Weather Description</description>
			<type>label</type>
			<id>0</id>
			<posX>0</posX>
			<posY>666</posY>
			<width>1280</width>
			<label>#infoservice.weather.today.temp  .  #infoservice.weather.today.humidity  .  #infoservice.weather.today.condition  .  #infoservice.weather.location</label>
			<align>center</align>
			<font>font11</font>
			<visible>plugin.isenabled(InfoService)+control.hasfocus(" + weather_button + @")</visible>
			<textcolor>90ffffff</textcolor>
            <animation effect=""fade"" time=""250"">VisibleChange</animation>
		</control>";



                if (tvseries_button != "") txt = txt
                + @"
        <control>
			<description>TVSeries updates</description>
			<type>label</type>
			<id>0</id>
			<posX>0</posX>
			<posY>666</posY>
			<width>1280</width>
			<label>Latest episode added: #infoservice.recentlyAdded.series[1].title  .  Season #infoservice.recentlyAdded.series[1].season  .  Episode #infoservice.recentlyAdded.series[1].episodenumber  .  #infoservice.recentlyAdded.series[1].episodetitle</label>
			<align>center</align>
			<font>font11</font>
			<visible>plugin.isenabled(InfoService)+control.hasfocus(" + tvseries_button + @")+plugin.isenabled(MP-TV Series)</visible>
			<textcolor>90ffffff</textcolor>
            <animation effect=""fade"" time=""250"">VisibleChange</animation>
		</control>";

                if (movingpictures_button != "") txt = txt
                + @"
        <!-- <control>
			<description>Moving Pictures updates</description>
			<type>label</type>
			<id>0</id>
			<posX>0</posX>
			<posY>666</posY>
			<width>1280</width>
			<label>Latest movie added: #infoservice.recentlyAdded.movie[1].title</label>
			<align>center</align>
			<font>font11</font>
			<visible>plugin.isenabled(InfoService)+control.hasfocus(" + movingpictures_button + @")+plugin.isenabled(Moving Pictures)</visible>
			<textcolor>90ffffff</textcolor>
            <animation effect=""fade"" time=""250"">VisibleChange</animation>
		</control> -->";

                txt = txt + @"
    </controls>
</window>";


                String path = BlackGlassDirClass.Path + "\\BasicHome_Buttons.xml";

                try
                {
                    TextWriter tw = new StreamWriter(path);

                    // write a line of text to the file
                    tw.Write(txt);

                    // close the stream
                    tw.Close();
                    //txt.Save(path, System.Drawing.Imaging.ImageFormat.Png);
                    toolStripStatusLabel1.Text = "XML File Saved Succesfully";
                    //MessageBox.Show("File Saved!");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not save file to disk. Original error: " + ex.Message);
                }


                // BACKDROPS

                txt = @"<?xml version=""1.0"" encoding=""utf-8"" standalone=""yes""?>
<window>
	<controls>
		
	<control>
			<description>100 image</description>
			<type>image</type>
			<id>0</id>
			<posX>0</posX>
			<posY>0</posY>
			<width>1280</width>
			<height>720</height>
			<texture>" + SecurityElement.Escape(textBoxhover100.Text) + @".png</texture>
			<visible>control.hasfocus(100)</visible>
			<animation effect=""fade"" time=""250"">visible</animation>
		</control>
		<control>
			<description>101 image</description>
			<type>image</type>
			<id>0</id>
			<posX>0</posX>
			<posY>0</posY>
			<width>1280</width>
			<height>720</height>
			<texture>" + SecurityElement.Escape(textBoxhover101.Text) + @".png</texture>
			<visible>control.hasfocus(101)</visible>
			<animation effect=""fade"" time=""250"">visible</animation>
		</control>
		<control>
			<description>102 image</description>
			<type>image</type>
			<id>0</id>
			<posX>0</posX>
			<posY>0</posY>
			<width>1280</width>
			<height>720</height>
			<texture>" + SecurityElement.Escape(textBoxhover102.Text) + @".png</texture>
			<visible>control.hasfocus(102)</visible>
			<animation effect=""fade"" time=""250"">visible</animation>
		</control>
		<control>
			<description>103 image</description>
			<type>image</type>
			<id>0</id>
			<posX>0</posX>
			<posY>0</posY>
			<width>1280</width>
			<height>720</height>
			<texture>" + SecurityElement.Escape(textBoxhover103.Text) + @".png</texture>
			<visible>control.hasfocus(103)</visible>
			<animation effect=""fade"" time=""250"">visible</animation>
		</control>
		<control>
			<description>104 image</description>
			<type>image</type>
			<id>0</id>
			<posX>0</posX>
			<posY>0</posY>
			<width>1280</width>
			<height>720</height>
			<texture>" + SecurityElement.Escape(textBoxhover104.Text) + @".png</texture>
			<visible>control.hasfocus(104)</visible>
			<animation effect=""fade"" time=""250"">visible</animation>
		</control>
		<control>
			<description>105 image</description>
			<type>image</type>
			<id>0</id>
			<posX>0</posX>
			<posY>0</posY>
			<width>1280</width>
			<height>720</height>
			<texture>" + SecurityElement.Escape(textBoxhover105.Text) + @".png</texture>
			<visible>control.hasfocus(105)</visible>
			<animation effect=""fade"" time=""250"">visible</animation>
		</control>
		<control>
			<description>106 image</description>
			<type>image</type>
			<id>0</id>
			<posX>0</posX>
			<posY>0</posY>
			<width>1280</width>
			<height>720</height>
			<texture>" + SecurityElement.Escape(textBoxhover106.Text) + @".png</texture>
			<visible>control.hasfocus(106)</visible>
			<animation effect=""fade"" time=""250"">visible</animation>
		</control>
		
		
		";
                if (weather_button != "") txt = txt + @"<control>
			<description>weather image</description>
			<type>image</type>
			<id>0</id>
			<posX>0</posX>
			<posY>0</posY>
			<width>1280</width>
			<height>720</height>
			<texture>animations\weather\#infoservice.weather.today.img.big.filenamewithoutext.jpg</texture>
			<visible>control.hasfocus(" + weather_button + @")+plugin.isenabled(InfoService)</visible>
			<animation effect=""fade"" time=""250"">visible</animation>
		</control>
		
	";

                if (tvseries_button != "") txt = txt + @"<control>
			<description>TV Series image</description>
			<type>image</type>
			<id>0</id>
			<posX>0</posX>
			<posY>0</posY>
			<width>1280</width>
			<height>720</height>
			<texture>#infoservice.recentlyAdded.series[1].fanart</texture>
			<visible>control.hasfocus(" + tvseries_button + @")+plugin.isenabled(InfoService)</visible>
			<animation effect=""fade"" time=""250"">visible</animation>
		</control>
		
	";
                txt = txt + @"</controls>
</window>";

                path = BlackGlassDirClass.Path + "\\BasicHome_Backdrops.xml";

                try
                {
                    TextWriter tw = new StreamWriter(path);

                    // write a line of text to the file
                    tw.Write(txt);

                    // close the stream
                    tw.Close();
                    //txt.Save(path, System.Drawing.Imaging.ImageFormat.Png);
                    toolStripStatusLabel1.Text = "XML File Saved Succesfully";
                    //MessageBox.Show("File Saved!");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not save file to disk. Original error: " + ex.Message);
                }

            }
        }

        public void saveSettings()
        {
            try
            {

                // write a line of text to the file


                String path = System.IO.Path.Combine(Application.StartupPath, "settings.xml");
                // Create a new file in C:\\ dir
                XmlTextWriter textWriter = new XmlTextWriter(path, null);
                textWriter.Formatting = Formatting.Indented;
                // Opens the document
                textWriter.WriteStartDocument();
                // Write first element
                textWriter.WriteStartElement("Buttons");

                textWriter.WriteStartElement("button");
                textWriter.WriteStartElement("Id", "");
                textWriter.WriteString("100");
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("name", "");
                textWriter.WriteString(SecurityElement.Escape(textBox100.Text));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("plugin", "");
                textWriter.WriteString(SecurityElement.Escape(textBoxid100.Text));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("hover", "");
                textWriter.WriteString(SecurityElement.Escape(textBoxhover100.Text));
                textWriter.WriteEndElement();
                textWriter.WriteEndElement();

                textWriter.WriteStartElement("button");
                textWriter.WriteStartElement("Id", "");
                textWriter.WriteString("101");
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("name", "");
                textWriter.WriteString(SecurityElement.Escape(textBox101.Text));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("plugin", "");
                textWriter.WriteString(SecurityElement.Escape(textBoxid101.Text));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("hover", "");
                textWriter.WriteString(SecurityElement.Escape(textBoxhover101.Text));
                textWriter.WriteEndElement();
                textWriter.WriteEndElement();

                textWriter.WriteStartElement("button");
                textWriter.WriteStartElement("Id", "");
                textWriter.WriteString("102");
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("name", "");
                textWriter.WriteString(SecurityElement.Escape(textBox102.Text));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("plugin", "");
                textWriter.WriteString(SecurityElement.Escape(textBoxid102.Text));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("hover", "");
                textWriter.WriteString(SecurityElement.Escape(textBoxhover102.Text));
                textWriter.WriteEndElement();
                textWriter.WriteEndElement();

                textWriter.WriteStartElement("button");
                textWriter.WriteStartElement("Id", "");
                textWriter.WriteString("103");
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("name", "");
                textWriter.WriteString(SecurityElement.Escape(textBox103.Text));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("plugin", "");
                textWriter.WriteString(SecurityElement.Escape(textBoxid103.Text));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("hover", "");
                textWriter.WriteString(SecurityElement.Escape(textBoxhover103.Text));
                textWriter.WriteEndElement();
                textWriter.WriteEndElement();

                textWriter.WriteStartElement("button");
                textWriter.WriteStartElement("Id", "");
                textWriter.WriteString("104");
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("name", "");
                textWriter.WriteString(SecurityElement.Escape(textBox104.Text));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("plugin", "");
                textWriter.WriteString(SecurityElement.Escape(textBoxid104.Text));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("hover", "");
                textWriter.WriteString(SecurityElement.Escape(textBoxhover104.Text));
                textWriter.WriteEndElement();
                textWriter.WriteEndElement();

                textWriter.WriteStartElement("button");
                textWriter.WriteStartElement("Id", "");
                textWriter.WriteString("105");
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("name", "");
                textWriter.WriteString(SecurityElement.Escape(textBox105.Text));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("plugin", "");
                textWriter.WriteString(SecurityElement.Escape(textBoxid105.Text));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("hover", "");
                textWriter.WriteString(SecurityElement.Escape(textBoxhover105.Text));
                textWriter.WriteEndElement();
                textWriter.WriteEndElement();

                textWriter.WriteStartElement("button");
                textWriter.WriteStartElement("Id", "");
                textWriter.WriteString("106");
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("name", "");
                textWriter.WriteString(SecurityElement.Escape(textBox106.Text));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("plugin", "");
                textWriter.WriteString(SecurityElement.Escape(textBoxid106.Text));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("hover", "");
                textWriter.WriteString(SecurityElement.Escape(textBoxhover106.Text));
                textWriter.WriteEndElement();
                textWriter.WriteEndElement();




                // Ends the document.

                textWriter.WriteEndDocument();
                // close writer
                textWriter.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Could not save file to disk. Original error: " + ex.Message);
            }
        }

        public void createMediaFolder()
        {

            //Create a new subfolder under the current active folder
            string newPath = System.IO.Path.Combine(BlackGlassDirClass.Path, "Media");

            // Create the subfolder
            System.IO.Directory.CreateDirectory(newPath);

        }

        private void buttonTarget_Click(object sender, EventArgs e)
        {

            DialogFolder.SelectedPath = BlackGlassDirClass.Path;
            //this.label1.Text = DialogFolder.SelectedPath;
            if (DialogFolder.ShowDialog() == DialogResult.OK)
            {
                textBoxTarget.Text = DialogFolder.SelectedPath;
                BlackGlassDirClass.Path = DialogFolder.SelectedPath;
            }
        }


    }

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
            get
            {
                return _hyperlink;
            }
            set
            {
                _hyperlink = value;
            }
        }
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public string Hover
        {
            get
            {
                return _hover;
            }
            set
            {
                _hover = value;
            }
        }


        public MPplugin() { }
        public MPplugin(int hyperlink, string name, string hover)
        {
            this._hyperlink = hyperlink;
            this._name = name;
            this._hover = hover;

        }
    }
}