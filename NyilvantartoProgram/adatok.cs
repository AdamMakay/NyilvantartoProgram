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


        public void ellenorzes(List<string> EllVaroAdatok)
        {
            int ellInt;
            if(string.IsNullOrEmpty(nev))
            {
            throw new ArgumentException("Rossz nev! >:[");
            }

           if(int.TryParse(this.kor,out ellInt))
           { 
                if (int.Parse(kor)  < 18 || int.Parse(kor) > 65)
                {
                    Console.WriteLine("Hibás életkor: " + this.nev);
                }
           }
           else throw new ArgumentException("Rossz kor! >:[");

           if(int.TryParse(this.fizetes, out ellInt))
            { 

                if (int.Parse(fizetes) < 0)
                {
                    Console.WriteLine("Hibás fizetés: " + this.nev);
                }
            }
           else throw new ArgumentException("Rossz fizetés! >:[");
            if (int.TryParse(this.szolgalatiIdo, out ellInt))
            {
                if (int.Parse(szolgalatiIdo) < 0)
                {
                    Console.WriteLine("Hibás szolgálati idő: " + this.nev);
                }

            }
            else throw new ArgumentException("Rossz szolgálati idő! >:[");
        }


    }
}
