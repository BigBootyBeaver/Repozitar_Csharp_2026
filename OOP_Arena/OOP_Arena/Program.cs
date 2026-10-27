using System.Text;

namespace OOP_Arena
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Kostka kostka = new Kostka(6);

            Console.WriteLine("Kdo se dneska bude prát?");
            Bojovnik bojovnik1 = new Bojovnik(Console.ReadLine(), 100, 20, 10, kostka);

            Console.WriteLine("A s kým?");
            Bojovnik bojovnik2 = new Bojovnik(Console.ReadLine(), 60, 18, 15, kostka);


            List<Bojovnik> seznamBojovniku = new List<Bojovnik>();
            seznamBojovniku.Add(bojovnik1);
            seznamBojovniku.Add((bojovnik2));

            Arena arena = new Arena(bojovnik1, bojovnik2, kostka, seznamBojovniku);



            arena.SpustZapas();
            Console.ReadLine();
        }
    }


}
