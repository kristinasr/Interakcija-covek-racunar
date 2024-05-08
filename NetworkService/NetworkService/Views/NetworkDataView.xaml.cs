using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NetworkService.Views
{
   
    public partial class NetworkDataView : UserControl
    {
        public NetworkDataView()
        {
            InitializeComponent();
            this.DataContext = new ViewModel.NetworkDataViewModel();
        }

        private void TextBoxId_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
