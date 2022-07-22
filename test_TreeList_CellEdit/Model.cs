using PropertyObserve;
using System;

namespace Test_TreeList_CellEdit
{
    /// <summary>
    /// Model
    /// ViewModel & Model inherit PropertyObservable class
    /// </summary>
    public class Model : PropertyObservable
    {
        private string _item;
        private int _count;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="item">item name</param>
        /// <param name="count">count</param>
        public Model(Fruit item, int count)
        {
            Id = Guid.NewGuid();
            _item = item.ToString();
            _count = count;
        }

        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; private set; }
        /// <summary>
        /// Item
        /// </summary>
        public string Item
        {
            get => _item;
            set
            {
                _item = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Count
        /// </summary>
        public int Count
        {
            get => _count;
            set
            {
                _count = Math.Max(0, value);
                OnPropertyChanged();
            }
        }
    }
}
