using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    //le agrego un comentario al archivo...
    public class Disco
    {
        [DisplayName("Título")]
        public string titulo { get; set; }

        [DisplayName("Cantidad de Canciones")]
        public int cantidadCanciones { get; set; }

        [DisplayName("Fecha de Lanzamiento")]
        public DateTime fechaLanzamiento { get; set; }

        [DisplayName("Imagen Tapa")]
        public string urlImagenTapa { get; set; }

        [DisplayName("Género Musical")]

        public Estilo GeneroMusical { get; set; }

        [DisplayName("Tipo de Edición")]

        public TipoEdicion TipoEdicion { get; set; }
    }
}
