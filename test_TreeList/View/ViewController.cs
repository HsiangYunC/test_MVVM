using System.ComponentModel;

namespace test_TreeList
{
    public class ViewController
    {
        private readonly BindingList<Model> _modelList; // bind view model
        public BindingList<ViewModel> ViewModelList { get; } // bind view

        public ViewController()
        {
            // bind view model
            _modelList = DataSource.ModelList; // bind data source
            _modelList.ListChanged += ListChanged_Model;
            ViewModelList = new BindingList<ViewModel>();
            Initialize();
        }

        private void ListChanged_Model(object sender, ListChangedEventArgs e)
        {
            Initialize();
        }

        private void Initialize()
        {
            ViewModelList.Clear();

            foreach (var model in _modelList)
            {
                ViewModelList.Add(new ViewModel(model));
            }
        }

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

        public void AddItem(string item, int price)
        {
            // send command to data source
            DataSource.AddItem(new Model(item, price));
        }
        public void RemoveItem(object vm)
        {
            if (vm is ViewModel model)
            {
                // send command to data source
                DataSource.RemoveItem(model.Guid);
            }
        }
    }
}
