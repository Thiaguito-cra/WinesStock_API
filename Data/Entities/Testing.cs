using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Testing
    {
        //6.  Agregar Entidad Cata**: Crear una entidad `Cata` con atributos 
        //     fecha, nombre, vinos y lista de invitados(Lista de strings). 
        //     Esta entidad deberá tener una relación con los vinos.
        public int Id { get; set; }
        public DateTime Date{ get; set; }

        public string Name { get; set; }

        public string Wine { get; set; }

        public List<string> Guest { get; set; }
        public List<Wine> Wines { get; set; }

    }
}
