using NetworkService.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkService.Model
{
    public class Termometer : BindableBase
    {
        #region Properties
        private int id;
        public int ID
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("ID");
            }
        }


        private string naziv;
        public string Naziv
        {
            get { return naziv; }
            set
            {
                naziv = value;
                OnPropertyChanged("Naziv");
            }
        }

        private TypeTermometer tip;
        public TypeTermometer Tip
        {
            get { return tip; }
            set
            {
                tip = value;
                OnPropertyChanged("Tip");
            }
        }

        private double vrednost;
        public double Vrednost
        {
            get { return vrednost; }
            set 
            {
                vrednost = value;
                ChartDataViewModel.SetFirstDotAndValue(value, naziv); 
                OnPropertyChanged("Vrednost"); 
            }
        }

        #endregion


        #region Constructors

        public Termometer() { }

        public Termometer(int id, string naziv, TypeTermometer tip)
        {
            this.ID = id;
            this.Naziv = naziv;
            this.Tip = tip;
            Vrednost = 0;
        }

        public Termometer(Termometer g)
        {
            g = g ?? new Termometer(); 
                                     
            this.ID = g.ID;
            this.Naziv = g.Naziv;
            this.Tip = g.Tip;
            //this.Tip.NazivTipa = g.tip.NazivTipa;
            //this.Tip.SlikaTipa = g.tip.SlikaTipa;
            this.Vrednost = g.Vrednost;
        }
        
        #endregion


        public override string ToString()
        {
            return ID + "-" + Naziv;
        }
    }
}
