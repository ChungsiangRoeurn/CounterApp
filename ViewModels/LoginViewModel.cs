using CounterApp.Commands;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace CounterApp.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private readonly RootViewModel _root;

        private string _username = "";
        private string _password = "";
        private string _message = "";

        public string Username
        {
            get => _username;
            set { _username = value; OnPropertyChanged(); }
        }

        public string Password
        {
            get => _password;
            set { _password = value; OnPropertyChanged(); }
        }

        public string Message
        {
            get => _message;
            set { _message = value; OnPropertyChanged(); }
        }

        public ICommand LoginCommand { get; }

        public LoginViewModel(RootViewModel root)
        {
            _root = root;
            LoginCommand = new RelayCommand(ExecuteLogin);
        }

        private void ExecuteLogin(object? obj)
        {
            if (Username == "admin" && Password == "admin")
            {
                MessageBox.Show("Login Success");

                _root.GoToDashboard(); // 👈 SWITCH HERE
            }
            else
            {
                MessageBox.Show("Invalid username or password");
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}