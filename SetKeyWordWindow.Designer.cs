namespace Work_Timer
{
    partial class KeyWordSetter
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.KeyWordBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // KeyWordBox
            // 
            this.KeyWordBox.Location = new System.Drawing.Point(12, 12);
            this.KeyWordBox.Multiline = true;
            this.KeyWordBox.Name = "KeyWordBox";
            this.KeyWordBox.Size = new System.Drawing.Size(352, 220);
            this.KeyWordBox.TabIndex = 0;
            // 
            // KeyWordSetter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 244);
            this.Controls.Add(this.KeyWordBox);
            this.Name = "KeyWordSetter";
            this.Text = "Set Key Words";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.KeyWordSetter_FormClosing);
            this.Load += new System.EventHandler(this.KeyWordSetter_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox KeyWordBox;
    }
}