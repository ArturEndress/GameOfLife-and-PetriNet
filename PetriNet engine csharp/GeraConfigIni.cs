using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetriNet_engine_csharp
{
    class GeraConfigIni
    {
        private int[,] mapa;
        Random random = new Random();
        int randomNum;
        public GeraConfigIni(int nCol, int nLin)
        {

            mapa = new int[nCol,nLin];

            for (int i = 0; i < nLin; i++)
            {
                for (int j = 0; j < nCol; j++)
                {
                    randomNum = random.Next(100);
                    if (randomNum <= 25)
                    {
                        mapa[j , i] = 1;
                    }
                    else
                    {
                        mapa[j , i] = 0;
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
