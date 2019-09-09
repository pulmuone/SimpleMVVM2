using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;
using System.Linq;
using SimpleMVVM.Sorting;
using SimpleMVVM.Controls;

namespace SimpleMVVM
{
    public class EmpViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableRangeCollection<EmpModel> _empList = new ObservableRangeCollection<EmpModel>();

        private string _result;

        private string _empId;
        private string _empName;

        private EmpModel _selectedItem;

        public ICommand SendCommand { get; } //생성자에서만 new할꺼면 private set없어도 된다.

        public ICommand ReturnValueCommand { get; }

        //public ICommand SortedCommand { get; set; }

        public EmpViewModel()
        {
            SendCommand = new Command(() => Send());
            ReturnValueCommand = new Command(() => Return());
            SortedCommand = new Command<DataGridHeader>(Sorted);

            EmpId = "1234";

        }

        private void Sorted(DataGridHeader e)
        {
            Console.WriteLine(e.SortFlag);
            Console.WriteLine(e.SortingEnabled);
            Console.WriteLine(e.FieldName);

            if(!e.SortingEnabled)
            {
                return;
            }

            SortingOrder sortMethod;
            
            if (e.SortFlag ==  SortingOrder.None || e.SortFlag == SortingOrder.Ascendant)
            {
                sortMethod = SortingOrder.Descendant;
            }
            else
            {
                sortMethod = SortingOrder.Ascendant;
            }

            e.SortFlag = sortMethod;
            List<EmpModel> lst = EmpList.ToList();

            SortData.SortList(ref lst, e.SortFlag, e.FieldName);

            EmpList.Clear();
            EmpList.AddRange(lst);
        }

        private void Return()
        {
            Debug.WriteLine("return");
        }

        private void Send()
        {
            EmpList.Clear();
            for (int i = 0; i < 100; i++)
            {
                EmpList.Add(new EmpModel { EmpId = i, EmpName = "test", Addr = i.ToString() + "addr", Age = i, Money = 5000 });
            }

            SelectedItem = EmpList.Skip(2).FirstOrDefault();

            //EmpList.Add(new EmpModel
            //    {
            //        EmpId = this.EmpId,
            //        EmpName = this.EmpName
            //    }
            //);
        }


        public string Result
        {
            set
            {
                if (_result == value) return;                
                _result = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Result"));

                //if (PropertyChanged != null)
                //{
                //    PropertyChanged(this, new PropertyChangedEventArgs("Result"));
                //}
            }

            get { return _result;}
        }

        public string EmpId
        {
            set
            {
                if (_empId == value) return;
                _empId = value;

               NotifyPropertyChanged();
               //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("EmpId"));
            }

            get { return _empId; }
        }

        public string EmpName
        {
            set
            {
                if (_empName == value) return;
                _empName = value;

                NotifyPropertyChanged();
                //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(EmpName));
            }

            get { return _empName; }
        }

        public ObservableRangeCollection<EmpModel> EmpList
        {
            get { return _empList; }

            set
            {
                if (_empList == value) return;
                _empList = value;

                NotifyPropertyChanged();
            }
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            //if(PropertyChanged != null)
            //{
            //    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            //}

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public EmpModel SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                if (_selectedItem != value)
                {
                    _selectedItem = value;
                }
            }
        }
    }
}
