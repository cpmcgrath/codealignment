namespace CMcG.CodeAlignment.Options
{
    partial class ScreenShortcuts
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
            this.lblAddSpace = new System.Windows.Forms.Label();
            this.btnRestoreDefaults = new System.Windows.Forms.Button();
            this.lblIsRegex = new System.Windows.Forms.Label();
            this.lblFromCaret = new System.Windows.Forms.Label();
            this.lblAlignment = new System.Windows.Forms.Label();
            this.lblKey = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.listShortcut = new CMcG.CodeAlignment.Controls.ListControl();
            this.SuspendLayout();
            // 
            // lblAddSpace
            // 
            this.lblAddSpace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAddSpace.AutoSize = true;
            this.lblAddSpace.Location = new System.Drawing.Point(494, 14);
            this.lblAddSpace.Name = "lblAddSpace";
            this.lblAddSpace.Size = new System.Drawing.Size(65, 15);
            this.lblAddSpace.TabIndex = 9;
            this.lblAddSpace.Text = "Add space:";
            // 
            // btnRestoreDefaults
            // 
            this.btnRestoreDefaults.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRestoreDefaults.Location = new System.Drawing.Point(444, 282);
            this.btnRestoreDefaults.Margin = new System.Windows.Forms.Padding(3, 3, 3, 12);
            this.btnRestoreDefaults.Name = "btnRestoreDefaults";
            this.btnRestoreDefaults.Size = new System.Drawing.Size(125, 23);
            this.btnRestoreDefaults.TabIndex = 8;
            this.btnRestoreDefaults.Text = "Restore &defaults";
            this.btnRestoreDefaults.UseVisualStyleBackColor = true;
            this.btnRestoreDefaults.Click += new System.EventHandler(this.RestoreDefaults);
            // 
            // lblIsRegex
            // 
            this.lblIsRegex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblIsRegex.AutoSize = true;
            this.lblIsRegex.Location = new System.Drawing.Point(439, 14);
            this.lblIsRegex.Name = "lblIsRegex";
            this.lblIsRegex.Size = new System.Drawing.Size(49, 15);
            this.lblIsRegex.TabIndex = 6;
            this.lblIsRegex.Text = "Is regex:";
            // 
            // lblFromCaret
            // 
            this.lblFromCaret.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFromCaret.AutoSize = true;
            this.lblFromCaret.Location = new System.Drawing.Point(365, 14);
            this.lblFromCaret.Name = "lblFromCaret";
            this.lblFromCaret.Size = new System.Drawing.Size(67, 15);
            this.lblFromCaret.TabIndex = 5;
            this.lblFromCaret.Text = "From caret:";
            // 
            // lblAlignment
            // 
            this.lblAlignment.AutoSize = true;
            this.lblAlignment.Location = new System.Drawing.Point(147, 14);
            this.lblAlignment.Name = "lblAlignment";
            this.lblAlignment.Size = new System.Drawing.Size(66, 15);
            this.lblAlignment.TabIndex = 4;
            this.lblAlignment.Text = "Alignment:";
            // 
            // lblKey
            // 
            this.lblKey.AutoSize = true;
            this.lblKey.Location = new System.Drawing.Point(12, 14);
            this.lblKey.Name = "lblKey";
            this.lblKey.Size = new System.Drawing.Size(29, 15);
            this.lblKey.TabIndex = 2;
            this.lblKey.Text = "Key:";
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(575, 282);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 3, 3, 12);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(35, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "+";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.AddShortcut);
            // 
            // listShortcut
            // 
            this.listShortcut.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listShortcut.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.listShortcut.Items = null;
            this.listShortcut.Location = new System.Drawing.Point(12, 32);
            this.listShortcut.Margin = new System.Windows.Forms.Padding(12, 3, 12, 3);
            this.listShortcut.Name = "listShortcut";
            this.listShortcut.Size = new System.Drawing.Size(598, 244);
            this.listShortcut.TabIndex = 3;
            this.listShortcut.ViewType = typeof(CMcG.CodeAlignment.Options.ShortcutLine);
            // 
            // ScreenShortcuts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.listShortcut);
            this.Controls.Add(this.lblAddSpace);
            this.Controls.Add(this.btnRestoreDefaults);
            this.Controls.Add(this.lblIsRegex);
            this.Controls.Add(this.lblFromCaret);
            this.Controls.Add(this.lblAlignment);
            this.Controls.Add(this.lblKey);
            this.Controls.Add(this.btnAdd);
            this.Name = "ScreenShortcuts";
            this.Size = new System.Drawing.Size(622, 317);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblKey;
        private System.Windows.Forms.Label lblAlignment;
        private System.Windows.Forms.Label lblFromCaret;
        private System.Windows.Forms.Label lblIsRegex;
        private System.Windows.Forms.Button btnRestoreDefaults;
        private System.Windows.Forms.Label lblAddSpace;
        private Controls.ListControl listShortcut;
    }
}
