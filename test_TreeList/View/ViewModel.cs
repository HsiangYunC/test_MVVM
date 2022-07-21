using PropertyObserve;
using System;
using System.ComponentModel;

namespace Test_TreeList
{
    /// <summary>
    /// ViewModel
    /// ViewModel & Model inherit PropertyObservable class
    /// </summary>
    public class ViewModel : PropertyObservable
    {
        private readonly Model _model;
        private Guid _parentId;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="model">model</param>
        /// <param name="parantId">parantId</param>
        public ViewModel(Model model, Guid parantId)
        {
            _parentId = parantId;

            // add PropertyChanged event
            _model = model;
            _model.PropertyChanged += ModelPropertyChanged;
        }

        #region Model parameter
        /// <summary>
        /// ID for treeList
        /// </summary>
        public Guid ID => _model.Id;

        /// <summary>
        /// ParentID for treeList
        /// </summary>
        public Guid ParentID => _parentId;

        /// <summary>
        /// Item
        /// </summary>
        [DisplayName("Item")]
        public string Item
        {
            get => _model.Item;
            set
            {
                _model.Item = value;
            }
        }

        /// <summary>
        /// Count
        /// </summary>
        [DisplayName("Count")]
        public int Count
        {
            get => _model.Count;
            set
            {
                _model.Count = value;
            }
        }
        #endregion

        /// <summary>
        /// Dispose
        /// </summary>
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
