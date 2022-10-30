using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Utazok_Feleves_Feladat
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Teszteleshez
            eleresi utvonal:
            bemenethez: C:\Users\Dell\source\repos\Utazok_Feleves_Feladat\Utazok_Feleves_Feladat\bin\TesztBe
            kimenethez: C:\Users\Dell\source\repos\Utazok_Feleves_Feladat\Utazok_Feleves_Feladat\bin\TesztKi
            
            @"..\TesztBe\utazoBe1.txt"            
            */
            string bemenet = @"..\TesztBe\utazoBe3.txt";
            int[] hossz = new int[2];

            if (Ellenorzes(ref hossz, @bemenet))
            {
                Utazok elsoUtazo = new Utazok(hossz, hossz[0], "elso", bemenet);
                Utazok masodikUtazo = new Utazok(hossz, hossz[0] + hossz[1], "masodik", bemenet);

                string[] tomb = new string[1000];
                tomb = elsoUtazo.Talalkozasok(elsoUtazo, masodikUtazo);
                for (int i = 0; i < tomb.Length; i++)
                {
                    Console.WriteLine(tomb[i]);
                }
            }
            else
            {
                Console.WriteLine("Hibas bemenet.");
            }

            Console.ReadLine();
        }
        static Boolean Ellenorzes(ref int[] hossz, string bemenet) // bemenet ellenőrzése, illetve adott utazonak a meglatogatott varosainak a szamanak az eltarolasa
        {
            StreamReader sr = new StreamReader(bemenet);

            hossz[0] = int.Parse(sr.ReadLine());
            if (hossz[0] == 0)
            {
                return false;
            }

            if (hossz[0] > 100 || hossz[0] < 1)
            {
                return false;
            }

            hossz[1] = 0;
            for (int i = 0; i < hossz[0] + 1; i++)
            {
                string[] seged = new string[3];
                if (i != hossz[0])
                {
                    seged = sr.ReadLine().Split(' ');
                    if (int.Parse(seged[0]) < 0 || int.Parse(seged[0]) > int.Parse(seged[1]) || int.Parse(seged[0]) > 10000 || int.Parse(seged[1]) > 10000)
                    {
                        return false;
                    }
                }
                else
                {
                    hossz[1] = int.Parse(sr.ReadLine());
                    for (int j = 0; j < hossz[1]; j++)
                    {
                        seged = sr.ReadLine().Split(' ');
                        if (int.Parse(seged[0]) < 0 || int.Parse(seged[0]) > int.Parse(seged[1]) || int.Parse(seged[0]) > 10000 || int.Parse(seged[1]) > 10000)
                        {
                            return false;
                        }
                    }
                }
            }
            if (hossz[1] > 100 || hossz[1] < 1)
            {
                return false;
            }
            return true;
        }
    }
}
