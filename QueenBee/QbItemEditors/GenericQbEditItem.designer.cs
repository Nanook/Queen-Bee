namespace Nanook.QueenBee
{
    partial class GenericQbEditItem
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
            this.lbl = new System.Windows.Forms.Label();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.err = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnConvert = new System.Windows.Forms.Button();
            this.menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuFloat = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInt = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUint = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHex = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuString = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.err)).BeginInit();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Location = new System.Drawing.Point(5, 6);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(35, 13);
            this.lbl.TabIndex = 0;
            this.lbl.Text = "label1";
            // 
            // txtValue
            // 
            this.txtValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.err.SetIconPadding(this.txtValue, 42);
            this.txtValue.Location = new System.Drawing.Point(66, 3);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(43, 20);
            this.txtValue.TabIndex = 1;
            // 
            // err
            // 
            this.err.ContainerControl = this;
            // 
            // btnConvert
            // 
            this.btnConvert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConvert.Location = new System.Drawing.Point(108, 2);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(42, 22);
            this.btnConvert.TabIndex = 2;
            this.btnConvert.Text = "float";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFloat,
            this.mnuInt,
            this.mnuUint,
            this.mnuHex,
            this.mnuString});
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(153, 136);
            // 
            // mnuFloat
            // 
            this.mnuFloat.Name = "mnuFloat";
            this.mnuFloat.Size = new System.Drawing.Size(152, 22);
            this.mnuFloat.Text = "Edit as Float";
            this.mnuFloat.Click += new System.EventHandler(this.mnu_Click);
            // 
            // mnuInt
            // 
            this.mnuInt.Name = "mnuInt";
            this.mnuInt.Size = new System.Drawing.Size(152, 22);
            this.mnuInt.Text = "Edit as Int";
            this.mnuInt.Click += new System.EventHandler(this.mnu_Click);
            // 
            // mnuUint
            // 
            this.mnuUint.Name = "mnuUint";
            this.mnuUint.Size = new System.Drawing.Size(152, 22);
            this.mnuUint.Text = "Edit as UInt";
            this.mnuUint.Click += new System.EventHandler(this.mnu_Click);
            // 
            // mnuHex
            // 
            this.mnuHex.Name = "mnuHex";
            this.mnuHex.Size = new System.Drawing.Size(152, 22);
            this.mnuHex.Text = "Edit as Hex";
            this.mnuHex.Click += new System.EventHandler(this.mnu_Click);
            // 
            // mnuString
            // 
            this.mnuString.Name = "mnuString";
            this.mnuString.Size = new System.Drawing.Size(152, 22);
            this.mnuString.Text = "Edit as String";
            this.mnuString.Click += new System.EventHandler(this.mnu_Click);
            // 
            // GenericQbEditItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.lbl);
            this.Name = "GenericQbEditItem";
            this.Size = new System.Drawing.Size(174, 24);
            ((System.ComponentModel.ISupportInitialize)(this.err)).EndInit();
            this.menu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.ErrorProvider err;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.ContextMenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem mnuFloat;
        private System.Windows.Forms.ToolStripMenuItem mnuInt;
        private System.Windows.Forms.ToolStripMenuItem mnuUint;
        private System.Windows.Forms.ToolStripMenuItem mnuHex;
        private System.Windows.Forms.ToolStripMenuItem mnuString;
    }
}
