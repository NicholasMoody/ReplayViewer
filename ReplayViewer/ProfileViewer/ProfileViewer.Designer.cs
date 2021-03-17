namespace ReplayViewer
{
    partial class ProfileViewer
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
            this.lbScores = new System.Windows.Forms.ListBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.txtTesting = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbScores
            // 
            this.lbScores.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbScores.FormattingEnabled = true;
            this.lbScores.Location = new System.Drawing.Point(12, 57);
            this.lbScores.Name = "lbScores";
            this.lbScores.Size = new System.Drawing.Size(259, 381);
            this.lbScores.TabIndex = 0;
            this.lbScores.SelectedIndexChanged += new System.EventHandler(this.lbScores_SelectedIndexChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtSearch.Location = new System.Drawing.Point(289, 57);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(170, 20);
            this.txtSearch.TabIndex = 1;
            // 
            // txtTesting
            // 
            this.txtTesting.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTesting.Location = new System.Drawing.Point(289, 83);
            this.txtTesting.Multiline = true;
            this.txtTesting.Name = "txtTesting";
            this.txtTesting.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtTesting.Size = new System.Drawing.Size(257, 355);
            this.txtTesting.TabIndex = 2;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(465, 57);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(81, 20);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.Search);
            // 
            // ProfileViewer
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 450);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtTesting);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lbScores);
            this.Name = "ProfileViewer";
            this.Text = "ProfileViewer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbScores;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.TextBox txtTesting;
        private System.Windows.Forms.Button btnSearch;
    }
}