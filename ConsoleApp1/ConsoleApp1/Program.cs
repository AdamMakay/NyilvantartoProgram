using System.Threading.Channels;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> uresLista = new List<string>();
            uresLista.Add("Nev;Kor;Elvegzett munkak szama;Fizetes");
            //Console.WriteLine(File.Exists("dolgozok.txt"));
            Console.WriteLine(File.ReadAllText("dolgozok.txt"));
            Dolgozok dolgozok = new Dolgozok();
           // dolgozok.dolgozokListaja.Add(new string[] { "Nev", ";Kor", ";Elvegzett munkak szama", ";Fizetes" });
            bool kilepes = true;
            while (kilepes)
            {
                string szam = Console.ReadLine().Trim();
                if (szam == "1")
                {
                    dolgozok.UjDolgozo();
                }
                if (szam == "2")
                {
                    dolgozok.Kiiratas();
                }
                if (szam == "3")
                {
                    Console.Write("Töröles modja:\n1 - Osszes adat\n2 - Egy szemely adatai\n");
                    string torlesModja = Console.ReadLine().Trim();
                    if (torlesModja == "1")
                    {
                        File.WriteAllLines("dolgozok.txt", uresLista);
                    }
                    else if (torlesModja == "2")
                    {
                        dolgozok.NevTorles();
                    }
                    else Console.WriteLine("Nincs ilyen opcio!");

                }
                if (szam == "4")
                {
                    Statisztika statisztika = new Statisztika();
                    Console.WriteLine("Melyik opciot szeretned:\n1-Atlag Eletkor\n2-Atlag Fizetes\n3-Osszes Elvegzett Munka");
                    string valasztas = Console.ReadLine().Trim();
                    if (valasztas == "1") Console.WriteLine("AZ atlagos eletkor: " + statisztika.AtlagKor("dolgozok.txt"));
                    else if (valasztas == "2") Console.WriteLine("Az atlagos fizetes: " + statisztika.AtlagFizetes("dolgozok.txt"));
                    else if (valasztas == "3") Console.WriteLine("Az osszes elvegzett munka: " + statisztika.OsszesElvegzettMunka("dolgozok.txt"));
                    else Console.WriteLine("Nincs ilyen opcio!");

                }
                if (szam == "5")
                {
                    kilepes = false;
                }
            }
            Console.ReadKey();
        }
    }


    public class Dolgozok
    {


        //public List<string[]> dolgozokListaja = new List<string[]>();
        public void UjDolgozo()
        {
            bool ujFajl = !File.Exists("dolgozok.txt");

            Console.Write("Nev: ");
            string nev = Console.ReadLine();
            if (File.Exists("dolgozok.txt"))
            {
                foreach (var item in File.ReadAllLines("dolgozok.txt"))
                {
                    string[] adatok = item.Split(';');
                    if (adatok[0] == nev)
                    {
                        Console.WriteLine("Már van ilyen nevű dolgozó!");
                        return;
                    }
                }
            }
            bool ellenorzes;
            int ellenorzesInt;
            byte ellenorzesByte;
            double ellenorzesDouble;
            string kor;
            while (true)
            {
                
                Console.Write("Kor: ");
                kor = Console.ReadLine();
                ellenorzes = byte.TryParse(kor, out ellenorzesByte);
                if (ellenorzes)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Hibás adat!");
                }
            }
            string munkakSzama;
            //item[1] = kor;
            while (true)
            {
                Console.Write("Elvegzett munkak szama: ");
                munkakSzama = Console.ReadLine();
                ellenorzes = int.TryParse(munkakSzama, out ellenorzesInt);
                if (ellenorzes)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Hibás adat!");
                }
            }
            //item[2] = munkakSzama;
            string fizetes;
            while (true)
            {
                Console.Write("Fizetes: ");
                fizetes = Console.ReadLine();
                ellenorzes = double.TryParse(fizetes, out ellenorzesDouble);
                if (ellenorzes)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Hibás adat!");
                }
            }
            //item[3] = fizetes;
            //dolgozokListaja.Add(new string[] { nev, kor, munkakSzama, fizetes });
            using (StreamWriter sw = new StreamWriter("dolgozok.txt", true))
            {
                if (ujFajl)
                {
                    sw.WriteLine("Nev;Kor;Elvegzett munkak szama;Fizetes");
                }

                sw.WriteLine($"{nev};{kor};{munkakSzama};{fizetes}");
            }

        }
        public void Kiiratas()
        {
            //Console.WriteLine("Kiiratas lefutott!");
            List<string> FajlBeolvasas = new List<string>();
            if (!File.Exists("dolgozok.txt"))
            {
                Console.WriteLine("Nincs meg a fájl!");
                return;
            }
            else
            {
                StreamReader streamReader = new StreamReader("dolgozok.txt");
                while (!streamReader.EndOfStream)
                {
                    FajlBeolvasas.Add(streamReader.ReadLine());
                }
                streamReader.Close();
            }
            foreach (var item in FajlBeolvasas)
            {
                Console.WriteLine(item);
            }

        }


        public void NevTorles()
        {
            StreamReader streamReader;
            List<string> FajlBeolvasas = new List<string>();
            List<string> uresLista = new List<string>();
            bool torles = false;
            if (!File.Exists("dolgozok.txt"))
            {
                Console.WriteLine("Nincs meg a fájl!");
                return;
            }
            else
            {
                streamReader = new StreamReader("dolgozok.txt");
                //bool torles = false;
                while (!streamReader.EndOfStream)
                {

                    FajlBeolvasas.Add(streamReader.ReadLine());
                }

                streamReader.Close();
            }



            Console.Write("Kérem adja meg a törölni kívánt dolgozó nevét: ");
            string nev = Console.ReadLine();
            for (var item = 1; item < FajlBeolvasas.Count; item++)
            {
                string[] adatok = FajlBeolvasas[item].Split(';');
                if (adatok[0] == nev)
                {
                    FajlBeolvasas.RemoveAt(item);
                    torles = true;
                    break;
                }
            }

            if (torles) File.WriteAllLines("dolgozok.txt", FajlBeolvasas);
            else Console.WriteLine("Nincs ilyen nevű dolgozó!");




        }
    }






    public class Statisztika
    {
        private int db;
        public int AtlagKor(string fajlNeve)
        {
            int korOsszesen = 0;
            
            StreamReader streamReader = new StreamReader(fajlNeve);
            streamReader.ReadLine();
            while (!streamReader.EndOfStream)
            {
               
                string[] tomb = streamReader.ReadLine().Split(';');
                korOsszesen += Convert.ToInt32(tomb[1]);
                db++;
            }
            streamReader.Close();
            return korOsszesen / db;
        }
        public double AtlagFizetes(string fajlNeve)
        {
            double fizetesOsszesen = 0;
            StreamReader streamReader = new StreamReader(fajlNeve);
            streamReader.ReadLine();
            while (!streamReader.EndOfStream)
            {
                
                string[] tomb = streamReader.ReadLine().Split(';');
                fizetesOsszesen += Convert.ToDouble(tomb[3]);
            }
            streamReader.Close();
            return fizetesOsszesen / db;
        }
        public int OsszesElvegzettMunka(string fajlNeve)
        {
            int elvegzettMunkaOsszesen = 0;
            StreamReader streamReader = new StreamReader(fajlNeve);
            streamReader.ReadLine();
            while (!streamReader.EndOfStream)
            {
                string[] tomb = streamReader.ReadLine().Split(';');
                elvegzettMunkaOsszesen += Convert.ToInt32(tomb[2]);
            }
            streamReader.Close();
            return elvegzettMunkaOsszesen;
        }
    }
}
