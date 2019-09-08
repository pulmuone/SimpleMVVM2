using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace SimpleMVVM
{
    public class ViewModelBase : IViewModel
    {

        public ViewModelBase()
        {
            
        }

        public ICommand SortedCommand { get; set; }
    }
}
