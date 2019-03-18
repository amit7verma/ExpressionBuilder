namespace ExpressionBuilder.Forms
{
    partial class ExpressionBuilderForm
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
            this.editorTextBox = new System.Windows.Forms.RichTextBox();
            this.okButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.descriptionTextBox = new System.Windows.Forms.RichTextBox();
            this.selectorListBox = new System.Windows.Forms.ListBox();
            this.OpsFuncsListBox = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // editorTextBox
            // 
            this.editorTextBox.Location = new System.Drawing.Point(12, 15);
            this.editorTextBox.Name = "editorTextBox";
            this.editorTextBox.Size = new System.Drawing.Size(447, 120);
            this.editorTextBox.TabIndex = 0;
            this.editorTextBox.Text = "";
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(273, 12);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(93, 23);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(380, 12);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(79, 23);
            this.CancelButton.TabIndex = 2;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(12, 12);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.descriptionTextBox);
            this.splitContainer1.Panel1.Controls.Add(this.selectorListBox);
            this.splitContainer1.Panel1.Controls.Add(this.OpsFuncsListBox);
            this.splitContainer1.Panel1.Controls.Add(this.editorTextBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.okButton);
            this.splitContainer1.Panel2.Controls.Add(this.CancelButton);
            this.splitContainer1.Size = new System.Drawing.Size(470, 419);
            this.splitContainer1.SplitterDistance = 368;
            this.splitContainer1.TabIndex = 3;
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Location = new System.Drawing.Point(318, 174);
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.ReadOnly = true;
            this.descriptionTextBox.Size = new System.Drawing.Size(141, 160);
            this.descriptionTextBox.TabIndex = 4;
            this.descriptionTextBox.Text = "";
            // 
            // selectorListBox
            // 
            this.selectorListBox.FormattingEnabled = true;
            this.selectorListBox.Location = new System.Drawing.Point(169, 174);
            this.selectorListBox.Name = "selectorListBox";
            this.selectorListBox.Size = new System.Drawing.Size(131, 160);
            this.selectorListBox.TabIndex = 3;
            this.selectorListBox.SelectedIndexChanged += new System.EventHandler(this.On_SelectorSelectedIndexChanged);
            // 
            // OpsFuncsListBox
            // 
            this.OpsFuncsListBox.FormattingEnabled = true;
            this.OpsFuncsListBox.Location = new System.Drawing.Point(12, 174);
            this.OpsFuncsListBox.Name = "OpsFuncsListBox";
            this.OpsFuncsListBox.Size = new System.Drawing.Size(138, 160);
            this.OpsFuncsListBox.TabIndex = 2;
            this.OpsFuncsListBox.SelectedIndexChanged += new System.EventHandler(this.On_OpsFuncsSelectedIndexChanged);
            // 
            // ExpressionBuilderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 443);
            this.Controls.Add(this.splitContainer1);
            this.Name = "ExpressionBuilderForm";
            this.Text = "Expression Editor";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox editorTextBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RichTextBox descriptionTextBox;
        private System.Windows.Forms.ListBox selectorListBox;
        private System.Windows.Forms.ListBox OpsFuncsListBox;
    }
}