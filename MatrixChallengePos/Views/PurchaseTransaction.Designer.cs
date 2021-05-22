
namespace MatrixChallengePos.ViewModels
{
    partial class PurchaseTransaction
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lstProductSearchResults = new System.Windows.Forms.ListBox();
            this.txtSearchProductName = new System.Windows.Forms.TextBox();
            this.cboSearchProductCategories = new System.Windows.Forms.ComboBox();
            this.cmdAddFoundProductsToTransaction = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmdAddFoundProductsToTransaction);
            this.groupBox1.Controls.Add(this.cboSearchProductCategories);
            this.groupBox1.Controls.Add(this.txtSearchProductName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lstProductSearchResults);
            this.groupBox1.Location = new System.Drawing.Point(14, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(225, 357);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Product Search";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Product Category:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Product Name:";
            // 
            // lstProductSearchResults
            // 
            this.lstProductSearchResults.FormattingEnabled = true;
            this.lstProductSearchResults.ItemHeight = 15;
            this.lstProductSearchResults.Location = new System.Drawing.Point(21, 147);
            this.lstProductSearchResults.Name = "lstProductSearchResults";
            this.lstProductSearchResults.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstProductSearchResults.Size = new System.Drawing.Size(189, 169);
            this.lstProductSearchResults.TabIndex = 3;
            // 
            // txtSearchProductName
            // 
            this.txtSearchProductName.Location = new System.Drawing.Point(24, 50);
            this.txtSearchProductName.Name = "txtSearchProductName";
            this.txtSearchProductName.Size = new System.Drawing.Size(186, 23);
            this.txtSearchProductName.TabIndex = 6;
            // 
            // cboSearchProductCategories
            // 
            this.cboSearchProductCategories.FormattingEnabled = true;
            this.cboSearchProductCategories.Location = new System.Drawing.Point(24, 104);
            this.cboSearchProductCategories.Name = "cboSearchProductCategories";
            this.cboSearchProductCategories.Size = new System.Drawing.Size(186, 23);
            this.cboSearchProductCategories.TabIndex = 7;
            // 
            // cmdAddFoundProductsToTransaction
            // 
            this.cmdAddFoundProductsToTransaction.Location = new System.Drawing.Point(24, 328);
            this.cmdAddFoundProductsToTransaction.Name = "cmdAddFoundProductsToTransaction";
            this.cmdAddFoundProductsToTransaction.Size = new System.Drawing.Size(186, 23);
            this.cmdAddFoundProductsToTransaction.TabIndex = 8;
            this.cmdAddFoundProductsToTransaction.Text = "Add Selected Products";
            this.cmdAddFoundProductsToTransaction.UseVisualStyleBackColor = true;
            // 
            // PurchaseTransaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "PurchaseTransaction";
            this.Size = new System.Drawing.Size(576, 551);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button cmdAddFoundProductsToTransaction;
        private System.Windows.Forms.ComboBox cboSearchProductCategories;
        private System.Windows.Forms.TextBox txtSearchProductName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstProductSearchResults;
    }
}
