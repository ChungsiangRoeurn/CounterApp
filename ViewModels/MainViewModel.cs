using CounterApp.Commands;
using CounterApp.ViewModels;
using CounterApp.Views;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace CounterApp.ViewModels 
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly RootViewModel _root;

        public ICommand OverviewCommand { get; }
        public ICommand FavoriteCommand { get; }
        public ICommand MovieCommand { get; }
        public ICommand SettingCommand { get; }
        public ICommand LogoutCommand { get; }

        private object? _currentViewModel;
        public object? CurrentViewModel
        {
            get => _currentViewModel;
            set { 
                _currentViewModel = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel(RootViewModel root)
        {
            _root = root;

            OverviewCommand = new RelayCommand(_ =>
                CurrentViewModel = new OverviewViewModel(this));

            MovieCommand = new RelayCommand(_ =>
                CurrentViewModel = new MovieListViewModel(this));

            FavoriteCommand = new RelayCommand(_ =>
                CurrentViewModel = new FavoriteViewModel(this));

            SettingCommand = new RelayCommand(_ =>
                CurrentViewModel = new SettingsViewModel(this));

            LogoutCommand = new RelayCommand(_ =>
            {
                var result = System.Windows.MessageBox.Show(
                    "Are you sure you want to logout?",
                    "Confirm Logout",
                    System.Windows.MessageBoxButton.YesNo,
                    System.Windows.MessageBoxImage.Question);

                if (result == System.Windows.MessageBoxResult.Yes)
                {
                    _root.GoToLogin();
                }
            });

            CurrentViewModel = new OverviewViewModel(this);
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
} 