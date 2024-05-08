using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkService.Model
{
    public class TypeTermometer : BindableBase
    {
        private string nazivTipa;
        public string NazivTipa
        {
            get { return nazivTipa; }
            set 
            { 
                nazivTipa = value;
                OnPropertyChanged("NazivTipa");
            }
        }

        private string slikaTipa;
        public string SlikaTipa
        {
            get { return slikaTipa; }
            set 
            { 
                slikaTipa = value;
                OnPropertyChanged("SlikaTipa");
            }
        }

        public TypeTermometer()
        {
            nazivTipa = string.Empty;
            slikaTipa = string.Empty;
        }

        public TypeTermometer(string tip, string slikaTipa)
        {
            NazivTipa = tip;
            SlikaTipa = slikaTipa;
        }

        public override string ToString()
        {
            return NazivTipa;
        }
    }
}
