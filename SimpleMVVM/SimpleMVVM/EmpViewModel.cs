using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SimpleMVVM
{
    public class EmpViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<EmpModel> _empList = new ObservableCollection<EmpModel>();

        private string _result;

        private string _empId;
        private string _empName;

        public ICommand SendCommand { get; } //생성자에서만 new할꺼면 private set없어도 된다.

        public ICommand ReturnValueCommand { get; }

        public EmpViewModel()
        {
            SendCommand = new Command(() => Send());
            ReturnValueCommand = new Command(() => Return());
            EmpId = "1234";
        }

        private void Return()
        {
            Debug.WriteLine("return");
        }

        private void Send()
        {
            Result = string.Format("ID : {0}, Name : {1}", EmpId, EmpName);

            //List<EmpModel> _list = new List<EmpModel>();

            EmpList.Clear();
            //EmpList = new ObservableCollection<EmpModel>(_list);


            EmpList.Add(new EmpModel
                {
                    EmpId = this.EmpId,
                    EmpName = this.EmpName
                }
            );
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

        public ObservableCollection<EmpModel> EmpList
        {
            get { return _empList; }

            set
            {
                if(_empList == value) return;
                _empList = value;

                NotifyPropertyChanged();
                //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("EmpList"));
            }
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
