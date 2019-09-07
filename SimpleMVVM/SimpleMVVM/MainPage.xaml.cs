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

            //this.EmpId.CursorPosition = 2;
            //this.EmpId.SelectionLength = 2;
           
        }

        private void MoveButton_Clicked(object sender, EventArgs e)
        {
            //collectionView.ScrollTo(30);

            //collectionView.SelectedItem = new EmpModel { EmpId = "50", EmpName = "test", Addr = "addr", Age = 12, Money = 5000 };

        }

        private void Entry_Focused(object sender, FocusEventArgs e)
        {
            Console.WriteLine(e.ToString());
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Console.WriteLine("=========================== test");
        }

        private void CollectionView_Focused(object sender, FocusEventArgs e)
        {
            Console.WriteLine(((CollectionView)sender).SelectedItem);
        }

        private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Console.WriteLine(((CollectionView)sender).SelectedItem);
            Console.WriteLine(e.CurrentSelection);

            string previous = (e.PreviousSelection.FirstOrDefault() as EmpModel)?.EmpId;
            string current = (e.CurrentSelection.FirstOrDefault() as EmpModel)?.EmpId;

            this.collectionView.ScrollTo(30, 0, ScrollToPosition.Start, false);
        }

        private void CollectionView_ScrollToRequested(object sender, ScrollToRequestEventArgs e)
        {
            
            
            Console.WriteLine("ScrollToRequested : " + e.Index);
         }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {

        }

        private void H0_Clicked(object sender, EventArgs e)
        {
            Console.WriteLine("aa");
        }
    }
}
