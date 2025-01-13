using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Dominio
{
    public class Pokemon
    {
        //sirve para dar nombre a la columna:anotation
        [DisplayName("Número")]
        public int Numero { get; set; } //necesito q lleve tilde. (mirar arriba)
        public string Nombre { get; set; }

        [DisplayName("Descripción")]
        public string Descripcion { get; set; }
        public string UrlImagen { get; set; }
        public Elemento Tipo { get; set; }

        public Elemento Debilidad{ get; set; }


    }
}
