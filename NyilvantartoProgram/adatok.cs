using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NyilvantartoProgram
{
    internal class adatok
    {
        private string nev;
        
        private string cim;
        private string szolgalatiIdo;
        
        private string kor;
        private string szakma;
        private string fizetes;


        public adatok(string nev, string kor, string cim, string szolgalatiido, string szakma, string fizetes)
        {
            this.nev = nev;
            this.kor = kor;
            this.cim = cim;
            this.szolgalatiIdo = szolgalatiido;
            this.szakma = szakma;
            this.fizetes = fizetes;
        }

        public string Nev { get => nev;  }
        public string Cim { get => cim;  }
        public string SzolgalatiIdo { get => szolgalatiIdo;  }
        public string Kor { get => kor;}
        public string Szakma { get => szakma; }
        public string Fizetes { get => fizetes;}
    }
}
