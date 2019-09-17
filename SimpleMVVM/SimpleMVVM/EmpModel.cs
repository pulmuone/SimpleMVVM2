using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SimpleMVVM
{
    public class EmpModel  : BindableObject
    {
        public ICommand PlusButtonCommand { get; }
        public ICommand MinusButtonCommand { get; }        

        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string Addr { get; set; }

        private int _age;
        public int Age 
        {
            get { return this._age; }
            set
            {
                if (_age == value) return;
                this._age = value;
                OnPropertyChanged("Age");
            }
        }

        public int Money { get; set; }


        public EmpModel()
        {
            PlusButtonCommand = new Command(() => PlusButton());
            MinusButtonCommand = new Command(() => MinusButton());
        }

        
        private void MinusButton()
        {
            Age -= 1;
        }

        private void PlusButton()
        {
            Age += 1;
        }
    }
}
