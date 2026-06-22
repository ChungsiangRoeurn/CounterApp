namespace CounterApp.ViewModels
{
    public class OverviewViewModel
    {
        private readonly MainViewModel _mainViewModel;

        public OverviewViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }
    }
}