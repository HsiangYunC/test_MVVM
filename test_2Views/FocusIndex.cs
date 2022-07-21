using PropertyObserve;

namespace Test_2Views
{
    /// <summary>
    /// FocusIndex
    /// </summary>
    internal class FocusIndex : PropertyObservable
    {
        private int _value;

        /// <summary>
        /// Value
        /// </summary>
        public int Value
        {
            get => _value;
            set
            {
                this._value = value;
                OnPropertyChanged();
            }
        }
    }
}
