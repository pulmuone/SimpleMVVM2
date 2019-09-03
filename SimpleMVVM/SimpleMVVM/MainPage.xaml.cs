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

        private void MoveButton_Clicked(object sender, EventArgs e)
        {
            //collectionView.ScrollTo(30);

            //collectionView.SelectedItem = new EmpModel { EmpId = "50", EmpName = "test", Addr = "addr", Age = 12, Money = 5000 };

        }

        private void Entry_Focused(object sender, FocusEventArgs e)
        {
            Console.WriteLine(collectionView.SelectedItem);
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Console.WriteLine("=========================== test");
        }
    }
}
