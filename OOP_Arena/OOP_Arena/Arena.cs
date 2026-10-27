using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOP_Arena
{
    class Arena
    {
        private Bojovnik bojovnik1;
        private Bojovnik bojovnik2;
        private Kostka kostka;
        private List<Bojovnik> seznamBojovniku;

        public Arena(Bojovnik bojovnik1, Bojovnik bojovnik2, Kostka kostka, List<Bojovnik> seznamBojovniku)
        {
            this.bojovnik1 = bojovnik1;
            this.bojovnik2 = bojovnik2;
            this.kostka = kostka;
            this.seznamBojovniku = seznamBojovniku;
        }
        private void VykresliArenu()
        {
            Console.Clear();
            Console.WriteLine("  /$$$$$$                                         \r\n /$$__  $$                                        \r\n| $$  \\ $$  /$$$$$$   /$$$$$$  /$$$$$$$   /$$$$$$ \r\n| $$$$$$$$ /$$__  $$ /$$__  $$| $$__  $$ |____  $$\r\n| $$__  $$| $$  \\__/| $$$$$$$$| $$  \\ $$  /$$$$$$$\r\n| $$  | $$| $$      | $$_____/| $$  | $$ /$$__  $$\r\n| $$  | $$| $$      |  $$$$$$$| $$  | $$|  $$$$$$$\r\n|__/  |__/|__/       \\_______/|__/  |__/ \\_______/\r\n                                                  \r\n                                                  \r\n                                                  ");

            Console.WriteLine("Zdraví bojovníků: \n");
            Console.WriteLine("{0} {1}", bojovnik1, bojovnik1.VratGrafickyPekneZivoty());
            Console.WriteLine("{0} {1}", bojovnik2, bojovnik2.VratGrafickyPekneZivoty());
        }

        private void VypisZpravu(string zprava)
        {
            Console.WriteLine(zprava);
            Thread.Sleep(500);
        }
        public void SpustZapas()
        {
            Console.Clear();
            Console.WriteLine("  /$$$$$$                                         \r\n /$$__  $$                                        \r\n| $$  \\ $$  /$$$$$$   /$$$$$$  /$$$$$$$   /$$$$$$ \r\n| $$$$$$$$ /$$__  $$ /$$__  $$| $$__  $$ |____  $$\r\n| $$__  $$| $$  \\__/| $$$$$$$$| $$  \\ $$  /$$$$$$$\r\n| $$  | $$| $$      | $$_____/| $$  | $$ /$$__  $$\r\n| $$  | $$| $$      |  $$$$$$$| $$  | $$|  $$$$$$$\r\n|__/  |__/|__/       \\_______/|__/  |__/ \\_______/\r\n                                                  \r\n                                                  \r\n                                                  ");
            Console.WriteLine("Vítejte v aréně!");
            Console.WriteLine($"Dnes se utkají {bojovnik1} a {bojovnik2}! \n");
            Console.WriteLine("Zápas může začít...");
            Console.ReadKey();
            // cyklus s bojem


            Kostka kostka = new Kostka(2);



            while (bojovnik1.JeNazivu() && bojovnik2.JeNazivu())
            {
                if (kostka.HodSebou() == 1) 
                {
                    seznamBojovniku[0] = bojovnik1;
                    seznamBojovniku[1] = bojovnik2;
                }
                else if (kostka.HodSebou() == 2)
                {
                    seznamBojovniku[0] = bojovnik2;
                    seznamBojovniku[1] = bojovnik1;
                }



                seznamBojovniku[0].Utoc(seznamBojovniku[1]);
                VykresliArenu();
                VypisZpravu(seznamBojovniku[0].Zprava); // zpráva o útoku
                VypisZpravu(seznamBojovniku[1].Zprava); // zpráva o obraně
                seznamBojovniku[1].Utoc(seznamBojovniku[0]);
                VykresliArenu();
                VypisZpravu(seznamBojovniku[1].Zprava); // zpráva o útoku
                VypisZpravu(seznamBojovniku[0].Zprava); // zpráva o obraně
                Console.WriteLine();
                Console.WriteLine();
                
                
                /*
                bojovnik1.Utoc(bojovnik2);
                VykresliArenu();
                VypisZpravu(bojovnik1.Zprava); // zpráva o útoku
                VypisZpravu(bojovnik2.Zprava); // zpráva o obraně
                bojovnik2.Utoc(bojovnik1);
                VykresliArenu();
                VypisZpravu(bojovnik2.Zprava); // zpráva o útoku
                VypisZpravu(bojovnik1.Zprava); // zpráva o obraně
                Console.WriteLine();
                Console.WriteLine(); 
                */

            }
        }
    }


}
