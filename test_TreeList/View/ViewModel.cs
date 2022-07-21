using PropertyObserve;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace test_TreeList
{
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
        [Display(AutoGenerateField = false)]
        public Guid Guid => _model.Id;

        [DisplayName("Item")]
        public string Item
        {
            get => _model.Item;
            set
            {
                _model.Item = value;
            }
        }

        [DisplayName("Price")]
        public int Price
        {
            get => _model.Price;
            set
            {
                _model.Price = value;
            }
        }
        #endregion

        public void Dispose()
        {
            if (_model != null)
            {
                _model.PropertyChanged -= ModelPropertyChanged;
            }
        }

        private void ModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged(e.PropertyName);
        }
    }
}
