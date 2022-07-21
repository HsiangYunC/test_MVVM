using System;
using System.ComponentModel;

namespace Test_2Views
{
    /// <summary>
    /// ViewController
    /// </summary>
    public class View1Controller
    {
        private readonly BindingList<Model> _modelList; // bind view model

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="index">index</param>
        public View1Controller(int index)
        {
            // bind view model
            _modelList = DataSource.ModelList[index]; // bind data source
            _modelList.ListChanged += ModelListChanged;
            ViewModelList = new BindingList<View1Model>();
            Initialize();
        }

        /// <summary>
        /// ViewModelList
        /// </summary>
        public BindingList<View1Model> ViewModelList { get; } // bind view

        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            if (_modelList != null)
            {
                _modelList.ListChanged -= ModelListChanged;
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
            //DataSource.AddItem(index);
        }
        /// <summary>
        /// removeItem
        /// </summary>
        /// <param name="index">index</param>
        /// <param name="vm">vm</param>
        public void RemoveItem(int index, object vm)
        {
            if (vm is View1Model model)
            {
                // send command to data source
                //DataSource.RemoveItem(index, model.ID);
            }
        }

        private void Initialize()
        {
            ViewModelList.Clear();

            foreach (var model in _modelList)
            {
                var parentNode = new View1Model(model, Guid.Empty);
                ViewModelList.Add(parentNode);

                if (DataSource.ModelList2.TryGetValue(parentNode.ID, out var subItems))
                {
                    foreach (var subitem in subItems)
                    {
                        var childNode = new View1Model(subitem, parentNode.ID);
                        ViewModelList.Add(childNode);
                    }
                }
            }
        }

        private void ModelListChanged(object sender, ListChangedEventArgs e)
        {
            Initialize();
        }
    }
}
