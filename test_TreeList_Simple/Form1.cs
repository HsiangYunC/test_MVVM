using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using System.IO;
using System.Windows.Forms;

namespace Test_TreeList_Simple
{
    /// <summary>
    /// Form1
    /// </summary>
    public partial class Form1 : XtraForm
    {
        private string _currentDir = string.Empty;

        /// <summary>
        /// Constructor
        /// </summary>
        public Form1()
        {
            InitializeComponent();

            treeList1.CustomNodeCellEdit += TreeList1_CustomNodeCellEdit;

            TreeListColumn col = treeList1.Columns.Add();
            col.FieldName = "Col A";
            col.Caption = "Data";
            col.VisibleIndex = 0;

            col = treeList1.Columns.Add();
            col.FieldName = "Col B";
            col.Caption = "Item";
            col.VisibleIndex = 1;
        }

        private void TreeList1_CustomNodeCellEdit(object sender, GetCustomNodeCellEditEventArgs e)
        {
            if (e.Column.VisibleIndex == 1)
            {
                switch (e.Node.GetValue(0).ToString())
                {
                    case nameof(FileInfo.IsReadOnly):
                        e.RepositoryItem = new RepositoryItemCheckEdit();
                        break;
                    case nameof(FileInfo.CreationTime):
                        e.RepositoryItem = new RepositoryItemDateEdit();
                        break;
                    case nameof(FileInfo.Length):
                        e.RepositoryItem = new RepositoryItemSpinEdit();
                        break;
                    default:
                        break;
                }

                if (e.Node.GetValue(0).ToString() == nameof(FileInfo.IsReadOnly))
                {
                    e.RepositoryItem = new RepositoryItemCheckEdit();
                }
                else if (e.Node.GetValue(0).ToString() == nameof(FileInfo.CreationTime))
                {
                    e.RepositoryItem = new RepositoryItemDateEdit();
                }
            }
        }

        private void RefreshTreeList()
        {
            treeList1.ClearNodes();

            var files = DataSource.GetFileList(_currentDir);
            foreach (var file in files)
            {
                var parentNode = treeList1.AppendNode(new object[] { file.Directory, file.Name }, null);
                treeList1.AppendNode(new object[] { nameof(FileInfo.CreationTime), file.CreationTime }, parentNode);
                treeList1.AppendNode(new object[] { nameof(FileInfo.Length), file.Length }, parentNode);
                treeList1.AppendNode(new object[] { nameof(FileInfo.IsReadOnly), file.IsReadOnly }, parentNode);
            }
            treeList1.ExpandAll();
        }

        private void BtnEditDirPath_EditValueChanged(object sender, System.EventArgs e)
        {
            RefreshTreeList();
        }

        private void BtnEditDirPath_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (xtraFolderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                _currentDir = xtraFolderBrowserDialog1.SelectedPath;
                (sender as ButtonEdit).EditValue = _currentDir;
            }
        }
    }
}
