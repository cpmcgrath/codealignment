namespace CMcG.CodeAlignment
{
    partial class FormKeyGrabber
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
            System.Windows.Forms.Label lblDescription;
            System.Windows.Forms.PictureBox icon;
            lblDescription = new System.Windows.Forms.Label();
            icon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(icon)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDescription
            // 
            lblDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            lblDescription.Location = new System.Drawing.Point(106, 0);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new System.Drawing.Size(394, 20);
            lblDescription.TabIndex = 0;
            lblDescription.Text = "Waiting for second key of chord...";
            lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // icon
            // 
            icon.Dock = System.Windows.Forms.DockStyle.Left;
            icon.Image = global::CMcG.CodeAlignment.Properties.Resources.CodeAlignmentBanner96x16;
            icon.Location = new System.Drawing.Point(0, 0);
            icon.Name = "icon";
            icon.Size = new System.Drawing.Size(106, 20);
            icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            icon.TabIndex = 1;
            icon.TabStop = false;
            // 
            // FormKeyGrabber
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 20);
            this.Controls.Add(lblDescription);
            this.Controls.Add(icon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(500, 80);
            this.Name = "FormKeyGrabber";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "FormKeyGrabber";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDown);
            ((System.ComponentModel.ISupportInitialize)(icon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion


    }
}