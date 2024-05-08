using NetworkService.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static NetworkService.Model.Termometer;
using static NetworkService.Model.DataBase;
using System.ComponentModel;
using System.Threading;
using System.Windows.Input;
using NetworkService.Helpers;

namespace NetworkService.ViewModel
{
    public class NetworkDataViewModel : ValidationBase
    {
        public MyICommand AddCommand { get; set; }
        public MyICommand DeleteCommand { get; set; }

        public MyICommand FilterCommand { get; set; }

        public MyICommand ResetCommand { get; set; }

        public MyICommand SaveFilterCommand { get; set; }
        public MyICommand LoadFilterCommand { get; set; }

        public MyICommand UserControlLoadedCommand { get; }

        public MyICommand<string> AddShortcutCommand { get; private set; }

        public static ObservableCollection<Termometer> TermometerFilter { get; private set; } = new ObservableCollection<Termometer>();

        private string pathFirst = "pack://application:,,,/Slike/RTD.jpg";
        private string pathSecond = "pack://application:,,,/Slike/TermoSprega.jpg";

        public NetworkDataViewModel()
        {
            NameValid = GetDefaultName(); 
            IdValid = GetNextId().ToString();

            PathValid = "pack://application:,,,/Slike/transparent.jpg";
            ValueName = true;
            NameOrType = 0;

            
            AddCommand = new MyICommand(OnAdd);
            DeleteCommand = new MyICommand(OnDelete, CanDelete);

         
            foreach (var generator in DataBase.Termometers)
            {
                Termometers.Add(generator);
            }

            FilterCommand = new MyICommand(FilterNew);
            ResetCommand = new MyICommand(Reset);
            AddShortcutCommand = new MyICommand<string>(AddShortcut);

            ValidValuesOnlyChecker();
        }


        private bool validValuesOnly = false;

        public bool ValidValuesOnly
        {
            get { return validValuesOnly; }
            set
            {
                if (validValuesOnly != value)
                {
                    validValuesOnly = value;
                    OnPropertyChanged("ValidValuesOnly");
                }
            }
        }

        private static bool resetedValidValues = true;

      

        private void ValidValuesOnlyChecker()
        {
            Task.Delay(300).ContinueWith(_ =>
            {          
                if (validValuesOnly)
                {
                    List<Termometer> TempTermometers = new List<Termometer>();


                 
                    if (TermometerFilter.Count() != 0)
                    {
                        foreach (var item in TermometerFilter)
                        {
                            if (item.Vrednost >= 250 && item.Vrednost <= 350)
                            {
                                TempTermometers.Add(item);
                            }
                        }
                    }
                    else { 
                        foreach (var item in DataBase.Termometers)
                        {
                            if (item.Vrednost >= 250 && item.Vrednost <= 350)
                            {
                                TempTermometers.Add(item);
                            }
                        }
                    }


                    Application.Current.Dispatcher.Invoke(() => 
                    {
                        Termometers.Clear();
                        foreach (var item in TempTermometers)
                        {
                            Termometers.Add(item);
                        }
                    });
                    OnPropertyChanged(nameof(Termometers));
                    resetedValidValues = false;
                }
                else
                {
                    if (!resetedValidValues)
                    {
                        Application.Current.Dispatcher.Invoke(() => 
                        {
                            Termometers.Clear(); 
                            if (TermometerFilter.Count() != 0)
                            {
                                foreach (var item in TermometerFilter)
                                {
                                    Termometers.Add(item);
                                }
                            }
                            else
                            {
                                foreach (var item in DataBase.Termometers)
                                {
                                    Termometers.Add(item);
                                }
                            }
                            resetedValidValues = true;
                        });
                        
                    }
                }

                ValidValuesOnlyChecker();
            });
        }

        
        /// <param name="destination"></param>

        public void AddShortcut(string destination)
        {
            switch (destination)
            {
                case "first":
                    OnAddShortcut("RTD");
                    break;
                case "second":
                    OnAddShortcut("Termo Sprega");
                    break;
            }
        }
        
