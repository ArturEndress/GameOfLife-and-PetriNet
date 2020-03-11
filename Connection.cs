using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetriNet_engine_csharp
{
    class Connection
    {
        private Boolean inhibitorArc;
        private Boolean entryArc;
        private Place place;

        public Connection()
        {
        }
        public Connection(Place place, Boolean entryArc, Boolean inhibitorArc)
        {
            this.inhibitorArc = inhibitorArc;
            this.entryArc = entryArc;
            this.place = place;
        }
        public Boolean isInhibitorArc()
        {
            return inhibitorArc;
        }
        public Boolean isEntryArc()
        {
            return entryArc;
        }
        public Place getPlace()
        {
            return place;
        }
    }
}
