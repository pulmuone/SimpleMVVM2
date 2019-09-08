using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace SimpleMVVM
{
    public interface IViewModel
    {
        ICommand SortedCommand { get; set; }
    }
}
