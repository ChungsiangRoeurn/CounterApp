using System;
using System.Collections.Generic;
using System.Text;

namespace CounterApp.ViewModels
{
    public class MovieViewModel
    {
        private readonly MainViewModel _mainViewModel;

        public MovieViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }
    }
}