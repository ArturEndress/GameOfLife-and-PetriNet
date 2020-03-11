using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetriNet_engine_csharp
{
    class PetriNet
    {
        private ArrayList placeList;
        private ArrayList transitionList;
        public PetriNet()
        {
            placeList = new ArrayList();
            transitionList = new ArrayList();
        }

        public void execCycle()
        {
        }
        public void insertTransition(Transition transition)
        {
            transitionList.Add(transition);
        }
        public void insertPlace(Place place)
        {
            placeList.Add(place);
        }
        public Transition getTransition(int pos)
        {
            return (Transition) transitionList[pos];
        }
        public Place getPlace(int pos)
        {
            return (Place) placeList[pos];
        }

    }
}