        private void OnAddShortcut(string type) 
        {
            TypeTermometer tempType;
            if (type == "RTD")
            {
                tempType = DataBase.TermometersTypesList.First(tm => tm.NazivTipa == "RTD");
            }
            else
            {
                tempType = DataBase.TermometersTypesList.First(tm => tm.NazivTipa == "TermoSprega");
            }

            IdValid = GetNextId().ToString();
            int IDSS = int.Parse(IdValid);

            var termometer = new Termometer()
            {
                ID = IDSS,
                Naziv = NameValid,
                Tip = tempType,
                Vrednost = 0
            };

            

            var addCommand = new AddTermometerCommand(termometer, Termometers, DataBase.Termometers);
            addCommand.Execute();  
            commandHistory.Push(addCommand); 

            IdValid = GetNextId().ToString();
            Reset();

            OnPropertyChanged(nameof(Termometers)); 
        }

        public static Termometer currentlySelectedTermomete = null;


        public bool DeleteShortcut()
        {
            if (currentlySelectedTermomete == null)
                return false;
           
            var deleteCommand = new DeleteTermometerCommand(currentlySelectedTermomete, Termometers, DataBase.Termometers);
            deleteCommand.Execute(); 
            commandHistory.Push(deleteCommand); 

            Reset();
            OnPropertyChanged(nameof(Termometers));
            currentlySelectedTermomete = null; 
            return true;
        }

       

        private static Stack<Helpers.ICommand> commandHistory = new Stack<Helpers.ICommand>();

        

        public bool UndoShortcut()
        {
            if (commandHistory.Count > 0) 
            {
                
                Helpers.ICommand latestCommand = commandHistory.Pop();
                latestCommand.UnExecute(); 

                OnPropertyChanged(nameof(Termometers));
                return true;
            }
           
            return false;
        }

        public static List<string> TipoviComboBox { get; set; } = new List<string> { "RTD", "TermoSprega" };

        /// <summary>
        /// Resetuje izabrane filtere i tabelu
        /// </summary>

        private void Reset()
        {
            
            FilterText = "";
            SelectedFilterTip = null; 
            Lower = true;
            Higher = false;
            Equal = false;

            Termometers.Clear();
            foreach (var item in DataBase.Termometers) 
            {
                Console.WriteLine(item.ID);
                Termometers.Add(item);
            }

            TermometerFilter.Clear(); 

            OnPropertyChanged(nameof(Termometers));
        }


        /// <summary>
        /// Na osnovu izabranih parametara za filtraciju prikazuje Termometere koji ih ispunjavaju
        /// </summary>

        private void FilterNew()
        { 
            
            if (string.IsNullOrEmpty(FilterText) && (string.IsNullOrEmpty(SelectedFilterTip) || SelectedFilterTip == null))
            {
                Termometers.Clear();
                foreach (var item in DataBase.Termometers)
                {
                    Termometers.Add(item);
                }
                return;
            }

            TermometerFilter.Clear();
            
            if (FilterText != null && FilterText != "")   
            {
                
                if (Lower)  
                {

                    for (int i = 0; i < DataBase.Termometers.Count; i++)   
                    {
                        if (DataBase.Termometers[i].ID < Convert.ToInt32(FilterText)) //broj koji unosimo
                        {
                            TermometerFilter.Add(DataBase.Termometers[i]);   
                        }

                    }
                }
                else if (Equal){ 

                    for(int i = 0; i < DataBase.Termometers.Count; i++)
                    {
                        if(DataBase.Termometers[i].ID == Convert.ToInt32(FilterText))
                        {
                            TermometerFilter.Add(DataBase.Termometers[i]);
                        }
                    }
                }
                else 
                {

                    for (int i = 0; i < DataBase.Termometers.Count; i++)
                    {
                        if (DataBase.Termometers[i].ID > Convert.ToInt32(FilterText))
                        {
                            TermometerFilter.Add(DataBase.Termometers[i]);
                        }

                    }
                }

                if (SelectedFilterTip != "" && SelectedFilterTip != null) 
                {
                    foreach (var r in TermometerFilter.ToList()) 
                    {
                        if (SelectedFilterTip != r.Tip.NazivTipa) 
                        {
                            TermometerFilter.Remove(r);
                        }
                    }

                }


            }
            else  
            {
                if (SelectedFilterTip != null)
                {
                   
                    for (int i = 0; i < DataBase.Termometers.Count; i++)
                    {
                        if (SelectedFilterTip == DataBase.Termometers[i].Tip.NazivTipa)
                            TermometerFilter.Add(DataBase.Termometers[i]);
                    }
                }
            }

            Termometers.Clear();
            foreach (var r in TermometerFilter.ToList())
            {
                
                Termometers.Add(r);
            }

            foreach (var item in Termometers)
            {
                Console.WriteLine("naziv: " + item.Naziv);
                Console.WriteLine("Id: " + item.ID);
            }

            OnPropertyChanged(nameof(Termometers));
        }

