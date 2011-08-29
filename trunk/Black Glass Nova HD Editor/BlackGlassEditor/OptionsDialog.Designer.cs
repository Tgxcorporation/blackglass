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
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxHover = new System.Windows.Forms.TextBox();
            this.checkBoxFanart = new System.Windows.Forms.CheckBox();
            this.groupBoxFanart = new System.Windows.Forms.GroupBox();
            this.numericUpDownDelay3 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownDelay2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownDelay1 = new System.Windows.Forms.NumericUpDown();
            this.labelDelay3 = new System.Windows.Forms.Label();
            this.labelDelay2 = new System.Windows.Forms.Label();
            this.labelDelay1 = new System.Windows.Forms.Label();
            this.numericUpDownLevels = new System.Windows.Forms.NumericUpDown();
            this.labelFanart = new System.Windows.Forms.Label();
            this.groupBoxFanart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDelay3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDelay2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDelay1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLevels)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Location = new System.Drawing.Point(86, 296);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(100, 23);
            this.buttonOk.TabIndex = 0;
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(215, 296);
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(272, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Hover Image";
            // 
            // textBoxHover
            // 
            this.textBoxHover.Location = new System.Drawing.Point(12, 90);
            this.textBoxHover.Name = "textBoxHover";
            this.textBoxHover.Size = new System.Drawing.Size(254, 20);
            this.textBoxHover.TabIndex = 8;
            // 
            // checkBoxFanart
            // 
            this.checkBoxFanart.AutoSize = true;
            this.checkBoxFanart.Location = new System.Drawing.Point(12, 116);
            this.checkBoxFanart.Name = "checkBoxFanart";
            this.checkBoxFanart.Padding = new System.Windows.Forms.Padding(4, 3, 3, 2);
            this.checkBoxFanart.Size = new System.Drawing.Size(111, 22);
            this.checkBoxFanart.TabIndex = 14;
            this.checkBoxFanart.Text = "Fanart Enabled?";
            this.checkBoxFanart.UseVisualStyleBackColor = false;
            this.checkBoxFanart.CheckedChanged += new System.EventHandler(this.checkBoxFanart_CheckedChanged);
            // 
            // groupBoxFanart
            // 
            this.groupBoxFanart.Controls.Add(this.numericUpDownDelay3);
            this.groupBoxFanart.Controls.Add(this.numericUpDownDelay2);
            this.groupBoxFanart.Controls.Add(this.numericUpDownDelay1);
            this.groupBoxFanart.Controls.Add(this.labelDelay3);
            this.groupBoxFanart.Controls.Add(this.labelDelay2);
            this.groupBoxFanart.Controls.Add(this.labelDelay1);
            this.groupBoxFanart.Controls.Add(this.numericUpDownLevels);
            this.groupBoxFanart.Controls.Add(this.labelFanart);
            this.groupBoxFanart.Location = new System.Drawing.Point(14, 141);
            this.groupBoxFanart.Name = "groupBoxFanart";
            this.groupBoxFanart.Size = new System.Drawing.Size(380, 140);
            this.groupBoxFanart.TabIndex = 15;
            this.groupBoxFanart.TabStop = false;
            this.groupBoxFanart.Text = "Fanart";
            // 
            // numericUpDownDelay3
            // 
            this.numericUpDownDelay3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownDelay3.Location = new System.Drawing.Point(6, 106);
            this.numericUpDownDelay3.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numericUpDownDelay3.Name = "numericUpDownDelay3";
            this.numericUpDownDelay3.Size = new System.Drawing.Size(59, 22);
            this.numericUpDownDelay3.TabIndex = 19;
            this.numericUpDownDelay3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownDelay3.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // numericUpDownDelay2
            // 
            this.numericUpDownDelay2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownDelay2.Location = new System.Drawing.Point(6, 78);
            this.numericUpDownDelay2.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numericUpDownDelay2.Name = "numericUpDownDelay2";
            this.numericUpDownDelay2.Size = new System.Drawing.Size(59, 22);
            this.numericUpDownDelay2.TabIndex = 18;
            this.numericUpDownDelay2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownDelay2.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // numericUpDownDelay1
            // 
            this.numericUpDownDelay1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownDelay1.Location = new System.Drawing.Point(6, 50);
            this.numericUpDownDelay1.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numericUpDownDelay1.Name = "numericUpDownDelay1";
            this.numericUpDownDelay1.Size = new System.Drawing.Size(59, 22);
            this.numericUpDownDelay1.TabIndex = 17;
            this.numericUpDownDelay1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownDelay1.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // labelDelay3
            // 
            this.labelDelay3.AutoSize = true;
            this.labelDelay3.Location = new System.Drawing.Point(71, 110);
            this.labelDelay3.Name = "labelDelay3";
            this.labelDelay3.Size = new System.Drawing.Size(289, 13);
            this.labelDelay3.TabIndex = 16;
            this.labelDelay3.Text = "Delay in ms for the 3rd Fanart to appear after the 2nd Fanart";
            // 
            // labelDelay2
            // 
            this.labelDelay2.AutoSize = true;
            this.labelDelay2.Location = new System.Drawing.Point(71, 82);
            this.labelDelay2.Name = "labelDelay2";
            this.labelDelay2.Size = new System.Drawing.Size(288, 13);
            this.labelDelay2.TabIndex = 14;
            this.labelDelay2.Text = "Delay in ms for the 2nd Fanart to appear after the 1st Fanart";
            // 
            // labelDelay1
            // 
            this.labelDelay1.AutoSize = true;
            this.labelDelay1.Location = new System.Drawing.Point(71, 54);
            this.labelDelay1.Name = "labelDelay1";
            this.labelDelay1.Size = new System.Drawing.Size(192, 13);
            this.labelDelay1.TabIndex = 12;
            this.labelDelay1.Text = "Delay in ms for the 1st Fanart to appear";
            // 
            // numericUpDownLevels
            // 
            this.numericUpDownLevels.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownLevels.Location = new System.Drawing.Point(27, 22);
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
            this.numericUpDownLevels.Size = new System.Drawing.Size(38, 22);
            this.numericUpDownLevels.TabIndex = 9;
            this.numericUpDownLevels.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownLevels.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownLevels.ValueChanged += new System.EventHandler(this.numericUpDownLevels_ValueChanged);
            // 
            // labelFanart
            // 
            this.labelFanart.AutoSize = true;
            this.labelFanart.Location = new System.Drawing.Point(71, 26);
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
            this.ClientSize = new System.Drawing.Size(404, 334);
            this.Controls.Add(this.checkBoxFanart);
            this.Controls.Add(this.groupBoxFanart);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxHover);
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
            this.groupBoxFanart.ResumeLayout(false);
            this.groupBoxFanart.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDelay3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDelay2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDelay1)).EndInit();
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
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxHover;
        private System.Windows.Forms.CheckBox checkBoxFanart;
        private System.Windows.Forms.GroupBox groupBoxFanart;
        private System.Windows.Forms.NumericUpDown numericUpDownDelay3;
        private System.Windows.Forms.NumericUpDown numericUpDownDelay2;
        private System.Windows.Forms.NumericUpDown numericUpDownDelay1;
        private System.Windows.Forms.Label labelDelay3;
        private System.Windows.Forms.Label labelDelay2;
        private System.Windows.Forms.Label labelDelay1;
        private System.Windows.Forms.NumericUpDown numericUpDownLevels;
        private System.Windows.Forms.Label labelFanart;
    }
}