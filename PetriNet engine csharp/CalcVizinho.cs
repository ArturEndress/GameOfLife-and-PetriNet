using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetriNet_engine_csharp
{
    class CalcVizinho
    {
        private int[,] mapa;
        private int[,] mapa2;
        private int xPlayer, yPlayer;
        private int nNpcs, nFlags;
        private int ciclosFF;


        Random rand = new Random();
        int sorteio;

        public CalcVizinho()
        { }

        public void CalcularVizinho(int nCol, int nLin, int posX, int posY)
        {
            int x, y;
            int nVizinhosVivos = 0;
            bool right, left, up, down;
            ciclosFF = 0;       // Contador para o FloodFill
            
            x = posX;
            y = posY;
            right = left = up = down = false;

            // TESTA VIZINHOS
            if (x == nCol)
            {
                right = true;
            }
            if (x == 0)
            {
                left = true;
            }
            if (y == nLin)
            {
                down = true;
            }
            if (y == 0)
            {
                up = true;
            }

            if (right)
            {
               
                if (up)
                {
                    
                    if (mapa2[0, nLin] == 1)
                    {
                        nVizinhosVivos++;
                    }
                    if (mapa2[0, y + 1] == 1)
                    {
                        nVizinhosVivos++;
                    }
                    if (mapa2[0, y] == 1)
                    {
                        nVizinhosVivos++;
                    }
                    if (mapa2[x - 1, nLin] == 1)
                    {
                        nVizinhosVivos++;
                    }
                    if (mapa2[x - 1, y + 1] == 1)
                    {
                        nVizinhosVivos++;
                    }
                    if (mapa2[x - 1, y] == 1)
                    {
                        nVizinhosVivos++;
                    }
                    if (mapa2[x, nLin] == 1)
                    {
                        nVizinhosVivos++;
                    }
                    if (mapa2[x, y + 1] == 1)
                    {
                        nVizinhosVivos++;
                    }
                    

                }
                else if (down)
                {
                    if (mapa2[0, 0] == 1)
                    {
                        nVizinhosVivos++;
                    }
                    if (mapa2[0, y - 1] == 1)
                    {
                        nVizinhosVivos++;
                    }
                    if (mapa2[0, y] == 1)
                    {
                        nVizinhosVivos++;
                    }
                    if (mapa2[x - 1, 0] == 1)
                    {
                        nVizinhosVivos++;
                    }
                    if (mapa2[x - 1, y - 1] == 1)
                    {
                        nVizinhosVivos++;
                    }
                    if (mapa2[x - 1, y] == 1)
                    {
                        nVizinhosVivos++;
                    }
                    if (mapa2[x, 0] == 1)
                    {
                        nVizinhosVivos++;
                    }
                    if (mapa2[x, y - 1] == 1)
                    {
                        nVizinhosVivos++;
                    }
                }
                else
                {
                    if (mapa2[0, y + 1] == 1)
                    {
                        nVizinhosVivos++;
                    }
                    if (mapa2[0, y - 1] == 1)
                    {
                        nVizinhosVivos++;
                    }
                    if (mapa2[0, y] == 1)
                    {
                        nVizinhosVivos++;
                    }
                    if (mapa2[x - 1, y + 1] == 1)
                    {
                        nVizinhosVivos++;
                    }
                    if (mapa2[x - 1, y - 1] == 1)
                    {
                        nVizinhosVivos++;
                    }
                    if (mapa2[x - 1, y] == 1)
                    {
                        nVizinhosVivos++;
                    }
                    if (mapa2[x, y + 1] == 1)
                    {
                        nVizinhosVivos++;
                    }
                    if (mapa2[x, y - 1] == 1)
                    {
                        nVizinhosVivos++;
                    }
                }

            }

            else if (left)
            {

                if (up)
                {

                    if (mapa2[nCol, nLin] == 1)
                    {
                        nVizinhosVivos++;
                    }
                    if (mapa2[nCol, y + 1] == 1)
                    {
                        nVizinhosVivos++;
                    }
                    if (mapa2[nCol, y] == 1)
                    {
                        nVizinhosVivos++;
                    }
                    if (mapa2[x + 1, nLin] == 1)
                    {
                        nVizinhosVivos++;
                    }
                    if (mapa2[x + 1, y + 1] == 1)
                    {
                        nVizinhosVivos++;
                    }
                    if (mapa2[x + 1, y] == 1)
                    {
                        nVizinhosVivos++;
                    }
                    if (mapa2[x, nLin] == 1)
                    {
                        nVizinhosVivos++;
                    }
                    if (mapa2[x, y + 1] == 1)
                    {
                        nVizinhosVivos++;
                    }


                }
                else if (down)
                {
                    if (mapa2[nCol, 0] == 1)
                    {
                        nVizinhosVivos++;
                    }
                    if (mapa2[nCol, y - 1] == 1)
                    {
                        nVizinhosVivos++;
                    }
                    if (mapa2[nCol, y] == 1)
                    {
                        nVizinhosVivos++;
                    }
                    if (mapa2[x + 1, 0] == 1)
                    {
                        nVizinhosVivos++;
                    }
                    if (mapa2[x + 1, y - 1] == 1)
                    {
                        nVizinhosVivos++;
                    }
                    if (mapa2[x + 1, y] == 1)
                    {
                        nVizinhosVivos++;
                    }
                    if (mapa2[x, 0] == 1)
                    {
                        nVizinhosVivos++;
                    }
                    if (mapa2[x, y - 1] == 1)
                    {
                        nVizinhosVivos++;
                    }
                }
                else
                {
                    if (mapa2[nCol, y + 1] == 1)
                    {
                        nVizinhosVivos++;
                    }
                    if (mapa2[nCol, y - 1] == 1)
                    {
                        nVizinhosVivos++;
                    }
                    if (mapa2[nCol, y] == 1)
                    {
                        nVizinhosVivos++;
                    }
                    if (mapa2[x + 1, y + 1] == 1)
                    {
                        nVizinhosVivos++;
                    }
                    if (mapa2[x + 1, y - 1] == 1)
                    {
                        nVizinhosVivos++;
                    }
                    if (mapa2[x + 1, y] == 1)
                    {
                        nVizinhosVivos++;
                    }
                    if (mapa2[x, y + 1] == 1)
                    {
                        nVizinhosVivos++;
                    }
                    if (mapa2[x, y - 1] == 1)
                    {
                        nVizinhosVivos++;
                    }
                }

            }
            else
            {
                if (up)
                {

                    if (mapa2[x + 1, nLin] == 1)
                    {
                        nVizinhosVivos++;
                    }
                    if (mapa2[x + 1, y + 1] == 1)
                    {
                        nVizinhosVivos++;
                    }
                    if (mapa2[x + 1, y] == 1)
                    {
                        nVizinhosVivos++;
                    }
                    if (mapa2[x - 1, nLin] == 1)
                    {
                        nVizinhosVivos++;
                    }
                    if (mapa2[x - 1, y + 1] == 1)
                    {
                        nVizinhosVivos++;
                    }
                    if (mapa2[x - 1, y] == 1)
                    {
                        nVizinhosVivos++;
                    }
                    if (mapa2[x, nLin] == 1)
                    {
                        nVizinhosVivos++;
                    }
                    if (mapa2[x, y + 1] == 1)
                    {
                        nVizinhosVivos++;
                    }


                }
                else if (down)
                {
                    if (mapa2[x + 1, 0] == 1)
                    {
                        nVizinhosVivos++;
                    }
                    if (mapa2[x + 1, y - 1] == 1)
                    {
                        nVizinhosVivos++;
                    }
                    if (mapa2[x + 1, y] == 1)
                    {
                        nVizinhosVivos++;
                    }
                    if (mapa2[x - 1, 0] == 1)
                    {
                        nVizinhosVivos++;
                    }
                    if (mapa2[x - 1, y - 1] == 1)
                    {
                        nVizinhosVivos++;
                    }
                    if (mapa2[x - 1, y] == 1)
                    {
                        nVizinhosVivos++;
                    }
                    if (mapa2[x, 0] == 1)
                    {
                        nVizinhosVivos++;
                    }
                    if (mapa2[x, y - 1] == 1)
                    {
                        nVizinhosVivos++;
                    }
                }
                else
                {
                    if (mapa2[x + 1, y + 1] == 1)
                    {
                        nVizinhosVivos++;
                    }
                    if (mapa2[x + 1, y - 1] == 1)
                    {
                        nVizinhosVivos++;
                    }
                    if (mapa2[x + 1, y] == 1)
                    {
                        nVizinhosVivos++;
                    }
                    if (mapa2[x - 1, y + 1] == 1)
                    {
                        nVizinhosVivos++;
                    }
                    if (mapa2[x - 1, y - 1] == 1)
                    {
                        nVizinhosVivos++;
                    }
                    if (mapa2[x - 1, y] == 1)
                    {
                        nVizinhosVivos++;
                    }
                    if (mapa2[x, y + 1] == 1)
                    {
                        nVizinhosVivos++;
                    }
                    if (mapa2[x, y - 1] == 1)
                    {
                        nVizinhosVivos++;
                    }
                }

            }

           

           
            // TROCAR ESTADO

            if (mapa[posX, posY] == 1)
            {
                if (nVizinhosVivos < 2)
                {
                    mapa[posX, posY] = 0;
                }
                if (nVizinhosVivos > 3)
                {
                    mapa[posX, posY] = 0;
                }
            }
            else if (mapa[posX, posY] == 0)
            {
                if (nVizinhosVivos == 3)
                {
                    mapa[posX, posY] = 1;
                }
            }

        }
        public void CopConfigIni(GeraConfigIni ini, int nCol, int nLin)
        {

            mapa = new int[nCol, nLin];

            for (int i = 0; i < nLin; i++)
            {
                for (int j = 0; j < nCol; j++)
                {
                    mapa[j, i] = ini.getMapa(j, i);
                }
            }
        }

        public void colocarPlayer(int nCol, int nLin)
        {
            bool colocouPlayer = false;
            while (!colocouPlayer)
            {
                Random rand = new Random();
                int randCol = rand.Next(nCol);
                int randLin = rand.Next(nLin);

                if (mapa[randCol, randLin] == 0)
                {
                    mapa[randCol, randLin] = 2;

                    xPlayer = randCol;
                    yPlayer = randLin;

                    colocouPlayer = true;
                }
            }          
        }


        public void floodFill(int x, int y, int nCol, int nLin, int nCicle)
        {

            if (nFlags <= 0 && nNpcs <= 0)
            {
                return;
            }

            sorteio = rand.Next(100);

            nCicle += 1;
            ciclosFF = nCicle;

        
            if (x >= 0 && x <= nCol - 1)
            {
                if (y >= 0 && y <= nLin - 1)
                {
                    if (mapa[x, y] == 0 || mapa[x, y] == 2)  // Testa se é chão ou player
                    { 
                        if (nCicle > 10)
                        {
                            if (mapa[x, y] == 0)    // Caso chão
                            {
                                if (xPlayer + 5 < x || xPlayer - 5 > x && yPlayer + 5 < y || yPlayer - 5 < y)
                                {
                                    if (sorteio <= 10)
                                    {
                                        if (nNpcs > 0)
                                        {
                                            mapa[x, y] = 3;
                                            nNpcs--;
                                        }
                                    }
                                    else if (sorteio <= 20)
                                    {
                                        if (nFlags > 0)
                                        {
                                            mapa[x, y] = 4;
                                            nFlags--;
                                        }
                                    }
                                }
                            }
                        }                 

                        floodFill(x + 1, y, nCol, nLin, nCicle);
                        floodFill(x, y + 1, nCol, nLin, nCicle);
                        floodFill(x - 1, y, nCol, nLin, nCicle);
                        floodFill(x, y - 1, nCol, nLin, nCicle);
                    }
                }
            }  
        }

        public void CopMap(int nCol, int nLin)
        {
            mapa2 = new int[nCol, nLin];

            for (int i = 0; i < nLin; i++)
            {
                for (int j = 0; j < nCol; j++)
                {
                    mapa2[j, i] = mapa[j, i];
                }
            }
        }
       
        public int getMapa(int posX, int posY)
        {
            return mapa[posX, posY];
        }
        public int getMapa2(int posX, int posY)
        {
            return mapa2[posX, posY];
        }

        public int[,] getAllMap()
        {
            return mapa;
        }

        public int getX()
        {
            return xPlayer;
        }
        public int getY()
        {
            return yPlayer;
        }
        public void setFlags(int nFlags)
        {
            this.nFlags = nFlags;
        }

        public void setNpcs(int nNpcs)
        {
            this.nNpcs = nNpcs;
        }

        public int getCicles()
        {
            return ciclosFF;
        }
    }
}
