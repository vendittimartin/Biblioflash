using System;
using System.Collections.Generic;
using Biblioflash.Manager.Services;

namespace Biblioflash.Manager.Domain
{
    public class Usuario
    {
        public Int64 ID { get; set; }
        public int Score { get; set; }
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }
        public string Mail { get; set; }
        public Rango RangoUsuario { get; set; }
        public virtual List<Prestamo> Prestamos { get; set; } = new List<Prestamo>();
        public bool ExtenderPrestamo(int CantDias)
        {
            if (this.Score >= CantDias * 5)
            {
                return true;
            }
            else {
                return false;
            }
        }
        
        public void setContraseña(string pContraseña) {
            this.Contraseña = Encriptador.GetSHA256(pContraseña);
        }
    }
}
