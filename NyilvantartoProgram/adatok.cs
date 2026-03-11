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


        public adatok( string nev, string kor, string cim,string szolgalatiido,  string szakma, string fizetes)
        {
            this.nev = nev;
            this.id = id;
            this.cim = cim;
            
            this.szolgalatiIdo = szolgalatiido;
            this.kor = kor;
            this.szakma = szakma;
            this.fizetes = fizetes;
        }


        public void ellenorzes(List<string> EllVaroAdatok)
        {
                
                if (int.Parse(kor)  < 18 || int.Parse(kor) > 65)
                {
                    Console.WriteLine("Hibás életkor: " + this.nev);
                }
                if (int.Parse(fizetes) < 0)
                {
                    Console.WriteLine("Hibás fizetés: " + this.nev);
                }
                if (int.Parse(szolgalatiIdo) < 0)
                {
                    Console.WriteLine("Hibás szolgálati idő: " + this.nev);
            }
        }



    }
}
