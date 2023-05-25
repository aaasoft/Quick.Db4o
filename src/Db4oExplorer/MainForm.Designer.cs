using Db4oExplorer.Controls;
namespace Db4oExplorer
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            tsMain = new System.Windows.Forms.ToolStrip();
            ddbFile = new System.Windows.Forms.ToolStripDropDownButton();
            打开数据库OToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            关闭数据库CToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            退出XToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ddbDatabase = new System.Windows.Forms.ToolStripDropDownButton();
            备份数据库BToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            碎片整理DToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ddbHelp = new System.Windows.Forms.ToolStripDropDownButton();
            关于Db4oExplorerAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            scMain = new System.Windows.Forms.SplitContainer();
            gbObject = new System.Windows.Forms.GroupBox();
            tvObjectBrowser = new System.Windows.Forms.TreeView();
            cmsForTvObjectViewer = new System.Windows.Forms.ContextMenuStrip(components);
            查看数据VToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            重命名MToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            删除DToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            全部刷新RToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ilObjectBrowser = new System.Windows.Forms.ImageList(components);
            gbQuery = new System.Windows.Forms.GroupBox();
            dgvShowData = new QueryDataGridView();
            tsMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)scMain).BeginInit();
            scMain.Panel1.SuspendLayout();
            scMain.Panel2.SuspendLayout();
            scMain.SuspendLayout();
            gbObject.SuspendLayout();
            cmsForTvObjectViewer.SuspendLayout();
            gbQuery.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvShowData).BeginInit();
            SuspendLayout();
            // 
            // tsMain
            // 
            tsMain.ImageScalingSize = new System.Drawing.Size(32, 32);
            tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { ddbFile, ddbDatabase, ddbHelp });
            tsMain.Location = new System.Drawing.Point(0, 0);
            tsMain.Name = "tsMain";
            tsMain.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            tsMain.Size = new System.Drawing.Size(1724, 41);
            tsMain.TabIndex = 0;
            tsMain.Text = "toolStrip1";
            // 
            // ddbFile
            // 
            ddbFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            ddbFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { 打开数据库OToolStripMenuItem, 关闭数据库CToolStripMenuItem, toolStripMenuItem1, 退出XToolStripMenuItem });
            ddbFile.Image = (System.Drawing.Image)resources.GetObject("ddbFile.Image");
            ddbFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            ddbFile.Name = "ddbFile";
            ddbFile.Size = new System.Drawing.Size(113, 35);
            ddbFile.Text = "文件(&F)";
            // 
            // 打开数据库OToolStripMenuItem
            // 
            打开数据库OToolStripMenuItem.Name = "打开数据库OToolStripMenuItem";
            打开数据库OToolStripMenuItem.Size = new System.Drawing.Size(321, 44);
            打开数据库OToolStripMenuItem.Text = "打开数据库(&O)...";
            打开数据库OToolStripMenuItem.Click += 打开数据库OToolStripMenuItem_Click;
            // 
            // 关闭数据库CToolStripMenuItem
            // 
            关闭数据库CToolStripMenuItem.Enabled = false;
            关闭数据库CToolStripMenuItem.Name = "关闭数据库CToolStripMenuItem";
            关闭数据库CToolStripMenuItem.Size = new System.Drawing.Size(321, 44);
            关闭数据库CToolStripMenuItem.Text = "关闭数据库(&C)";
            关闭数据库CToolStripMenuItem.Click += 关闭数据库CToolStripMenuItem_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new System.Drawing.Size(318, 6);
            // 
            // 退出XToolStripMenuItem
            // 
            退出XToolStripMenuItem.Name = "退出XToolStripMenuItem";
            退出XToolStripMenuItem.Size = new System.Drawing.Size(321, 44);
            退出XToolStripMenuItem.Text = "退出(&X)";
            退出XToolStripMenuItem.Click += 退出XToolStripMenuItem_Click;
            // 
            // ddbDatabase
            // 
            ddbDatabase.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            ddbDatabase.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { 备份数据库BToolStripMenuItem, 碎片整理DToolStripMenuItem });
            ddbDatabase.Enabled = false;
            ddbDatabase.Image = (System.Drawing.Image)resources.GetObject("ddbDatabase.Image");
            ddbDatabase.ImageTransparentColor = System.Drawing.Color.Magenta;
            ddbDatabase.Name = "ddbDatabase";
            ddbDatabase.Size = new System.Drawing.Size(142, 35);
            ddbDatabase.Text = "数据库(&D)";
            // 
            // 备份数据库BToolStripMenuItem
            // 
            备份数据库BToolStripMenuItem.Name = "备份数据库BToolStripMenuItem";
            备份数据库BToolStripMenuItem.Size = new System.Drawing.Size(298, 44);
            备份数据库BToolStripMenuItem.Text = "备份数据库(&B)";
            备份数据库BToolStripMenuItem.Click += 备份数据库BToolStripMenuItem_Click;
            // 
            // 碎片整理DToolStripMenuItem
            // 
            碎片整理DToolStripMenuItem.Name = "碎片整理DToolStripMenuItem";
            碎片整理DToolStripMenuItem.Size = new System.Drawing.Size(298, 44);
            碎片整理DToolStripMenuItem.Text = "碎片整理(&D)";
            碎片整理DToolStripMenuItem.Click += 碎片整理DToolStripMenuItem_Click;
            // 
            // ddbHelp
            // 
            ddbHelp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            ddbHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { 关于Db4oExplorerAToolStripMenuItem });
            ddbHelp.Image = (System.Drawing.Image)resources.GetObject("ddbHelp.Image");
            ddbHelp.ImageTransparentColor = System.Drawing.Color.Magenta;
            ddbHelp.Name = "ddbHelp";
            ddbHelp.Size = new System.Drawing.Size(119, 35);
            ddbHelp.Text = "帮助(&H)";
            // 
            // 关于Db4oExplorerAToolStripMenuItem
            // 
            关于Db4oExplorerAToolStripMenuItem.Name = "关于Db4oExplorerAToolStripMenuItem";
            关于Db4oExplorerAToolStripMenuItem.Size = new System.Drawing.Size(390, 44);
            关于Db4oExplorerAToolStripMenuItem.Text = "关于 Db4oExplorer(&A)";
            关于Db4oExplorerAToolStripMenuItem.Click += 关于Db4oExplorerAToolStripMenuItem_Click;
            // 
            // scMain
            // 
            scMain.Dock = System.Windows.Forms.DockStyle.Fill;
            scMain.Location = new System.Drawing.Point(0, 41);
            scMain.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            scMain.Name = "scMain";
            // 
            // scMain.Panel1
            // 
            scMain.Panel1.Controls.Add(gbObject);
            // 
            // scMain.Panel2
            // 
            scMain.Panel2.Controls.Add(gbQuery);
            scMain.Size = new System.Drawing.Size(1724, 972);
            scMain.SplitterDistance = 573;
            scMain.SplitterWidth = 9;
            scMain.TabIndex = 1;
            // 
            // gbObject
            // 
            gbObject.Controls.Add(tvObjectBrowser);
            gbObject.Dock = System.Windows.Forms.DockStyle.Fill;
            gbObject.Location = new System.Drawing.Point(0, 0);
            gbObject.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            gbObject.Name = "gbObject";
            gbObject.Padding = new System.Windows.Forms.Padding(7, 8, 7, 8);
            gbObject.Size = new System.Drawing.Size(573, 972);
            gbObject.TabIndex = 1;
            gbObject.TabStop = false;
            gbObject.Text = "对象浏览器";
            // 
            // tvObjectBrowser
            // 
            tvObjectBrowser.ContextMenuStrip = cmsForTvObjectViewer;
            tvObjectBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            tvObjectBrowser.HideSelection = false;
            tvObjectBrowser.ImageIndex = 0;
            tvObjectBrowser.ImageList = ilObjectBrowser;
            tvObjectBrowser.Location = new System.Drawing.Point(7, 39);
            tvObjectBrowser.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            tvObjectBrowser.Name = "tvObjectBrowser";
            tvObjectBrowser.SelectedImageIndex = 0;
            tvObjectBrowser.Size = new System.Drawing.Size(559, 925);
            tvObjectBrowser.TabIndex = 0;
            // 
            // cmsForTvObjectViewer
            // 
            cmsForTvObjectViewer.ImageScalingSize = new System.Drawing.Size(32, 32);
            cmsForTvObjectViewer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { 查看数据VToolStripMenuItem, toolStripMenuItem3, 重命名MToolStripMenuItem, 删除DToolStripMenuItem, toolStripMenuItem2, 全部刷新RToolStripMenuItem });
            cmsForTvObjectViewer.Name = "cmsForTvObjectViewer";
            cmsForTvObjectViewer.Size = new System.Drawing.Size(217, 168);
            cmsForTvObjectViewer.Opening += cmsForTvObjectViewer_Opening;
            // 
            // 查看数据VToolStripMenuItem
            // 
            查看数据VToolStripMenuItem.Name = "查看数据VToolStripMenuItem";
            查看数据VToolStripMenuItem.Size = new System.Drawing.Size(216, 38);
            查看数据VToolStripMenuItem.Text = "查看数据(&V)";
            查看数据VToolStripMenuItem.Click += 查看数据VToolStripMenuItem_Click;
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new System.Drawing.Size(213, 6);
            // 
            // 重命名MToolStripMenuItem
            // 
            重命名MToolStripMenuItem.Name = "重命名MToolStripMenuItem";
            重命名MToolStripMenuItem.Size = new System.Drawing.Size(216, 38);
            重命名MToolStripMenuItem.Text = "重命名(&M)";
            重命名MToolStripMenuItem.Click += 重命名MToolStripMenuItem_Click;
            // 
            // 删除DToolStripMenuItem
            // 
            删除DToolStripMenuItem.Name = "删除DToolStripMenuItem";
            删除DToolStripMenuItem.Size = new System.Drawing.Size(216, 38);
            删除DToolStripMenuItem.Text = "删除(&D)";
            删除DToolStripMenuItem.Click += 删除DToolStripMenuItem_Click;
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new System.Drawing.Size(213, 6);
            // 
            // 全部刷新RToolStripMenuItem
            // 
            全部刷新RToolStripMenuItem.Name = "全部刷新RToolStripMenuItem";
            全部刷新RToolStripMenuItem.Size = new System.Drawing.Size(216, 38);
            全部刷新RToolStripMenuItem.Text = "全部刷新(&F)";
            全部刷新RToolStripMenuItem.Click += 全部刷新RToolStripMenuItem_Click;
            // 
            // ilObjectBrowser
            // 
            ilObjectBrowser.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            ilObjectBrowser.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("ilObjectBrowser.ImageStream");
            ilObjectBrowser.TransparentColor = System.Drawing.Color.Fuchsia;
            ilObjectBrowser.Images.SetKeyName(0, "VSObject_Field");
            ilObjectBrowser.Images.SetKeyName(1, "VSObject_Object");
            // 
            // gbQuery
            // 
            gbQuery.Controls.Add(dgvShowData);
            gbQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            gbQuery.Location = new System.Drawing.Point(0, 0);
            gbQuery.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            gbQuery.Name = "gbQuery";
            gbQuery.Padding = new System.Windows.Forms.Padding(7, 8, 7, 8);
            gbQuery.Size = new System.Drawing.Size(1142, 972);
            gbQuery.TabIndex = 1;
            gbQuery.TabStop = false;
            gbQuery.Text = "查询";
            // 
            // dgvShowData
            // 
            dgvShowData.AllowUserToAddRows = false;
            dgvShowData.AllowUserToDeleteRows = false;
            dgvShowData.AllowUserToResizeRows = false;
            dgvShowData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvShowData.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvShowData.EnableHeadersVisualStyles = false;
            dgvShowData.Location = new System.Drawing.Point(7, 39);
            dgvShowData.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            dgvShowData.MultiSelect = false;
            dgvShowData.Name = "dgvShowData";
            dgvShowData.ReadOnly = true;
            dgvShowData.RowHeadersVisible = false;
            dgvShowData.RowHeadersWidth = 82;
            dgvShowData.RowTemplate.Height = 23;
            dgvShowData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvShowData.Size = new System.Drawing.Size(1128, 925);
            dgvShowData.TabIndex = 0;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(14F, 31F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1724, 1013);
            Controls.Add(scMain);
            Controls.Add(tsMain);
            Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            Name = "MainForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Db4oExplorer";
            FormClosing += MainForm_FormClosing;
            Load += MainForm_Load;
            tsMain.ResumeLayout(false);
            tsMain.PerformLayout();
            scMain.Panel1.ResumeLayout(false);
            scMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)scMain).EndInit();
            scMain.ResumeLayout(false);
            gbObject.ResumeLayout(false);
            cmsForTvObjectViewer.ResumeLayout(false);
            gbQuery.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvShowData).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripDropDownButton ddbFile;
        private System.Windows.Forms.ToolStripMenuItem 打开数据库OToolStripMenuItem;
        private System.Windows.Forms.SplitContainer scMain;
        private System.Windows.Forms.GroupBox gbObject;
        private System.Windows.Forms.TreeView tvObjectBrowser;
        private System.Windows.Forms.ImageList ilObjectBrowser;
        private System.Windows.Forms.ContextMenuStrip cmsForTvObjectViewer;
        private System.Windows.Forms.ToolStripMenuItem 全部刷新RToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 退出XToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 重命名MToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查看数据VToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem 删除DToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton ddbDatabase;
        private System.Windows.Forms.ToolStripMenuItem 备份数据库BToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 碎片整理DToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton ddbHelp;
        private System.Windows.Forms.ToolStripMenuItem 关于Db4oExplorerAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关闭数据库CToolStripMenuItem;
        private QueryDataGridView dgvShowData;
        private System.Windows.Forms.GroupBox gbQuery;
    }
}

