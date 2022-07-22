using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using System;
using System.Drawing;

namespace Test_TreeList_CellEdit
{
    /// <summary>
    /// View
    /// </summary>
    public partial class View : XtraForm
    {
        private int _focusIndex = 0;
        private ViewController _viewController = null;

        /// <summary>
        /// Constructor
        /// </summary>
        public View()
        {
            InitializeComponent();
            treeList1.CustomNodeCellEdit += TreeList1_CustomNodeCellEdit;
        }

        private void View_Load(object sender, EventArgs e)
        {
            UpdateFocus();
        }

        private void UpdateFocus()
        {
            // dispose view controller before use
            _viewController?.Dispose();

            // bind view model list to UI component datasource
            _viewController = new ViewController(_focusIndex);
            treeList1.DataSource = _viewController.ViewModelList;
            treeList1.ExpandAll();
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            UpdateFocus();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            _viewController.AddItem(_focusIndex);
            treeList1.ExpandAll();

            //string item = textEdit1.Text;
            //if (int.TryParse(textEdit2.Text, out int count))
            //{
            //    // send command to view controller
            //    _viewController.AddItem(_focusIndex, item, count);
            //}
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (treeList1.FocusedNode != null)
            {
                var data = treeList1.GetDataRecordByNode(treeList1.FocusedNode);

                // send command to view controller
                _viewController.RemoveItem(_focusIndex, data);
            }

            treeList1.ExpandAll();
        }

        private void Btn_NextPage_Click(object sender, EventArgs e)
        {
            _focusIndex = ++_focusIndex % 3;
            UpdateFocus();
        }

        private void TreeList1_CustomNodeCellEdit(object sender, DevExpress.XtraTreeList.GetCustomNodeCellEditEventArgs e)
        {
            if (e.Node.Level == 1 && e.Column.FieldName == nameof(Model.Count))
            {
                //e.RepositoryItem = new RepositoryItemButtonEdit();
                //e.RepositoryItem = new RepositoryItemCheckEdit();
                e.RepositoryItem = new RepositoryItemToggleSwitch();
            }
        }
    }
}
