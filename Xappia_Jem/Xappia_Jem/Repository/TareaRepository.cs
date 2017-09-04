using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xappia_Jem.Model;

namespace Xappia_Jem.Repository
{
    public class TareaRepository
    {
        public static int insertTarea(Tarea nuevaTarea)
        {
            int resultado = 0;
            using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(App.RutaDB))
            {
                connection.CreateTable<Tarea>();

                resultado = connection.Insert(nuevaTarea);
            }
            return resultado;
        }
    }
}
