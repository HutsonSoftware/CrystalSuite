namespace CrystalSuite
{
    partial class ReportScheduler
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Jobs");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Job Monitor");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Error Logs");
            this.JobsContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newJobToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.manageSchedulesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.viewAllHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.startJobToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.viewHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.JobContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.viewJobToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.stopJobToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteJobToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.JobsContextMenuStrip.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.JobContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // JobsContextMenuStrip
            // 
            this.JobsContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newJobToolStripMenuItem,
            this.toolStripSeparator3,
            this.manageSchedulesToolStripMenuItem,
            this.toolStripSeparator4,
            this.viewAllHistoryToolStripMenuItem});
            this.JobsContextMenuStrip.Name = "contextMenuStrip1";
            this.JobsContextMenuStrip.Size = new System.Drawing.Size(174, 82);
            // 
            // newJobToolStripMenuItem
            // 
            this.newJobToolStripMenuItem.Name = "newJobToolStripMenuItem";
            this.newJobToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.newJobToolStripMenuItem.Text = "New Job";
            this.newJobToolStripMenuItem.Click += new System.EventHandler(this.newJobToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(170, 6);
            // 
            // manageSchedulesToolStripMenuItem
            // 
            this.manageSchedulesToolStripMenuItem.Name = "manageSchedulesToolStripMenuItem";
            this.manageSchedulesToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.manageSchedulesToolStripMenuItem.Text = "Manage Schedules";
            this.manageSchedulesToolStripMenuItem.Click += new System.EventHandler(this.manageSchedulesToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(170, 6);
            // 
            // viewAllHistoryToolStripMenuItem
            // 
            this.viewAllHistoryToolStripMenuItem.Name = "viewAllHistoryToolStripMenuItem";
            this.viewAllHistoryToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.viewAllHistoryToolStripMenuItem.Text = "View History";
            this.viewAllHistoryToolStripMenuItem.Click += new System.EventHandler(this.viewAllHistoryToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            this.splitContainer1.Panel1MinSize = 200;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Size = new System.Drawing.Size(967, 566);
            this.splitContainer1.SplitterDistance = 271;
            this.splitContainer1.TabIndex = 0;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            treeNode4.ContextMenuStrip = this.JobsContextMenuStrip;
            treeNode4.Name = "Jobs";
            treeNode4.Tag = "Jobs";
            treeNode4.Text = "Jobs";
            treeNode5.Name = "JobMonitor";
            treeNode5.Tag = "JobMonitor";
            treeNode5.Text = "Job Monitor";
            treeNode6.Name = "ErrorLogs";
            treeNode6.Tag = "ErrorLogs";
            treeNode6.Text = "Error Logs";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode5,
            treeNode6});
            this.treeView1.Size = new System.Drawing.Size(271, 566);
            this.treeView1.TabIndex = 0;
            this.treeView1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseUp);
            // 
            // startJobToolStripMenuItem
            // 
            this.startJobToolStripMenuItem.Name = "startJobToolStripMenuItem";
            this.startJobToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.startJobToolStripMenuItem.Text = "Start Job";
            this.startJobToolStripMenuItem.Click += new System.EventHandler(this.startJobToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(137, 6);
            // 
            // viewHistoryToolStripMenuItem
            // 
            this.viewHistoryToolStripMenuItem.Name = "viewHistoryToolStripMenuItem";
            this.viewHistoryToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.viewHistoryToolStripMenuItem.Text = "View History";
            this.viewHistoryToolStripMenuItem.Click += new System.EventHandler(this.viewHistoryToolStripMenuItem_Click);
            // 
            // enableToolStripMenuItem
            // 
            this.enableToolStripMenuItem.Name = "enableToolStripMenuItem";
            this.enableToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.enableToolStripMenuItem.Text = "Enable";
            this.enableToolStripMenuItem.Click += new System.EventHandler(this.enableToolStripMenuItem_Click);
            // 
            // disableToolStripMenuItem
            // 
            this.disableToolStripMenuItem.Name = "disableToolStripMenuItem";
            this.disableToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.disableToolStripMenuItem.Text = "Disable";
            this.disableToolStripMenuItem.Click += new System.EventHandler(this.disableToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(137, 6);
            // 
            // JobContextMenuStrip
            // 
            this.JobContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewJobToolStripMenuItem,
            this.toolStripSeparator1,
            this.startJobToolStripMenuItem,
            this.stopJobToolStripMenuItem,
            this.toolStripSeparator2,
            this.viewHistoryToolStripMenuItem,
            this.enableToolStripMenuItem,
            this.disableToolStripMenuItem,
            this.toolStripSeparator5,
            this.deleteJobToolStripMenuItem1});
            this.JobContextMenuStrip.Name = "contextMenuStrip2";
            this.JobContextMenuStrip.Size = new System.Drawing.Size(141, 176);
            // 
            // viewJobToolStripMenuItem
            // 
            this.viewJobToolStripMenuItem.Name = "viewJobToolStripMenuItem";
            this.viewJobToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.viewJobToolStripMenuItem.Text = "View Job";
            this.viewJobToolStripMenuItem.Click += new System.EventHandler(this.viewJobToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(137, 6);
            // 
            // stopJobToolStripMenuItem
            // 
            this.stopJobToolStripMenuItem.Name = "stopJobToolStripMenuItem";
            this.stopJobToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.stopJobToolStripMenuItem.Text = "Stop Job";
            this.stopJobToolStripMenuItem.Click += new System.EventHandler(this.stopJobToolStripMenuItem_Click);
            // 
            // deleteJobToolStripMenuItem1
            // 
            this.deleteJobToolStripMenuItem1.Name = "deleteJobToolStripMenuItem1";
            this.deleteJobToolStripMenuItem1.Size = new System.Drawing.Size(140, 22);
            this.deleteJobToolStripMenuItem1.Text = "Delete Job";
            this.deleteJobToolStripMenuItem1.Click += new System.EventHandler(this.deleteJobToolStripMenuItem1_Click);
            // 
            // ReportScheduler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 566);
            this.Controls.Add(this.splitContainer1);
            this.Name = "ReportScheduler";
            this.Text = "ReportScheduler";
            this.Load += new System.EventHandler(this.ReportScheduler_Load);
            this.JobsContextMenuStrip.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.JobContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ContextMenuStrip JobsContextMenuStrip;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ToolStripMenuItem newJobToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem manageSchedulesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem viewAllHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startJobToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem viewHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disableToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ContextMenuStrip JobContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem viewJobToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem stopJobToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteJobToolStripMenuItem1;
    }
}