using DevExpress.XtraEditors;
using System;

namespace test_TreeList
{
    public partial class View : XtraForm
    {
        private ViewController _viewController = null;

        public View()
        {
            InitializeComponent();
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
            _viewController = new ViewController();
            treeList1.DataSource = _viewController.ViewModelList;
            treeList1.ExpandAll();
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            UpdateFocus();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            string item = textEdit1.Text;
            if (int.TryParse(textEdit2.Text, out int price))
            {
                // send command to view controller
                _viewController.AddItem(item, price);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (treeList1.FocusedNode != null)
            {
                var data = treeList1.GetDataRecordByNode(treeList1.FocusedNode);

                // send command to view controller
                _viewController.RemoveItem(data);
            }
        }
    }
}
