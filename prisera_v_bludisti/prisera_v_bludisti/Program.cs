namespace prisera_v_bludisti
{
    
    internal class Program
    {
        class Prisera
        {
            public int X = 1;
            public int Y = 1;
            public int Smer = 0; // směry jsou 1 až 4
            char[] Vzhledy = ['>', '^', '<', 'v'];
            public bool OtocilaSeVpravo = false;
            public char Vzhled
            {
                get
                {
                    // Ochrana před přetečením indexu (kdyby směr byl mimo rozsah 0 až 3)
                    if (Smer >= 0 && Smer < Vzhledy.Length)
                    {
                        return Vzhledy[Smer];
                    }
                    return '>'; // Výchozí znak, pokud by se stala chyba (i když by se stát neměla, protože kvůli modulo to nepřeteče)
                }
            }
        }

        List<Prisera> prisery = new List<Prisera>();

        static char[,] NactiBludiste(List<Prisera> seznamPriser)
        {
            int sirka = int.Parse(Console.ReadLine());
            int vyska = int.Parse(Console.ReadLine());

            char[,] bludiste = new char[vyska, sirka];

            for (int i = 0; i < vyska; i++)
            {
                string line = Console.ReadLine();

                for (int j = 0; j < sirka; j++)
                {
                    bludiste[i, j] = line[j];
                    if (bludiste[i, j] == '>' || bludiste[i, j] == '^' || bludiste[i, j] == '<' || bludiste[i, j] == 'v') // následující blok přidá instanci příšery do seznamu
                    {
                        Prisera novaPrisera = new Prisera();
                        novaPrisera.X = j;
                        novaPrisera.Y = i;



                        if (bludiste[i, j] == '>') novaPrisera.Smer = 0;
                        else if (bludiste[i, j] == '^') novaPrisera.Smer = 1;
                        else if (bludiste[i, j] == '<') novaPrisera.Smer = 2;
                        else if (bludiste[i, j] == 'v') novaPrisera.Smer = 3;

                        seznamPriser.Add(novaPrisera);

                    }

                }

            }

            return bludiste;
        }

        static void PohniPrysery(List<Prisera> seznamPriser, char[,] bludiste)
        {
            for (int i = 0; i < seznamPriser.Count; i++)
            {
                Prisera p = seznamPriser[i];


                bludiste[p.Y, p.X] = '.'; // vymažeme příšeru z bludiště (udělá tam volno)

                int smerVpravo = (p.Smer + 3) % 4;
                int smerRovne = p.Smer;

                int vpravoX = p.X;
                int vpravoY = p.Y;
                if (smerVpravo == 0) vpravoX++;
                else if (smerVpravo == 1) vpravoY--;
                else if (smerVpravo == 2) vpravoX--;
                else if (smerVpravo == 3) vpravoY++;
                char polickoVpravo = bludiste[vpravoY, vpravoX];


                int rovneX = p.X;
                int rovneY = p.Y;
                if (smerRovne == 0) rovneX++;
                else if (smerRovne == 1) rovneY--;
                else if (smerRovne == 2) rovneX--;
                else if (smerRovne == 3) rovneY++;
                char polickoRovne = bludiste[rovneY, rovneX];


                /*
                if (bludiste[noveY, noveX] == '.')
                {
                    p.X = noveX;
                    p.Y = noveY;
                }
                else 
                {
                    p.Smer = (p.Smer + 1) % 4;
                } */

                if (p.OtocilaSeVpravo == false && polickoVpravo == '.') // pokud je najednou políčko vpravo prázdné a víš, že ses v minulém tahu neotočila doprava (šla jsi rovně), tak se otoč doprava
                {
                    p.Smer = (p.Smer + 3) % 4; ;
                    p.OtocilaSeVpravo = true;
                }
                else if (p.OtocilaSeVpravo == true && polickoRovne == '.') // pokud ses otočila doprava a políčko před čumákem je prázdné, tak se tam pohni
                {
                    p.X = rovneX;
                    p.Y = rovneY;
                    p.OtocilaSeVpravo = false;
                }
                else if (polickoRovne != '.') // pokud narazíš čumákem do zdi, otoč se doleva
                {
                    p.Smer = (p.Smer + 1) % 4;
                }
                else if (polickoRovne == '.' && polickoVpravo != '.') // když je políčko před čumákem prázdné a políčko vpravo plné, tak se pohni dopředu
                {
                    p.X = rovneX;
                    p.Y = rovneY;
                }



                bludiste[p.Y, p.X] = p.Vzhled; // zapíše příšeru na nové místo v bludisti (nebo zůstane na starém, protože se nepohnula)

            }


        }
        static void VypisBludiste(char[,] bludiste)
        {

            int vyska = bludiste.GetLength(0);
            int sirka = bludiste.GetLength(1);


            for (int i = 0; i < vyska; i++)
            {
                for (int j = 0; j < sirka; j++)
                {
                    Console.Write(bludiste[i, j]);
                }
                Console.WriteLine(); // Další řádek

            }



        }

        static void Main(string[] args)
        {
            List<Prisera> prisery = new List<Prisera>();
            char[,] bludiste = NactiBludiste(prisery);

            Console.WriteLine(); // aby tam byla mezera mezi vstupem a vypsanými tahy 

            // Cyklus pro 20 tahů příšer
            for (int tah = 0; tah < 20; tah++)
            {
                Console.WriteLine($"{tah + 1}. krok");
                PohniPrysery(prisery, bludiste);
                VypisBludiste(bludiste);
                Console.WriteLine(); // odenteruje bludiště

            }
        }
    }

}
