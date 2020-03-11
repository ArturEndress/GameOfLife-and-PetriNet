using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace PetriNet_engine_csharp
{
    class Program
    {
        static void Main(string[] args)
        {


            // MATRIZ

            int nCol, nLin, nCicles;

            Console.Write("Quantas Colunas? ");
            nCol = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            Console.Write("Quantas Linhas? ");
            nLin = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            Console.Write("Quantos Ciclos? ");
            nCicles = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();


            GeraConfigIni configIni = new GeraConfigIni(nCol, nLin);

            CalcVizinho calcVizinho = new CalcVizinho();


            while (calcVizinho.getCicles() < 50)
            {

                calcVizinho.CopConfigIni(configIni, nCol, nLin);
                calcVizinho.CopMap(nCol, nLin);






                for (int n = 0; n < nCicles; n++)
                {
                    for (int i = 0; i < nLin; i++)
                    {
                        for (int j = 0; j < nCol; j++)
                        {
                            calcVizinho.CalcularVizinho(nCol - 1, nLin - 1, j, i);
                        }
                    }
                    calcVizinho.CopMap(nCol, nLin);

                }

                //Seta flags e NPCs
                calcVizinho.setFlags(4);
                calcVizinho.setNpcs(3);

                calcVizinho.colocarPlayer(nCol, nLin);

                calcVizinho.floodFill(calcVizinho.getX(), calcVizinho.getY(), nCol, nLin, 0);

            }



            // PETRI NET
            PetriNet net = new PetriNet();

            Console.WriteLine();

            net.CreateNet(calcVizinho.getAllMap(), nCol, nLin);

           


            for (int i = 0; i < nLin; i++)
            {
                for (int j = 0; j < nCol; j++)
                {
                    if (net.getPlace(j + nCol * i).getId() == 1)
                    {
                        Console.Write("X" + " ");
                    }
                    else if (net.getPlace(j + nCol * i).getId() == 2)
                    {
                        Console.Write("O" + " ");
                    }
                    else if (net.getPlace(j + nCol * i).getId() == 3)
                    {
                        Console.Write("N" + " ");
                    }
                    else if (net.getPlace(j + nCol * i).getId() == 4)
                    {
                        Console.Write("F" + " ");
                    }
                    else
                    {
                        Console.Write("-" + " ");
                    }
                }
                Console.WriteLine();
            }

            Console.ReadKey();
            Console.WriteLine();


            while (net.getFlags() > 0)
            {
                Console.WriteLine("Execute Cicle");
                net.execCycle();
                Console.WriteLine("Draw Map");
                net.desenhaRede(nCol);

                Console.WriteLine("N Flags: {0}", net.getFlags());
            }

            Console.ReadKey();
        }
    }
}
