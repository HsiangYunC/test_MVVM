using System;

namespace test_MVVM
{
    // ViewModel & Model inherit PropertyObservable class
    public class Model : PropertyObservable
    {
        private string _item;
        private int _price;

        public Model(string item, int price)
        {
            Id = Guid.NewGuid();
            _item = item;
            _price = price;
        }

        public Guid Id { get; private set; }

        public string Item
        {
            get => _item;
            set
            {
                _item = value;
                OnPropertyChanged();
            }
        }

        public int Price
        {
            get => _price;
            set
            {
                _price = Math.Max(0, value);
                OnPropertyChanged();
            }
        }
    }
}
