namespace CMcG.CodeAlignment.Options
{
    partial class ScreenSelectors
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
            this.lblXmlTypes = new System.Windows.Forms.Label();
            this.txtXmlTypes = new System.Windows.Forms.TextBox();
            this.bindOptions = new System.Windows.Forms.BindingSource(this.components);
            this.btnRestoreDefaults = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindOptions)).BeginInit();
            this.SuspendLayout();
            // 
            // lblXmlTypes
            // 
            this.lblXmlTypes.AutoSize = true;
            this.lblXmlTypes.Location = new System.Drawing.Point(12, 68);
            this.lblXmlTypes.Name = "lblXmlTypes";
            this.lblXmlTypes.Size = new System.Drawing.Size(65, 15);
            this.lblXmlTypes.TabIndex = 0;
            this.lblXmlTypes.Text = "XML Types";
            // 
            // txtXmlTypes
            // 
            this.txtXmlTypes.AcceptsReturn = true;
            this.txtXmlTypes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtXmlTypes.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindOptions, "XmlTypesString", true));
            this.txtXmlTypes.Location = new System.Drawing.Point(15, 86);
            this.txtXmlTypes.Multiline = true;
            this.txtXmlTypes.Name = "txtXmlTypes";
            this.txtXmlTypes.Size = new System.Drawing.Size(135, 190);
            this.txtXmlTypes.TabIndex = 1;
            // 
            // bindOptions
            // 
            this.bindOptions.DataSource = typeof(CMcG.CodeAlignment.Business.Options);
            // 
            // btnRestoreDefaults
            // 
            this.btnRestoreDefaults.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRestoreDefaults.Location = new System.Drawing.Point(484, 282);
            this.btnRestoreDefaults.Margin = new System.Windows.Forms.Padding(3, 3, 3, 12);
            this.btnRestoreDefaults.Name = "btnRestoreDefaults";
            this.btnRestoreDefaults.Size = new System.Drawing.Size(125, 23);
            this.btnRestoreDefaults.TabIndex = 9;
            this.btnRestoreDefaults.Text = "Restore &defaults";
            this.btnRestoreDefaults.UseVisualStyleBackColor = true;
            this.btnRestoreDefaults.Click += new System.EventHandler(this.RestoreDefaults);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(247, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = "End of scope line values (seperate with space)";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindOptions, "ScopeSelectorLineValues", true));
            this.textBox1.Location = new System.Drawing.Point(265, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(344, 23);
            this.textBox1.TabIndex = 11;
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindOptions, "ScopeSelectorLineEnds", true));
            this.textBox2.Location = new System.Drawing.Point(265, 41);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(344, 23);
            this.textBox2.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(239, 15);
            this.label2.TabIndex = 12;
            this.label2.Text = "End of scope line ends (seperate with space)";
            // 
            // ScreenSelectors
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRestoreDefaults);
            this.Controls.Add(this.txtXmlTypes);
            this.Controls.Add(this.lblXmlTypes);
            this.Name = "ScreenSelectors";
            this.Size = new System.Drawing.Size(622, 317);
            ((System.ComponentModel.ISupportInitialize)(this.bindOptions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblXmlTypes;
        private System.Windows.Forms.TextBox txtXmlTypes;
        private System.Windows.Forms.BindingSource bindOptions;
        private System.Windows.Forms.Button btnRestoreDefaults;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
    }
}
