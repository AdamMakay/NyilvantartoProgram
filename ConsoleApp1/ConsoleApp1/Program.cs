namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {

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
            Console.ReadKey();
        }
    }


    public class  Dolgozok
    {
       

         //public List<string[]> dolgozokListaja = new List<string[]>();
         public void UjDolgozo()
         {
            bool ujFajl = !File.Exists("dolgozok.txt");

            Console.Write("Nev: ");
            string nev = Console.ReadLine();
            if (File.Exists("dolgozok.txt"))
            {
                foreach(var item in File.ReadAllLines("dolgozok.txt"))
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




    }   






    

    //public class Statisztika
    //{

    //}

}
