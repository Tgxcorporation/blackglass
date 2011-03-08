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

        private void buttonOk_Click(object sender, EventArgs e)
        {
            mId = textBoxId.Text;
            mDescription = textBoxDescription.Text;
            mParameter = textBoxParameter.Text;
        }
    }
}
