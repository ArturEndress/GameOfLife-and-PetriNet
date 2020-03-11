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
        private ArrayList overLayerList;
        private ArrayList transitionList;
        private int[,] mapa;
        private int nFlags;
        

        public PetriNet()
        {
            placeList = new ArrayList();
            transitionList = new ArrayList();
            overLayerList = new ArrayList();
            nFlags = 0;
        }

        public void CreateNet(int[,] mapa, int nCol, int nLin)
        {
            this.mapa = mapa;

            for (int i = 0; i < nLin; i++)
            {
                for (int j = 0; j < nCol; j++)
                {
                    Place overLayer;
                    Place place;
                    place = new Place(mapa[j, i], j, i);
                    overLayer = new Place(mapa[j, i], j, i);
                    if (mapa[j, i] == 1)
                    {
                        overLayer.addToken(new Token());
                    }
                    if (mapa[j, i] == 2)
                    {
                        place.addToken(new Player());
                    }
                    if (mapa[j, i] == 3)
                    {
                        place.addToken(new Npc());
                    }
                    if (mapa[j, i] == 4)
                    {
                        place.addToken(new Flag());

                        nFlags++;
                    }

                    //if (i == 1 && j == 1)
                    //{
                    //    place.addToken(new Player());
                    //    place.setId(2);
                    //}
                    place.setPosLista(placeList.Count);
                    overLayer.setPosLista(overLayerList.Count);

                    placeList.Add(place);
                    overLayerList.Add(overLayer);

                   

                    if (j > 0)
                    {
                        Transition transition = new Transition(j - 1);
                        transition.insertConnection(new Connection((Place)placeList[j - 1 + i * nCol], 1, true, false));
                        transition.insertConnection(new Connection((Place)placeList[j + i * nCol], 1, false, false));
                        transition.insertConnection(new Connection((Place)overLayerList[j + i * nCol], 1, true, true));

                        transitionList.Add(transition);

                        transition = new Transition(j);
                        transition.insertConnection(new Connection((Place)placeList[j + i * nCol], 1, true, false));
                        transition.insertConnection(new Connection((Place)placeList[j - 1 + i * nCol], 1, false, false));
                        transition.insertConnection(new Connection((Place)overLayerList[j - 1 + i * nCol], 1, true, true));

                        transitionList.Add(transition);
                    }
                    if (i > 0)
                    {
                        Transition transition = new Transition(j);
                        transition.insertConnection(new Connection((Place)placeList[j + ((i - 1) * nCol)], 1, true, false));
                        transition.insertConnection(new Connection((Place)placeList[j + ((i - 1) * nCol) + nCol], 1, false, false));
                        transition.insertConnection(new Connection((Place)overLayerList[j + ((i - 1) * nCol) + nCol], 1, true, true));

                        transitionList.Add(transition);

                        transition = new Transition(i);
                        transition.insertConnection(new Connection((Place)placeList[j + ((i - 1) * nCol) + nCol], 1, true, false));
                        transition.insertConnection(new Connection((Place)placeList[j + ((i - 1) * nCol)], 1, false, false));
                        transition.insertConnection(new Connection((Place)overLayerList[j + ((i - 1) * nCol)], 1, true, true));

                        transitionList.Add(transition);
                    }
                }
            }


        }
        public void execCycle()
        {
            moveNpcs();
            movePlayer();
        }

        public void movePlayer()
        {
            Transition transition;
            Connection connection;





            for (int i = 0; i < placeList.Count; i++)
            {
                Place place = (Place)placeList[i];



                if (!place.isEmpty())
                {
                    if (place.getId() == 2)
                    {



                        Console.ReadKey();
                        Console.WriteLine("ID: {0}", place.getId());
                        Console.WriteLine("Para qual direcao vc quer andar?");
                        Console.WriteLine("Cima - 1");
                        Console.WriteLine("Baixo - 2");
                        Console.WriteLine("Direita - 3");
                        Console.WriteLine("Esquerda - 4");


                        int dir;
                        dir = Convert.ToInt32(Console.ReadLine());


                        for (int j = 0; j < transitionList.Count; j++)
                        {
                            transition = (Transition)transitionList[j];

                            transition.chekIfEnabled();



                            if (transition.isEnabled())
                            {



                                for (int k = 0; k < transition.connOutList.Count; k++)
                                {

                                    connection = (Connection)transition.connOutList[k];



                                    if (dir == 4)
                                    {
                                        if (place.getPos('c') > 0)
                                        {
                                            

                                            if (connection.getPlace().getPos('c') == place.getPos('c') - 1)
                                            {
                                                if (connection.getPlace().getPos('l') == place.getPos('l'))
                                                {
                                                    if (connection.getPlace().getId() == 4)
                                                    {
                                                        connection.getPlace().removeToken(0);
                                                        connection.getPlace().setId(0);
                                                        nFlags--;
                                                    }
                                                    if (place.nTokens() == 1)
                                                    {
                                                        place.removeToken(0);
                                                    }
                                                    else
                                                    {
                                                        place.removeToken(1);
                                                    }
                                                    
                                                    connection.getPlace().addToken(new Player());

                                                    //TROCA ID
                                                    if (connection.getPlace().getId() == 0)
                                                    {
                                                        place.setId(0);
                                                        connection.getPlace().setId(2);

                                                        placeList[i] = place;
                                                    }
                                                    else
                                                    {
                                                        place.setId(3);
                                                        connection.getPlace().setId(2);

                                                        placeList[i] = place;
                                                    }
                                                    placeList[connection.getPlace().getPosLista()] = connection.getPlace();
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                    if (dir == 1)
                                    {
                                        if (place.getPos('l') > 0)
                                        {
                                            if (connection.getPlace().getPos('l') == place.getPos('l') - 1)
                                            {
                                                if (connection.getPlace().getPos('c') == place.getPos('c'))
                                                {
                                                    if (connection.getPlace().getId() == 4)
                                                    {
                                                        connection.getPlace().removeToken(0);
                                                        nFlags--;
                                                    }

                                                    if (place.nTokens() == 1)
                                                    {
                                                        place.removeToken(0);
                                                    }
                                                    else
                                                    {
                                                        place.removeToken(1);
                                                    }

                                                    connection.getPlace().addToken(new Player());

                                                    //TROCA ID
                                                    if (connection.getPlace().getId() == 0)
                                                    {
                                                        place.setId(0);
                                                        connection.getPlace().setId(2);

                                                        placeList[i] = place;
                                                    }
                                                    else
                                                    {
                                                        place.setId(3);
                                                        connection.getPlace().setId(2);

                                                        placeList[i] = place;
                                                    }

                                                    placeList[connection.getPlace().getPosLista()] = connection.getPlace();
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                    if (dir == 3)
                                    {
                                        if (place.getPos('c') < 20)
                                        {
                                            if (connection.getPlace().getPos('c') == place.getPos('c') + 1)
                                            {
                                                if (connection.getPlace().getPos('l') == place.getPos('l'))
                                                {
                                                    if (connection.getPlace().getId() == 4)
                                                    {
                                                        connection.getPlace().removeToken(0);
                                                        nFlags--;
                                                    }


                                                    if (place.nTokens() == 1)
                                                    {
                                                        place.removeToken(0);
                                                    }
                                                    else
                                                    {
                                                        place.removeToken(1);
                                                    }

                                                    connection.getPlace().addToken(new Player());

                                                    //TROCA ID
                                                    if (connection.getPlace().getId() == 0)
                                                    {
                                                        place.setId(0);
                                                        connection.getPlace().setId(2);

                                                        placeList[i] = place;
                                                    }
                                                    else
                                                    {
                                                        place.setId(3);
                                                        connection.getPlace().setId(2);

                                                        placeList[i] = place;
                                                    }


                                                    placeList[connection.getPlace().getPosLista()] = connection.getPlace();
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                    if (dir == 2)
                                    {
                                        if (place.getPos('l') < 20)
                                        {
                                            if (connection.getPlace().getPos('l') == place.getPos('l') + 1)
                                            {
                                                if (connection.getPlace().getPos('c') == place.getPos('c'))
                                                {
                                                    if (connection.getPlace().getId() == 4)
                                                    {
                                                        connection.getPlace().removeToken(0);
                                                        nFlags--;
                                                    }


                                                    if (place.nTokens() == 1)
                                                    {
                                                        place.removeToken(0);
                                                    }
                                                    else
                                                    {
                                                        place.removeToken(1);
                                                    }

                                                    connection.getPlace().addToken(new Player());

                                                    //TROCA ID
                                                    if (connection.getPlace().getId() == 0)
                                                    {
                                                        place.setId(0);
                                                        connection.getPlace().setId(2);

                                                        placeList[i] = place;
                                                    }
                                                    else
                                                    {
                                                        place.setId(3);
                                                        connection.getPlace().setId(2);

                                                        placeList[i] = place;
                                                    }


                                                    placeList[connection.getPlace().getPosLista()] = connection.getPlace();
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    }
                }
            }
        }

        public void moveNpcs()
        {
            Transition transition;
            Connection connection;

            Random random = new Random();
            



            for (int i = 0; i < placeList.Count; i++)
            {
                Place place = (Place)placeList[i];



                if (!place.isEmpty())
                {
                    if (place.getId() == 3)
                    {

                        int dir = random.Next(1, 4);
                        
                        for (int j = 0; j < transitionList.Count; j++)
                        {
                            transition = (Transition)transitionList[j];

                            transition.chekIfEnabled();



                            if (transition.isEnabled())
                            {



                                for (int k = 0; k < transition.connOutList.Count; k++)
                                {

                                    connection = (Connection)transition.connOutList[k];



                                    if (dir == 4)
                                    {
                                        if (place.getPos('c') > 0)
                                        {
                                            
                                            if (connection.getPlace().getPos('c') == place.getPos('c') - 1)
                                            {
                                                if (connection.getPlace().getPos('l') == place.getPos('l'))
                                                {


                                                    if (place.nTokens() == 1)
                                                    {
                                                        place.removeToken(0);
                                                    }
                                                    else
                                                    {
                                                        place.removeToken(1);
                                                    }

                                                    connection.getPlace().addToken(new Npc());

                                                    //TROCA ID
                                                    if (connection.getPlace().getId() == 0)
                                                    {
                                                        place.setId(0);
                                                        connection.getPlace().setId(3);

                                                        placeList[i] = place;
                                                    }
                                                    else if (connection.getPlace().getId() == 2)
                                                    {
                                                        place.setId(2);
                                                        connection.getPlace().setId(3);

                                                        placeList[i] = place;
                                                    }
                                                    else if (connection.getPlace().getId() == 4)
                                                    {
                                                        place.setId(4);
                                                        connection.getPlace().setId(3);

                                                        placeList[i] = place;
                                                    }


                                                    placeList[connection.getPlace().getPosLista()] = connection.getPlace();
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                    if (dir == 1)
                                    {
                                        if (place.getPos('l') > 0)
                                        {
                                            if (connection.getPlace().getPos('l') == place.getPos('l') - 1)
                                            {
                                                if (connection.getPlace().getPos('c') == place.getPos('c'))
                                                {
                                                    if (place.nTokens() == 1)
                                                    {
                                                        place.removeToken(0);
                                                    }
                                                    else
                                                    {
                                                        place.removeToken(1);
                                                    }

                                                    connection.getPlace().addToken(new Npc());

                                                    //TROCA ID
                                                    if (connection.getPlace().getId() == 0)
                                                    {
                                                        place.setId(0);
                                                        connection.getPlace().setId(3);

                                                        placeList[i] = place;
                                                    }
                                                    else if (connection.getPlace().getId() == 2)
                                                    {
                                                        place.setId(2);
                                                        connection.getPlace().setId(3);

                                                        placeList[i] = place;
                                                    }
                                                    else if (connection.getPlace().getId() == 4)
                                                    {
                                                        place.setId(4);
                                                        connection.getPlace().setId(3);

                                                        placeList[i] = place;
                                                    }


                                                    placeList[connection.getPlace().getPosLista()] = connection.getPlace();
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                    if (dir == 3)
                                    {
                                        if (place.getPos('c') < 20)
                                        {
                                            if (connection.getPlace().getPos('c') == place.getPos('c') + 1)
                                            {
                                                if (connection.getPlace().getPos('l') == place.getPos('l'))
                                                {
                                                    if (place.nTokens() == 1)
                                                    {
                                                        place.removeToken(0);
                                                    }
                                                    else
                                                    {
                                                        place.removeToken(1);
                                                    }

                                                    connection.getPlace().addToken(new Npc());

                                                    //TROCA ID
                                                    if (connection.getPlace().getId() == 0)
                                                    {
                                                        place.setId(0);
                                                        connection.getPlace().setId(3);

                                                        placeList[i] = place;
                                                    }
                                                    else if (connection.getPlace().getId() == 2)
                                                    {
                                                        place.setId(2);
                                                        connection.getPlace().setId(3);

                                                        placeList[i] = place;
                                                    }
                                                    else if (connection.getPlace().getId() == 4)
                                                    {
                                                        place.setId(4);
                                                        connection.getPlace().setId(3);

                                                        placeList[i] = place;
                                                    }


                                                    placeList[connection.getPlace().getPosLista()] = connection.getPlace();
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                    if (dir == 2)
                                    {
                                        if (place.getPos('l') < 20)
                                        {
                                            if (connection.getPlace().getPos('l') == place.getPos('l') + 1)
                                            {
                                                if (connection.getPlace().getPos('c') == place.getPos('c'))
                                                {
                                                    if (place.nTokens() == 1)
                                                    {
                                                        place.removeToken(0);
                                                    }
                                                    else
                                                    {
                                                        place.removeToken(1);
                                                    }

                                                    connection.getPlace().addToken(new Npc());

                                                    //TROCA ID
                                                    if (connection.getPlace().getId() == 0)
                                                    {
                                                        place.setId(0);
                                                        connection.getPlace().setId(3);

                                                        placeList[i] = place;
                                                    }
                                                    else if (connection.getPlace().getId() == 2)
                                                    {
                                                        place.setId(2);
                                                        connection.getPlace().setId(3);

                                                        placeList[i] = place;
                                                    }
                                                    else if (connection.getPlace().getId() == 4)
                                                    {
                                                        place.setId(4);
                                                        connection.getPlace().setId(3);

                                                        placeList[i] = place;
                                                    }


                                                    placeList[connection.getPlace().getPosLista()] = connection.getPlace();
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    }
                }
            }
        }

        public void desenhaRede(int nCol)
        {
            ////////// DESENHA REDE

            Console.WriteLine("NCOL: {0}, PlaceCount: {1} ", nCol, placeList.Count);

            for (int n = 0; n < placeList.Count; n++)
            {
                Place place = (Place)placeList[n];

                if (n % nCol == 0)
                {
                    Console.WriteLine();
                }

                if (place.getId() == 1)
                {
                    Console.Write("X" + " ");
                }
                else if (place.getId() == 2)
                {
                    Console.Write("O" + " ");
                }
                else if (place.getId() == 3)
                {
                    Console.Write("N" + " ");
                }
                else if (place.getId() == 4)
                {
                    Console.Write("F" + " ");
                }
                else
                {
                    Console.Write("-" + " ");
                }
            }
            Console.WriteLine();
            Console.ReadKey();
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
            return (Transition)transitionList[pos];
        }
        public Place getPlace(int pos)
        {
            return (Place)placeList[pos];
        }
        public int nPlaces()
        {
            return placeList.Count;
        }
        public Place getOverLayer(int pos)
        {
            return (Place) overLayerList[pos];
        }
       public int getFlags()
        {
            return nFlags;
        }
    }
}
