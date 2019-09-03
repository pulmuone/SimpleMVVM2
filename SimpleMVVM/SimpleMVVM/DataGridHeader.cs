using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SimpleMVVM
{
    public class DataGridHeader : Label
    {
        public string FieldName { get; set; }

        public bool SortFlag { get; set; }

        public bool AllowSort { get; set; }

        public bool IsSelectionField { get; set; }
    }
}
