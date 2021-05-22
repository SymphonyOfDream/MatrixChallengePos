
namespace MatrixChallengePos.Views
{
    partial class PayTransactionView
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.lblTax = new System.Windows.Forms.Label();
            this.lblGrandTotal = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAmountTendered = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblChangeDueCustomer = new System.Windows.Forms.Label();
            this.cmdCompleteTransaction = new System.Windows.Forms.Button();
            this.cmdCancelTransactionPayment = new System.Windows.Forms.Button();
            this.lblAmountDueCustomerBreakdown = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Subtotal:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tax:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Grand Total:";
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.Location = new System.Drawing.Point(115, 25);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(76, 23);
            this.lblSubtotal.TabIndex = 3;
            this.lblSubtotal.Text = "0";
            this.lblSubtotal.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblTax
            // 
            this.lblTax.Location = new System.Drawing.Point(115, 62);
            this.lblTax.Name = "lblTax";
            this.lblTax.Size = new System.Drawing.Size(76, 23);
            this.lblTax.TabIndex = 4;
            this.lblTax.Text = "0";
            this.lblTax.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblGrandTotal
            // 
            this.lblGrandTotal.Location = new System.Drawing.Point(115, 104);
            this.lblGrandTotal.Name = "lblGrandTotal";
            this.lblGrandTotal.Size = new System.Drawing.Size(76, 23);
            this.lblGrandTotal.TabIndex = 5;
            this.lblGrandTotal.Text = "0";
            this.lblGrandTotal.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 181);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Amount Tendered:";
            // 
            // txtAmountTendered
            // 
            this.txtAmountTendered.Location = new System.Drawing.Point(164, 178);
            this.txtAmountTendered.Name = "txtAmountTendered";
            this.txtAmountTendered.Size = new System.Drawing.Size(100, 23);
            this.txtAmountTendered.TabIndex = 7;
            this.txtAmountTendered.TextChanged += new System.EventHandler(this.txtAmountTendered_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 239);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "Change Due Customer:";
            // 
            // lblChangeDueCustomer
            // 
            this.lblChangeDueCustomer.Location = new System.Drawing.Point(163, 239);
            this.lblChangeDueCustomer.Name = "lblChangeDueCustomer";
            this.lblChangeDueCustomer.Size = new System.Drawing.Size(100, 23);
            this.lblChangeDueCustomer.TabIndex = 9;
            this.lblChangeDueCustomer.Text = "0";
            this.lblChangeDueCustomer.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cmdCompleteTransaction
            // 
            this.cmdCompleteTransaction.Location = new System.Drawing.Point(127, 292);
            this.cmdCompleteTransaction.Name = "cmdCompleteTransaction";
            this.cmdCompleteTransaction.Size = new System.Drawing.Size(158, 33);
            this.cmdCompleteTransaction.TabIndex = 10;
            this.cmdCompleteTransaction.Text = "Complete Transaction";
            this.cmdCompleteTransaction.UseVisualStyleBackColor = true;
            this.cmdCompleteTransaction.Click += new System.EventHandler(this.cmdCompleteTransaction_Click);
            // 
            // cmdCancelTransactionPayment
            // 
            this.cmdCancelTransactionPayment.Location = new System.Drawing.Point(27, 292);
            this.cmdCancelTransactionPayment.Name = "cmdCancelTransactionPayment";
            this.cmdCancelTransactionPayment.Size = new System.Drawing.Size(75, 33);
            this.cmdCancelTransactionPayment.TabIndex = 11;
            this.cmdCancelTransactionPayment.Text = "Cancel";
            this.cmdCancelTransactionPayment.UseVisualStyleBackColor = true;
            this.cmdCancelTransactionPayment.Click += new System.EventHandler(this.cmdCancelTransactionPayment_Click);
            // 
            // lblAmountDueCustomerBreakdown
            // 
            this.lblAmountDueCustomerBreakdown.AutoSize = true;
            this.lblAmountDueCustomerBreakdown.Location = new System.Drawing.Point(27, 258);
            this.lblAmountDueCustomerBreakdown.Name = "lblAmountDueCustomerBreakdown";
            this.lblAmountDueCustomerBreakdown.Size = new System.Drawing.Size(0, 15);
            this.lblAmountDueCustomerBreakdown.TabIndex = 12;
            // 
            // PayTransactionView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 332);
            this.ControlBox = false;
            this.Controls.Add(this.lblAmountDueCustomerBreakdown);
            this.Controls.Add(this.cmdCancelTransactionPayment);
            this.Controls.Add(this.cmdCompleteTransaction);
            this.Controls.Add(this.lblChangeDueCustomer);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtAmountTendered);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblGrandTotal);
            this.Controls.Add(this.lblTax);
            this.Controls.Add(this.lblSubtotal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PayTransactionView";
            this.Text = "Complete Transaction";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.Label lblTax;
        private System.Windows.Forms.Label lblGrandTotal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAmountTendered;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblChangeDueCustomer;
        private System.Windows.Forms.Button cmdCompleteTransaction;
        private System.Windows.Forms.Button cmdCancelTransactionPayment;
        private System.Windows.Forms.Label lblAmountDueCustomerBreakdown;
    }
}