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
        private int id;
        private string cim;
        private int szolgalatiIdo;
        
        private int kor;
        private string szakma;
        private int fizetes;


        public adatok(int id, string nev, int kor, string cim,int szolgalatiido,  string szakma, int fizetes)
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
                
                if (kor < 18 || kor > 65)
                {
                    Console.WriteLine("Hibás életkor: " + this.nev);
                }
                if (fizetes < 0)
                {
                    Console.WriteLine("Hibás fizetés: " + this.nev);
                }
                if (szolgalatiIdo < 0)
                {
                    Console.WriteLine("Hibás szolgálati idő: " + this.nev);
            }
        }



    }
}
