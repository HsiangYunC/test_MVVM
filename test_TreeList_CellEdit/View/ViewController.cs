using System;
using System.ComponentModel;

namespace Test_TreeList_CellEdit
{
    /// <summary>
    /// ViewController
    /// </summary>
    public class ViewController
    {
        private readonly BindingList<Model> _modelList; // bind view model

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="index">index</param>
        public ViewController(int index)
        {
            // bind view model
            _modelList = DataSource.ModelList[index]; // bind data source
            _modelList.ListChanged += ListChanged_Model;

            ViewModelList = new BindingList<ViewModel>();
            Initialize();
        }

        /// <summary>
        /// ViewModelList
        /// </summary>
        public BindingList<ViewModel> ViewModelList { get; } // bind view

        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            if (_modelList != null)
            {
                _modelList.ListChanged -= ListChanged_Model;
            }

            foreach (var vm in ViewModelList)
            {
                vm.Dispose();
            }
        }

        /// <summary>
        /// Additem
        /// </summary>
        /// <param name="index">index</param>
        public void AddItem(int index)
        {
            // send command to data source
            DataSource.AddItem(index);
        }
        /// <summary>
        /// removeItem
        /// </summary>
        /// <param name="index">index</param>
        /// <param name="vm">vm</param>
        public void RemoveItem(int index, object vm)
        {
            if (vm is ViewModel model)
            {
                // send command to data source
                DataSource.RemoveItem(index, model.ID);
            }
        }

        private void Initialize()
        {
            ViewModelList.Clear();

            foreach (var model in _modelList)
            {
                var parentNode = new ViewModel(model, Guid.Empty);
                ViewModelList.Add(parentNode);

                if (DataSource.ModelList2.TryGetValue(parentNode.ID, out var subItems))
                {
                    foreach (var subitem in subItems)
                    {
                        var childNode = new ViewModel(subitem, parentNode.ID);
                        ViewModelList.Add(childNode);
                    }
                }
            }
        }

        private void ListChanged_Model(object sender, ListChangedEventArgs e)
        {
            Initialize();
        }
    }
}
