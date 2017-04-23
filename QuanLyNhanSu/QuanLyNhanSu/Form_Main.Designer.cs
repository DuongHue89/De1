namespace QuanLyNhanSu
{
    partial class Form_Main
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Chức năng");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Hướng dẫn");
            this.tre = new System.Windows.Forms.TreeView();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // tre
            // 
            this.tre.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.tre.Dock = System.Windows.Forms.DockStyle.Left;
            this.tre.Location = new System.Drawing.Point(0, 0);
            this.tre.Name = "tre";
            treeNode1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            treeNode1.Name = "chucnang";
            treeNode1.Text = "Chức năng";
            treeNode2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            treeNode2.Name = "huongdan";
            treeNode2.Text = "Hướng dẫn";
            this.tre.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            this.tre.Size = new System.Drawing.Size(121, 497);
            this.tre.TabIndex = 0;
            this.tre.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tre_AfterSelect);
            // 
            // pnlMain
            // 
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(121, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(615, 497);
            this.pnlMain.TabIndex = 1;
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 497);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.tre);
            this.Name = "Form_Main";
            this.Text = "Quản Lý Nhân Sự";
            //this.Load += new System.EventHandler(this.Form1_Load_1);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tre;
        private System.Windows.Forms.Panel pnlMain;
    }
}

