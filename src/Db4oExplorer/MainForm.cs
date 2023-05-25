using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using Db4objects.Db4o;
using Db4objects.Db4o.CS;
using Db4objects.Db4o.Ext;
using Db4objects.Db4o.Reflect;
using System.Linq;
using aaaSoft.Helpers;
using System.IO;
using Db4objects.Db4o.Query;
using System.Threading;

namespace Db4oExplorer
{
    public partial class MainForm : Form
    {
        private const string COLUMN_NO_NAME = "No.";
        private const String VSObject_Object_ImageKey = "VSObject_Object";
        private const String VSObject_Field_ImageKey = "VSObject_Field";

        private Dictionary<IStoredClass, Type> dictStoredClass_Type = new Dictionary<IStoredClass, Type>();
        //数据库文件路径
        private String databaseFilePath;
        //对象服务器
        private IObjectServer objectServer = null;
        private Boolean isConnectedToServer
        {
            get
            {
                return objectServer != null;
            }
        }

        public MainForm()
        {
            InitializeComponent();
        }

        #region 窗口事件部分
        private void MainForm_Load(object sender, EventArgs e)
        {
            //databaseFilePath = "test.yap";
            //openDbFile();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            closeDbFile();
        }
        #endregion

        //打开数据库文件
        private void openDbFile()
        {
            //try
            {
                objectServer = Db4oClientServer.OpenServer(databaseFilePath, Db4oClientServer.ArbitraryPort);

                打开数据库OToolStripMenuItem.Enabled = false;
                关闭数据库CToolStripMenuItem.Enabled = true;
                tvObjectBrowser.Enabled = true;
                ddbDatabase.Enabled = true;
            }
            //catch (Exception ex)
            //{
            //    MessageBox.Show(String.Format("打开数据库文件[{0}]时出现异常，原因：{1}", databaseFilePath, ex.Message));
            //    return;
            //}

            refreshAll();
        }

        //关闭数据库文件
        private void closeDbFile()
        {
            打开数据库OToolStripMenuItem.Enabled = true;
            关闭数据库CToolStripMenuItem.Enabled = false;
            tvObjectBrowser.Enabled = false;
            tvObjectBrowser.Nodes.Clear();
            ddbDatabase.Enabled = false;
            dgvShowData.DataSource = null;
            if (objectServer != null)
                objectServer.Close();
        }

        private void defrag(Db4objects.Db4o.Defragment.DefragmentConfig config)
        {
            closeDbFile();
            Exception exception = null;
            ProgressBar pb = new ProgressBar();
            pb.Value = 0;
            pb.Maximum = 100;
            pb.Minimum = 0;

            try
            {
                FileInfo preDbInfo = new FileInfo(config.OrigPath());
                Int64 preFileLength = preDbInfo.Length;
                //整理是否已经结束
                Boolean isDefragFinish = false;
                Thread defragmentThread = new Thread(new ParameterizedThreadStart(delegate (Object obj)
                {
                    Db4objects.Db4o.Defragment.Defragment.Defrag(config);
                    isDefragFinish = true;
                }));
                defragmentThread.Start();

                pb.Width = this.ClientSize.Width;
                pb.Left = (this.ClientSize.Width - pb.Width) / 2;
                pb.Top = this.ClientSize.Height - pb.Height;
                this.Controls.Add(pb);
                foreach (Control ctl in this.Controls)
                {
                    if (ctl != pb)
                        ctl.Enabled = false;
                }
                pb.BringToFront();

                while (!isDefragFinish)
                {
                    if (File.Exists(databaseFilePath))
                    {
                        FileInfo finalDbInfo = new FileInfo(databaseFilePath);
                        Int64 currentFileLength = finalDbInfo.Length;
                        if (currentFileLength < preFileLength)
                        {
                            pb.Value = Convert.ToInt32(currentFileLength * 100 / preFileLength);
                        }
                    }
                    Application.DoEvents();
                    //休息0.5秒
                    Thread.Sleep(500);
                }
            }
            catch (Exception ex)
            {
                exception = ex;
            }
            finally
            {
                this.Controls.Remove(pb);
                foreach (Control ctl in this.Controls)
                {
                    ctl.Enabled = true;
                }
                if (exception != null)
                    throw exception;
            }
            openDbFile();
        }

