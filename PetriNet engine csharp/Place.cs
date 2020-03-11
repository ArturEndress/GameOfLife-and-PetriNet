using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetriNet_engine_csharp
{
    class Place
    {
        private int _iD, posCol, posLin;
        private Boolean empty;
        private ArrayList tokensList;
        private int posLista;
    
        public Place(int id, int posCol, int posLin)
        {
            this._iD = id;
            this.empty = true;
            this.posCol = posCol;
            this.posLin = posLin;
            tokensList = new ArrayList();
        }
        public void addToken(Token token)
        {
            tokensList.Add(token);
            empty = false;
        }
        public void removeToken(int pos)
        {
            if (!empty)
            {
                tokensList.RemoveAt(pos);
                if (tokensList.Count == 0)
                {
                    empty = true;
                }
            }
        }


        public Boolean isEmpty()
        {
            return empty;
        }
        public int getId()
        {
            return _iD;
        }
        public int nTokens()
        {
            return tokensList.Count;
        }
        public int getPos(char pos)
        {
            if (pos == 'c')
            {
                return posCol;
            }
            if (pos == 'l')
            {
                return posLin;
            }
            else
                return 0;
        }

        public void setId(int id)
        {
            _iD = id;
        }

        public void setPosLista(int pos)
        {
            posLista = pos;
        }
        public int getPosLista()
        {
            return posLista;
        }
    }
}
