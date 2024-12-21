using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEGES_Models.ViewModels
{
    public class DetailInfoVM
    {
        public string Caption { get; set; }
        public string Value { get; set; }
        public DetailInfoVM(string caption, string value)
        {
            Caption = caption;
            Value = value;
        }
    }
}
