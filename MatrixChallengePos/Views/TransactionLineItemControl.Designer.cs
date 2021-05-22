
namespace MatrixChallengePos.Views
{
    partial class TransactionLineItemControl
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
            this.lblTransactionDetails = new System.Windows.Forms.Label();
            this.cmdDeleteTransaction = new System.Windows.Forms.Button();
            this.cmdRemoveOne = new System.Windows.Forms.Button();
            this.cmdAddOne = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTransactionDetails
            // 
            this.lblTransactionDetails.Location = new System.Drawing.Point(52, 7);
            this.lblTransactionDetails.Name = "lblTransactionDetails";
            this.lblTransactionDetails.Size = new System.Drawing.Size(244, 17);
            this.lblTransactionDetails.TabIndex = 0;
            this.lblTransactionDetails.Text = "label1";
            // 
            // cmdDeleteTransaction
            // 
            this.cmdDeleteTransaction.Location = new System.Drawing.Point(6, 3);
            this.cmdDeleteTransaction.Name = "cmdDeleteTransaction";
            this.cmdDeleteTransaction.Size = new System.Drawing.Size(40, 23);
            this.cmdDeleteTransaction.TabIndex = 1;
            this.cmdDeleteTransaction.Text = "Del";
            this.cmdDeleteTransaction.UseVisualStyleBackColor = true;
            // 
            // cmdRemoveOne
            // 
            this.cmdRemoveOne.Location = new System.Drawing.Point(302, 3);
            this.cmdRemoveOne.Name = "cmdRemoveOne";
            this.cmdRemoveOne.Size = new System.Drawing.Size(29, 23);
            this.cmdRemoveOne.TabIndex = 2;
            this.cmdRemoveOne.Text = "-";
            this.cmdRemoveOne.UseVisualStyleBackColor = true;
            // 
            // cmdAddOne
            // 
            this.cmdAddOne.Location = new System.Drawing.Point(337, 3);
            this.cmdAddOne.Name = "cmdAddOne";
            this.cmdAddOne.Size = new System.Drawing.Size(29, 23);
            this.cmdAddOne.TabIndex = 3;
            this.cmdAddOne.Text = "+";
            this.cmdAddOne.UseVisualStyleBackColor = true;
            // 
            // TransactionLineItemControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmdAddOne);
            this.Controls.Add(this.cmdRemoveOne);
            this.Controls.Add(this.cmdDeleteTransaction);
            this.Controls.Add(this.lblTransactionDetails);
            this.Name = "TransactionLineItemControl";
            this.Size = new System.Drawing.Size(374, 30);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTransactionDetails;
        private System.Windows.Forms.Button cmdDeleteTransaction;
        private System.Windows.Forms.Button cmdRemoveOne;
        private System.Windows.Forms.Button cmdAddOne;
    }
}
