namespace Test_2Views
{
    /// <summary>
    /// EntryView
    /// </summary>
    public partial class EntryView : DevExpress.XtraEditors.XtraForm
    {
        private FocusIndex _focusIndex = new FocusIndex();

        /// <summary>
        /// Constructor
        /// </summary>
        public EntryView()
        {
            _focusIndex.Value = 0;
            InitializeComponent();

            new View1(_focusIndex).Show();
            new View2(_focusIndex).Show();
        }

        private void BtnFrontPage_Click(object sender, System.EventArgs e)
        {
            _focusIndex.Value = (_focusIndex.Value + DataSource.ModelList.Count - 1) % DataSource.ModelList.Count;
        }

        private void BtnNextPage_Click(object sender, System.EventArgs e)
        {
            _focusIndex.Value = (_focusIndex.Value + 1) % DataSource.ModelList.Count;
        }
    }
}
