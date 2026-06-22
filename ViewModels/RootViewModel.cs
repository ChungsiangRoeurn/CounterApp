using CounterApp.ViewModels;
using System.ComponentModel;
using System.Runtime.CompilerServices;

public class RootViewModel : INotifyPropertyChanged
{
    private object? _currentViewModel;

    public object? CurrentViewModel
    {
        get => _currentViewModel;
        set { _currentViewModel = value; OnPropertyChanged(); }
    }

    public RootViewModel()
    {
        CurrentViewModel = new LoginViewModel(this); 
    }

    public void GoToDashboard()
    {
        CurrentViewModel = new MainViewModel(this);
    }

    public void GoToLogin()
    {
        CurrentViewModel = new LoginViewModel(this);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string name = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}