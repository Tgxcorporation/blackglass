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

            this.Hide();
            Splash frmSplash = new Splash();
            frmSplash.Show();
            frmSplash.Update();

            string path = System.IO.Path.Combine(Application.StartupPath, "BGN_plugins.xml");
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
                    Plugins.Load("http://blackglass.googlecode.com/svn/trunk/Plugin%20List/BGN_plugins.xml");
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


            //Combobox plugin list
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
            XmlNodeList hover = Buttons.GetElementsByTagName("hover");
            XmlNodeList fanart = Buttons.GetElementsByTagName("fanart");
            XmlNodeList fanartLevels = Buttons.GetElementsByTagName("fanartLevels");
            XmlNodeList parameter = Buttons.GetElementsByTagName("parameter");
            XmlNodeList fanartDelay1 = Buttons.GetElementsByTagName("fanartDelay1");
            XmlNodeList fanartDelay2 = Buttons.GetElementsByTagName("fanartDelay2");
            XmlNodeList fanartDelay3 = Buttons.GetElementsByTagName("fanartDelay3");

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


            if (fanart[0].InnerText == "True") { checkBox100.Checked = true; } else { checkBox100.Checked = false; }
            if (fanart[1].InnerText == "True") { checkBox101.Checked = true; } else { checkBox101.Checked = false; }
            if (fanart[2].InnerText == "True") { checkBox102.Checked = true; } else { checkBox102.Checked = false; }
            if (fanart[3].InnerText == "True") { checkBox103.Checked = true; } else { checkBox103.Checked = false; }
            if (fanart[4].InnerText == "True") { checkBox104.Checked = true; } else { checkBox104.Checked = false; }
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

            numericUpDown100.Value = decimal.Parse(fanartLevels[0].InnerText);
            numericUpDown101.Value = decimal.Parse(fanartLevels[1].InnerText);
            numericUpDown102.Value = decimal.Parse(fanartLevels[2].InnerText);
            numericUpDown103.Value = decimal.Parse(fanartLevels[3].InnerText);
            numericUpDown104.Value = decimal.Parse(fanartLevels[4].InnerText);
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

            numericUpDownDelay1_100.Value = decimal.Parse(fanartDelay1[0].InnerText); numericUpDownDelay2_100.Value = decimal.Parse(fanartDelay2[0].InnerText); numericUpDownDelay3_100.Value = decimal.Parse(fanartDelay3[0].InnerText);
            numericUpDownDelay1_101.Value = decimal.Parse(fanartDelay1[1].InnerText); numericUpDownDelay2_101.Value = decimal.Parse(fanartDelay2[1].InnerText); numericUpDownDelay3_101.Value = decimal.Parse(fanartDelay3[1].InnerText);
            numericUpDownDelay1_102.Value = decimal.Parse(fanartDelay1[2].InnerText); numericUpDownDelay2_102.Value = decimal.Parse(fanartDelay2[2].InnerText); numericUpDownDelay3_102.Value = decimal.Parse(fanartDelay3[2].InnerText);
            numericUpDownDelay1_103.Value = decimal.Parse(fanartDelay1[3].InnerText); numericUpDownDelay2_103.Value = decimal.Parse(fanartDelay2[3].InnerText); numericUpDownDelay3_103.Value = decimal.Parse(fanartDelay3[3].InnerText);
            numericUpDownDelay1_104.Value = decimal.Parse(fanartDelay1[4].InnerText); numericUpDownDelay2_104.Value = decimal.Parse(fanartDelay2[4].InnerText); numericUpDownDelay3_104.Value = decimal.Parse(fanartDelay3[4].InnerText);
            numericUpDownDelay1_105.Value = decimal.Parse(fanartDelay1[5].InnerText); numericUpDownDelay2_105.Value = decimal.Parse(fanartDelay2[5].InnerText); numericUpDownDelay3_105.Value = decimal.Parse(fanartDelay3[5].InnerText);
            numericUpDownDelay1_106.Value = decimal.Parse(fanartDelay1[6].InnerText); numericUpDownDelay2_106.Value = decimal.Parse(fanartDelay2[6].InnerText); numericUpDownDelay3_106.Value = decimal.Parse(fanartDelay3[6].InnerText);
            numericUpDownDelay1_107.Value = decimal.Parse(fanartDelay1[7].InnerText); numericUpDownDelay2_107.Value = decimal.Parse(fanartDelay2[7].InnerText); numericUpDownDelay3_107.Value = decimal.Parse(fanartDelay3[7].InnerText);
            numericUpDownDelay1_108.Value = decimal.Parse(fanartDelay1[8].InnerText); numericUpDownDelay2_108.Value = decimal.Parse(fanartDelay2[8].InnerText); numericUpDownDelay3_108.Value = decimal.Parse(fanartDelay3[8].InnerText);
            numericUpDownDelay1_109.Value = decimal.Parse(fanartDelay1[9].InnerText); numericUpDownDelay2_109.Value = decimal.Parse(fanartDelay2[9].InnerText); numericUpDownDelay3_109.Value = decimal.Parse(fanartDelay3[9].InnerText);
            numericUpDownDelay1_110.Value = decimal.Parse(fanartDelay1[10].InnerText); numericUpDownDelay2_110.Value = decimal.Parse(fanartDelay2[10].InnerText); numericUpDownDelay3_110.Value = decimal.Parse(fanartDelay3[10].InnerText);
            numericUpDownDelay1_111.Value = decimal.Parse(fanartDelay1[11].InnerText); numericUpDownDelay2_111.Value = decimal.Parse(fanartDelay2[11].InnerText); numericUpDownDelay3_111.Value = decimal.Parse(fanartDelay3[11].InnerText);
            numericUpDownDelay1_112.Value = decimal.Parse(fanartDelay1[12].InnerText); numericUpDownDelay2_112.Value = decimal.Parse(fanartDelay2[12].InnerText); numericUpDownDelay3_112.Value = decimal.Parse(fanartDelay3[12].InnerText);
            numericUpDownDelay1_113.Value = decimal.Parse(fanartDelay1[13].InnerText); numericUpDownDelay2_113.Value = decimal.Parse(fanartDelay2[13].InnerText); numericUpDownDelay3_113.Value = decimal.Parse(fanartDelay3[13].InnerText);
            numericUpDownDelay1_114.Value = decimal.Parse(fanartDelay1[14].InnerText); numericUpDownDelay2_114.Value = decimal.Parse(fanartDelay2[14].InnerText); numericUpDownDelay3_114.Value = decimal.Parse(fanartDelay3[14].InnerText);

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

            frmSplash.Close();
            this.Visible = true;
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

            if (focus == 1)
            {
                myStream = myAssembly.GetManifestResourceStream("BlackGlassEditor.Images.basichome_" + buttonRif + "_contour.png");
                Bitmap contour = new Bitmap(myStream);
                gfx.DrawImage(contour, new System.Drawing.Rectangle(0, 0, contour.Width, contour.Height));
                contour.Dispose();
            }

            //img = Functions.SetImgOpacity(img, 0.70f);

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
            textBoxhover100.Text = findPluginHover(Int32.Parse(textBoxid100.Text));
            if (comboBox100.Text == "Empty Button") { textBox100.Text = ""; textBoxid100.Text = ""; };
            //checkBox100.Visible = false;
            checkBox100.Checked = false;
            if (textBoxid100.Text == "504" || textBoxid100.Text == "501" || textBoxid100.Text == "96742" || textBoxid100.Text == "1" || textBoxid100.Text == "9811" || textBoxid100.Text == "2600" || textBoxid100.Text == "2") { checkBox100.Checked = true; numericUpDown100.Value = 1.0m; };
        }
        private void comboBox101_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox101.Text = comboBox101.Text;
            textBoxid101.Text = findPlugin(comboBox101.Text).ToString();
            textBoxParameter101.Text = "";
            textBoxhover101.Text = findPluginHover(Int32.Parse(textBoxid101.Text));
            if (comboBox101.Text == "Empty Button") { textBox101.Text = ""; textBoxid101.Text = ""; };
            //checkBox101.Visible = false;
            checkBox101.Checked = false;
            if (textBoxid101.Text == "504" || textBoxid101.Text == "501" || textBoxid101.Text == "96742" || textBoxid101.Text == "1" || textBoxid101.Text == "9811" || textBoxid101.Text == "2600" || textBoxid101.Text == "2") { checkBox101.Checked = true; numericUpDown101.Value = 1.0m; };
        }
        private void comboBox102_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox102.Text = comboBox102.Text;
            textBoxid102.Text = findPlugin(comboBox102.Text).ToString();
            textBoxParameter102.Text = "";
            textBoxhover102.Text = findPluginHover(Int32.Parse(textBoxid102.Text));
            if (comboBox102.Text == "Empty Button") { textBox102.Text = ""; textBoxid102.Text = ""; };
            //checkBox102.Visible = false;
            checkBox102.Checked = false;
            if (textBoxid102.Text == "504" || textBoxid102.Text == "501" || textBoxid102.Text == "96742" || textBoxid102.Text == "1" || textBoxid102.Text == "9811" || textBoxid102.Text == "2600" || textBoxid102.Text == "2") { checkBox102.Checked = true; numericUpDown102.Value = 1.0m; };
        }
        private void comboBox103_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox103.Text = comboBox103.Text;
            textBoxid103.Text = findPlugin(comboBox103.Text).ToString();
            textBoxParameter103.Text = "";
            textBoxhover103.Text = findPluginHover(Int32.Parse(textBoxid103.Text));
            if (comboBox103.Text == "Empty Button") { textBox103.Text = ""; textBoxid103.Text = ""; };
            //checkBox103.Visible = false;
            checkBox103.Checked = false;
            if (textBoxid103.Text == "504" || textBoxid103.Text == "501" || textBoxid103.Text == "96742" || textBoxid103.Text == "1" || textBoxid103.Text == "9811" || textBoxid103.Text == "2600" || textBoxid103.Text == "2") { checkBox103.Checked = true; numericUpDown103.Value = 1.0m; };
        }
        private void comboBox104_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox104.Text = comboBox104.Text;
            textBoxid104.Text = findPlugin(comboBox104.Text).ToString();
            textBoxParameter104.Text = "";
            textBoxhover104.Text = findPluginHover(Int32.Parse(textBoxid104.Text));
            if (comboBox104.Text == "Empty Button") { textBox104.Text = ""; textBoxid104.Text = ""; };
            //checkBox104.Visible = false;
            checkBox104.Checked = false;
            if (textBoxid104.Text == "504" || textBoxid104.Text == "501" || textBoxid104.Text == "96742" || textBoxid104.Text == "1" || textBoxid104.Text == "9811" || textBoxid104.Text == "2600" || textBoxid104.Text == "2") { checkBox104.Checked = true; numericUpDown104.Value = 1.0m; };
        }
        private void comboBox105_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox105.Text = comboBox105.Text;
            textBoxid105.Text = findPlugin(comboBox105.Text).ToString();
            textBoxParameter105.Text = "";
            textBoxhover105.Text = findPluginHover(Int32.Parse(textBoxid105.Text));
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
            textBoxhover106.Text = findPluginHover(Int32.Parse(textBoxid106.Text));
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
            textBoxhover107.Text = findPluginHover(Int32.Parse(textBoxid107.Text));
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
            textBoxhover108.Text = findPluginHover(Int32.Parse(textBoxid108.Text));
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
            textBoxhover109.Text = findPluginHover(Int32.Parse(textBoxid109.Text));
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
            textBoxhover110.Text = findPluginHover(Int32.Parse(textBoxid110.Text));
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
            textBoxhover111.Text = findPluginHover(Int32.Parse(textBoxid111.Text));
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
            textBoxhover112.Text = findPluginHover(Int32.Parse(textBoxid112.Text));
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
            textBoxhover113.Text = findPluginHover(Int32.Parse(textBoxid113.Text));
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
            textBoxhover114.Text = findPluginHover(Int32.Parse(textBoxid114.Text));
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

                Int32 progressCounter = 5;

                progressBarBuild.Value = 0;
                toolStripStatusLabel1.Text = "Creating Basic Home...";
                this.Update();


                if (pictureBox100.Image != null) { progressCounter++; }
                if (pictureBox101.Image != null) { progressCounter++; }
                if (pictureBox102.Image != null) { progressCounter++; }
                if (pictureBox103.Image != null) { progressCounter++; }
                if (pictureBox104.Image != null) { progressCounter++; }
                if (pictureBox105.Image != null) { progressCounter++; }
                if (pictureBox106.Image != null) { progressCounter++; }
                if (pictureBox107.Image != null) { progressCounter++; }
                if (pictureBox108.Image != null) { progressCounter++; }
                if (pictureBox109.Image != null) { progressCounter++; }
                if (pictureBox110.Image != null) { progressCounter++; }
                if (pictureBox111.Image != null) { progressCounter++; }
                if (pictureBox112.Image != null) { progressCounter++; }
                if (pictureBox113.Image != null) { progressCounter++; }
                if (pictureBox114.Image != null) { progressCounter++; }

                Int32 step = (Int32)(Math.Round((Decimal)(100 / progressCounter)));
                progressBarBuild.Step = step;

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

                progressBarBuild.PerformStep();
                Bitmap buttonImage100 = new Bitmap(buildImage(pictureBox100.Image, "100", 0));
                saveImage(BlackGlassDirClass.Path + "\\Media\\basichome_100_nofocus.png", pictureBox100.Image, "100", 0);
                saveImage(BlackGlassDirClass.Path + "\\Media\\basichome_100_focus.png", pictureBox100.Image, "100", 1);

                progressBarBuild.PerformStep();
                Bitmap buttonImage101 = new Bitmap(buildImage(pictureBox101.Image, "101", 0));
                saveImage(BlackGlassDirClass.Path + "\\Media\\basichome_101_nofocus.png", pictureBox101.Image, "101", 0);
                saveImage(BlackGlassDirClass.Path + "\\Media\\basichome_101_focus.png", pictureBox101.Image, "101", 1);

                progressBarBuild.PerformStep();
                Bitmap buttonImage102 = new Bitmap(buildImage(pictureBox102.Image, "102", 1));
                saveImage(BlackGlassDirClass.Path + "\\Media\\basichome_102_nofocus.png", pictureBox102.Image, "102", 0);
                saveImage(BlackGlassDirClass.Path + "\\Media\\basichome_102_focus.png", pictureBox102.Image, "102", 1);

                progressBarBuild.PerformStep();
                Bitmap buttonImage103 = new Bitmap(buildImage(pictureBox103.Image, "103", 0));
                saveImage(BlackGlassDirClass.Path + "\\Media\\basichome_103_nofocus.png", pictureBox103.Image, "103", 0);
                saveImage(BlackGlassDirClass.Path + "\\Media\\basichome_103_focus.png", pictureBox103.Image, "103", 1);

                progressBarBuild.PerformStep();
                Bitmap buttonImage104 = new Bitmap(buildImage(pictureBox104.Image, "104", 0));
                saveImage(BlackGlassDirClass.Path + "\\Media\\basichome_104_nofocus.png", pictureBox104.Image, "104", 0);
                saveImage(BlackGlassDirClass.Path + "\\Media\\basichome_104_focus.png", pictureBox104.Image, "104", 1);

                Bitmap buttonImage105 = null;
                if (pictureBox105.Image != null)
                {
                    progressBarBuild.PerformStep();
                    buttonImage105 = new Bitmap(buildImage(pictureBox105.Image, "105", 1));
                    saveImage(BlackGlassDirClass.Path + "\\Media\\basichome_105_nofocus.png", pictureBox105.Image, "105", 0);
                    saveImage(BlackGlassDirClass.Path + "\\Media\\basichome_105_focus.png", pictureBox105.Image, "105", 1);
                }
                Bitmap buttonImage106 = null;
                if (pictureBox106.Image != null)
                {
                    progressBarBuild.PerformStep();
                    buttonImage106 = new Bitmap(buildImage(pictureBox106.Image, "106", 1));
                    saveImage(BlackGlassDirClass.Path + "\\Media\\basichome_106_nofocus.png", pictureBox106.Image, "106", 0);
                    saveImage(BlackGlassDirClass.Path + "\\Media\\basichome_106_focus.png", pictureBox106.Image, "106", 1);
                }
                Bitmap buttonImage107 = null;
                if (pictureBox107.Image != null)
                {
                    progressBarBuild.PerformStep();
                    buttonImage107 = new Bitmap(buildImage(pictureBox107.Image, "107", 1));
                    saveImage(BlackGlassDirClass.Path + "\\Media\\basichome_107_nofocus.png", pictureBox107.Image, "107", 0);
                    saveImage(BlackGlassDirClass.Path + "\\Media\\basichome_107_focus.png", pictureBox107.Image, "107", 1);
                }
                Bitmap buttonImage108 = null;
                if (pictureBox108.Image != null)
                {
                    progressBarBuild.PerformStep();
                    buttonImage108 = new Bitmap(buildImage(pictureBox108.Image, "108", 1));
                    saveImage(BlackGlassDirClass.Path + "\\Media\\basichome_108_nofocus.png", pictureBox108.Image, "108", 0);
                    saveImage(BlackGlassDirClass.Path + "\\Media\\basichome_108_focus.png", pictureBox108.Image, "108", 1);
                }
                Bitmap buttonImage109 = null;
                if (pictureBox109.Image != null)
                {
                    progressBarBuild.PerformStep();
                    buttonImage109 = new Bitmap(buildImage(pictureBox109.Image, "109", 1));
                    saveImage(BlackGlassDirClass.Path + "\\Media\\basichome_109_nofocus.png", pictureBox109.Image, "109", 0);
                    saveImage(BlackGlassDirClass.Path + "\\Media\\basichome_109_focus.png", pictureBox109.Image, "109", 1);
                }
                Bitmap buttonImage110 = null;
                if (pictureBox110.Image != null)
                {
                    progressBarBuild.PerformStep();
                    buttonImage110 = new Bitmap(buildImage(pictureBox110.Image, "110", 1));
                    saveImage(BlackGlassDirClass.Path + "\\Media\\basichome_110_nofocus.png", pictureBox110.Image, "110", 0);
                    saveImage(BlackGlassDirClass.Path + "\\Media\\basichome_110_focus.png", pictureBox110.Image, "110", 1);
                }
                Bitmap buttonImage111 = null;
                if (pictureBox111.Image != null)
                {
                    progressBarBuild.PerformStep();
                    buttonImage111 = new Bitmap(buildImage(pictureBox111.Image, "111", 1));
                    saveImage(BlackGlassDirClass.Path + "\\Media\\basichome_111_nofocus.png", pictureBox111.Image, "111", 0);
                    saveImage(BlackGlassDirClass.Path + "\\Media\\basichome_111_focus.png", pictureBox111.Image, "111", 1);
                }
                Bitmap buttonImage112 = null;
                if (pictureBox112.Image != null)
                {
                    progressBarBuild.PerformStep();
                    buttonImage112 = new Bitmap(buildImage(pictureBox112.Image, "112", 1));
                    saveImage(BlackGlassDirClass.Path + "\\Media\\basichome_112_nofocus.png", pictureBox112.Image, "112", 0);
                    saveImage(BlackGlassDirClass.Path + "\\Media\\basichome_112_focus.png", pictureBox112.Image, "112", 1);
                }
                Bitmap buttonImage113 = null;
                if (pictureBox113.Image != null)
                {
                    progressBarBuild.PerformStep();
                    buttonImage113 = new Bitmap(buildImage(pictureBox113.Image, "113", 1));
                    saveImage(BlackGlassDirClass.Path + "\\Media\\basichome_113_nofocus.png", pictureBox113.Image, "113", 0);
                    saveImage(BlackGlassDirClass.Path + "\\Media\\basichome_113_focus.png", pictureBox113.Image, "113", 1);
                }
                Bitmap buttonImage114 = null;
                if (pictureBox114.Image != null)
                {
                    progressBarBuild.PerformStep();
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
                progressBarBuild.PerformStep();

                //if (pictureBox105.Image != null) gfx.DrawImage(buttonImage105, new System.Drawing.Rectangle(114, 261, buttonImage105.Width, buttonImage105.Height));
                //if (pictureBox106.Image != null) gfx.DrawImage(buttonImage106, new System.Drawing.Rectangle(342, 300, buttonImage106.Width, buttonImage106.Height));
                //if (pictureBox107.Image != null) gfx.DrawImage(buttonImage107, new System.Drawing.Rectangle(543, 316, buttonImage107.Width, buttonImage107.Height));
                //if (pictureBox108.Image != null) gfx.DrawImage(buttonImage108, new System.Drawing.Rectangle(733, 300, buttonImage108.Width, buttonImage108.Height));
                //if (pictureBox109.Image != null) gfx.DrawImage(buttonImage109, new System.Drawing.Rectangle(935, 261, buttonImage109.Width, buttonImage109.Height));
                //if (pictureBox110.Image != null) gfx.DrawImage(buttonImage110, new System.Drawing.Rectangle(126, 106, buttonImage110.Width, buttonImage110.Height));
                //if (pictureBox111.Image != null) gfx.DrawImage(buttonImage111, new System.Drawing.Rectangle(348, 168, buttonImage111.Width, buttonImage111.Height));
                //if (pictureBox112.Image != null) gfx.DrawImage(buttonImage112, new System.Drawing.Rectangle(545, 192, buttonImage112.Width, buttonImage112.Height));
                //if (pictureBox113.Image != null) gfx.DrawImage(buttonImage113, new System.Drawing.Rectangle(731, 168, buttonImage113.Width, buttonImage113.Height));
                //if (pictureBox114.Image != null) gfx.DrawImage(buttonImage114, new System.Drawing.Rectangle(929, 106, buttonImage114.Width, buttonImage114.Height));

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
                progressBarBuild.PerformStep();

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
                progressBarBuild.PerformStep();

                saveXML(); progressBarBuild.PerformStep();
                saveSettings(); progressBarBuild.PerformStep();

                deleteBlackGlassCacheDir();

                progressBarBuild.Value = 100;
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

            if (path == "") MessageBox.Show("Error: Could not find Black Glass Nova Skin folder.\n\nUse the 'Select Skin Path' button to find it!");


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
			<animation effect=""fade"" time=""150"">VisibleChange</animation>
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
			<animation effect=""fade"" time=""150"">VisibleChange</animation>
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
			<animation effect=""fade"" time=""150"">VisibleChange</animation>
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
			<animation effect=""fade"" time=""150"">VisibleChange</animation>
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
			<animation effect=""fade"" time=""150"">VisibleChange</animation>
		</control>

        ";

                txt = txt + buildHoverLabelXml("100") + buildButtonXml("100"); if (checkBox100.Checked == true) txt = txt + buildFanartTextXml("100");
                txt = txt + buildHoverLabelXml("101") + buildButtonXml("101"); if (checkBox101.Checked == true) txt = txt + buildFanartTextXml("101");
                txt = txt + buildHoverLabelXml("102") + buildButtonXml("102"); if (checkBox102.Checked == true) txt = txt + buildFanartTextXml("102");
                txt = txt + buildHoverLabelXml("103") + buildButtonXml("103"); if (checkBox103.Checked == true) txt = txt + buildFanartTextXml("103");
                txt = txt + buildHoverLabelXml("104") + buildButtonXml("104"); if (checkBox104.Checked == true) txt = txt + buildFanartTextXml("104");
                if (comboBox105.SelectedItem.ToString() != findPluginName(0)) { txt = txt + buildHoverLabelXml("105") + buildButtonXml("105"); if (checkBox105.Checked == true) txt = txt + buildFanartTextXml("105"); }
                if (comboBox106.SelectedItem.ToString() != findPluginName(0)) { txt = txt + buildHoverLabelXml("106") + buildButtonXml("106"); if (checkBox106.Checked == true) txt = txt + buildFanartTextXml("106"); }
                if (comboBox107.SelectedItem.ToString() != findPluginName(0)) { txt = txt + buildHoverLabelXml("107") + buildButtonXml("107"); if (checkBox107.Checked == true) txt = txt + buildFanartTextXml("107"); }
                if (comboBox108.SelectedItem.ToString() != findPluginName(0)) { txt = txt + buildHoverLabelXml("108") + buildButtonXml("108"); if (checkBox108.Checked == true) txt = txt + buildFanartTextXml("108"); }
                if (comboBox109.SelectedItem.ToString() != findPluginName(0)) { txt = txt + buildHoverLabelXml("109") + buildButtonXml("109"); if (checkBox109.Checked == true) txt = txt + buildFanartTextXml("109"); }
                if (comboBox110.SelectedItem.ToString() != findPluginName(0)) { txt = txt + buildHoverLabelXml("110") + buildButtonXml("110"); if (checkBox110.Checked == true) txt = txt + buildFanartTextXml("110"); }
                if (comboBox111.SelectedItem.ToString() != findPluginName(0)) { txt = txt + buildHoverLabelXml("111") + buildButtonXml("111"); if (checkBox111.Checked == true) txt = txt + buildFanartTextXml("111"); }
                if (comboBox112.SelectedItem.ToString() != findPluginName(0)) { txt = txt + buildHoverLabelXml("112") + buildButtonXml("112"); if (checkBox112.Checked == true) txt = txt + buildFanartTextXml("112"); }
                if (comboBox113.SelectedItem.ToString() != findPluginName(0)) { txt = txt + buildHoverLabelXml("113") + buildButtonXml("113"); if (checkBox113.Checked == true) txt = txt + buildFanartTextXml("113"); }
                if (comboBox114.SelectedItem.ToString() != findPluginName(0)) { txt = txt + buildHoverLabelXml("114") + buildButtonXml("114"); if (checkBox114.Checked == true) txt = txt + buildFanartTextXml("114"); }

                txt = txt + @"
    </controls>
</window>";

                String path = BlackGlassDirClass.Path + "\\BasicHome_Buttons.xml";

                try
                {
                    TextWriter tw = new StreamWriter(path, false, Encoding.UTF8);
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
		
    ";
                txt = txt + buildHoverBackdropXml("100");
                txt = txt + buildHoverBackdropXml("101");
                txt = txt + buildHoverBackdropXml("102");
                txt = txt + buildHoverBackdropXml("103");
                txt = txt + buildHoverBackdropXml("104");
                if (comboBox105.SelectedItem.ToString() != findPluginName(0)) txt = txt + buildHoverBackdropXml("105");
                if (comboBox106.SelectedItem.ToString() != findPluginName(0)) txt = txt + buildHoverBackdropXml("106");
                if (comboBox107.SelectedItem.ToString() != findPluginName(0)) txt = txt + buildHoverBackdropXml("107");
                if (comboBox108.SelectedItem.ToString() != findPluginName(0)) txt = txt + buildHoverBackdropXml("108");
                if (comboBox109.SelectedItem.ToString() != findPluginName(0)) txt = txt + buildHoverBackdropXml("109");
                if (comboBox110.SelectedItem.ToString() != findPluginName(0)) txt = txt + buildHoverBackdropXml("110");
                if (comboBox111.SelectedItem.ToString() != findPluginName(0)) txt = txt + buildHoverBackdropXml("111");
                if (comboBox112.SelectedItem.ToString() != findPluginName(0)) txt = txt + buildHoverBackdropXml("112");
                if (comboBox113.SelectedItem.ToString() != findPluginName(0)) txt = txt + buildHoverBackdropXml("113");
                if (comboBox114.SelectedItem.ToString() != findPluginName(0)) txt = txt + buildHoverBackdropXml("114");

                if (checkBox100.Checked == true) txt = txt + buildFanartBackdropXml("100");
                if (checkBox101.Checked == true) txt = txt + buildFanartBackdropXml("101");
                if (checkBox102.Checked == true) txt = txt + buildFanartBackdropXml("102");
                if (checkBox103.Checked == true) txt = txt + buildFanartBackdropXml("103");
                if (checkBox104.Checked == true) txt = txt + buildFanartBackdropXml("104");
                if (checkBox105.Checked == true) txt = txt + buildFanartBackdropXml("105");
                if (checkBox106.Checked == true) txt = txt + buildFanartBackdropXml("106");
                if (checkBox107.Checked == true) txt = txt + buildFanartBackdropXml("107");
                if (checkBox108.Checked == true) txt = txt + buildFanartBackdropXml("108");
                if (checkBox109.Checked == true) txt = txt + buildFanartBackdropXml("109");
                if (checkBox110.Checked == true) txt = txt + buildFanartBackdropXml("110");
                if (checkBox111.Checked == true) txt = txt + buildFanartBackdropXml("111");
                if (checkBox112.Checked == true) txt = txt + buildFanartBackdropXml("112");
                if (checkBox113.Checked == true) txt = txt + buildFanartBackdropXml("113");
                if (checkBox114.Checked == true) txt = txt + buildFanartBackdropXml("114");


                txt = txt + @"</controls>
</window>";

                path = BlackGlassDirClass.Path + "\\BasicHome_Backdrops.xml";

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
                textWriter.WriteString(SecurityElement.Escape(textBoxid100.Text));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("hover", "");
                textWriter.WriteString(SecurityElement.Escape(textBoxhover100.Text));
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
                textWriter.WriteStartElement("fanartDelay1", "");
                textWriter.WriteString(SecurityElement.Escape(numericUpDownDelay1_100.Value.ToString()));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("fanartDelay2", "");
                textWriter.WriteString(SecurityElement.Escape(numericUpDownDelay2_100.Value.ToString()));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("fanartDelay3", "");
                textWriter.WriteString(SecurityElement.Escape(numericUpDownDelay3_100.Value.ToString()));
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
                textWriter.WriteStartElement("fanart", "");
                textWriter.WriteString(SecurityElement.Escape(checkBox101.Checked.ToString()));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("fanartLevels", "");
                textWriter.WriteString(SecurityElement.Escape(numericUpDown101.Value.ToString()));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("parameter", "");
                textWriter.WriteString(SecurityElement.Escape(textBoxParameter101.Text));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("fanartDelay1", "");
                textWriter.WriteString(SecurityElement.Escape(numericUpDownDelay1_101.Value.ToString()));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("fanartDelay2", "");
                textWriter.WriteString(SecurityElement.Escape(numericUpDownDelay2_101.Value.ToString()));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("fanartDelay3", "");
                textWriter.WriteString(SecurityElement.Escape(numericUpDownDelay3_101.Value.ToString()));
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
                textWriter.WriteStartElement("fanart", "");
                textWriter.WriteString(SecurityElement.Escape(checkBox102.Checked.ToString()));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("fanartLevels", "");
                textWriter.WriteString(SecurityElement.Escape(numericUpDown102.Value.ToString()));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("parameter", "");
                textWriter.WriteString(SecurityElement.Escape(textBoxParameter102.Text));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("fanartDelay1", "");
                textWriter.WriteString(SecurityElement.Escape(numericUpDownDelay1_102.Value.ToString()));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("fanartDelay2", "");
                textWriter.WriteString(SecurityElement.Escape(numericUpDownDelay2_102.Value.ToString()));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("fanartDelay3", "");
                textWriter.WriteString(SecurityElement.Escape(numericUpDownDelay3_102.Value.ToString()));
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
                textWriter.WriteStartElement("fanart", "");
                textWriter.WriteString(SecurityElement.Escape(checkBox103.Checked.ToString()));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("fanartLevels", "");
                textWriter.WriteString(SecurityElement.Escape(numericUpDown103.Value.ToString()));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("parameter", "");
                textWriter.WriteString(SecurityElement.Escape(textBoxParameter103.Text));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("fanartDelay1", "");
                textWriter.WriteString(SecurityElement.Escape(numericUpDownDelay1_103.Value.ToString()));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("fanartDelay2", "");
                textWriter.WriteString(SecurityElement.Escape(numericUpDownDelay2_103.Value.ToString()));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("fanartDelay3", "");
                textWriter.WriteString(SecurityElement.Escape(numericUpDownDelay3_103.Value.ToString()));
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
                textWriter.WriteStartElement("fanart", "");
                textWriter.WriteString(SecurityElement.Escape(checkBox104.Checked.ToString()));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("fanartLevels", "");
                textWriter.WriteString(SecurityElement.Escape(numericUpDown104.Value.ToString()));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("parameter", "");
                textWriter.WriteString(SecurityElement.Escape(textBoxParameter104.Text));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("fanartDelay1", "");
                textWriter.WriteString(SecurityElement.Escape(numericUpDownDelay1_104.Value.ToString()));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("fanartDelay2", "");
                textWriter.WriteString(SecurityElement.Escape(numericUpDownDelay2_104.Value.ToString()));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("fanartDelay3", "");
                textWriter.WriteString(SecurityElement.Escape(numericUpDownDelay3_104.Value.ToString()));
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
                textWriter.WriteStartElement("fanart", "");
                textWriter.WriteString(SecurityElement.Escape(checkBox105.Checked.ToString()));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("fanartLevels", "");
                textWriter.WriteString(SecurityElement.Escape(numericUpDown105.Value.ToString()));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("parameter", "");
                textWriter.WriteString(SecurityElement.Escape(textBoxParameter105.Text));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("fanartDelay1", "");
                textWriter.WriteString(SecurityElement.Escape(numericUpDownDelay1_105.Value.ToString()));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("fanartDelay2", "");
                textWriter.WriteString(SecurityElement.Escape(numericUpDownDelay2_105.Value.ToString()));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("fanartDelay3", "");
                textWriter.WriteString(SecurityElement.Escape(numericUpDownDelay3_105.Value.ToString()));
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
                textWriter.WriteStartElement("fanart", "");
                textWriter.WriteString(SecurityElement.Escape(checkBox106.Checked.ToString()));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("fanartLevels", "");
                textWriter.WriteString(SecurityElement.Escape(numericUpDown106.Value.ToString()));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("parameter", "");
                textWriter.WriteString(SecurityElement.Escape(textBoxParameter106.Text));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("fanartDelay1", "");
                textWriter.WriteString(SecurityElement.Escape(numericUpDownDelay1_106.Value.ToString()));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("fanartDelay2", "");
                textWriter.WriteString(SecurityElement.Escape(numericUpDownDelay2_106.Value.ToString()));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("fanartDelay3", "");
                textWriter.WriteString(SecurityElement.Escape(numericUpDownDelay3_106.Value.ToString()));
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
                textWriter.WriteStartElement("fanart", "");
                textWriter.WriteString(SecurityElement.Escape(checkBox107.Checked.ToString()));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("fanartLevels", "");
                textWriter.WriteString(SecurityElement.Escape(numericUpDown107.Value.ToString()));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("parameter", "");
                textWriter.WriteString(SecurityElement.Escape(textBoxParameter107.Text));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("fanartDelay1", "");
                textWriter.WriteString(SecurityElement.Escape(numericUpDownDelay1_107.Value.ToString()));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("fanartDelay2", "");
                textWriter.WriteString(SecurityElement.Escape(numericUpDownDelay2_107.Value.ToString()));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("fanartDelay3", "");
                textWriter.WriteString(SecurityElement.Escape(numericUpDownDelay3_107.Value.ToString()));
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
                textWriter.WriteStartElement("fanart", "");
                textWriter.WriteString(SecurityElement.Escape(checkBox108.Checked.ToString()));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("fanartLevels", "");
                textWriter.WriteString(SecurityElement.Escape(numericUpDown108.Value.ToString()));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("parameter", "");
                textWriter.WriteString(SecurityElement.Escape(textBoxParameter108.Text));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("fanartDelay1", "");
                textWriter.WriteString(SecurityElement.Escape(numericUpDownDelay1_108.Value.ToString()));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("fanartDelay2", "");
                textWriter.WriteString(SecurityElement.Escape(numericUpDownDelay2_108.Value.ToString()));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("fanartDelay3", "");
                textWriter.WriteString(SecurityElement.Escape(numericUpDownDelay3_108.Value.ToString()));
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
                textWriter.WriteStartElement("fanart", "");
                textWriter.WriteString(SecurityElement.Escape(checkBox109.Checked.ToString()));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("fanartLevels", "");
                textWriter.WriteString(SecurityElement.Escape(numericUpDown109.Value.ToString()));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("parameter", "");
                textWriter.WriteString(SecurityElement.Escape(textBoxParameter109.Text));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("fanartDelay1", "");
                textWriter.WriteString(SecurityElement.Escape(numericUpDownDelay1_109.Value.ToString()));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("fanartDelay2", "");
                textWriter.WriteString(SecurityElement.Escape(numericUpDownDelay2_109.Value.ToString()));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("fanartDelay3", "");
                textWriter.WriteString(SecurityElement.Escape(numericUpDownDelay3_109.Value.ToString()));
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
                textWriter.WriteStartElement("fanart", "");
                textWriter.WriteString(SecurityElement.Escape(checkBox110.Checked.ToString()));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("fanartLevels", "");
                textWriter.WriteString(SecurityElement.Escape(numericUpDown110.Value.ToString()));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("parameter", "");
                textWriter.WriteString(SecurityElement.Escape(textBoxParameter110.Text));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("fanartDelay1", "");
                textWriter.WriteString(SecurityElement.Escape(numericUpDownDelay1_110.Value.ToString()));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("fanartDelay2", "");
                textWriter.WriteString(SecurityElement.Escape(numericUpDownDelay2_110.Value.ToString()));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("fanartDelay3", "");
                textWriter.WriteString(SecurityElement.Escape(numericUpDownDelay3_110.Value.ToString()));
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
                textWriter.WriteStartElement("fanart", "");
                textWriter.WriteString(SecurityElement.Escape(checkBox111.Checked.ToString()));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("fanartLevels", "");
                textWriter.WriteString(SecurityElement.Escape(numericUpDown111.Value.ToString()));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("parameter", "");
                textWriter.WriteString(SecurityElement.Escape(textBoxParameter111.Text));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("fanartDelay1", "");
                textWriter.WriteString(SecurityElement.Escape(numericUpDownDelay1_111.Value.ToString()));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("fanartDelay2", "");
                textWriter.WriteString(SecurityElement.Escape(numericUpDownDelay2_111.Value.ToString()));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("fanartDelay3", "");
                textWriter.WriteString(SecurityElement.Escape(numericUpDownDelay3_111.Value.ToString()));
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
                textWriter.WriteStartElement("fanart", "");
                textWriter.WriteString(SecurityElement.Escape(checkBox112.Checked.ToString()));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("fanartLevels", "");
                textWriter.WriteString(SecurityElement.Escape(numericUpDown112.Value.ToString()));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("parameter", "");
                textWriter.WriteString(SecurityElement.Escape(textBoxParameter112.Text));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("fanartDelay1", "");
                textWriter.WriteString(SecurityElement.Escape(numericUpDownDelay1_112.Value.ToString()));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("fanartDelay2", "");
                textWriter.WriteString(SecurityElement.Escape(numericUpDownDelay2_112.Value.ToString()));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("fanartDelay3", "");
                textWriter.WriteString(SecurityElement.Escape(numericUpDownDelay3_112.Value.ToString()));
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
                textWriter.WriteStartElement("fanart", "");
                textWriter.WriteString(SecurityElement.Escape(checkBox113.Checked.ToString()));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("fanartLevels", "");
                textWriter.WriteString(SecurityElement.Escape(numericUpDown113.Value.ToString()));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("parameter", "");
                textWriter.WriteString(SecurityElement.Escape(textBoxParameter113.Text));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("fanartDelay1", "");
                textWriter.WriteString(SecurityElement.Escape(numericUpDownDelay1_113.Value.ToString()));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("fanartDelay2", "");
                textWriter.WriteString(SecurityElement.Escape(numericUpDownDelay2_113.Value.ToString()));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("fanartDelay3", "");
                textWriter.WriteString(SecurityElement.Escape(numericUpDownDelay3_113.Value.ToString()));
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
                textWriter.WriteStartElement("fanart", "");
                textWriter.WriteString(SecurityElement.Escape(checkBox114.Checked.ToString()));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("fanartLevels", "");
                textWriter.WriteString(SecurityElement.Escape(numericUpDown114.Value.ToString()));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("parameter", "");
                textWriter.WriteString(SecurityElement.Escape(textBoxParameter114.Text));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("fanartDelay1", "");
                textWriter.WriteString(SecurityElement.Escape(numericUpDownDelay1_114.Value.ToString()));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("fanartDelay2", "");
                textWriter.WriteString(SecurityElement.Escape(numericUpDownDelay2_114.Value.ToString()));
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("fanartDelay3", "");
                textWriter.WriteString(SecurityElement.Escape(numericUpDownDelay3_114.Value.ToString()));
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
                textWriter.WriteStartElement("fanart", "");
                textWriter.WriteString("");
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("fanartlevels", "");
                textWriter.WriteString("1");
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("parameter", "");
                textWriter.WriteString("");
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("fanartDelay1", "");
                textWriter.WriteString("");
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("fanartDelay2", "");
                textWriter.WriteString("");
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("fanartDelay3", "");
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

        private Boolean checkCheckBoxes(String buttonId)
        {

            Boolean found = false;

            if (checkBox100.Checked == true && buttonId == "100") found = true;
            if (checkBox101.Checked == true && buttonId == "101") found = true;
            if (checkBox102.Checked == true && buttonId == "102") found = true;
            if (checkBox103.Checked == true && buttonId == "103") found = true;
            if (checkBox104.Checked == true && buttonId == "104") found = true;
            if (checkBox105.Checked == true && buttonId == "105") found = true;
            if (checkBox106.Checked == true && buttonId == "106") found = true;
            if (checkBox107.Checked == true && buttonId == "107") found = true;
            if (checkBox108.Checked == true && buttonId == "108") found = true;
            if (checkBox109.Checked == true && buttonId == "109") found = true;
            if (checkBox110.Checked == true && buttonId == "110") found = true;
            if (checkBox111.Checked == true && buttonId == "111") found = true;
            if (checkBox112.Checked == true && buttonId == "112") found = true;
            if (checkBox113.Checked == true && buttonId == "113") found = true;
            if (checkBox114.Checked == true && buttonId == "114") found = true;

            return found;
        }

        private String findButtonLeft(String id)
        {

            String ButtonId = id;

            switch (id)
            {

                case "100":
                    ButtonId = "104";
                    break;

                case "101":
                    ButtonId = "100";
                    break;

                case "102":
                    ButtonId = "101";
                    break;

                case "103":
                    ButtonId = "102";
                    break;

                case "104":
                    ButtonId = "103";
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
                    ButtonId = "101";
                    break;

                case "101":
                    ButtonId = "102";
                    break;

                case "102":
                    ButtonId = "103";
                    break;

                case "103":
                    ButtonId = "104";
                    break;

                case "104":
                    ButtonId = "100";
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

        private String buildHoverLabelXml(String id)
        {
            String labelTextbox = String.Empty;

            switch (id)
            {
                case "100":
                    labelTextbox = SecurityElement.Escape(textBox100.Text);
                    break;
                case "101":
                    labelTextbox = SecurityElement.Escape(textBox101.Text);
                    break;
                case "102":
                    labelTextbox = SecurityElement.Escape(textBox102.Text);
                    break;
                case "103":
                    labelTextbox = SecurityElement.Escape(textBox103.Text);
                    break;
                case "104":
                    labelTextbox = SecurityElement.Escape(textBox104.Text);
                    break;
                case "105":
                    labelTextbox = SecurityElement.Escape(textBox105.Text);
                    break;
                case "106":
                    labelTextbox = SecurityElement.Escape(textBox106.Text);
                    break;
                case "107":
                    labelTextbox = SecurityElement.Escape(textBox107.Text);
                    break;
                case "108":
                    labelTextbox = SecurityElement.Escape(textBox108.Text);
                    break;
                case "109":
                    labelTextbox = SecurityElement.Escape(textBox109.Text);
                    break;
                case "110":
                    labelTextbox = SecurityElement.Escape(textBox110.Text);
                    break;
                case "111":
                    labelTextbox = SecurityElement.Escape(textBox111.Text);
                    break;
                case "112":
                    labelTextbox = SecurityElement.Escape(textBox112.Text);
                    break;
                case "113":
                    labelTextbox = SecurityElement.Escape(textBox113.Text);
                    break;
                case "114":
                    labelTextbox = SecurityElement.Escape(textBox114.Text);
                    break;
            }


            String xmloutput = @"<!-- ID " + id + @" -->
		<control>
			<description>" + id + @" hover label</description>
			<type>label</type>
			<id>0</id>
			<posX>0</posX>
			<posY>625</posY>
			<width>1280</width>
			<label>" + labelTextbox + @"</label>
			<font>font37</font>
			<align>center</align>
			<visible>control.hasfocus(" + id + @")</visible>
			<animation effect=""fade"" time=""150"">VisibleChange</animation>
		</control>";

            return xmloutput;
        }


        private String buildButtonXml(String id)
        {
            String labelTextbox = String.Empty;
            String idTextbox = String.Empty;
            String labelTextboxParameter = String.Empty;
            String posX = String.Empty;
            String posY = String.Empty;
            String width = String.Empty;
            String height = String.Empty;
            String condition = String.Empty;
            String ButtonUp = String.Empty;
            String ButtonDown = String.Empty;

            switch (id)
            {
                case "100":
                    labelTextbox = SecurityElement.Escape(textBox100.Text); idTextbox = SecurityElement.Escape(textBoxid100.Text);
                    labelTextboxParameter = SecurityElement.Escape(textBoxParameter100.Text);
                    posX = "100"; posY = "428"; width = "239"; height = "245";
                    if (comboBox105.SelectedItem.ToString() != findPluginName(0)) { ButtonUp = "105"; } else { ButtonUp = "18"; }; ButtonDown = "1111";
                    condition = @"yes";
                    break;
                case "101":
                    labelTextbox = SecurityElement.Escape(textBox101.Text); idTextbox = SecurityElement.Escape(textBoxid101.Text);
                    labelTextboxParameter = SecurityElement.Escape(textBoxParameter101.Text);
                    posX = "336"; posY = "440"; width = "209"; height = "214";
                    if (comboBox106.SelectedItem.ToString() != findPluginName(0)) { ButtonUp = "106"; } else { ButtonUp = "18"; }; ButtonDown = "1111";
                    condition = @"yes";
                    break;
                case "102":
                    labelTextbox = SecurityElement.Escape(textBox102.Text); idTextbox = SecurityElement.Escape(textBoxid102.Text);
                    labelTextboxParameter = SecurityElement.Escape(textBoxParameter102.Text);
                    posX = "542"; posY = "444"; width = "196"; height = "205";
                    if (comboBox107.SelectedItem.ToString() != findPluginName(0)) { ButtonUp = "107"; } else { ButtonUp = "18"; }; ButtonDown = "1111";
                    condition = @"yes";
                    break;
                case "103":
                    labelTextbox = SecurityElement.Escape(textBox103.Text); idTextbox = SecurityElement.Escape(textBoxid103.Text);
                    labelTextboxParameter = SecurityElement.Escape(textBoxParameter103.Text);
                    posX = "736"; posY = "440"; width = "209"; height = "215";
                    if (comboBox108.SelectedItem.ToString() != findPluginName(0)) { ButtonUp = "108"; } else { ButtonUp = "18"; }; ButtonDown = "1111";
                    condition = @"yes";
                    break;
                case "104":
                    labelTextbox = SecurityElement.Escape(textBox104.Text); idTextbox = SecurityElement.Escape(textBoxid104.Text);
                    labelTextboxParameter = SecurityElement.Escape(textBoxParameter104.Text);
                    posX = "941"; posY = "428"; width = "239"; height = "242";
                    if (comboBox109.SelectedItem.ToString() != findPluginName(0)) { ButtonUp = "109"; } else { ButtonUp = "18"; }; ButtonDown = "1111";
                    condition = @"yes";
                    break;
                case "105":
                    labelTextbox = SecurityElement.Escape(textBox105.Text); idTextbox = SecurityElement.Escape(textBoxid105.Text);
                    labelTextboxParameter = SecurityElement.Escape(textBoxParameter105.Text);
                    posX = "114"; posY = "261"; width = "232"; height = "183";
                    if (comboBox110.SelectedItem.ToString() != findPluginName(0)) { ButtonUp = "110"; } else { ButtonUp = "18"; }; ButtonDown = "100";
                    condition = @"control.hasfocus(1000)|control.hasfocus(105)|control.hasfocus(110)";
                    break;
                case "106":
                    labelTextbox = SecurityElement.Escape(textBox106.Text); idTextbox = SecurityElement.Escape(textBoxid106.Text);
                    labelTextboxParameter = SecurityElement.Escape(textBoxParameter106.Text);
                    posX = "342"; posY = "300"; width = "205"; height = "151";
                    if (comboBox111.SelectedItem.ToString() != findPluginName(0)) { ButtonUp = "111"; } else { ButtonUp = "18"; }; ButtonDown = "101";
                    condition = @"control.hasfocus(1001)|control.hasfocus(106)|control.hasfocus(111)";
                    break;
                case "107":
                    labelTextbox = SecurityElement.Escape(textBox107.Text); idTextbox = SecurityElement.Escape(textBoxid107.Text);
                    labelTextboxParameter = SecurityElement.Escape(textBoxParameter107.Text);
                    posX = "543"; posY = "316"; width = "194"; height = "137";
                    if (comboBox112.SelectedItem.ToString() != findPluginName(0)) { ButtonUp = "112"; } else { ButtonUp = "18"; }; ButtonDown = "102";
                    condition = @"control.hasfocus(1002)|control.hasfocus(107)|control.hasfocus(112)";
                    break;
                case "108":
                    labelTextbox = SecurityElement.Escape(textBox108.Text); idTextbox = SecurityElement.Escape(textBoxid108.Text);
                    labelTextboxParameter = SecurityElement.Escape(textBoxParameter108.Text);
                    posX = "733"; posY = "300"; width = "205"; height = "151";
                    if (comboBox113.SelectedItem.ToString() != findPluginName(0)) { ButtonUp = "113"; } else { ButtonUp = "18"; }; ButtonDown = "103";
                    condition = @"control.hasfocus(1003)|control.hasfocus(108)|control.hasfocus(113)";
                    break;
                case "109":
                    labelTextbox = SecurityElement.Escape(textBox109.Text); idTextbox = SecurityElement.Escape(textBoxid109.Text);
                    labelTextboxParameter = SecurityElement.Escape(textBoxParameter109.Text);
                    posX = "935"; posY = "261"; width = "232"; height = "183";
                    if (comboBox114.SelectedItem.ToString() != findPluginName(0)) { ButtonUp = "114"; } else { ButtonUp = "18"; }; ButtonDown = "104";
                    condition = @"control.hasfocus(1004)|control.hasfocus(109)|control.hasfocus(114)";
                    break;
                case "110":
                    labelTextbox = SecurityElement.Escape(textBox110.Text); idTextbox = SecurityElement.Escape(textBoxid110.Text);
                    labelTextboxParameter = SecurityElement.Escape(textBoxParameter110.Text);
                    posX = "126"; posY = "106"; width = "226"; height = "196";
                    ButtonUp = "18"; ButtonDown = "105";
                    condition = @"control.hasfocus(1000)|control.hasfocus(105)|control.hasfocus(110)";
                    break;
                case "111":
                    labelTextbox = SecurityElement.Escape(textBox111.Text); idTextbox = SecurityElement.Escape(textBoxid111.Text);
                    labelTextboxParameter = SecurityElement.Escape(textBoxParameter111.Text);
                    posX = "348"; posY = "168"; width = "201"; height = "154";
                    ButtonUp = "18"; ButtonDown = "106";
                    condition = @"control.hasfocus(1001)|control.hasfocus(106)|control.hasfocus(111)";
                    break;
                case "112":
                    labelTextbox = SecurityElement.Escape(textBox112.Text); idTextbox = SecurityElement.Escape(textBoxid112.Text);
                    labelTextboxParameter = SecurityElement.Escape(textBoxParameter112.Text);
                    posX = "545"; posY = "192"; width = "190"; height = "133";
                    ButtonUp = "18"; ButtonDown = "107";
                    condition = @"control.hasfocus(1002)|control.hasfocus(107)|control.hasfocus(112)";
                    break;
                case "113":
                    labelTextbox = SecurityElement.Escape(textBox113.Text); idTextbox = SecurityElement.Escape(textBoxid113.Text);
                    labelTextboxParameter = SecurityElement.Escape(textBoxParameter113.Text);
                    posX = "731"; posY = "168"; width = "201"; height = "154";
                    ButtonUp = "18"; ButtonDown = "108";
                    condition = @"control.hasfocus(1003)|control.hasfocus(108)|control.hasfocus(113)";
                    break;
                case "114":
                    labelTextbox = SecurityElement.Escape(textBox114.Text); idTextbox = SecurityElement.Escape(textBoxid114.Text);
                    labelTextboxParameter = SecurityElement.Escape(textBoxParameter114.Text);
                    posX = "929"; posY = "106"; width = "225"; height = "196";
                    ButtonUp = "18"; ButtonDown = "109";
                    condition = @"control.hasfocus(1004)|control.hasfocus(109)|control.hasfocus(114)";
                    break;
            }


            String xmloutput = @"
		<control>
			<description>" + id + @" image</description>
			<type>image</type>
			<id>0</id>
			<posX>" + posX + @"</posX>
			<posY>" + posY + @"</posY>
			<width>" + width + @"</width>
			<height>" + height + @"</height>
			<texture>basichome_" + id + @"_nofocus.png</texture>
            <visible>" + condition + @"</visible>
			<animation effect=""fade"" time=""150"">VisibleChange</animation>
		</control>
        <control>
			<description>" + id + @" hover image</description>
			<type>image</type>
			<id>0</id>
			<posX>" + posX + @"</posX>
			<posY>" + posY + @"</posY>
			<width>" + width + @"</width>
			<height>" + height + @"</height>
			<texture>basichome_" + id + @"_focus.png</texture>
            <visible>control.hasfocus(" + id + @")</visible>
			<animation effect=""fade"" time=""150"">VisibleChange</animation>
		</control>
        <control>
			<description>" + id + @" button</description>
			<type>button</type>
			<id>" + id + @"</id>
			<posX>" + posX + @"</posX>
			<posY>" + posY + @"</posY>
			<width>" + width + @"</width>
			<height>" + height + @"</height>
			<label>" + labelTextbox + @"</label>
			<textXOff>3000</textXOff>
			<hyperlink>" + idTextbox + @"</hyperlink>
			<hyperlinkParameter>" + labelTextboxParameter + @"</hyperlinkParameter> 
			<onleft>" + findButtonLeft(id) + @"</onleft>
			<onright>" + findButtonRight(id) + @"</onright>
			<onup>" + ButtonUp + @"</onup>
			<ondown>" + ButtonDown + @"</ondown>
			<textureFocus>-</textureFocus>
			<textureNoFocus>-</textureNoFocus>
        </control>
        ";

            return xmloutput;
        }


        private String buildFanartTextXml(String id)
        {
            String labelTextbox = String.Empty;
            String idTextbox = String.Empty;
            String plugin_trick = String.Empty;
            String pictures_plugin_trick1 = String.Empty;
            String pictures_plugin_trick2 = String.Empty;
            String pictures_plugin_trick3 = String.Empty;
            String plugin_name = String.Empty;
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
                    break;
                case "101":
                    labelTextbox = SecurityElement.Escape(textBox101.Text); idTextbox = SecurityElement.Escape(textBoxid101.Text); fanartLevel = numericUpDown101.Value;
                    break;
                case "102":
                    labelTextbox = SecurityElement.Escape(textBox102.Text); idTextbox = SecurityElement.Escape(textBoxid102.Text); fanartLevel = numericUpDown102.Value;
                    break;
                case "103":
                    labelTextbox = SecurityElement.Escape(textBox103.Text); idTextbox = SecurityElement.Escape(textBoxid103.Text); fanartLevel = numericUpDown103.Value;
                    break;
                case "104":
                    labelTextbox = SecurityElement.Escape(textBox104.Text); idTextbox = SecurityElement.Escape(textBoxid104.Text); fanartLevel = numericUpDown104.Value;
                    break;
                case "105":
                    labelTextbox = SecurityElement.Escape(textBox105.Text); idTextbox = SecurityElement.Escape(textBoxid105.Text); fanartLevel = numericUpDown105.Value;
                    break;
                case "106":
                    labelTextbox = SecurityElement.Escape(textBox106.Text); idTextbox = SecurityElement.Escape(textBoxid106.Text); fanartLevel = numericUpDown106.Value;
                    break;
                case "107":
                    labelTextbox = SecurityElement.Escape(textBox107.Text); idTextbox = SecurityElement.Escape(textBoxid107.Text); fanartLevel = numericUpDown107.Value;
                    break;
                case "108":
                    labelTextbox = SecurityElement.Escape(textBox108.Text); idTextbox = SecurityElement.Escape(textBoxid108.Text); fanartLevel = numericUpDown108.Value;
                    break;
                case "109":
                    labelTextbox = SecurityElement.Escape(textBox109.Text); idTextbox = SecurityElement.Escape(textBoxid109.Text); fanartLevel = numericUpDown109.Value;
                    break;
                case "110":
                    labelTextbox = SecurityElement.Escape(textBox110.Text); idTextbox = SecurityElement.Escape(textBoxid110.Text); fanartLevel = numericUpDown110.Value;
                    break;
                case "111":
                    labelTextbox = SecurityElement.Escape(textBox111.Text); idTextbox = SecurityElement.Escape(textBoxid111.Text); fanartLevel = numericUpDown111.Value;
                    break;
                case "112":
                    labelTextbox = SecurityElement.Escape(textBox112.Text); idTextbox = SecurityElement.Escape(textBoxid112.Text); fanartLevel = numericUpDown112.Value;
                    break;
                case "113":
                    labelTextbox = SecurityElement.Escape(textBox113.Text); idTextbox = SecurityElement.Escape(textBoxid113.Text); fanartLevel = numericUpDown113.Value;
                    break;
                case "114":
                    labelTextbox = SecurityElement.Escape(textBox114.Text); idTextbox = SecurityElement.Escape(textBoxid114.Text); fanartLevel = numericUpDown114.Value;
                    break;
            }

            if (fanartLevel == 1.0M)
            {
                pictures_plugin_trick1 = "+!string.contains(#latestMediaHandler.picture.latest1.thumb,Folder.jpg)";
                text_trick1 = findTextTrick(idTextbox, "1");
                fanartLabel1 = findFanartLabel(idTextbox, "1");
            }
            if (fanartLevel == 2.0M)
            {
                pictures_plugin_trick1 = "+!string.contains(#latestMediaHandler.picture.latest2.thumb,Folder.jpg)"; pictures_plugin_trick2 = "+!string.contains(#latestMediaHandler.picture.latest1.thumb,Folder.jpg)";
                text_trick1 = findTextTrick(idTextbox, "2"); text_trick2 = findTextTrick(idTextbox, "1");
                fanartLabel1 = findFanartLabel(idTextbox, "2"); fanartLabel2 = findFanartLabel(idTextbox, "1");
            }
            if (fanartLevel == 3.0M)
            {
                pictures_plugin_trick1 = "+!string.contains(#latestMediaHandler.picture.latest3.thumb,Folder.jpg)"; pictures_plugin_trick2 = "+!string.contains(#latestMediaHandler.picture.latest2.thumb,Folder.jpg)"; pictures_plugin_trick3 = "+!string.contains(#latestMediaHandler.picture.latest1.thumb,Folder.jpg)";
                text_trick1 = findTextTrick(idTextbox, "3"); text_trick2 = findTextTrick(idTextbox, "2"); text_trick3 = findTextTrick(idTextbox, "1");
                fanartLabel1 = findFanartLabel(idTextbox, "3"); fanartLabel2 = findFanartLabel(idTextbox, "2"); fanartLabel3 = findFanartLabel(idTextbox, "1");
            }

            plugin_name = findFanartPluginName(idTextbox);
            if (idTextbox != "2") { pictures_plugin_trick1 = String.Empty; pictures_plugin_trick2 = String.Empty; pictures_plugin_trick3 = String.Empty; }


            String xmloutput = String.Empty;

            if (fanartLevel == 1.0M) xmloutput = @" 
		<control>
			<description>" + id + @"00 fanart text</description>
			<type>label</type>
			<id>0</id>
			<posX>0</posX>
			<posY>666</posY>
			<width>1280</width>
			<label>" + fanartLabel1 + @"</label>
			<align>center</align>
			<font>font11</font>
			<visible>control.isvisible(" + id + @"00)+plugin.isenabled(Latest Media Handler)+plugin.isenabled(" + plugin_name + @")+control.hasfocus(" + id + @")" + text_trick1 + @"</visible>
			<textcolor>90ffffff</textcolor>
			<animation effect=""fade"" time=""150"">visible</animation>
			<animation effect=""fade"" time=""250"" delay=""250"">WindowOpen</animation>
			<animation effect=""fade"" time=""250"" delay=""0"">WindowClose</animation>
		</control>

        ";

            if (fanartLevel == 2.0M) xmloutput = @" 
		<control>
			<description>" + id + @"00 fanart text</description>
			<type>label</type>
			<id>0</id>
			<posX>0</posX>
			<posY>666</posY>
			<width>1280</width>
			<label>" + fanartLabel1 + @"</label>
			<align>center</align>
			<font>font11</font>
			<visible>control.isvisible(" + id + @"00)+plugin.isenabled(Latest Media Handler)+plugin.isenabled(" + plugin_name + @")+control.hasfocus(" + id + @")" + text_trick1 + @"</visible>
			<textcolor>90ffffff</textcolor>
			<animation effect=""fade"" time=""150"">visible</animation>
			<animation effect=""fade"" time=""250"" delay=""250"">WindowOpen</animation>
			<animation effect=""fade"" time=""250"" delay=""0"">WindowClose</animation>
		</control>
       <control>
			<description>" + id + @"01 fanart text</description>
			<type>label</type>
			<id>0</id>
			<posX>0</posX>
			<posY>666</posY>
			<width>1280</width>
			<label>" + fanartLabel2 + @"</label>
			<align>center</align>
			<font>font11</font>
			<visible>control.isvisible(" + id + @"01)+plugin.isenabled(Latest Media Handler)+plugin.isenabled(" + plugin_name + @")+control.hasfocus(" + id + @")" + text_trick2 + @"</visible>
			<textcolor>90ffffff</textcolor>
			<animation effect=""fade"" time=""150"">visible</animation>
			<animation effect=""fade"" time=""250"" delay=""250"">WindowOpen</animation>
			<animation effect=""fade"" time=""250"" delay=""0"">WindowClose</animation>
		</control>

        ";

            if (fanartLevel == 3.0M) xmloutput = @" 
		<control>
			<description>" + id + @"00 fanart text</description>
			<type>label</type>
			<id>0</id>
			<posX>0</posX>
			<posY>666</posY>
			<width>1280</width>
			<label>" + fanartLabel1 + @"</label>
			<align>center</align>
			<font>font11</font>
			<visible>control.isvisible(" + id + @"00)+plugin.isenabled(Latest Media Handler)+plugin.isenabled(" + plugin_name + @")+control.hasfocus(" + id + @")" + text_trick1 + @"</visible>
			<textcolor>90ffffff</textcolor>
			<animation effect=""fade"" time=""150"">visible</animation>
			<animation effect=""fade"" time=""250"" delay=""250"">WindowOpen</animation>
			<animation effect=""fade"" time=""250"" delay=""0"">WindowClose</animation>
		</control>
        <control>
			<description>" + id + @"01 fanart text</description>
			<type>label</type>
			<id>0</id>
			<posX>0</posX>
			<posY>666</posY>
			<width>1280</width>
			<label>" + fanartLabel2 + @"</label>
			<align>center</align>
			<font>font11</font>
			<visible>control.isvisible(" + id + @"01)+plugin.isenabled(Latest Media Handler)+plugin.isenabled(" + plugin_name + @")+control.hasfocus(" + id + @")" + text_trick2 + @"</visible>
			<textcolor>90ffffff</textcolor>
			<animation effect=""fade"" time=""150"">visible</animation>
			<animation effect=""fade"" time=""250"" delay=""250"">WindowOpen</animation>
			<animation effect=""fade"" time=""250"" delay=""0"">WindowClose</animation>
		</control>
        <control>
			<description>" + id + @"02 fanart text</description>
			<type>label</type>
			<id>0</id>
			<posX>0</posX>
			<posY>666</posY>
			<width>1280</width>
			<label>" + fanartLabel3 + @"</label>
			<align>center</align>
			<font>font11</font>
			<visible>control.isvisible(" + id + @"02)+plugin.isenabled(Latest Media Handler)+plugin.isenabled(" + plugin_name + @")+control.hasfocus(" + id + @")" + text_trick3 + @"</visible>
			<textcolor>90ffffff</textcolor>
			<animation effect=""fade"" time=""150"">visible</animation>
			<animation effect=""fade"" time=""250"" delay=""250"">WindowOpen</animation>
			<animation effect=""fade"" time=""250"" delay=""0"">WindowClose</animation>
		</control>


        ";

            return xmloutput;
        }


        private String buildHoverBackdropXml(String id)
        {
            String labelTextbox = String.Empty;

            switch (id)
            {
                case "100":
                    labelTextbox = SecurityElement.Escape(textBoxhover100.Text);
                    break;
                case "101":
                    labelTextbox = SecurityElement.Escape(textBoxhover101.Text);
                    break;
                case "102":
                    labelTextbox = SecurityElement.Escape(textBoxhover102.Text);
                    break;
                case "103":
                    labelTextbox = SecurityElement.Escape(textBoxhover103.Text);
                    break;
                case "104":
                    labelTextbox = SecurityElement.Escape(textBoxhover104.Text);
                    break;
                case "105":
                    labelTextbox = SecurityElement.Escape(textBoxhover105.Text);
                    break;
                case "106":
                    labelTextbox = SecurityElement.Escape(textBoxhover106.Text);
                    break;
                case "107":
                    labelTextbox = SecurityElement.Escape(textBoxhover107.Text);
                    break;
                case "108":
                    labelTextbox = SecurityElement.Escape(textBoxhover108.Text);
                    break;
                case "109":
                    labelTextbox = SecurityElement.Escape(textBoxhover109.Text);
                    break;
                case "110":
                    labelTextbox = SecurityElement.Escape(textBoxhover110.Text);
                    break;
                case "111":
                    labelTextbox = SecurityElement.Escape(textBoxhover111.Text);
                    break;
                case "112":
                    labelTextbox = SecurityElement.Escape(textBoxhover112.Text);
                    break;
                case "113":
                    labelTextbox = SecurityElement.Escape(textBoxhover113.Text);
                    break;
                case "114":
                    labelTextbox = SecurityElement.Escape(textBoxhover114.Text);
                    break;
            }


            String xmloutput = @"
		<control>
			<description>" + id + @" hover backdrop image</description>
			<type>image</type>
			<id>0</id>
			<posX>0</posX>
			<posY>0</posY>
			<width>1280</width>
			<height>720</height>
			<texture>" + labelTextbox + @".png</texture>
            <visible>control.hasfocus(" + id + @")</visible>
			<animation effect=""fade"" time=""250"">visible</animation>
		</control>
        ";

            return xmloutput;
        }


        private String buildFanartBackdropXml(String id)
        {
            String labelTextbox = String.Empty;
            String idTextbox = String.Empty;
            String plugin_trick = String.Empty;
            String pictures_plugin_trick1 = String.Empty;
            String pictures_plugin_trick2 = String.Empty;
            String pictures_plugin_trick3 = String.Empty;
            String plugin_name = String.Empty;
            String texture_name1 = String.Empty;
            String texture_name2 = String.Empty;
            String texture_name3 = String.Empty;
            Decimal fanartLevel = 1M;
            Decimal fanartDelay1 = 1000M;
            Decimal fanartDelay2 = 2000M;
            Decimal fanartDelay3 = 2000M;


            switch (id)
            {
                case "100":
                    labelTextbox = SecurityElement.Escape(textBox100.Text); idTextbox = SecurityElement.Escape(textBoxid100.Text); fanartLevel = numericUpDown100.Value;
                    fanartDelay1 = numericUpDownDelay1_100.Value; fanartDelay2 = numericUpDownDelay2_100.Value; fanartDelay3 = numericUpDownDelay3_100.Value;
                    break;
                case "101":
                    labelTextbox = SecurityElement.Escape(textBox101.Text); idTextbox = SecurityElement.Escape(textBoxid101.Text); fanartLevel = numericUpDown101.Value;
                    fanartDelay1 = numericUpDownDelay1_101.Value; fanartDelay2 = numericUpDownDelay2_101.Value; fanartDelay3 = numericUpDownDelay3_101.Value;
                    break;
                case "102":
                    labelTextbox = SecurityElement.Escape(textBox102.Text); idTextbox = SecurityElement.Escape(textBoxid102.Text); fanartLevel = numericUpDown102.Value;
                    fanartDelay1 = numericUpDownDelay1_102.Value; fanartDelay2 = numericUpDownDelay2_102.Value; fanartDelay3 = numericUpDownDelay3_102.Value;
                    break;
                case "103":
                    labelTextbox = SecurityElement.Escape(textBox103.Text); idTextbox = SecurityElement.Escape(textBoxid103.Text); fanartLevel = numericUpDown103.Value;
                    fanartDelay1 = numericUpDownDelay1_103.Value; fanartDelay2 = numericUpDownDelay2_103.Value; fanartDelay3 = numericUpDownDelay3_103.Value;
                    break;
                case "104":
                    labelTextbox = SecurityElement.Escape(textBox104.Text); idTextbox = SecurityElement.Escape(textBoxid104.Text); fanartLevel = numericUpDown104.Value;
                    fanartDelay1 = numericUpDownDelay1_104.Value; fanartDelay2 = numericUpDownDelay2_104.Value; fanartDelay3 = numericUpDownDelay3_104.Value;
                    break;
                case "105":
                    labelTextbox = SecurityElement.Escape(textBox105.Text); idTextbox = SecurityElement.Escape(textBoxid105.Text); fanartLevel = numericUpDown105.Value;
                    fanartDelay1 = numericUpDownDelay1_105.Value; fanartDelay2 = numericUpDownDelay2_105.Value; fanartDelay3 = numericUpDownDelay3_105.Value;
                    break;
                case "106":
                    labelTextbox = SecurityElement.Escape(textBox106.Text); idTextbox = SecurityElement.Escape(textBoxid106.Text); fanartLevel = numericUpDown106.Value;
                    fanartDelay1 = numericUpDownDelay1_106.Value; fanartDelay2 = numericUpDownDelay2_106.Value; fanartDelay3 = numericUpDownDelay3_106.Value;
                    break;
                case "107":
                    labelTextbox = SecurityElement.Escape(textBox107.Text); idTextbox = SecurityElement.Escape(textBoxid107.Text); fanartLevel = numericUpDown107.Value;
                    fanartDelay1 = numericUpDownDelay1_107.Value; fanartDelay2 = numericUpDownDelay2_107.Value; fanartDelay3 = numericUpDownDelay3_107.Value;
                    break;
                case "108":
                    labelTextbox = SecurityElement.Escape(textBox108.Text); idTextbox = SecurityElement.Escape(textBoxid108.Text); fanartLevel = numericUpDown108.Value;
                    fanartDelay1 = numericUpDownDelay1_108.Value; fanartDelay2 = numericUpDownDelay2_108.Value; fanartDelay3 = numericUpDownDelay3_108.Value;
                    break;
                case "109":
                    labelTextbox = SecurityElement.Escape(textBox109.Text); idTextbox = SecurityElement.Escape(textBoxid109.Text); fanartLevel = numericUpDown109.Value;
                    fanartDelay1 = numericUpDownDelay1_109.Value; fanartDelay2 = numericUpDownDelay2_109.Value; fanartDelay3 = numericUpDownDelay3_109.Value;
                    break;
                case "110":
                    labelTextbox = SecurityElement.Escape(textBox110.Text); idTextbox = SecurityElement.Escape(textBoxid110.Text); fanartLevel = numericUpDown110.Value;
                    fanartDelay1 = numericUpDownDelay1_110.Value; fanartDelay2 = numericUpDownDelay2_110.Value; fanartDelay3 = numericUpDownDelay3_110.Value;
                    break;
                case "111":
                    labelTextbox = SecurityElement.Escape(textBox111.Text); idTextbox = SecurityElement.Escape(textBoxid111.Text); fanartLevel = numericUpDown111.Value;
                    fanartDelay1 = numericUpDownDelay1_111.Value; fanartDelay2 = numericUpDownDelay2_111.Value; fanartDelay3 = numericUpDownDelay3_111.Value;
                    break;
                case "112":
                    labelTextbox = SecurityElement.Escape(textBox112.Text); idTextbox = SecurityElement.Escape(textBoxid112.Text); fanartLevel = numericUpDown112.Value;
                    fanartDelay1 = numericUpDownDelay1_112.Value; fanartDelay2 = numericUpDownDelay2_112.Value; fanartDelay3 = numericUpDownDelay3_112.Value;
                    break;
                case "113":
                    labelTextbox = SecurityElement.Escape(textBox113.Text); idTextbox = SecurityElement.Escape(textBoxid113.Text); fanartLevel = numericUpDown113.Value;
                    fanartDelay1 = numericUpDownDelay1_113.Value; fanartDelay2 = numericUpDownDelay2_113.Value; fanartDelay3 = numericUpDownDelay3_113.Value;
                    break;
                case "114":
                    labelTextbox = SecurityElement.Escape(textBox114.Text); idTextbox = SecurityElement.Escape(textBoxid114.Text); fanartLevel = numericUpDown114.Value;
                    fanartDelay1 = numericUpDownDelay1_114.Value; fanartDelay2 = numericUpDownDelay2_114.Value; fanartDelay3 = numericUpDownDelay3_114.Value;
                    break;
            }

            if (fanartLevel == 1.0M)
            {
                texture_name1 = findFanartTexture(idTextbox, "1");
                pictures_plugin_trick1 = "+!string.contains(#latestMediaHandler.picture.latest1.thumb,Folder.jpg)";
            }
            if (fanartLevel == 2.0M)
            {
                texture_name1 = findFanartTexture(idTextbox, "2"); texture_name2 = findFanartTexture(idTextbox, "1");
                pictures_plugin_trick1 = "+!string.contains(#latestMediaHandler.picture.latest2.thumb,Folder.jpg)"; pictures_plugin_trick2 = "+!string.contains(#latestMediaHandler.picture.latest1.thumb,Folder.jpg)";
            }
            if (fanartLevel == 3.0M)
            {
                texture_name1 = findFanartTexture(idTextbox, "3"); texture_name2 = findFanartTexture(idTextbox, "2"); texture_name3 = findFanartTexture(idTextbox, "1");
                pictures_plugin_trick1 = "+!string.contains(#latestMediaHandler.picture.latest3.thumb,Folder.jpg)"; pictures_plugin_trick2 = "+!string.contains(#latestMediaHandler.picture.latest2.thumb,Folder.jpg)"; pictures_plugin_trick3 = "+!string.contains(#latestMediaHandler.picture.latest1.thumb,Folder.jpg)";
            }

            plugin_name = findFanartPluginName(idTextbox);
            if (idTextbox != "2") { pictures_plugin_trick1 = String.Empty; pictures_plugin_trick2 = String.Empty; pictures_plugin_trick3 = String.Empty; }


            String xmloutput = String.Empty;

            if (fanartLevel == 1.0M) xmloutput = @" 
		<control>
			<description>" + id + @"00 fanart focused</description>
			<type>image</type>
			<id>" + id + @"00</id>
			<posX>0</posX>
			<posY>0</posY>
			<width>1280</width>
			<height>720</height>
			<keepaspectratio>yes</keepaspectratio>
			<centered>yes</centered>
			<zoom>yes</zoom>
			<texture>" + texture_name1 + @"</texture>
			<visible>plugin.isenabled(Latest Media Handler)+plugin.isenabled(" + plugin_name + @")+control.hasfocus(" + id + @")" + pictures_plugin_trick1 + @"</visible>
			<animation effect=""fade"" time=""200"" delay=""" + fanartDelay1 + @""">visible</animation>
 		</control>

        ";

            if (fanartLevel == 2.0M) xmloutput = @" 
		<control>
			<description>" + id + @"00 fanart focused</description>
			<type>image</type>
			<id>" + id + @"00</id>
			<posX>0</posX>
			<posY>0</posY>
			<width>1280</width>
			<height>720</height>
			<keepaspectratio>yes</keepaspectratio>
			<centered>yes</centered>
			<zoom>yes</zoom>
			<texture>" + texture_name1 + @"</texture>
			<visible>!control.isvisible(" + id + @"01)+plugin.isenabled(Latest Media Handler)+plugin.isenabled(" + plugin_name + @")+control.hasfocus(" + id + @")" + pictures_plugin_trick1 + @"</visible>
			<animation effect=""fade"" time=""200"" delay=""" + fanartDelay1 + @""">visible</animation>
            <animation effect=""fade"" time=""200"">hidden</animation>
		</control>
        <control>
			<description>" + id + @"01 fanart focused</description>
			<type>image</type>
			<id>" + id + @"01</id>
			<posX>0</posX>
			<posY>0</posY>
			<width>1280</width>
			<height>720</height>
			<keepaspectratio>yes</keepaspectratio>
			<centered>yes</centered>
			<zoom>yes</zoom>
			<texture>" + texture_name2 + @"</texture>
			<visible>plugin.isenabled(Latest Media Handler)+plugin.isenabled(" + plugin_name + @")+control.hasfocus(" + id + @")" + pictures_plugin_trick2 + @"</visible>
			<animation effect=""fade"" time=""200"" delay=""" + (fanartDelay1 + fanartDelay2) + @""">visible</animation>
		</control>

        ";

            if (fanartLevel == 3.0M) xmloutput = @" 
		<control>
			<description>" + id + @"00 fanart focused</description>
			<type>image</type>
			<id>" + id + @"00</id>
			<posX>0</posX>
			<posY>0</posY>
			<width>1280</width>
			<height>720</height>
			<keepaspectratio>yes</keepaspectratio>
			<centered>yes</centered>
			<zoom>yes</zoom>
			<texture>" + texture_name1 + @"</texture>
			<visible>!control.isvisible(" + id + @"01)+!control.isvisible(" + id + @"02)+plugin.isenabled(Latest Media Handler)+plugin.isenabled(" + plugin_name + @")+control.hasfocus(" + id + @")" + pictures_plugin_trick1 + @"</visible>
			<animation effect=""fade"" time=""200"" delay=""" + fanartDelay1 + @""">visible</animation>
            <animation effect=""fade"" time=""200"">hidden</animation>
		</control>
        <control>
			<description>" + id + @"01 fanart focused</description>
			<type>image</type>
			<id>" + id + @"01</id>
			<posX>0</posX>
			<posY>0</posY>
			<width>1280</width>
			<height>720</height>
			<keepaspectratio>yes</keepaspectratio>
			<centered>yes</centered>
			<zoom>yes</zoom>
			<texture>" + texture_name2 + @"</texture>
			<visible>!control.isvisible(" + id + @"02)+plugin.isenabled(Latest Media Handler)+plugin.isenabled(" + plugin_name + @")+control.hasfocus(" + id + @")" + pictures_plugin_trick2 + @"</visible>
			<animation effect=""fade"" time=""200"" delay=""" + (fanartDelay1 + fanartDelay2) + @""">visible</animation>
            <animation effect=""fade"" time=""200"">hidden</animation>
		</control>
        <control>
			<description>" + id + @"02 fanart focused</description>
			<type>image</type>
			<id>" + id + @"02</id>
			<posX>0</posX>
			<posY>0</posY>
			<width>1280</width>
			<height>720</height>
			<keepaspectratio>yes</keepaspectratio>
			<centered>yes</centered>
			<zoom>yes</zoom>
			<texture>" + texture_name3 + @"</texture>
			<visible>plugin.isenabled(Latest Media Handler)+plugin.isenabled(" + plugin_name + @")+control.hasfocus(" + id + @")" + pictures_plugin_trick3 + @"</visible>
			<animation effect=""fade"" time=""200"" delay=""" + (fanartDelay1 + fanartDelay2 + fanartDelay3) + @""">visible</animation>
		</control>
        
        ";

            return xmloutput;
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
                    texture = "#latestMediaHandler.music.latest" + level + ".fanart1";
                    break;
                case "501":
                    texture = "#latestMediaHandler.music.latest" + level + ".fanart1";
                    break;
                case "1":
                    texture = "#latestMediaHandler.tvrecordings.latest" + level + ".thumb";
                    break;
                case "2":
                    texture = "#latestMediaHandler.picture.latest" + level + ".thumb";
                    break;
                case "96742":
                    texture = "#latestMediaHandler.movingpicture.latest" + level + ".fanart";
                    break;
                case "9811":
                    texture = "#latestMediaHandler.tvseries.latest" + level + ".fanart";
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
                    trick = "+!string.equals(#latestMediaHandler.music.latest" + level + ".album,)";
                    break;
                case "501":
                    trick = "+!string.equals(#latestMediaHandler.music.latest" + level + ".album,)";
                    break;
                case "1":
                    trick = "+!string.equals(#latestMediaHandler.tvrecordings.latest" + level + ".title,)";
                    break;
                case "2":
                    trick = "+!string.equals(#latestMediaHandler.picture.latest" + level + ".filename,)";
                    break;
                case "96742":
                    trick = "+!string.equals(#latestMediaHandler.movingpicture.latest" + level + ".title,)";
                    break;
                case "9811":
                    trick = "+!string.equals(#latestMediaHandler.tvseries.latest" + level + ".episodeName,)";
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
                    FanartLabel = "#latestMediaHandler.music.latest" + level + ".dateAdded:     #latestMediaHandler.music.latest" + level + ".artist     #latestMediaHandler.music.latest" + level + ".album     #latestMediaHandler.music.latest" + level + ".genre";
                    break;
                case "501":
                    FanartLabel = "#latestMediaHandler.music.latest" + level + ".dateAdded:     #latestMediaHandler.music.latest" + level + ".artist     #latestMediaHandler.music.latest" + level + ".album     #latestMediaHandler.music.latest" + level + ".genre";
                    break;
                case "1":
                    FanartLabel = "#latestMediaHandler.tvrecordings.latest" + level + ".dateAdded:     #latestMediaHandler.tvrecordings.latest" + level + ".title     #latestMediaHandler.tvrecordings.latest" + level + ".genre";
                    break;
                case "2":
                    FanartLabel = "#latestMediaHandler.picture.latest" + level + ".dateAdded:     #latestMediaHandler.picture.latest" + level + ".filename";
                    break;
                case "96742":
                    FanartLabel = "#latestMediaHandler.movingpicture.latest" + level + ".dateAdded:     #latestMediaHandler.movingpicture.latest" + level + ".title     #latestMediaHandler.movingpicture.latest" + level + ".runtime mins     #latestMediaHandler.movingpicture.latest" + level + ".genre     #latestMediaHandler.movingpicture.latest" + level + ".year";
                    break;
                case "9811":
                    FanartLabel = "#latestMediaHandler.tvseries.latest" + level + ".dateAdded:     #latestMediaHandler.tvseries.latest" + level + ".serieName     #latestMediaHandler.tvseries.latest" + level + ".seasonIndexx#latestMediaHandler.tvseries.latest" + level + ".episodeIndex - #latestMediaHandler.tvseries.latest" + level + ".episodeName     #latestMediaHandler.tvseries.latest" + level + ".runtime mins";
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
            myOptionDialog.Hover = textBoxhover110.Text;
            myOptionDialog.Text = "Button 110 Options";
            myOptionDialog.Fanart = checkBox110.Checked;
            myOptionDialog.Levels = numericUpDown110.Value;
            myOptionDialog.ShowFanartControls = true;
            myOptionDialog.Delay1 = numericUpDownDelay1_110.Value; myOptionDialog.Delay2 = numericUpDownDelay2_110.Value; myOptionDialog.Delay3 = numericUpDownDelay3_110.Value;

            if (myOptionDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxid110.Text = myOptionDialog.Id;
                textBox110.Text = myOptionDialog.Description;
                textBoxParameter110.Text = myOptionDialog.Parameter;
                textBoxhover110.Text = myOptionDialog.Hover;
                checkBox110.Checked = myOptionDialog.Fanart;
                numericUpDown110.Value = myOptionDialog.Levels;
                numericUpDownDelay1_110.Value = myOptionDialog.Delay1; numericUpDownDelay2_110.Value = myOptionDialog.Delay2; numericUpDownDelay3_110.Value = myOptionDialog.Delay3;
            }
        }

        private void buttonOptions111_Click(object sender, EventArgs e)
        {
            OptionsDialog myOptionDialog = new OptionsDialog();
            myOptionDialog.Id = textBoxid111.Text;
            myOptionDialog.Description = textBox111.Text;
            myOptionDialog.Parameter = textBoxParameter111.Text;
            myOptionDialog.Hover = textBoxhover111.Text;
            myOptionDialog.Text = "Button 111 Options";
            myOptionDialog.Fanart = checkBox111.Checked;
            myOptionDialog.Levels = numericUpDown111.Value;
            myOptionDialog.ShowFanartControls = true;
            myOptionDialog.Delay1 = numericUpDownDelay1_111.Value; myOptionDialog.Delay2 = numericUpDownDelay2_111.Value; myOptionDialog.Delay3 = numericUpDownDelay3_111.Value;

            if (myOptionDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxid111.Text = myOptionDialog.Id;
                textBox111.Text = myOptionDialog.Description;
                textBoxParameter111.Text = myOptionDialog.Parameter;
                textBoxhover111.Text = myOptionDialog.Hover;
                checkBox111.Checked = myOptionDialog.Fanart;
                numericUpDown111.Value = myOptionDialog.Levels;
                numericUpDownDelay1_111.Value = myOptionDialog.Delay1; numericUpDownDelay2_111.Value = myOptionDialog.Delay2; numericUpDownDelay3_111.Value = myOptionDialog.Delay3;
            }
        }

        private void buttonOptions112_Click(object sender, EventArgs e)
        {
            OptionsDialog myOptionDialog = new OptionsDialog();
            myOptionDialog.Id = textBoxid112.Text;
            myOptionDialog.Description = textBox112.Text;
            myOptionDialog.Parameter = textBoxParameter112.Text;
            myOptionDialog.Hover = textBoxhover112.Text;
            myOptionDialog.Text = "Button 112 Options";
            myOptionDialog.Fanart = checkBox112.Checked;
            myOptionDialog.Levels = numericUpDown112.Value;
            myOptionDialog.ShowFanartControls = true;
            myOptionDialog.Delay1 = numericUpDownDelay1_112.Value; myOptionDialog.Delay2 = numericUpDownDelay2_112.Value; myOptionDialog.Delay3 = numericUpDownDelay3_112.Value;

            if (myOptionDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxid112.Text = myOptionDialog.Id;
                textBox112.Text = myOptionDialog.Description;
                textBoxParameter112.Text = myOptionDialog.Parameter;
                textBoxhover112.Text = myOptionDialog.Hover;
                checkBox112.Checked = myOptionDialog.Fanart;
                numericUpDown112.Value = myOptionDialog.Levels;
                numericUpDownDelay1_112.Value = myOptionDialog.Delay1; numericUpDownDelay2_112.Value = myOptionDialog.Delay2; numericUpDownDelay3_112.Value = myOptionDialog.Delay3;
            }
        }

        private void buttonOptions113_Click(object sender, EventArgs e)
        {
            OptionsDialog myOptionDialog = new OptionsDialog();
            myOptionDialog.Id = textBoxid113.Text;
            myOptionDialog.Description = textBox113.Text;
            myOptionDialog.Parameter = textBoxParameter113.Text;
            myOptionDialog.Hover = textBoxhover113.Text;
            myOptionDialog.Text = "Button 113 Options";
            myOptionDialog.Fanart = checkBox113.Checked;
            myOptionDialog.Levels = numericUpDown113.Value;
            myOptionDialog.ShowFanartControls = true;
            myOptionDialog.Delay1 = numericUpDownDelay1_113.Value; myOptionDialog.Delay2 = numericUpDownDelay2_113.Value; myOptionDialog.Delay3 = numericUpDownDelay3_113.Value;

            if (myOptionDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxid113.Text = myOptionDialog.Id;
                textBox113.Text = myOptionDialog.Description;
                textBoxParameter113.Text = myOptionDialog.Parameter;
                textBoxhover113.Text = myOptionDialog.Hover;
                checkBox113.Checked = myOptionDialog.Fanart;
                numericUpDown113.Value = myOptionDialog.Levels;
                numericUpDownDelay1_113.Value = myOptionDialog.Delay1; numericUpDownDelay2_113.Value = myOptionDialog.Delay2; numericUpDownDelay3_113.Value = myOptionDialog.Delay3;
            }
        }

        private void buttonOptions114_Click(object sender, EventArgs e)
        {
            OptionsDialog myOptionDialog = new OptionsDialog();
            myOptionDialog.Id = textBoxid114.Text;
            myOptionDialog.Description = textBox114.Text;
            myOptionDialog.Parameter = textBoxParameter114.Text;
            myOptionDialog.Hover = textBoxhover114.Text;
            myOptionDialog.Text = "Button 114 Options";
            myOptionDialog.Fanart = checkBox114.Checked;
            myOptionDialog.Levels = numericUpDown114.Value;
            myOptionDialog.ShowFanartControls = true;
            myOptionDialog.Delay1 = numericUpDownDelay1_114.Value; myOptionDialog.Delay2 = numericUpDownDelay2_114.Value; myOptionDialog.Delay3 = numericUpDownDelay3_114.Value;

            if (myOptionDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxid114.Text = myOptionDialog.Id;
                textBox114.Text = myOptionDialog.Description;
                textBoxParameter114.Text = myOptionDialog.Parameter;
                textBoxhover114.Text = myOptionDialog.Hover;
                checkBox114.Checked = myOptionDialog.Fanart;
                numericUpDown114.Value = myOptionDialog.Levels;
                numericUpDownDelay1_114.Value = myOptionDialog.Delay1; numericUpDownDelay2_114.Value = myOptionDialog.Delay2; numericUpDownDelay3_114.Value = myOptionDialog.Delay3;
            }
        }

        private void buttonOptions106_Click(object sender, EventArgs e)
        {
            OptionsDialog myOptionDialog = new OptionsDialog();
            myOptionDialog.Id = textBoxid106.Text;
            myOptionDialog.Description = textBox106.Text;
            myOptionDialog.Parameter = textBoxParameter106.Text;
            myOptionDialog.Hover = textBoxhover106.Text;
            myOptionDialog.Text = "Button 106 Options";
            myOptionDialog.Fanart = checkBox106.Checked;
            myOptionDialog.Levels = numericUpDown106.Value;
            myOptionDialog.ShowFanartControls = true;
            myOptionDialog.Delay1 = numericUpDownDelay1_106.Value; myOptionDialog.Delay2 = numericUpDownDelay2_106.Value; myOptionDialog.Delay3 = numericUpDownDelay3_106.Value;

            if (myOptionDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxid106.Text = myOptionDialog.Id;
                textBox106.Text = myOptionDialog.Description;
                textBoxParameter106.Text = myOptionDialog.Parameter;
                textBoxhover106.Text = myOptionDialog.Hover;
                checkBox106.Checked = myOptionDialog.Fanart;
                numericUpDown106.Value = myOptionDialog.Levels;
                numericUpDownDelay1_106.Value = myOptionDialog.Delay1; numericUpDownDelay2_106.Value = myOptionDialog.Delay2; numericUpDownDelay3_106.Value = myOptionDialog.Delay3;
            }
        }

        private void buttonOptions107_Click(object sender, EventArgs e)
        {
            OptionsDialog myOptionDialog = new OptionsDialog();
            myOptionDialog.Id = textBoxid107.Text;
            myOptionDialog.Description = textBox107.Text;
            myOptionDialog.Parameter = textBoxParameter107.Text;
            myOptionDialog.Hover = textBoxhover107.Text;
            myOptionDialog.Text = "Button 107 Options";
            myOptionDialog.Fanart = checkBox107.Checked;
            myOptionDialog.Levels = numericUpDown107.Value;
            myOptionDialog.ShowFanartControls = true;
            myOptionDialog.Delay1 = numericUpDownDelay1_107.Value; myOptionDialog.Delay2 = numericUpDownDelay2_107.Value; myOptionDialog.Delay3 = numericUpDownDelay3_107.Value;

            if (myOptionDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxid107.Text = myOptionDialog.Id;
                textBox107.Text = myOptionDialog.Description;
                textBoxParameter107.Text = myOptionDialog.Parameter;
                textBoxhover107.Text = myOptionDialog.Hover;
                checkBox107.Checked = myOptionDialog.Fanart;
                numericUpDown107.Value = myOptionDialog.Levels;
                numericUpDownDelay1_107.Value = myOptionDialog.Delay1; numericUpDownDelay2_107.Value = myOptionDialog.Delay2; numericUpDownDelay3_107.Value = myOptionDialog.Delay3;
            }
        }

        private void buttonOptions108_Click(object sender, EventArgs e)
        {
            OptionsDialog myOptionDialog = new OptionsDialog();
            myOptionDialog.Id = textBoxid108.Text;
            myOptionDialog.Description = textBox108.Text;
            myOptionDialog.Parameter = textBoxParameter108.Text;
            myOptionDialog.Hover = textBoxhover108.Text;
            myOptionDialog.Text = "Button 108 Options";
            myOptionDialog.Fanart = checkBox108.Checked;
            myOptionDialog.Levels = numericUpDown108.Value;
            myOptionDialog.ShowFanartControls = true;
            myOptionDialog.Delay1 = numericUpDownDelay1_108.Value; myOptionDialog.Delay2 = numericUpDownDelay2_108.Value; myOptionDialog.Delay3 = numericUpDownDelay3_108.Value;

            if (myOptionDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxid108.Text = myOptionDialog.Id;
                textBox108.Text = myOptionDialog.Description;
                textBoxParameter108.Text = myOptionDialog.Parameter;
                textBoxhover108.Text = myOptionDialog.Hover;
                checkBox108.Checked = myOptionDialog.Fanart;
                numericUpDown108.Value = myOptionDialog.Levels;
                numericUpDownDelay1_108.Value = myOptionDialog.Delay1; numericUpDownDelay2_108.Value = myOptionDialog.Delay2; numericUpDownDelay3_108.Value = myOptionDialog.Delay3;
            }
        }

        private void buttonOptions109_Click(object sender, EventArgs e)
        {
            OptionsDialog myOptionDialog = new OptionsDialog();
            myOptionDialog.Id = textBoxid109.Text;
            myOptionDialog.Description = textBox109.Text;
            myOptionDialog.Parameter = textBoxParameter109.Text;
            myOptionDialog.Hover = textBoxhover109.Text;
            myOptionDialog.Text = "Button 109 Options";
            myOptionDialog.Fanart = checkBox109.Checked;
            myOptionDialog.Levels = numericUpDown109.Value;
            myOptionDialog.ShowFanartControls = true;
            myOptionDialog.Delay1 = numericUpDownDelay1_109.Value; myOptionDialog.Delay2 = numericUpDownDelay2_109.Value; myOptionDialog.Delay3 = numericUpDownDelay3_109.Value;

            if (myOptionDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxid109.Text = myOptionDialog.Id;
                textBox109.Text = myOptionDialog.Description;
                textBoxParameter109.Text = myOptionDialog.Parameter;
                textBoxhover109.Text = myOptionDialog.Hover;
                checkBox109.Checked = myOptionDialog.Fanart;
                numericUpDown109.Value = myOptionDialog.Levels;
                numericUpDownDelay1_109.Value = myOptionDialog.Delay1; numericUpDownDelay2_109.Value = myOptionDialog.Delay2; numericUpDownDelay3_109.Value = myOptionDialog.Delay3;
            }
        }

        private void buttonOptions105_Click(object sender, EventArgs e)
        {
            OptionsDialog myOptionDialog = new OptionsDialog();
            myOptionDialog.Id = textBoxid105.Text;
            myOptionDialog.Description = textBox105.Text;
            myOptionDialog.Parameter = textBoxParameter105.Text;
            myOptionDialog.Hover = textBoxhover105.Text;
            myOptionDialog.Text = "Button 105 Options";
            myOptionDialog.Fanart = checkBox105.Checked;
            myOptionDialog.Levels = numericUpDown105.Value;
            myOptionDialog.ShowFanartControls = true;
            myOptionDialog.Delay1 = numericUpDownDelay1_105.Value; myOptionDialog.Delay2 = numericUpDownDelay2_105.Value; myOptionDialog.Delay3 = numericUpDownDelay3_105.Value;

            if (myOptionDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxid105.Text = myOptionDialog.Id;
                textBox105.Text = myOptionDialog.Description;
                textBoxParameter105.Text = myOptionDialog.Parameter;
                textBoxhover105.Text = myOptionDialog.Hover;
                checkBox105.Checked = myOptionDialog.Fanart;
                numericUpDown105.Value = myOptionDialog.Levels;
                numericUpDownDelay1_105.Value = myOptionDialog.Delay1; numericUpDownDelay2_105.Value = myOptionDialog.Delay2; numericUpDownDelay3_105.Value = myOptionDialog.Delay3;
            }
        }

        private void buttonOptions104_Click(object sender, EventArgs e)
        {
            OptionsDialog myOptionDialog = new OptionsDialog();
            myOptionDialog.Id = textBoxid104.Text;
            myOptionDialog.Description = textBox104.Text;
            myOptionDialog.Parameter = textBoxParameter104.Text;
            myOptionDialog.Hover = textBoxhover104.Text;
            myOptionDialog.Text = "Button 104 Options";
            myOptionDialog.Fanart = checkBox104.Checked;
            myOptionDialog.Levels = numericUpDown104.Value;
            myOptionDialog.ShowFanartControls = true;
            myOptionDialog.Delay1 = numericUpDownDelay1_104.Value; myOptionDialog.Delay2 = numericUpDownDelay2_104.Value; myOptionDialog.Delay3 = numericUpDownDelay3_104.Value;

            if (myOptionDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxid104.Text = myOptionDialog.Id;
                textBox104.Text = myOptionDialog.Description;
                textBoxParameter104.Text = myOptionDialog.Parameter;
                textBoxhover104.Text = myOptionDialog.Hover;
                checkBox104.Checked = myOptionDialog.Fanart;
                numericUpDown104.Value = myOptionDialog.Levels;
                numericUpDownDelay1_104.Value = myOptionDialog.Delay1; numericUpDownDelay2_104.Value = myOptionDialog.Delay2; numericUpDownDelay3_104.Value = myOptionDialog.Delay3;
            }
        }

        private void buttonOptions103_Click(object sender, EventArgs e)
        {
            OptionsDialog myOptionDialog = new OptionsDialog();
            myOptionDialog.Id = textBoxid103.Text;
            myOptionDialog.Description = textBox103.Text;
            myOptionDialog.Parameter = textBoxParameter103.Text;
            myOptionDialog.Hover = textBoxhover103.Text;
            myOptionDialog.Text = "Button 103 Options";
            myOptionDialog.Fanart = checkBox103.Checked;
            myOptionDialog.Levels = numericUpDown103.Value;
            myOptionDialog.ShowFanartControls = true;
            myOptionDialog.Delay1 = numericUpDownDelay1_103.Value; myOptionDialog.Delay2 = numericUpDownDelay2_103.Value; myOptionDialog.Delay3 = numericUpDownDelay3_103.Value;

            if (myOptionDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxid103.Text = myOptionDialog.Id;
                textBox103.Text = myOptionDialog.Description;
                textBoxParameter103.Text = myOptionDialog.Parameter;
                textBoxhover103.Text = myOptionDialog.Hover;
                checkBox103.Checked = myOptionDialog.Fanart;
                numericUpDown103.Value = myOptionDialog.Levels;
                numericUpDownDelay1_103.Value = myOptionDialog.Delay1; numericUpDownDelay2_103.Value = myOptionDialog.Delay2; numericUpDownDelay3_103.Value = myOptionDialog.Delay3;
            }
        }

        private void buttonOptions102_Click(object sender, EventArgs e)
        {
            OptionsDialog myOptionDialog = new OptionsDialog();
            myOptionDialog.Id = textBoxid102.Text;
            myOptionDialog.Description = textBox102.Text;
            myOptionDialog.Parameter = textBoxParameter102.Text;
            myOptionDialog.Hover = textBoxhover102.Text;
            myOptionDialog.Text = "Button 102 Options";
            myOptionDialog.Fanart = checkBox102.Checked;
            myOptionDialog.Levels = numericUpDown102.Value;
            myOptionDialog.ShowFanartControls = true;
            myOptionDialog.Delay1 = numericUpDownDelay1_102.Value; myOptionDialog.Delay2 = numericUpDownDelay2_102.Value; myOptionDialog.Delay3 = numericUpDownDelay3_102.Value;

            if (myOptionDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxid102.Text = myOptionDialog.Id;
                textBox102.Text = myOptionDialog.Description;
                textBoxParameter102.Text = myOptionDialog.Parameter;
                textBoxhover102.Text = myOptionDialog.Hover;
                checkBox102.Checked = myOptionDialog.Fanart;
                numericUpDown102.Value = myOptionDialog.Levels;
                numericUpDownDelay1_102.Value = myOptionDialog.Delay1; numericUpDownDelay2_102.Value = myOptionDialog.Delay2; numericUpDownDelay3_102.Value = myOptionDialog.Delay3;
            }
        }

        private void buttonOptions101_Click(object sender, EventArgs e)
        {
            OptionsDialog myOptionDialog = new OptionsDialog();
            myOptionDialog.Id = textBoxid101.Text;
            myOptionDialog.Description = textBox101.Text;
            myOptionDialog.Parameter = textBoxParameter101.Text;
            myOptionDialog.Hover = textBoxhover101.Text;
            myOptionDialog.Text = "Button 101 Options";
            myOptionDialog.Fanart = checkBox101.Checked;
            myOptionDialog.Levels = numericUpDown101.Value;
            myOptionDialog.ShowFanartControls = true;
            myOptionDialog.Delay1 = numericUpDownDelay1_101.Value; myOptionDialog.Delay2 = numericUpDownDelay2_101.Value; myOptionDialog.Delay3 = numericUpDownDelay3_101.Value;

            if (myOptionDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxid101.Text = myOptionDialog.Id;
                textBox101.Text = myOptionDialog.Description;
                textBoxParameter101.Text = myOptionDialog.Parameter;
                textBoxhover101.Text = myOptionDialog.Hover;
                checkBox101.Checked = myOptionDialog.Fanart;
                numericUpDown101.Value = myOptionDialog.Levels;
                numericUpDownDelay1_101.Value = myOptionDialog.Delay1; numericUpDownDelay2_101.Value = myOptionDialog.Delay2; numericUpDownDelay3_101.Value = myOptionDialog.Delay3;
            }
        }

        private void buttonOptions100_Click(object sender, EventArgs e)
        {
            OptionsDialog myOptionDialog = new OptionsDialog();
            myOptionDialog.Id = textBoxid100.Text;
            myOptionDialog.Description = textBox100.Text;
            myOptionDialog.Parameter = textBoxParameter100.Text;
            myOptionDialog.Hover = textBoxhover100.Text;
            myOptionDialog.Text = "Button 100 Options";
            myOptionDialog.Fanart = checkBox100.Checked;
            myOptionDialog.Levels = numericUpDown100.Value;
            myOptionDialog.ShowFanartControls = true;
            myOptionDialog.Delay1 = numericUpDownDelay1_100.Value; myOptionDialog.Delay2 = numericUpDownDelay2_100.Value; myOptionDialog.Delay3 = numericUpDownDelay3_100.Value;

            if (myOptionDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxid100.Text = myOptionDialog.Id;
                textBox100.Text = myOptionDialog.Description;
                textBoxParameter100.Text = myOptionDialog.Parameter;
                textBoxhover100.Text = myOptionDialog.Hover;
                checkBox100.Checked = myOptionDialog.Fanart;
                numericUpDown100.Value = myOptionDialog.Levels;
                numericUpDownDelay1_100.Value = myOptionDialog.Delay1; numericUpDownDelay2_100.Value = myOptionDialog.Delay2; numericUpDownDelay3_100.Value = myOptionDialog.Delay3;
            }
        }

    }


}