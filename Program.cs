using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static List<Elem> elems = new List<Elem>();
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("felfedezesek.csv");
            while(!sr.EndOfStream)
            {
                var data = sr.ReadLine().Split(';');
                Elem elem = new Elem(data[0], data[1], data[2], data[3], data[4]);
                elems.Add(elem);
            }
            sr.Close();
            elems = elems.Skip(1).ToList();

            Console.WriteLine($"3. feladat: Elemek száma: {elems.Count()}");
            Console.WriteLine($"4. feladat: Felfedezések száma az ókorban: {elems.Where(x => x.Year == "Ókor").Count()}");
            string sign;
            while (true)
            {
                Console.Write("5. feladat: Kérek egy vegyjelet: ");
                sign = Console.ReadLine();
                if(sign.ToLower().Length <= 2)
                {
                    break;
                }
            }
            Console.WriteLine("6. feladat: Keresés");
            Elem foundElem = elems.First(x => x.Sign == sign);
            if(foundElem != null)
            {
                Console.WriteLine($"\tAz elem vegyjele: {foundElem.Sign}");
                Console.WriteLine($"\tAz elem neve: {foundElem.Name}");
                Console.WriteLine($"\tRendszáma: {foundElem.PlateNumber}");
                Console.WriteLine($"\tFelfedezés éve: {foundElem.Year}");
                Console.WriteLine($"\tFelfedező: {foundElem.Explorer}");
            }
            else
            {
                Console.WriteLine("\tNincs ilyen elem az adatforrásban!");
            }
        }
    }
}
