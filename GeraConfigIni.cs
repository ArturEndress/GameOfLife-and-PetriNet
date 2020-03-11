using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoL
{
    class GeraConfigIni
    {
        private int[,] mapa;
        Random random = new Random();
        int randomNum;
        public GeraConfigIni(int nCol, int nLin)
        {

            mapa = new int[nLin,nCol];

            for (int i = 0; i < nCol; i++)
            {
                for (int j = 0; j < nLin; j++)
                {
                    randomNum = random.Next(100);
                    if (randomNum <= 25)
                    {
                        mapa[i , j] = 1;
                    }
                    else
                    {
                        mapa[i , j] = 0;
                    }
                }

            }
        }
        public int getMapa(int posX, int posY)
        {
            return mapa[posX , posY];
        }
    }
}
