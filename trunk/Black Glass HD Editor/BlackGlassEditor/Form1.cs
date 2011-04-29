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
using ImageHuer;

namespace BlackGlassEditor
{


    public partial class Form1 : Form
    {
        public List<MPplugin> plugins = new List<MPplugin>();

        public Form1()
        {
            InitializeComponent();

            string path = System.IO.Path.Combine(Application.StartupPath, "BG_plugins.xml");
            System.Xml.XmlDocument Plugins = new System.Xml.XmlDocument();

            if (File.Exists(path))
            {
                FileStream pREADER = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                Plugins.Load(pREADER);
            }
            else
            {
                try
                {
                    Plugins.Load("http://blackglass.googlecode.com/svn/trunk/Plugin%20List/BG_plugins.xml");
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not download plugin list from Internet. Please retry later.\n\nOriginal error: " + ex.Message);
                }
            }


            System.Xml.XmlNodeList NodeList = Plugins.GetElementsByTagName("plugins");

            XmlNodeList pid = Plugins.GetElementsByTagName("id");
            XmlNodeList pname = Plugins.GetElementsByTagName("name");
            XmlNodeList phover = Plugins.GetElementsByTagName("hover");

            plugins.Add(new MPplugin(0, "Empty Button", ""));
            plugins.Add(new MPplugin(99999, "Custom Plugin", "hover_custom"));

            for (int i = 0; i < pid.Count; i++)
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
            FileStream READER = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            READER = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            System.Xml.XmlDocument Buttons = new System.Xml.XmlDocument();
            Buttons.Load(READER);
            NodeList = Buttons.GetElementsByTagName("Buttons");

            XmlNodeList name = Buttons.GetElementsByTagName("name");
            XmlNodeList plugin = Buttons.GetElementsByTagName("plugin");
            XmlNodeList fanart = Buttons.GetElementsByTagName("fanart");
            XmlNodeList fanartLevels = Buttons.GetElementsByTagName("fanartLevels");
            XmlNodeList parameter = Buttons.GetElementsByTagName("parameter");
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

            textBoxParameter100.Text = parameter[0].InnerText;
            textBoxParameter101.Text = parameter[1].InnerText;
            textBoxParameter102.Text = parameter[2].InnerText;
            textBoxParameter103.Text = parameter[3].InnerText;
            textBoxParameter104.Text = parameter[4].InnerText;
            textBoxParameter105.Text = parameter[5].InnerText;
            textBoxParameter106.Text = parameter[6].InnerText;
            textBoxParameter107.Text = parameter[7].InnerText;
            textBoxParameter108.Text = parameter[8].InnerText;
            textBoxParameter109.Text = parameter[9].InnerText;
            textBoxParameter110.Text = parameter[10].InnerText;
            textBoxParameter111.Text = parameter[11].InnerText;
            textBoxParameter112.Text = parameter[12].InnerText;
            textBoxParameter113.Text = parameter[13].InnerText;
            textBoxParameter114.Text = parameter[14].InnerText;

            if (plugin[0].InnerText != "0") textBoxid100.Text = plugin[0].InnerText;
            if (plugin[1].InnerText != "0") textBoxid101.Text = plugin[1].InnerText;
            if (plugin[2].InnerText != "0") textBoxid102.Text = plugin[2].InnerText;
            if (plugin[3].InnerText != "0") textBoxid103.Text = plugin[3].InnerText;
            if (plugin[4].InnerText != "0") textBoxid104.Text = plugin[4].InnerText;
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

            //if (fanart[0].InnerText == "True") { checkBox100.Checked = true; } else { checkBox100.Visible = false; }
            //if (fanart[1].InnerText == "True") { checkBox101.Checked = true; } else { checkBox101.Visible = false; }
            //if (fanart[2].InnerText == "True") { checkBox102.Checked = true; } else { checkBox102.Visible = false; }
            //if (fanart[3].InnerText == "True") { checkBox103.Checked = true; } else { checkBox103.Visible = false; }
            //if (fanart[4].InnerText == "True") { checkBox104.Checked = true; } else { checkBox104.Visible = false; }
            if (fanart[5].InnerText == "True") { checkBox105.Checked = true; } else { checkBox105.Checked = false; }
            if (fanart[6].InnerText == "True") { checkBox106.Checked = true; } else { checkBox106.Checked = false; }
            if (fanart[7].InnerText == "True") { checkBox107.Checked = true; } else { checkBox107.Checked = false; }
            if (fanart[8].InnerText == "True") { checkBox108.Checked = true; } else { checkBox108.Checked = false; }
            if (fanart[9].InnerText == "True") { checkBox109.Checked = true; } else { checkBox109.Checked = false; }
            if (fanart[10].InnerText == "True") { checkBox110.Checked = true; } else { checkBox110.Checked = false; }
            if (fanart[11].InnerText == "True") { checkBox111.Checked = true; } else { checkBox111.Checked = false; }
            if (fanart[12].InnerText == "True") { checkBox112.Checked = true; } else { checkBox112.Checked = false; }
            if (fanart[13].InnerText == "True") { checkBox113.Checked = true; } else { checkBox113.Checked = false; }
            if (fanart[14].InnerText == "True") { checkBox114.Checked = true; } else { checkBox114.Checked = false; }


            numericUpDown105.Value = decimal.Parse(fanartLevels[5].InnerText);
            numericUpDown106.Value = decimal.Parse(fanartLevels[6].InnerText);
            numericUpDown107.Value = decimal.Parse(fanartLevels[7].InnerText);
            numericUpDown108.Value = decimal.Parse(fanartLevels[8].InnerText);
            numericUpDown109.Value = decimal.Parse(fanartLevels[9].InnerText);
            numericUpDown110.Value = decimal.Parse(fanartLevels[10].InnerText);
            numericUpDown111.Value = decimal.Parse(fanartLevels[11].InnerText);
            numericUpDown112.Value = decimal.Parse(fanartLevels[12].InnerText);
            numericUpDown113.Value = decimal.Parse(fanartLevels[13].InnerText);
            numericUpDown114.Value = decimal.Parse(fanartLevels[14].InnerText);


            String ApplicationPath = Application.StartupPath;


            if (File.Exists(ApplicationPath + "\\100.jpg") && plugin[0].InnerText != "0") pictureBox100.Image = formatImage((Bitmap)Bitmap.FromFile(ApplicationPath + "\\100.jpg"), "100");
            if (File.Exists(ApplicationPath + "\\101.jpg") && plugin[1].InnerText != "0") pictureBox101.Image = formatImage((Bitmap)Bitmap.FromFile(ApplicationPath + "\\101.jpg"), "101");
            if (File.Exists(ApplicationPath + "\\102.jpg") && plugin[2].InnerText != "0") pictureBox102.Image = formatImage((Bitmap)Bitmap.FromFile(ApplicationPath + "\\102.jpg"), "102");
            if (File.Exists(ApplicationPath + "\\103.jpg") && plugin[3].InnerText != "0") pictureBox103.Image = formatImage((Bitmap)Bitmap.FromFile(ApplicationPath + "\\103.jpg"), "103");
            if (File.Exists(ApplicationPath + "\\104.jpg") && plugin[4].InnerText != "0") pictureBox104.Image = formatImage((Bitmap)Bitmap.FromFile(ApplicationPath + "\\104.jpg"), "104");
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



            Assembly myAssembly = Assembly.GetExecutingAssembly();
            Stream myStream = myAssembly.GetManifestResourceStream("BlackGlassEditor.Images.blue_bg_sample.png");
            radioButtonCustomColor.BackgroundImage = new Bitmap(myStream);

            myStream = myAssembly.GetManifestResourceStream("BlackGlassEditor.Images.black_bg_sample.png");
            radioButtonBlack.BackgroundImage = new Bitmap(myStream);

            if (plugin[16].InnerText == "black")
            {
                radioButtonBlack.Checked = true;
                numericUpDownColor.Value = 0.0m;
            }
            else
            {
                radioButtonCustomColor.Checked = true;
                numericUpDownColor.Value = Decimal.Parse(plugin[16].InnerText);

                myStream = myAssembly.GetManifestResourceStream("BlackGlassEditor.Images.blue_bg_sample.png");
                ImageManipulator im = new ImageManipulator(new Bitmap(myStream));
                String newvalue = numericUpDownColor.Value.ToString();
                radioButtonCustomColor.BackgroundImage = (Bitmap)im.RotateHue(float.Parse(newvalue));
            }
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
                    newsizeX = 359; newsizeY = 368;
                    topleftX = 18; topleftY = 3;
                    toprightX = 232; toprightY = 13;
                    bottomleftX = 6; bottomleftY = 163;
                    bottomrightX = 226; bottomrightY = 150;
                    break;

                case "101":
                    newsizeX = 313; newsizeY = 322;
                    topleftX = 11; topleftY = 3;
                    toprightX = 202; toprightY = 7;
                    bottomleftX = 6; bottomleftY = 137;
                    bottomrightX = 200; bottomrightY = 132;
                    break;

                case "102":
                    newsizeX = 295; newsizeY = 307;
                    topleftX = 7; topleftY = 3;
                    toprightX = 189; toprightY = 3;
                    bottomleftX = 7; bottomleftY = 127;
                    bottomrightX = 189; bottomrightY = 127;
                    break;

                case "103":
                    newsizeX = 314; newsizeY = 324;
                    topleftX = 6; topleftY = 8;
                    toprightX = 196; toprightY = 3;
                    bottomleftX = 8; bottomleftY = 132;
                    bottomrightX = 202; bottomrightY = 136;
                    break;

                case "104":
                    newsizeX = 359; newsizeY = 363;
                    topleftX = 7; topleftY = 14;
                    toprightX = 220; toprightY = 3;
                    bottomleftX = 12; bottomleftY = 150;
                    bottomrightX = 232; bottomrightY = 163;
                    break;

                case "105":
                    newsizeX = 349; newsizeY = 274;
                    topleftX = 18; topleftY = 3;
                    toprightX = 224; toprightY = 40;
                    bottomleftX = 6; bottomleftY = 156;
                    bottomrightX = 219; bottomrightY = 171;
                    break;

                case "106":
                    newsizeX = 307; newsizeY = 228;
                    topleftX = 11; topleftY = 3;
                    toprightX = 198; toprightY = 18;
                    bottomleftX = 6; bottomleftY = 134;
                    bottomrightX = 196; bottomrightY = 139;
                    break;

                case "107":
                    newsizeX = 290; newsizeY = 205;
                    topleftX = 8; topleftY = 3;
                    toprightX = 185; toprightY = 3;
                    bottomleftX = 7; bottomleftY = 124;
                    bottomrightX = 187; bottomrightY = 124;
                    break;

                case "108":
                    newsizeX = 307; newsizeY = 228;
                    topleftX = 8; topleftY = 18;
                    toprightX = 192; toprightY = 3;
                    bottomleftX = 8; bottomleftY = 139;
                    bottomrightX = 198; bottomrightY = 133;
                    break;

                case "109":
                    newsizeX = 348; newsizeY = 274;
                    topleftX = 6; topleftY = 44;
                    toprightX = 214; toprightY = 4;
                    bottomleftX = 11; bottomleftY = 180;
                    bottomrightX = 224; bottomrightY = 157;
                    break;

                case "110":
                    newsizeX = 337; newsizeY = 295;
                    topleftX = 18; topleftY = 2;
                    toprightX = 219; toprightY = 62;
                    bottomleftX = 6; bottomleftY = 144;
                    bottomrightX = 213; bottomrightY = 185;
                    break;

                case "111":
                    newsizeX = 301; newsizeY = 232;
                    topleftX = 11; topleftY = 2;
                    toprightX = 194; toprightY = 25;
                    bottomleftX = 6; bottomleftY = 125;
                    bottomrightX = 192; bottomrightY = 142;
                    break;

                case "112":
                    newsizeX = 285; newsizeY = 200;
                    topleftX = 8; topleftY = 4;
                    toprightX = 182; toprightY = 4;
                    bottomleftX = 8; bottomleftY = 120;
                    bottomrightX = 182; bottomrightY = 120;
                    break;

                case "113":
                    newsizeX = 302; newsizeY = 232;
                    topleftX = 7; topleftY = 26;
                    toprightX = 189; toprightY = 2;
                    bottomleftX = 8; bottomleftY = 142;
                    bottomrightX = 194; bottomrightY = 126;
                    break;

                case "114":
                    newsizeX = 338; newsizeY = 295;
                    topleftX = 6; topleftY = 62;
                    toprightX = 208; toprightY = 1;
                    bottomleftX = 11; bottomleftY = 186;
                    bottomrightX = 218; bottomrightY = 144;
                    break;

            }

            topleftX = Convert.ToInt32(topleftX * 1.5); topleftY = Convert.ToInt32(topleftY * 1.5);
            toprightX = Convert.ToInt32(toprightX * 1.5); toprightY = Convert.ToInt32(toprightY * 1.5);
            bottomleftX = Convert.ToInt32(bottomleftX * 1.5); bottomleftY = Convert.ToInt32(bottomleftY * 1.5);
            bottomrightX = Convert.ToInt32(bottomrightX * 1.5); bottomrightY = Convert.ToInt32(bottomrightY * 1.5);

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

