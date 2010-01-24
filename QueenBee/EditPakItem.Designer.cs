namespace Nanook.QueenBee
{
    partial class EditPakItem
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
            this.lblItemPath = new System.Windows.Forms.Label();
            this.txtItemPath = new System.Windows.Forms.TextBox();
            this.lblFileType = new System.Windows.Forms.Label();
            this.chkFilename = new System.Windows.Forms.CheckBox();
            this.grpPakItem = new System.Windows.Forms.GroupBox();
            this.lblOther = new System.Windows.Forms.Label();
            this.txtOther = new System.Windows.Forms.TextBox();
            this.cboFileType = new System.Windows.Forms.ComboBox();
            this.lblImport = new System.Windows.Forms.Label();
            this.txtImport = new System.Windows.Forms.TextBox();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnInfo = new System.Windows.Forms.Button();
            this.open = new System.Windows.Forms.OpenFileDialog();
            this.grpPakItem.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblItemPath
            // 
            this.lblItemPath.AutoSize = true;
            this.lblItemPath.Location = new System.Drawing.Point(9, 22);
            this.lblItemPath.Name = "lblItemPath";
            this.lblItemPath.Size = new System.Drawing.Size(98, 13);
            this.lblItemPath.TabIndex = 0;
            this.lblItemPath.Text = "Path and Filename:";
            // 
            // txtItemPath
            // 
            this.txtItemPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtItemPath.Location = new System.Drawing.Point(12, 38);
            this.txtItemPath.Name = "txtItemPath";
            this.txtItemPath.Size = new System.Drawing.Size(304, 20);
            this.txtItemPath.TabIndex = 2;
            // 
            // lblFileType
            // 
            this.lblFileType.AutoSize = true;
            this.lblFileType.Location = new System.Drawing.Point(8, 67);
            this.lblFileType.Name = "lblFileType";
            this.lblFileType.Size = new System.Drawing.Size(34, 13);
            this.lblFileType.TabIndex = 3;
            this.lblFileType.Text = "Type:";
            // 
            // chkFilename
            // 
            this.chkFilename.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkFilename.AutoSize = true;
            this.chkFilename.Location = new System.Drawing.Point(163, 21);
            this.chkFilename.Name = "chkFilename";
            this.chkFilename.Size = new System.Drawing.Size(155, 17);
            this.chkFilename.TabIndex = 1;
            this.chkFilename.Text = "Include Filename in Header";
            this.chkFilename.UseVisualStyleBackColor = true;
            // 
            // grpPakItem
            // 
            this.grpPakItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpPakItem.Controls.Add(this.lblOther);
            this.grpPakItem.Controls.Add(this.txtOther);
            this.grpPakItem.Controls.Add(this.cboFileType);
            this.grpPakItem.Controls.Add(this.chkFilename);
            this.grpPakItem.Controls.Add(this.lblItemPath);
            this.grpPakItem.Controls.Add(this.txtItemPath);
            this.grpPakItem.Controls.Add(this.lblFileType);
            this.grpPakItem.Location = new System.Drawing.Point(1, 2);
            this.grpPakItem.Name = "grpPakItem";
            this.grpPakItem.Size = new System.Drawing.Size(328, 94);
            this.grpPakItem.TabIndex = 0;
            this.grpPakItem.TabStop = false;
            this.grpPakItem.Text = "PAK Item Header Details";
            // 
            // lblOther
            // 
            this.lblOther.AutoSize = true;
            this.lblOther.Location = new System.Drawing.Point(138, 67);
            this.lblOther.Name = "lblOther";
            this.lblOther.Size = new System.Drawing.Size(36, 13);
            this.lblOther.TabIndex = 5;
            this.lblOther.Text = "Other:";
            this.lblOther.Visible = false;
            // 
            // txtOther
            // 
            this.txtOther.Location = new System.Drawing.Point(177, 64);
            this.txtOther.Name = "txtOther";
            this.txtOther.Size = new System.Drawing.Size(92, 20);
            this.txtOther.TabIndex = 6;
            this.txtOther.Visible = false;
            // 
            // cboFileType
            // 
            this.cboFileType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFileType.FormattingEnabled = true;
            this.cboFileType.Location = new System.Drawing.Point(48, 63);
            this.cboFileType.Name = "cboFileType";
            this.cboFileType.Size = new System.Drawing.Size(84, 21);
            this.cboFileType.TabIndex = 4;
            this.cboFileType.SelectedIndexChanged += new System.EventHandler(this.cboFileType_SelectedIndexChanged);
            // 
            // lblImport
            // 
            this.lblImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblImport.AutoSize = true;
            this.lblImport.Location = new System.Drawing.Point(1, 104);
            this.lblImport.Name = "lblImport";
            this.lblImport.Size = new System.Drawing.Size(39, 13);
            this.lblImport.TabIndex = 1;
            this.lblImport.Text = "Import:";
            // 
            // txtImport
            // 
            this.txtImport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtImport.Location = new System.Drawing.Point(42, 101);
            this.txtImport.Name = "txtImport";
            this.txtImport.Size = new System.Drawing.Size(260, 20);
            this.txtImport.TabIndex = 2;
            // 
            // btnImport
            // 
            this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImport.Location = new System.Drawing.Point(304, 101);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(25, 22);
            this.btnImport.TabIndex = 3;
            this.btnImport.Text = "...";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(173, 130);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(254, 130);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnInfo
            // 
            this.btnInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnInfo.Location = new System.Drawing.Point(1, 130);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(75, 23);
            this.btnInfo.TabIndex = 4;
            this.btnInfo.Text = "Info...";
            this.btnInfo.UseVisualStyleBackColor = true;
            this.btnInfo.Click += new System.EventHandler(this.btnInfo_Click);
            // 
            // open
            // 
            this.open.Title = "Open File";
            // 
            // EditPakItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 155);
            this.Controls.Add(this.btnInfo);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.grpPakItem);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.txtImport);
            this.Controls.Add(this.lblImport);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditPakItem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New PAK Item";
            this.grpPakItem.ResumeLayout(false);
            this.grpPakItem.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblItemPath;
        private System.Windows.Forms.TextBox txtItemPath;
        private System.Windows.Forms.Label lblFileType;
        private System.Windows.Forms.CheckBox chkFilename;
        private System.Windows.Forms.GroupBox grpPakItem;
        private System.Windows.Forms.Label lblImport;
        private System.Windows.Forms.TextBox txtImport;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnInfo;
        private System.Windows.Forms.ComboBox cboFileType;
        private System.Windows.Forms.OpenFileDialog open;
        private System.Windows.Forms.Label lblOther;
        private System.Windows.Forms.TextBox txtOther;
    }
}