
namespace MatrixChallengePos.Views
{
    partial class MatrixChallengePosMainView
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.cmdLogout = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.lblLoggedOnEmployeeLabel = new System.Windows.Forms.ToolStripLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmdStartPurchase = new System.Windows.Forms.Button();
            this.pnlUserControl = new System.Windows.Forms.Panel();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdLogout,
            this.toolStripLabel1,
            this.lblLoggedOnEmployeeLabel});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(926, 28);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // cmdLogout
            // 
            this.cmdLogout.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.cmdLogout.BackColor = System.Drawing.SystemColors.ControlDark;
            this.cmdLogout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.cmdLogout.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.cmdLogout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdLogout.Name = "cmdLogout";
            this.cmdLogout.Size = new System.Drawing.Size(70, 25);
            this.cmdLogout.Text = "Log Out";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(54, 25);
            this.toolStripLabel1.Text = "NONE";
            // 
            // lblLoggedOnEmployeeLabel
            // 
            this.lblLoggedOnEmployeeLabel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblLoggedOnEmployeeLabel.Name = "lblLoggedOnEmployeeLabel";
            this.lblLoggedOnEmployeeLabel.Size = new System.Drawing.Size(154, 25);
            this.lblLoggedOnEmployeeLabel.Text = "Logged in Employee:";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.Controls.Add(this.cmdStartPurchase);
            this.panel1.Location = new System.Drawing.Point(12, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 626);
            this.panel1.TabIndex = 1;
            // 
            // cmdStartPurchase
            // 
            this.cmdStartPurchase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdStartPurchase.Location = new System.Drawing.Point(12, 11);
            this.cmdStartPurchase.Name = "cmdStartPurchase";
            this.cmdStartPurchase.Size = new System.Drawing.Size(179, 47);
            this.cmdStartPurchase.TabIndex = 0;
            this.cmdStartPurchase.Text = "Start Purchase Transaction";
            this.cmdStartPurchase.UseVisualStyleBackColor = true;
            this.cmdStartPurchase.Click += new System.EventHandler(this.cmdStartPurchase_Click);
            // 
            // pnlUserControl
            // 
            this.pnlUserControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlUserControl.Location = new System.Drawing.Point(228, 28);
            this.pnlUserControl.Name = "pnlUserControl";
            this.pnlUserControl.Size = new System.Drawing.Size(686, 626);
            this.pnlUserControl.TabIndex = 2;
            // 
            // MatrixChallengePosMainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 666);
            this.Controls.Add(this.pnlUserControl);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MatrixChallengePosMainView";
            this.Text = "MatrixChallengePosMainView";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel lblLoggedOnEmployeeLabel;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton cmdLogout;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button cmdStartPurchase;
        private System.Windows.Forms.Panel pnlUserControl;
    }
}