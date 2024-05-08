using NetworkService.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows;
using System.Collections.ObjectModel;

namespace NetworkService.Converters
{
    
    public class PercentageToPixelConverter : IValueConverter
    {
       
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is ObservableCollection<Termometer>)
            { 
                var database = (ObservableCollection<Termometer>)value; 
                                                                      
                var total = database.Count();   
                var rtdCount = database.Where(d => d.Tip.NazivTipa == "RTD").Count();
                                                                                       
                var rtdPercentage = (double)rtdCount / total; 
                                                              

               
                var totalPixel = System.Convert.ToDouble(parameter); 
                return rtdPercentage * totalPixel; 
            }

            return 0;  
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
