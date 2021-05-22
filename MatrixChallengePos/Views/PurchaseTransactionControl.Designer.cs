
namespace MatrixChallengePos.Views
{
    partial class PurchaseTransactionControl
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
            this.cmdAddFoundProductsToTransaction = new System.Windows.Forms.Button();
            this.cboSearchProductCategories = new System.Windows.Forms.ComboBox();
            this.txtSearchProductName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lstProductSearchResults = new System.Windows.Forms.ListBox();
            this.grpTransaction = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTransactionSubtotal = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTransactionTax = new System.Windows.Forms.Label();
            this.lblTransactionTotal = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmdPay = new System.Windows.Forms.Button();
            this.cmdCancelTransaction = new System.Windows.Forms.Button();
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
            // cmdAddFoundProductsToTransaction
            // 
            this.cmdAddFoundProductsToTransaction.Enabled = false;
            this.cmdAddFoundProductsToTransaction.Location = new System.Drawing.Point(24, 328);
            this.cmdAddFoundProductsToTransaction.Name = "cmdAddFoundProductsToTransaction";
            this.cmdAddFoundProductsToTransaction.Size = new System.Drawing.Size(186, 23);
            this.cmdAddFoundProductsToTransaction.TabIndex = 8;
            this.cmdAddFoundProductsToTransaction.Text = "Add Selected Products";
            this.cmdAddFoundProductsToTransaction.UseVisualStyleBackColor = true;
            this.cmdAddFoundProductsToTransaction.Click += new System.EventHandler(this.cmdAddFoundProductsToTransaction_Click);
            // 
            // cboSearchProductCategories
            // 
            this.cboSearchProductCategories.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSearchProductCategories.FormattingEnabled = true;
            this.cboSearchProductCategories.Location = new System.Drawing.Point(24, 104);
            this.cboSearchProductCategories.Name = "cboSearchProductCategories";
            this.cboSearchProductCategories.Size = new System.Drawing.Size(186, 23);
            this.cboSearchProductCategories.TabIndex = 7;
            this.cboSearchProductCategories.SelectedIndexChanged += new System.EventHandler(this.cboSearchProductCategories_SelectedIndexChanged);
            // 
            // txtSearchProductName
            // 
            this.txtSearchProductName.Location = new System.Drawing.Point(24, 50);
            this.txtSearchProductName.Name = "txtSearchProductName";
            this.txtSearchProductName.Size = new System.Drawing.Size(186, 23);
            this.txtSearchProductName.TabIndex = 6;
            this.txtSearchProductName.TextChanged += new System.EventHandler(this.txtSearchProductName_TextChanged);
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
            this.lstProductSearchResults.SelectedIndexChanged += new System.EventHandler(this.lstProductSearchResults_SelectedIndexChanged);
            // 
            // grpTransaction
            // 
            this.grpTransaction.Location = new System.Drawing.Point(257, 11);
            this.grpTransaction.Name = "grpTransaction";
            this.grpTransaction.Size = new System.Drawing.Size(474, 438);
            this.grpTransaction.TabIndex = 2;
            this.grpTransaction.TabStop = false;
            this.grpTransaction.Text = "Transaction";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(483, 463);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Transaction Subtotal:";
            // 
            // lblTransactionSubtotal
            // 
            this.lblTransactionSubtotal.Location = new System.Drawing.Point(606, 463);
            this.lblTransactionSubtotal.Name = "lblTransactionSubtotal";
            this.lblTransactionSubtotal.Size = new System.Drawing.Size(125, 18);
            this.lblTransactionSubtotal.TabIndex = 4;
            this.lblTransactionSubtotal.Text = "0";
            this.lblTransactionSubtotal.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(483, 497);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "Transaction Tax:";
            // 
            // lblTransactionTax
            // 
            this.lblTransactionTax.Location = new System.Drawing.Point(606, 497);
            this.lblTransactionTax.Name = "lblTransactionTax";
            this.lblTransactionTax.Size = new System.Drawing.Size(125, 18);
            this.lblTransactionTax.TabIndex = 6;
            this.lblTransactionTax.Text = "0";
            this.lblTransactionTax.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblTransactionTotal
            // 
            this.lblTransactionTotal.Location = new System.Drawing.Point(606, 529);
            this.lblTransactionTotal.Name = "lblTransactionTotal";
            this.lblTransactionTotal.Size = new System.Drawing.Size(125, 18);
            this.lblTransactionTotal.TabIndex = 8;
            this.lblTransactionTotal.Text = "0";
            this.lblTransactionTotal.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(483, 529);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 15);
            this.label6.TabIndex = 7;
            this.label6.Text = "Transaction Total:";
            // 
            // cmdPay
            // 
            this.cmdPay.Location = new System.Drawing.Point(267, 497);
            this.cmdPay.Name = "cmdPay";
            this.cmdPay.Size = new System.Drawing.Size(115, 47);
            this.cmdPay.TabIndex = 9;
            this.cmdPay.Text = "Pay";
            this.cmdPay.UseVisualStyleBackColor = true;
            this.cmdPay.Click += new System.EventHandler(this.cmdPay_Click);
            // 
            // cmdCancelTransaction
            // 
            this.cmdCancelTransaction.Location = new System.Drawing.Point(14, 497);
            this.cmdCancelTransaction.Name = "cmdCancelTransaction";
            this.cmdCancelTransaction.Size = new System.Drawing.Size(127, 47);
            this.cmdCancelTransaction.TabIndex = 10;
            this.cmdCancelTransaction.Text = "Cancel Transaction";
            this.cmdCancelTransaction.UseVisualStyleBackColor = true;
            this.cmdCancelTransaction.Click += new System.EventHandler(this.cmdCancelTransaction_Click);
            // 
            // PurchaseTransactionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmdCancelTransaction);
            this.Controls.Add(this.cmdPay);
            this.Controls.Add(this.lblTransactionTotal);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblTransactionTax);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblTransactionSubtotal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.grpTransaction);
            this.Controls.Add(this.groupBox1);
            this.Name = "PurchaseTransactionControl";
            this.Size = new System.Drawing.Size(787, 551);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button cmdAddFoundProductsToTransaction;
        private System.Windows.Forms.ComboBox cboSearchProductCategories;
        private System.Windows.Forms.TextBox txtSearchProductName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstProductSearchResults;
        private System.Windows.Forms.GroupBox grpTransaction;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTransactionSubtotal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTransactionTax;
        private System.Windows.Forms.Label lblTransactionTotal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button cmdPay;
        private System.Windows.Forms.Button cmdCancelTransaction;
    }
}
