namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string szam = Console.ReadLine();
            if (szam == "1")
            {
                Dolgozok dolgozok = new Dolgozok();
                dolgozok.UjDolgozo();
            }
        }
    }


    public class  Dolgozok
    {
        static List<string[]> dolgozokListaja = new List<string[]>();

         public void UjDolgozo()
        {
            Console.Write("Nev: ");
            string nev = Console.ReadLine();
            foreach (var item in dolgozokListaja)
            {
                if (nev != item[0])
                {
                    Console.WriteLine("Mar letezik ilyen nevu dolgozo!");
                    return;
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
            dolgozokListaja.Add(new string[] { nev, kor, munkakSzama, fizetes });
        }   




    }

    public class Statisztika
    {

    }

    public class DolgozokAdatai
    {

    }
}
