using NetworkService.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace NetworkService.ViewModel
{
    public class MainWindowViewModel : BindableBase
    {
        private int index;
        private double value;
        private bool file = false;
        private string path;

        public MyICommand<string> NavCommand { get; private set; }
       
        private NetworkDataViewModel networkDataViewModel = new NetworkDataViewModel();

        private DragAndDropViewModel dragAndDropViewModel = new DragAndDropViewModel(new Views.DragAndDropView());
        private ChartDataViewModel chartDataViewModel = new ChartDataViewModel();
        private BindableBase currentViewModel;

        public MyICommand CloseCommand { get; set; }

        public MyICommand<string> AddShortcutCommand { get; private set; }
        public MyICommand DeleteShortcutCommand { get; private set; }
        public MyICommand UndoShortcutCommand { get; private set; }

        public MyICommand NistaCommand { get; set; }

        public MainWindowViewModel() 
        {
            path = Environment.CurrentDirectory + @"\Log.txt"; 

            NavCommand = new MyICommand<string>(OnNav); 
            AddShortcutCommand = new MyICommand<string>(AddShortcut);
            DeleteShortcutCommand = new MyICommand(DeleteShortcut);
            UndoShortcutCommand = new MyICommand(UndoShortcut);
            CurrentViewModel = networkDataViewModel; 
            CloseCommand = new MyICommand(OnClose);

            createListener(); 
            
        }

       
        public BindableBase CurrentViewModel 
        {
            get { return currentViewModel; }
            set
            {
                SetProperty(ref currentViewModel, value); 
            }
        }

        
        /// <param name="destination">first za RTD tip, second za Termo spregu</param>

        private void AddShortcut(string destination)
        {
            switch (destination)
            {
                case "first":
                    networkDataViewModel.AddShortcut("first");
                    break;
                case "second":
                    networkDataViewModel.AddShortcut("second");
                    break;
            }
            RefreshViewModel("networkData"); 
        }

     

        private void DeleteShortcut() 
        {
            if(!networkDataViewModel.DeleteShortcut())
                return;
            RefreshViewModel("networkData");
        }

       

        private void UndoShortcut()
        {
            if (!networkDataViewModel.UndoShortcut())
                return ;
            RefreshViewModel("networkData");
        }

     
        /// <param name="destination"></param>

        public void RefreshViewModel(string destination) //za radiobutton
        {
            networkDataViewModel = new NetworkDataViewModel();
            dragAndDropViewModel = new DragAndDropViewModel(new Views.DragAndDropView());
            chartDataViewModel = new ChartDataViewModel();

            CurrentViewModel = new BindableBase(); 

            Task.Delay(250).ContinueWith(_ => 
            {
                Application.Current.Dispatcher.Invoke(() => 
                {
                    switch (destination) 
                    {
                        case "networkData": 
                            CurrentViewModel = networkDataViewModel;
                            break;
                        case "dragAndDrop":
                            CurrentViewModel = dragAndDropViewModel;
                            break;
                        case "chartView":
                            CurrentViewModel = chartDataViewModel;
                            break;
                    }
                });
                
            });

            
        }

     
        /// <param name="destination"></param>

        private void OnNav(string destination)
        {
            switch (destination)
            {
                case "networkData":
                    CurrentViewModel = new BindableBase();
                    break;
                case "dragAndDrop":
                    CurrentViewModel = new BindableBase();
                    break;
                case "chartView":
                    CurrentViewModel = new BindableBase();
                    break;
            }
            RefreshViewModel(destination);
        }

        private void OnClose()
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to exit?", "Confirm closing application.",
                                         MessageBoxButton.YesNo,
                                         MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Application.Current.MainWindow.Close();
            }
        }


        private void createListener()
        {
            var tcp = new TcpListener(IPAddress.Any, 25565);
            tcp.Start();

            var listeningThread = new Thread(() =>
            {
                while (true)
                {
                    var tcpClient = tcp.AcceptTcpClient();
                    ThreadPool.QueueUserWorkItem(param =>
                    {
                        //Prijem poruke
                        NetworkStream stream = tcpClient.GetStream();
                        string incomming;
                        byte[] bytes = new byte[1024];
                        int i = stream.Read(bytes, 0, bytes.Length);
                        
                        incomming = System.Text.Encoding.ASCII.GetString(bytes, 0, i);

                        //objekata ima u sistemu
                        if (incomming.Equals("Need object count"))
                        {
                            
                            Byte[] data = System.Text.Encoding.ASCII.GetBytes(DataBase.Termometers.Count.ToString());
                            stream.Write(data, 0, data.Length);
                        }
                        else
                        {
                            
                            Console.WriteLine(incomming); //"Entitet_1:272"

                            
                            
                            // Azuriranje potrebnih stvari u aplikaciji

                            string[] split = incomming.Split('_', ':');
                            index = Int32.Parse(split[1]);
                            value = Double.Parse(split[2]);

                            try
                            {
                                DataBase.Termometers[index].Vrednost = value;
                               
                                Upis();
                            }
                            catch
                            {
                                
                            }
                        }
                    }, null);
                }
            });

            listeningThread.IsBackground = true;
            listeningThread.Start();
        }

       

        private void Upis()
        {
            if (!file) 
            {
                StreamWriter writer;
                using (writer = new StreamWriter(path)) 
                {
                    writer.WriteLine("Date Time:\t" + DateTime.Now.ToString() + "\tObject_" + index + "\tValue:\t" + value);
                }
                file = true; 
            }
            else 
            {
                StreamWriter writer;
                using (writer = new StreamWriter(path, true)) 
                {
                    writer.WriteLine("Date Time:\t" + DateTime.Now.ToString() + "\tObject_" + index + "\tValue:\t" + value);

                }
            }
            file = true;
        }
    }
}
