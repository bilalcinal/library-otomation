
namespace PresentationLayer
{
    partial class Graphic
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
            this.lbıdstdntGraphic = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbıdstdntGraphic
            // 
            this.lbıdstdntGraphic.AutoSize = true;
            this.lbıdstdntGraphic.Location = new System.Drawing.Point(324, 80);
            this.lbıdstdntGraphic.Name = "lbıdstdntGraphic";
            this.lbıdstdntGraphic.Size = new System.Drawing.Size(46, 17);
            this.lbıdstdntGraphic.TabIndex = 0;
            this.lbıdstdntGraphic.Text = "label1";
            // 
            // Graphic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbıdstdntGraphic);
            this.Name = "Graphic";
            this.Text = "Graphic";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lbıdstdntGraphic;
    }
}