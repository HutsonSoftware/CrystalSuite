namespace CrystalSuite
{
    partial class ReportSchedulerSimple
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tvwReports = new System.Windows.Forms.TreeView();
            this.enableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.ReportContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.runReportNowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteReportToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.lnkScheduleNewReport = new System.Windows.Forms.LinkLabel();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.ReportContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.tvwReports);
            this.splitContainer1.Panel1MinSize = 200;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.lnkScheduleNewReport);
            this.splitContainer1.Size = new System.Drawing.Size(967, 566);
            this.splitContainer1.SplitterDistance = 271;
            this.splitContainer1.TabIndex = 0;
            // 
            // tvwReports
            // 
            this.tvwReports.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvwReports.Location = new System.Drawing.Point(0, 0);
            this.tvwReports.Name = "tvwReports";
            this.tvwReports.Size = new System.Drawing.Size(271, 566);
            this.tvwReports.TabIndex = 0;
            this.tvwReports.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tvwReports_MouseUp);
            // 
            // enableToolStripMenuItem
            // 
            this.enableToolStripMenuItem.Name = "enableToolStripMenuItem";
            this.enableToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.enableToolStripMenuItem.Text = "Enable";
            this.enableToolStripMenuItem.Click += new System.EventHandler(this.enableToolStripMenuItem_Click);
            // 
            // disableToolStripMenuItem
            // 
            this.disableToolStripMenuItem.Name = "disableToolStripMenuItem";
            this.disableToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.disableToolStripMenuItem.Text = "Disable";
            this.disableToolStripMenuItem.Click += new System.EventHandler(this.disableToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(200, 6);
            // 
            // ReportContextMenuStrip
            // 
            this.ReportContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runReportNowToolStripMenuItem,
            this.toolStripSeparator1,
            this.enableToolStripMenuItem,
            this.disableToolStripMenuItem,
            this.toolStripSeparator5,
            this.deleteReportToolStripMenuItem1});
            this.ReportContextMenuStrip.Name = "contextMenuStrip2";
            this.ReportContextMenuStrip.Size = new System.Drawing.Size(204, 104);
            // 
            // runReportNowToolStripMenuItem
            // 
            this.runReportNowToolStripMenuItem.Name = "runReportNowToolStripMenuItem";
            this.runReportNowToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.runReportNowToolStripMenuItem.Text = "Run Report Now";
            this.runReportNowToolStripMenuItem.Click += new System.EventHandler(this.runReportNowToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(200, 6);
            // 
            // deleteReportToolStripMenuItem1
            // 
            this.deleteReportToolStripMenuItem1.Name = "deleteReportToolStripMenuItem1";
            this.deleteReportToolStripMenuItem1.Size = new System.Drawing.Size(203, 22);
            this.deleteReportToolStripMenuItem1.Text = "Delete Scheduled Report";
            this.deleteReportToolStripMenuItem1.Click += new System.EventHandler(this.deleteReportToolStripMenuItem1_Click);
            // 
            // lnkScheduleNewReport
            // 
            this.lnkScheduleNewReport.AutoSize = true;
            this.lnkScheduleNewReport.Location = new System.Drawing.Point(35, 41);
            this.lnkScheduleNewReport.Name = "lnkScheduleNewReport";
            this.lnkScheduleNewReport.Size = new System.Drawing.Size(112, 13);
            this.lnkScheduleNewReport.TabIndex = 0;
            this.lnkScheduleNewReport.TabStop = true;
            this.lnkScheduleNewReport.Text = "Schedule New Report";
            this.lnkScheduleNewReport.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkScheduleNewReport_LinkClicked);
            // 
            // ReportSchedulerSimple
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 566);
            this.Controls.Add(this.splitContainer1);
            this.Name = "ReportSchedulerSimple";
            this.Text = "ReportScheduler";
            this.Load += new System.EventHandler(this.ReportScheduler_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.ReportContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView tvwReports;
        private System.Windows.Forms.ToolStripMenuItem enableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disableToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ContextMenuStrip ReportContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem runReportNowToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem deleteReportToolStripMenuItem1;
        private System.Windows.Forms.LinkLabel lnkScheduleNewReport;
    }
}