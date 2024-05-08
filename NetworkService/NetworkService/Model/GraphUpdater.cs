using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkService.Model
{
    public class GraphUpdater : BindableBase
    {
        //5 tacaka koji predstavljaju 5 poluprecinka krugova i 5 njihovih vrednosti

        private double firstDot;
        public double FirstDot
        {
            get { return firstDot; }
            set
            {
                SecondDot = firstDot;
                firstDot = value;
                OnPropertyChanged("FirstDot"); 
            }
        }

        private double secondDot;
        public double SecondDot
        {
            get { return secondDot; }
            set
            {
                ThirdDot = secondDot;
                secondDot = value;
                OnPropertyChanged("SecondDot");
            }
        }

        private double thirdDot;
        public double ThirdDot
        {
            get { return thirdDot; }
            set
            {
                FourthDot = thirdDot;
                thirdDot = value;
                OnPropertyChanged("ThirdDot");
            }
        }

        private double fourthDot;
        public double FourthDot
        {
            get { return fourthDot; }
            set
            {
                FifthDot = fourthDot;
                fourthDot = value;
                OnPropertyChanged("FourthDot");
            }
        }

        private double fifthDot;
        public double FifthDot
        {
            get { return fifthDot; }
            set
            {
                fifthDot = value;
                OnPropertyChanged("FifthDot");
            }
        }


        private double firstValue;
        public double FirstValue
        {
            get { return firstValue; }
            set
            {
                SecondValue = firstValue;
                firstValue = value;
                OnPropertyChanged("FirstValue");
            }
        }

        private double secondValue;
        public double SecondValue
        {
            get { return secondValue; }
            set
            {
                ThirdValue = secondValue;
                secondValue = value;
                OnPropertyChanged("SecondValue");
            }
        }

        private double thirdValue;
        public double ThirdValue
        {
            get { return thirdValue; }
            set
            {
                FourthValue = thirdValue;
                thirdValue = value;
                OnPropertyChanged("ThirdValue");
            }
        }

        private double fourthValue;
        public double FourthValue
        {
            get { return fourthValue; }
            set
            {
                FifthValue = fourthValue;
                fourthValue = value;
                OnPropertyChanged("FourthValue");
            }
        }

        private double fifthValue;
        public double FifthValue
        {
            get { return fifthValue; }
            set
            {
                fifthValue = value;
                OnPropertyChanged("FifthValue");
            }
        }

        private double maxValue;
        public double MaxValue
        {
            get { return maxValue; }
            set
            {
                maxValue = value;
                OnPropertyChanged("MaxValue");
            }
        }

        //Vremena koja se ispisuju ispod krugova u chart-u

        private string firstTime;

        public string FirstTime
        {
            get { return firstTime; }
            set
            {
                SecondTime = firstTime;
                firstTime = value;
                OnPropertyChanged("FirstTime");
            }
        }

        private string secondTime;

        public string SecondTime
        {
            get { return secondTime; }
            set
            {

                ThirdTime = secondTime;
                secondTime = value;
                OnPropertyChanged("SecondTime");
            }
        }

        private string thirdTime;

        public string ThirdTime
        {
            get { return thirdTime; }
            set
            {

                FourthTime = thirdTime;
                thirdTime = value;
                OnPropertyChanged("ThirdTime");
            }
        }

        private string fourthTime;

        public string FourthTime
        {
            get { return fourthTime; }
            set
            {

                FifthTime = fourthTime;
                fourthTime = value;
                OnPropertyChanged("FourthTime");
            }
        }

        private string fifthTime;

        public string FifthTime
        {
            get { return fifthTime; }
            set
            {
                fifthTime = value;
                OnPropertyChanged("FifthTime");
            }
        }

    }
}
