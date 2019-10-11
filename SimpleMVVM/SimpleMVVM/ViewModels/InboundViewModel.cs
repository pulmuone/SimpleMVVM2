using SimpleMVVM.Controls;
using SimpleMVVM.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleMVVM.ViewModels
{
    public class InboundViewModel : ViewModelBase
    {
        private ObservableRangeCollection<InboundModel> _inboundList = new ObservableRangeCollection<InboundModel>();

        private DateTime _inboundDate = Convert.ToDateTime("1900-01-01");
        private string _invoiceNumber;


        public InboundViewModel()
        {
            List<InboundModel> lst = new List<InboundModel>
            {
                new InboundModel{ InvoiceNumber ="ABC1234", InboundDate ="2019-10-11",  VenderCode="Z101", VenderName="매입업체 Z101", Remark ="긴급 주문입니다." },
                new InboundModel{ InvoiceNumber ="ABC1235", InboundDate ="2019-10-11",  VenderCode="Z102", VenderName="매입업체 Z102", Remark ="영업팀 확인 요망"  },
                new InboundModel{ InvoiceNumber ="ABC1236", InboundDate ="2019-10-11",  VenderCode="Z103", VenderName="매입업체 Z103", Remark = string.Empty }
            };

            InboundList.AddRange(lst);

            InboundDate = DateTime.Now;
        }


        public ObservableRangeCollection<InboundModel> InboundList
        {
            get => _inboundList;
            set => SetProperty(ref this._inboundList, value);
        }

        public DateTime InboundDate { get => _inboundDate; set => SetProperty(ref _inboundDate, value); }
        public string InvoiceNumber { get => _invoiceNumber; set => SetProperty(ref _invoiceNumber, value); }

    }
}
