namespace NyilvantartoProgram
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }

        public List<string> EllVaroAdatok()
        {
            List<string> EllVaroAdatok = new List<string>();
            //int id, string nev, int kor, string cim,int szolgalatiido,  string szakma, int fizetes
            Console.Write("Adja meg a dolgozó nevét: ");
            string nev = Console.ReadLine();
            EllVaroAdatok.Add(nev);
            Console.Write("Adja meg a dolgozó életkorát: ");
            string kor = Console.ReadLine();
            Console.Write("Adja meg a dolgozó címét: ");
            string cim = Console.ReadLine();
            Console.Write("Adja meg a dolgozó szolgálati idejét: ");
            string szolgalatiIdo = Console.ReadLine();
            Console.Write("Adja meg a dolgozó szakmáját: ");
            string szakma = Console.ReadLine();
            Console.Write("Adja meg a dolgozó fizetését: ");
            string fizetes = Console.ReadLine();
        }
    }
}
