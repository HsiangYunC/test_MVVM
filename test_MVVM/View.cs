using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace test_MVVM
{
    public partial class View : Form
    {
        private ViewController _viewController = null;

        public View()
        {
            InitializeComponent();
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

        private void View_Load(object sender, EventArgs e)
        {
            UpdateFocus();
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
        }

        public void AddItem(string item, int price)
        {
            // send command to data source
            DataSource.AddItem(new Model(item, price));
        }
        public void RemoveItem(object vm)
        {
            if (vm is ViewModel model)
                // send command to data source
                DataSource.RemoveItem(model.Guid);
        }
    }

    // ViewModel & Model inherit PropertyObservable class
    public class ViewModel : PropertyObservable
    {
        private readonly Model _model;

        public ViewModel(Model model)
        {
            // add PropertyChanged event
            _model = model;
            _model.PropertyChanged += ModelPropertyChanged;
        }

        #region Model parameter
        public Guid Guid => _model.Id;
        public string Item => _model.Item;
        public int Price => _model.Price;
        #endregion

        private void ModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged(e.PropertyName);
        }
    }

    public class Model : PropertyObservable
    {
        public Model(string item, int price)
        {
            Id = Guid.NewGuid();
            Item = item;
            Price = price;
        }
        public Guid Id { get; private set; }

        public string Item { get; set; }

        public int Price { get; set; }
    }
}
