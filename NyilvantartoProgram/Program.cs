
namespace NyilvantartoProgram
{
    internal class Program
    {
        static void Main(string[] args)
        {

            adatok BeirtAdatok = null;
            if (!File.Exists("adatok.txt"))
            {
                File.WriteAllText("adatok.txt", "Név;Kor;Cím;SzolgalatiIdő;Szakma;Fizetés\n");
            }
            StreamWriter sw;
            Console.Write("1 - Új dolgozó felvétele\n");
            Console.Write("2 - Dolgozók listázása\n");
            Console.Write("3 - Statisztikák\n");
            Console.Write("4 - Dolgozó törlése\n");
            string valasz = Console.ReadLine();
            if (valasz == "1")
            {
                BeirtAdatok = EllVaroAdatok();
                sw = new StreamWriter("adatok.txt", true);
                sw.WriteLine($"{BeirtAdatok.Nev};{BeirtAdatok.Kor};{BeirtAdatok.Cim};{BeirtAdatok.SzolgalatiIdo};{BeirtAdatok.Szakma};{BeirtAdatok.Fizetes}");
                sw.Close();
            }
            if (valasz == "2")
            {
                Console.WriteLine(File.ReadAllText("adatok.txt"));

            }
            if (valasz == "3")
            {
                Console.Write("Adja meg a lekérdezendő dolgozó nevét: ");
                string adatok = Statisztika(Console.ReadLine());
                Console.WriteLine(adatok);
            }
            if (valasz == "4")
            {
                Console.Write("Mit szeretne csinálni?\n");
                Console.Write("1 - Egy dolgozó törlése\n");
                Console.Write("2 - Összes dolgozó törlése\n");

                string torlesValasz = Console.ReadLine();

                if (torlesValasz == "1")
                {
                    Console.Write("Adja meg a törlendő dolgozó nevét: ");
                    string nev = Console.ReadLine();
                    DolgozoTorles(nev);
                }
                if (torlesValasz == "2")
                {
                    OsszesTorles();
                }
            }
        }



        static string Statisztika(string nev)
        {
            StreamReader sr = new StreamReader("adatok.txt");
            while (!sr.EndOfStream)
            {
                string sor = sr.ReadLine();
                string[] adatok = sor.Split(';');
                if (adatok[0] == nev)
                {
                    return sor;
                }
            }
            sr.Close();
            return "Nincs ilyen dolgozó!";
        }

        static adatok EllVaroAdatok()
        {


            Console.Write("Adja meg a dolgozó nevét: ");
            string nev = Console.ReadLine();





            Console.Write("Adja meg a dolgozó életkorát: ");
            string kor = Console.ReadLine();
            int korInt;
            while (!int.TryParse(kor, out korInt) || korInt < 17 || korInt > 65)
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

            return new adatok(nev, kor, cim, szolgalatiIdo, szakma, fizetes);
        }
        static void DolgozoTorles(string nev)
        {
            List<string> sorok = new List<string>(File.ReadAllLines("adatok.txt"));
            List<string> ujSorok = new List<string>();

            foreach (string sor in sorok)
            {
                string[] adatok = sor.Split(';');

                if (adatok[0] != nev || adatok[0] == "Név")
                {
                    ujSorok.Add(sor);
                }
            }

            File.WriteAllLines("adatok.txt", ujSorok);

            Console.WriteLine("Dolgozó törölve");
        }
        static void OsszesTorles()
        {
            File.WriteAllText("adatok.txt", "Név;Kor;Cím;SzolgalatiIdő;Szakma;Fizetés\n");
            Console.WriteLine("Minden dolgozó törölve");
        }
    }
}
