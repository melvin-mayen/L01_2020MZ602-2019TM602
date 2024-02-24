using System.ComponentModel.DataAnnotations;

namespace L01_2020MZ602_2019TM602.Models
{
    public class Comentarios
    {
        public int cometarioId { get; set; }

        public int publicacionId { get; set; }

        public string comentario{ get; set; }

        public int usuarioId { get; set; }

    }

}