        //刷新全部
        private void refreshAll()
        {
            tvObjectBrowser.Nodes.Clear();
            dictStoredClass_Type.Clear();

            IObjectContainer objectContainer = objectServer.OpenClient();

            /*
            for (int i = 0; i <= 100000; i++)
            {
                var tmpClass = new
                {
                    Name = "NAME_" + i
                    ,
                    Description = Guid.NewGuid().ToString()
                };
                objectContainer.Store(tmpClass);

                var tmpClass2 = new
                {
                    Name2 = "NAME_" + i
                    ,
                    Description2 = Guid.NewGuid().ToString()
                    ,
                    TmpClassRef = tmpClass
                };
                objectContainer.Store(tmpClass2);
            }
            */

            Boolean bInternStrings = objectContainer.Ext().Configure().InternStrings();
            Boolean bOptimizeNativeQueries = objectContainer.Ext().Configure().OptimizeNativeQueries();

            IStoredClass[] storedClassArray = objectContainer.Ext().StoredClasses();

            foreach (IStoredClass storedClass in storedClassArray)
            {
                //对象名称
                String objectName = storedClass.GetName();
                //字段数组
                IStoredField[] storedFieldArray = storedClass.GetStoredFields();
                //对象类型
                Type objectType = Type.GetType(objectName, false);

                if (objectType != null)
                {
                    dictStoredClass_Type.Add(storedClass, objectType);
                }

                //对象数量
                Int32 objectCount = storedClass.InstanceCount();
                //对象显示名称
                String objectDisplayName = String.Format("{0} (数量:{1})", objectName, objectCount);

                TreeNode objectNode = tvObjectBrowser.Nodes.Add(objectDisplayName, objectDisplayName, VSObject_Object_ImageKey, VSObject_Object_ImageKey);
                objectNode.Tag = storedClass;

                foreach (IStoredField storedField in storedFieldArray)
                {
                    //字段名称
                    String fieldName = storedField.GetName();
                    //字段类型
                    IReflectClass reflectClass = storedField.GetStoredType();
                    //字段类型名称
                    String fieldTypeName;
                    if (reflectClass == null)
                    {
                        fieldTypeName = "null";
                    }
                    else
                    {
                        fieldTypeName = reflectClass.GetName();
                    }
                    //字段显示名称
                    String fieldDisplayName = String.Format("{0} ({1})", fieldName, fieldTypeName);
                    TreeNode fieldNode = objectNode.Nodes.Add(fieldDisplayName, fieldDisplayName, VSObject_Field_ImageKey, VSObject_Field_ImageKey);
                    fieldNode.Tag = storedField;
                }
            }
            objectContainer.Close();
        }

        #region cmsForTvObjectViewer 关联菜单部分
        private void cmsForTvObjectViewer_Opening(object sender, CancelEventArgs e)
        {
            TreeNode selectedTreeNode = tvObjectBrowser.SelectedNode;

            重命名MToolStripMenuItem.Enabled = selectedTreeNode != null;
            删除DToolStripMenuItem.Enabled = selectedTreeNode != null && selectedTreeNode.Tag is IStoredClass;
            查看数据VToolStripMenuItem.Enabled = selectedTreeNode != null && selectedTreeNode.Tag is IStoredClass;
            全部刷新RToolStripMenuItem.Enabled = isConnectedToServer;
        }

        private void 查看数据VToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode selectedTreeNode = tvObjectBrowser.SelectedNode;
            IStoredClass storedClass = (IStoredClass)selectedTreeNode.Tag;
            String storedClassName = storedClass.GetName();

            IObjectContainer objectContainer = objectServer.OpenClient();
            IQuery query = objectContainer.Query();

            dgvShowData.SetObjectContainer(objectContainer);
            dgvShowData.SetQuery(query, storedClassName);

            IConstraint constrain = query.Constrain(objectContainer.Ext().Reflector().ForName(storedClassName));
            IObjectSet objectSet2 = query.Execute();


