
namespace Test_2Views
{
    partial class EntryView
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
            this.BtnNextPage = new DevExpress.XtraEditors.SimpleButton();
            this.BtnFrontPage = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // BtnNextPage
            // 
            this.BtnNextPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnNextPage.Location = new System.Drawing.Point(210, 179);
            this.BtnNextPage.Name = "BtnNextPage";
            this.BtnNextPage.Size = new System.Drawing.Size(125, 35);
            this.BtnNextPage.TabIndex = 0;
            this.BtnNextPage.Text = "Next Page";
            this.BtnNextPage.Click += new System.EventHandler(this.BtnNextPage_Click);
            // 
            // BtnFrontPage
            // 
            this.BtnFrontPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnFrontPage.Location = new System.Drawing.Point(210, 138);
            this.BtnFrontPage.Name = "BtnFrontPage";
            this.BtnFrontPage.Size = new System.Drawing.Size(125, 35);
            this.BtnFrontPage.TabIndex = 1;
            this.BtnFrontPage.Text = "Front Page";
            this.BtnFrontPage.Click += new System.EventHandler(this.BtnFrontPage_Click);
            // 
            // EntryView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 226);
            this.Controls.Add(this.BtnFrontPage);
            this.Controls.Add(this.BtnNextPage);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "EntryView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Entry";
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton BtnFrontPage;
        private DevExpress.XtraEditors.SimpleButton BtnNextPage;
    }
}

