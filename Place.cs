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
        private int _iD;
        private Boolean empty;
        private ArrayList tokensList;
    
        public Place(int id)
        {
            this._iD = id;
            this.empty = true;
            tokensList = new ArrayList();
        }
        public void addToken(Token token)
        {
            tokensList.Add(token);
        }
        public Boolean isEmpty()
        {
            return empty;
        }
        public int getId()
        {
            return _iD;
        }
    }
}
