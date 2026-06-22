using System;
using System.Collections.Generic;
using System.Text;

namespace CounterApp.ViewModels
{
    public class SettingsViewModel
    {
        private readonly MainViewModel _mainViewModel;

        public SettingsViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }
    }
}