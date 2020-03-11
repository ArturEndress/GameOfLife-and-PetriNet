using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoL
{
    class CalcVizinho
    {
        //GeraConfigIni
        private int[,] mapa;
        private int[,] mapa2;
        //private int nVizinhosVivos = 0;

        public CalcVizinho()
        { }
        public void CalcularVizinho(int nCol, int nLin, int posX, int posY)
        {
            int x, y;
            int nVizinhosVivos = 0;

            bool right, left, up, down;

            //CALCULA VIZINHOS QUANDO POS ESTA NA PONTA DO MAPA
            //if (posX == 0)
            //{
            //    x = nCol;
            //}
            //else if (posX == nCol)
            //{
            //    x = 0;
            //}
            //else
            //{
            //    x = posX;
            //}

            //if (posY == 0)
            //{
            //    y = nLin;
            //}
            //else if (posY == nLin)
            //{
            //    y = 0;
            //}
            //else
            //{
            //    y = posY;
            //}

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

            for (int i = 0; i < nCol; i++)
            {
                for (int j = 0; j < nLin; j++)
                {
                    mapa[i, j] = ini.getMapa(i, j);
                }
            }
        }

        public void CopMap(int nCol, int nLin)
        {
            mapa2 = new int[nCol, nLin];

            for (int i = 0; i < nCol; i++)
            {
                for (int j = 0; j < nLin; j++)
                {
                    mapa2[i, j] = mapa[i, j];
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
    }
}