        private static bool lower = true;
        private static bool higher = false;
        private static bool equal = false;

        public bool Lower
        {
            get { return lower; }
            set
            {
                if (lower != value)
                {
                    lower = value;
                    OnPropertyChanged("Lower");
                }
            }
        }
        public bool Higher
        {
            get { return higher; }
            set
            {
                if (higher != value)
                {
                    higher = value;
                    OnPropertyChanged("Higher");
                }
            }
        }

        public bool Equal
        {
            get { return equal; }
            set
            {
                if (equal != value)
                {
                    equal = value;
                    OnPropertyChanged("Equal");
                }
            }
        }

        private string filterText;
        public string FilterText   
        {
            get { return filterText; }
            set
            {
                if (filterText != value)
                {
                    filterText = value;
                    OnPropertyChanged("FilterText");
                }
            }
        }

        private string selectedFilterTip = string.Empty;

        public string SelectedFilterTip   
        {
            get { return selectedFilterTip; }
            set
            {
                if (selectedFilterTip != value)
                {
                    selectedFilterTip = value;


                    OnPropertyChanged("SelectedFilterTip");
                }
            }
        }

        private string selectedSavedFilter = string.Empty;

        public string SelectedSavedFilter    
        {
            get { return selectedSavedFilter; }
            set
            {
                if (selectedSavedFilter != value)
                {
                    selectedSavedFilter = value;


                    OnPropertyChanged("SelectedSavedFilter");
                }
            }
        }


        #region Termometer Propeties


        private string idValid;
        public string IdValid
        {
            get { return idValid; }
            set
            {
                if (idValid != value)
                {
                    idValid = value;
                    OnPropertyChanged("IdValid");
                    UpdateNameIfDefault();
                }
            }
        }

        private string nameValid;
        public string NameValid
        {
            get { return nameValid; }
            set
            {
                if (nameValid != value)
                {
                    nameValid = value;
                    OnPropertyChanged("NameValid");
                }
            }
        }


        private string tipValid;
        public string TipValid
        {
            get { return tipValid; }
            set
            {
                if (tipValid != value)
                {
                    tipValid = value;
                    OnPropertyChanged("TipValid");

                    if (value == "RTD")
                        PathValid = pathFirst;
                    else
                        PathValid = pathSecond;

                    OnPropertyChanged("PathValid");

                }
            }
        }

        private string pathValid;
        public string PathValid
        {
            get { return pathValid; }
            set
            {
                if (pathValid != value)
                {
                    pathValid = value;
                    OnPropertyChanged("PathValid");
                }
            }
        }

        #endregion


        #region Selected Termometer

        private Termometer selectedTermometer;

        public Termometer SelectedTermometer
        {
            get { return selectedTermometer; }
            set
            {
                selectedTermometer = value;
                DeleteCommand.RaiseCanExecuteChanged();
            }
        }

        #endregion


        #region List of Termometers

        private ObservableCollection<Termometer> termometers = new ObservableCollection<Termometer>();

        public ObservableCollection<Termometer> Termometers
        {
            get { return termometers; }
            set
            {
                termometers = value;
                OnPropertyChanged(nameof(Termometers));
            }
        }


        #endregion


        #region Add

