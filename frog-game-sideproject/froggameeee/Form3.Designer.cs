
namespace froggameeee
{
    partial class Form3
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
            this.froggo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.froggo)).BeginInit();
            this.SuspendLayout();
            // 
            // froggo
            // 
            this.froggo.Image = global::froggameeee.Properties.Resources.frog_boy_right;
            this.froggo.Location = new System.Drawing.Point(12, 36);
            this.froggo.Name = "froggo";
            this.froggo.Size = new System.Drawing.Size(88, 82);
            this.froggo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.froggo.TabIndex = 0;
            this.froggo.TabStop = false;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.froggo);
            this.Name = "Form3";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.froggo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox froggo;
    }
}