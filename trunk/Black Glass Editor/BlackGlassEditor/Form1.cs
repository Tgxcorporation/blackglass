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

            plugins.Add(new MPplugin(5000, "Alarm")); 
            plugins.Add(new MPplugin(6001, "Anime"));
            plugins.Add(new MPplugin(760, "Burner"));
            plugins.Add(new MPplugin(1987, "Clipta Video Search"));
            plugins.Add(new MPplugin(7676, "Daily Comics"));
            plugins.Add(new MPplugin(63453335, "EarthTV"));
            plugins.Add(new MPplugin(330099, "Email Manager"));
            plugins.Add(new MPplugin(2497, "Emulators"));
            plugins.Add(new MPplugin(800, "Extensions"));
            plugins.Add(new MPplugin(1666, "FANatic Monitor"));
            plugins.Add(new MPplugin(7986, "Films"));
            plugins.Add(new MPplugin(557311, "File Explorer"));
            plugins.Add(new MPplugin(464554871, "FritzManager"));
            plugins.Add(new MPplugin(16004, "GeckoBrowser"));
            plugins.Add(new MPplugin(30885, "Global Search"));
            plugins.Add(new MPplugin(7972, "HTPCInfo"));
            plugins.Add(new MPplugin(16001, "Infoservice RSS"));
            plugins.Add(new MPplugin(16003, "Infoservice Twitter"));
            plugins.Add(new MPplugin(6912, "Justin.tv"));
            plugins.Add(new MPplugin(7890, "Last.fm"));
            plugins.Add(new MPplugin(90478, "Lyrics")); 
            plugins.Add(new MPplugin(7980, "MediaTip"));
            plugins.Add(new MPplugin(8765, "Media Slayer"));
            plugins.Add(new MPplugin(16581, "Meteo.hr"));
            plugins.Add(new MPplugin(96742, "Moving Pictures"));
            plugins.Add(new MPplugin(801, "MpeInstaller"));
            plugins.Add(new MPplugin(3847, "MpNZB"));
            plugins.Add(new MPplugin(0, "Multishortcut"));
            plugins.Add(new MPplugin(501, "Music"));
            plugins.Add(new MPplugin(504, "Music Genres"));
            plugins.Add(new MPplugin(880, "Music Videos"));
            plugins.Add(new MPplugin(10099, "Netflix"));
            plugins.Add(new MPplugin(2700, "News RSS"));
            plugins.Add(new MPplugin(30050, "Online Photos and Friends"));
            plugins.Add(new MPplugin(4755, "Online Videos"));
            plugins.Add(new MPplugin(2, "Pictures"));
            plugins.Add(new MPplugin(34, "Plugins"));
            plugins.Add(new MPplugin(3, "Programs"));
            plugins.Add(new MPplugin(30, "Radio"));
            plugins.Add(new MPplugin(25650, "RadioTime"));
            plugins.Add(new MPplugin(42000, "Score Center"));
            plugins.Add(new MPplugin(4, "Settings"));
            plugins.Add(new MPplugin(2345, "Shoutcast"));
            plugins.Add(new MPplugin(7111992, "Showtimes"));
            plugins.Add(new MPplugin(1911, "Skype"));
            plugins.Add(new MPplugin(7969, "Sleep Control"));
            plugins.Add(new MPplugin(45678, "Smart Playlists"));
            plugins.Add(new MPplugin(15634330, "Stream Radio"));
            plugins.Add(new MPplugin(7777, "Sudoku"));
            plugins.Add(new MPplugin(7700, "Teletext"));
            plugins.Add(new MPplugin(7776, "Tetris"));
            plugins.Add(new MPplugin(5900, "Trailers"));
            plugins.Add(new MPplugin(1, "TV"));
            plugins.Add(new MPplugin(6799, "TV Gemist"));
            plugins.Add(new MPplugin(9811, "TV Series"));
            plugins.Add(new MPplugin(5678, "Torrents"));
            plugins.Add(new MPplugin(6, "Videos"));
            plugins.Add(new MPplugin(25, "Video Titles"));
            plugins.Add(new MPplugin(2959, "Video Editor"));
            plugins.Add(new MPplugin(7971, "Volume Control"));
            plugins.Add(new MPplugin(2600, "Weather"));
            plugins.Add(new MPplugin(4711, "Wikipedia"));
            plugins.Add(new MPplugin(7978, "World Clock"));
            plugins.Add(new MPplugin(10234, "WorldMap"));
            plugins.Add(new MPplugin(29050, "Youtube.fm"));



            foreach (MPplugin p in plugins)
            {
                comboBox100.Items.Add(p.Name);
                comboBox101.Items.Add(p.Name);
                comboBox102.Items.Add(p.Name);
                comboBox103.Items.Add(p.Name);
                comboBox104.Items.Add(p.Name);
                comboBox105.Items.Add(p.Name);
                comboBox106.Items.Add(p.Name);
                comboBox107.Items.Add(p.Name);
                comboBox108.Items.Add(p.Name);
                comboBox109.Items.Add(p.Name);
                comboBox110.Items.Add(p.Name);
                comboBox111.Items.Add(p.Name);
                comboBox112.Items.Add(p.Name);
                comboBox113.Items.Add(p.Name);
                comboBox114.Items.Add(p.Name);
            }




            string path = System.IO.Path.Combine(Application.StartupPath, "settings.xml");
            FileStream READER = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite); 
            System.Xml.XmlDocument Buttons = new System.Xml.XmlDocument();
            Buttons.Load(READER); 
            System.Xml.XmlNodeList NodeList = Buttons.GetElementsByTagName("Buttons"); 


            XmlNodeList name = Buttons.GetElementsByTagName("name");
            XmlNodeList plugin = Buttons.GetElementsByTagName("plugin");

            comboBox100.SelectedItem = findPluginName(Int32.Parse(plugin[0].InnerText));
            comboBox101.SelectedItem = findPluginName(Int32.Parse(plugin[1].InnerText));
            comboBox102.SelectedItem = findPluginName(Int32.Parse(plugin[2].InnerText));
            comboBox103.SelectedItem = findPluginName(Int32.Parse(plugin[3].InnerText));
            comboBox104.SelectedItem = findPluginName(Int32.Parse(plugin[4].InnerText));
            comboBox105.SelectedItem = findPluginName(Int32.Parse(plugin[5].InnerText));
            comboBox106.SelectedItem = findPluginName(Int32.Parse(plugin[6].InnerText));
            comboBox107.SelectedItem = findPluginName(Int32.Parse(plugin[7].InnerText));
            comboBox108.SelectedItem = findPluginName(Int32.Parse(plugin[8].InnerText));
            comboBox109.SelectedItem = findPluginName(Int32.Parse(plugin[9].InnerText));
            comboBox110.SelectedItem = findPluginName(Int32.Parse(plugin[10].InnerText));
            comboBox111.SelectedItem = findPluginName(Int32.Parse(plugin[11].InnerText));
            comboBox112.SelectedItem = findPluginName(Int32.Parse(plugin[12].InnerText));
            comboBox113.SelectedItem = findPluginName(Int32.Parse(plugin[13].InnerText));
            comboBox114.SelectedItem = findPluginName(Int32.Parse(plugin[14].InnerText));


            textBox100.Text = name[0].InnerText;
            textBox101.Text = name[1].InnerText;
            textBox102.Text = name[2].InnerText;
            textBox103.Text = name[3].InnerText;
            textBox104.Text = name[4].InnerText;
            textBox105.Text = name[5].InnerText;
            textBox106.Text = name[6].InnerText;
            textBox107.Text = name[7].InnerText;
            textBox108.Text = name[8].InnerText;
            textBox109.Text = name[9].InnerText;
            textBox110.Text = name[10].InnerText;
            textBox111.Text = name[11].InnerText;
            textBox112.Text = name[12].InnerText;
            textBox113.Text = name[13].InnerText;
            textBox114.Text = name[14].InnerText;

            textBoxid100.Text = plugin[0].InnerText;
            textBoxid101.Text = plugin[1].InnerText;
            textBoxid102.Text = plugin[2].InnerText;
            textBoxid103.Text = plugin[3].InnerText;
            textBoxid104.Text = plugin[4].InnerText;
            textBoxid105.Text = plugin[5].InnerText;
            textBoxid106.Text = plugin[6].InnerText;
            textBoxid107.Text = plugin[7].InnerText;
            textBoxid108.Text = plugin[8].InnerText;
            textBoxid109.Text = plugin[9].InnerText;
            textBoxid110.Text = plugin[10].InnerText;
            textBoxid111.Text = plugin[11].InnerText;
            textBoxid112.Text = plugin[12].InnerText;
            textBoxid113.Text = plugin[13].InnerText;
            textBoxid114.Text = plugin[14].InnerText;


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

                            Size newsize = new Size(239, 245);

                            Point topleft = new Point(18, 3);
                            Point topright = new Point(232, 13);
                            Point bottomleft = new Point(6, 163);
                            Point bottomright = new Point(226, 150);

                            img = QuadDistort.Distort((Bitmap)Functions.resizeImage((Bitmap)img, newsize), topleft, topright, bottomleft, bottomright);


                            Bitmap reflectedImg = (Bitmap)Bitmap.FromFile(DialogOpen.FileName);
                            reflectedImg.RotateFlip(RotateFlipType.RotateNoneFlipY);

                            topleft = new Point(11, 157);
                            topright = new Point(236, 131);
                            bottomleft = new Point(3, 305);
                            bottomright = new Point(232, 300);

                            reflectedImg = QuadDistort.Distort((Bitmap)Functions.resizeImage((Bitmap)reflectedImg, newsize), topleft, topright, bottomleft, bottomright);

                            Bitmap dummyImage = new Bitmap(239, 245);
                            Graphics ga = Graphics.FromImage(dummyImage);
                            ga.DrawImage(img, new System.Drawing.Rectangle(0, 0, img.Width, img.Height));
                            ga.DrawImage(reflectedImg, new System.Drawing.Rectangle(-5, 89, img.Width, img.Height));
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

                            Size newsize = new Size(209, 214);

                            Point topleft = new Point(11, 3);
                            Point topright = new Point(202, 7);
                            Point bottomleft = new Point(6, 137);
                            Point bottomright = new Point(200, 132);

                            img = QuadDistort.Distort((Bitmap)Functions.resizeImage((Bitmap)img, newsize), topleft, topright, bottomleft, bottomright);


                            Bitmap reflectedImg = (Bitmap)Bitmap.FromFile(DialogOpen.FileName);
                            reflectedImg.RotateFlip(RotateFlipType.RotateNoneFlipY);

                            topleft = new Point(6, 134);
                            topright = new Point(203, 120);
                            bottomleft = new Point(0, 280);
                            bottomright = new Point(205, 284);

                            reflectedImg = QuadDistort.Distort((Bitmap)Functions.resizeImage((Bitmap)reflectedImg, newsize), topleft, topright, bottomleft, bottomright);

                            Bitmap dummyImage = new Bitmap(209, 214);
                            Graphics ga = Graphics.FromImage(dummyImage);
                            ga.DrawImage(img, new System.Drawing.Rectangle(0, 0, img.Width, img.Height));
                            ga.DrawImage(reflectedImg, new System.Drawing.Rectangle(0, 82, img.Width, img.Height));
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

                            Size newsize = new Size(196, 205);

                            Point topleft = new Point(7, 3);
                            Point topright = new Point(189, 3);
                            Point bottomleft = new Point(7, 127);
                            Point bottomright = new Point(189, 127);

                            img = QuadDistort.Distort((Bitmap)Functions.resizeImage((Bitmap)img, newsize), topleft, topright, bottomleft, bottomright);


                            Bitmap reflectedImg = (Bitmap)Bitmap.FromFile(DialogOpen.FileName);
                            reflectedImg.RotateFlip(RotateFlipType.RotateNoneFlipY);

                            topleft = new Point(6, 89);
                            topright = new Point(193, 89);
                            bottomleft = new Point(6, 204);
                            bottomright = new Point(193, 204);

                            reflectedImg = QuadDistort.Distort((Bitmap)Functions.resizeImage((Bitmap)reflectedImg, newsize), topleft, topright, bottomleft, bottomright);

                            Bitmap dummyImage = new Bitmap(196, 205);
                            Graphics ga = Graphics.FromImage(dummyImage);
                            ga.DrawImage(img, new System.Drawing.Rectangle(0, 0, img.Width, img.Height));
                            ga.DrawImage(reflectedImg, new System.Drawing.Rectangle(0, 80, img.Width, img.Height));
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

                            Size newsize = new Size(209, 215);

                            Point topleft = new Point(6, 8);
                            Point topright = new Point(196, 3);
                            Point bottomleft = new Point(8, 132);
                            Point bottomright = new Point(202, 136);

                            img = QuadDistort.Distort((Bitmap)Functions.resizeImage((Bitmap)img, newsize), topleft, topright, bottomleft, bottomright);


                            Bitmap reflectedImg = (Bitmap)Bitmap.FromFile(DialogOpen.FileName);
                            reflectedImg.RotateFlip(RotateFlipType.RotateNoneFlipY);

                            topleft = new Point(3, 93);
                            topright = new Point(202, 100);
                            bottomleft = new Point(3, 215);
                            bottomright = new Point(209, 215);

                            reflectedImg = QuadDistort.Distort((Bitmap)Functions.resizeImage((Bitmap)reflectedImg, newsize), topleft, topright, bottomleft, bottomright);

                            Bitmap dummyImage = new Bitmap(209, 215);
                            Graphics ga = Graphics.FromImage(dummyImage);
                            ga.DrawImage(img, new System.Drawing.Rectangle(0, 0, img.Width, img.Height));
                            ga.DrawImage(reflectedImg, new System.Drawing.Rectangle(6, 82, img.Width, img.Height));
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

                            Size newsize = new Size(239, 242);

                            Point topleft = new Point(7, 14);
                            Point topright = new Point(220, 3);
                            Point bottomleft = new Point(12, 150);
                            Point bottomright = new Point(232, 163);

                            img = QuadDistort.Distort((Bitmap)Functions.resizeImage((Bitmap)img, newsize), topleft, topright, bottomleft, bottomright);


                            Bitmap reflectedImg = (Bitmap)Bitmap.FromFile(DialogOpen.FileName);
                            reflectedImg.RotateFlip(RotateFlipType.RotateNoneFlipY);

                            topleft = new Point(5, 122);
                            topright = new Point(234, 149);
                            bottomleft = new Point(9, 285);
                            bottomright = new Point(239, 285);

                            reflectedImg = QuadDistort.Distort((Bitmap)Functions.resizeImage((Bitmap)reflectedImg, newsize), topleft, topright, bottomleft, bottomright);

                            Bitmap dummyImage = new Bitmap(239, 242);
                            Graphics ga = Graphics.FromImage(dummyImage);
                            ga.DrawImage(img, new System.Drawing.Rectangle(0, 0, img.Width, img.Height));
                            ga.DrawImage(reflectedImg, new System.Drawing.Rectangle(5, 89, img.Width, img.Height));
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

                            Size newsize = new Size(232, 183);

                            Point topleft = new Point(18, 3);
                            Point topright = new Point(224, 40);
                            Point bottomleft = new Point(6, 156);
                            Point bottomright = new Point(219, 171);

                            img = QuadDistort.Distort((Bitmap)Functions.resizeImage((Bitmap)img, newsize), topleft, topright, bottomleft, bottomright);

                            Bitmap dummyImage = new Bitmap(232, 183);
                            Graphics ga = Graphics.FromImage(dummyImage);
                            ga.DrawImage(img, new System.Drawing.Rectangle(0, 0, img.Width, img.Height));
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

                            Size newsize = new Size(205, 151);

                            Point topleft = new Point(11, 3);
                            Point topright = new Point(198, 18);
                            Point bottomleft = new Point(6, 134);
                            Point bottomright = new Point(196, 139);

                            img = QuadDistort.Distort((Bitmap)Functions.resizeImage((Bitmap)img, newsize), topleft, topright, bottomleft, bottomright);

                            Bitmap dummyImage = new Bitmap(205, 151);
                            Graphics ga = Graphics.FromImage(dummyImage);
                            ga.DrawImage(img, new System.Drawing.Rectangle(0, 0, img.Width, img.Height));
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
        private void buttonLoad107_Click(object sender, EventArgs e)
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

                            Size newsize = new Size(194, 137);

                            Point topleft = new Point(8, 3);
                            Point topright = new Point(185, 3);
                            Point bottomleft = new Point(7, 124);
                            Point bottomright = new Point(187, 124);

                            img = QuadDistort.Distort((Bitmap)Functions.resizeImage((Bitmap)img, newsize), topleft, topright, bottomleft, bottomright);

                            Bitmap dummyImage = new Bitmap(194, 137);
                            Graphics ga = Graphics.FromImage(dummyImage);
                            ga.DrawImage(img, new System.Drawing.Rectangle(0, 0, img.Width, img.Height));
                            pictureBox107.Image = dummyImage;

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
        private void buttonLoad108_Click(object sender, EventArgs e)
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

                            Size newsize = new Size(205, 151);

                            Point topleft = new Point(8, 18);
                            Point topright = new Point(192, 3);
                            Point bottomleft = new Point(8, 139);
                            Point bottomright = new Point(198, 133);

                            img = QuadDistort.Distort((Bitmap)Functions.resizeImage((Bitmap)img, newsize), topleft, topright, bottomleft, bottomright);

                            Bitmap dummyImage = new Bitmap(205, 151);
                            Graphics ga = Graphics.FromImage(dummyImage);
                            ga.DrawImage(img, new System.Drawing.Rectangle(0, 0, img.Width, img.Height));
                            pictureBox108.Image = dummyImage;

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
        private void buttonLoad109_Click(object sender, EventArgs e)
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

                            Size newsize = new Size(232, 183);

                            Point topleft = new Point(6, 44);
                            Point topright = new Point(214, 4);
                            Point bottomleft = new Point(11, 180);
                            Point bottomright = new Point(224, 157);

                            img = QuadDistort.Distort((Bitmap)Functions.resizeImage((Bitmap)img, newsize), topleft, topright, bottomleft, bottomright);

                            Bitmap dummyImage = new Bitmap(232, 183);
                            Graphics ga = Graphics.FromImage(dummyImage);
                            ga.DrawImage(img, new System.Drawing.Rectangle(0, 0, img.Width, img.Height));
                            pictureBox109.Image = dummyImage;

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
        private void buttonLoad110_Click(object sender, EventArgs e)
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

                            Size newsize = new Size(226, 196);

                            Point topleft = new Point(18, 2);
                            Point topright = new Point(219, 62);
                            Point bottomleft = new Point(6, 144);
                            Point bottomright = new Point(213, 185);

                            img = QuadDistort.Distort((Bitmap)Functions.resizeImage((Bitmap)img, newsize), topleft, topright, bottomleft, bottomright);

                            Bitmap dummyImage = new Bitmap(226, 196);
                            Graphics ga = Graphics.FromImage(dummyImage);
                            ga.DrawImage(img, new System.Drawing.Rectangle(0, 0, img.Width, img.Height));
                            pictureBox110.Image = dummyImage;

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

        private void buttonLoad111_Click(object sender, EventArgs e)
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

                            Size newsize = new Size(201, 154);

                            Point topleft = new Point(11, 2);
                            Point topright = new Point(194, 25);
                            Point bottomleft = new Point(6, 125);
                            Point bottomright = new Point(192, 142);

                            img = QuadDistort.Distort((Bitmap)Functions.resizeImage((Bitmap)img, newsize), topleft, topright, bottomleft, bottomright);

                            Bitmap dummyImage = new Bitmap(201, 154);
                            Graphics ga = Graphics.FromImage(dummyImage);
                            ga.DrawImage(img, new System.Drawing.Rectangle(0, 0, img.Width, img.Height));
                            pictureBox111.Image = dummyImage;

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
        private void buttonLoad112_Click(object sender, EventArgs e)
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

                            Size newsize = new Size(190, 133);

                            Point topleft = new Point(8, 4);
                            Point topright = new Point(182, 4);
                            Point bottomleft = new Point(8, 120);
                            Point bottomright = new Point(182, 120);

                            img = QuadDistort.Distort((Bitmap)Functions.resizeImage((Bitmap)img, newsize), topleft, topright, bottomleft, bottomright);

                            Bitmap dummyImage = new Bitmap(190, 133);
                            Graphics ga = Graphics.FromImage(dummyImage);
                            ga.DrawImage(img, new System.Drawing.Rectangle(0, 0, img.Width, img.Height));
                            pictureBox112.Image = dummyImage;

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
        private void buttonLoad113_Click(object sender, EventArgs e)
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

                            Size newsize = new Size(201, 154);

                            Point topleft = new Point(7, 26);
                            Point topright = new Point(189, 2);
                            Point bottomleft = new Point(8, 142);
                            Point bottomright = new Point(194, 126);

                            img = QuadDistort.Distort((Bitmap)Functions.resizeImage((Bitmap)img, newsize), topleft, topright, bottomleft, bottomright);

                            Bitmap dummyImage = new Bitmap(201, 154);
                            Graphics ga = Graphics.FromImage(dummyImage);
                            ga.DrawImage(img, new System.Drawing.Rectangle(0, 0, img.Width, img.Height));
                            pictureBox113.Image = dummyImage;

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
        private void buttonLoad114_Click(object sender, EventArgs e)
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

                            Size newsize = new Size(225, 196);

                            Point topleft = new Point(6, 62);
                            Point topright = new Point(208, 1);
                            Point bottomleft = new Point(11, 186);
                            Point bottomright = new Point(218, 144);

                            img = QuadDistort.Distort((Bitmap)Functions.resizeImage((Bitmap)img, newsize), topleft, topright, bottomleft, bottomright);

                            Bitmap dummyImage = new Bitmap(225, 196);
                            Graphics ga = Graphics.FromImage(dummyImage);
                            ga.DrawImage(img, new System.Drawing.Rectangle(0, 0, img.Width, img.Height));
                            pictureBox114.Image = dummyImage;

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

        private void buttonSave107f_Click(object sender, EventArgs e)
        {
            if (!checkTargetPicture("107") && checkTargetPath())
            {

                String path = BlackGlassDirClass.Path + "\\Media\\basichome_107_focus.png";
                saveImage(path, pictureBox107.Image, "107", 1);
                deleteBlackGlassCacheDir();
            }
        }

        private void buttonSave107u_Click(object sender, EventArgs e)
        {
            if (!checkTargetPicture("107") && checkTargetPath())
            {

                String path = BlackGlassDirClass.Path + "\\Media\\basichome_107_nofocus.png";
                saveImage(path, pictureBox107.Image, "107", 0);
                deleteBlackGlassCacheDir();
            }
        }

        private void buttonSave108f_Click(object sender, EventArgs e)
        {
            if (!checkTargetPicture("108") && checkTargetPath())
            {

                String path = BlackGlassDirClass.Path + "\\Media\\basichome_108_focus.png";
                saveImage(path, pictureBox108.Image, "108", 1);
                deleteBlackGlassCacheDir();
            }
        }

        private void buttonSave108u_Click(object sender, EventArgs e)
        {
            if (!checkTargetPicture("108") && checkTargetPath())
            {

                String path = BlackGlassDirClass.Path + "\\Media\\basichome_108_nofocus.png";
                saveImage(path, pictureBox108.Image, "108", 0);
                deleteBlackGlassCacheDir();
            }
        }

        private void buttonSave109f_Click(object sender, EventArgs e)
        {
            if (!checkTargetPicture("109") && checkTargetPath())
            {

                String path = BlackGlassDirClass.Path + "\\Media\\basichome_109_focus.png";
                saveImage(path, pictureBox109.Image, "109", 1);
                deleteBlackGlassCacheDir();
            }
        }

        private void buttonSave109u_Click(object sender, EventArgs e)
        {
            if (!checkTargetPicture("109") && checkTargetPath())
            {

                String path = BlackGlassDirClass.Path + "\\Media\\basichome_109_nofocus.png";
                saveImage(path, pictureBox109.Image, "109", 0);
                deleteBlackGlassCacheDir();
            }
        }

        private void buttonSave110f_Click(object sender, EventArgs e)
        {
            if (!checkTargetPicture("110") && checkTargetPath())
            {

                String path = BlackGlassDirClass.Path + "\\Media\\basichome_110_focus.png";
                saveImage(path, pictureBox110.Image, "110", 1);
                deleteBlackGlassCacheDir();
            }
        }

        private void buttonSave110u_Click(object sender, EventArgs e)
        {
            if (!checkTargetPicture("110") && checkTargetPath())
            {

                String path = BlackGlassDirClass.Path + "\\Media\\basichome_110_nofocus.png";
                saveImage(path, pictureBox110.Image, "110", 0);
                deleteBlackGlassCacheDir();
            }
        }

        private void buttonSave111f_Click(object sender, EventArgs e)
        {
            if (!checkTargetPicture("111") && checkTargetPath())
            {

                String path = BlackGlassDirClass.Path + "\\Media\\basichome_111_focus.png";
                saveImage(path, pictureBox111.Image, "111", 1);
                deleteBlackGlassCacheDir();
            }
        }

        private void buttonSave111u_Click(object sender, EventArgs e)
        {
            if (!checkTargetPicture("111") && checkTargetPath())
            {

                String path = BlackGlassDirClass.Path + "\\Media\\basichome_111_nofocus.png";
                saveImage(path, pictureBox111.Image, "111", 0);
                deleteBlackGlassCacheDir();
            }
        }

        private void buttonSave112f_Click(object sender, EventArgs e)
        {
            if (!checkTargetPicture("112") && checkTargetPath())
            {

                String path = BlackGlassDirClass.Path + "\\Media\\basichome_112_focus.png";
                saveImage(path, pictureBox112.Image, "112", 1);
                deleteBlackGlassCacheDir();
            }
        }

        private void buttonSave112u_Click(object sender, EventArgs e)
        {
            if (!checkTargetPicture("112") && checkTargetPath())
            {

                String path = BlackGlassDirClass.Path + "\\Media\\basichome_112_nofocus.png";
                saveImage(path, pictureBox112.Image, "112", 0);
                deleteBlackGlassCacheDir();
            }
        }
        private void buttonSave113f_Click(object sender, EventArgs e)
        {
            if (!checkTargetPicture("113") && checkTargetPath())
            {

                String path = BlackGlassDirClass.Path + "\\Media\\basichome_113_focus.png";
                saveImage(path, pictureBox113.Image, "113", 1);
                deleteBlackGlassCacheDir();
            }
        }

        private void buttonSave113u_Click(object sender, EventArgs e)
        {
            if (!checkTargetPicture("113") && checkTargetPath())
            {

                String path = BlackGlassDirClass.Path + "\\Media\\basichome_113_nofocus.png";
                saveImage(path, pictureBox113.Image, "113", 0);
                deleteBlackGlassCacheDir();
            }
        }
        private void buttonSave114f_Click(object sender, EventArgs e)
        {
            if (!checkTargetPicture("114") && checkTargetPath())
            {

                String path = BlackGlassDirClass.Path + "\\Media\\basichome_114_focus.png";
                saveImage(path, pictureBox114.Image, "114", 1);
                deleteBlackGlassCacheDir();
            }
        }

        private void buttonSave114u_Click(object sender, EventArgs e)
        {
            if (!checkTargetPicture("114") && checkTargetPath())
            {

                String path = BlackGlassDirClass.Path + "\\Media\\basichome_114_nofocus.png";
                saveImage(path, pictureBox114.Image, "114", 0);
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
                    myWidth = 239;
                    myHeight = 245;
                    break;
                case "101":
                    myWidth = 209;
                    myHeight = 214;
                    break;
                case "102":
                    myWidth = 196;
                    myHeight = 205;
                    break;
                case "103":
                    myWidth = 209;
                    myHeight = 215;
                    break;
                case "104":
                    myWidth = 239;
                    myHeight = 242;
                    break;
                case "105":
                    myWidth = 232;
                    myHeight = 183;
                    break;
                case "106":
                    myWidth = 205;
                    myHeight = 151;
                    break;
                case "107":
                    myWidth = 194;
                    myHeight = 137;
                    break;
                case "108":
                    myWidth = 205;
                    myHeight = 151;
                    break;
                case "109":
                    myWidth = 232;
                    myHeight = 183;
                    break;
                case "110":
                    myWidth = 226;
                    myHeight = 196;
                    break;
                case "111":
                    myWidth = 201;
                    myHeight = 154;
                    break;
                case "112":
                    myWidth = 190;
                    myHeight = 133;
                    break;
                case "113":
                    myWidth = 201;
                    myHeight = 154;
                    break;
                case "114":
                    myWidth = 225;
                    myHeight = 196;
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
                shadow = (Bitmap)Functions.SetImgOpacity(shadow, 0.50f);
                img = Functions.SetImgOpacity(img, 0.50f);
            }

            gfxClip.DrawImage(img, new System.Drawing.Rectangle(0, 0, img.Width, img.Height));


            gfx.DrawImage(shadow, new System.Drawing.Rectangle(0, 0, shadow.Width, shadow.Height));

            if (focus == 1)
            {
                myStream = myAssembly.GetManifestResourceStream("BlackGlassEditor.Images.basichome_" + buttonRif + "_contour.png");
                Bitmap contour = new Bitmap(myStream);
                gfx.DrawImage(contour, new System.Drawing.Rectangle(0, 0, contour.Width, contour.Height));
            }

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
                    myWidth = 239;
                    myHeight = 245;
                    break;
                case "101":
                    myWidth = 209;
                    myHeight = 214;
                    break;
                case "102":
                    myWidth = 196;
                    myHeight = 205;
                    break;
                case "103":
                    myWidth = 209;
                    myHeight = 215;
                    break;
                case "104":
                    myWidth = 239;
                    myHeight = 242;
                    break;
                case "105":
                    myWidth = 232;
                    myHeight = 183;
                    break;
                case "106":
                    myWidth = 205;
                    myHeight = 151;
                    break;
                case "107":
                    myWidth = 194;
                    myHeight = 137;
                    break;
                case "108":
                    myWidth = 205;
                    myHeight = 151;
                    break;
                case "109":
                    myWidth = 232;
                    myHeight = 183;
                    break;
                case "110":
                    myWidth = 226;
                    myHeight = 196;
                    break;
                case "111":
                    myWidth = 201;
                    myHeight = 154;
                    break;
                case "112":
                    myWidth = 190;
                    myHeight = 133;
                    break;
                case "113":
                    myWidth = 201;
                    myHeight = 154;
                    break;
                case "114":
                    myWidth = 225;
                    myHeight = 196;
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
                shadow = (Bitmap)Functions.SetImgOpacity(shadow, 0.50f);
                img = Functions.SetImgOpacity(img, 0.50f);
            }

            gfxClip.DrawImage(img, new System.Drawing.Rectangle(0, 0, img.Width, img.Height));


            gfx.DrawImage(shadow, new System.Drawing.Rectangle(0, 0, shadow.Width, shadow.Height));

            if (focus == 1)
            {
                myStream = myAssembly.GetManifestResourceStream("BlackGlassEditor.Images.basichome_" + buttonRif + "_contour.png");
                Bitmap contour = new Bitmap(myStream);
                gfx.DrawImage(contour, new System.Drawing.Rectangle(0, 0, contour.Width, contour.Height));
            }

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
        }

        private void comboBox101_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox101.Text = comboBox101.Text;
            textBoxid101.Text = findPlugin(comboBox101.Text).ToString();
        }
        private void comboBox102_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox102.Text = comboBox102.Text;
            textBoxid102.Text = findPlugin(comboBox102.Text).ToString();
        }
        private void comboBox103_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox103.Text = comboBox103.Text;
            textBoxid103.Text = findPlugin(comboBox103.Text).ToString();
        }
        private void comboBox104_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox104.Text = comboBox104.Text;
            textBoxid104.Text = findPlugin(comboBox104.Text).ToString();
        }
        private void comboBox105_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox105.Text = comboBox105.Text;
            textBoxid105.Text = findPlugin(comboBox105.Text).ToString();
        }
        private void comboBox106_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox106.Text = comboBox106.Text;
            textBoxid106.Text = findPlugin(comboBox106.Text).ToString();
        }
        private void comboBox107_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox107.Text = comboBox107.Text;
            textBoxid107.Text = findPlugin(comboBox107.Text).ToString();
        }
        private void comboBox108_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox108.Text = comboBox108.Text;
            textBoxid108.Text = findPlugin(comboBox108.Text).ToString();
        }
        private void comboBox109_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox109.Text = comboBox109.Text;
            textBoxid109.Text = findPlugin(comboBox109.Text).ToString();
        }
        private void comboBox110_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox110.Text = comboBox110.Text;
            textBoxid110.Text = findPlugin(comboBox110.Text).ToString();
        }
        private void comboBox111_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox111.Text = comboBox111.Text;
            textBoxid111.Text = findPlugin(comboBox111.Text).ToString();
        }
        private void comboBox112_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox112.Text = comboBox112.Text;
            textBoxid112.Text = findPlugin(comboBox112.Text).ToString();
        }
        private void comboBox113_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox113.Text = comboBox113.Text;
            textBoxid113.Text = findPlugin(comboBox113.Text).ToString();
        }
        private void comboBox114_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox114.Text = comboBox114.Text;
            textBoxid114.Text = findPlugin(comboBox114.Text).ToString();
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
            if (pictureBox107.Image == null) errors++;
            if (pictureBox108.Image == null) errors++;
            if (pictureBox109.Image == null) errors++;
            if (pictureBox110.Image == null) errors++;
            if (pictureBox111.Image == null) errors++;
            if (pictureBox112.Image == null) errors++;
            if (pictureBox113.Image == null) errors++;
            if (pictureBox114.Image == null) errors++;

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
            if (textBox107.Text == "") errors++;
            if (textBox108.Text == "") errors++;
            if (textBox109.Text == "") errors++;
            if (textBox110.Text == "") errors++;
            if (textBox111.Text == "") errors++;
            if (textBox112.Text == "") errors++;
            if (textBox113.Text == "") errors++;
            if (textBox114.Text == "") errors++;

            if (textBoxid100.Text == "") errors++;
            if (textBoxid101.Text == "") errors++;
            if (textBoxid102.Text == "") errors++;
            if (textBoxid103.Text == "") errors++;
            if (textBoxid104.Text == "") errors++;
            if (textBoxid105.Text == "") errors++;
            if (textBoxid106.Text == "") errors++;
            if (textBoxid107.Text == "") errors++;
            if (textBoxid108.Text == "") errors++;
            if (textBoxid109.Text == "") errors++;
            if (textBoxid110.Text == "") errors++;
            if (textBoxid111.Text == "") errors++;
            if (textBoxid112.Text == "") errors++;
            if (textBoxid113.Text == "") errors++;
            if (textBoxid114.Text == "") errors++;

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




                // SELEZIONA COLORE THEME

                String themecolor = "blue";
                if (radioButtonBlue.Checked == true) themecolor = "blue";
                if (radioButtonRed.Checked == true) themecolor = "red";
                if (radioButtonYellow.Checked == true) themecolor = "yellow";
                if (radioButtonGreen.Checked == true) themecolor = "green";
                if (radioButtonBlack.Checked == true) themecolor = "black";

                // CARICAMENTO basichome_bg.jpg
                Assembly myAssembly = Assembly.GetExecutingAssembly();

                Stream myStream = myAssembly.GetManifestResourceStream("BlackGlassEditor.Images." + themecolor + "_bg_up.png");
                Bitmap basichome_bg = new Bitmap(myStream);


                // CARICAMENTO bg.jpg
                myStream = myAssembly.GetManifestResourceStream("BlackGlassEditor.Images." + themecolor + "_bg_down.png");
                Bitmap bg = new Bitmap(myStream);


                // CARICAMENTO sidebuttons
                myStream = myAssembly.GetManifestResourceStream("BlackGlassEditor.Images.side_buttons.png");
                Bitmap sidebuttons = new Bitmap(myStream);


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

                Bitmap buttonImage107 = new Bitmap(buildImage(pictureBox107.Image, "107", 0));
                saveImage(BlackGlassDirClass.Path + "\\Media\\basichome_107_nofocus.png", pictureBox107.Image, "107", 0);
                saveImage(BlackGlassDirClass.Path + "\\Media\\basichome_107_focus.png", pictureBox107.Image, "107", 1);

                Bitmap buttonImage108 = new Bitmap(buildImage(pictureBox108.Image, "108", 0));
                saveImage(BlackGlassDirClass.Path + "\\Media\\basichome_108_nofocus.png", pictureBox108.Image, "108", 0);
                saveImage(BlackGlassDirClass.Path + "\\Media\\basichome_108_focus.png", pictureBox108.Image, "108", 1);

                Bitmap buttonImage109 = new Bitmap(buildImage(pictureBox109.Image, "109", 0));
                saveImage(BlackGlassDirClass.Path + "\\Media\\basichome_109_nofocus.png", pictureBox109.Image, "109", 0);
                saveImage(BlackGlassDirClass.Path + "\\Media\\basichome_109_focus.png", pictureBox109.Image, "109", 1);

                Bitmap buttonImage110 = new Bitmap(buildImage(pictureBox110.Image, "110", 0));
                saveImage(BlackGlassDirClass.Path + "\\Media\\basichome_110_nofocus.png", pictureBox110.Image, "110", 0);
                saveImage(BlackGlassDirClass.Path + "\\Media\\basichome_110_focus.png", pictureBox110.Image, "110", 1);

                Bitmap buttonImage111 = new Bitmap(buildImage(pictureBox111.Image, "111", 0));
                saveImage(BlackGlassDirClass.Path + "\\Media\\basichome_111_nofocus.png", pictureBox111.Image, "111", 0);
                saveImage(BlackGlassDirClass.Path + "\\Media\\basichome_111_focus.png", pictureBox111.Image, "111", 1);

                Bitmap buttonImage112 = new Bitmap(buildImage(pictureBox112.Image, "112", 0));
                saveImage(BlackGlassDirClass.Path + "\\Media\\basichome_112_nofocus.png", pictureBox112.Image, "112", 0);
                saveImage(BlackGlassDirClass.Path + "\\Media\\basichome_112_focus.png", pictureBox112.Image, "112", 1);

                Bitmap buttonImage113 = new Bitmap(buildImage(pictureBox113.Image, "113", 0));
                saveImage(BlackGlassDirClass.Path + "\\Media\\basichome_113_nofocus.png", pictureBox113.Image, "113", 0);
                saveImage(BlackGlassDirClass.Path + "\\Media\\basichome_113_focus.png", pictureBox113.Image, "113", 1);

                Bitmap buttonImage114 = new Bitmap(buildImage(pictureBox114.Image, "114", 0));
                saveImage(BlackGlassDirClass.Path + "\\Media\\basichome_114_nofocus.png", pictureBox114.Image, "114", 0);
                saveImage(BlackGlassDirClass.Path + "\\Media\\basichome_114_focus.png", pictureBox114.Image, "114", 1);


                // Setta il colore trasparente
                Color col = splash.GetPixel(1, 1);


                //CREA bg.jpg

                gfx.DrawImage(bg, new System.Drawing.Rectangle(0, 0, 1280, 720));

                try
                {
                    ImageCodecInfo jgpEncoder = Functions.GetEncoder(ImageFormat.Jpeg);

                    System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;
                    EncoderParameters myEncoderParameters = new EncoderParameters(1);

                    EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 100L);
                    myEncoderParameters.Param[0] = myEncoderParameter;

                    finalImage.Save(BlackGlassDirClass.Path + "\\Media\\bg.jpg", jgpEncoder, myEncoderParameters);
                    toolStripStatusLabel1.Text = "Theme Files Saved Succesfully";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not save bg.jpg to disk. Original error: " + ex.Message);
                }


                //CREA basichome_bg.jpg

                gfx.DrawImage(basichome_bg, new System.Drawing.Rectangle(0, 0, 1280, 720));

                try
                {
                    ImageCodecInfo jgpEncoder = Functions.GetEncoder(ImageFormat.Jpeg);

                    System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;
                    EncoderParameters myEncoderParameters = new EncoderParameters(1);

                    EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 100L);
                    myEncoderParameters.Param[0] = myEncoderParameter;

                    finalImage.Save(BlackGlassDirClass.Path + "\\Media\\basichome_bg.jpg", jgpEncoder, myEncoderParameters);
                    toolStripStatusLabel1.Text = "Theme Files Saved Succesfully";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not save basichome_bg.jpg to disk. Original error: " + ex.Message);
                }


                // CREA bg_homefull.jpg 
                gfx.DrawImage(sidebuttons, new System.Drawing.Rectangle(0, 0, 1280, 720));

                gfx.DrawImage(buttonImage100, new System.Drawing.Rectangle(100, 398, buttonImage100.Width, buttonImage100.Height));
                gfx.DrawImage(buttonImage101, new System.Drawing.Rectangle(336, 410, buttonImage101.Width, buttonImage101.Height));
                gfx.DrawImage(buttonImage102, new System.Drawing.Rectangle(542, 414, buttonImage102.Width, buttonImage102.Height));
                gfx.DrawImage(buttonImage103, new System.Drawing.Rectangle(736, 410, buttonImage103.Width, buttonImage103.Height));
                gfx.DrawImage(buttonImage104, new System.Drawing.Rectangle(941, 398, buttonImage104.Width, buttonImage104.Height));
                gfx.DrawImage(buttonImage105, new System.Drawing.Rectangle(114, 231, buttonImage105.Width, buttonImage105.Height));
                gfx.DrawImage(buttonImage106, new System.Drawing.Rectangle(342, 270, buttonImage106.Width, buttonImage106.Height));
                gfx.DrawImage(buttonImage107, new System.Drawing.Rectangle(543, 286, buttonImage107.Width, buttonImage107.Height));
                gfx.DrawImage(buttonImage108, new System.Drawing.Rectangle(733, 270, buttonImage108.Width, buttonImage108.Height));
                gfx.DrawImage(buttonImage109, new System.Drawing.Rectangle(935, 231, buttonImage109.Width, buttonImage109.Height));
                gfx.DrawImage(buttonImage110, new System.Drawing.Rectangle(126, 76, buttonImage110.Width, buttonImage110.Height));
                gfx.DrawImage(buttonImage111, new System.Drawing.Rectangle(348, 138, buttonImage111.Width, buttonImage111.Height));
                gfx.DrawImage(buttonImage112, new System.Drawing.Rectangle(545, 162, buttonImage112.Width, buttonImage112.Height));
                gfx.DrawImage(buttonImage113, new System.Drawing.Rectangle(731, 138, buttonImage113.Width, buttonImage113.Height));
                gfx.DrawImage(buttonImage114, new System.Drawing.Rectangle(929, 76, buttonImage114.Width, buttonImage114.Height));

                try
                {
                    ImageCodecInfo jgpEncoder = Functions.GetEncoder(ImageFormat.Jpeg);

                    System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;
                    EncoderParameters myEncoderParameters = new EncoderParameters(1);

                    EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 100L);
                    myEncoderParameters.Param[0] = myEncoderParameter;

                    finalImage.Save(BlackGlassDirClass.Path + "\\Media\\bg_homefull.jpg", jgpEncoder, myEncoderParameters);
                    toolStripStatusLabel1.Text = "Theme Files Saved Succesfully";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not save bg_homefull.jpg to disk. Original error: " + ex.Message);
                }


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
            if (Directory.Exists(ProgramFilesx86() + @"\Team MediaPortal\MediaPortal\skin\Black Glass")) path = ProgramFilesx86() + @"\Team MediaPortal\MediaPortal\skin\Black Glass";

            // MP 1.1 
            if (Directory.Exists(Environment.GetEnvironmentVariable("ALLUSERSPROFILE") + @"\Team MediaPortal\MediaPortal\skin\Black Glass")) path = Environment.GetEnvironmentVariable("ALLUSERSPROFILE") + @"\Team MediaPortal\MediaPortal\skin\Black Glass";

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

            if (Directory.Exists(Environment.GetEnvironmentVariable("ALLUSERSPROFILE") + @"\Team MediaPortal\MediaPortal\Cache\Black Glass")) path = Environment.GetEnvironmentVariable("ALLUSERSPROFILE") + @"\Team MediaPortal\MediaPortal\Cache\Black Glass";

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
                if (textBoxid107.Text == "2600") weather_button = "107";
                if (textBoxid108.Text == "2600") weather_button = "108";
                if (textBoxid109.Text == "2600") weather_button = "109";
                if (textBoxid110.Text == "2600") weather_button = "110";
                if (textBoxid111.Text == "2600") weather_button = "111";
                if (textBoxid112.Text == "2600") weather_button = "112";
                if (textBoxid113.Text == "2600") weather_button = "113";
                if (textBoxid114.Text == "2600") weather_button = "114";


                String tvseries_button = "";

                if (textBoxid100.Text == "9811") tvseries_button = "100";
                if (textBoxid101.Text == "9811") tvseries_button = "101";
                if (textBoxid102.Text == "9811") tvseries_button = "102";
                if (textBoxid103.Text == "9811") tvseries_button = "103";
                if (textBoxid104.Text == "9811") tvseries_button = "104";
                if (textBoxid105.Text == "9811") tvseries_button = "105";
                if (textBoxid106.Text == "9811") tvseries_button = "106";
                if (textBoxid107.Text == "9811") tvseries_button = "107";
                if (textBoxid108.Text == "9811") tvseries_button = "108";
                if (textBoxid109.Text == "9811") tvseries_button = "109";
                if (textBoxid110.Text == "9811") tvseries_button = "110";
                if (textBoxid111.Text == "9811") tvseries_button = "111";
                if (textBoxid112.Text == "9811") tvseries_button = "112";
                if (textBoxid113.Text == "9811") tvseries_button = "113";
                if (textBoxid114.Text == "9811") tvseries_button = "114";


                String movingpictures_button = "";

                if (textBoxid100.Text == "96742") movingpictures_button = "100";
                if (textBoxid101.Text == "96742") movingpictures_button = "101";
                if (textBoxid102.Text == "96742") movingpictures_button = "102";
                if (textBoxid103.Text == "96742") movingpictures_button = "103";
                if (textBoxid104.Text == "96742") movingpictures_button = "104";
                if (textBoxid105.Text == "96742") movingpictures_button = "105";
                if (textBoxid106.Text == "96742") movingpictures_button = "106";
                if (textBoxid107.Text == "96742") movingpictures_button = "107";
                if (textBoxid108.Text == "96742") movingpictures_button = "108";
                if (textBoxid109.Text == "96742") movingpictures_button = "109";
                if (textBoxid110.Text == "96742") movingpictures_button = "110";
                if (textBoxid111.Text == "96742") movingpictures_button = "111";
                if (textBoxid112.Text == "96742") movingpictures_button = "112";
                if (textBoxid113.Text == "96742") movingpictures_button = "113";
                if (textBoxid114.Text == "96742") movingpictures_button = "114";

                string txt = @"<?xml version=""1.0"" encoding=""utf-8"" standalone=""yes""?>
