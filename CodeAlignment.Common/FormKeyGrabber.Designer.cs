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
            lblDescription = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblDescription
            // 
            lblDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            lblDescription.Location = new System.Drawing.Point(0, 0);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new System.Drawing.Size(450, 20);
            lblDescription.TabIndex = 0;
            lblDescription.Text = "Code alignment started, waiting for second shortcut key";
            lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FormKeyGrabber
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 20);
            this.Controls.Add(lblDescription);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(450, 20);
            this.Name = "FormKeyGrabber";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "FormKeyGrabber";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDown);
            this.ResumeLayout(false);

        }

        #endregion


    }
}