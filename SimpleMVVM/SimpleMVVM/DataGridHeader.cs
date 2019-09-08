using SimpleMVVM.Behaviors;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using SimpleMVVM.Sorting;

namespace SimpleMVVM
{
    public class DataGridHeader : Label
    {

        public string FieldName { get; set; }

        public SortingOrder SortFlag { get; set; }

        public static readonly BindableProperty SortingEnabledProperty = BindableProperty.Create(nameof(SortingEnabled), typeof(bool), typeof(DataGridHeader), true);

        public bool SortingEnabled
        {
            get { return (bool)GetValue(SortingEnabledProperty); }
            set { SetValue(SortingEnabledProperty, value); }
        }

        public DataGridHeader()
        {
            //ViewModel = new ViewModelBase();
            var tapGestureRecognizer = new TapGestureRecognizer
            {
                NumberOfTapsRequired = 1
            };
            tapGestureRecognizer.Tapped += (s, e) =>
            {
                Console.WriteLine("gwise-test {0}", SortingEnabled);

                Clicked?.Invoke(s, EventArgs.Empty);
            };

            this.GestureRecognizers.Add(tapGestureRecognizer);

            //EventToCommandBehavior etcb = new EventToCommandBehavior();
            //etcb.EventName = "Clicked";
            //etcb.Command = (BindingContext as ViewModelBase).SortedCommand;
            //etcb.CommandParameter = this;

            //this.Behaviors.Add(etcb);
        }

        //https://stackoverflow.com/questions/35811060/how-to-create-click-event-on-label-in-xamarin-forms-dynamically/35811410
        public event EventHandler Clicked;

        public string Name
        {
            get; set;
        }

        //public void OnClicked()
        //{
        //    Clicked?.Invoke(this, null);
        //}

        //public event EventHandler Clicked
        //{
        //    add
        //    {
        //        lock (this)
        //        {
        //            click += value;

        //            var g = new TapGestureRecognizer();

        //            g.Tapped += (s, e) => click?.Invoke(s, e);

        //            GestureRecognizers.Add(g);
        //        }
        //    }
        //    remove
        //    {
        //        lock (this)
        //        {
        //            click -= value;

        //            GestureRecognizers.Clear();
        //        }
        //    }
        //}
    }
}
