using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SimpleMVVM
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            //BindingContext = new EmpViewModel();

            this.EmpId.CursorPosition = 2;
            this.EmpId.SelectionLength = 2;
        }
    }
}
