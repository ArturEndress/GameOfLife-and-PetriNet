using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetriNet_engine_csharp
{
    class Token
    {
        protected int ID { get; set; }
        public Token(int id)
        {
            this.ID = id;
        }
        public Token()
        {           
        }
    }
}
