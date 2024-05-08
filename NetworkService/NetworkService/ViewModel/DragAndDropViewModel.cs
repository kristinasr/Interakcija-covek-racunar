using NetworkService.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace NetworkService.ViewModel
{
    public class DragAndDropViewModel : BindableBase
    {
        private ListView listViewTermometer;
        public BindingList<Termometer> Items { get; set; }

        public MyICommand<ListView> MLBUCommand { get; set; }
        public MyICommand<Termometer> SCCommand { get; set; }
        public MyICommand<Canvas> DCommand { get; set; }
        public MyICommand<Canvas> FreeCommand { get; set; }
        public MyICommand<Canvas> LCommand { get; set; }
        public MyICommand<Canvas> SCommand { get; set; }
        public MyICommand<ListView> LLWCommand { get; set; }
        public List<Canvas> filledCanvases = new List<Canvas>();
        public static Termometer draggedItem = null;
        private Grid _gridName;
        private bool dragging = false;
        private static bool exists = false;
        private int selectedIndex = 0;
        public ObservableCollection<LineModel> Lines { get; set; }

        Dictionary<int, Termometer> temp = new Dictionary<int, Termometer>();

        private Canvas uzetCanvas;
        private bool izListe = false;
        public static Dictionary<int, Termometer> ubaceniUMrezu = new Dictionary<int, Termometer>();
        private Grid _mainCanvas;

        
        public Grid MainCanvas
        {
            get { return _mainCanvas; }
            set
            {
                if (_mainCanvas != value)
                {
                    _mainCanvas = value;
                    OnPropertyChanged(nameof(MainCanvas));
                }
            }
        }

        public UserControl CurrentUserControl { get; set; }
        public MyICommand FillOutCommand { get; set; }

        public int SelectedIndex    
        {
            get { return selectedIndex; }
            set
            {
                selectedIndex = value;
                OnPropertyChanged("SelectedIndex");
            }
        }

        
        
        
        /// <param name="userControl"></param>

        public DragAndDropViewModel(UserControl userControl)       
        {
            Lines = new ObservableCollection<LineModel>();
            CurrentUserControl = userControl;
            foreach (Termometer reaktor in DataBase.Termometers)
            {

                temp.Add(reaktor.ID, reaktor);
              
            }

            Items = new BindingList<Termometer>();

            foreach (Termometer reaktor1 in DataBase.Termometers)
            {
                exists = false;
                foreach (Termometer reaktor2 in DataBase.CanvasObjects.Values)
                {
                    if (reaktor2.ID == reaktor1.ID)
                    {
                        exists = true;
                        break;
                    }
                }

                if (exists == false)
                    Items.Add(new Termometer(reaktor1));
            }

           
            MLBUCommand = new MyICommand<ListView>(Pusti);
            SCCommand = new MyICommand<Termometer>(Prevuci);
            DCommand = new MyICommand<Canvas>(Zauzmi);
            FreeCommand = new MyICommand<Canvas>(Oslobodi);
            LCommand = new MyICommand<Canvas>(OnLoad);
            SCommand = new MyICommand<Canvas>(UzmiCanvas);
            LLWCommand = new MyICommand<ListView>(OnLLW);
        }

        #region Prevlacenje iz canvasa u canvas

        /// <summary>
        /// Implementira SCommand koja uzima kanvas ispod misa kad klikne
        /// </summary>
        /// <param name="canvas">Kliknut kanvas</param>


        private void UzmiCanvas(Canvas canvas)
        {
      
            if (canvas.Resources["taken"] != null)
            {
                draggedItem = DataBase.CanvasObjects[canvas.Name];

                if (!dragging)
                {
                    izListe = false;
                    dragging = true;
                    uzetCanvas = canvas;
                    DragDrop.DoDragDrop(canvas, draggedItem, DragDropEffects.Copy | DragDropEffects.Move);

                    canvas.Resources.Remove("taken");
                    filledCanvases.Remove(canvas);

                    ConnectCanvasesWithOneLine(filledCanvases);
                }
            }
        }

       

        private void IzbrisiStariCanvas()
        {
            uzetCanvas.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#ccc7b9");
            DataBase.CanvasObjects.Remove(uzetCanvas.Name);
            uzetCanvas.Resources.Remove("taken");
            uzetCanvas = null;
        }

        #endregion


        /// <summary>
        /// Ucitavaju se svi reaktori u listu 
        /// </summary>
        /// <param name="listview"></param>

        public void OnLLW(ListView listview)
        {
            listViewTermometer = listview;
        }


        #region Ucitaj promene na kanvasu

        /// <summary>
        /// Kad se udje na view DragAndDropView da se ucitaju kanvasi koji su zauzeti
        /// </summary>
        /// <param name="c"></param>

        public void OnLoad(Canvas c)
        {
            if (DataBase.CanvasObjects.ContainsKey(c.Name)) 
            {
                BitmapImage logo = new BitmapImage();
                logo.BeginInit();
                logo.UriSource = new Uri(DataBase.CanvasObjects[c.Name].Tip.SlikaTipa); 
                logo.EndInit(); 
                c.Background = new ImageBrush(logo);
                if (!c.Resources.Contains("taken")) 
                {
                   
                    c.Resources.Add("taken", true);
                    filledCanvases.Add(c);
                    ConnectCanvasesWithOneLine(filledCanvases); 
                }
                ProveriVrednost(c);
            }
        }

        #endregion


        #region Oslobodi canvas

        /// <summary>
        /// Kada se pritisne dugme oslobodi da se izbaci zauzeti kanvas i vrati u listu
        /// </summary>
        /// <param name="canvas"></param>

        public void Oslobodi(Canvas canvas)
        {
            try
            {
                if (canvas.Resources["taken"] != null) 
                {
                    
                    canvas.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#ccc7b9")); ;
                  
                    ((Border)canvas.Children[0]).BorderBrush = Brushes.Transparent;

               
                    foreach (Termometer generator in DataBase.Termometers)
                    {
                        
                        if (!Items.Contains(generator) && DataBase.CanvasObjects[canvas.Name].ID == generator.ID)
                        {
                            Items.Add(new Termometer(generator));
                        }
                    }
                    canvas.Resources.Remove("taken"); 
                    filledCanvases.Remove(canvas); 
                    DataBase.CanvasObjects.Remove(canvas.Name);   
                    ConnectCanvasesWithOneLine(filledCanvases);
                }
            }
            catch (Exception) { }
        }

        #endregion


        #region Zauzmi canvas

        /// <summary>
        /// Izvrsava se kada se iz liste prevuce na kanvas da se zauzme
        /// </summary>
        /// <param name="canvas"></param>

        public void Zauzmi(Canvas canvas)
        {

            if (draggedItem != null) 
            { 
                if (canvas.Resources["taken"] == null) 
                { 
                    BitmapImage logo = new BitmapImage();
                    logo.BeginInit();
                    logo.UriSource = new Uri(draggedItem.Tip.SlikaTipa); 
                    logo.EndInit();
                    canvas.Background = new ImageBrush(logo); 
                    //DataBase.CanvasObjects[canvas.Name] = draggedItem;
                    canvas.Resources.Add("taken", true); 

                    filledCanvases.Add(canvas); 
                    Grid grid = (Grid)CurrentUserControl.FindName("MainCanvas"); 


                    if (izListe)
                        Items.Remove(Items.Single(x => x.ID == draggedItem.ID)); 

                    if (izListe)
                    {
                        DataBase.CanvasObjects[canvas.Name] = draggedItem; 
                        izListe = false;
                    }
                    else
                    {
                        DataBase.CanvasObjects[canvas.Name] = draggedItem;
                        IzbrisiStariCanvas();
                    }

                    SelectedIndex = 0;
                    ProveriVrednost(canvas); 

                    ConnectCanvasesWithOneLine(filledCanvases);
                }
                dragging = false;
            }
        }

        #endregion


        #region Pusti klik

        /// <summary>
        /// Kada se pusti klik na kanvas
        /// </summary>
        /// <param name="lw"></param>

        public void Pusti(ListView lw)
        {
            draggedItem = null;
            lw.SelectedItem = null;
            dragging = false;
        }

        #endregion


        #region Prevuci objekat

        
        /// <param name="generator"></param>

        public void Prevuci(Termometer generator)
        {
            if (!dragging) 
            {
                dragging = true;
                izListe = true;
                draggedItem = new Termometer(generator);
                DragDrop.DoDragDrop(listViewTermometer, draggedItem, DragDropEffects.Move);
            }
        }

        #endregion


        #region Proveri vrednost reaktora

        
        /// <param name="canvas"></param>
        //vr sa simulatora
        private void ProveriVrednost(Canvas canvas) 
        {
            foreach (Termometer generator in DataBase.Termometers)
            {
                temp[generator.ID] = generator; 
            }

            Task.Delay(2000).ContinueWith(_ =>
            {
                Application.Current.Dispatcher.Invoke(() => 
                {
                   
                    if (DataBase.CanvasObjects.Count != 0)
                    {
                       
                        if (DataBase.CanvasObjects.ContainsKey(canvas.Name))
                        {
                            bool ret = false;
                            foreach (var item in DataBase.Termometers)
                            {
                                if (item.ID == temp[DataBase.CanvasObjects[canvas.Name].ID].ID)
                                    ret = true;
                            }
                           
                            if (!ret)
                                DataBase.CanvasObjects.Remove(canvas.Name); 
                            else if (temp[DataBase.CanvasObjects[canvas.Name].ID].Vrednost < 250 || temp[DataBase.CanvasObjects[canvas.Name].ID].Vrednost > 350) 
                            {
                                ((Border)(canvas).Children[0]).BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#ccc7b9"));
                                ((Border)(canvas).Children[0]).BorderThickness = new Thickness(100);
                                if (((Border)(canvas).Children[0]).BorderBrush.IsFrozen) 
                                {
                                    ((Border)(canvas).Children[0]).BorderBrush = ((Border)(canvas).Children[0]).BorderBrush.Clone(); 
                                }
                                ((Border)(canvas).Children[0]).BorderBrush.Opacity = 0.5;
                            }
                            else
                                ((Border)(canvas).Children[0]).BorderBrush = Brushes.Transparent;
                        }
                        else
                            ((Border)(canvas).Children[0]).BorderBrush = Brushes.Transparent;
                    }
                });
                ProveriVrednost(canvas); 
            });
        }

        /// <summary>
        /// Svaki kanvas koji je zauzet da se poveze linijom
        /// </summary>
        /// <param name="canvases"></param>


        private void ConnectCanvasesWithOneLine(List<Canvas> canvases)
        {
            Grid grid = (Grid)CurrentUserControl.FindName("MainGrid");

           
            var existingLines = grid.Children.OfType<Line>().ToList();
            foreach (var line in existingLines)
            {
                grid.Children.Remove(line);
            }

            
            for (int i = 0; i < canvases.Count - 1; i++)
            {
                Canvas canvas1 = canvases[i];
                Canvas canvas2 = canvases[i + 1];

                // Get the positions of the canvases within the Grid
                Point canvas1Pos = canvas1.TransformToAncestor(grid).Transform(new Point(0, 0));
                Point canvas2Pos = canvas2.TransformToAncestor(grid).Transform(new Point(0, 0));

                // Calculate the center points of the canvases
                Point canvas1Center = new Point(canvas1Pos.X + canvas1.ActualWidth / 2, canvas1Pos.Y + canvas1.ActualHeight / 2);
                Point canvas2Center = new Point(canvas2Pos.X + canvas2.ActualWidth / 2, canvas2Pos.Y + canvas2.ActualHeight / 2);

                
                Line line = new Line
                {
                    X1 = canvas1Center.X,
                    Y1 = canvas1Center.Y,
                    X2 = canvas2Center.X,
                    Y2 = canvas2Center.Y,
                    Stroke = (SolidColorBrush)(new BrushConverter().ConvertFrom("#af7a6d")),
                    StrokeThickness = 2,
                    IsHitTestVisible = false
                };
                
                
                grid.Children.Add(line);
            }
        }

        #endregion
    }

       
}
