namespace AY.Translit.TestApp
{
    public partial class MainWindowView
    {
        public MainWindowView()
        {
            InitializeComponent();
        }

        public MainWindowView(IMainWindow viewModel)
            : this()
        {
            DataContext = viewModel;
        }
    }
}