                topleftX = Convert.ToInt32(topleftX * 1.5); topleftY = Convert.ToInt32(topleftY * 1.5);
                toprightX = Convert.ToInt32(toprightX * 1.5); toprightY = Convert.ToInt32(toprightY * 1.5);
                bottomleftX = Convert.ToInt32(bottomleftX * 1.5); bottomleftY = Convert.ToInt32(bottomleftY * 1.5);
                bottomrightX = Convert.ToInt32(bottomrightX * 1.5); bottomrightY = Convert.ToInt32(bottomrightY * 1.5);
                offsetX = Convert.ToInt32(offsetX * 1.5); offsetY = Convert.ToInt32(offsetY * 1.5);


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
                ga.DrawImage((Bitmap)Functions.SetImgOpacity(reflectedImg, 0.50f), new System.Drawing.Rectangle(offsetX, offsetY, img.Width, img.Height));
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
                    myWidth = 359;
                    myHeight = 368;
                    break;
                case "101":
                    myWidth = 313;
                    myHeight = 322;
                    break;
                case "102":
                    myWidth = 295;
                    myHeight = 307;
                    break;
                case "103":
                    myWidth = 314;
                    myHeight = 324;
                    break;
                case "104":
                    myWidth = 359;
                    myHeight = 363;
                    break;
                case "105":
                    myWidth = 349;
                    myHeight = 274;
                    break;
                case "106":
                    myWidth = 307;
                    myHeight = 228;
                    break;
                case "107":
                    myWidth = 290;
                    myHeight = 205;
                    break;
                case "108":
                    myWidth = 307;
                    myHeight = 228;
                    break;
                case "109":
                    myWidth = 348;
                    myHeight = 274;
                    break;
                case "110":
                    myWidth = 337;
                    myHeight = 295;
                    break;
                case "111":
                    myWidth = 301;
                    myHeight = 232;
                    break;
                case "112":
                    myWidth = 285;
                    myHeight = 200;
                    break;
                case "113":
                    myWidth = 302;
                    myHeight = 232;
                    break;
                case "114":
                    myWidth = 338;
                    myHeight = 295;
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
                //img = Functions.MakeGrayscale(img);
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
                    myWidth = 359;
                    myHeight = 368;
                    break;
                case "101":
                    myWidth = 313;
                    myHeight = 322;
                    break;
                case "102":
                    myWidth = 295;
                    myHeight = 307;
                    break;
                case "103":
                    myWidth = 314;
                    myHeight = 324;
                    break;
                case "104":
                    myWidth = 359;
                    myHeight = 363;
                    break;
                case "105":
                    myWidth = 349;
                    myHeight = 274;
                    break;
                case "106":
                    myWidth = 307;
                    myHeight = 228;
                    break;
                case "107":
                    myWidth = 290;
                    myHeight = 205;
                    break;
                case "108":
                    myWidth = 307;
                    myHeight = 228;
                    break;
                case "109":
                    myWidth = 348;
                    myHeight = 274;
                    break;
                case "110":
                    myWidth = 337;
                    myHeight = 295;
                    break;
                case "111":
                    myWidth = 301;
                    myHeight = 232;
                    break;
                case "112":
                    myWidth = 285;
                    myHeight = 200;
                    break;
                case "113":
                    myWidth = 302;
                    myHeight = 232;
                    break;
                case "114":
                    myWidth = 338;
                    myHeight = 295;
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
                //img = Functions.MakeGrayscale(img);

            }

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
            textBoxParameter100.Text = "";
            if (comboBox100.Text == "Empty Button") { textBox100.Text = ""; textBoxid100.Text = ""; };
        }
        private void comboBox101_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox101.Text = comboBox101.Text;
            textBoxid101.Text = findPlugin(comboBox101.Text).ToString();
            textBoxParameter101.Text = "";
            if (comboBox101.Text == "Empty Button") { textBox101.Text = ""; textBoxid101.Text = ""; };
        }
        private void comboBox102_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox102.Text = comboBox102.Text;
            textBoxid102.Text = findPlugin(comboBox102.Text).ToString();
            textBoxParameter102.Text = "";
            if (comboBox102.Text == "Empty Button") { textBox102.Text = ""; textBoxid102.Text = ""; };
        }
        private void comboBox103_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox103.Text = comboBox103.Text;
            textBoxid103.Text = findPlugin(comboBox103.Text).ToString();
            textBoxParameter103.Text = "";
            if (comboBox103.Text == "Empty Button") { textBox103.Text = ""; textBoxid103.Text = ""; };
        }
        private void comboBox104_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox104.Text = comboBox104.Text;
            textBoxid104.Text = findPlugin(comboBox104.Text).ToString();
            textBoxParameter104.Text = "";
            if (comboBox104.Text == "Empty Button") { textBox104.Text = ""; textBoxid104.Text = ""; };
        }
        private void comboBox105_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox105.Text = comboBox105.Text;
            textBoxid105.Text = findPlugin(comboBox105.Text).ToString();
            textBoxParameter105.Text = "";
            if (comboBox105.Text == "Empty Button") { textBox105.Text = ""; textBoxid105.Text = ""; };
            //checkBox105.Visible = false;
            checkBox105.Checked = false;
            if (textBoxid105.Text == "504" || textBoxid105.Text == "501" || textBoxid105.Text == "96742" || textBoxid105.Text == "1" || textBoxid105.Text == "9811" || textBoxid105.Text == "2600" || textBoxid105.Text == "2") { checkBox105.Checked = true; numericUpDown105.Value = 1.0m; };
        }
        private void comboBox106_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox106.Text = comboBox106.Text;
            textBoxid106.Text = findPlugin(comboBox106.Text).ToString();
            textBoxParameter106.Text = "";
            if (comboBox106.Text == "Empty Button") { textBox106.Text = ""; textBoxid106.Text = ""; };
            //checkBox106.Visible = false;
            checkBox106.Checked = false;
            if (textBoxid106.Text == "504" || textBoxid106.Text == "501" || textBoxid106.Text == "96742" || textBoxid106.Text == "1" || textBoxid106.Text == "9811" || textBoxid106.Text == "2600" || textBoxid106.Text == "2") { checkBox106.Checked = true; numericUpDown106.Value = 1.0m; };
        }
        private void comboBox107_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox107.Text = comboBox107.Text;
            textBoxid107.Text = findPlugin(comboBox107.Text).ToString();
            textBoxParameter107.Text = "";
            if (comboBox107.Text == "Empty Button") { textBox107.Text = ""; textBoxid107.Text = ""; };
            //checkBox107.Visible = false;
            checkBox107.Checked = false;
            if (textBoxid107.Text == "504" || textBoxid107.Text == "501" || textBoxid107.Text == "96742" || textBoxid107.Text == "1" || textBoxid107.Text == "9811" || textBoxid107.Text == "2600" || textBoxid107.Text == "2") { checkBox107.Checked = true; numericUpDown107.Value = 1.0m; };
        }
        private void comboBox108_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox108.Text = comboBox108.Text;
            textBoxid108.Text = findPlugin(comboBox108.Text).ToString();
            textBoxParameter108.Text = "";
            if (comboBox108.Text == "Empty Button") { textBox108.Text = ""; textBoxid108.Text = ""; };
            //checkBox108.Visible = false;
            checkBox108.Checked = false;
            if (textBoxid108.Text == "504" || textBoxid108.Text == "501" || textBoxid108.Text == "96742" || textBoxid108.Text == "1" || textBoxid108.Text == "9811" || textBoxid108.Text == "2600" || textBoxid108.Text == "2") { checkBox108.Checked = true; numericUpDown108.Value = 1.0m; };
        }
        private void comboBox109_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox109.Text = comboBox109.Text;
            textBoxid109.Text = findPlugin(comboBox109.Text).ToString();
            textBoxParameter109.Text = "";
            if (comboBox109.Text == "Empty Button") { textBox109.Text = ""; textBoxid109.Text = ""; };
            //checkBox109.Visible = false;
            checkBox109.Checked = false;
            if (textBoxid109.Text == "504" || textBoxid109.Text == "501" || textBoxid109.Text == "96742" || textBoxid109.Text == "1" || textBoxid109.Text == "9811" || textBoxid109.Text == "2600" || textBoxid109.Text == "2") { checkBox109.Checked = true; numericUpDown109.Value = 1.0m; };
        }
        private void comboBox110_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox110.Text = comboBox110.Text;
            textBoxid110.Text = findPlugin(comboBox110.Text).ToString();
            textBoxParameter110.Text = "";
            if (comboBox110.Text == "Empty Button") { textBox110.Text = ""; textBoxid110.Text = ""; };
            //checkBox110.Visible = false;
            checkBox110.Checked = false;
            if (textBoxid110.Text == "504" || textBoxid110.Text == "501" || textBoxid110.Text == "96742" || textBoxid110.Text == "1" || textBoxid110.Text == "9811" || textBoxid110.Text == "2600" || textBoxid110.Text == "2") { checkBox110.Checked = true; numericUpDown110.Value = 1.0m; };
        }
        private void comboBox111_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox111.Text = comboBox111.Text;
            textBoxid111.Text = findPlugin(comboBox111.Text).ToString();
            textBoxParameter111.Text = "";
            if (comboBox111.Text == "Empty Button") { textBox111.Text = ""; textBoxid111.Text = ""; };
            //checkBox111.Visible = false;
            checkBox111.Checked = false;
            if (textBoxid111.Text == "504" || textBoxid111.Text == "501" || textBoxid111.Text == "96742" || textBoxid111.Text == "1" || textBoxid111.Text == "9811" || textBoxid111.Text == "2600" || textBoxid111.Text == "2") { checkBox111.Checked = true; numericUpDown111.Value = 1.0m; };
        }
        private void comboBox112_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox112.Text = comboBox112.Text;
            textBoxid112.Text = findPlugin(comboBox112.Text).ToString();
            textBoxParameter112.Text = "";
            if (comboBox112.Text == "Empty Button") { textBox112.Text = ""; textBoxid112.Text = ""; };
            //checkBox112.Visible = false;
            checkBox112.Checked = false;
            if (textBoxid112.Text == "504" || textBoxid112.Text == "501" || textBoxid112.Text == "96742" || textBoxid112.Text == "1" || textBoxid112.Text == "9811" || textBoxid112.Text == "2600" || textBoxid112.Text == "2") { checkBox112.Checked = true; numericUpDown112.Value = 1.0m; };
        }
        private void comboBox113_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox113.Text = comboBox113.Text;
            textBoxid113.Text = findPlugin(comboBox113.Text).ToString();
            textBoxParameter113.Text = "";
            if (comboBox113.Text == "Empty Button") { textBox113.Text = ""; textBoxid113.Text = ""; };
            //checkBox113.Visible = false;
            checkBox113.Checked = false;
            if (textBoxid113.Text == "504" || textBoxid113.Text == "501" || textBoxid113.Text == "96742" || textBoxid113.Text == "1" || textBoxid113.Text == "9811" || textBoxid113.Text == "2600" || textBoxid113.Text == "2") { checkBox113.Checked = true; numericUpDown113.Value = 1.0m; };
        }
        private void comboBox114_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox114.Text = comboBox114.Text;
            textBoxid114.Text = findPlugin(comboBox114.Text).ToString();
            textBoxParameter114.Text = "";
            if (comboBox114.Text == "Empty Button") { textBox114.Text = ""; textBoxid114.Text = ""; };
            //checkBox114.Visible = false;
            checkBox114.Checked = false;
            if (textBoxid114.Text == "504" || textBoxid114.Text == "501" || textBoxid114.Text == "96742" || textBoxid114.Text == "1" || textBoxid114.Text == "9811" || textBoxid114.Text == "2600" || textBoxid114.Text == "2") { checkBox114.Checked = true; numericUpDown114.Value = 1.0m; };
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
            string Name = "Custom Plugin";
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
            if (checkEmptyPictures() > 0) MessageBox.Show("Error: At least a Button has no associated picture!");
            else if (checkEmptyCombos() > 0) MessageBox.Show("Error: At least a Button has no associated plugin!");
            else if (!checkTargetPath()) MessageBox.Show("Error: Target Path not set!");
            else
            {


                // INIZIALIZZAZIONE

                Bitmap finalImage = new Bitmap(1920, 1080);
                Bitmap clipImage = new Bitmap(1920, 1080);

                Graphics gfx = Graphics.FromImage(finalImage);
                gfx.SmoothingMode = SmoothingMode.AntiAlias;


                // SELEZIONA COLORE THEME

                String themecolor = "custom";
                if (radioButtonCustomColor.Checked == true) themecolor = "blue";
                if (radioButtonBlack.Checked == true) themecolor = "black";
                String newhuevalue = numericUpDownColor.Value.ToString();
                Bitmap basichome_bg;
                Bitmap bg;

                // CARICAMENTO basichome_bg.jpg
                Assembly myAssembly = Assembly.GetExecutingAssembly();

                Stream myStream = myAssembly.GetManifestResourceStream("BlackGlassEditor.Images." + themecolor + "_bg_up.png");
                if (radioButtonCustomColor.Checked == true)
                {
                    ImageManipulator im = new ImageManipulator(new Bitmap(myStream));
                    basichome_bg = (Bitmap)im.RotateHue(float.Parse(newhuevalue));
                }
                else
                {
                    basichome_bg = new Bitmap(myStream);
                }

                // CARICAMENTO bg.jpg
                myStream = myAssembly.GetManifestResourceStream("BlackGlassEditor.Images." + themecolor + "_bg_down.png");
                if (radioButtonCustomColor.Checked == true)
                {
                    ImageManipulator im = new ImageManipulator(new Bitmap(myStream));
                    bg = (Bitmap)im.RotateHue(float.Parse(newhuevalue));
                }
                else
                {
                    bg = new Bitmap(myStream);
                }




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

                Bitmap buttonImage100 = null;
                if (pictureBox100.Image != null)
                {
                    buttonImage100 = new Bitmap(buildImage(pictureBox100.Image, "100", 1));
                    saveImage(BlackGlassDirClass.Path + "\\Media\\basichome_100_nofocus.png", pictureBox100.Image, "100", 0);
                    saveImage(BlackGlassDirClass.Path + "\\Media\\basichome_100_focus.png", pictureBox100.Image, "100", 1);
                }

                Bitmap buttonImage101 = null;
                if (pictureBox101.Image != null)
                {
                    buttonImage101 = new Bitmap(buildImage(pictureBox101.Image, "101", 1));
                    saveImage(BlackGlassDirClass.Path + "\\Media\\basichome_101_nofocus.png", pictureBox101.Image, "101", 0);
                    saveImage(BlackGlassDirClass.Path + "\\Media\\basichome_101_focus.png", pictureBox101.Image, "101", 1);
                }

                Bitmap buttonImage102 = null;
                if (pictureBox102.Image != null)
                {
                    buttonImage102 = new Bitmap(buildImage(pictureBox102.Image, "102", 1));
                    saveImage(BlackGlassDirClass.Path + "\\Media\\basichome_102_nofocus.png", pictureBox102.Image, "102", 0);
                    saveImage(BlackGlassDirClass.Path + "\\Media\\basichome_102_focus.png", pictureBox102.Image, "102", 1);
                }

                Bitmap buttonImage103 = null;
                if (pictureBox103.Image != null)
                {
                    buttonImage103 = new Bitmap(buildImage(pictureBox103.Image, "103", 1));
                    saveImage(BlackGlassDirClass.Path + "\\Media\\basichome_103_nofocus.png", pictureBox103.Image, "103", 0);
                    saveImage(BlackGlassDirClass.Path + "\\Media\\basichome_103_focus.png", pictureBox103.Image, "103", 1);
                }

                Bitmap buttonImage104 = null;
                if (pictureBox104.Image != null)
                {
                    buttonImage104 = new Bitmap(buildImage(pictureBox104.Image, "104", 1));
                    saveImage(BlackGlassDirClass.Path + "\\Media\\basichome_104_nofocus.png", pictureBox104.Image, "104", 0);
                    saveImage(BlackGlassDirClass.Path + "\\Media\\basichome_104_focus.png", pictureBox104.Image, "104", 1);
                }

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

                gfx.DrawImage(bg, new System.Drawing.Rectangle(0, 0, 1920, 1080));

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

                gfx.DrawImage(basichome_bg, new System.Drawing.Rectangle(0, 0, 1920, 1080));

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
                gfx.DrawImage(sidebuttons, new System.Drawing.Rectangle(0, 0, 1920, 1080));


                if (pictureBox100.Image != null) gfx.DrawImage(buttonImage100, new System.Drawing.Rectangle(150, 597, buttonImage100.Width, buttonImage100.Height));
                if (pictureBox101.Image != null) gfx.DrawImage(buttonImage101, new System.Drawing.Rectangle(504, 615, buttonImage101.Width, buttonImage101.Height));
                if (pictureBox102.Image != null) gfx.DrawImage(buttonImage102, new System.Drawing.Rectangle(813, 621, buttonImage102.Width, buttonImage102.Height));
                if (pictureBox103.Image != null) gfx.DrawImage(buttonImage103, new System.Drawing.Rectangle(1104, 615, buttonImage103.Width, buttonImage103.Height));
                if (pictureBox104.Image != null) gfx.DrawImage(buttonImage104, new System.Drawing.Rectangle(1411, 597, buttonImage104.Width, buttonImage104.Height));
                if (pictureBox105.Image != null) gfx.DrawImage(buttonImage105, new System.Drawing.Rectangle(171, 346, buttonImage105.Width, buttonImage105.Height));
                if (pictureBox106.Image != null) gfx.DrawImage(buttonImage106, new System.Drawing.Rectangle(513, 405, buttonImage106.Width, buttonImage106.Height));
                if (pictureBox107.Image != null) gfx.DrawImage(buttonImage107, new System.Drawing.Rectangle(814, 429, buttonImage107.Width, buttonImage107.Height));
                if (pictureBox108.Image != null) gfx.DrawImage(buttonImage108, new System.Drawing.Rectangle(1099, 405, buttonImage108.Width, buttonImage108.Height));
                if (pictureBox109.Image != null) gfx.DrawImage(buttonImage109, new System.Drawing.Rectangle(1402, 346, buttonImage109.Width, buttonImage109.Height));
                if (pictureBox110.Image != null) gfx.DrawImage(buttonImage110, new System.Drawing.Rectangle(189, 114, buttonImage110.Width, buttonImage110.Height));
                if (pictureBox111.Image != null) gfx.DrawImage(buttonImage111, new System.Drawing.Rectangle(522, 207, buttonImage111.Width, buttonImage111.Height));
                if (pictureBox112.Image != null) gfx.DrawImage(buttonImage112, new System.Drawing.Rectangle(817, 243, buttonImage112.Width, buttonImage112.Height));
                if (pictureBox113.Image != null) gfx.DrawImage(buttonImage113, new System.Drawing.Rectangle(1096, 207, buttonImage113.Width, buttonImage113.Height));
                if (pictureBox114.Image != null) gfx.DrawImage(buttonImage114, new System.Drawing.Rectangle(1393, 114, buttonImage114.Width, buttonImage114.Height));



                //try
                //{
                //    ImageCodecInfo jgpEncoder = Functions.GetEncoder(ImageFormat.Jpeg);

                //    System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;
                //    EncoderParameters myEncoderParameters = new EncoderParameters(1);

                //    EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 100L);
                //    myEncoderParameters.Param[0] = myEncoderParameter;

                //    finalImage.Save(BlackGlassDirClass.Path + "\\Media\\bg_homefull.jpg", jgpEncoder, myEncoderParameters);
                //    toolStripStatusLabel1.Text = "Theme Files Saved Succesfully";
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show("Error: Could not save bg_homefull.jpg to disk. Original error: " + ex.Message);
                //}


                //CREA preview.png
                gfx.DrawImage(preview, new System.Drawing.Rectangle(0, 0, 1920, 1080));

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
                gfx.DrawImage(splash, new System.Drawing.Rectangle(0, 0, 1920, 1080));

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
            if (Directory.Exists(ProgramFilesx86() + @"\Team MediaPortal\MediaPortal\skin\Black Glass HD")) path = ProgramFilesx86() + @"\Team MediaPortal\MediaPortal\skin\Black Glass HD";

            // MP 1.1 
            if (Directory.Exists(Environment.GetEnvironmentVariable("ALLUSERSPROFILE") + @"\Team MediaPortal\MediaPortal\skin\Black Glass HD")) path = Environment.GetEnvironmentVariable("ALLUSERSPROFILE") + @"\Team MediaPortal\MediaPortal\skin\Black Glass HD";

            if (path == "") MessageBox.Show("Error: Could not find Black Glass HD Skin folder.\n\nUse the 'Select Skin Path' button to find it!");


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
            if (BlackGlassDirClass.Path == "") MessageBox.Show("Error: Target Path is not set!");
            else if (checkEmptyCombos() > 0) MessageBox.Show("Error: At least a Button has no associated plugin!");
            else
            {

                string txt = @"<?xml version=""1.0"" encoding=""utf-8"" standalone=""yes""?>
<window>
  <controls>

        ";

                if (comboBox100.SelectedItem.ToString() != findPluginName(0)) { txt = txt + buildHoverLabelXml("100") + buildButtonXml("100"); }
                if (comboBox101.SelectedItem.ToString() != findPluginName(0)) { txt = txt + buildHoverLabelXml("101") + buildButtonXml("101"); }
                if (comboBox102.SelectedItem.ToString() != findPluginName(0)) { txt = txt + buildHoverLabelXml("102") + buildButtonXml("102"); }
                if (comboBox103.SelectedItem.ToString() != findPluginName(0)) { txt = txt + buildHoverLabelXml("103") + buildButtonXml("103"); }
                if (comboBox104.SelectedItem.ToString() != findPluginName(0)) { txt = txt + buildHoverLabelXml("104") + buildButtonXml("104"); }
                if (comboBox105.SelectedItem.ToString() != findPluginName(0)) { txt = txt + buildHoverLabelXml("105") + buildButtonXml("105"); if (checkBox105.Checked == true) txt = txt + buildFanartImageXml("105"); }
                if (comboBox106.SelectedItem.ToString() != findPluginName(0)) { txt = txt + buildHoverLabelXml("106") + buildButtonXml("106"); if (checkBox106.Checked == true) txt = txt + buildFanartImageXml("106"); }
                if (comboBox107.SelectedItem.ToString() != findPluginName(0)) { txt = txt + buildHoverLabelXml("107") + buildButtonXml("107"); if (checkBox107.Checked == true) txt = txt + buildFanartImageXml("107"); }
                if (comboBox108.SelectedItem.ToString() != findPluginName(0)) { txt = txt + buildHoverLabelXml("108") + buildButtonXml("108"); if (checkBox108.Checked == true) txt = txt + buildFanartImageXml("108"); }
                if (comboBox109.SelectedItem.ToString() != findPluginName(0)) { txt = txt + buildHoverLabelXml("109") + buildButtonXml("109"); if (checkBox109.Checked == true) txt = txt + buildFanartImageXml("109"); }
                if (comboBox110.SelectedItem.ToString() != findPluginName(0)) { txt = txt + buildHoverLabelXml("110") + buildButtonXml("110"); if (checkBox110.Checked == true) txt = txt + buildFanartImageXml("110"); }
                if (comboBox111.SelectedItem.ToString() != findPluginName(0)) { txt = txt + buildHoverLabelXml("111") + buildButtonXml("111"); if (checkBox111.Checked == true) txt = txt + buildFanartImageXml("111"); }
                if (comboBox112.SelectedItem.ToString() != findPluginName(0)) { txt = txt + buildHoverLabelXml("112") + buildButtonXml("112"); if (checkBox112.Checked == true) txt = txt + buildFanartImageXml("112"); }
                if (comboBox113.SelectedItem.ToString() != findPluginName(0)) { txt = txt + buildHoverLabelXml("113") + buildButtonXml("113"); if (checkBox113.Checked == true) txt = txt + buildFanartImageXml("113"); }
                if (comboBox114.SelectedItem.ToString() != findPluginName(0)) { txt = txt + buildHoverLabelXml("114") + buildButtonXml("114"); if (checkBox114.Checked == true) txt = txt + buildFanartImageXml("114"); }
                txt = txt + @"
    </controls>
</window>";


                String path = BlackGlassDirClass.Path + "\\BasicHome_Buttons.xml";

                try
                {
                    TextWriter tw = new StreamWriter(path, false, Encoding.UTF8);
                    //TextWriter tw = new StreamWriter(path);
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
                XmlTextWriter textWriter = new XmlTextWriter(path, Encoding.UTF8);
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
                if (textBoxid100.Text == "") textWriter.WriteString("0");
                if (textBoxid100.Text != "") textWriter.WriteString(SecurityElement.Escape(textBoxid100.Text));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("fanart", "");
                textWriter.WriteString(SecurityElement.Escape(checkBox100.Checked.ToString()));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("fanartLevels", "");
                textWriter.WriteString(SecurityElement.Escape(numericUpDown100.Value.ToString()));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("parameter", "");
                textWriter.WriteString(SecurityElement.Escape(textBoxParameter100.Text));
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
                if (textBoxid101.Text == "") textWriter.WriteString("0");
                if (textBoxid101.Text != "") textWriter.WriteString(SecurityElement.Escape(textBoxid101.Text));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("fanart", "");
                textWriter.WriteString(SecurityElement.Escape(checkBox101.Checked.ToString()));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("fanartLevels", "");
                textWriter.WriteString(SecurityElement.Escape(numericUpDown101.Value.ToString()));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("parameter", "");
                textWriter.WriteString(SecurityElement.Escape(textBoxParameter101.Text));
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
                if (textBoxid102.Text == "") textWriter.WriteString("0");
                if (textBoxid102.Text != "") textWriter.WriteString(SecurityElement.Escape(textBoxid102.Text));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("fanart", "");
                textWriter.WriteString(SecurityElement.Escape(checkBox102.Checked.ToString()));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("fanartLevels", "");
                textWriter.WriteString(SecurityElement.Escape(numericUpDown102.Value.ToString()));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("parameter", "");
                textWriter.WriteString(SecurityElement.Escape(textBoxParameter102.Text));
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
                if (textBoxid103.Text == "") textWriter.WriteString("0");
                if (textBoxid103.Text != "") textWriter.WriteString(SecurityElement.Escape(textBoxid103.Text));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("fanart", "");
                textWriter.WriteString(SecurityElement.Escape(checkBox103.Checked.ToString()));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("fanartLevels", "");
                textWriter.WriteString(SecurityElement.Escape(numericUpDown103.Value.ToString()));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("parameter", "");
                textWriter.WriteString(SecurityElement.Escape(textBoxParameter103.Text));
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
                if (textBoxid104.Text == "") textWriter.WriteString("0");
                if (textBoxid104.Text != "") textWriter.WriteString(SecurityElement.Escape(textBoxid104.Text));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("fanart", "");
                textWriter.WriteString(SecurityElement.Escape(checkBox104.Checked.ToString()));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("fanartLevels", "");
                textWriter.WriteString(SecurityElement.Escape(numericUpDown104.Value.ToString()));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("parameter", "");
                textWriter.WriteString(SecurityElement.Escape(textBoxParameter104.Text));
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
                textWriter.WriteStartElement("fanart", "");
                textWriter.WriteString(SecurityElement.Escape(checkBox105.Checked.ToString()));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("fanartLevels", "");
                textWriter.WriteString(SecurityElement.Escape(numericUpDown105.Value.ToString()));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("parameter", "");
                textWriter.WriteString(SecurityElement.Escape(textBoxParameter105.Text));
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
                textWriter.WriteStartElement("fanart", "");
                textWriter.WriteString(SecurityElement.Escape(checkBox106.Checked.ToString()));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("fanartLevels", "");
                textWriter.WriteString(SecurityElement.Escape(numericUpDown106.Value.ToString()));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("parameter", "");
                textWriter.WriteString(SecurityElement.Escape(textBoxParameter106.Text));
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
                textWriter.WriteStartElement("fanart", "");
                textWriter.WriteString(SecurityElement.Escape(checkBox107.Checked.ToString()));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("fanartLevels", "");
                textWriter.WriteString(SecurityElement.Escape(numericUpDown107.Value.ToString()));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("parameter", "");
                textWriter.WriteString(SecurityElement.Escape(textBoxParameter107.Text));
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
                textWriter.WriteStartElement("fanart", "");
                textWriter.WriteString(SecurityElement.Escape(checkBox108.Checked.ToString()));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("fanartLevels", "");
                textWriter.WriteString(SecurityElement.Escape(numericUpDown108.Value.ToString()));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("parameter", "");
                textWriter.WriteString(SecurityElement.Escape(textBoxParameter108.Text));
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
                textWriter.WriteStartElement("fanart", "");
                textWriter.WriteString(SecurityElement.Escape(checkBox109.Checked.ToString()));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("fanartLevels", "");
                textWriter.WriteString(SecurityElement.Escape(numericUpDown109.Value.ToString()));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("parameter", "");
                textWriter.WriteString(SecurityElement.Escape(textBoxParameter109.Text));
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
                textWriter.WriteStartElement("fanart", "");
                textWriter.WriteString(SecurityElement.Escape(checkBox110.Checked.ToString()));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("fanartLevels", "");
                textWriter.WriteString(SecurityElement.Escape(numericUpDown110.Value.ToString()));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("parameter", "");
                textWriter.WriteString(SecurityElement.Escape(textBoxParameter110.Text));
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
                textWriter.WriteStartElement("fanart", "");
                textWriter.WriteString(SecurityElement.Escape(checkBox111.Checked.ToString()));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("fanartLevels", "");
                textWriter.WriteString(SecurityElement.Escape(numericUpDown111.Value.ToString()));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("parameter", "");
                textWriter.WriteString(SecurityElement.Escape(textBoxParameter111.Text));
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
                textWriter.WriteStartElement("fanart", "");
                textWriter.WriteString(SecurityElement.Escape(checkBox112.Checked.ToString()));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("fanartLevels", "");
                textWriter.WriteString(SecurityElement.Escape(numericUpDown112.Value.ToString()));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("parameter", "");
                textWriter.WriteString(SecurityElement.Escape(textBoxParameter112.Text));
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
                textWriter.WriteStartElement("fanart", "");
                textWriter.WriteString(SecurityElement.Escape(checkBox113.Checked.ToString()));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("fanartLevels", "");
                textWriter.WriteString(SecurityElement.Escape(numericUpDown113.Value.ToString()));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("parameter", "");
                textWriter.WriteString(SecurityElement.Escape(textBoxParameter113.Text));
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
                textWriter.WriteStartElement("fanart", "");
                textWriter.WriteString(SecurityElement.Escape(checkBox114.Checked.ToString()));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("fanartLevels", "");
                textWriter.WriteString(SecurityElement.Escape(numericUpDown114.Value.ToString()));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("parameter", "");
                textWriter.WriteString(SecurityElement.Escape(textBoxParameter114.Text));
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
                textWriter.WriteStartElement("fanart", "");
                textWriter.WriteString("");
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("fanartLevels", "");
                textWriter.WriteString("1");
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("parameter", "");
                textWriter.WriteString("");
                textWriter.WriteEndElement();
                textWriter.WriteEndElement();
                String themecolor = numericUpDownColor.Value.ToString();
                if (radioButtonBlack.Checked == true) themecolor = "black";

                textWriter.WriteStartElement("button");
                textWriter.WriteStartElement("Id", "");
                textWriter.WriteString("0");
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("name", "");
                textWriter.WriteString("Color");
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("plugin", "");
                textWriter.WriteString(themecolor);
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("fanart", "");
                textWriter.WriteString("");
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("fanartlevels", "");
                textWriter.WriteString("1");
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("parameter", "");
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

        private void buttonEmpty100_Click(object sender, EventArgs e)
        {
            if (pictureBox100.Image != null) pictureBox100.Image.Dispose();
            pictureBox100.Image = null;
            pictureBox100.Invalidate();
            comboBox100.SelectedItem = findPluginName(0);
            if (File.Exists(Application.StartupPath + "\\100.jpg")) File.Delete(Application.StartupPath + "\\100.jpg");
        }

        private void buttonEmpty101_Click(object sender, EventArgs e)
        {
            if (pictureBox101.Image != null) pictureBox101.Image.Dispose();
            pictureBox101.Image = null;
            pictureBox101.Invalidate();
            comboBox101.SelectedItem = findPluginName(0);
            if (File.Exists(Application.StartupPath + "\\101.jpg")) File.Delete(Application.StartupPath + "\\101.jpg");
        }

        private void buttonEmpty102_Click(object sender, EventArgs e)
        {
            if (pictureBox102.Image != null) pictureBox102.Image.Dispose();
            pictureBox102.Image = null;
            pictureBox102.Invalidate();
            comboBox102.SelectedItem = findPluginName(0);
            if (File.Exists(Application.StartupPath + "\\102.jpg")) File.Delete(Application.StartupPath + "\\102.jpg");
        }

        private void buttonEmpty103_Click(object sender, EventArgs e)
        {
            if (pictureBox103.Image != null) pictureBox103.Image.Dispose();
            pictureBox103.Image = null;
            pictureBox103.Invalidate();
            comboBox103.SelectedItem = findPluginName(0);
            if (File.Exists(Application.StartupPath + "\\103.jpg")) File.Delete(Application.StartupPath + "\\103.jpg");
        }

        private void buttonEmpty104_Click(object sender, EventArgs e)
        {
            if (pictureBox104.Image != null) pictureBox104.Image.Dispose();
            pictureBox104.Image = null;
            pictureBox104.Invalidate();
            comboBox104.SelectedItem = findPluginName(0);
            if (File.Exists(Application.StartupPath + "\\104.jpg")) File.Delete(Application.StartupPath + "\\104.jpg");
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

        private int checkEmptyCombos()
        {
            int errors = 0;

            if (comboBox100.SelectedItem.ToString() == findPluginName(0) && pictureBox100.Image != null) { MessageBox.Show("Error: Button 100 has no associated plugin!"); errors++; }
            if (comboBox101.SelectedItem.ToString() == findPluginName(0) && pictureBox101.Image != null) { MessageBox.Show("Error: Button 101 has no associated plugin!"); errors++; }
            if (comboBox102.SelectedItem.ToString() == findPluginName(0) && pictureBox102.Image != null) { MessageBox.Show("Error: Button 102 has no associated plugin!"); errors++; }
            if (comboBox103.SelectedItem.ToString() == findPluginName(0) && pictureBox103.Image != null) { MessageBox.Show("Error: Button 103 has no associated plugin!"); errors++; }
            if (comboBox104.SelectedItem.ToString() == findPluginName(0) && pictureBox104.Image != null) { MessageBox.Show("Error: Button 104 has no associated plugin!"); errors++; }
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

            if (comboBox100.SelectedItem.ToString() != findPluginName(0) && pictureBox100.Image == null) { MessageBox.Show("Error: Button 100 has no picture!"); errors++; }
            if (comboBox101.SelectedItem.ToString() != findPluginName(0) && pictureBox101.Image == null) { MessageBox.Show("Error: Button 101 has no picture!"); errors++; }
            if (comboBox102.SelectedItem.ToString() != findPluginName(0) && pictureBox102.Image == null) { MessageBox.Show("Error: Button 102 has no picture!"); errors++; }
            if (comboBox103.SelectedItem.ToString() != findPluginName(0) && pictureBox103.Image == null) { MessageBox.Show("Error: Button 103 has no picture!"); errors++; }
            if (comboBox104.SelectedItem.ToString() != findPluginName(0) && pictureBox104.Image == null) { MessageBox.Show("Error: Button 104 has no picture!"); errors++; }
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

        private String findButtonLeft(String id)
        {

            String ButtonId = id;

            switch (id)
            {

                case "100":
                    ButtonId = "100";
                    if (comboBox101.SelectedItem.ToString() != findPluginName(0)) ButtonId = "101";
                    if (comboBox102.SelectedItem.ToString() != findPluginName(0)) ButtonId = "102";
                    if (comboBox103.SelectedItem.ToString() != findPluginName(0)) ButtonId = "103";
                    if (comboBox104.SelectedItem.ToString() != findPluginName(0)) ButtonId = "104";
                    break;

                case "101":
                    ButtonId = "101";
                    if (comboBox102.SelectedItem.ToString() != findPluginName(0)) ButtonId = "102";
                    if (comboBox103.SelectedItem.ToString() != findPluginName(0)) ButtonId = "103";
                    if (comboBox104.SelectedItem.ToString() != findPluginName(0)) ButtonId = "104";
                    if (comboBox100.SelectedItem.ToString() != findPluginName(0)) ButtonId = "100";
                    break;

                case "102":
                    ButtonId = "102";
                    if (comboBox103.SelectedItem.ToString() != findPluginName(0)) ButtonId = "103";
                    if (comboBox104.SelectedItem.ToString() != findPluginName(0)) ButtonId = "104";
                    if (comboBox100.SelectedItem.ToString() != findPluginName(0)) ButtonId = "100";
                    if (comboBox101.SelectedItem.ToString() != findPluginName(0)) ButtonId = "101";
                    break;

                case "103":
                    ButtonId = "103";
                    if (comboBox104.SelectedItem.ToString() != findPluginName(0)) ButtonId = "104";
                    if (comboBox100.SelectedItem.ToString() != findPluginName(0)) ButtonId = "100";
                    if (comboBox101.SelectedItem.ToString() != findPluginName(0)) ButtonId = "101";
                    if (comboBox102.SelectedItem.ToString() != findPluginName(0)) ButtonId = "102";
                    break;

                case "104":
                    ButtonId = "104";
                    if (comboBox100.SelectedItem.ToString() != findPluginName(0)) ButtonId = "100";
                    if (comboBox101.SelectedItem.ToString() != findPluginName(0)) ButtonId = "101";
                    if (comboBox102.SelectedItem.ToString() != findPluginName(0)) ButtonId = "102";
                    if (comboBox103.SelectedItem.ToString() != findPluginName(0)) ButtonId = "103";
                    break;

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
                case "100":
                    ButtonId = "100";
                    if (comboBox104.SelectedItem.ToString() != findPluginName(0)) ButtonId = "104";
                    if (comboBox103.SelectedItem.ToString() != findPluginName(0)) ButtonId = "103";
                    if (comboBox102.SelectedItem.ToString() != findPluginName(0)) ButtonId = "102";
                    if (comboBox101.SelectedItem.ToString() != findPluginName(0)) ButtonId = "101";
                    break;

                case "101":
                    ButtonId = "101";
                    if (comboBox100.SelectedItem.ToString() != findPluginName(0)) ButtonId = "100";
                    if (comboBox104.SelectedItem.ToString() != findPluginName(0)) ButtonId = "104";
                    if (comboBox103.SelectedItem.ToString() != findPluginName(0)) ButtonId = "103";
                    if (comboBox102.SelectedItem.ToString() != findPluginName(0)) ButtonId = "102";
                    break;

                case "102":
                    ButtonId = "102";
                    if (comboBox101.SelectedItem.ToString() != findPluginName(0)) ButtonId = "101";
                    if (comboBox100.SelectedItem.ToString() != findPluginName(0)) ButtonId = "100";
                    if (comboBox104.SelectedItem.ToString() != findPluginName(0)) ButtonId = "104";
                    if (comboBox103.SelectedItem.ToString() != findPluginName(0)) ButtonId = "103";
                    break;

                case "103":
                    ButtonId = "103";
                    if (comboBox102.SelectedItem.ToString() != findPluginName(0)) ButtonId = "102";
                    if (comboBox101.SelectedItem.ToString() != findPluginName(0)) ButtonId = "101";
                    if (comboBox100.SelectedItem.ToString() != findPluginName(0)) ButtonId = "100";
                    if (comboBox104.SelectedItem.ToString() != findPluginName(0)) ButtonId = "104";
                    break;

                case "104":
                    ButtonId = "104";
                    if (comboBox103.SelectedItem.ToString() != findPluginName(0)) ButtonId = "103";
                    if (comboBox102.SelectedItem.ToString() != findPluginName(0)) ButtonId = "102";
                    if (comboBox101.SelectedItem.ToString() != findPluginName(0)) ButtonId = "101";
                    if (comboBox100.SelectedItem.ToString() != findPluginName(0)) ButtonId = "100";
                    break;

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


        private String findButtonUp(String id)
        {

            String ButtonId = id;

            switch (id)
            {

                case "100":
                    ButtonId = "18";
                    if (comboBox110.SelectedItem.ToString() != findPluginName(0)) ButtonId = "110";
                    if (comboBox105.SelectedItem.ToString() != findPluginName(0)) ButtonId = "105";
                    break;

                case "101":
                    ButtonId = "18";
                    if (comboBox111.SelectedItem.ToString() != findPluginName(0)) ButtonId = "111";
                    if (comboBox106.SelectedItem.ToString() != findPluginName(0)) ButtonId = "106";
                    break;

                case "102":
                    ButtonId = "18";
                    if (comboBox112.SelectedItem.ToString() != findPluginName(0)) ButtonId = "112";
                    if (comboBox107.SelectedItem.ToString() != findPluginName(0)) ButtonId = "107";
                    break;

                case "103":
                    ButtonId = "18";
                    if (comboBox113.SelectedItem.ToString() != findPluginName(0)) ButtonId = "113";
                    if (comboBox108.SelectedItem.ToString() != findPluginName(0)) ButtonId = "108";
                    break;

                case "104":
                    ButtonId = "18";
                    if (comboBox114.SelectedItem.ToString() != findPluginName(0)) ButtonId = "114";
                    if (comboBox109.SelectedItem.ToString() != findPluginName(0)) ButtonId = "109";
                    break;

                case "105":
                    ButtonId = "18";
                    if (comboBox110.SelectedItem.ToString() != findPluginName(0)) ButtonId = "110";
                    break;

                case "106":
                    ButtonId = "18";
                    if (comboBox111.SelectedItem.ToString() != findPluginName(0)) ButtonId = "111";
                    break;

                case "107":
                    ButtonId = "18";
                    if (comboBox112.SelectedItem.ToString() != findPluginName(0)) ButtonId = "112";
                    break;

                case "108":
                    ButtonId = "18";
                    if (comboBox113.SelectedItem.ToString() != findPluginName(0)) ButtonId = "113";
                    break;

                case "109":
                    ButtonId = "18";
                    if (comboBox114.SelectedItem.ToString() != findPluginName(0)) ButtonId = "114";
                    break;

                case "110":
                    ButtonId = "18";
                    break;

                case "111":
                    ButtonId = "18";
                    break;

                case "112":
                    ButtonId = "18";
                    break;

                case "113":
                    ButtonId = "18";
                    break;

                case "114":
                    ButtonId = "18";
                    break;
            }

            return ButtonId;
        }


        private String findButtonDown(String id)
        {

            String ButtonId = id;

            switch (id)
            {

                case "100":
                    ButtonId = "1111";
                    break;

                case "101":
                    ButtonId = "1111";
                    break;

                case "102":
                    ButtonId = "1111";
                    break;

                case "103":
                    ButtonId = "1111";
                    break;

                case "104":
                    ButtonId = "1111";
                    break;

                case "105":
                    ButtonId = "1111";
                    if (comboBox100.SelectedItem.ToString() != findPluginName(0)) ButtonId = "100";
                    break;

                case "106":
                    ButtonId = "1111";
                    if (comboBox101.SelectedItem.ToString() != findPluginName(0)) ButtonId = "101";
                    break;

                case "107":
                    ButtonId = "1111";
                    if (comboBox102.SelectedItem.ToString() != findPluginName(0)) ButtonId = "102";
                    break;

                case "108":
                    ButtonId = "1111";
                    if (comboBox103.SelectedItem.ToString() != findPluginName(0)) ButtonId = "103";
                    break;

                case "109":
                    ButtonId = "1111";
                    if (comboBox104.SelectedItem.ToString() != findPluginName(0)) ButtonId = "104";
                    break;

                case "110":
                    ButtonId = "1111";
                    if (comboBox100.SelectedItem.ToString() != findPluginName(0)) ButtonId = "100";
                    if (comboBox105.SelectedItem.ToString() != findPluginName(0)) ButtonId = "105";
                    break;

                case "111":
                    ButtonId = "1111";
                    if (comboBox101.SelectedItem.ToString() != findPluginName(0)) ButtonId = "101";
                    if (comboBox106.SelectedItem.ToString() != findPluginName(0)) ButtonId = "106";
                    break;

                case "112":
                    ButtonId = "1111";
                    if (comboBox102.SelectedItem.ToString() != findPluginName(0)) ButtonId = "102";
                    if (comboBox107.SelectedItem.ToString() != findPluginName(0)) ButtonId = "107";
                    break;

                case "113":
                    ButtonId = "1111";
                    if (comboBox103.SelectedItem.ToString() != findPluginName(0)) ButtonId = "103";
                    if (comboBox108.SelectedItem.ToString() != findPluginName(0)) ButtonId = "108";
                    break;

                case "114":
                    ButtonId = "1111";
                    if (comboBox104.SelectedItem.ToString() != findPluginName(0)) ButtonId = "104";
                    if (comboBox109.SelectedItem.ToString() != findPluginName(0)) ButtonId = "109";
                    break;
            }

            return ButtonId;
        }


        private String buildHoverLabelXml(String id)
        {
            String labelTextbox = String.Empty;
            String delayOpen = String.Empty;
            String delayClose = String.Empty;

            switch (id)
            {
                case "100":
                    labelTextbox = SecurityElement.Escape(textBox100.Text);
                    delayOpen = "250"; delayClose = "0";
                    break;
                case "101":
                    labelTextbox = SecurityElement.Escape(textBox101.Text);
                    delayOpen = "250"; delayClose = "0";
                    break;
                case "102":
                    labelTextbox = SecurityElement.Escape(textBox102.Text);
                    delayOpen = "250"; delayClose = "0";
                    break;
                case "103":
                    labelTextbox = SecurityElement.Escape(textBox103.Text);
                    delayOpen = "250"; delayClose = "0";
                    break;
                case "104":
                    labelTextbox = SecurityElement.Escape(textBox104.Text);
                    delayOpen = "250"; delayClose = "0";
                    break;
                case "105":
                    labelTextbox = SecurityElement.Escape(textBox105.Text);
                    delayOpen = "250"; delayClose = "0";
                    break;
                case "106":
                    labelTextbox = SecurityElement.Escape(textBox106.Text);
                    delayOpen = "250"; delayClose = "0";
                    break;
                case "107":
                    labelTextbox = SecurityElement.Escape(textBox107.Text);
                    delayOpen = "250"; delayClose = "0";
                    break;
                case "108":
                    labelTextbox = SecurityElement.Escape(textBox108.Text);
                    delayOpen = "250"; delayClose = "0";
                    break;
                case "109":
                    labelTextbox = SecurityElement.Escape(textBox109.Text);
                    delayOpen = "250"; delayClose = "0";
                    break;
                case "110":
                    labelTextbox = SecurityElement.Escape(textBox110.Text);
                    delayOpen = "250"; delayClose = "0";
                    break;
                case "111":
                    labelTextbox = SecurityElement.Escape(textBox111.Text);
                    delayOpen = "250"; delayClose = "0";
                    break;
                case "112":
                    labelTextbox = SecurityElement.Escape(textBox112.Text);
                    delayOpen = "250"; delayClose = "0";
                    break;
                case "113":
                    labelTextbox = SecurityElement.Escape(textBox113.Text);
                    delayOpen = "250"; delayClose = "0";
                    break;
                case "114":
                    labelTextbox = SecurityElement.Escape(textBox114.Text);
                    delayOpen = "250"; delayClose = "0";
                    break;
            }


            String xmloutput = @"<!-- ID " + id + @" -->
		<control>
			<description>" + id + @" hover label</description>
			<type>label</type>
			<id>0</id>
			<posX>0</posX>
			<posY>927</posY>
			<width>1920</width>
			<label>" + labelTextbox + @"</label>
			<font>font40</font>
			<align>center</align>
			<visible>control.hasfocus(" + id + @")</visible>
			<animation effect=""fade"" time=""150"">VisibleChange</animation>
            <animation effect=""fade"" time=""250"" delay=""" + delayOpen + @""">WindowOpen</animation>
			<animation effect=""fade"" time=""250"" delay=""" + delayClose + @""">WindowClose</animation>
		</control>";

            return xmloutput;
        }


        private String buildButtonXml(String id)
        {
            String labelTextbox = String.Empty;
            String idTextbox = String.Empty;
            String labelTextboxParameter = String.Empty;
            String delayOpen = String.Empty;
            String delayClose = String.Empty;
            String posX = String.Empty;
            String posY = String.Empty;
            String width = String.Empty;
            String height = String.Empty;

            switch (id)
            {
                case "100":
                    labelTextbox = SecurityElement.Escape(textBox100.Text); idTextbox = SecurityElement.Escape(textBoxid100.Text);
                    labelTextboxParameter = SecurityElement.Escape(textBoxParameter100.Text);
                    delayOpen = "83"; delayClose = "167"; posX = "150"; posY = "597"; width = "358"; height = "367";
                    break;
                case "101":
                    labelTextbox = SecurityElement.Escape(textBox101.Text); idTextbox = SecurityElement.Escape(textBoxid101.Text);
                    labelTextboxParameter = SecurityElement.Escape(textBoxParameter101.Text);
                    delayOpen = "167"; delayClose = "83"; posX = "504"; posY = "615"; width = "313"; height = "321";
                    break;
                case "102":
                    labelTextbox = SecurityElement.Escape(textBox102.Text); idTextbox = SecurityElement.Escape(textBoxid102.Text);
                    labelTextboxParameter = SecurityElement.Escape(textBoxParameter102.Text);
                    delayOpen = "250"; delayClose = "0"; posX = "813"; posY = "621"; width = "294"; height = "307";
                    break;
                case "103":
                    labelTextbox = SecurityElement.Escape(textBox103.Text); idTextbox = SecurityElement.Escape(textBoxid103.Text);
                    labelTextboxParameter = SecurityElement.Escape(textBoxParameter103.Text);
                    delayOpen = "167"; delayClose = "83"; posX = "1104"; posY = "615"; width = "313"; height = "322";
                    break;
                case "104":
                    labelTextbox = SecurityElement.Escape(textBox104.Text); idTextbox = SecurityElement.Escape(textBoxid104.Text);
                    labelTextboxParameter = SecurityElement.Escape(textBoxParameter104.Text);
                    delayOpen = "83"; delayClose = "167"; posX = "1411"; posY = "597"; width = "358"; height = "363";
                    break;
                case "105":
                    labelTextbox = SecurityElement.Escape(textBox105.Text); idTextbox = SecurityElement.Escape(textBoxid105.Text);
                    labelTextboxParameter = SecurityElement.Escape(textBoxParameter105.Text);
                    delayOpen = "83"; delayClose = "167"; posX = "171"; posY = "346"; width = "348"; height = "274";
                    break;
                case "106":
                    labelTextbox = SecurityElement.Escape(textBox106.Text); idTextbox = SecurityElement.Escape(textBoxid106.Text);
                    labelTextboxParameter = SecurityElement.Escape(textBoxParameter106.Text);
                    delayOpen = "167"; delayClose = "83"; posX = "513"; posY = "405"; width = "307"; height = "226";
                    break;
                case "107":
                    labelTextbox = SecurityElement.Escape(textBox107.Text); idTextbox = SecurityElement.Escape(textBoxid107.Text);
                    labelTextboxParameter = SecurityElement.Escape(textBoxParameter107.Text);
                    delayOpen = "250"; delayClose = "0"; posX = "814"; posY = "429"; width = "291"; height = "205";
                    break;
                case "108":
                    labelTextbox = SecurityElement.Escape(textBox108.Text); idTextbox = SecurityElement.Escape(textBoxid108.Text);
                    labelTextboxParameter = SecurityElement.Escape(textBoxParameter108.Text);
                    delayOpen = "167"; delayClose = "83"; posX = "1099"; posY = "405"; width = "307"; height = "226";
                    break;
                case "109":
                    labelTextbox = SecurityElement.Escape(textBox109.Text); idTextbox = SecurityElement.Escape(textBoxid109.Text);
                    labelTextboxParameter = SecurityElement.Escape(textBoxParameter109.Text);
                    delayOpen = "83"; delayClose = "167"; posX = "1402"; posY = "346"; width = "348"; height = "274";
                    break;
                case "110":
                    labelTextbox = SecurityElement.Escape(textBox110.Text); idTextbox = SecurityElement.Escape(textBoxid110.Text);
                    labelTextboxParameter = SecurityElement.Escape(textBoxParameter110.Text);
                    delayOpen = "83"; delayClose = "167"; posX = "189"; posY = "114"; width = "339"; height = "294";
                    break;
                case "111":
                    labelTextbox = SecurityElement.Escape(textBox111.Text); idTextbox = SecurityElement.Escape(textBoxid111.Text);
                    labelTextboxParameter = SecurityElement.Escape(textBoxParameter111.Text);
                    delayOpen = "167"; delayClose = "83"; posX = "522"; posY = "207"; width = "301"; height = "231";
                    break;
                case "112":
                    labelTextbox = SecurityElement.Escape(textBox112.Text); idTextbox = SecurityElement.Escape(textBoxid112.Text);
                    labelTextboxParameter = SecurityElement.Escape(textBoxParameter112.Text);
                    delayOpen = "250"; delayClose = "0"; posX = "817"; posY = "242"; width = "285"; height = "199";
                    break;
                case "113":
                    labelTextbox = SecurityElement.Escape(textBox113.Text); idTextbox = SecurityElement.Escape(textBoxid113.Text);
                    labelTextboxParameter = SecurityElement.Escape(textBoxParameter113.Text);
                    delayOpen = "167"; delayClose = "83"; posX = "1096"; posY = "207"; width = "301"; height = "231";
                    break;
                case "114":
                    labelTextbox = SecurityElement.Escape(textBox114.Text); idTextbox = SecurityElement.Escape(textBoxid114.Text);
                    labelTextboxParameter = SecurityElement.Escape(textBoxParameter114.Text);
                    delayOpen = "83"; delayClose = "167"; posX = "1393"; posY = "114"; width = "337"; height = "294";
                    break;
            }

            String xmloutput = @" 
		<control>
			<description>" + id + @" button</description>
			<type>button</type>
			<id>" + id + @"</id>
			<posX>" + posX + @"</posX>
			<posY>" + posY + @"</posY>
			<width>" + width + @"</width>
			<height>" + height + @"</height>
			<label>" + labelTextbox + @"</label>
			<textXOff>4500</textXOff>
			<hyperlink>" + idTextbox + @"</hyperlink>
			<hyperlinkParameter>" + labelTextboxParameter + @"</hyperlinkParameter> 
			<onleft>" + findButtonLeft(id) + @"</onleft>
			<onright>" + findButtonRight(id) + @"</onright>
			<onup>" + findButtonUp(id) + @"</onup>
			<ondown>" + findButtonDown(id) + @"</ondown>
			<textureFocus>basichome_" + id + @"_focus.png</textureFocus>
			<textureNoFocus>basichome_" + id + @"_nofocus.png</textureNoFocus>
            <animation effect=""fade"" time=""250"" delay=""" + delayOpen + @""">WindowOpen</animation>
			<animation effect=""fade"" time=""250"" delay=""" + delayClose + @""">WindowClose</animation>
		</control>


        ";

            return xmloutput;
        }


        private String buildFanartImageXml(String id)
        {
            String labelTextbox = String.Empty;
            String idTextbox = String.Empty;
            String delayOpen = String.Empty;
            String delayClose = String.Empty;
            String posX = String.Empty;
            String posY = String.Empty;
            String width = String.Empty;
            String height = String.Empty;
            String plugin_trick = String.Empty;
            String pictures_plugin_trick1 = String.Empty;
            String pictures_plugin_trick2 = String.Empty;
            String pictures_plugin_trick3 = String.Empty;
            String plugin_name = String.Empty;
            String texture_name1 = String.Empty;
            String texture_name2 = String.Empty;
            String texture_name3 = String.Empty;
            String text_trick1 = String.Empty;
            String text_trick2 = String.Empty;
            String text_trick3 = String.Empty;
            Decimal fanartLevel = 1M;
            String fanartLabel1 = String.Empty;
            String fanartLabel2 = String.Empty;
            String fanartLabel3 = String.Empty;


            switch (id)
            {
                case "100":
                    labelTextbox = SecurityElement.Escape(textBox100.Text); idTextbox = SecurityElement.Escape(textBoxid100.Text); fanartLevel = numericUpDown100.Value;
                    delayOpen = "83"; delayClose = "167"; posX = "100"; posY = "398"; width = "239"; height = "245";
                    break;
                case "101":
                    labelTextbox = SecurityElement.Escape(textBox101.Text); idTextbox = SecurityElement.Escape(textBoxid101.Text); fanartLevel = numericUpDown101.Value;
                    delayOpen = "167"; delayClose = "83"; posX = "336"; posY = "410"; width = "209"; height = "214";
                    break;
                case "102":
                    labelTextbox = SecurityElement.Escape(textBox102.Text); idTextbox = SecurityElement.Escape(textBoxid102.Text); fanartLevel = numericUpDown102.Value;
                    delayOpen = "250"; delayClose = "0"; posX = "542"; posY = "414"; width = "196"; height = "205";
                    break;
                case "103":
                    labelTextbox = SecurityElement.Escape(textBox103.Text); idTextbox = SecurityElement.Escape(textBoxid103.Text); fanartLevel = numericUpDown103.Value;
                    delayOpen = "167"; delayClose = "83"; posX = "736"; posY = "410"; width = "209"; height = "215";
                    break;
                case "104":
                    labelTextbox = SecurityElement.Escape(textBox104.Text); idTextbox = SecurityElement.Escape(textBoxid104.Text); fanartLevel = numericUpDown104.Value;
                    delayOpen = "83"; delayClose = "167"; posX = "941"; posY = "398"; width = "239"; height = "242";
                    break;
                case "105":
                    labelTextbox = SecurityElement.Escape(textBox105.Text); idTextbox = SecurityElement.Escape(textBoxid105.Text); fanartLevel = numericUpDown105.Value;
                    delayOpen = "83"; delayClose = "167"; posX = "185"; posY = "356"; width = "319"; height = "241";
                    break;
                case "106":
                    labelTextbox = SecurityElement.Escape(textBox106.Text); idTextbox = SecurityElement.Escape(textBoxid106.Text); fanartLevel = numericUpDown106.Value;
                    delayOpen = "167"; delayClose = "83"; posX = "528"; posY = "414"; width = "277"; height = "194";
                    break;
                case "107":
                    labelTextbox = SecurityElement.Escape(textBox107.Text); idTextbox = SecurityElement.Escape(textBoxid107.Text); fanartLevel = numericUpDown107.Value;
                    delayOpen = "250"; delayClose = "0"; posX = "829"; posY = "439"; width = "261"; height = "172";
                    break;
                case "108":
                    labelTextbox = SecurityElement.Escape(textBox108.Text); idTextbox = SecurityElement.Escape(textBoxid108.Text); fanartLevel = numericUpDown108.Value;
                    delayOpen = "167"; delayClose = "83"; posX = "1114"; posY = "414"; width = "278"; height = "194";
                    break;
                case "109":
                    labelTextbox = SecurityElement.Escape(textBox109.Text); idTextbox = SecurityElement.Escape(textBoxid109.Text); fanartLevel = numericUpDown109.Value;
                    delayOpen = "83"; delayClose = "167"; posX = "1417"; posY = "356"; width = "318"; height = "241";
                    break;
                case "110":
                    labelTextbox = SecurityElement.Escape(textBox110.Text); idTextbox = SecurityElement.Escape(textBoxid110.Text); fanartLevel = numericUpDown110.Value;
                    delayOpen = "83"; delayClose = "167"; posX = "203"; posY = "123"; width = "310"; height = "263";
                    break;
                case "111":
                    labelTextbox = SecurityElement.Escape(textBox111.Text); idTextbox = SecurityElement.Escape(textBoxid111.Text); fanartLevel = numericUpDown111.Value;
                    delayOpen = "167"; delayClose = "83"; posX = "537"; posY = "217"; width = "271"; height = "199";
                    break;
                case "112":
                    labelTextbox = SecurityElement.Escape(textBox112.Text); idTextbox = SecurityElement.Escape(textBoxid112.Text); fanartLevel = numericUpDown112.Value;
                    delayOpen = "250"; delayClose = "0"; posX = "832"; posY = "253"; width = "254"; height = "166";
                    break;
                case "113":
                    labelTextbox = SecurityElement.Escape(textBox113.Text); idTextbox = SecurityElement.Escape(textBoxid113.Text); fanartLevel = numericUpDown113.Value;
                    delayOpen = "167"; delayClose = "83"; posX = "1111"; posY = "216"; width = "272"; height = "199";
                    break;
                case "114":
                    labelTextbox = SecurityElement.Escape(textBox114.Text); idTextbox = SecurityElement.Escape(textBoxid114.Text); fanartLevel = numericUpDown114.Value;
                    delayOpen = "83"; delayClose = "167"; posX = "1408"; posY = "123"; width = "308"; height = "263";
                    break;
            }


            if (fanartLevel == 1.0M)
            {
                texture_name1 = findFanartTexture(idTextbox, "1");
                pictures_plugin_trick1 = "+!string.contains(#fanarthandler.picture.latest1.thumb,Folder.jpg)";
                text_trick1 = findTextTrick(idTextbox, "1");
                fanartLabel1 = findFanartLabel(idTextbox, "1");
            }
            if (fanartLevel == 2.0M)
            {
                texture_name1 = findFanartTexture(idTextbox, "2"); texture_name2 = findFanartTexture(idTextbox, "1");
                pictures_plugin_trick1 = "+!string.contains(#fanarthandler.picture.latest2.thumb,Folder.jpg)"; pictures_plugin_trick2 = "+!string.contains(#fanarthandler.picture.latest1.thumb,Folder.jpg)";
                text_trick1 = findTextTrick(idTextbox, "2"); text_trick2 = findTextTrick(idTextbox, "1");
                fanartLabel1 = findFanartLabel(idTextbox, "2"); fanartLabel2 = findFanartLabel(idTextbox, "1");
            }
            if (fanartLevel == 3.0M)
            {
                texture_name1 = findFanartTexture(idTextbox, "3"); texture_name2 = findFanartTexture(idTextbox, "2"); texture_name3 = findFanartTexture(idTextbox, "1");
                pictures_plugin_trick1 = "+!string.contains(#fanarthandler.picture.latest3.thumb,Folder.jpg)"; pictures_plugin_trick2 = "+!string.contains(#fanarthandler.picture.latest2.thumb,Folder.jpg)"; pictures_plugin_trick3 = "+!string.contains(#fanarthandler.picture.latest1.thumb,Folder.jpg)";
                text_trick1 = findTextTrick(idTextbox, "3"); text_trick2 = findTextTrick(idTextbox, "2"); text_trick3 = findTextTrick(idTextbox, "1");
                fanartLabel1 = findFanartLabel(idTextbox, "3"); fanartLabel2 = findFanartLabel(idTextbox, "2"); fanartLabel3 = findFanartLabel(idTextbox, "1");
            }


            plugin_name = findFanartPluginName(idTextbox);
            if (idTextbox != "2") { pictures_plugin_trick1 = String.Empty; pictures_plugin_trick2 = String.Empty; pictures_plugin_trick3 = String.Empty; }


            String xmloutput = String.Empty;

            if (fanartLevel == 1.0M) xmloutput = @" 
		<control>
			<description>" + id + @"00 fanart focused</description>
			<type>image</type>
			<id>" + id + @"00</id>
			<posX>" + posX + @"</posX>
			<posY>" + posY + @"</posY>
			<width>" + width + @"</width>
			<height>" + height + @"</height>
			<keepaspectratio>yes</keepaspectratio>
			<centered>yes</centered>
			<zoom>yes</zoom>
			<texture mask=""basichome_" + id + @"_mask.png"">" + texture_name1 + @"</texture>
			<visible>plugin.isenabled(Fanart Handler)+plugin.isenabled(" + plugin_name + @")+control.hasfocus(" + id + @")" + pictures_plugin_trick1 + @"</visible>
			<animation effect=""fade"" time=""250"" delay=""" + delayOpen + @""">WindowOpen</animation>
			<animation effect=""fade"" time=""250"" delay=""" + delayClose + @""">WindowClose</animation>
            <animation effect=""fade"" time=""100"" delay=""1000"">visible</animation>
		</control>
        <control>
			<description>" + id + @"00 fanart text</description>
			<type>label</type>
			<id>0</id>
			<posX>0</posX>
			<posY>999</posY>
			<width>1920</width>
			<label>" + fanartLabel1 + @"</label>
			<align>center</align>
			<font>font11</font>
			<visible>control.isvisible(" + id + @"00)+plugin.isenabled(Fanart Handler)+plugin.isenabled(" + plugin_name + @")+control.hasfocus(" + id + @")" + text_trick1 + @"</visible>
			<textcolor>90ffffff</textcolor>
			<animation effect=""fade"" time=""100"">visible</animation>
			<animation effect=""fade"" time=""250"" delay=""250"">WindowOpen</animation>
			<animation effect=""fade"" time=""250"" delay=""0"">WindowClose</animation>
		</control>

        ";

            if (fanartLevel == 2.0M) xmloutput = @" 
		<control>
			<description>" + id + @"00 fanart focused</description>
			<type>image</type>
			<id>" + id + @"00</id>
			<posX>" + posX + @"</posX>
			<posY>" + posY + @"</posY>
			<width>" + width + @"</width>
			<height>" + height + @"</height>
			<keepaspectratio>yes</keepaspectratio>
			<centered>yes</centered>
			<zoom>yes</zoom>
			<texture mask=""basichome_" + id + @"_mask.png"">" + texture_name1 + @"</texture>
			<visible>!control.isvisible(" + id + @"01)+plugin.isenabled(Fanart Handler)+plugin.isenabled(" + plugin_name + @")+control.hasfocus(" + id + @")" + pictures_plugin_trick1 + @"</visible>
			<animation effect=""fade"" time=""250"" delay=""" + delayOpen + @""">WindowOpen</animation>
			<animation effect=""fade"" time=""250"" delay=""" + delayClose + @""">WindowClose</animation>
            <animation effect=""fade"" time=""100"" delay=""1000"">visible</animation>
            <animation effect=""fade"" time=""100"">hidden</animation>
		</control>
        <control>
			<description>" + id + @"00 fanart text</description>
			<type>label</type>
			<id>0</id>
			<posX>0</posX>
			<posY>999</posY>
			<width>1920</width>
			<label>" + fanartLabel1 + @"</label>
			<align>center</align>
			<font>font11</font>
			<visible>control.isvisible(" + id + @"00)+plugin.isenabled(Fanart Handler)+plugin.isenabled(" + plugin_name + @")+control.hasfocus(" + id + @")" + text_trick1 + @"</visible>
			<textcolor>90ffffff</textcolor>
			<animation effect=""fade"" time=""100"">visible</animation>
			<animation effect=""fade"" time=""250"" delay=""250"">WindowOpen</animation>
			<animation effect=""fade"" time=""250"" delay=""0"">WindowClose</animation>
		</control>
        <control>
			<description>" + id + @"01 fanart focused</description>
			<type>image</type>
			<id>" + id + @"01</id>
			<posX>" + posX + @"</posX>
			<posY>" + posY + @"</posY>
			<width>" + width + @"</width>
			<height>" + height + @"</height>
			<keepaspectratio>yes</keepaspectratio>
			<centered>yes</centered>
			<zoom>yes</zoom>
			<texture mask=""basichome_" + id + @"_mask.png"">" + texture_name2 + @"</texture>
			<visible>plugin.isenabled(Fanart Handler)+plugin.isenabled(" + plugin_name + @")+control.hasfocus(" + id + @")" + pictures_plugin_trick2 + @"</visible>
			<animation effect=""fade"" time=""250"" delay=""" + delayOpen + @""">WindowOpen</animation>
			<animation effect=""fade"" time=""250"" delay=""" + delayClose + @""">WindowClose</animation>
            <animation effect=""fade"" time=""100"" delay=""3000"">visible</animation>
		</control>
        <control>
			<description>" + id + @"01 fanart text</description>
			<type>label</type>
			<id>0</id>
			<posX>0</posX>
			<posY>999</posY>
			<width>1920</width>
			<label>" + fanartLabel2 + @"</label>
			<align>center</align>
			<font>font11</font>
			<visible>control.isvisible(" + id + @"01)+plugin.isenabled(Fanart Handler)+plugin.isenabled(" + plugin_name + @")+control.hasfocus(" + id + @")" + text_trick2 + @"</visible>
			<textcolor>90ffffff</textcolor>
			<animation effect=""fade"" time=""100"">visible</animation>
			<animation effect=""fade"" time=""250"" delay=""250"">WindowOpen</animation>
			<animation effect=""fade"" time=""250"" delay=""0"">WindowClose</animation>
		</control>

        ";

            if (fanartLevel == 3.0M) xmloutput = @" 
		<control>
			<description>" + id + @"00 fanart focused</description>
			<type>image</type>
			<id>" + id + @"00</id>
			<posX>" + posX + @"</posX>
			<posY>" + posY + @"</posY>
			<width>" + width + @"</width>
			<height>" + height + @"</height>
			<keepaspectratio>yes</keepaspectratio>
			<centered>yes</centered>
			<zoom>yes</zoom>
			<texture mask=""basichome_" + id + @"_mask.png"">" + texture_name1 + @"</texture>
			<visible>!control.isvisible(" + id + @"01)+!control.isvisible(" + id + @"02)+plugin.isenabled(Fanart Handler)+plugin.isenabled(" + plugin_name + @")+control.hasfocus(" + id + @")" + pictures_plugin_trick1 + @"</visible>
			<animation effect=""fade"" time=""250"" delay=""" + delayOpen + @""">WindowOpen</animation>
			<animation effect=""fade"" time=""250"" delay=""" + delayClose + @""">WindowClose</animation>
            <animation effect=""fade"" time=""100"" delay=""1000"">visible</animation>
            <animation effect=""fade"" time=""100"">hidden</animation>
		</control>
        <control>
			<description>" + id + @"00 fanart text</description>
			<type>label</type>
			<id>0</id>
			<posX>0</posX>
			<posY>999</posY>
			<width>1920</width>
			<label>" + fanartLabel1 + @"</label>
			<align>center</align>
			<font>font11</font>
			<visible>control.isvisible(" + id + @"00)+plugin.isenabled(Fanart Handler)+plugin.isenabled(" + plugin_name + @")+control.hasfocus(" + id + @")" + text_trick1 + @"</visible>
			<textcolor>90ffffff</textcolor>
			<animation effect=""fade"" time=""100"">visible</animation>
			<animation effect=""fade"" time=""250"" delay=""250"">WindowOpen</animation>
			<animation effect=""fade"" time=""250"" delay=""0"">WindowClose</animation>
		</control>
        <control>
			<description>" + id + @"01 fanart focused</description>
			<type>image</type>
			<id>" + id + @"01</id>
			<posX>" + posX + @"</posX>
			<posY>" + posY + @"</posY>
			<width>" + width + @"</width>
			<height>" + height + @"</height>
			<keepaspectratio>yes</keepaspectratio>
			<centered>yes</centered>
			<zoom>yes</zoom>
			<texture mask=""basichome_" + id + @"_mask.png"">" + texture_name2 + @"</texture>
			<visible>!control.isvisible(" + id + @"02)+plugin.isenabled(Fanart Handler)+plugin.isenabled(" + plugin_name + @")+control.hasfocus(" + id + @")" + pictures_plugin_trick2 + @"</visible>
			<animation effect=""fade"" time=""250"" delay=""" + delayOpen + @""">WindowOpen</animation>
			<animation effect=""fade"" time=""250"" delay=""" + delayClose + @""">WindowClose</animation>
            <animation effect=""fade"" time=""100"" delay=""3000"">visible</animation>
            <animation effect=""fade"" time=""100"">hidden</animation>
		</control>
        <control>
			<description>" + id + @"01 fanart text</description>
			<type>label</type>
			<id>0</id>
			<posX>0</posX>
			<posY>999</posY>
			<width>1920</width>
			<label>" + fanartLabel2 + @"</label>
			<align>center</align>
			<font>font11</font>
			<visible>control.isvisible(" + id + @"01)+plugin.isenabled(Fanart Handler)+plugin.isenabled(" + plugin_name + @")+control.hasfocus(" + id + @")" + text_trick2 + @"</visible>
			<textcolor>90ffffff</textcolor>
			<animation effect=""fade"" time=""100"">visible</animation>
			<animation effect=""fade"" time=""250"" delay=""250"">WindowOpen</animation>
			<animation effect=""fade"" time=""250"" delay=""0"">WindowClose</animation>
		</control>
        <control>
			<description>" + id + @"02 fanart focused</description>
			<type>image</type>
			<id>" + id + @"02</id>
			<posX>" + posX + @"</posX>
			<posY>" + posY + @"</posY>
			<width>" + width + @"</width>
			<height>" + height + @"</height>
			<keepaspectratio>yes</keepaspectratio>
			<centered>yes</centered>
			<zoom>yes</zoom>
			<texture mask=""basichome_" + id + @"_mask.png"">" + texture_name3 + @"</texture>
			<visible>plugin.isenabled(Fanart Handler)+plugin.isenabled(" + plugin_name + @")+control.hasfocus(" + id + @")" + pictures_plugin_trick3 + @"</visible>
			<animation effect=""fade"" time=""250"" delay=""" + delayOpen + @""">WindowOpen</animation>
			<animation effect=""fade"" time=""250"" delay=""" + delayClose + @""">WindowClose</animation>
            <animation effect=""fade"" time=""100"" delay=""5000"">visible</animation>
		</control>
        <control>
			<description>" + id + @"02 fanart text</description>
			<type>label</type>
			<id>0</id>
			<posX>0</posX>
			<posY>999</posY>
			<width>1920</width>
			<label>" + fanartLabel3 + @"</label>
			<align>center</align>
			<font>font11</font>
			<visible>control.isvisible(" + id + @"02)+plugin.isenabled(Fanart Handler)+plugin.isenabled(" + plugin_name + @")+control.hasfocus(" + id + @")" + text_trick3 + @"</visible>
			<textcolor>90ffffff</textcolor>
			<animation effect=""fade"" time=""100"">visible</animation>
			<animation effect=""fade"" time=""250"" delay=""250"">WindowOpen</animation>
			<animation effect=""fade"" time=""250"" delay=""0"">WindowClose</animation>
		</control>


        ";

            return xmloutput;
        }


        private void numericUpDownColor_ValueChanged(object sender, EventArgs e)
        {
            radioButtonCustomColor.Checked = true;

            Assembly myAssembly = Assembly.GetExecutingAssembly();
            Stream myStream = myAssembly.GetManifestResourceStream("BlackGlassEditor.Images.blue_bg_sample.png");


            ImageManipulator im = new ImageManipulator(new Bitmap(myStream));
            String newvalue = numericUpDownColor.Value.ToString();
            radioButtonCustomColor.BackgroundImage = (Bitmap)im.RotateHue(float.Parse(newvalue));

        }


        private String findFanartPluginName(String id)
        {
            String plugin_name = "";
            switch (id)
            {
                case "504":
                    plugin_name = "Music";
                    break;
                case "501":
                    plugin_name = "Music";
                    break;
                case "1":
                    plugin_name = "TV";
                    break;
                case "2":
                    plugin_name = "Pictures";
                    break;
                case "96742":
                    plugin_name = "Moving Pictures";
                    break;
                case "9811":
                    plugin_name = "MP-TV Series";
                    break;
                case "2600":
                    plugin_name = "InfoService";
                    break;
                default:
                    break;
            }
            return plugin_name;
        }

        private String findFanartTexture(String id, String level)
        {
            String texture = "";
            switch (id)
            {
                case "504":
                    texture = "#fanarthandler.music.latest" + level + ".fanart1";
                    break;
                case "501":
                    texture = "#fanarthandler.music.latest" + level + ".fanart1";
                    break;
                case "1":
                    texture = "#fanarthandler.tvrecordings.latest" + level + ".thumb";
                    break;
                case "2":
                    texture = "#fanarthandler.picture.latest" + level + ".thumb";
                    break;
                case "96742":
                    texture = "#fanarthandler.movingpicture.latest" + level + ".fanart";
                    break;
                case "9811":
                    texture = "#fanarthandler.tvseries.latest" + level + ".fanart";
                    break;
                case "2600":
                    if (level == "1") texture = "animations\\weather\\#infoservice.weather.today.img.big.filenamewithoutext.jpg";
                    if (level == "2") texture = "animations\\weather\\#infoservice.weather.forecast2.day.img.big.filenamewithoutext.jpg";
                    if (level == "3") texture = "animations\\weather\\#infoservice.weather.forecast3.day.img.big.filenamewithoutext.jpg";
                    break;
                default:
                    break;
            }
            return texture;
        }

        private String findTextTrick(String id, String level)
        {
            String trick = "";
            switch (id)
            {
                case "504":
                    trick = "+!string.equals(#fanarthandler.music.latest" + level + ".album,)";
                    break;
                case "501":
                    trick = "+!string.equals(#fanarthandler.music.latest" + level + ".album,)";
                    break;
                case "1":
                    trick = "+!string.equals(#fanarthandler.tvrecordings.latest" + level + ".title,)";
                    break;
                case "2":
                    trick = "+!string.equals(#fanarthandler.picture.latest" + level + ".filename,)";
                    break;
                case "96742":
                    trick = "+!string.equals(#fanarthandler.movingpicture.latest" + level + ".title,)";
                    break;
                case "9811":
                    trick = "+!string.equals(#fanarthandler.tvseries.latest" + level + ".episodeName,)";
                    break;
                case "2600":
                    if (level == "1") trick = "+!string.equals(#infoservice.weather.today.condition,)";
                    if (level == "2") trick = "+!string.equals(#infoservice.weather.forecast2.day.condition,)";
                    if (level == "3") trick = "+!string.equals(#infoservice.weather.forecast3.day.condition,)";
                    break;
                default:
                    break;
            }
            return trick;
        }

        private String findFanartLabel(String id, String level)
        {
            String FanartLabel = "";
            switch (id)
            {
                case "504":
                    FanartLabel = "#fanarthandler.music.latest" + level + ".dateAdded:     #fanarthandler.music.latest" + level + ".artist     #fanarthandler.music.latest" + level + ".album     #fanarthandler.music.latest" + level + ".genre";
                    break;
                case "501":
                    FanartLabel = "#fanarthandler.music.latest" + level + ".dateAdded:     #fanarthandler.music.latest" + level + ".artist     #fanarthandler.music.latest" + level + ".album     #fanarthandler.music.latest" + level + ".genre";
                    break;
                case "1":
                    FanartLabel = "#fanarthandler.tvrecordings.latest" + level + ".dateAdded:     #fanarthandler.tvrecordings.latest" + level + ".title     #fanarthandler.tvrecordings.latest" + level + ".genre";
                    break;
                case "2":
                    FanartLabel = "#fanarthandler.picture.latest" + level + ".dateAdded:     #fanarthandler.picture.latest" + level + ".filename";
                    break;
                case "96742":
                    FanartLabel = "#fanarthandler.movingpicture.latest" + level + ".dateAdded:     #fanarthandler.movingpicture.latest" + level + ".title     #fanarthandler.movingpicture.latest" + level + ".runtime     #fanarthandler.movingpicture.latest" + level + ".genre     #fanarthandler.movingpicture.latest" + level + ".year";
                    break;
                case "9811":
                    FanartLabel = "#fanarthandler.tvseries.latest" + level + ".dateAdded:     #fanarthandler.tvseries.latest" + level + ".serieName     #fanarthandler.tvseries.latest" + level + ".seasonIndexx#fanarthandler.tvseries.latest" + level + ".episodeIndex - #fanarthandler.tvseries.latest" + level + ".episodeName     #fanarthandler.tvseries.latest" + level + ".runtime";
                    break;
                case "2600":
                    if (level == "1") FanartLabel = "#infoservice.weather.today.weekday:     #infoservice.weather.today.temp     #infoservice.weather.today.humidity     #infoservice.weather.today.condition     #infoservice.weather.location";
                    if (level == "2") FanartLabel = "#infoservice.weather.forecast2.weekday:     #infoservice.weather.forecast2.day.humidity     #infoservice.weather.forecast2.day.condition     #infoservice.weather.location";
                    if (level == "3") FanartLabel = "#infoservice.weather.forecast3.weekday:     #infoservice.weather.forecast3.day.humidity     #infoservice.weather.forecast3.day.condition     #infoservice.weather.location";
                    break;
                default:
                    break;
            }
            return FanartLabel;
        }

        private void buttonOptions110_Click(object sender, EventArgs e)
        {
            OptionsDialog myOptionDialog = new OptionsDialog();
            myOptionDialog.Id = textBoxid110.Text;
            myOptionDialog.Description = textBox110.Text;
            myOptionDialog.Parameter = textBoxParameter110.Text;
            myOptionDialog.Text = "Button 110 Options";
            myOptionDialog.Fanart = checkBox110.Checked;
            myOptionDialog.Levels = numericUpDown110.Value;
            myOptionDialog.ShowFanartControls = true;

            if (myOptionDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxid110.Text = myOptionDialog.Id;
                textBox110.Text = myOptionDialog.Description;
                textBoxParameter110.Text = myOptionDialog.Parameter;
                checkBox110.Checked = myOptionDialog.Fanart;
                numericUpDown110.Value = myOptionDialog.Levels;
            }
        }

        private void buttonOptions111_Click(object sender, EventArgs e)
        {
            OptionsDialog myOptionDialog = new OptionsDialog();
            myOptionDialog.Id = textBoxid111.Text;
            myOptionDialog.Description = textBox111.Text;
            myOptionDialog.Parameter = textBoxParameter111.Text;
            myOptionDialog.Text = "Button 111 Options";
            myOptionDialog.Fanart = checkBox111.Checked;
            myOptionDialog.Levels = numericUpDown111.Value;
            myOptionDialog.ShowFanartControls = true;

            if (myOptionDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxid111.Text = myOptionDialog.Id;
                textBox111.Text = myOptionDialog.Description;
                textBoxParameter111.Text = myOptionDialog.Parameter;
                checkBox111.Checked = myOptionDialog.Fanart;
                numericUpDown111.Value = myOptionDialog.Levels;
            }
        }

        private void buttonOptions112_Click(object sender, EventArgs e)
        {
            OptionsDialog myOptionDialog = new OptionsDialog();
            myOptionDialog.Id = textBoxid112.Text;
            myOptionDialog.Description = textBox112.Text;
            myOptionDialog.Parameter = textBoxParameter112.Text;
            myOptionDialog.Text = "Button 112 Options";
            myOptionDialog.Fanart = checkBox112.Checked;
            myOptionDialog.Levels = numericUpDown112.Value;
            myOptionDialog.ShowFanartControls = true;

            if (myOptionDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxid112.Text = myOptionDialog.Id;
                textBox112.Text = myOptionDialog.Description;
                textBoxParameter112.Text = myOptionDialog.Parameter;
                checkBox112.Checked = myOptionDialog.Fanart;
                numericUpDown112.Value = myOptionDialog.Levels;
            }
        }

        private void buttonOptions113_Click(object sender, EventArgs e)
        {
            OptionsDialog myOptionDialog = new OptionsDialog();
            myOptionDialog.Id = textBoxid113.Text;
            myOptionDialog.Description = textBox113.Text;
            myOptionDialog.Parameter = textBoxParameter113.Text;
            myOptionDialog.Fanart = checkBox113.Checked;
            myOptionDialog.Levels = numericUpDown113.Value;
            myOptionDialog.ShowFanartControls = true;

            myOptionDialog.Text = "Button 113 Options";

            if (myOptionDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxid113.Text = myOptionDialog.Id;
                textBox113.Text = myOptionDialog.Description;
                textBoxParameter113.Text = myOptionDialog.Parameter;
                checkBox113.Checked = myOptionDialog.Fanart;
                numericUpDown113.Value = myOptionDialog.Levels;
            }
        }

        private void buttonOptions114_Click(object sender, EventArgs e)
        {
            OptionsDialog myOptionDialog = new OptionsDialog();
            myOptionDialog.Id = textBoxid114.Text;
            myOptionDialog.Description = textBox114.Text;
            myOptionDialog.Parameter = textBoxParameter114.Text;
            myOptionDialog.Text = "Button 114 Options";
            myOptionDialog.Fanart = checkBox114.Checked;
            myOptionDialog.Levels = numericUpDown114.Value;
            myOptionDialog.ShowFanartControls = true;

            if (myOptionDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxid114.Text = myOptionDialog.Id;
                textBox114.Text = myOptionDialog.Description;
                textBoxParameter114.Text = myOptionDialog.Parameter;
                checkBox114.Checked = myOptionDialog.Fanart;
                numericUpDown114.Value = myOptionDialog.Levels;
            }
        }

        private void buttonOptions106_Click(object sender, EventArgs e)
        {
            OptionsDialog myOptionDialog = new OptionsDialog();
            myOptionDialog.Id = textBoxid106.Text;
            myOptionDialog.Description = textBox106.Text;
            myOptionDialog.Parameter = textBoxParameter106.Text;
            myOptionDialog.Text = "Button 106 Options";
            myOptionDialog.Fanart = checkBox106.Checked;
            myOptionDialog.Levels = numericUpDown106.Value;
            myOptionDialog.ShowFanartControls = true;

            if (myOptionDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxid106.Text = myOptionDialog.Id;
                textBox106.Text = myOptionDialog.Description;
                textBoxParameter106.Text = myOptionDialog.Parameter;
                checkBox106.Checked = myOptionDialog.Fanart;
                numericUpDown106.Value = myOptionDialog.Levels;
            }
        }

        private void buttonOptions107_Click(object sender, EventArgs e)
        {
            OptionsDialog myOptionDialog = new OptionsDialog();
            myOptionDialog.Id = textBoxid107.Text;
            myOptionDialog.Description = textBox107.Text;
            myOptionDialog.Parameter = textBoxParameter107.Text;
            myOptionDialog.Text = "Button 107 Options";
            myOptionDialog.Fanart = checkBox107.Checked;
            myOptionDialog.Levels = numericUpDown107.Value;
            myOptionDialog.ShowFanartControls = true;

            if (myOptionDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxid107.Text = myOptionDialog.Id;
                textBox107.Text = myOptionDialog.Description;
                textBoxParameter107.Text = myOptionDialog.Parameter;
                checkBox107.Checked = myOptionDialog.Fanart;
                numericUpDown107.Value = myOptionDialog.Levels;
            }
        }

        private void buttonOptions108_Click(object sender, EventArgs e)
        {
            OptionsDialog myOptionDialog = new OptionsDialog();
            myOptionDialog.Id = textBoxid108.Text;
            myOptionDialog.Description = textBox108.Text;
            myOptionDialog.Parameter = textBoxParameter108.Text;
            myOptionDialog.Text = "Button 108 Options";
            myOptionDialog.Fanart = checkBox108.Checked;
            myOptionDialog.Levels = numericUpDown108.Value;
            myOptionDialog.ShowFanartControls = true;

            if (myOptionDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxid108.Text = myOptionDialog.Id;
                textBox108.Text = myOptionDialog.Description;
                textBoxParameter108.Text = myOptionDialog.Parameter;
                checkBox108.Checked = myOptionDialog.Fanart;
                numericUpDown108.Value = myOptionDialog.Levels;
            }
        }

        private void buttonOptions109_Click(object sender, EventArgs e)
        {
            OptionsDialog myOptionDialog = new OptionsDialog();
            myOptionDialog.Id = textBoxid109.Text;
            myOptionDialog.Description = textBox109.Text;
            myOptionDialog.Parameter = textBoxParameter109.Text;
            myOptionDialog.Text = "Button 109 Options";
            myOptionDialog.Fanart = checkBox109.Checked;
            myOptionDialog.Levels = numericUpDown109.Value;
            myOptionDialog.ShowFanartControls = true;

            if (myOptionDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxid109.Text = myOptionDialog.Id;
                textBox109.Text = myOptionDialog.Description;
                textBoxParameter109.Text = myOptionDialog.Parameter;
                checkBox109.Checked = myOptionDialog.Fanart;
                numericUpDown109.Value = myOptionDialog.Levels;
            }
        }

        private void buttonOptions105_Click(object sender, EventArgs e)
        {
            OptionsDialog myOptionDialog = new OptionsDialog();
            myOptionDialog.Id = textBoxid105.Text;
            myOptionDialog.Description = textBox105.Text;
            myOptionDialog.Parameter = textBoxParameter105.Text;
            myOptionDialog.Text = "Button 105 Options";
            myOptionDialog.Fanart = checkBox105.Checked;
            myOptionDialog.Levels = numericUpDown105.Value;
            myOptionDialog.ShowFanartControls = true;

            if (myOptionDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxid105.Text = myOptionDialog.Id;
                textBox105.Text = myOptionDialog.Description;
                textBoxParameter105.Text = myOptionDialog.Parameter;
                checkBox105.Checked = myOptionDialog.Fanart;
                numericUpDown105.Value = myOptionDialog.Levels;
            }
        }

        private void buttonOptions104_Click(object sender, EventArgs e)
        {
            OptionsDialog myOptionDialog = new OptionsDialog();
            myOptionDialog.Id = textBoxid104.Text;
            myOptionDialog.Description = textBox104.Text;
            myOptionDialog.Parameter = textBoxParameter104.Text;
            myOptionDialog.Text = "Button 104 Options";
            myOptionDialog.Fanart = checkBox104.Checked;
            myOptionDialog.Levels = numericUpDown104.Value;
            myOptionDialog.ShowFanartControls = false;

            if (myOptionDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxid104.Text = myOptionDialog.Id;
                textBox104.Text = myOptionDialog.Description;
                textBoxParameter104.Text = myOptionDialog.Parameter;
                checkBox104.Checked = myOptionDialog.Fanart;
                numericUpDown104.Value = myOptionDialog.Levels;
            }
        }

        private void buttonOptions103_Click(object sender, EventArgs e)
        {
            OptionsDialog myOptionDialog = new OptionsDialog();
            myOptionDialog.Id = textBoxid103.Text;
            myOptionDialog.Description = textBox103.Text;
            myOptionDialog.Parameter = textBoxParameter103.Text;
            myOptionDialog.Text = "Button 103 Options";
            myOptionDialog.Fanart = checkBox103.Checked;
            myOptionDialog.Levels = numericUpDown103.Value;
            myOptionDialog.ShowFanartControls = false;

            if (myOptionDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxid103.Text = myOptionDialog.Id;
                textBox103.Text = myOptionDialog.Description;
                textBoxParameter103.Text = myOptionDialog.Parameter;
                checkBox103.Checked = myOptionDialog.Fanart;
                numericUpDown103.Value = myOptionDialog.Levels;
            }
        }

        private void buttonOptions102_Click(object sender, EventArgs e)
        {
            OptionsDialog myOptionDialog = new OptionsDialog();
            myOptionDialog.Id = textBoxid102.Text;
            myOptionDialog.Description = textBox102.Text;
            myOptionDialog.Parameter = textBoxParameter102.Text;
            myOptionDialog.Text = "Button 102 Options";
            myOptionDialog.Fanart = checkBox102.Checked;
            myOptionDialog.Levels = numericUpDown102.Value;
            myOptionDialog.ShowFanartControls = false;

            if (myOptionDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxid102.Text = myOptionDialog.Id;
                textBox102.Text = myOptionDialog.Description;
                textBoxParameter102.Text = myOptionDialog.Parameter;
                checkBox102.Checked = myOptionDialog.Fanart;
                numericUpDown102.Value = myOptionDialog.Levels;
            }
        }

        private void buttonOptions101_Click(object sender, EventArgs e)
        {
            OptionsDialog myOptionDialog = new OptionsDialog();
            myOptionDialog.Id = textBoxid101.Text;
            myOptionDialog.Description = textBox101.Text;
            myOptionDialog.Parameter = textBoxParameter101.Text;
            myOptionDialog.Text = "Button 101 Options";
            myOptionDialog.Fanart = checkBox101.Checked;
            myOptionDialog.Levels = numericUpDown101.Value;
            myOptionDialog.ShowFanartControls = false;

            if (myOptionDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxid101.Text = myOptionDialog.Id;
                textBox101.Text = myOptionDialog.Description;
                textBoxParameter101.Text = myOptionDialog.Parameter;
                checkBox101.Checked = myOptionDialog.Fanart;
                numericUpDown101.Value = myOptionDialog.Levels;
            }
        }

        private void buttonOptions100_Click(object sender, EventArgs e)
        {
            OptionsDialog myOptionDialog = new OptionsDialog();
            myOptionDialog.Id = textBoxid100.Text;
            myOptionDialog.Description = textBox100.Text;
            myOptionDialog.Parameter = textBoxParameter100.Text;
            myOptionDialog.Text = "Button 100 Options";
            myOptionDialog.Fanart = checkBox100.Checked;
            myOptionDialog.Levels = numericUpDown100.Value;
            myOptionDialog.ShowFanartControls = false;

            if (myOptionDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxid100.Text = myOptionDialog.Id;
                textBox100.Text = myOptionDialog.Description;
                textBoxParameter100.Text = myOptionDialog.Parameter;
                checkBox100.Checked = myOptionDialog.Fanart;
                numericUpDown100.Value = myOptionDialog.Levels;
            }
        }



    }
}