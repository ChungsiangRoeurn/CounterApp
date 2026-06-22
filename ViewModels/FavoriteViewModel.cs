using System;
using System.Collections.Generic;
using System.Text;

namespace CounterApp.ViewModels
{
    public class FavoriteViewModel
    {
        private readonly MainViewModel _mainViewModel;

        public FavoriteViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }
    }
}
