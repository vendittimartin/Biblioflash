using Biblioflash.Manager.Domain;

namespace Biblioflash.Manager.DTO
{
    public class UsuarioDTO
    {
        public string NombreUsuario { get; set; }

        public int Score { get; set; }

        public Rango RangoUsuario { get; set; }

        public string Mail { get; set; }
        public string Contraseña { get; set; }
    }
}
