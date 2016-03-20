namespace Growler
{
    partial class GrowlerSettingsPanel
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.checkBoxSilent = new System.Windows.Forms.CheckBox();
            this.checkBoxIgnoreClose = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // checkBoxSilent
            // 
            this.checkBoxSilent.AutoSize = true;
            this.checkBoxSilent.Location = new System.Drawing.Point(14, 19);
            this.checkBoxSilent.Name = "checkBoxSilent";
            this.checkBoxSilent.Size = new System.Drawing.Size(111, 17);
            this.checkBoxSilent.TabIndex = 0;
            this.checkBoxSilent.Text = "Silent notifications";
            this.checkBoxSilent.UseVisualStyleBackColor = true;
            this.checkBoxSilent.CheckedChanged += new System.EventHandler(this.checkBoxSilent_CheckedChanged);
            // 
            // checkBoxIgnoreClose
            // 
            this.checkBoxIgnoreClose.AutoSize = true;
            this.checkBoxIgnoreClose.Location = new System.Drawing.Point(14, 42);
            this.checkBoxIgnoreClose.Name = "checkBoxIgnoreClose";
            this.checkBoxIgnoreClose.Size = new System.Drawing.Size(239, 17);
            this.checkBoxIgnoreClose.TabIndex = 1;
            this.checkBoxIgnoreClose.Text = "Ignore Growl commands to close notifications";
            this.checkBoxIgnoreClose.UseVisualStyleBackColor = true;
            this.checkBoxIgnoreClose.CheckedChanged += new System.EventHandler(this.checkBoxIgnoreClose_CheckedChanged);
            // 
            // GrowlerSettingsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.checkBoxIgnoreClose);
            this.Controls.Add(this.checkBoxSilent);
            this.Name = "GrowlerSettingsPanel";
            this.Load += new System.EventHandler(this.GrowlerSettingsPanel_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxSilent;
        private System.Windows.Forms.CheckBox checkBoxIgnoreClose;
    }
}
