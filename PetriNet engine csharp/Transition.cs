using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetriNet_engine_csharp
{
    class Transition
    {
        private int id;
        private bool enabled;
        public ArrayList connInList;
        public ArrayList connOutList;

        public Transition(int id)
        {
            connInList = new ArrayList();   // Conexões de entrada
            connOutList = new ArrayList();  // Conexões de saída
            enabled = false;
            this.id = id;
            
        }
         public Boolean isEnabled()
        {
            return enabled;
        }
        public void insertConnection(Connection conn)
        {
            // Insere conexões nas suas respectivas listas 

            if (conn.isEntryArc())
            {
                connInList.Add(conn);
            } else
            {
                connOutList.Add(conn);
            }
            
        }
        public int getId()
        {
            return id;
        }
        public void chekIfEnabled()
        {
            Connection connection;

            for (int i = 0; i < connInList.Count; i++)
            {
                connection = (Connection) connInList[i];    // Lista (do tipo Connection) de conexões de entrada
                if (connection.isInhibitorArc())
                {
                    if (connection.getPlace().nTokens() >= connection.getWeight())
                    {
                        enabled = false;
                        break;
                    }

                    else
                    {
                        enabled = true;                        
                    }
                }
                else
                {
                    if (connection.getPlace().nTokens() >= connection.getWeight())
                    {
                        enabled = true;
                    }
                    else
                    {
                        enabled = false;
                        break;
                    }
                }
            }
        }
    }
}