        /// <summary>
        /// Dodavanje novog generatora u listu generatora
        /// </summary>

        private void OnAdd()
        {
            Validate();

            if (IsValid) 
            {
                int IDSS = int.Parse(IdValid);

                var termometer = new Termometer()
                {
                    ID = IDSS,
                    Naziv = NameValid,
                    Tip = DataBase.TermometersTypesList.First(mt => mt.NazivTipa == TipValid),
                    Vrednost = 0
                };

                var addCommand = new AddTermometerCommand(termometer, Termometers, DataBase.Termometers);
                addCommand.Execute();
                commandHistory.Push(addCommand);

                IdValid = GetNextId().ToString();
                Reset();

                OnPropertyChanged(nameof(Termometers));
            }
        }

        #endregion


        #region Delete

        /// <summary>
        /// Brise izabrani generator iz liste
        /// </summary>

        private bool CanDelete()
        {
            currentlySelectedTermomete = SelectedTermometer;
            return SelectedTermometer != null;
        }

        private void OnDelete() 
        {
            var deleteCommand = new DeleteTermometerCommand(SelectedTermometer, Termometers, DataBase.Termometers);
            deleteCommand.Execute();
            commandHistory.Push(deleteCommand);

            Reset();
            OnPropertyChanged(nameof(Termometers));
        }

        #endregion


        #region Validation

       

        protected override void ValidateSelf()
        {
            int IDS = 0;
            int.TryParse(IdValid, out IDS);

            if (string.IsNullOrWhiteSpace(NameValid))
            {
                this.ValidationErrors["Naziv"] = "Unesite naziv"; 
            }

            if (string.IsNullOrWhiteSpace(IdValid))
            {
                this.ValidationErrors["ID"] = "Unesite ID";
            }
            else if (!int.TryParse(IdValid, out IDS))
            {
                this.ValidationErrors["ID"] = "Mora biti broj";
            }
            else if (DataBase.Termometers.FirstOrDefault(tp => tp.ID == IDS) != default)
            {
                this.ValidationErrors["ID"] = "ID vec postoji";
            }
            else if (IDS < 1)
            {
                this.ValidationErrors["ID"] = "Mora biti > 0";
            }

            if (TipValid == "System.Windows.Controls.ComboBoxItem: select" || TipValid == null)
            {
                this.ValidationErrors["Tip"] = "Izaberite tip";
            }
        }

        #endregion


        #region Filter Properties

        private string searchValueText;
        public string SearchValueText
        {
            get { return searchValueText; }
            set
            {
                searchValueText = value;
                OnPropertyChanged("SearchValueText");
                FilterCommand.RaiseCanExecuteChanged();
            }
        }

        private int nameOrType;
        public int NameOrType
        {
            get { return nameOrType; }
            set
            {
                nameOrType = value;
            }
        }

        private string nameButtonSearch = "Search";
        public string NameButtonSearch
        {
            get { return nameButtonSearch; }
            set
            {
                nameButtonSearch = value;
                OnPropertyChanged("NameButtonSearch");
            }
        }

        private bool valueName;
        public bool ValueName
        {
            get { return valueName; }
            set
            {
                valueName = value;
                OnPropertyChanged("ValueName");
            }
        }

        private bool valueType;
        public bool ValueType
        {
            get { return valueType; }
            set
            {
                valueType = value;
                OnPropertyChanged("ValueType");
            }
        }

        #endregion

        

        #region Update Name or ID

        #region NextID

        public static int GetNextId()
        {
            int nextId = 1;

            while (DataBase.Termometers.FirstOrDefault(gr => gr.ID == nextId) != default)
            {
                nextId++;
            }

            return nextId;
        }

        #endregion


        #region UpdateName

        private void UpdateNameIfDefault()
        {
            if (NameValid != null)
            {
                if (NameValid.Contains("Termometer_"))
                {
                    NameValid = GetDefaultName(); 
                }
            }
        }

        #endregion


        #region DefaultName
        private string GetDefaultName()
        {
            return $"Termometer_{IdValid}";
        }
        #endregion

        #endregion



    }
}
