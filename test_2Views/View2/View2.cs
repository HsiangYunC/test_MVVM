using DevExpress.XtraEditors;
using System;

namespace Test_2Views
{
    /// <summary>
    /// View 2
    /// </summary>
    public partial class View2 : XtraForm
    {
        private readonly FocusIndex _focusIndex = new FocusIndex();
        private View2Controller _viewController = null;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="focusIndex">focusIndex</param>
        internal View2(FocusIndex focusIndex)
        {
            _focusIndex = focusIndex;
            _focusIndex.PropertyChanged += FocusIndexPropertyChanged;

            InitializeComponent();
        }

        private void UpdateFocus()
        {
            // dispose view controller before use
            _viewController?.Dispose();

            // bind view model list to UI component datasource
            _viewController = new View2Controller(_focusIndex.Value);
            treeList1.DataSource = _viewController.ViewModelList;
            treeList1.ExpandAll();
        }

        private void View_Load(object sender, EventArgs e)
        {
            UpdateFocus();
        }

        private void FocusIndexPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            UpdateFocus();
        }
    }
}
