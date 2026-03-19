
namespace NyilvantartoProgram
{
    internal class Program
    {
        static void Main(string[] args)
        {

            bool fut = true;
            adatok BeirtAdatok = null;
            if (!File.Exists("adatok.txt"))
            {
                File.WriteAllText("adatok.txt", "Név;Kor;Cím;SzolgalatiIdő;Szakma;Fizetés\n");
            }

            while (fut)
            {
                //Kinézet------------------------------------------------------------------------------------------------------------------------
                Console.Clear();
                int dolgozoSzam = File.ReadAllLines("adatok.txt").Length - 1;
                Console.Write("\n\n\n======== DOLGOZÓI NYILVÁNTARTÓ RENDSZER ========\n");
                Console.WriteLine($"Jelenleg {dolgozoSzam} dolgozó van az adatbázisban.");
                Console.Write("\nVálassza ki hogy mit szeretne csinálni:\n");
                Console.WriteLine("------------------------------------------------");
                Console.Write("1 - Új dolgozó felvétele\t\t\t|\n");
                Console.Write("2 - Dolgozók listázása\t\t\t\t|\n");
                Console.Write("3 - Statisztikák\t\t\t\t|\n");
                Console.Write("4 - Dolgozó törlése\t\t\t\t|\n");
                Console.Write("5 - Kilépés\t\t\t\t\t|\n");
                Console.WriteLine("------------------------------------------------\n");
                Console.Write("Adja meg a választott számot: ");
                string valasz = Console.ReadLine();



                //Dolgozó hozzáadása-------------------------------------------------------------------------------------------------------------
                if (valasz == "1")
                {
                    BeirtAdatok = EllVaroAdatok();
                    using (StreamWriter sw = new StreamWriter("adatok.txt", true))
                    {
                        sw.WriteLine($"{BeirtAdatok.Nev};{BeirtAdatok.Kor};{BeirtAdatok.Cim};{BeirtAdatok.SzolgalatiIdo};{BeirtAdatok.Szakma};{BeirtAdatok.Fizetes}");
                    }
                    Console.Write("Dolgozó sikeresen hozzáadva\n\n");
                    Console.WriteLine("Nyomjon meg egy gombot a visszalépéshez...");
                    Console.ReadKey();
                }


                //Dolgozók listázása-------------------------------------------------------------------------------------------------------------
                else if (valasz == "2")
                {
                    Console.WriteLine($"\n{File.ReadAllText("adatok.txt").Replace(";", " ")}");
                    Console.WriteLine("Nyomjon meg egy gombot a visszalépéshez...");
                    Console.ReadKey();

                }


                //Statisztikák-------------------------------------------------------------------------------------------------------------
                else if (valasz == "3")
                {
                    Console.Write("\nMiről szeretne statisztikát?\n");
                    Console.Write("1 - Átlag lekérdezése\n");
                    Console.Write("2 - Dolgozó keresése\n");
                    Console.Write("3 - Részleg keresése\n");
                    string valasz1 = Console.ReadLine();

                    if (valasz1 == "1")
                    {
                        string[] sorok = File.ReadAllLines("adatok.txt");
                        if (sorok.Length <= 1)
                        {
                            Console.WriteLine("\nNincsenek dolgozók az adatbázisban!");
                        }
                        else
                        {
                            int osszFizetes = 0;
                            int osszSzolgalatiIdo = 0;
                            int dolgozokSzama = sorok.Length - 1;

                            for (int i = 1; i < sorok.Length; i++)
                            {
                                string[] adatok = sorok[i].Split(';');
                                osszSzolgalatiIdo += int.Parse(adatok[3]);
                                osszFizetes += int.Parse(adatok[5]);
                            }

                            double atlagFizetes = (double)osszFizetes / dolgozokSzama;
                            double atlagSzolgalatiIdo = (double)osszSzolgalatiIdo / dolgozokSzama;

                            Console.WriteLine($"\nÁtlag fizetés: {atlagFizetes:F0}");
                            Console.WriteLine($"Átlag szolgálati idő: {atlagSzolgalatiIdo:F2}\n");
                        }
                        Console.WriteLine("Nyomjon meg egy gombot a visszalépéshez...");
                        Console.ReadKey();
                    }
                    else if (valasz1 == "2")
                    {
                        Console.Write("Adja meg a lekérdezendő dolgozó nevét: ");
                        string adatok = Statisztika(Console.ReadLine());
                        Console.WriteLine($"\nNév Kor Cím SzolgalatiIdő Szakma Fizetés\n{adatok.Replace(";"," ")}\n");
                        Console.WriteLine("Nyomjon meg egy gombot a visszalépéshez...");
                        Console.ReadKey();
                    }
                    else if (valasz1 == "3")
                    {
                        Console.Write("Adja meg a részleg nevét: ");
                        string reszleg = Console.ReadLine();

                        string[] sorok = File.ReadAllLines("adatok.txt");
                        bool talalat = false;

                        Console.WriteLine($"\nDolgozók a(z) {reszleg} részlegben:");

                        for (int i = 1; i < sorok.Length; i++)
                        {
                            string[] adatok = sorok[i].Split(';');
                            if (adatok[4] == reszleg)
                            {
                                Console.WriteLine(string.Join(" ", adatok));
                                talalat = true;
                            }
                        }

                        if (!talalat)
                            Console.WriteLine("\nNincs ilyen részleg!");

                        Console.WriteLine("\nNyomjon meg egy gombot a visszalépéshez...");
                        Console.ReadKey();
                    }
                }



                //Dolgozók törlése-------------------------------------------------------------------------------------------------------------
                else if (valasz == "4")
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
                    else if (torlesValasz == "2")
                    {
                        OsszesTorles();
                    }
                    else
                    {
                        Console.WriteLine("\n\nNincs ilyen opció!");
                    }
                    Console.WriteLine("Nyomjon meg egy gombot a visszalépéshez...");
                    Console.ReadKey();
                }




                //Kilépés-------------------------------------------------------------------------------------------------------------
                else if (valasz == "5")
                {
                    Console.Write("\n\nViszont látásra!");
                    fut = false;
                }
            }
            
        }


        //Dolgozó adatai-------------------------------------------------------------------------------------------------------------
        static string Statisztika(string nev)
        {
            using (StreamReader sr = new StreamReader("adatok.txt"))
            {
                while (!sr.EndOfStream)
                {
                    string sor = sr.ReadLine();
                    string[] adatok = sor.Split(';');
                    if (adatok[0] == nev)
                    {
                        return sor;
                    }
                }
            }

            return "\n\nNincs ilyen dolgozó!";
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



        //Törlés funkciók-------------------------------------------------------------------------------------------------------------
        static void DolgozoTorles(string nev)
        {
            List<string> sorok = new List<string>(File.ReadAllLines("adatok.txt"));
            List<string> ujSorok = new List<string>();

            bool talalat = false;

            foreach (string sor in sorok)
            {
                string[] adatok = sor.Split(';');

                if (adatok[0] == nev)
                {
                    talalat = true;
                }
                else
                {
                    ujSorok.Add(sor);
                }
            }

            if (talalat)
            {
                File.WriteAllLines("adatok.txt", ujSorok);
                Console.WriteLine("Dolgozó törölve");
            }
            else
            {
                Console.WriteLine("Nincs ilyen nevű dolgozó!\n\n");
            }
        }
        static void OsszesTorles()
        {
            File.WriteAllText("adatok.txt", "Név;Kor;Cím;SzolgalatiIdő;Szakma;Fizetés\n");
            Console.WriteLine("Minden dolgozó törölve");
        }
    }
}
