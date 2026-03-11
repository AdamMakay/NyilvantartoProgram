namespace NyilvantartoProgram
{
    internal class Program
    {
        static void Main(string[] args)
        {
            adatok adatok;
            adatok = new adatok(EllVaroAdatok[0],)
        }
        public string[] EllVaroAdatok()
        {
            string[] EllVaroAdatok = new string[6];

            Console.Write("Adja meg a dolgozó nevét: ");
            EllVaroAdatok[0] = Console.ReadLine();

            Console.Write("Adja meg a dolgozó életkorát: ");
            EllVaroAdatok[1] = Console.ReadLine();

            Console.Write("Adja meg a dolgozó címét: ");
            EllVaroAdatok[2] = Console.ReadLine();

            Console.Write("Adja meg a dolgozó szolgálati idejét: ");
            EllVaroAdatok[3] = Console.ReadLine();

            Console.Write("Adja meg a dolgozó szakmáját: ");
            EllVaroAdatok[4] = Console.ReadLine();

            Console.Write("Adja meg a dolgozó fizetését: ");
            EllVaroAdatok[5] = Console.ReadLine();

            return EllVaroAdatok;
        }
    }
}
