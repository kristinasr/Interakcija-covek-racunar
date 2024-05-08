using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NetworkService.Model
{
    /// <summary>
    /// Glavna baza svih generatora koji se naprave tokom koriscenja aplikacije
    /// kod postavlja inicijalne vrednosti za Termometers kolekciju(kolekcija termometara) i CanvasObjects rečnik(mapiranje objekata na kanvasu).
    /// </summary>

    public static class DataBase
    {
        public static ObservableCollection<Termometer> Termometers { get; set; } = new ObservableCollection<Termometer>();

        public static ObservableCollection<TypeTermometer> TermometersTypesList { get; set; } = new ObservableCollection<TypeTermometer>()
        {

            
			new TypeTermometer("RTD", "pack://application:,,,/Slike/RTD.jpg"),
            new TypeTermometer("TermoSprega", "pack://application:,,,/Slike/TermoSprega.jpg")
        };

        

       
        public static Dictionary<string, Termometer> CanvasObjects { get; set; } = new Dictionary<string, Termometer>();

        static DataBase()
        {
           
            Termometers = new ObservableCollection<Termometer>()
            {
                
                new Termometer(1, "Termometer_1", TermometersTypesList[0]),
                new Termometer(2, "Termometer_2", TermometersTypesList[1])
            };

            // SacuvaniTermometer.Add(Termometers);
        }
    }
}
