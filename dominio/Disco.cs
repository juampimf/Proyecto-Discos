using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    //le agrego un comentario al archivo...
    public class Disco
    {
        public string titulo { get; set; }
        public int cantidadCanciones { get; set; }
        public DateTime fechaLanzamiento { get; set; }

        public string urlImagenTapa { get; set; }

        public Estilo GeneroMusical { get; set; }

        public TipoEdicion TipoEdicion { get; set; }
    }
}
