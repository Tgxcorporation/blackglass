namespace BlackGlassEditor
{
    partial class OptionsDialog
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Liberare le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.textBoxId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxParameter = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBoxFanart = new System.Windows.Forms.CheckBox();
            this.numericUpDownLevels = new System.Windows.Forms.NumericUpDown();
            this.labelFanart = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLevels)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Location = new System.Drawing.Point(71, 127);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(100, 24);
            this.buttonOk.TabIndex = 0;
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(199, 127);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(100, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // textBoxId
            // 
            this.textBoxId.Location = new System.Drawing.Point(12, 12);
            this.textBoxId.Name = "textBoxId";
            this.textBoxId.Size = new System.Drawing.Size(254, 20);
            this.textBoxId.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(272, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Plugin Id";
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Location = new System.Drawing.Point(12, 38);
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(254, 20);
            this.textBoxDescription.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(272, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Plugin Name";
            // 
            // textBoxParameter
            // 
            this.textBoxParameter.Location = new System.Drawing.Point(12, 64);
            this.textBoxParameter.Name = "textBoxParameter";
            this.textBoxParameter.Size = new System.Drawing.Size(254, 20);
            this.textBoxParameter.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(272, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Plugin Parameter";
            // 
            // checkBoxFanart
            // 
            this.checkBoxFanart.AutoSize = true;
            this.checkBoxFanart.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.checkBoxFanart.ForeColor = System.Drawing.Color.White;
            this.checkBoxFanart.Location = new System.Drawing.Point(12, 91);
            this.checkBoxFanart.Name = "checkBoxFanart";
            this.checkBoxFanart.Padding = new System.Windows.Forms.Padding(4, 3, 3, 2);
            this.checkBoxFanart.Size = new System.Drawing.Size(111, 22);
            this.checkBoxFanart.TabIndex = 8;
            this.checkBoxFanart.Text = "Fanart Enabled?";
            this.checkBoxFanart.UseVisualStyleBackColor = false;
            this.checkBoxFanart.CheckedChanged += new System.EventHandler(this.checkBoxFanart_CheckedChanged);
            // 
            // numericUpDownLevels
            // 
            this.numericUpDownLevels.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownLevels.Location = new System.Drawing.Point(140, 91);
            this.numericUpDownLevels.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDownLevels.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownLevels.Name = "numericUpDownLevels";
            this.numericUpDownLevels.Size = new System.Drawing.Size(49, 22);
            this.numericUpDownLevels.TabIndex = 9;
            this.numericUpDownLevels.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // labelFanart
            // 
            this.labelFanart.AutoSize = true;
            this.labelFanart.Location = new System.Drawing.Point(195, 95);
            this.labelFanart.Name = "labelFanart";
            this.labelFanart.Size = new System.Drawing.Size(71, 13);
            this.labelFanart.TabIndex = 10;
            this.labelFanart.Text = "Fanart Levels";
            // 
            // OptionsDialog
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(371, 163);
            this.Controls.Add(this.labelFanart);
            this.Controls.Add(this.numericUpDownLevels);
            this.Controls.Add(this.checkBoxFanart);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxParameter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxDescription);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxId);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "OptionsDialog";
            this.Text = "Options";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLevels)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TextBox textBoxId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxParameter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBoxFanart;
        private System.Windows.Forms.NumericUpDown numericUpDownLevels;
        private System.Windows.Forms.Label labelFanart;
    }
}