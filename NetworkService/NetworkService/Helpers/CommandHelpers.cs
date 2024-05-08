using NetworkService.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace NetworkService.Helpers
{
   

    
    public interface ICommand 
    {
        void Execute(); 
        void UnExecute();
    }

    public class AddTermometerCommand : ICommand
    {
        private Termometer termometer; 
        private ObservableCollection<Termometer> termometers; 
        private ObservableCollection<Termometer> database; 

        public AddTermometerCommand(Termometer termometer, ObservableCollection<Termometer> termometers, ObservableCollection<Termometer> database)
        {
            this.termometer = termometer;
            this.termometers = termometers;
            this.database = database;
        }

        public void Execute()
        {
            database.Add(termometer);
            termometers.Add(termometer);
        }

        public void UnExecute()
        {
            database.Remove(termometer);
            termometers.Remove(termometer);
        }
    }

    public class DeleteTermometerCommand : ICommand
    {
        private Termometer termometer;
        private ObservableCollection<Termometer> termometers;
        private ObservableCollection<Termometer> database;

        public DeleteTermometerCommand(Termometer termometer, ObservableCollection<Termometer> termometers, ObservableCollection<Termometer> database)
        {
            this.termometer = termometer;
            this.termometers = termometers;
            this.database = database;
        }

        public void Execute()
        {
            database.Remove(termometer);
            termometers.Remove(termometer);
        }

        public void UnExecute()
        {
            database.Add(termometer);
            termometers.Add(termometer);
        }
    }
}
