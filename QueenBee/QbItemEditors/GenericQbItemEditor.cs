using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Nanook.QueenBee.Parser;

namespace Nanook.QueenBee
{
    internal class GenericQbItemEditor : QbItemEditorBase
    {
        public GenericQbItemEditor() : base()
        {
            InitializeComponent();
        }

        private void GenericQbItemEditor_Load(object sender, EventArgs e)
        {
            bool tooManyItems = false;
            int spacing = 22;
            int top = 20;
            int tabIndex = this.TabIndex;
            int lblWidth = 0;

            List<GenericQbItem> gis = QbFile.GetGenericItems(base.QbItem);

            if (gis.Count > 500)
            {
                tooManyItems = true;
                this.AutoScrollMinSize = new Size(0, (top * 2) + (spacing * (1 + 1) + 10)); //+ 1 for button
            }
            else
                this.AutoScrollMinSize = new Size(0, (top * 2) + (spacing * (gis.Count + 1) + 10)); //+ 1 for button

            this.Tag = base.QbItem; //store item for update

            bool hasEditable = false;

            try
            {
                int qbItemFound = 0;
                if (gis.Count > 0 && gis[gis.Count - 1].SourceProperty == "ItemQbKey") //nasty hack
                {
                    addEditItem(spacing, ref top, ref lblWidth, ref hasEditable, gis[gis.Count - 1]);
                    qbItemFound = 1;
                }

                if (!tooManyItems)
                {
                    for (int i = 0; i < gis.Count - qbItemFound; i++)
                        addEditItem(spacing, ref top, ref lblWidth, ref hasEditable, gis[i]);
                }
            }
            catch (Exception ex)
            {
                base.ShowException("Edit Item List Error", ex);
            }

            foreach (GenericQbEditItem et in this.Controls)
                et.TextBoxLeft = lblWidth + 6;

            try
            {
                if (this.Controls.Count != 0)
                {
                    Button btnUpdateItems = new Button();
                    btnUpdateItems.Text = "&Update";
                    btnUpdateItems.Anchor = AnchorStyles.Top | AnchorStyles.Right;
                    btnUpdateItems.Left = (this.ClientSize.Width - btnUpdateItems.Width - 15);
                    btnUpdateItems.Top = top + 10;
                    btnUpdateItems.Height = 22;
                    btnUpdateItems.Enabled = hasEditable;
                    btnUpdateItems.Click += new EventHandler(btnUpdateItems_Click);
                    this.Controls.Add(btnUpdateItems);
                }

                if (tooManyItems)
                    base.ShowError("Too Many Items", string.Format("This item contains {0} items. It is likely that it should be edited by a dedicated application.", gis.Count.ToString()));
            }
            catch (Exception ex)
            {
                base.ShowException("Update Button Error", ex);
            }
        }

        private void addEditItem(int spacing, ref int top, ref int lblWidth, ref bool hasEditable, GenericQbItem gi)
        {
            GenericQbEditItem ei;
            ei = new GenericQbEditItem();
            ei.SetData(gi);
            ei.Left = 0;
            ei.Width = this.ClientSize.Width;
            ei.Top = top;
            top += spacing;
            ei.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;

            if (!hasEditable && !gi.ReadOnly)
                hasEditable = true;

            if (gi.UseQbItemType)
                ei.ConvertTo(base.QbItemDataType);
            //else
            //    ei.ConvertTo(base.EditType);

            this.Controls.Add(ei);

            if (ei.LabelWidth > lblWidth)
                lblWidth = ei.LabelWidth;
        }



        private void btnUpdateItems_Click(object sender, EventArgs e)
        {
            List<GenericQbItem> gis = new List<GenericQbItem>();
            GenericQbEditItem ei;
            GenericQbItem gi;

            //check that all the items are valid before saving

            try
            {
                //Check if QbKey is in the debug file, if not then add it to the user defined list
                base.AddQbKeyToUserDebugFile(base.QbItem.ItemQbKey);

                foreach (Control un in this.Controls)
                {
                    if ((ei = (un as GenericQbEditItem)) != null)
                    {
                        if (!ei.IsValid)
                        {
                            base.ShowError("Error", "QB cannot be updated while data is invalid.");
                            return;
                        }
                        gi = ei.GenericQbItem;

                        //if QbKey, check to see if it's in the debug file, if not then add it to the user defined list
                        if (gi.Type == typeof(QbKey))
                            AddQbKeyToUserDebugFile(gi.ToQbKey());

                        gis.Add(gi);
                    }
                }
            }
            catch (Exception ex)
            {
                base.ShowException("Failed to Get Item Values", ex);
                return;
            }

            try
            {
                QbFile.SetGenericItems(base.QbItem, gis);
            }
            catch (Exception ex)
            {
                base.ShowException("Edit Values Update Error", ex);
                return;
            }

            base.UpdateQbItem();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // GenericQbItemEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Name = "GenericQbItemEditor";
            this.Load += new System.EventHandler(this.GenericQbItemEditor_Load);
            this.ResumeLayout(false);

        }

    }
}
