namespace NyilvantartoProgram
{
    internal class Program
    {
        static void Main(string[] args)
        {
         
            adatok BeirtAdatok;
            if(!File.Exists("adatok.txt"))
            {
                File.WriteAllText("adatok.txt", "Nev;Kor;Cim;SzolgalatiIdo;Szakma;Fizetes\n");
            }
            StreamWriter sw;
            Console.Write("1 - Adatok megadása\n");
            string valasz = Console.ReadLine();
            if(valasz == "1")
            {
                BeirtAdatok = EllVaroAdatok();
                sw= new StreamWriter("adatok.txt", true);
                sw.WriteLine($"{BeirtAdatok.nev};{BeirtAdatok.kor};{BeirtAdatok.cim};{BeirtAdatok.szolgalatiIdo};{BeirtAdatok.szakma};{BeirtAdatok.fizetes}");

            }
        }
        static adatok EllVaroAdatok()
        {
            

            Console.Write("Adja meg a dolgozó nevét: ");
            string nev = Console.ReadLine();
            while (nev == null)
            {
                Console.WriteLine("Hibás nev!");
                Console.Write("Adja meg újra az életkort: ");
                nev = Console.ReadLine();
            }

            Console.Write("Adja meg a dolgozó életkorát: ");
            string kor = Console.ReadLine();
            int korInt;
            while (!int.TryParse(kor, out korInt) || korInt < 7 || korInt > 65)
            {
                Console.WriteLine("Hibás életkor!");
                Console.Write("Adja meg újra az életkort: ");
                kor = Console.ReadLine();
            }

            Console.Write("Adja meg a dolgozó címét: ");
            string cim = Console.ReadLine();

            Console.Write("Adja meg a dolgozó szolgálati idejét: ");
            string szolgalatiIdo = Console.ReadLine();
            int szolgalatiInt;
            while (!int.TryParse(szolgalatiIdo, out szolgalatiInt) || szolgalatiInt <= 0)
            {
                Console.WriteLine("Hibás szolgálati idő!");
                Console.Write("Adja meg újra: ");
                szolgalatiIdo = Console.ReadLine();
            }

            Console.Write("Adja meg a dolgozó szakmáját: ");
            string szakma = Console.ReadLine();

            Console.Write("Adja meg a dolgozó fizetését: ");
            string fizetes = Console.ReadLine();
            int fizetesInt;
            while (!int.TryParse(fizetes, out fizetesInt) || fizetesInt < 0)
            {
                Console.WriteLine("Hibás fizetés!");
                Console.Write("Adja meg újra a fizetést: ");
                fizetes = Console.ReadLine();
            }

            return new adatok(nev,kor,cim,szolgalatiIdo,szakma,fizetes);
        }
    }
}