            long[] idArray = objectSet2.Ext().GetIDs();
            List<Object> list = new List<object>();
            for (int i = 0; i <= idArray.Length - 1; i++)
            {
                Object obj = null;
                while (obj == null)
                {
                    try
                    {
                        obj = objectSet2[i];
                    }
                    catch
                    {
                        objectSet2.Reset();
                    }
                }
                list.Add(obj);
            }

            DataTable dt = new DataTable(storedClassName);
            dt.Columns.Add(COLUMN_NO_NAME);

            IStoredField[] storedFieldArray = storedClass.GetStoredFields();
            foreach (IStoredField storedField in storedFieldArray)
            {
                dt.Columns.Add(storedField.GetName());
            }

            int index = 0;
            foreach (Object obj in list)
            {
                index++;
                List<Object> fieldList = new List<object>();
                fieldList.Add(index);

                for (int i = 0; i <= storedFieldArray.Length - 1; i++)
                {
                    var columnName = storedFieldArray[i].GetName();
                    if (columnName.Equals(COLUMN_NO_NAME))
                        continue;

                    var field = objectContainer.Ext().Reflector().ForObject(obj).GetDeclaredField(columnName);
                    var fieldObject = field.Get(obj);
                    fieldList.Add(fieldObject);
                }
                dt.Rows.Add(fieldList.ToArray());
            }
            dgvShowData.DataSource = dt;
            objectContainer.Close();
        }

        public class Predicate : Db4objects.Db4o.Query.Predicate
        {
            public delegate bool MatchDelegate(object obj);
            private MatchDelegate matchDelegate;

            public Predicate(Type type, MatchDelegate matchDelegate)
                : base(type)
            {
                this.matchDelegate = matchDelegate;
            }

            public override bool AppliesTo(object candidate)
            {
                if (matchDelegate == null)
                    return base.AppliesTo(candidate);
                else
                    return matchDelegate(candidate);
            }
        }

        private TreeNode findTagEqualsTreeNode(TreeNodeCollection tnc, Object tag)
        {
            if (tnc == null || tnc.Count == 0)
                return null;
            foreach (TreeNode node in tnc)
            {
                if (node.Tag.Equals(tag))
                    return node;
                else
                {
                    TreeNode tmpNode = findTagEqualsTreeNode(node.Nodes, tag);
                    if (tmpNode != null)
                        return tmpNode;
                }
            }
            return null;
        }

        private void 重命名MToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = tvObjectBrowser.SelectedNode;
            Object obj = selectedNode.Tag;
            if (obj == null)
                return;

            //刷新后选中的节点
            TreeNode afterSelectedNode = null;

