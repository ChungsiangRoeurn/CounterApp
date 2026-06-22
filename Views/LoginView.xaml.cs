using CounterApp.ViewModels;
using System.Windows.Controls;

namespace CounterApp.Views
{
    public partial class LoginView : UserControl
    {
        public LoginView()
        {
            InitializeComponent();

            PasswordBox.PasswordChanged += (s, e) =>
            {
                if (DataContext is LoginViewModel vm)
                {
                    vm.Password = PasswordBox.Password;
                }
            };
        }
    }
}