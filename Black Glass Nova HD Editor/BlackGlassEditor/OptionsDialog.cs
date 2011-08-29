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

        private string mHover;
        public string Hover
        {
            get { return mHover; }
            set { textBoxHover.Text = value; }
        }
		
		private Decimal mDelay1;
        public Decimal Delay1
        {
            get { return mDelay1; }
            set { numericUpDownDelay1.Value = value; } 
        }

        private Decimal mDelay2;
        public Decimal Delay2
        {
            get { return mDelay2; }
            set { numericUpDownDelay2.Value = value; }
        }

        private Decimal mDelay3;
        public Decimal Delay3
        {
            get { return mDelay3; }
            set { numericUpDownDelay3.Value = value; }
        }

        //private Boolean mShowFanartControls;
        public Boolean ShowFanartControls
        {
            //get { return mShowFanartControls; }
            set
            {
                if (value == true)
                {
                    checkBoxFanart.Visible = true; groupBoxFanart.Visible = true; 
                    if (checkBoxFanart.Checked == false) { groupBoxFanart.Visible = false; }
                    if (textBoxId.Text != "504" && textBoxId.Text != "501" && textBoxId.Text != "96742" && textBoxId.Text != "1" && textBoxId.Text != "9811" && textBoxId.Text != "2600" && textBoxId.Text != "2")
                    {  groupBoxFanart.Visible = false; checkBoxFanart.Visible = false; }
                }
                if (value == false) { groupBoxFanart.Visible = false; }
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            mId = textBoxId.Text;
            mDescription = textBoxDescription.Text;
            mParameter = textBoxParameter.Text;
            mFanart = checkBoxFanart.Checked;
            mLevels = numericUpDownLevels.Value;
            mHover = textBoxHover.Text;
			mDelay1 = numericUpDownDelay1.Value;
            mDelay2 = numericUpDownDelay2.Value;
            mDelay3 = numericUpDownDelay3.Value;
        }

        private void checkBoxFanart_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked == true) { groupBoxFanart.Visible = true; }
            if (((CheckBox)sender).Checked == false) { groupBoxFanart.Visible = false; }
        }
		
		 private void numericUpDownLevels_ValueChanged(object sender, EventArgs e)
        {
            if (((NumericUpDown)sender).Value == 1) { numericUpDownDelay2.Visible = false; numericUpDownDelay3.Visible = false; labelDelay2.Visible = false; labelDelay3.Visible = false; }
            if (((NumericUpDown)sender).Value == 2) { numericUpDownDelay2.Visible = true; numericUpDownDelay3.Visible = false; labelDelay2.Visible = true; labelDelay3.Visible = false; }
            if (((NumericUpDown)sender).Value == 3) { numericUpDownDelay2.Visible = true; numericUpDownDelay3.Visible = true; labelDelay2.Visible = true; labelDelay3.Visible = true; }
        }

    }
}
