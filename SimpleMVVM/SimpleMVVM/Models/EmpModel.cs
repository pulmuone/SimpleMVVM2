using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SimpleMVVM.Models
{
    public class EmpModel  : BindableObject
    {
        public ICommand PlusButtonCommand { get; }
        public ICommand MinusButtonCommand { get; }        

        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string Addr { get; set; }

        private int _age;
        
        public ComboBoxModel Grade { get; set; }

        public List<ComboBoxModel> Grades { get; set; }

        public EmpModel()
        {
            PlusButtonCommand = new Command(() => PlusButton());
            MinusButtonCommand = new Command(() => MinusButton());


            Grades = new List<ComboBoxModel>
            {
                new ComboBoxModel {Code="001", Name="1학년"},
                new ComboBoxModel {Code="002", Name="2학년"},
                new ComboBoxModel {Code="003", Name="3학년"},
                new ComboBoxModel {Code="004", Name="4학년"}
            };
        }

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
