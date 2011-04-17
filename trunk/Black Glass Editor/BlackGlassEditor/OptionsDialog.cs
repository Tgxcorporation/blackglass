using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BlackGlassEditor
{
    public partial class OptionsDialog : Form
    {
        public OptionsDialog()
        {
            InitializeComponent();
        }

        private string mId;
        public string Id
        {
            get { return mId; }
            set { textBoxId.Text = value; }
        }

        private string mDescription;
        public string Description
        {
            get { return mDescription; }
            set { textBoxDescription.Text = value; }
        }

        private string mParameter;
        public string Parameter
        {
            get { return mParameter; }
            set { textBoxParameter.Text = value; }
        }

        private Boolean mFanart;
        public Boolean Fanart
        {
            get { return mFanart; }
            set { checkBoxFanart.Checked = value; }
        }

        private Decimal mLevels;
        public Decimal Levels
        {
            get { return mLevels; }
            set { numericUpDownLevels.Value = value; }
        }

        //private Boolean mShowFanartControls;
        public Boolean ShowFanartControls
        {
            //get { return mShowFanartControls; }
            set
            {
                if (value == true)
                {
                    checkBoxFanart.Visible = true; numericUpDownLevels.Visible = true; labelFanart.Visible = true;
                    if (checkBoxFanart.Checked == false) { numericUpDownLevels.Visible = false; labelFanart.Visible = false; }
                    if (textBoxId.Text != "504" && textBoxId.Text != "501" && textBoxId.Text != "96742" && textBoxId.Text != "1" && textBoxId.Text != "9811" && textBoxId.Text != "2600" && textBoxId.Text != "2")
                    { checkBoxFanart.Visible = false; numericUpDownLevels.Visible = false; labelFanart.Visible = false; }
                }
                if (value == false) { checkBoxFanart.Visible = false; numericUpDownLevels.Visible = false; labelFanart.Visible = false; }
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            mId = textBoxId.Text;
            mDescription = textBoxDescription.Text;
            mParameter = textBoxParameter.Text;
            mFanart = checkBoxFanart.Checked;
            mLevels = numericUpDownLevels.Value;
        }

        private void checkBoxFanart_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked == true) { numericUpDownLevels.Visible = true; labelFanart.Visible = true; }
            if (((CheckBox)sender).Checked == false) { numericUpDownLevels.Visible = false; labelFanart.Visible = false; }
        }
    }
}
