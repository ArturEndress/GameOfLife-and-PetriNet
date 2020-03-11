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
            Token tok = new Token(1);
            Place lugar = new Place(2);
            lugar.addToken(tok);
            Console.WriteLine("Place:" + lugar.getId() );

            PetriNet eng = new PetriNet();
            eng.insertPlace(new Place(3));
            eng.insertTransition(new Transition(0)); //0 eh o id da transition

            eng.getTransition(0).insertConnection(new Connection(eng.getPlace(0), true, false)); //de entrada, nao inibidor

            eng.execCycle();

            Console.WriteLine("transicao: " + eng.getTransition(0).getId());

            Console.WriteLine("quantas conexoes de entrada: " + eng.getTransition(0).connInList.Count);
            Console.WriteLine("quantas conexoes de saida: " + eng.getTransition(0).connOutList.Count);

            Console.WriteLine("lugar de entrada: " + ((Connection) eng.getTransition(0).connInList[0]).getPlace().getId());

            Console.ReadKey();
        }
    }
}
