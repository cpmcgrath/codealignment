namespace CMcG.CodeAlignment.Options
{
    partial class ShortcutLine
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
            this.components = new System.ComponentModel.Container();
            this.cboKey = new System.Windows.Forms.ComboBox();
            this.bindShortcut = new System.Windows.Forms.BindingSource(this.components);
            this.bindKeyLookup = new System.Windows.Forms.BindingSource(this.components);
            this.txtShortcut = new System.Windows.Forms.TextBox();
            this.chkFromCaret = new System.Windows.Forms.CheckBox();
            this.chkRegex = new System.Windows.Forms.CheckBox();
            this.chkAddSpace = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.bindShortcut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindKeyLookup)).BeginInit();
            this.SuspendLayout();
            // 
            // cboKey
            // 
            this.cboKey.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bindShortcut, "Value", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cboKey.DataSource = this.bindKeyLookup;
            this.cboKey.DisplayMember = "Description";
            this.cboKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKey.FormattingEnabled = true;
            this.cboKey.Location = new System.Drawing.Point(3, 3);
            this.cboKey.Name = "cboKey";
            this.cboKey.Size = new System.Drawing.Size(126, 23);
            this.cboKey.TabIndex = 0;
            this.cboKey.ValueMember = "Value";
            // 
            // bindShortcut
            // 
            this.bindShortcut.DataSource = typeof(CMcG.CodeAlignment.Business.KeyShortcut);
            // 
            // bindKeyLookup
            // 
            this.bindKeyLookup.DataSource = typeof(CMcG.CodeAlignment.Options.KeyLookup);
            // 
            // txtShortcut
            // 
            this.txtShortcut.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtShortcut.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindShortcut, "Alignment", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtShortcut.Location = new System.Drawing.Point(135, 3);
            this.txtShortcut.Name = "txtShortcut";
            this.txtShortcut.Size = new System.Drawing.Size(153, 23);
            this.txtShortcut.TabIndex = 1;
            // 
            // chkFromCaret
            // 
            this.chkFromCaret.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkFromCaret.AutoSize = true;
            this.chkFromCaret.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindShortcut, "AlignFromCaret", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkFromCaret.Location = new System.Drawing.Point(324, 7);
            this.chkFromCaret.Margin = new System.Windows.Forms.Padding(33, 3, 3, 3);
            this.chkFromCaret.Name = "chkFromCaret";
            this.chkFromCaret.Size = new System.Drawing.Size(15, 14);
            this.chkFromCaret.TabIndex = 2;
            this.chkFromCaret.UseVisualStyleBackColor = true;
            // 
            // chkRegex
            // 
            this.chkRegex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkRegex.AutoSize = true;
            this.chkRegex.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindShortcut, "UseRegex", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkRegex.Location = new System.Drawing.Point(390, 7);
            this.chkRegex.Margin = new System.Windows.Forms.Padding(41, 3, 3, 3);
            this.chkRegex.Name = "chkRegex";
            this.chkRegex.Size = new System.Drawing.Size(15, 14);
            this.chkRegex.TabIndex = 3;
            this.chkRegex.UseVisualStyleBackColor = true;
            // 
            // chkAddSpace
            // 
            this.chkAddSpace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkAddSpace.AutoSize = true;
            this.chkAddSpace.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindShortcut, "AddSpace", true));
            this.chkAddSpace.Location = new System.Drawing.Point(456, 7);
            this.chkAddSpace.Margin = new System.Windows.Forms.Padding(41, 3, 3, 3);
            this.chkAddSpace.Name = "chkAddSpace";
            this.chkAddSpace.Size = new System.Drawing.Size(15, 14);
            this.chkAddSpace.TabIndex = 5;
            this.chkAddSpace.UseVisualStyleBackColor = true;
            // 
            // ShortcutLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkAddSpace);
            this.Controls.Add(this.chkRegex);
            this.Controls.Add(this.chkFromCaret);
            this.Controls.Add(this.txtShortcut);
            this.Controls.Add(this.cboKey);
            this.Name = "ShortcutLine";
            this.Size = new System.Drawing.Size(511, 29);
            ((System.ComponentModel.ISupportInitialize)(this.bindShortcut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindKeyLookup)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboKey;
        private System.Windows.Forms.TextBox txtShortcut;
        private System.Windows.Forms.CheckBox chkFromCaret;
        private System.Windows.Forms.CheckBox chkRegex;
        private System.Windows.Forms.BindingSource bindShortcut;
        private System.Windows.Forms.BindingSource bindKeyLookup;
        private System.Windows.Forms.CheckBox chkAddSpace;
    }
}