<window>
  <controls>
        
<!-- ID 100 -->
		<control>
			<description>100 image</description>
			<type>image</type>
			<id>0</id>
			<posX>100</posX>
			<posY>398</posY>
			<width>239</width>
			<height>245</height>
			<texture>basichome_100_nofocus.png</texture>
		</control>
		<control>
			<description>100 hover image</description>
			<type>image</type>
			<id>0</id>
			<posX>100</posX>
			<posY>398</posY>
			<width>239</width>
			<height>245</height>
			<texture>basichome_100_focus.png</texture>
			<visible>control.hasfocus(100)</visible>
			<animation effect=""fade"" time=""500"">VisibleChange</animation>
			<animation effect=""zoom"" start=""100,100"" end=""102,102"" time=""500"">VisibleChange</animation>
		</control>
		<control>
			<description>100 hover label</description>
			<type>label</type>
			<posX>0</posX>
			<posY>618</posY>
			<width>1280</width>
			<label>" + SecurityElement.Escape(textBox100.Text) + @"</label>
			<font>font48</font>
			<align>center</align>
			<visible>control.hasfocus(100)</visible>
			<textcolor>ffffffff</textcolor>
			<animation effect=""fade"" time=""500"">VisibleChange</animation>
		</control>
		<control>
			<description>100 button</description>
			<type>button</type>
			<id>100</id>
			<posX>100</posX>
			<posY>398</posY>
			<width>241</width>
			<height>245</height>
			<label>" + SecurityElement.Escape(textBox100.Text) + @"</label>
            <textXOff>3000</textXOff>
			<hyperlink>" + SecurityElement.Escape(textBoxid100.Text) + @"</hyperlink>
			<onleft>104</onleft>
			<onright>101</onright>
			<onup>105</onup>
			<ondown>17</ondown>
			<textureFocus>-</textureFocus>
			<textureNoFocus>-</textureNoFocus>
		</control>


		<!-- ID 101 -->
		<control>
			<description>101 image</description>
			<type>image</type>
			<id>0</id>
			<posX>336</posX>
			<posY>410</posY>
			<width>209</width>
			<height>214</height>
			<texture>basichome_101_nofocus.png</texture>
		</control>
		<control>
			<description>101 hover image</description>
			<type>image</type>
			<id>0</id>
			<posX>336</posX>
			<posY>410</posY>
			<width>209</width>
			<height>214</height>
			<texture>basichome_101_focus.png</texture>
			<visible>control.hasfocus(101)</visible>
			<animation effect=""fade"" time=""500"">VisibleChange</animation>
			<animation effect=""zoom"" start=""100,100"" end=""102,102"" time=""500"">VisibleChange</animation>
		</control>
		<control>
			<description>101 hover label</description>
			<type>label</type>
			<id>0</id>
			<posX>0</posX>
			<posY>618</posY>
			<width>1280</width>
			<label>" + SecurityElement.Escape(textBox101.Text) + @"</label>
			<font>font48</font>
			<align>center</align>
			<visible>control.hasfocus(101)</visible>
			<textcolor>ffffffff</textcolor>
			<animation effect=""fade"" time=""500"">VisibleChange</animation>
		</control>
		<control>
			<description>101 button</description>
			<type>button</type>
			<id>101</id>
			<posX>335</posX>
			<posY>410</posY>
			<width>211</width>
			<height>215</height>
			<label>" + SecurityElement.Escape(textBox101.Text) + @"</label>
            <textXOff>3000</textXOff>
			<hyperlink>" + SecurityElement.Escape(textBoxid101.Text) + @"</hyperlink>
			<onleft>100</onleft>
			<onright>102</onright>
			<onup>106</onup>
			<ondown>17</ondown>
			<textureFocus>-</textureFocus>
			<textureNoFocus>-</textureNoFocus>
		</control>


		<!-- ID 102 -->
		<control>
			<description>102 image</description>
			<type>image</type>
			<id>0</id>
			<posX>542</posX>
			<posY>414</posY>
			<width>196</width>
			<height>205</height>
			<texture>basichome_102_nofocus.png</texture>
		</control>
		<control>
			<description>102 hover image</description>
			<type>image</type>
			<id>0</id>
			<posX>542</posX>
			<posY>414</posY>
			<width>196</width>
			<height>205</height>
			<visible>control.hasfocus(102)</visible>
			<texture>basichome_102_focus.png</texture>
			<animation effect=""fade"" time=""500"">VisibleChange</animation>
			<animation effect=""zoom"" start=""100,100"" end=""102,102"" time=""500"">VisibleChange</animation>
		</control>
		<control>
			<description>102 hover label</description>
			<type>label</type>
			<id>0</id>
			<posX>0</posX>
			<posY>618</posY>
			<width>1280</width>
			<label>" + SecurityElement.Escape(textBox102.Text) + @"</label>
			<font>font48</font>
			<align>center</align>
			<visible>control.hasfocus(102)</visible>
			<textcolor>ffffffff</textcolor>
			<animation effect=""fade"" time=""500"">VisibleChange</animation>
		</control>
		<control>
			<description>102 button</description>
			<type>button</type>
			<id>102</id>
			<posX>541</posX>
			<posY>414</posY>
			<width>198</width>
			<height>205</height>
			<label>" + SecurityElement.Escape(textBox102.Text) + @"</label>
            <textXOff>3000</textXOff>
			<hyperlink>" + SecurityElement.Escape(textBoxid102.Text) + @"</hyperlink>
			<onleft>101</onleft>
			<onright>103</onright>
			<onup>107</onup>
			<ondown>18</ondown>
			<textureFocus>-</textureFocus>
			<textureNoFocus>-</textureNoFocus>
		</control>


		<!-- ID 103 -->
		<control>
			<description>103 image</description>
			<type>image</type>
			<id>0</id>
			<posX>736</posX>
			<posY>410</posY>
			<width>209</width>
			<height>215</height>
			<texture>basichome_103_nofocus.png</texture>
		</control>
		<control>
			<description>103 hover image</description>
			<type>image</type>
			<id>0</id>
			<posX>736</posX>
			<posY>410</posY>
			<width>209</width>
			<height>215</height>
			<texture>basichome_103_focus.png</texture>
			<visible>control.hasfocus(103)</visible>
			<animation effect=""fade"" time=""500"">VisibleChange</animation>
			<animation effect=""zoom"" start=""100,100"" end=""102,102"" time=""500"">VisibleChange</animation>
		</control>
		<control>
			<description>103 hover label</description>
			<type>label</type>
			<id>0</id>
			<posX>0</posX>
			<posY>618</posY>
			<width>1280</width>
			<label>" + SecurityElement.Escape(textBox103.Text) + @"</label>
			<font>font48</font> 
			<align>center</align>
			<visible>control.hasfocus(103)</visible>
			<textcolor>ffffffff</textcolor>
			<animation effect=""fade"" time=""500"">VisibleChange</animation>
		</control>
		<control>
			<description>103 button</description>
			<type>button</type>
			<id>103</id>
			<posX>735</posX>
			<posY>410</posY>
			<width>210</width>
			<height>215</height>
			<label>" + SecurityElement.Escape(textBox103.Text) + @"</label>
            <textXOff>3000</textXOff>
			<hyperlink>" + SecurityElement.Escape(textBoxid103.Text) + @"</hyperlink>
			<onleft>102</onleft>
			<onright>104</onright>
			<onup>108</onup>
			<ondown>19</ondown>
			<textureFocus>-</textureFocus>
			<textureNoFocus>-</textureNoFocus>
		</control>



		<!-- ID 104 -->
		<control>
			<description>104 image</description>
			<type>image</type>
			<id>0</id>
			<posX>941</posX>
			<posY>398</posY>
			<width>239</width>
			<height>242</height>
			<texture>basichome_104_nofocus.png</texture>
		</control>
		<control>
			<description>104 hover image</description>
			<type>image</type>
			<id>0</id>
			<posX>941</posX>
			<posY>398</posY>
			<width>239</width>
			<height>242</height>
			<texture>basichome_104_focus.png</texture>
			<visible>control.hasfocus(104)</visible>
			<animation effect=""fade"" time=""500"">VisibleChange</animation>
			<animation effect=""zoom"" start=""100,100"" end=""102,102"" time=""500"">VisibleChange</animation>
		</control>
		<control>
			<description>104 hover label</description>
			<type>label</type>
			<id>0</id>
			<posX>0</posX>
			<posY>618</posY>
			<width>1280</width>
			<label>" + SecurityElement.Escape(textBox104.Text) + @"</label>
			<font>font48</font>
			<align>center</align>
			<visible>control.hasfocus(104)</visible>
			<textcolor>ffffffff</textcolor>
			<animation effect=""fade"" time=""500"">VisibleChange</animation>
		</control>
		<control>
			<description>104 button</description>
			<type>button</type>
			<id>104</id>
			<posX>940</posX>
			<posY>398</posY>
			<width>241</width>
			<height>242</height>
			<label>" + SecurityElement.Escape(textBox104.Text) + @"</label>
            <textXOff>3000</textXOff>
			<hyperlink>" + SecurityElement.Escape(textBoxid104.Text) + @"</hyperlink>
			<onleft>103</onleft>
			<onright>100</onright>
			<onup>109</onup>
			<ondown>19</ondown>
			<textureFocus>-</textureFocus>
			<textureNoFocus>-</textureNoFocus>
		</control>



		<!-- ID 105 -->
		<control>
			<description>105 image</description>
			<type>image</type>
			<id>0</id>
			<posX>114</posX>
			<posY>231</posY>
			<width>232</width>
			<height>183</height>
			<texture>basichome_105_nofocus.png</texture>
		</control>
		<control>
			<description>105 hover image</description>
			<type>image</type>
			<id>0</id>
			<posX>114</posX>
			<posY>231</posY>
			<width>232</width>
			<height>183</height>
			<texture>basichome_105_focus.png</texture>
			<visible>control.hasfocus(105)</visible>
			<animation effect=""fade"" time=""500"">VisibleChange</animation>
			<animation effect=""zoom"" start=""100,100"" end=""102,102"" time=""500"">VisibleChange</animation>
		</control>
		<control>
			<description>105 hover label</description>
			<type>label</type>
			<id>0</id>
			<posX>0</posX>
			<posY>618</posY>
			<width>1280</width>
			<label>" + SecurityElement.Escape(textBox105.Text) + @"</label>
			<font>font48</font>
			<align>center</align>
			<visible>control.hasfocus(105)</visible>
			<textcolor>ffffffff</textcolor>
			<animation effect=""fade"" time=""500"">VisibleChange</animation>
		</control>
		<control>
			<description>105 button</description>
			<type>button</type>
			<id>105</id>
			<posX>113</posX>
			<posY>231</posY>
			<width>234</width>
			<height>184</height>
			<label>" + SecurityElement.Escape(textBox105.Text) + @"</label>
            <textXOff>3000</textXOff>
			<hyperlink>" + SecurityElement.Escape(textBoxid105.Text) + @"</hyperlink>
			<onleft>109</onleft>
			<onright>106</onright>
			<onup>110</onup>
			<ondown>100</ondown>
			<textureFocus>-</textureFocus>
			<textureNoFocus>-</textureNoFocus>
		</control>



		<!-- ID 106 -->
		<control>
			<description>106 image</description>
			<type>image</type>
			<id>0</id>
			<posX>342</posX>
			<posY>270</posY>
			<width>205</width>
			<height>151</height>
			<texture>basichome_106_nofocus.png</texture>
		</control>
		<control>
			<description>106 hover image</description>
			<type>image</type>
			<id>0</id>
			<posX>342</posX>
			<posY>270</posY>
			<width>205</width>
			<height>151</height>
			<visible>control.hasfocus(106)</visible>
			<texture>basichome_106_focus.png</texture>
			<animation effect=""fade"" time=""500"">VisibleChange</animation>
			<animation effect=""zoom"" start=""100,100"" end=""102,102"" time=""500"">VisibleChange</animation>
		</control>
		<control>
			<description>106 hover label</description>
			<type>label</type>
			<id>0</id>
			<posX>0</posX>
			<posY>618</posY>
			<width>1280</width>
			<label>" + SecurityElement.Escape(textBox106.Text) + @"</label>
			<font>font48</font>
			<align>center</align>
			<visible>control.hasfocus(106)</visible>
			<textcolor>ffffffff</textcolor>
			<animation effect=""fade"" time=""500"">VisibleChange</animation>
		</control>
		<control>
			<description>106 button</description>
			<type>button</type>
			<id>106</id>
			<posX>341</posX>
			<posY>270</posY>
			<width>207</width>
			<height>152</height>
			<label>" + SecurityElement.Escape(textBox106.Text) + @"</label>
            <textXOff>3000</textXOff>
			<hyperlink>" + SecurityElement.Escape(textBoxid106.Text) + @"</hyperlink>
			<onleft>105</onleft>
			<onright>107</onright>
			<onup>111</onup>
			<ondown>101</ondown>
			<textureFocus>-</textureFocus>
			<textureNoFocus>-</textureNoFocus>
		</control>



		<!-- ID 107 -->
		<control>
			<description>107 image</description>
			<type>image</type>
			<id>0</id>
			<posX>543</posX>
			<posY>286</posY>
			<width>194</width>
			<height>137</height>
			<texture>basichome_107_nofocus.png</texture>
		</control>
		<control>
			<description>107 hover image</description>
			<type>image</type>
			<id>0</id>
			<posX>543</posX>
			<posY>286</posY>
			<width>194</width>
			<height>137</height>
			<texture>basichome_107_focus.png</texture>
			<visible>control.hasfocus(107)</visible>
			<animation effect=""fade"" time=""500"">VisibleChange</animation>
			<animation effect=""zoom"" start=""100,100"" end=""102,102"" time=""500"">VisibleChange</animation>
		</control>
		<control>
			<description>107 hover label</description>
			<type>label</type>
			<id>0</id>
			<posX>0</posX>
			<posY>618</posY>
			<width>1280</width>
			<label>" + SecurityElement.Escape(textBox107.Text) + @"</label>
			<font>font48</font>
			<align>center</align>
			<visible>control.hasfocus(107)</visible>
			<textcolor>ffffffff</textcolor>
			<animation effect=""fade"" time=""500"">VisibleChange</animation>
		</control>
		<control>
			<description>107 button</description>
			<type>button</type>
			<id>107</id>
			<posX>543</posX>
			<posY>286</posY>
			<width>195</width>
			<height>138</height>
			<label>" + SecurityElement.Escape(textBox107.Text) + @"</label>
            <textXOff>3000</textXOff>
			<hyperlink>" + SecurityElement.Escape(textBoxid107.Text) + @"</hyperlink>
			<onleft>106</onleft>
			<onright>108</onright>
			<onup>112</onup>
			<ondown>102</ondown>
			<textureFocus>-</textureFocus>
			<textureNoFocus>-</textureNoFocus>
		</control>



		<!-- ID 108 -->
		<control>
			<description>108 image</description>
			<type>image</type>
			<id>0</id>
			<posX>733</posX>
			<posY>270</posY>
			<width>205</width>
			<height>151</height>
			<texture>basichome_108_nofocus.png</texture>
		</control>
		<control>
			<description>108 hover image</description>
			<type>image</type>
			<id>0</id>
			<posX>733</posX>
			<posY>270</posY>
			<width>205</width>
			<height>151</height>
			<visible>control.hasfocus(108)</visible>
			<texture>basichome_108_focus.png</texture>
			<animation effect=""fade"" time=""500"">VisibleChange</animation>
			<animation effect=""zoom"" start=""100,100"" end=""102,102"" time=""500"">VisibleChange</animation>
		</control>
		<control>
			<description>108 hover label</description>
			<type>label</type>
			<id>0</id>
			<posX>0</posX>
			<posY>618</posY>
			<width>1280</width>
			<label>" + SecurityElement.Escape(textBox108.Text) + @"</label>
			<font>font48</font>
			<align>center</align>
			<visible>control.hasfocus(108)</visible>
			<textcolor>ffffffff</textcolor>
			<animation effect=""fade"" time=""500"">VisibleChange</animation>
		</control>
		<control>
			<description>108 button</description>
			<type>button</type>
			<id>108</id>
			<posX>733</posX>
			<posY>270</posY>
			<width>206</width>
			<height>152</height>
			<label>" + SecurityElement.Escape(textBox108.Text) + @"</label>
            <textXOff>3000</textXOff>
			<hyperlink>" + SecurityElement.Escape(textBoxid108.Text) + @"</hyperlink>
			<onleft>107</onleft>
			<onright>109</onright>
			<onup>113</onup>
			<ondown>103</ondown>
			<textureFocus>-</textureFocus>
			<textureNoFocus>-</textureNoFocus>
		</control>



		<!-- ID 109 -->
		<control>
			<description>109 image</description>
			<type>image</type>
			<id>0</id>
			<posX>935</posX>
			<posY>231</posY>
			<width>232</width>
			<height>183</height>
			<texture>basichome_109_nofocus.png</texture>
		</control>
		<control>
			<description>109 hover image</description>
			<type>image</type>
			<id>0</id>
			<posX>935</posX>
			<posY>231</posY>
			<width>232</width>
			<height>183</height>
			<texture>basichome_109_focus.png</texture>
			<visible>control.hasfocus(109)</visible>
			<animation effect=""fade"" time=""500"">VisibleChange</animation>
			<animation effect=""zoom"" start=""100,100"" end=""102,102"" time=""500"">VisibleChange</animation>
		</control>
		<control>
			<description>109 hover label</description>
			<type>label</type>
			<id>0</id>
			<posX>0</posX>
			<posY>618</posY>
			<width>1280</width>
			<label>" + SecurityElement.Escape(textBox109.Text) + @"</label>
			<font>font48</font>
			<align>center</align>
			<visible>control.hasfocus(109)</visible>
			<textcolor>ffffffff</textcolor>
			<animation effect=""fade"" time=""500"">VisibleChange</animation>
		</control>
		<control>
			<description>109 button</description>
			<type>button</type>
			<id>109</id>
			<posX>934</posX>
			<posY>231</posY>
			<width>234</width>
			<height>184</height>
			<label>" + SecurityElement.Escape(textBox109.Text) + @"</label>
            <textXOff>3000</textXOff>
			<hyperlink>" + SecurityElement.Escape(textBoxid109.Text) + @"</hyperlink>
			<onleft>108</onleft>
			<onright>105</onright>
			<onup>114</onup>
			<ondown>104</ondown>
			<textureFocus>-</textureFocus>
			<textureNoFocus>-</textureNoFocus>
		</control>



		<!-- ID 110 -->
		<control>
			<description>110 image</description>
			<type>image</type>
			<id>0</id>
			<posX>126</posX>
			<posY>76</posY>
			<width>226</width>
			<height>196</height>
			<texture>basichome_110_nofocus.png</texture>
		</control>
		<control>
			<description>110 hover image</description>
			<type>image</type>
			<id>0</id>
			<posX>126</posX>
			<posY>76</posY>
			<width>226</width>
			<height>196</height>
			<texture>basichome_110_focus.png</texture>
			<visible>control.hasfocus(110)</visible>
			<animation effect=""fade"" time=""500"">VisibleChange</animation>
			<animation effect=""zoom"" start=""100,100"" end=""102,102"" time=""500"">VisibleChange</animation>
		</control>
		<control>
			<description>110 hover label</description>
			<type>label</type>
			<id>0</id>
			<posX>0</posX>
			<posY>618</posY>
			<width>1280</width>
			<label>" + SecurityElement.Escape(textBox110.Text) + @"</label>
			<font>font48</font>
			<align>center</align>
			<visible>control.hasfocus(110)</visible>
			<textcolor>ffffffff</textcolor>
			<animation effect=""fade"" time=""500"">VisibleChange</animation>
		</control>
		<control>
			<description>110 button</description>
			<type>button</type>
			<id>110</id>
			<posX>126</posX>
			<posY>76</posY>
			<width>227</width>
			<height>197</height>
			<label>" + SecurityElement.Escape(textBox110.Text) + @"</label>
            <textXOff>3000</textXOff>
			<hyperlink>" + SecurityElement.Escape(textBoxid110.Text) + @"</hyperlink>
			<onleft>114</onleft>
			<onright>111</onright>
			<onup>17</onup>
			<ondown>105</ondown>
			<textureFocus>-</textureFocus>
			<textureNoFocus>-</textureNoFocus>
		</control>



		<!-- ID 111 -->
		<control>
			<description>111 image</description>
			<type>image</type>
			<id>0</id>
			<posX>348</posX>
			<posY>138</posY>
			<width>201</width>
			<height>154</height>
			<texture>basichome_111_nofocus.png</texture>
		</control>
		<control>
			<description>111 hover image</description>
			<type>image</type>
			<id>0</id>
			<posX>348</posX>
			<posY>138</posY>
			<width>201</width>
			<height>154</height>
			<texture>basichome_111_focus.png</texture>
			<visible>control.hasfocus(111)</visible>
			<animation effect=""fade"" time=""500"">VisibleChange</animation>
			<animation effect=""zoom"" start=""100,100"" end=""102,102"" time=""500"">VisibleChange</animation>
		</control>
		<control>
			<description>111 hover label</description>
			<type>label</type>
			<id>0</id>
			<posX>0</posX>
			<posY>618</posY>
			<width>1280</width>
			<label>" + SecurityElement.Escape(textBox111.Text) + @"</label>
			<font>font48</font>
			<align>center</align>
			<visible>control.hasfocus(111)</visible>
			<textcolor>ffffffff</textcolor>
			<animation effect=""fade"" time=""500"">VisibleChange</animation>
		</control>
		<control>
			<description>111 button</description>
			<type>button</type>
			<id>111</id>
			<posX>347</posX>
			<posY>138</posY>
			<width>204</width>
			<height>158</height>
			<label>" + SecurityElement.Escape(textBox111.Text) + @"</label>
            <textXOff>3000</textXOff>
			<hyperlink>" + SecurityElement.Escape(textBoxid111.Text) + @"</hyperlink>
			<onleft>110</onleft>
			<onright>112</onright>
			<onup>17</onup>
			<ondown>106</ondown>
			<textureFocus>-</textureFocus>
			<textureNoFocus>-</textureNoFocus>
		</control>



		<!-- ID 112 -->
		<control>
			<description>112 image</description>
			<type>image</type>
			<id>0</id>
			<posX>545</posX>
			<posY>162</posY>
			<width>190</width>
			<height>133</height>
			<texture>basichome_112_nofocus.png</texture>
		</control>
		<control>
			<description>112 hover image</description>
			<type>image</type>
			<id>0</id>
			<posX>545</posX>
			<posY>162</posY>
			<width>190</width>
			<height>133</height>
			<visible>control.hasfocus(112)</visible>
			<texture>basichome_112_focus.png</texture>
			<animation effect=""fade"" time=""500"">VisibleChange</animation>
			<animation effect=""zoom"" start=""100,100"" end=""102,102"" time=""500"">VisibleChange</animation>
		</control>
		<control>
			<description>112 hover label</description>
			<type>label</type>
			<id>0</id>
			<posX>0</posX>
			<posY>618</posY>
			<width>1280</width>
			<label>" + SecurityElement.Escape(textBox112.Text) + @"</label>
			<font>font48</font>
			<align>center</align>
			<visible>control.hasfocus(112)</visible>
			<textcolor>ffffffff</textcolor>
			<animation effect=""fade"" time=""500"">VisibleChange</animation>
		</control>
		<control>
			<description>112 button</description>
			<type>button</type>
			<id>112</id>
			<posX>544</posX>
			<posY>162</posY>
			<width>192</width>
			<height>134</height>
			<label>" + SecurityElement.Escape(textBox112.Text) + @"</label>
            <textXOff>3000</textXOff>
			<hyperlink>" + SecurityElement.Escape(textBoxid112.Text) + @"</hyperlink>
			<onleft>111</onleft>
			<onright>113</onright>
			<onup>18</onup>
			<ondown>107</ondown>
			<textureFocus>-</textureFocus>
			<textureNoFocus>-</textureNoFocus>
		</control>



		<!-- ID 113 -->
		<control>
			<description>113 image</description>
			<type>image</type>
			<id>0</id>
			<posX>731</posX>
			<posY>138</posY>
			<width>201</width>
			<height>154</height>
			<texture>basichome_113_nofocus.png</texture>
		</control>
		<control>
			<description>113 hover image</description>
			<type>image</type>
			<id>0</id>
			<posX>731</posX>
			<posY>138</posY>
			<width>201</width>
			<height>154</height>
			<texture>basichome_113_focus.png</texture>
			<visible>control.hasfocus(113)</visible>
			<animation effect=""fade"" time=""500"">VisibleChange</animation>
			<animation effect=""zoom"" start=""100,100"" end=""102,102"" time=""500"">VisibleChange</animation>
		</control>
		<control>
			<description>113 hover label</description>
			<type>label</type>
			<id>0</id>
			<posX>0</posX>
			<posY>618</posY>
			<width>1280</width>
			<label>" + SecurityElement.Escape(textBox113.Text) + @"</label>
			<font>font48</font>
			<align>center</align>
			<visible>control.hasfocus(113)</visible>
			<textcolor>ffffffff</textcolor>
			<animation effect=""fade"" time=""500"">VisibleChange</animation>
		</control>
		<control>
			<description>113 button</description>
			<type>button</type>
			<id>113</id>
			<posX>730</posX>
			<posY>138</posY>
			<width>203</width>
			<height>155</height>
			<label>" + SecurityElement.Escape(textBox113.Text) + @"</label>
            <textXOff>3000</textXOff>
			<!-- <hyperlink>2700</hyperlink> -->
			<hyperlink>" + SecurityElement.Escape(textBoxid113.Text) + @"</hyperlink>
			<onleft>112</onleft>
			<onright>114</onright>
			<onup>19</onup>
			<ondown>108</ondown>
			<textureFocus>-</textureFocus>
			<textureNoFocus>-</textureNoFocus>
		</control>



		<!-- ID 114 -->
		<control>
			<description>114 image</description>
			<type>image</type>
			<id>0</id>
			<posX>929</posX>
			<posY>76</posY>
			<width>225</width>
			<height>196</height>
			<texture>basichome_114_nofocus.png</texture>
		</control>
		<control>
			<description>114 hover image</description>
			<type>image</type>
			<id>0</id>
			<posX>929</posX>
			<posY>76</posY>
			<width>225</width>
			<height>196</height>
			<texture>basichome_114_focus.png</texture>
			<visible>control.hasfocus(114)</visible>
			<animation effect=""fade"" time=""500"">VisibleChange</animation>
			<animation effect=""zoom"" start=""100,100"" end=""102,102"" time=""500"">VisibleChange</animation>
		</control>
		<control>
			<description>114 hover label</description>
			<type>label</type>
			<id>0</id>
			<posX>0</posX>
			<posY>618</posY>
			<width>1280</width>
			<label>" + SecurityElement.Escape(textBox114.Text) + @"</label>
			<font>font48</font>
			<align>center</align>
			<visible>control.hasfocus(114)</visible>
			<textcolor>ffffffff</textcolor>
			<animation effect=""fade"" time=""500"">VisibleChange</animation>
		</control>
		<control>
			<description>114 button</description>
			<type>button</type>
			<id>114</id>
			<posX>928</posX>
			<posY>76</posY>
			<width>227</width>
			<height>197</height>
			<label>" + SecurityElement.Escape(textBox114.Text) + @"</label>
            <textXOff>3000</textXOff>
			<hyperlink>" + SecurityElement.Escape(textBoxid114.Text) + @"</hyperlink>
			<onleft>113</onleft>
			<onright>110</onright>
			<onup>19</onup>
			<ondown>109</ondown>
			<textureFocus>-</textureFocus>
			<textureNoFocus>-</textureNoFocus>
		</control>


        <!-- SUBTITLES -->
        <control>
			<description>Weather Description</description>
			<type>label</type>
			<id>0</id>
			<posX>0</posX>
			<posY>666</posY>
			<width>1280</width>
			<label>#infoservice.weather.today.temp     #infoservice.weather.today.humidity     #infoservice.weather.today.condition     #infoservice.weather.location</label>
			<align>center</align>
			<font>font11</font>
			<visible>plugin.isenabled(InfoService)+control.hasfocus(" + weather_button + @")</visible>
			<textcolor>90ffffff</textcolor>
		</control>
		
		<control>
			<description>TVSeries updates</description>
			<type>label</type>
			<id>0</id>
			<posX>0</posX>
			<posY>666</posY>
			<width>1280</width>
			<label>Recently added:     #infoservice.recentlyAdded.series1.title     Season #infoservice.recentlyAdded.series1.season     Episode #infoservice.recentlyAdded.series1.episodenumber     #infoservice.recentlyAdded.series1.episodetitle</label>			<align>center</align>
			<font>font11</font>
			<visible>plugin.isenabled(InfoService)+control.hasfocus(" + tvseries_button + @")+plugin.isenabled(MP-TV Series)</visible>
			<textcolor>90ffffff</textcolor>
		</control>
		
		<!-- <control>
			<description>Moving Pictures updates</description>
			<type>label</type>
			<id>0</id>
			<posX>0</posX>
			<posY>666</posY>
			<width>1280</width>
			<label>Recently added:     #infoservice.recentlyAdded.movie1.title</label>
			<align>center</align>
			<font>font11</font>
			<visible>plugin.isenabled(InfoService)+control.hasfocus(" + movingpictures_button + @")+plugin.isenabled(Moving Pictures)</visible>
			<textcolor>90ffffff</textcolor>
		</control> -->
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
                textWriter.WriteEndElement();

                textWriter.WriteStartElement("button");
                textWriter.WriteStartElement("Id", "");
                textWriter.WriteString("107");
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("name", "");
                textWriter.WriteString(SecurityElement.Escape(textBox107.Text));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("plugin", "");
                textWriter.WriteString(SecurityElement.Escape(textBoxid107.Text));
                textWriter.WriteEndElement();
                textWriter.WriteEndElement();

                textWriter.WriteStartElement("button");
                textWriter.WriteStartElement("Id", "");
                textWriter.WriteString("108");
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("name", "");
                textWriter.WriteString(SecurityElement.Escape(textBox108.Text));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("plugin", "");
                textWriter.WriteString(SecurityElement.Escape(textBoxid108.Text));
                textWriter.WriteEndElement();
                textWriter.WriteEndElement();

                textWriter.WriteStartElement("button");
                textWriter.WriteStartElement("Id", "");
                textWriter.WriteString("109");
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("name", "");
                textWriter.WriteString(SecurityElement.Escape(textBox109.Text));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("plugin", "");
                textWriter.WriteString(SecurityElement.Escape(textBoxid109.Text));
                textWriter.WriteEndElement();
                textWriter.WriteEndElement();

                textWriter.WriteStartElement("button");
                textWriter.WriteStartElement("Id", "");
                textWriter.WriteString("110");
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("name", "");
                textWriter.WriteString(SecurityElement.Escape(textBox110.Text));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("plugin", "");
                textWriter.WriteString(SecurityElement.Escape(textBoxid110.Text));
                textWriter.WriteEndElement();
                textWriter.WriteEndElement();

                textWriter.WriteStartElement("button");
                textWriter.WriteStartElement("Id", "");
                textWriter.WriteString("111");
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("name", "");
                textWriter.WriteString(SecurityElement.Escape(textBox111.Text));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("plugin", "");
                textWriter.WriteString(SecurityElement.Escape(textBoxid111.Text));
                textWriter.WriteEndElement();
                textWriter.WriteEndElement();

                textWriter.WriteStartElement("button");
                textWriter.WriteStartElement("Id", "");
                textWriter.WriteString("112");
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("name", "");
                textWriter.WriteString(SecurityElement.Escape(textBox112.Text));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("plugin", "");
                textWriter.WriteString(SecurityElement.Escape(textBoxid112.Text));
                textWriter.WriteEndElement();
                textWriter.WriteEndElement();

                textWriter.WriteStartElement("button");
                textWriter.WriteStartElement("Id", "");
                textWriter.WriteString("113");
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("name", "");
                textWriter.WriteString(SecurityElement.Escape(textBox113.Text));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("plugin", "");
                textWriter.WriteString(SecurityElement.Escape(textBoxid113.Text));
                textWriter.WriteEndElement();
                textWriter.WriteEndElement();

                textWriter.WriteStartElement("button");
                textWriter.WriteStartElement("Id", "");
                textWriter.WriteString("114");
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("name", "");
                textWriter.WriteString(SecurityElement.Escape(textBox114.Text));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("plugin", "");
                textWriter.WriteString(SecurityElement.Escape(textBoxid114.Text));
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


        public MPplugin() { }
        public MPplugin(int hyperlink, string name)
        {
            this._hyperlink = hyperlink;
            this._name = name;

        }
    }
}