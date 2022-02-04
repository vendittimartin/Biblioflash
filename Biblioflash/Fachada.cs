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
                Usuario userToDTO = unitOfWork.UsuarioRepository.buscarUsuario(pNombreUsuario);
                UsuarioDTO usuarioDTO = new UsuarioDTO
                {
                    NombreUsuario = userToDTO.NombreUsuario,
                    Score = userToDTO.Score,
                    Mail = userToDTO.Mail,
                    RangoUsuario = userToDTO.RangoUsuario,
                    Contraseña = userToDTO.Contraseña
                };
                return usuarioDTO;
            }
        }

        public bool iniciarSesion(string pNombreUsuario, string pContraseña)
        {
            UsuarioDTO user = buscarUsuario(pNombreUsuario);
            if (user.NombreUsuario == null)
            {
                return false;
            }
            else 
            {
                if (user.Contraseña == pContraseña)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public void registrarUsuario(string pNombreUsuario, string pContraseña, string pMail)
        {
            using (IUnitOfWork unitOfWork = new UnitOfWork(new AccountManagerDbContext()))
            {
                Usuario user= new Usuario
                {
                    NombreUsuario = pNombreUsuario,
                    Score = 0,
                    Mail = pMail,
                    RangoUsuario = Rango.Cliente,
                    Contraseña = pContraseña
                };

                unitOfWork.UsuarioRepository.Add(user);
                unitOfWork.Complete();
            }  
        }

        public void registrarAdmin()
        {
            using (IUnitOfWork unitOfWork = new UnitOfWork(new AccountManagerDbContext()))
            {
                UsuarioDTO userDTO = buscarUsuario("admin");
                if (userDTO.NombreUsuario == null)
                { 
                    Usuario user = new Usuario
                    {
                        NombreUsuario = "admin",
                        Score = 0,
                        Mail = "admin",
                        RangoUsuario = Rango.Admin,
                        Contraseña = "admin"
                    };

                    unitOfWork.UsuarioRepository.Add(user);
                    unitOfWork.Complete();
                }
            }
        }
    }
}