            if (obj is IStoredClass)
            {
                IStoredClass storedClass = (IStoredClass)obj;
                String preTypeName = storedClass.GetName();
                String newTypeName = InputForm.GetInput(String.Format("重命名类型[{0}]名称", preTypeName), "请输入新的类型名称：", preTypeName);
                if (newTypeName == null)
                    return;

                if (String.IsNullOrEmpty(newTypeName))
                {
                    MessageBox.Show("输入的新的类型名称为空，未作任何更改！", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                try
                {
                    storedClass.Rename(newTypeName);
                    closeDbFile();
                    openDbFile();
                    afterSelectedNode = findTagEqualsTreeNode(tvObjectBrowser.Nodes, obj);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("重命名类型名称失败！原因：" + ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else if (obj is IStoredField)
            {
                IStoredField storedField = (IStoredField)obj;
                String preFieldName = storedField.GetName();
                String newFieldName = InputForm.GetInput(String.Format("重命名字段[{0}]名称", preFieldName), "请输入新的字段名称：", preFieldName);
                if (newFieldName == null)
                    return;

                if (String.IsNullOrEmpty(newFieldName))
                {
                    MessageBox.Show("输入的新的字段名称为空，未作任何更改！", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                try
                {
                    storedField.Rename(newFieldName);
                    closeDbFile();
                    openDbFile();
                    afterSelectedNode = findTagEqualsTreeNode(tvObjectBrowser.Nodes, obj);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("重命名字段名称失败！原因：" + ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

            if (afterSelectedNode != null)
            {
                tvObjectBrowser.SelectedNode = afterSelectedNode;
            }
        }

        public class NotAcceptStoredClassFilter : Db4objects.Db4o.Defragment.IStoredClassFilter
        {
            //不接受的类数组
            String[] notAcceptStoredClassNameArray;

            public NotAcceptStoredClassFilter(String notAcceptStoredClassName)
            {
                init(new String[] { notAcceptStoredClassName });
            }

            public NotAcceptStoredClassFilter(String[] notAcceptStoredClassNameArray)
            {
                init(notAcceptStoredClassNameArray);
            }

            private void init(String[] notAcceptStoredClassArray)
            {
                this.notAcceptStoredClassNameArray = notAcceptStoredClassArray;
            }

            public bool Accept(IStoredClass storedClass)
            {
                return !notAcceptStoredClassNameArray.Contains(storedClass.GetName());
            }
        }

        private void 删除DToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = tvObjectBrowser.SelectedNode;
            Object obj = selectedNode.Tag;
            if (obj == null)
                return;

            //刷新后选中的节点
            TreeNode afterSelectedNode = null;

            if (obj is IStoredClass)
            {
                IStoredClass storedClass = (IStoredClass)obj;
                String storedClassName = storedClass.GetName();

                var dr = MessageBox.Show(String.Format("您确定要删除类型[{0}]？", storedClassName), Application.ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == System.Windows.Forms.DialogResult.Cancel)
                    return;

                //进行碎片整理以删除不用的类型
                try
                {
                    String tmpFileName = Path.GetTempFileName();
                    Db4objects.Db4o.Defragment.DefragmentConfig config = new Db4objects.Db4o.Defragment.DefragmentConfig(databaseFilePath, tmpFileName);
                    config.ForceBackupDelete(true);
                    config.StoredClassFilter(new NotAcceptStoredClassFilter(storedClassName));
                    defrag(config);
                    File.Delete(tmpFileName);
                    MessageBox.Show(String.Format("删除类型[{0}]成功！", storedClassName), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(String.Format("删除类型[{0}]时出错，原因：{1}", storedClassName, ex.Message));
                }
            }
            else if (obj is IStoredField)
            {
                IStoredField storedField = (IStoredField)obj;
            }

            if (afterSelectedNode != null)
            {
                tvObjectBrowser.SelectedNode = afterSelectedNode;
            }
        }

        private void 全部刷新RToolStripMenuItem_Click(object sender, EventArgs e)
        {
            refreshAll();
        }
        #endregion


        #region "文件"菜单部分
        private void 打开数据库OToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "请选择db4o数据库文件";
            ofd.Filter = "db4o数据库文件(*.yap;*.db;*.data)|*.yap;*.db;*.data|所有文件(*.*)|*.*";
            var dr = ofd.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.Cancel)
                return;

            databaseFilePath = ofd.FileName;
            openDbFile();
        }

        private void 关闭数据库CToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closeDbFile();
        }

        private void 退出XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion


        #region "数据库"菜单部分

        private void 备份数据库BToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Title = "请选择数据库备份文件";
                sfd.Filter = "db4o数据库文件(*.yap)|*.yap|db4o数据库文件(*.db)|*.db|db4o数据库文件(*.data)|*.data";
                sfd.FileName = String.Format("{0}_{1}", System.IO.Path.GetFileNameWithoutExtension(databaseFilePath), DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
                var dr = sfd.ShowDialog();
                if (dr == System.Windows.Forms.DialogResult.Cancel)
                    return;

                objectServer.Ext().Backup(sfd.FileName);
                MessageBox.Show(String.Format("对数据库进行备份成功完成！"), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("对数据库进行备份时出错，原因：{0}", ex.Message), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void 碎片整理DToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //进行碎片整理
            try
            {
                String tmpFileName = Path.GetTempFileName();
                Db4objects.Db4o.Defragment.DefragmentConfig config = new Db4objects.Db4o.Defragment.DefragmentConfig(databaseFilePath, tmpFileName);
                config.ForceBackupDelete(true);
                defrag(config);
                File.Delete(tmpFileName);
                MessageBox.Show(String.Format("对数据库进行碎片整理成功完成！"), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("对数据库进行碎片整理时出错，原因：{0}", ex.Message), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        #endregion

        #region "帮助"菜单部分

        private void 关于Db4oExplorerAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutForm().ShowDialog();
        }
        #endregion
    }
}
