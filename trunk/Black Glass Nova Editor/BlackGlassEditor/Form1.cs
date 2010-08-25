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

            string path = System.IO.Path.Combine(Application.StartupPath, "plugins.xml");
            FileStream READER = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            System.Xml.XmlDocument Plugins = new System.Xml.XmlDocument();
            Plugins.Load(READER);
            System.Xml.XmlNodeList NodeList = Plugins.GetElementsByTagName("plugins");

            XmlNodeList pid = Plugins.GetElementsByTagName("id");
            XmlNodeList pname = Plugins.GetElementsByTagName("name");
            XmlNodeList phover = Plugins.GetElementsByTagName("hover");

            plugins.Add(new MPplugin(0, "Empty Button", ""));

            for (int i = 0; i < pid.Count; i++ )
            {
                plugins.Add(new MPplugin(int.Parse(pid[i].InnerText), pname[i].InnerText, phover[i].InnerText));
            }

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

            path = System.IO.Path.Combine(Application.StartupPath, "settings.xml");
            READER = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            System.Xml.XmlDocument Buttons = new System.Xml.XmlDocument();
            Buttons.Load(READER);
            NodeList = Buttons.GetElementsByTagName("Buttons");

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
            if (plugin[5].InnerText != "0") textBoxid105.Text = plugin[5].InnerText;
            if (plugin[6].InnerText != "0") textBoxid106.Text = plugin[6].InnerText;
            if (plugin[7].InnerText != "0") textBoxid107.Text = plugin[7].InnerText;
            if (plugin[8].InnerText != "0") textBoxid108.Text = plugin[8].InnerText;
            if (plugin[9].InnerText != "0") textBoxid109.Text = plugin[9].InnerText;
            if (plugin[10].InnerText != "0") textBoxid110.Text = plugin[10].InnerText;
            if (plugin[11].InnerText != "0") textBoxid111.Text = plugin[11].InnerText;
            if (plugin[12].InnerText != "0") textBoxid112.Text = plugin[12].InnerText;
            if (plugin[13].InnerText != "0") textBoxid113.Text = plugin[13].InnerText;
            if (plugin[14].InnerText != "0") textBoxid114.Text = plugin[14].InnerText;

            textBoxhover100.Text = hover[0].InnerText;
            textBoxhover101.Text = hover[1].InnerText;
            textBoxhover102.Text = hover[2].InnerText;
            textBoxhover103.Text = hover[3].InnerText;
            textBoxhover104.Text = hover[4].InnerText;
            textBoxhover105.Text = hover[5].InnerText;
            textBoxhover106.Text = hover[6].InnerText;
            textBoxhover107.Text = hover[7].InnerText;
            textBoxhover108.Text = hover[8].InnerText;
            textBoxhover109.Text = hover[9].InnerText;
            textBoxhover110.Text = hover[10].InnerText;
            textBoxhover111.Text = hover[11].InnerText;
            textBoxhover112.Text = hover[12].InnerText;
            textBoxhover113.Text = hover[13].InnerText;
            textBoxhover114.Text = hover[14].InnerText;

            String ApplicationPath = Application.StartupPath;


            if (File.Exists(ApplicationPath + "\\100.jpg")) pictureBox100.Image = formatImage((Bitmap)Bitmap.FromFile(ApplicationPath + "\\100.jpg"), "100");
            if (File.Exists(ApplicationPath + "\\101.jpg")) pictureBox101.Image = formatImage((Bitmap)Bitmap.FromFile(ApplicationPath + "\\101.jpg"), "101");
            if (File.Exists(ApplicationPath + "\\102.jpg")) pictureBox102.Image = formatImage((Bitmap)Bitmap.FromFile(ApplicationPath + "\\102.jpg"), "102");
            if (File.Exists(ApplicationPath + "\\103.jpg")) pictureBox103.Image = formatImage((Bitmap)Bitmap.FromFile(ApplicationPath + "\\103.jpg"), "103");
            if (File.Exists(ApplicationPath + "\\104.jpg")) pictureBox104.Image = formatImage((Bitmap)Bitmap.FromFile(ApplicationPath + "\\104.jpg"), "104");
            if (File.Exists(ApplicationPath + "\\105.jpg") && plugin[5].InnerText != "0") pictureBox105.Image = formatImage((Bitmap)Bitmap.FromFile(ApplicationPath + "\\105.jpg"), "105");
            if (File.Exists(ApplicationPath + "\\106.jpg") && plugin[6].InnerText != "0") pictureBox106.Image = formatImage((Bitmap)Bitmap.FromFile(ApplicationPath + "\\106.jpg"), "106");
            if (File.Exists(ApplicationPath + "\\107.jpg") && plugin[7].InnerText != "0") pictureBox107.Image = formatImage((Bitmap)Bitmap.FromFile(ApplicationPath + "\\107.jpg"), "107");
            if (File.Exists(ApplicationPath + "\\108.jpg") && plugin[8].InnerText != "0") pictureBox108.Image = formatImage((Bitmap)Bitmap.FromFile(ApplicationPath + "\\108.jpg"), "108");
            if (File.Exists(ApplicationPath + "\\109.jpg") && plugin[9].InnerText != "0") pictureBox109.Image = formatImage((Bitmap)Bitmap.FromFile(ApplicationPath + "\\109.jpg"), "109");
            if (File.Exists(ApplicationPath + "\\110.jpg") && plugin[10].InnerText != "0") pictureBox110.Image = formatImage((Bitmap)Bitmap.FromFile(ApplicationPath + "\\110.jpg"), "110");
            if (File.Exists(ApplicationPath + "\\111.jpg") && plugin[11].InnerText != "0") pictureBox111.Image = formatImage((Bitmap)Bitmap.FromFile(ApplicationPath + "\\111.jpg"), "111");
            if (File.Exists(ApplicationPath + "\\112.jpg") && plugin[12].InnerText != "0") pictureBox112.Image = formatImage((Bitmap)Bitmap.FromFile(ApplicationPath + "\\112.jpg"), "112");
            if (File.Exists(ApplicationPath + "\\113.jpg") && plugin[13].InnerText != "0") pictureBox113.Image = formatImage((Bitmap)Bitmap.FromFile(ApplicationPath + "\\113.jpg"), "113");
            if (File.Exists(ApplicationPath + "\\114.jpg") && plugin[14].InnerText != "0") pictureBox114.Image = formatImage((Bitmap)Bitmap.FromFile(ApplicationPath + "\\114.jpg"), "114");

            BlackGlassDirClass.Path = plugin[15].InnerText;

            if (!Directory.Exists(BlackGlassDirClass.Path)) BlackGlassDirClass.Path = findBlackGlassSkinDir();

            textBoxTarget.Text = BlackGlassDirClass.Path;
        }


        public Bitmap formatImage(Bitmap img, String name)
        {
            Bitmap reflectedImg = img;
            int newsizeX = new int();
            int newsizeY = new int();
            int topleftX = new int();
            int topleftY = new int();
            int toprightX = new int();
            int toprightY = new int();
            int bottomleftX = new int();
            int bottomleftY = new int();
            int bottomrightX = new int();
            int bottomrightY = new int();
            int offsetX = new int();
            int offsetY = new int();

            switch (name)
            {

                case "100":
                    newsizeX = 239; newsizeY = 245;
                    topleftX = 18; topleftY = 3;
                    toprightX = 232; toprightY = 13;
                    bottomleftX = 6; bottomleftY = 163;
                    bottomrightX = 226; bottomrightY = 150;
                    break;

                case "101":
                    newsizeX = 209; newsizeY = 214;
                    topleftX = 11; topleftY = 3;
                    toprightX = 202; toprightY = 7;
                    bottomleftX = 6; bottomleftY = 137;
                    bottomrightX = 200; bottomrightY = 132;
                    break;

                case "102":
                    newsizeX = 196; newsizeY = 205;
                    topleftX = 7; topleftY = 3;
                    toprightX = 189; toprightY = 3;
                    bottomleftX = 7; bottomleftY = 127;
                    bottomrightX = 189; bottomrightY = 127;
                    break;

                case "103":
                    newsizeX = 209; newsizeY = 215;
                    topleftX = 6; topleftY = 8;
                    toprightX = 196; toprightY = 3;
                    bottomleftX = 8; bottomleftY = 132;
                    bottomrightX = 202; bottomrightY = 136;
                    break;

                case "104":
                    newsizeX = 239; newsizeY = 242;
                    topleftX = 7; topleftY = 14;
                    toprightX = 220; toprightY = 3;
                    bottomleftX = 12; bottomleftY = 150;
                    bottomrightX = 232; bottomrightY = 163;
                    break;

                case "105":
                    newsizeX = 232; newsizeY = 183;
                    topleftX = 18; topleftY = 3;
                    toprightX = 224; toprightY = 40;
                    bottomleftX = 6; bottomleftY = 156;
                    bottomrightX = 219; bottomrightY = 171;
                    break;

                case "106":
                    newsizeX = 205; newsizeY = 151;
                    topleftX = 11; topleftY = 3;
                    toprightX = 198; toprightY = 18;
                    bottomleftX = 6; bottomleftY = 134;
                    bottomrightX = 196; bottomrightY = 139;
                    break;

                case "107":
                    newsizeX = 194; newsizeY = 137;
                    topleftX = 8; topleftY = 3;
                    toprightX = 185; toprightY = 3;
                    bottomleftX = 7; bottomleftY = 124;
                    bottomrightX = 187; bottomrightY = 124;
                    break;

                case "108":
                    newsizeX = 205; newsizeY = 151;
                    topleftX = 8; topleftY = 18;
                    toprightX = 192; toprightY = 3;
                    bottomleftX = 8; bottomleftY = 139;
                    bottomrightX = 198; bottomrightY = 133;
                    break;

                case "109":
                    newsizeX = 232; newsizeY = 183;
                    topleftX = 6; topleftY = 44;
                    toprightX = 214; toprightY = 4;
                    bottomleftX = 11; bottomleftY = 180;
                    bottomrightX = 224; bottomrightY = 157;
                    break;

                case "110":
                    newsizeX = 226; newsizeY = 196;
                    topleftX = 18; topleftY = 2;
                    toprightX = 219; toprightY = 62;
                    bottomleftX = 6; bottomleftY = 144;
                    bottomrightX = 213; bottomrightY = 185;
                    break;

                case "111":
                    newsizeX = 201; newsizeY = 154;
                    topleftX = 11; topleftY = 2;
                    toprightX = 194; toprightY = 25;
                    bottomleftX = 6; bottomleftY = 125;
                    bottomrightX = 192; bottomrightY = 142;
                    break;

                case "112":
                    newsizeX = 190; newsizeY = 133;
                    topleftX = 8; topleftY = 4;
                    toprightX = 182; toprightY = 4;
                    bottomleftX = 8; bottomleftY = 120;
                    bottomrightX = 182; bottomrightY = 120;
                    break;

                case "113":
                    newsizeX = 201; newsizeY = 154;
                    topleftX = 7; topleftY = 26;
                    toprightX = 189; toprightY = 2;
                    bottomleftX = 8; bottomleftY = 142;
                    bottomrightX = 194; bottomrightY = 126;
                    break;

                case "114":
                    newsizeX = 225; newsizeY = 196;
                    topleftX = 6; topleftY = 62;
                    toprightX = 208; toprightY = 1;
                    bottomleftX = 11; bottomleftY = 186;
                    bottomrightX = 218; bottomrightY = 144;
                    break;

            }


            Size newsize = new Size(newsizeX, newsizeY);

            Point topleft = new Point(topleftX, topleftY);
            Point topright = new Point(toprightX, toprightY);
            Point bottomleft = new Point(bottomleftX, bottomleftY);
            Point bottomright = new Point(bottomrightX, bottomrightY);

            img = QuadDistort.Distort((Bitmap)Functions.resizeImage((Bitmap)img, newsize), topleft, topright, bottomleft, bottomright);


            if (name == "100" || name == "101" || name == "102" || name == "103" || name == "104")
            {

                reflectedImg.RotateFlip(RotateFlipType.RotateNoneFlipY);

                switch (name)
                {

                    case "100":
                        topleftX = 11; topleftY = 157;
                        toprightX = 236; toprightY = 131;
                        bottomleftX = 3; bottomleftY = 305;
                        bottomrightX = 232; bottomrightY = 300;
                        offsetX = -5; offsetY = 89;
                        break;

                    case "101":
                        topleftX = 6; topleftY = 134;
                        toprightX = 203; toprightY = 120;
                        bottomleftX = 0; bottomleftY = 280;
                        bottomrightX = 205; bottomrightY = 284;
                        offsetX = 0; offsetY = 82;
                        break;

                    case "102":
                        topleftX = 6; topleftY = 89;
                        toprightX = 193; toprightY = 89;
                        bottomleftX = 6; bottomleftY = 204;
                        bottomrightX = 193; bottomrightY = 204;
                        offsetX = 0; offsetY = 80;
                        break;

                    case "103":
                        topleftX = 3; topleftY = 93;
                        toprightX = 202; toprightY = 100;
                        bottomleftX = 3; bottomleftY = 215;
                        bottomrightX = 209; bottomrightY = 215;
                        offsetX = 6; offsetY = 82;
                        break;

                    case "104":
                        topleftX = 5; topleftY = 122;
                        toprightX = 234; toprightY = 149;
                        bottomleftX = 9; bottomleftY = 285;
                        bottomrightX = 239; bottomrightY = 285;
                        offsetX = 5; offsetY = 89;
                        break;

                }

                topleft = new Point(topleftX, topleftY);
                topright = new Point(toprightX, toprightY);
                bottomleft = new Point(bottomleftX, bottomleftY);
                bottomright = new Point(bottomrightX, bottomrightY);

                reflectedImg = QuadDistort.Distort((Bitmap)Functions.resizeImage((Bitmap)reflectedImg, newsize), topleft, topright, bottomleft, bottomright);
            }


            Bitmap dummyImage = new Bitmap(newsizeX, newsizeY);
            Graphics ga = Graphics.FromImage(dummyImage);
            ga.DrawImage(img, new System.Drawing.Rectangle(0, 0, img.Width, img.Height));

            if (name == "100" || name == "101" || name == "102" || name == "103" || name == "104")
            {
                ga.DrawImage(reflectedImg, new System.Drawing.Rectangle(offsetX, offsetY, img.Width, img.Height));
            }
            img.Dispose();
            reflectedImg.Dispose();
            return dummyImage;
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
                            saveSettingsImage(img, "100.jpg");
                            pictureBox100.Image = formatImage(img, "100");
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
                            saveSettingsImage(img, "101.jpg");
                            pictureBox101.Image = formatImage(img, "101");
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
                            saveSettingsImage(img, "102.jpg");
                            pictureBox102.Image = formatImage(img, "102");
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
                            saveSettingsImage(img, "103.jpg");
                            pictureBox103.Image = formatImage(img, "103");
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
                            saveSettingsImage(img, "104.jpg");
                            pictureBox104.Image = formatImage(img, "104");
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
                            saveSettingsImage(img, "105.jpg");
                            pictureBox105.Image = formatImage(img, "105");
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
                            saveSettingsImage(img, "106.jpg");
                            pictureBox106.Image = formatImage(img, "106");
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
                            saveSettingsImage(img, "107.jpg");
                            pictureBox107.Image = formatImage(img, "107");
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
                            saveSettingsImage(img, "108.jpg");
                            pictureBox108.Image = formatImage(img, "108");
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
                            saveSettingsImage(img, "109.jpg");
                            pictureBox109.Image = formatImage(img, "109");
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
                            saveSettingsImage(img, "110.jpg");
                            pictureBox110.Image = formatImage(img, "110");
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
                            saveSettingsImage(img, "111.jpg");
                            pictureBox111.Image = formatImage(img, "111");
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
                            saveSettingsImage(img, "112.jpg");
                            pictureBox112.Image = formatImage(img, "112");
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
                            saveSettingsImage(img, "113.jpg");
                            pictureBox113.Image = formatImage(img, "113");
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
                            saveSettingsImage(img, "114.jpg");
                            pictureBox114.Image = formatImage(img, "114");
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
                shadow = (Bitmap)Functions.SetImgOpacity(shadow, 0.70f);
                img = Functions.MakeGrayscale(img);
                img = Functions.SetImgOpacity(img, 0.70f);
            }

            gfxClip.DrawImage(img, new System.Drawing.Rectangle(0, 0, img.Width, img.Height));


            gfx.DrawImage(shadow, new System.Drawing.Rectangle(0, 0, shadow.Width, shadow.Height));

            if (focus == 1)
            {
                myStream = myAssembly.GetManifestResourceStream("BlackGlassEditor.Images.basichome_" + buttonRif + "_contour.png");
                Bitmap contour = new Bitmap(myStream);
                gfx.DrawImage(contour, new System.Drawing.Rectangle(0, 0, contour.Width, contour.Height));
                contour.Dispose();
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
                shadow = (Bitmap)Functions.SetImgOpacity(shadow, 0.70f);
                img = Functions.MakeGrayscale(img);
                
            }

            img = Functions.SetImgOpacity(img, 0.70f);

            gfxClip.DrawImage(img, new System.Drawing.Rectangle(0, 0, img.Width, img.Height));


            gfx.DrawImage(shadow, new System.Drawing.Rectangle(0, 0, shadow.Width, shadow.Height));

            //if (focus == 1)
            //{
            //    myStream = myAssembly.GetManifestResourceStream("BlackGlassEditor.Images.basichome_" + buttonRif + "_contour.png");
            //    Bitmap contour = new Bitmap(myStream);
            //    gfx.DrawImage(contour, new System.Drawing.Rectangle(0, 0, contour.Width, contour.Height));
            //}

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
            if (comboBox100.Text == "Empty Button") { textBox100.Text = ""; textBoxid100.Text = ""; };
        }
        private void comboBox101_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox101.Text = comboBox101.Text;
            textBoxid101.Text = findPlugin(comboBox101.Text).ToString();
            textBoxhover101.Text = findPluginHover(Int32.Parse(textBoxid101.Text));
            if (comboBox101.Text == "Empty Button") { textBox101.Text = ""; textBoxid101.Text = ""; };
        }
        private void comboBox102_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox102.Text = comboBox102.Text;
            textBoxid102.Text = findPlugin(comboBox102.Text).ToString();
            textBoxhover102.Text = findPluginHover(Int32.Parse(textBoxid102.Text));
            if (comboBox102.Text == "Empty Button") { textBox102.Text = ""; textBoxid102.Text = ""; };
        }
        private void comboBox103_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox103.Text = comboBox103.Text;
            textBoxid103.Text = findPlugin(comboBox103.Text).ToString();
            textBoxhover103.Text = findPluginHover(Int32.Parse(textBoxid103.Text));
            if (comboBox103.Text == "Empty Button") { textBox103.Text = ""; textBoxid103.Text = ""; };
        }
        private void comboBox104_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox104.Text = comboBox104.Text;
            textBoxid104.Text = findPlugin(comboBox104.Text).ToString();
            textBoxhover104.Text = findPluginHover(Int32.Parse(textBoxid104.Text));
            if (comboBox104.Text == "Empty Button") { textBox104.Text = ""; textBoxid104.Text = ""; };
        }
        private void comboBox105_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox105.Text = comboBox105.Text;
            textBoxid105.Text = findPlugin(comboBox105.Text).ToString();
            textBoxhover105.Text = findPluginHover(Int32.Parse(textBoxid105.Text));
            if (comboBox105.Text == "Empty Button") { textBox105.Text = ""; textBoxid105.Text = ""; };
        }
        private void comboBox106_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox106.Text = comboBox106.Text;
            textBoxid106.Text = findPlugin(comboBox106.Text).ToString();
            textBoxhover106.Text = findPluginHover(Int32.Parse(textBoxid106.Text));
            if (comboBox106.Text == "Empty Button") { textBox106.Text = ""; textBoxid106.Text = ""; };
        }
        private void comboBox107_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox107.Text = comboBox107.Text;
            textBoxid107.Text = findPlugin(comboBox107.Text).ToString();
            textBoxhover107.Text = findPluginHover(Int32.Parse(textBoxid107.Text));
            if (comboBox107.Text == "Empty Button") { textBox107.Text = ""; textBoxid107.Text = ""; };
        }
        private void comboBox108_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox108.Text = comboBox108.Text;
            textBoxid108.Text = findPlugin(comboBox108.Text).ToString();
            textBoxhover108.Text = findPluginHover(Int32.Parse(textBoxid108.Text));
            if (comboBox108.Text == "Empty Button") { textBox108.Text = ""; textBoxid108.Text = ""; };
        }
        private void comboBox109_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox109.Text = comboBox109.Text;
            textBoxid109.Text = findPlugin(comboBox109.Text).ToString();
            textBoxhover109.Text = findPluginHover(Int32.Parse(textBoxid109.Text));
            if (comboBox109.Text == "Empty Button") { textBox109.Text = ""; textBoxid109.Text = ""; };
        }
        private void comboBox110_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox110.Text = comboBox110.Text;
            textBoxid110.Text = findPlugin(comboBox110.Text).ToString();
            textBoxhover110.Text = findPluginHover(Int32.Parse(textBoxid110.Text));
            if (comboBox110.Text == "Empty Button") { textBox110.Text = ""; textBoxid110.Text = ""; };
        }
        private void comboBox111_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox111.Text = comboBox111.Text;
            textBoxid111.Text = findPlugin(comboBox111.Text).ToString();
            textBoxhover111.Text = findPluginHover(Int32.Parse(textBoxid111.Text));
            if (comboBox111.Text == "Empty Button") { textBox111.Text = ""; textBoxid111.Text = ""; };
        }
        private void comboBox112_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox112.Text = comboBox112.Text;
            textBoxid112.Text = findPlugin(comboBox112.Text).ToString();
            textBoxhover112.Text = findPluginHover(Int32.Parse(textBoxid112.Text));
            if (comboBox112.Text == "Empty Button") { textBox112.Text = ""; textBoxid112.Text = ""; };
        }
        private void comboBox113_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox113.Text = comboBox113.Text;
            textBoxid113.Text = findPlugin(comboBox113.Text).ToString();
            textBoxhover113.Text = findPluginHover(Int32.Parse(textBoxid113.Text));
            if (comboBox113.Text == "Empty Button") { textBox113.Text = ""; textBoxid113.Text = ""; };
        }
        private void comboBox114_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox114.Text = comboBox114.Text;
            textBoxid114.Text = findPlugin(comboBox114.Text).ToString();
            textBoxhover114.Text = findPluginHover(Int32.Parse(textBoxid114.Text));
            if (comboBox114.Text == "Empty Button") { textBox114.Text = ""; textBoxid114.Text = ""; };
        }


        public int findPlugin(string pluginName)
        {
            int hyperlink = 0;
            foreach (MPplugin p in plugins)
            {
                if (p.Name == pluginName) hyperlink = p.Hyperlink;
            }
            return hyperlink;
        }

        public string findPluginName(int pluginId)
        {
            string Name = "";
            foreach (MPplugin p in plugins)
            {
                if (p.Hyperlink == pluginId) Name = p.Name;
            }
            return Name;
        }

        public string findPluginHover(int pluginId)
        {
            string Hover = "";
            foreach (MPplugin p in plugins)
            {
                if (p.Hyperlink == pluginId) Hover = p.Hover;
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
            //if (pictureBox105.Image == null) errors++;
            //if (pictureBox106.Image == null) errors++;
            //if (pictureBox107.Image == null) errors++;
            //if (pictureBox108.Image == null) errors++;
            //if (pictureBox109.Image == null) errors++;
            //if (pictureBox110.Image == null) errors++;
            //if (pictureBox111.Image == null) errors++;
            //if (pictureBox112.Image == null) errors++;
            //if (pictureBox113.Image == null) errors++;
            //if (pictureBox114.Image == null) errors++;

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
            //if (textBox105.Text == "") errors++;
            //if (textBox106.Text == "") errors++;
            //if (textBox107.Text == "") errors++;
            //if (textBox108.Text == "") errors++;
            //if (textBox109.Text == "") errors++;
            //if (textBox110.Text == "") errors++;
            //if (textBox111.Text == "") errors++;
            //if (textBox112.Text == "") errors++;
            //if (textBox113.Text == "") errors++;
            //if (textBox114.Text == "") errors++;

            if (textBoxid100.Text == "") errors++;
            if (textBoxid101.Text == "") errors++;
            if (textBoxid102.Text == "") errors++;
            if (textBoxid103.Text == "") errors++;
            if (textBoxid104.Text == "") errors++;
            //if (textBoxid105.Text == "") errors++;
            //if (textBoxid106.Text == "") errors++;
            //if (textBoxid107.Text == "") errors++;
            //if (textBoxid108.Text == "") errors++;
            //if (textBoxid109.Text == "") errors++;
            //if (textBoxid110.Text == "") errors++;
            //if (textBoxid111.Text == "") errors++;
            //if (textBoxid112.Text == "") errors++;
            //if (textBoxid113.Text == "") errors++;
            //if (textBoxid114.Text == "") errors++;

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
            if (checktextboxes() > 0) MessageBox.Show("Error: At least a textbox is empty in the bottom row! All the Button Names and IDs in the bottom row must be filled up!");
            else if (checkpictures() > 0) MessageBox.Show("Error: At least a picture in the bottom row is empty! All the pictures in the bottom row must be filled up!");
            else if (checkColumns() > 0) MessageBox.Show("Error: At least a Column is missing a Button!");
            else if (checkEmptyPictures() > 0) MessageBox.Show("Error: At least a Button has no associated picture!");
            else if (checkEmptyCombos() > 0) MessageBox.Show("Error: At least a Button has no associated plugin!");
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

                Bitmap buttonImage100 = new Bitmap(buildImage(pictureBox100.Image, "100", 1));
                saveImage(BlackGlassDirClass.Path + "\\Media\\basichome_100_nofocus.png", pictureBox100.Image, "100", 0);
                saveImage(BlackGlassDirClass.Path + "\\Media\\basichome_100_focus.png", pictureBox100.Image, "100", 1);

                Bitmap buttonImage101 = new Bitmap(buildImage(pictureBox101.Image, "101", 1));
                saveImage(BlackGlassDirClass.Path + "\\Media\\basichome_101_nofocus.png", pictureBox101.Image, "101", 0);
                saveImage(BlackGlassDirClass.Path + "\\Media\\basichome_101_focus.png", pictureBox101.Image, "101", 1);

                Bitmap buttonImage102 = new Bitmap(buildImage(pictureBox102.Image, "102", 1));
                saveImage(BlackGlassDirClass.Path + "\\Media\\basichome_102_nofocus.png", pictureBox102.Image, "102", 0);
                saveImage(BlackGlassDirClass.Path + "\\Media\\basichome_102_focus.png", pictureBox102.Image, "102", 1);

                Bitmap buttonImage103 = new Bitmap(buildImage(pictureBox103.Image, "103", 1));
                saveImage(BlackGlassDirClass.Path + "\\Media\\basichome_103_nofocus.png", pictureBox103.Image, "103", 0);
                saveImage(BlackGlassDirClass.Path + "\\Media\\basichome_103_focus.png", pictureBox103.Image, "103", 1);

                Bitmap buttonImage104 = new Bitmap(buildImage(pictureBox104.Image, "104", 1));
                saveImage(BlackGlassDirClass.Path + "\\Media\\basichome_104_nofocus.png", pictureBox104.Image, "104", 0);
                saveImage(BlackGlassDirClass.Path + "\\Media\\basichome_104_focus.png", pictureBox104.Image, "104", 1);

                Bitmap buttonImage105 = null; 
                if (pictureBox105.Image != null)
                {
                    buttonImage105 = new Bitmap(buildImage(pictureBox105.Image, "105", 1));
                    saveImage(BlackGlassDirClass.Path + "\\Media\\basichome_105_nofocus.png", pictureBox105.Image, "105", 0);
                    saveImage(BlackGlassDirClass.Path + "\\Media\\basichome_105_focus.png", pictureBox105.Image, "105", 1);
                }
                Bitmap buttonImage106 = null;
                if (pictureBox106.Image != null)
                {
                    buttonImage106 = new Bitmap(buildImage(pictureBox106.Image, "106", 1));
                    saveImage(BlackGlassDirClass.Path + "\\Media\\basichome_106_nofocus.png", pictureBox106.Image, "106", 0);
                    saveImage(BlackGlassDirClass.Path + "\\Media\\basichome_106_focus.png", pictureBox106.Image, "106", 1);
                }
                Bitmap buttonImage107 = null;
                if (pictureBox107.Image != null)
                {
                    buttonImage107 = new Bitmap(buildImage(pictureBox107.Image, "107", 1));
                    saveImage(BlackGlassDirClass.Path + "\\Media\\basichome_107_nofocus.png", pictureBox107.Image, "107", 0);
                    saveImage(BlackGlassDirClass.Path + "\\Media\\basichome_107_focus.png", pictureBox107.Image, "107", 1);
                }
                Bitmap buttonImage108 = null;
                if (pictureBox108.Image != null)
                {
                    buttonImage108 = new Bitmap(buildImage(pictureBox108.Image, "108", 1));
                    saveImage(BlackGlassDirClass.Path + "\\Media\\basichome_108_nofocus.png", pictureBox108.Image, "108", 0);
                    saveImage(BlackGlassDirClass.Path + "\\Media\\basichome_108_focus.png", pictureBox108.Image, "108", 1);
                }
                Bitmap buttonImage109 = null;
                if (pictureBox109.Image != null)
                {
                    buttonImage109 = new Bitmap(buildImage(pictureBox109.Image, "109", 1));
                    saveImage(BlackGlassDirClass.Path + "\\Media\\basichome_109_nofocus.png", pictureBox109.Image, "109", 0);
                    saveImage(BlackGlassDirClass.Path + "\\Media\\basichome_109_focus.png", pictureBox109.Image, "109", 1);
                }
                Bitmap buttonImage110 = null;
                if (pictureBox110.Image != null)
                {
                    buttonImage110 = new Bitmap(buildImage(pictureBox110.Image, "110", 1));
                    saveImage(BlackGlassDirClass.Path + "\\Media\\basichome_110_nofocus.png", pictureBox110.Image, "110", 0);
                    saveImage(BlackGlassDirClass.Path + "\\Media\\basichome_110_focus.png", pictureBox110.Image, "110", 1);
                }
                Bitmap buttonImage111 = null;
                if (pictureBox111.Image != null)
                {
                    buttonImage111 = new Bitmap(buildImage(pictureBox111.Image, "111", 1));
                    saveImage(BlackGlassDirClass.Path + "\\Media\\basichome_111_nofocus.png", pictureBox111.Image, "111", 0);
                    saveImage(BlackGlassDirClass.Path + "\\Media\\basichome_111_focus.png", pictureBox111.Image, "111", 1);
                }
                Bitmap buttonImage112 = null;
                if (pictureBox112.Image != null)
                {
                    buttonImage112 = new Bitmap(buildImage(pictureBox112.Image, "112", 1));
                    saveImage(BlackGlassDirClass.Path + "\\Media\\basichome_112_nofocus.png", pictureBox112.Image, "112", 0);
                    saveImage(BlackGlassDirClass.Path + "\\Media\\basichome_112_focus.png", pictureBox112.Image, "112", 1);
                }
                Bitmap buttonImage113 = null;
                if (pictureBox113.Image != null)
                {
                    buttonImage113 = new Bitmap(buildImage(pictureBox113.Image, "113", 1));
                    saveImage(BlackGlassDirClass.Path + "\\Media\\basichome_113_nofocus.png", pictureBox113.Image, "113", 0);
                    saveImage(BlackGlassDirClass.Path + "\\Media\\basichome_113_focus.png", pictureBox113.Image, "113", 1);
                }
                Bitmap buttonImage114 = null;
                if (pictureBox114.Image != null)
                {
                    buttonImage114 = new Bitmap(buildImage(pictureBox114.Image, "114", 1));
                    saveImage(BlackGlassDirClass.Path + "\\Media\\basichome_114_nofocus.png", pictureBox114.Image, "114", 0);
                    saveImage(BlackGlassDirClass.Path + "\\Media\\basichome_114_focus.png", pictureBox114.Image, "114", 1);
                }

                // Setta il colore trasparente
                Color col = splash.GetPixel(1, 1);


                //CREA bg.jpg

                //gfx.DrawImage(bg, new System.Drawing.Rectangle(0, 0, 1280, 720));




                //CREA basichome_bg.jpg

                gfx.DrawImage(background, new System.Drawing.Rectangle(0, 0, 1280, 720));



                // CREA bg_homefull.jpg 
                gfx.DrawImage(gradient, new System.Drawing.Rectangle(0, 0, 1280, 720));

                
                
                // CARICAMENTO left & right
                myStream = myAssembly.GetManifestResourceStream("BlackGlassEditor.Images.basichome_left.png");
                Bitmap left = new Bitmap(myStream);
                myStream = myAssembly.GetManifestResourceStream("BlackGlassEditor.Images.basichome_right.png");
                Bitmap right = new Bitmap(myStream);

                gfx.DrawImage(left, new System.Drawing.Rectangle(0, 421, left.Width, left.Height));
                gfx.DrawImage(right, new System.Drawing.Rectangle(1182, 421, right.Width, right.Height));


                gfx.DrawImage(buttonImage100, new System.Drawing.Rectangle(100, 428, buttonImage100.Width, buttonImage100.Height));
                gfx.DrawImage(buttonImage101, new System.Drawing.Rectangle(336, 440, buttonImage101.Width, buttonImage101.Height));
                gfx.DrawImage(buttonImage102, new System.Drawing.Rectangle(542, 444, buttonImage102.Width, buttonImage102.Height));
                gfx.DrawImage(buttonImage103, new System.Drawing.Rectangle(736, 440, buttonImage103.Width, buttonImage103.Height));
                gfx.DrawImage(buttonImage104, new System.Drawing.Rectangle(941, 428, buttonImage104.Width, buttonImage104.Height));
                if (pictureBox105.Image != null) gfx.DrawImage(buttonImage105, new System.Drawing.Rectangle(114, 261, buttonImage105.Width, buttonImage105.Height));
                if (pictureBox106.Image != null) gfx.DrawImage(buttonImage106, new System.Drawing.Rectangle(342, 300, buttonImage106.Width, buttonImage106.Height));
                if (pictureBox107.Image != null) gfx.DrawImage(buttonImage107, new System.Drawing.Rectangle(543, 316, buttonImage107.Width, buttonImage107.Height));
                if (pictureBox108.Image != null) gfx.DrawImage(buttonImage108, new System.Drawing.Rectangle(733, 300, buttonImage108.Width, buttonImage108.Height));
                if (pictureBox109.Image != null) gfx.DrawImage(buttonImage109, new System.Drawing.Rectangle(935, 261, buttonImage109.Width, buttonImage109.Height));
                if (pictureBox110.Image != null) gfx.DrawImage(buttonImage110, new System.Drawing.Rectangle(126, 106, buttonImage110.Width, buttonImage110.Height));
                if (pictureBox111.Image != null) gfx.DrawImage(buttonImage111, new System.Drawing.Rectangle(348, 168, buttonImage111.Width, buttonImage111.Height));
                if (pictureBox112.Image != null) gfx.DrawImage(buttonImage112, new System.Drawing.Rectangle(545, 192, buttonImage112.Width, buttonImage112.Height));
                if (pictureBox113.Image != null) gfx.DrawImage(buttonImage113, new System.Drawing.Rectangle(731, 168, buttonImage113.Width, buttonImage113.Height));
                if (pictureBox114.Image != null) gfx.DrawImage(buttonImage114, new System.Drawing.Rectangle(929, 106, buttonImage114.Width, buttonImage114.Height));

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

                toolStripStatusLabel1.Text = "Basic Home Creation Complete!";
                MessageBox.Show("Basic Home Creation Complete!");

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
            if (Directory.Exists(Environment.GetEnvironmentVariable("ALLUSERSPROFILE") + @"\Team MediaPortal\MediaPortal\skin\Black Glass Nova")) path = Environment.GetEnvironmentVariable("ALLUSERSPROFILE") + @"\Team MediaPortal\MediaPortal\skin\Black Glass Nova";

            if (path == "") MessageBox.Show("Error: Could not find Black Glass Nova Skin. Use the 'Select Target Path' button to find it!");


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

            if (Directory.Exists(Environment.GetEnvironmentVariable("ALLUSERSPROFILE") + @"\Team MediaPortal\MediaPortal\Cache")) path = Environment.GetEnvironmentVariable("ALLUSERSPROFILE") + @"\Team MediaPortal\MediaPortal\Cache";

            if (path != "") Directory.Delete(path, true);
        }

        public void saveXML()
        {
            if (checktextboxes() > 0) MessageBox.Show("Error: At least a textbox in the bottom row is empty! All the Button Names and IDs in the bottom row must be filled up!");
            else if (BlackGlassDirClass.Path == "") MessageBox.Show("Error: Target Path is not set!");
            else if (checkColumns() > 0) MessageBox.Show("Error: At least a Column is missing a Button!");
            else if (checkEmptyCombos() > 0) MessageBox.Show("Error: At least a Button has no associated plugin!");
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

        ";
                if (pictureBox105.Image != null) txt = txt + @"<control>
			<description>1000 button</description>
			<type>button</type>
			<id>1000</id>
			<posX>216</posX>
			<posY>404</posY>
			<width>29</width>
			<height>25</height>
			<label>Up</label>
			<textXOff>3000</textXOff>
			<onleft>1000</onleft>
			<onright>1000</onright>
			<onup>105</onup>
			<ondown>100</ondown>
			<textureFocus>basichome_1000.png</textureFocus>
			<textureNoFocus>basichome_1000.png</textureNoFocus>
			<visible>control.hasfocus(100)</visible>
			<animation effect=""fade"" time=""500"">VisibleChange</animation>
			<animation effect=""zoom"" start=""70,70"" end=""100,100"" time=""500"">VisibleChange</animation>
			<animation effect=""slide"" end=""0,-6"" time=""500"">VisibleChange</animation>
		</control>
		
		";
                if (pictureBox106.Image != null) txt = txt + @"<control>
			<description>1001 button</description>
			<type>button</type>
			<id>1001</id>
			<posX>432</posX>
			<posY>415</posY>
			<width>28</width>
			<height>25</height>
			<label>Up</label>
			<textXOff>3000</textXOff>
			<onleft>1001</onleft>
			<onright>1001</onright>
			<onup>106</onup>
			<ondown>101</ondown>
			<textureFocus>basichome_1001.png</textureFocus>
			<textureNoFocus>basichome_1001.png</textureNoFocus>
			<visible>control.hasfocus(101)</visible>
			<animation effect=""fade"" time=""500"">VisibleChange</animation>
			<animation effect=""zoom"" start=""70,70"" end=""100,100"" time=""500"">VisibleChange</animation>
			<animation effect=""slide"" end=""0,-6"" time=""500"">VisibleChange</animation>
		</control>
		
		";
                if (pictureBox107.Image != null) txt = txt + @"<control>
			<description>1002 button</description>
			<type>button</type>
			<id>1002</id>
			<posX>626</posX>
			<posY>418</posY>
			<width>28</width>
			<height>24</height>
			<label>Up</label>
			<textXOff>3000</textXOff>
			<onleft>1002</onleft>
			<onright>1002</onright>
			<onup>107</onup>
			<ondown>102</ondown>
			<textureFocus>basichome_1002.png</textureFocus>
			<textureNoFocus>basichome_1002.png</textureNoFocus>
			<visible>control.hasfocus(102)</visible>
			<animation effect=""fade"" time=""500"">VisibleChange</animation>
			<animation effect=""zoom"" start=""70,70"" end=""100,100"" time=""500"">VisibleChange</animation>
			<animation effect=""slide"" end=""0,-6"" time=""500"">VisibleChange</animation>
		</control>
		
		";
                if (pictureBox108.Image != null) txt = txt + @"<control>
			<description>1003 button</description>
			<type>button</type>
			<id>1003</id>
			<posX>820</posX>
			<posY>415</posY>
			<width>28</width>
			<height>25</height>
			<label>Up</label>
			<textXOff>3000</textXOff>
			<onleft>1003</onleft>
			<onright>1003</onright>
			<onup>108</onup>
			<ondown>103</ondown>
			<textureFocus>basichome_1003.png</textureFocus>
			<textureNoFocus>basichome_1003.png</textureNoFocus>
			<visible>control.hasfocus(103)</visible>
			<animation effect=""fade"" time=""500"">VisibleChange</animation>
			<animation effect=""zoom"" start=""70,70"" end=""100,100"" time=""500"">VisibleChange</animation>
			<animation effect=""slide"" end=""0,-6"" time=""500"">VisibleChange</animation>
		</control>

        ";
                if (pictureBox109.Image != null) txt = txt + @"<control>
			<description>1004 button</description>
			<type>button</type>
			<id>1004</id>
			<posX>1036</posX>
			<posY>404</posY>
			<width>29</width>
			<height>25</height>
			<label>Up</label>
			<textXOff>3000</textXOff>
			<onleft>1004</onleft>
			<onright>1004</onright>
			<onup>109</onup>
			<ondown>104</ondown>
			<textureFocus>basichome_1004.png</textureFocus>
			<textureNoFocus>basichome_1004.png</textureNoFocus>
			<visible>control.hasfocus(104)</visible>
			<animation effect=""fade"" time=""500"">VisibleChange</animation>
			<animation effect=""zoom"" start=""70,70"" end=""100,100"" time=""500"">VisibleChange</animation>
			<animation effect=""slide"" end=""0,-6"" time=""500"">VisibleChange</animation>
		</control>

        ";

                txt = txt + @"<!-- ID 100 -->
		<control>
			<description>100 image</description>
			<type>image</type>
			<id>0</id>
			<posX>100</posX>
			<posY>428</posY>
			<width>239</width>
			<height>245</height>
			<texture>basichome_100_nofocus.png</texture>
		</control>
		<control>
			<description>100 hover image</description>
			<type>image</type>
			<id>0</id>
			<posX>100</posX>
			<posY>428</posY>
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
			<id>0</id>
			<posX>0</posX>
			<posY>630</posY>
			<width>1280</width>
			<label>" + SecurityElement.Escape(textBox100.Text) + @"</label>
			<font>font40</font>
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
			<posY>428</posY>
			<width>241</width>
			<height>245</height>
			<label>" + SecurityElement.Escape(textBox100.Text) + @"</label>
			<textXOff>3000</textXOff>
			<hyperlink>" + SecurityElement.Escape(textBoxid100.Text) + @"</hyperlink>
			<onleft>104</onleft>
			<onright>101</onright>
			";
                if (comboBox105.SelectedItem.ToString() != findPluginName(0)) txt = txt + @"<onup>105</onup>";
                if (comboBox105.SelectedItem.ToString() == findPluginName(0)) txt = txt + @"<onup>18</onup>";
                txt = txt + @"
			<ondown>1111</ondown>
			<textureFocus>-</textureFocus>
			<textureNoFocus>-</textureNoFocus>
		</control>

        
        <!-- ID 101 -->
		<control>
			<description>101 image</description>
			<type>image</type>
			<id>0</id>
			<posX>336</posX>
			<posY>440</posY>
			<width>209</width>
			<height>214</height>
			<texture>basichome_101_nofocus.png</texture>
		</control>
		<control>
			<description>101 hover image</description>
			<type>image</type>
			<id>0</id>
			<posX>336</posX>
			<posY>440</posY>
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
			<posY>630</posY>
			<width>1280</width>
			<label>" + SecurityElement.Escape(textBox101.Text) + @"</label>
			<font>font40</font>
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
			<posY>440</posY>
			<width>211</width>
			<height>215</height>
			<label>" + SecurityElement.Escape(textBox101.Text) + @"</label>
			<textXOff>3000</textXOff>
			<hyperlink>" + SecurityElement.Escape(textBoxid101.Text) + @"</hyperlink>
			<onleft>100</onleft>
			<onright>102</onright>
			";
                if (comboBox106.SelectedItem.ToString() != findPluginName(0)) txt = txt + @"<onup>106</onup>";
                if (comboBox106.SelectedItem.ToString() == findPluginName(0)) txt = txt + @"<onup>18</onup>";
                txt = txt + @"
			<ondown>1111</ondown>
			<textureFocus>-</textureFocus>
			<textureNoFocus>-</textureNoFocus>
		</control>


		<!-- ID 102 -->
		<control>
			<description>102 image</description>
			<type>image</type>
			<id>0</id>
			<posX>542</posX>
			<posY>444</posY>
			<width>196</width>
			<height>205</height>
			<texture>basichome_102_nofocus.png</texture>
		</control>
		<control>
			<description>102 hover image</description>
			<type>image</type>
			<id>0</id>
			<posX>542</posX>
			<posY>444</posY>
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
			<posY>630</posY>
			<width>1280</width>
			<label>" + SecurityElement.Escape(textBox102.Text) + @"</label>
			<font>font40</font>
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
			<posY>444</posY>
			<width>198</width>
			<height>205</height>
			<label>" + SecurityElement.Escape(textBox102.Text) + @"</label>
			<textXOff>3000</textXOff>
			<hyperlink>" + SecurityElement.Escape(textBoxid102.Text) + @"</hyperlink>
			<onleft>101</onleft>
			<onright>103</onright>
			";
                if (comboBox107.SelectedItem.ToString() != findPluginName(0)) txt = txt + @"<onup>107</onup>";
                if (comboBox107.SelectedItem.ToString() == findPluginName(0)) txt = txt + @"<onup>18</onup>";
                txt = txt + @"
			<ondown>1111</ondown>
			<textureFocus>-</textureFocus>
			<textureNoFocus>-</textureNoFocus>
		</control>


		<!-- ID 103 -->
		<control>
			<description>103 image</description>
			<type>image</type>
			<id>0</id>
			<posX>736</posX>
			<posY>440</posY>
			<width>209</width>
			<height>215</height>
			<texture>basichome_103_nofocus.png</texture>
		</control>
		<control>
			<description>103 hover image</description>
			<type>image</type>
			<id>0</id>
			<posX>736</posX>
			<posY>440</posY>
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
			<posY>630</posY>
			<width>1280</width>
			<label>" + SecurityElement.Escape(textBox103.Text) + @"</label>
			<font>font40</font> 
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
			<posY>440</posY>
			<width>210</width>
			<height>215</height>
			<label>" + SecurityElement.Escape(textBox103.Text) + @"</label>
			<textXOff>3000</textXOff>
			<hyperlink>" + SecurityElement.Escape(textBoxid103.Text) + @"</hyperlink>
			<onleft>102</onleft>
			<onright>104</onright>
			";
                if (comboBox108.SelectedItem.ToString() != findPluginName(0)) txt = txt + @"<onup>108</onup>";
                if (comboBox108.SelectedItem.ToString() == findPluginName(0)) txt = txt + @"<onup>18</onup>";
                txt = txt + @"
			<ondown>1111</ondown>
			<textureFocus>-</textureFocus>
			<textureNoFocus>-</textureNoFocus>
		</control>



		<!-- ID 104 -->
		<control>
			<description>104 image</description>
			<type>image</type>
			<id>0</id>
			<posX>941</posX>
			<posY>428</posY>
			<width>239</width>
			<height>242</height>
			<texture>basichome_104_nofocus.png</texture>
		</control>
		<control>
			<description>104 hover image</description>
			<type>image</type>
			<id>0</id>
			<posX>941</posX>
			<posY>428</posY>
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
			<posY>630</posY>
			<width>1280</width>
			<label>" + SecurityElement.Escape(textBox104.Text) + @"</label>
			<font>font40</font>
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
			<posY>428</posY>
			<width>241</width>
			<height>242</height>
			<label>" + SecurityElement.Escape(textBox104.Text) + @"</label>
			<textXOff>3000</textXOff>
			<hyperlink>" + SecurityElement.Escape(textBoxid104.Text) + @"</hyperlink>
			<onleft>103</onleft>
			<onright>100</onright>
			";
                if (comboBox109.SelectedItem.ToString() != findPluginName(0)) txt = txt + @"<onup>109</onup>";
                if (comboBox109.SelectedItem.ToString() == findPluginName(0)) txt = txt + @"<onup>18</onup>";
                txt = txt + @"
			<ondown>1111</ondown>
			<textureFocus>-</textureFocus>
			<textureNoFocus>-</textureNoFocus>
		</control>

		";

                if (comboBox105.SelectedItem.ToString() != findPluginName(0))
                {
                    txt = txt + @"<!-- ID 105 -->
		<control>
			<description>105 image</description>
			<type>image</type>
			<id>0</id>
			<posX>114</posX>
			<posY>261</posY>
			<width>232</width>
			<height>183</height>
			<texture>basichome_105_nofocus.png</texture>
			<visible>control.hasfocus(1000)|control.hasfocus(105)|control.hasfocus(110)</visible>
			<animation effect=""fade"" time=""500"">VisibleChange</animation>
		</control>
		<control>
			<description>105 hover image</description>
			<type>image</type>
			<id>0</id>
			<posX>114</posX>
			<posY>261</posY>
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
			<posY>630</posY>
			<width>1280</width>
			<label>" + SecurityElement.Escape(textBox105.Text) + @"</label>
			<font>font40</font>
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
			<posY>261</posY>
			<width>234</width>
			<height>184</height>
			<label>" + SecurityElement.Escape(textBox105.Text) + @"</label>
			<textXOff>3000</textXOff>
			<hyperlink>" + SecurityElement.Escape(textBoxid105.Text) + @"</hyperlink>
			<onleft>" + findButtonLeft("105") + @"</onleft>
			<onright>" + findButtonRight("105") + @"</onright>
            ";
                    if (comboBox110.SelectedItem.ToString() != findPluginName(0)) txt = txt + @"<onup>110</onup>";
                    if (comboBox110.SelectedItem.ToString() == findPluginName(0)) txt = txt + @"<onup>18</onup>";
                    txt = txt + @"
            <ondown>100</ondown>
			<textureFocus>-</textureFocus>
			<textureNoFocus>-</textureNoFocus>
		</control>

        ";
                }


                if (comboBox106.SelectedItem.ToString() != findPluginName(0))
                {
                    txt = txt + @"<!-- ID 106 -->
		<control>
			<description>106 image</description>
			<type>image</type>
			<id>0</id>
			<posX>342</posX>
			<posY>300</posY>
			<width>205</width>
			<height>151</height>
			<texture>basichome_106_nofocus.png</texture>
			<visible>control.hasfocus(1001)|control.hasfocus(106)|control.hasfocus(111)</visible>
			<animation effect=""fade"" time=""500"">VisibleChange</animation>
		</control>
		<control>
			<description>106 hover image</description>
			<type>image</type>
			<id>0</id>
			<posX>342</posX>
			<posY>300</posY>
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
			<posY>630</posY>
			<width>1280</width>
			<label>" + SecurityElement.Escape(textBox106.Text) + @"</label>
			<font>font40</font>
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
			<posY>300</posY>
			<width>207</width>
			<height>152</height>
			<label>" + SecurityElement.Escape(textBox106.Text) + @"</label>
			<textXOff>3000</textXOff>
			<hyperlink>" + SecurityElement.Escape(textBoxid106.Text) + @"</hyperlink>
			<onleft>" + findButtonLeft("106") + @"</onleft>
			<onright>" + findButtonRight("106") + @"</onright>
			";
                    if (comboBox111.SelectedItem.ToString() != findPluginName(0)) txt = txt + @"<onup>111</onup>";
                    if (comboBox111.SelectedItem.ToString() == findPluginName(0)) txt = txt + @"<onup>18</onup>";
                    txt = txt + @"
			<ondown>101</ondown>
			<textureFocus>-</textureFocus>
			<textureNoFocus>-</textureNoFocus>
		</control>

        ";
                }


                if (comboBox107.SelectedItem.ToString() != findPluginName(0))
                {
                    txt = txt + @"<!-- ID 107 -->
		<control>
			<description>107 image</description>
			<type>image</type>
			<id>0</id>
			<posX>543</posX>
			<posY>316</posY>
			<width>194</width>
			<height>137</height>
			<texture>basichome_107_nofocus.png</texture>
			<visible>control.hasfocus(1002)|control.hasfocus(107)|control.hasfocus(112)</visible>
			<animation effect=""fade"" time=""500"">VisibleChange</animation>
		</control>
		<control>
			<description>107 hover image</description>
			<type>image</type>
			<id>0</id>
			<posX>543</posX>
			<posY>316</posY>
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
			<posY>630</posY>
			<width>1280</width>
			<label>" + SecurityElement.Escape(textBox107.Text) + @"</label>
			<font>font40</font>
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
			<posY>316</posY>
			<width>195</width>
			<height>138</height>
			<label>" + SecurityElement.Escape(textBox107.Text) + @"</label>
			<textXOff>3000</textXOff>
			<hyperlink>" + SecurityElement.Escape(textBoxid107.Text) + @"</hyperlink>
			<onleft>" + findButtonLeft("107") + @"</onleft>
			<onright>" + findButtonRight("107") + @"</onright>
			";
                    if (comboBox112.SelectedItem.ToString() != findPluginName(0)) txt = txt + @"<onup>112</onup>";
                    if (comboBox112.SelectedItem.ToString() == findPluginName(0)) txt = txt + @"<onup>18</onup>";
                    txt = txt + @"
			<ondown>102</ondown>
			<textureFocus>-</textureFocus>
			<textureNoFocus>-</textureNoFocus>
		</control>

        ";
                }


                if (comboBox108.SelectedItem.ToString() != findPluginName(0))
                {
                    txt = txt + @"<!-- ID 108 -->
		<control>
			<description>108 image</description>
			<type>image</type>
			<id>0</id>
			<posX>733</posX>
			<posY>300</posY>
			<width>205</width>
			<height>151</height>
			<texture>basichome_108_nofocus.png</texture>
			<visible>control.hasfocus(1003)|control.hasfocus(108)|control.hasfocus(113)</visible>
			<animation effect=""fade"" time=""500"">VisibleChange</animation>
		</control>
		<control>
			<description>108 hover image</description>
			<type>image</type>
			<id>0</id>
			<posX>733</posX>
			<posY>300</posY>
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
			<posY>630</posY>
			<width>1280</width>
			<label>" + SecurityElement.Escape(textBox108.Text) + @"</label>
			<font>font40</font>
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
			<posY>300</posY>
			<width>206</width>
			<height>152</height>
			<label>" + SecurityElement.Escape(textBox108.Text) + @"</label>
			<textXOff>3000</textXOff>
			<hyperlink>" + SecurityElement.Escape(textBoxid108.Text) + @"</hyperlink>
			<onleft>" + findButtonLeft("108") + @"</onleft>
			<onright>" + findButtonRight("108") + @"</onright>
			";
                    if (comboBox113.SelectedItem.ToString() != findPluginName(0)) txt = txt + @"<onup>113</onup>";
                    if (comboBox113.SelectedItem.ToString() == findPluginName(0)) txt = txt + @"<onup>18</onup>";
                    txt = txt + @"
			<ondown>103</ondown>
			<textureFocus>-</textureFocus>
			<textureNoFocus>-</textureNoFocus>
		</control>

        ";
                }



                if (comboBox109.SelectedItem.ToString() != findPluginName(0))
                {
                    txt = txt + @"<!-- ID 109 -->
		<control>
			<description>109 image</description>
			<type>image</type>
			<id>0</id>
			<posX>935</posX>
			<posY>261</posY>
			<width>232</width>
			<height>183</height>
			<texture>basichome_109_nofocus.png</texture>
			<visible>control.hasfocus(1004)|control.hasfocus(109)|control.hasfocus(114)</visible>
			<animation effect=""fade"" time=""500"">VisibleChange</animation>
		</control>
		<control>
			<description>109 hover image</description>
			<type>image</type>
			<id>0</id>
			<posX>935</posX>
			<posY>261</posY>
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
			<posY>630</posY>
			<width>1280</width>
			<label>" + SecurityElement.Escape(textBox109.Text) + @"</label>
			<font>font40</font>
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
			<posY>261</posY>
			<width>234</width>
			<height>184</height>
			<label>" + SecurityElement.Escape(textBox109.Text) + @"</label>
			<textXOff>3000</textXOff>
			<hyperlink>" + SecurityElement.Escape(textBoxid109.Text) + @"</hyperlink>
			<onleft>" + findButtonLeft("109") + @"</onleft>
			<onright>" + findButtonRight("109") + @"</onright>
			";
                    if (comboBox114.SelectedItem.ToString() != findPluginName(0)) txt = txt + @"<onup>114</onup>";
                    if (comboBox114.SelectedItem.ToString() == findPluginName(0)) txt = txt + @"<onup>18</onup>";
                    txt = txt + @"
			<ondown>104</ondown>
			<textureFocus>-</textureFocus>
			<textureNoFocus>-</textureNoFocus>
		</control>

        ";
                }



                if (comboBox110.SelectedItem.ToString() != findPluginName(0)) txt = txt + @"<!-- ID 110 -->
		<control>
			<description>110 image</description>
			<type>image</type>
			<id>0</id>
			<posX>126</posX>
			<posY>106</posY>
			<width>226</width>
			<height>196</height>
			<texture>basichome_110_nofocus.png</texture>
			<visible>control.hasfocus(1000)|control.hasfocus(105)|control.hasfocus(110)</visible>
			<animation effect=""fade"" time=""500"">VisibleChange</animation>
		</control>
		<control>
			<description>110 hover image</description>
			<type>image</type>
			<id>0</id>
			<posX>126</posX>
			<posY>106</posY>
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
			<posY>630</posY>
			<width>1280</width>
			<label>" + SecurityElement.Escape(textBox110.Text) + @"</label>
			<font>font40</font>
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
			<posY>106</posY>
			<width>227</width>
			<height>197</height>
			<label>" + SecurityElement.Escape(textBox110.Text) + @"</label>
			<textXOff>3000</textXOff>
			<hyperlink>" + SecurityElement.Escape(textBoxid110.Text) + @"</hyperlink>
			<onleft>" + findButtonLeft("110") + @"</onleft>
			<onright>" + findButtonRight("110") + @"</onright>
			<onup>18</onup>
			<ondown>105</ondown>
			<textureFocus>-</textureFocus>
			<textureNoFocus>-</textureNoFocus>
		</control>

        ";



                if (comboBox111.SelectedItem.ToString() != findPluginName(0)) txt = txt + @"<!-- ID 111 -->
		<control>
			<description>111 image</description>
			<type>image</type>
			<id>0</id>
			<posX>348</posX>
			<posY>168</posY>
			<width>201</width>
			<height>154</height>
			<texture>basichome_111_nofocus.png</texture>
			<visible>control.hasfocus(1001)|control.hasfocus(106)|control.hasfocus(111)</visible>
			<animation effect=""fade"" time=""500"">VisibleChange</animation>
		</control>
		<control>
			<description>111 hover image</description>
			<type>image</type>
			<id>0</id>
			<posX>348</posX>
			<posY>168</posY>
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
			<posY>630</posY>
			<width>1280</width>
			<label>" + SecurityElement.Escape(textBox111.Text) + @"</label>
			<font>font40</font>
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
			<posY>168</posY>
			<width>204</width>
			<height>158</height>
			<label>" + SecurityElement.Escape(textBox111.Text) + @"</label>
			<textXOff>3000</textXOff>
			<hyperlink>" + SecurityElement.Escape(textBoxid111.Text) + @"</hyperlink>
			<onleft>" + findButtonLeft("111") + @"</onleft>
			<onright>" + findButtonRight("111") + @"</onright>
			<onup>18</onup>
			<ondown>106</ondown>
			<textureFocus>-</textureFocus>
			<textureNoFocus>-</textureNoFocus>
		</control>

        ";



                if (comboBox112.SelectedItem.ToString() != findPluginName(0)) txt = txt + @"<!-- ID 112 -->
		<control>
			<description>112 image</description>
			<type>image</type>
			<id>0</id>
			<posX>545</posX>
			<posY>192</posY>
			<width>190</width>
			<height>133</height>
			<texture>basichome_112_nofocus.png</texture>
			<visible>control.hasfocus(1002)|control.hasfocus(107)|control.hasfocus(112)</visible>
			<animation effect=""fade"" time=""500"">VisibleChange</animation>
		</control>
		<control>
			<description>112 hover image</description>
			<type>image</type>
			<id>0</id>
			<posX>545</posX>
			<posY>192</posY>
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
			<posY>630</posY>
			<width>1280</width>
			<label>" + SecurityElement.Escape(textBox112.Text) + @"</label>
			<font>font40</font>
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
			<posY>192</posY>
			<width>192</width>
			<height>134</height>
			<label>" + SecurityElement.Escape(textBox112.Text) + @"</label>
			<textXOff>3000</textXOff>
			<hyperlink>" + SecurityElement.Escape(textBoxid112.Text) + @"</hyperlink>
			<onleft>" + findButtonLeft("112") + @"</onleft>
			<onright>" + findButtonRight("112") + @"</onright>
			<onup>18</onup>
			<ondown>107</ondown>
			<textureFocus>-</textureFocus>
			<textureNoFocus>-</textureNoFocus>
		</control>

        ";



                if (comboBox113.SelectedItem.ToString() != findPluginName(0)) txt = txt + @"<!-- ID 113 -->
		<control>
			<description>113 image</description>
			<type>image</type>
			<id>0</id>
			<posX>731</posX>
			<posY>168</posY>
			<width>201</width>
			<height>154</height>
			<texture>basichome_113_nofocus.png</texture>
			<visible>control.hasfocus(1003)|control.hasfocus(108)|control.hasfocus(113)</visible>
			<animation effect=""fade"" time=""500"">VisibleChange</animation>
		</control>
		<control>
			<description>113 hover image</description>
			<type>image</type>
			<id>0</id>
			<posX>731</posX>
			<posY>168</posY>
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
			<posY>630</posY>
			<width>1280</width>
			<label>" + SecurityElement.Escape(textBox113.Text) + @"</label>
			<font>font40</font>
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
			<posY>168</posY>
			<width>203</width>
			<height>155</height>
			<label>" + SecurityElement.Escape(textBox113.Text) + @"</label>
			<textXOff>3000</textXOff>
			<hyperlink>" + SecurityElement.Escape(textBoxid113.Text) + @"</hyperlink>
			<onleft>" + findButtonLeft("113") + @"</onleft>
			<onright>" + findButtonRight("113") + @"</onright>
			<onup>18</onup>
			<ondown>108</ondown>
			<textureFocus>-</textureFocus>
			<textureNoFocus>-</textureNoFocus>
		</control>

        ";



                if (comboBox114.SelectedItem.ToString() != findPluginName(0)) txt = txt + @"<!-- ID 114 -->
		<control>
			<description>114 image</description>
			<type>image</type>
			<id>0</id>
			<posX>929</posX>
			<posY>106</posY>
			<width>225</width>
			<height>196</height>
			<texture>basichome_114_nofocus.png</texture>
			<visible>control.hasfocus(1004)|control.hasfocus(109)|control.hasfocus(114)</visible>
			<animation effect=""fade"" time=""500"">VisibleChange</animation>
		</control>
		<control>
			<description>114 hover image</description>
			<type>image</type>
			<id>0</id>
			<posX>929</posX>
			<posY>106</posY>
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
			<posY>630</posY>
			<width>1280</width>
			<label>" + SecurityElement.Escape(textBox114.Text) + @"</label>
			<font>font40</font>
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
			<posY>106</posY>
			<width>227</width>
			<height>197</height>
			<label>" + SecurityElement.Escape(textBox114.Text) + @"</label>
			<textXOff>3000</textXOff>
			<hyperlink>" + SecurityElement.Escape(textBoxid114.Text) + @"</hyperlink>
			<onleft>" + findButtonLeft("114") + @"</onleft>
			<onright>" + findButtonRight("114") + @"</onright>
			<onup>18</onup>
			<ondown>109</ondown>
			<textureFocus>-</textureFocus>
			<textureNoFocus>-</textureNoFocus>
		</control>

        ";

                txt = txt + @"<!-- SUBTITLES -->";

                if (weather_button != "") txt = txt
                 + @"
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
			<label>Recently added:     #infoservice.recentlyAdded.series1.title     Season #infoservice.recentlyAdded.series1.season     Episode #infoservice.recentlyAdded.series1.episodenumber     #infoservice.recentlyAdded.series1.episodetitle</label>
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
			<label>Recently added:     #infoservice.recentlyAdded.movie1.title</label>
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
                    tw.Write(txt);
                    tw.Close();
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
        ";

                if (comboBox105.SelectedItem.ToString() != findPluginName(0)) txt = txt + @"<control>
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
        ";

                if (comboBox106.SelectedItem.ToString() != findPluginName(0)) txt = txt + @"<control>
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

                if (comboBox107.SelectedItem.ToString() != findPluginName(0)) txt = txt + @"<control>
			<description>107 image</description>
			<type>image</type>
			<id>0</id>
			<posX>0</posX>
			<posY>0</posY>
			<width>1280</width>
			<height>720</height>
			<texture>" + SecurityElement.Escape(textBoxhover107.Text) + @".png</texture>
			<visible>control.hasfocus(107)</visible>
			<animation effect=""fade"" time=""250"">visible</animation>
		</control>
        ";

                if (comboBox108.SelectedItem.ToString() != findPluginName(0)) txt = txt + @"<control>
			<description>108 image</description>
			<type>image</type>
			<id>0</id>
			<posX>0</posX>
			<posY>0</posY>
			<width>1280</width>
			<height>720</height>
			<texture>" + SecurityElement.Escape(textBoxhover108.Text) + @".png</texture>
			<visible>control.hasfocus(108)</visible>
			<animation effect=""fade"" time=""250"">visible</animation>
		</control>
        ";

                if (comboBox109.SelectedItem.ToString() != findPluginName(0)) txt = txt + @"<control>
			<description>109 image</description>
			<type>image</type>
			<id>0</id>
			<posX>0</posX>
			<posY>0</posY>
			<width>1280</width>
			<height>720</height>
			<texture>" + SecurityElement.Escape(textBoxhover109.Text) + @".png</texture>
			<visible>control.hasfocus(109)</visible>
			<animation effect=""fade"" time=""250"">visible</animation>
		</control>
        ";

                if (comboBox110.SelectedItem.ToString() != findPluginName(0)) txt = txt + @"<control>
			<description>110 image</description>
			<type>image</type>
			<id>0</id>
			<posX>0</posX>
			<posY>0</posY>
			<width>1280</width>
			<height>720</height>
			<texture>" + SecurityElement.Escape(textBoxhover110.Text) + @".png</texture>
			<visible>control.hasfocus(110)</visible>
			<animation effect=""fade"" time=""250"">visible</animation>
		</control>
        ";

                if (comboBox111.SelectedItem.ToString() != findPluginName(0)) txt = txt + @"<control>
			<description>111 image</description>
			<type>image</type>
			<id>0</id>
			<posX>0</posX>
			<posY>0</posY>
			<width>1280</width>
			<height>720</height>
			<texture>" + SecurityElement.Escape(textBoxhover111.Text) + @".png</texture>
			<visible>control.hasfocus(111)</visible>
			<animation effect=""fade"" time=""250"">visible</animation>
		</control>
        ";

                if (comboBox112.SelectedItem.ToString() != findPluginName(0)) txt = txt + @"<control>
			<description>112 image</description>
			<type>image</type>
			<id>0</id>
			<posX>0</posX>
			<posY>0</posY>
			<width>1280</width>
			<height>720</height>
			<texture>" + SecurityElement.Escape(textBoxhover112.Text) + @".png</texture>
			<visible>control.hasfocus(112)</visible>
			<animation effect=""fade"" time=""250"">visible</animation>
		</control>
        ";

                if (comboBox113.SelectedItem.ToString() != findPluginName(0)) txt = txt + @"<control>
			<description>113 image</description>
			<type>image</type>
			<id>0</id>
			<posX>0</posX>
			<posY>0</posY>
			<width>1280</width>
			<height>720</height>
			<texture>" + SecurityElement.Escape(textBoxhover113.Text) + @".png</texture>
			<visible>control.hasfocus(113)</visible>
			<animation effect=""fade"" time=""250"">visible</animation>
		</control>
        ";

                if (comboBox114.SelectedItem.ToString() != findPluginName(0)) txt = txt + @"<control>
			<description>114 image</description>
			<type>image</type>
			<id>0</id>
			<posX>0</posX>
			<posY>0</posY>
			<width>1280</width>
			<height>720</height>
			<texture>" + SecurityElement.Escape(textBoxhover114.Text) + @".png</texture>
			<visible>control.hasfocus(114)</visible>
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
			<texture>#infoservice.recentlyAdded.series1.fanart</texture>
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

                    tw.Write(txt);
                    tw.Close();
                    toolStripStatusLabel1.Text = "XML File Saved Succesfully";
                    //MessageBox.Show("File Saved!");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not save file to disk. Original error: " + ex.Message);
                }


            }
        }


        public void saveSettingsImage(Bitmap img, String name)
        {
            try
            {
                ImageCodecInfo jgpEncoder = Functions.GetEncoder(ImageFormat.Jpeg);

                System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;
                EncoderParameters myEncoderParameters = new EncoderParameters(1);

                EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 90L);
                myEncoderParameters.Param[0] = myEncoderParameter;

                FileStream fs = new FileStream(System.IO.Path.Combine(Application.StartupPath, name), FileMode.Create, FileAccess.Write);
                img.Save(fs, jgpEncoder, myEncoderParameters);
                fs.Close();
                fs.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Could not save file from disk. Original error: " + ex.Message);
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
                if (textBoxid105.Text == "") textWriter.WriteString("0");
                if (textBoxid105.Text != "") textWriter.WriteString(SecurityElement.Escape(textBoxid105.Text));
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
                if (textBoxid106.Text == "") textWriter.WriteString("0");
                if (textBoxid106.Text != "") textWriter.WriteString(SecurityElement.Escape(textBoxid106.Text));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("hover", "");
                textWriter.WriteString(SecurityElement.Escape(textBoxhover106.Text));
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
                if (textBoxid107.Text == "") textWriter.WriteString("0");
                if (textBoxid107.Text != "") textWriter.WriteString(SecurityElement.Escape(textBoxid107.Text));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("hover", "");
                textWriter.WriteString(SecurityElement.Escape(textBoxhover107.Text));
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
                if (textBoxid108.Text == "") textWriter.WriteString("0");
                if (textBoxid108.Text != "") textWriter.WriteString(SecurityElement.Escape(textBoxid108.Text));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("hover", "");
                textWriter.WriteString(SecurityElement.Escape(textBoxhover108.Text));
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
                if (textBoxid109.Text == "") textWriter.WriteString("0");
                if (textBoxid109.Text != "") textWriter.WriteString(SecurityElement.Escape(textBoxid109.Text));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("hover", "");
                textWriter.WriteString(SecurityElement.Escape(textBoxhover109.Text));
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
                if (textBoxid110.Text == "") textWriter.WriteString("0");
                if (textBoxid110.Text != "") textWriter.WriteString(SecurityElement.Escape(textBoxid110.Text));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("hover", "");
                textWriter.WriteString(SecurityElement.Escape(textBoxhover110.Text));
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
                if (textBoxid111.Text == "") textWriter.WriteString("0");
                if (textBoxid111.Text != "") textWriter.WriteString(SecurityElement.Escape(textBoxid111.Text));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("hover", "");
                textWriter.WriteString(SecurityElement.Escape(textBoxhover111.Text));
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
                if (textBoxid112.Text == "") textWriter.WriteString("0");
                if (textBoxid112.Text != "") textWriter.WriteString(SecurityElement.Escape(textBoxid112.Text));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("hover", "");
                textWriter.WriteString(SecurityElement.Escape(textBoxhover112.Text));
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
                if (textBoxid113.Text == "") textWriter.WriteString("0");
                if (textBoxid113.Text != "") textWriter.WriteString(SecurityElement.Escape(textBoxid113.Text));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("hover", "");
                textWriter.WriteString(SecurityElement.Escape(textBoxhover113.Text));
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
                if (textBoxid114.Text == "") textWriter.WriteString("0");
                if (textBoxid114.Text != "") textWriter.WriteString(SecurityElement.Escape(textBoxid114.Text));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("hover", "");
                textWriter.WriteString(SecurityElement.Escape(textBoxhover114.Text));
                textWriter.WriteEndElement();
                textWriter.WriteEndElement();

                textWriter.WriteStartElement("button");
                textWriter.WriteStartElement("Id", "");
                textWriter.WriteString("0");
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("name", "");
                textWriter.WriteString("Saving Directory");
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("plugin", "");
                textWriter.WriteString(BlackGlassDirClass.Path);
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("hover", "");
                textWriter.WriteString("");
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

        private void buttonEmpty105_Click(object sender, EventArgs e)
        {
            if (pictureBox105.Image != null) pictureBox105.Image.Dispose();
            pictureBox105.Image = null;
            pictureBox105.Invalidate();
            comboBox105.SelectedItem = findPluginName(0);
            if (File.Exists(Application.StartupPath + "\\105.jpg")) File.Delete(Application.StartupPath + "\\105.jpg");
        }

        private void buttonEmpty106_Click(object sender, EventArgs e)
        {
            if (pictureBox106.Image != null) pictureBox106.Image.Dispose();
            pictureBox106.Image = null;
            pictureBox106.Invalidate();
            comboBox106.SelectedItem = findPluginName(0);
            if (File.Exists(Application.StartupPath + "\\106.jpg")) File.Delete(Application.StartupPath + "\\106.jpg");
        }

        private void buttonEmpty107_Click(object sender, EventArgs e)
        {
            if (pictureBox107.Image != null) pictureBox107.Image.Dispose();
            pictureBox107.Image = null;
            pictureBox107.Invalidate();
            comboBox107.SelectedItem = findPluginName(0);
            if (File.Exists(Application.StartupPath + "\\107.jpg")) File.Delete(Application.StartupPath + "\\107.jpg");
        }

        private void buttonEmpty108_Click(object sender, EventArgs e)
        {
            if (pictureBox108.Image != null) pictureBox108.Image.Dispose();
            pictureBox108.Image = null;
            pictureBox108.Invalidate();
            comboBox108.SelectedItem = findPluginName(0);
            if (File.Exists(Application.StartupPath + "\\108.jpg")) File.Delete(Application.StartupPath + "\\108.jpg");
        }

        private void buttonEmpty109_Click(object sender, EventArgs e)
        {
            if (pictureBox109.Image != null) pictureBox109.Image.Dispose();
            pictureBox109.Image = null;
            pictureBox109.Invalidate();
            comboBox109.SelectedItem = findPluginName(0);
            if (File.Exists(Application.StartupPath + "\\109.jpg")) File.Delete(Application.StartupPath + "\\109.jpg");
        }

        private void buttonEmpty110_Click(object sender, EventArgs e)
        {
            if (pictureBox110.Image != null) pictureBox110.Image.Dispose();
            pictureBox110.Image = null;
            pictureBox110.Invalidate();
            comboBox110.SelectedItem = findPluginName(0);
            if (File.Exists(Application.StartupPath + "\\110.jpg")) File.Delete(Application.StartupPath + "\\110.jpg");
        }

        private void buttonEmpty111_Click(object sender, EventArgs e)
        {
            if (pictureBox111.Image != null) pictureBox111.Image.Dispose();
            pictureBox111.Image = null;
            pictureBox111.Invalidate();
            comboBox111.SelectedItem = findPluginName(0);
            if (File.Exists(Application.StartupPath + "\\111.jpg")) File.Delete(Application.StartupPath + "\\111.jpg");
        }

        private void buttonEmpty112_Click(object sender, EventArgs e)
        {
            if (pictureBox112.Image != null) pictureBox112.Image.Dispose();
            pictureBox112.Image = null;
            pictureBox112.Invalidate();
            comboBox112.SelectedItem = findPluginName(0);
            if (File.Exists(Application.StartupPath + "\\112.jpg")) File.Delete(Application.StartupPath + "\\112.jpg");
        }

        private void buttonEmpty113_Click(object sender, EventArgs e)
        {
            if (pictureBox113.Image != null) pictureBox113.Image.Dispose();
            pictureBox113.Image = null;
            pictureBox113.Invalidate();
            comboBox113.SelectedItem = findPluginName(0);
            if (File.Exists(Application.StartupPath + "\\113.jpg")) File.Delete(Application.StartupPath + "\\113.jpg");
        }

        private void buttonEmpty114_Click(object sender, EventArgs e)
        {
            if (pictureBox114.Image != null) pictureBox114.Image.Dispose();
            pictureBox114.Image = null;
            pictureBox114.Invalidate();
            comboBox114.SelectedItem = findPluginName(0);
            if (File.Exists(Application.StartupPath + "\\114.jpg")) File.Delete(Application.StartupPath + "\\114.jpg");
        }

        private int checkColumns()
        {

            int errors = 0;

            if (comboBox105.SelectedItem.ToString() == findPluginName(0) && comboBox110.SelectedItem.ToString() != findPluginName(0)) { MessageBox.Show("Error: Button 105 cannot be empty!"); errors++; }
            if (comboBox106.SelectedItem.ToString() == findPluginName(0) && comboBox111.SelectedItem.ToString() != findPluginName(0)) { MessageBox.Show("Error: Button 106 cannot be empty!"); errors++; }
            if (comboBox107.SelectedItem.ToString() == findPluginName(0) && comboBox112.SelectedItem.ToString() != findPluginName(0)) { MessageBox.Show("Error: Button 107 cannot be empty!"); errors++; }
            if (comboBox108.SelectedItem.ToString() == findPluginName(0) && comboBox113.SelectedItem.ToString() != findPluginName(0)) { MessageBox.Show("Error: Button 108 cannot be empty!"); errors++; }
            if (comboBox109.SelectedItem.ToString() == findPluginName(0) && comboBox114.SelectedItem.ToString() != findPluginName(0)) { MessageBox.Show("Error: Button 109 cannot be empty!"); errors++; }

            return errors;
        }

        private int checkEmptyCombos()
        {
            int errors = 0;

            if (comboBox105.SelectedItem.ToString() == findPluginName(0) && pictureBox105.Image != null) { MessageBox.Show("Error: Button 105 has no associated plugin!"); errors++; }
            if (comboBox106.SelectedItem.ToString() == findPluginName(0) && pictureBox106.Image != null) { MessageBox.Show("Error: Button 106 has no associated plugin!"); errors++; }
            if (comboBox107.SelectedItem.ToString() == findPluginName(0) && pictureBox107.Image != null) { MessageBox.Show("Error: Button 107 has no associated plugin!"); errors++; }
            if (comboBox108.SelectedItem.ToString() == findPluginName(0) && pictureBox108.Image != null) { MessageBox.Show("Error: Button 108 has no associated plugin!"); errors++; }
            if (comboBox109.SelectedItem.ToString() == findPluginName(0) && pictureBox109.Image != null) { MessageBox.Show("Error: Button 109 has no associated plugin!"); errors++; }
            if (comboBox110.SelectedItem.ToString() == findPluginName(0) && pictureBox110.Image != null) { MessageBox.Show("Error: Button 110 has no associated plugin!"); errors++; }
            if (comboBox111.SelectedItem.ToString() == findPluginName(0) && pictureBox111.Image != null) { MessageBox.Show("Error: Button 111 has no associated plugin!"); errors++; }
            if (comboBox112.SelectedItem.ToString() == findPluginName(0) && pictureBox112.Image != null) { MessageBox.Show("Error: Button 112 has no associated plugin!"); errors++; }
            if (comboBox113.SelectedItem.ToString() == findPluginName(0) && pictureBox113.Image != null) { MessageBox.Show("Error: Button 113 has no associated plugin!"); errors++; }
            if (comboBox114.SelectedItem.ToString() == findPluginName(0) && pictureBox114.Image != null) { MessageBox.Show("Error: Button 114 has no associated plugin!"); errors++; }

            return errors;
        }

        private int checkEmptyPictures()
        {
            int errors = 0;

            if (comboBox105.SelectedItem.ToString() != findPluginName(0) && pictureBox105.Image == null) { MessageBox.Show("Error: Button 105 has no picture!"); errors++; }
            if (comboBox106.SelectedItem.ToString() != findPluginName(0) && pictureBox106.Image == null) { MessageBox.Show("Error: Button 106 has no picture!"); errors++; }
            if (comboBox107.SelectedItem.ToString() != findPluginName(0) && pictureBox107.Image == null) { MessageBox.Show("Error: Button 107 has no picture!"); errors++; }
            if (comboBox108.SelectedItem.ToString() != findPluginName(0) && pictureBox108.Image == null) { MessageBox.Show("Error: Button 108 has no picture!"); errors++; }
            if (comboBox109.SelectedItem.ToString() != findPluginName(0) && pictureBox109.Image == null) { MessageBox.Show("Error: Button 109 has no picture!"); errors++; }
            if (comboBox110.SelectedItem.ToString() != findPluginName(0) && pictureBox110.Image == null) { MessageBox.Show("Error: Button 110 has no picture!"); errors++; }
            if (comboBox111.SelectedItem.ToString() != findPluginName(0) && pictureBox111.Image == null) { MessageBox.Show("Error: Button 111 has no picture!"); errors++; }
            if (comboBox112.SelectedItem.ToString() != findPluginName(0) && pictureBox112.Image == null) { MessageBox.Show("Error: Button 112 has no picture!"); errors++; }
            if (comboBox113.SelectedItem.ToString() != findPluginName(0) && pictureBox113.Image == null) { MessageBox.Show("Error: Button 113 has no picture!"); errors++; }
            if (comboBox114.SelectedItem.ToString() != findPluginName(0) && pictureBox114.Image == null) { MessageBox.Show("Error: Button 114 has no picture!"); errors++; }

            return errors;
        }

        private String findButtonLeft(String id) { 
        
            String ButtonId = id;

            switch (id) { 
            
                case "105":
                    ButtonId = "105";
                    if (comboBox106.SelectedItem.ToString() != findPluginName(0)) ButtonId = "106"; 
                    if (comboBox107.SelectedItem.ToString() != findPluginName(0)) ButtonId = "107";
                    if (comboBox108.SelectedItem.ToString() != findPluginName(0)) ButtonId = "108";
                    if (comboBox109.SelectedItem.ToString() != findPluginName(0)) ButtonId = "109";
                    break;

                case "106":
                    ButtonId = "106";
                    if (comboBox107.SelectedItem.ToString() != findPluginName(0)) ButtonId = "107";
                    if (comboBox108.SelectedItem.ToString() != findPluginName(0)) ButtonId = "108";
                    if (comboBox109.SelectedItem.ToString() != findPluginName(0)) ButtonId = "109";
                    if (comboBox105.SelectedItem.ToString() != findPluginName(0)) ButtonId = "105";
                    break;

                case "107":
                    ButtonId = "107";
                    if (comboBox108.SelectedItem.ToString() != findPluginName(0)) ButtonId = "108";
                    if (comboBox109.SelectedItem.ToString() != findPluginName(0)) ButtonId = "109";
                    if (comboBox105.SelectedItem.ToString() != findPluginName(0)) ButtonId = "105";
                    if (comboBox106.SelectedItem.ToString() != findPluginName(0)) ButtonId = "106";
                    break;

                case "108":
                    ButtonId = "108";
                    if (comboBox109.SelectedItem.ToString() != findPluginName(0)) ButtonId = "109";
                    if (comboBox105.SelectedItem.ToString() != findPluginName(0)) ButtonId = "105";
                    if (comboBox106.SelectedItem.ToString() != findPluginName(0)) ButtonId = "106";
                    if (comboBox107.SelectedItem.ToString() != findPluginName(0)) ButtonId = "107";
                    
                    break;

                case "109":
                    ButtonId = "109";
                    if (comboBox105.SelectedItem.ToString() != findPluginName(0)) ButtonId = "105";
                    if (comboBox106.SelectedItem.ToString() != findPluginName(0)) ButtonId = "106";
                    if (comboBox107.SelectedItem.ToString() != findPluginName(0)) ButtonId = "107";
                    if (comboBox108.SelectedItem.ToString() != findPluginName(0)) ButtonId = "108";
                    break;


                case "110":
                    ButtonId = "110";
                    if (comboBox111.SelectedItem.ToString() != findPluginName(0)) ButtonId = "111";
                    if (comboBox112.SelectedItem.ToString() != findPluginName(0)) ButtonId = "112";
                    if (comboBox113.SelectedItem.ToString() != findPluginName(0)) ButtonId = "113";
                    if (comboBox114.SelectedItem.ToString() != findPluginName(0)) ButtonId = "114";
                    break;

                case "111":
                    ButtonId = "111";
                    if (comboBox112.SelectedItem.ToString() != findPluginName(0)) ButtonId = "112";
                    if (comboBox113.SelectedItem.ToString() != findPluginName(0)) ButtonId = "113";
                    if (comboBox114.SelectedItem.ToString() != findPluginName(0)) ButtonId = "114";
                    if (comboBox110.SelectedItem.ToString() != findPluginName(0)) ButtonId = "110";
                    break;

                case "112":
                    ButtonId = "112";
                    if (comboBox113.SelectedItem.ToString() != findPluginName(0)) ButtonId = "113";
                    if (comboBox114.SelectedItem.ToString() != findPluginName(0)) ButtonId = "114";
                    if (comboBox110.SelectedItem.ToString() != findPluginName(0)) ButtonId = "110";
                    if (comboBox111.SelectedItem.ToString() != findPluginName(0)) ButtonId = "111";
                    break;

                case "113":
                    ButtonId = "113";
                    if (comboBox114.SelectedItem.ToString() != findPluginName(0)) ButtonId = "114";
                    if (comboBox110.SelectedItem.ToString() != findPluginName(0)) ButtonId = "110";
                    if (comboBox111.SelectedItem.ToString() != findPluginName(0)) ButtonId = "111";
                    if (comboBox112.SelectedItem.ToString() != findPluginName(0)) ButtonId = "112";
                    break;

                case "114":
                    ButtonId = "114";
                    if (comboBox110.SelectedItem.ToString() != findPluginName(0)) ButtonId = "110";
                    if (comboBox111.SelectedItem.ToString() != findPluginName(0)) ButtonId = "111";
                    if (comboBox112.SelectedItem.ToString() != findPluginName(0)) ButtonId = "112";
                    if (comboBox113.SelectedItem.ToString() != findPluginName(0)) ButtonId = "113";
                    break;
            }
            return ButtonId;
        }


        private String findButtonRight(String id)
        {

            String ButtonId = id;

            switch (id)
            {

                case "105":
                    ButtonId = "105";
                    if (comboBox109.SelectedItem.ToString() != findPluginName(0)) ButtonId = "109"; 
                    if (comboBox108.SelectedItem.ToString() != findPluginName(0)) ButtonId = "108";
                    if (comboBox107.SelectedItem.ToString() != findPluginName(0)) ButtonId = "107";
                    if (comboBox106.SelectedItem.ToString() != findPluginName(0)) ButtonId = "106";
                    break;

                case "106":
                    ButtonId = "106";
                    if (comboBox105.SelectedItem.ToString() != findPluginName(0)) ButtonId = "105";
                    if (comboBox109.SelectedItem.ToString() != findPluginName(0)) ButtonId = "109";
                    if (comboBox108.SelectedItem.ToString() != findPluginName(0)) ButtonId = "108";
                    if (comboBox107.SelectedItem.ToString() != findPluginName(0)) ButtonId = "107";
                    break;

                case "107":
                    ButtonId = "107";
                    if (comboBox106.SelectedItem.ToString() != findPluginName(0)) ButtonId = "106";
                    if (comboBox105.SelectedItem.ToString() != findPluginName(0)) ButtonId = "105";
                    if (comboBox109.SelectedItem.ToString() != findPluginName(0)) ButtonId = "109";
                    if (comboBox108.SelectedItem.ToString() != findPluginName(0)) ButtonId = "108";
                    break;

                case "108":
                    ButtonId = "108";
                    if (comboBox107.SelectedItem.ToString() != findPluginName(0)) ButtonId = "107";
                    if (comboBox106.SelectedItem.ToString() != findPluginName(0)) ButtonId = "106";
                    if (comboBox105.SelectedItem.ToString() != findPluginName(0)) ButtonId = "105";
                    if (comboBox109.SelectedItem.ToString() != findPluginName(0)) ButtonId = "109";

                    break;

                case "109":
                    ButtonId = "109";
                    if (comboBox108.SelectedItem.ToString() != findPluginName(0)) ButtonId = "108";
                    if (comboBox107.SelectedItem.ToString() != findPluginName(0)) ButtonId = "107";
                    if (comboBox106.SelectedItem.ToString() != findPluginName(0)) ButtonId = "106";
                    if (comboBox105.SelectedItem.ToString() != findPluginName(0)) ButtonId = "105";
                    break;


                case "110":
                    ButtonId = "110";
                    if (comboBox114.SelectedItem.ToString() != findPluginName(0)) ButtonId = "114";
                    if (comboBox113.SelectedItem.ToString() != findPluginName(0)) ButtonId = "113";
                    if (comboBox112.SelectedItem.ToString() != findPluginName(0)) ButtonId = "112"; 
                    if (comboBox111.SelectedItem.ToString() != findPluginName(0)) ButtonId = "111";
                    break;

                case "111":
                    ButtonId = "111";
                    if (comboBox110.SelectedItem.ToString() != findPluginName(0)) ButtonId = "110";
                    if (comboBox114.SelectedItem.ToString() != findPluginName(0)) ButtonId = "114";
                    if (comboBox113.SelectedItem.ToString() != findPluginName(0)) ButtonId = "113";
                    if (comboBox112.SelectedItem.ToString() != findPluginName(0)) ButtonId = "112";
                    break;

                case "112":
                    ButtonId = "112";
                    if (comboBox111.SelectedItem.ToString() != findPluginName(0)) ButtonId = "111";
                    if (comboBox110.SelectedItem.ToString() != findPluginName(0)) ButtonId = "110";
                    if (comboBox114.SelectedItem.ToString() != findPluginName(0)) ButtonId = "114";
                    if (comboBox113.SelectedItem.ToString() != findPluginName(0)) ButtonId = "113";
                    break;

                case "113":
                    ButtonId = "113";
                    if (comboBox112.SelectedItem.ToString() != findPluginName(0)) ButtonId = "112";
                    if (comboBox111.SelectedItem.ToString() != findPluginName(0)) ButtonId = "111";
                    if (comboBox110.SelectedItem.ToString() != findPluginName(0)) ButtonId = "110";
                    if (comboBox114.SelectedItem.ToString() != findPluginName(0)) ButtonId = "114";
                    break;

                case "114":
                    ButtonId = "114";
                    if (comboBox113.SelectedItem.ToString() != findPluginName(0)) ButtonId = "113";
                    if (comboBox112.SelectedItem.ToString() != findPluginName(0)) ButtonId = "112";
                    if (comboBox111.SelectedItem.ToString() != findPluginName(0)) ButtonId = "111";
                    if (comboBox110.SelectedItem.ToString() != findPluginName(0)) ButtonId = "110";
                    break;
            }
            return ButtonId;
        }

    }
    

}