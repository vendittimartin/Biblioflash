using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioflash.Manager.API;
using Biblioflash.Manager.DTO;
using Biblioflash.Manager.Domain;
using Biblioflash.Manager.DAL;
using Biblioflash.Manager.DAL.EntityFramework;


namespace Biblioflash
{
    public class Fachada
    {
        public List<UsuarioDTO> listaUsuarios()
        {
            using (IUnitOfWork unitOfWork = new UnitOfWork(new AccountManagerDbContext()))
            {
                IEnumerable<Usuario> listaUsuario = unitOfWork.UsuarioRepository.GetAll();
                List<UsuarioDTO> listaUsuariosDTO = new List<UsuarioDTO>();
                foreach (var usuario in listaUsuario)
                {
                    UsuarioDTO usuarioDTO = new UsuarioDTO
                    {
                        NombreUsuario = usuario.NombreUsuario,
                        Score = usuario.Score,
                        Mail = usuario.Mail,
                        RangoUsuario = usuario.RangoUsuario
                    };
                    listaUsuariosDTO.Add(usuarioDTO);
                }

                return listaUsuariosDTO;
            }
        }
        public UsuarioDTO buscarUsuario(string pNombreUsuario)
        {
            using (IUnitOfWork unitOfWork = new UnitOfWork(new AccountManagerDbContext()))
            {
                Usuario usertoDTO = unitOfWork.UsuarioRepository.buscarUsuario(pNombreUsuario);
                UsuarioDTO usuarioDTO = new UsuarioDTO
                {
                    NombreUsuario = usertoDTO.NombreUsuario,
                    Score = usertoDTO.Score,
                    Mail = usertoDTO.Mail,
                    RangoUsuario = usertoDTO.RangoUsuario
                };
                return usuarioDTO;
            }
        }

        public bool iniciarSesion(string pNombreUsuario, string pContraseña)
        { 

        }
    }
}
