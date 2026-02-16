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
                if(torlesModja == "1")
                {
                    File.WriteAllLines("dolgozok.txt",uresLista);
                }
                else if(torlesModja == "2")
                {
                    dolgozok.NevTorles();
                }
                else Console.WriteLine("Nincs ilyen opcio!");
                
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


            Console.Write("Kor: ");
            string kor = Console.ReadLine();
            //item[1] = kor;
            Console.Write("Elvegzett munkak szama: ");
            string munkakSzama = Console.ReadLine();
            //item[2] = munkakSzama;
            Console.Write("Fizetes: ");
            string fizetes = Console.ReadLine();
            //item[3] = fizetes;
            //dolgozokListaja.Add(new string[] { nev, kor, munkakSzama, fizetes });
            using (StreamWriter sw = new StreamWriter("dolgozok.txt", true))
            {
                if (ujFajl)
                {
                    sw.WriteLine("Nev;Kor;Elvegzett munkak szama;Fizetes");
                }

                sw.WriteLine($"{nev};{Convert.ToInt32(kor)};{Convert.ToInt32(munkakSzama)};{Convert.ToDouble(fizetes)}");
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






    //public class Statisztika
    //{

        //}

}
