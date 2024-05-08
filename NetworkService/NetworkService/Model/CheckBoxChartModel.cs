using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkService.Model
{
    public class CheckBoxChartModel
    {
        public string Naziv { get; set; }
        public bool IsChecked { get; set; }

        public CheckBoxChartModel(string naziv, bool isChecked)
        {
            Naziv = naziv;
            IsChecked = isChecked;
        }
    }
}
