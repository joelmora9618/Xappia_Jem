using System;
using System.Collections.Generic;
using System.Linq;
using SQLite;
using System.Text;
using System.Threading.Tasks;

namespace Xappia_Jem.Model
{
    public class Tarea
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        [MaxLength(150)]
        public String Nombre { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Hora { get; set; }
        public Boolean Completada { get; set; }
    }
}
