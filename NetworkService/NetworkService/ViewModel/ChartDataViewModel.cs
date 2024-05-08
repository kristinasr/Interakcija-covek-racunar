using NetworkService.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Xml.Linq;

namespace NetworkService.ViewModel
{

    public class ChartDataViewModel : BindableBase
    {
        public MyICommand<CheckBoxChartModel> CheckboxCommand { get; set; }
      

        private bool isChecked = true;
        public bool IsChecked
        {
            get { return isChecked; }
            set
            {
                isChecked = value;
                OnPropertyChanged("IsChecked");
            }
        }

        public static ObservableCollection<CheckBoxChartModel> CheckBoxItems { get; set; } = new ObservableCollection<CheckBoxChartModel>();

        public static ObservableCollection<Termometer> ChartTermometers { get; set; } = new ObservableCollection<Termometer>(); 

        public static GraphUpdater Elements { get; set; } = new GraphUpdater();

        
        /// <param name="dot">Poluprecnik kruga</param>
        /// <param name="value">Vrednost</param>
        /// <param name="name">Koji reaktor menja vrednost</param>


        public static void SetFirstDotAndValue(double value, string name)
        {
            
            if (ChartTermometers.Count != 0)
            {
               
                var reaktor = ChartTermometers.FirstOrDefault(g => g.Naziv == name);

                if (reaktor != null)
                {
                   
                    Elements.FirstDot = CalculateElementRadius(value);
                    Elements.FirstValue = value;
                    Elements.FirstTime = DateTime.Now.ToString("HH:mm");
                }
            }
            else
            {
                Elements.FirstDot = CalculateElementRadius(value);
                Elements.FirstValue = value;
                Elements.FirstTime = DateTime.Now.ToString("HH:mm");
            }
             
        }

       
        /// <param name="checkBoxData"></param>


       
        private void CheckBoxExecute(CheckBoxChartModel checkBoxData)
        {
            Termometer forDisplay = new Termometer();

            if (checkBoxData.IsChecked)
            {
               
                var reaktor = DataBase.Termometers.FirstOrDefault(g => g.Naziv == checkBoxData.Naziv);
                ChartTermometers.Add(reaktor);
            }
            else
            {
                var reaktor = DataBase.Termometers.FirstOrDefault(g => g.Naziv == checkBoxData.Naziv);
                ChartTermometers.Remove(reaktor); 
            }
  
        }

        /// <summary>
        /// Racuna velicinu poluprecnika kruga 
        /// 9 zbog velicina elipse to je odoka stavljeno
        /// </summary>
        /// <param name="value">Vrednost iz metering simulatora</param>
        /// <returns></returns>

        public static double CalculateElementRadius(double value)
        {
            return value / 9;
        }

        /// <summary>
        /// Inicijalizacija svih reaktora i komandi
        /// </summary>

        
        public ChartDataViewModel()
        {
            
            CheckboxCommand = new MyICommand<CheckBoxChartModel>(CheckBoxExecute);

            CheckBoxItems.Clear();
            ChartTermometers.Clear();

            
            foreach (Termometer ob in DataBase.Termometers)
            {
                CheckBoxItems.Add(new CheckBoxChartModel(ob.Naziv, false));
            }
        }


    }
}
