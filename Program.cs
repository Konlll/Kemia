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
            try
            {
                Elem foundElem = elems.First(x => x.Sign.ToLower() == sign.ToLower());
                Console.WriteLine($"\tAz elem vegyjele: {foundElem.Sign}");
                Console.WriteLine($"\tAz elem neve: {foundElem.Name}");
                Console.WriteLine($"\tRendszáma: {foundElem.PlateNumber}");
                Console.WriteLine($"\tFelfedezés éve: {foundElem.Year}");
                Console.WriteLine($"\tFelfedező: {foundElem.Explorer}");
            }
            catch (Exception)
            {
                Console.WriteLine("\tNincs ilyen elem az adatforrásban!");
            }

            List<Elem> filteredElems = elems.SkipWhile(x => x.Year == "Ókor").ToList();
            int year = 0;
            for(int i = 0; i < filteredElems.Count; i++)
            {
                try
                {
                    if(int.Parse(filteredElems[i+1].Year) - int.Parse(filteredElems[i].Year) > year)
                    {
                        year = int.Parse(filteredElems[i + 1].Year) - int.Parse(filteredElems[i].Year);
                    }
                }
                catch (Exception)
                {
                    break;
                }
            }
            Console.WriteLine($"7. feladat: {year} év volt a leghosszabb időszak két elem felfedezése között.");

            Console.WriteLine("8. feladat: Statisztika");
            //List<Elem> years = elems.GroupBy(x => x.Year);
        }
    }
}
