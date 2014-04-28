namespace CrystalSuite
{
    partial class StartUpPanel
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvRecentChanges = new System.Windows.Forms.DataGridView();
            this.grpCommonTasks = new System.Windows.Forms.GroupBox();
            this.lnkEditExistingJob = new System.Windows.Forms.LinkLabel();
            this.lnkViewRunningJobs = new System.Windows.Forms.LinkLabel();
            this.lnkAddNewJob = new System.Windows.Forms.LinkLabel();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentChanges)).BeginInit();
            this.grpCommonTasks.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.grpCommonTasks);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(450, 324);
            this.panel1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dgvRecentChanges);
            this.groupBox1.Location = new System.Drawing.Point(17, 131);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(421, 168);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Recent Changes";
            // 
            // dgvRecentChanges
            // 
            this.dgvRecentChanges.AllowUserToAddRows = false;
            this.dgvRecentChanges.AllowUserToDeleteRows = false;
            this.dgvRecentChanges.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRecentChanges.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecentChanges.Location = new System.Drawing.Point(11, 17);
            this.dgvRecentChanges.Name = "dgvRecentChanges";
            this.dgvRecentChanges.ReadOnly = true;
            this.dgvRecentChanges.Size = new System.Drawing.Size(399, 138);
            this.dgvRecentChanges.TabIndex = 0;
            // 
            // grpCommonTasks
            // 
            this.grpCommonTasks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpCommonTasks.Controls.Add(this.lnkEditExistingJob);
            this.grpCommonTasks.Controls.Add(this.lnkViewRunningJobs);
            this.grpCommonTasks.Controls.Add(this.lnkAddNewJob);
            this.grpCommonTasks.Location = new System.Drawing.Point(17, 12);
            this.grpCommonTasks.Name = "grpCommonTasks";
            this.grpCommonTasks.Size = new System.Drawing.Size(421, 113);
            this.grpCommonTasks.TabIndex = 0;
            this.grpCommonTasks.TabStop = false;
            this.grpCommonTasks.Text = "Common Tasks";
            // 
            // lnkEditExistingJob
            // 
            this.lnkEditExistingJob.AutoSize = true;
            this.lnkEditExistingJob.Location = new System.Drawing.Point(23, 48);
            this.lnkEditExistingJob.Name = "lnkEditExistingJob";
            this.lnkEditExistingJob.Size = new System.Drawing.Size(84, 13);
            this.lnkEditExistingJob.TabIndex = 2;
            this.lnkEditExistingJob.TabStop = true;
            this.lnkEditExistingJob.Text = "Edit Existing Job";
            this.lnkEditExistingJob.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkEditExistingJob_LinkClicked);
            // 
            // lnkViewRunningJobs
            // 
            this.lnkViewRunningJobs.AutoSize = true;
            this.lnkViewRunningJobs.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.lnkViewRunningJobs.Location = new System.Drawing.Point(23, 70);
            this.lnkViewRunningJobs.Name = "lnkViewRunningJobs";
            this.lnkViewRunningJobs.Size = new System.Drawing.Size(98, 13);
            this.lnkViewRunningJobs.TabIndex = 1;
            this.lnkViewRunningJobs.TabStop = true;
            this.lnkViewRunningJobs.Text = "View Running Jobs";
            this.lnkViewRunningJobs.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkViewRunningJobs_LinkClicked);
            // 
            // lnkAddNewJob
            // 
            this.lnkAddNewJob.AutoSize = true;
            this.lnkAddNewJob.Location = new System.Drawing.Point(23, 25);
            this.lnkAddNewJob.Name = "lnkAddNewJob";
            this.lnkAddNewJob.Size = new System.Drawing.Size(71, 13);
            this.lnkAddNewJob.TabIndex = 0;
            this.lnkAddNewJob.TabStop = true;
            this.lnkAddNewJob.Text = "Add New Job";
            this.lnkAddNewJob.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAddNewJob_LinkClicked);
            // 
            // StartUpPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "StartUpPanel";
            this.Size = new System.Drawing.Size(450, 324);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentChanges)).EndInit();
            this.grpCommonTasks.ResumeLayout(false);
            this.grpCommonTasks.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvRecentChanges;
        private System.Windows.Forms.GroupBox grpCommonTasks;
        private System.Windows.Forms.LinkLabel lnkEditExistingJob;
        private System.Windows.Forms.LinkLabel lnkViewRunningJobs;
        private System.Windows.Forms.LinkLabel lnkAddNewJob;
    }
}
