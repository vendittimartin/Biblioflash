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
        public int cantEjemplaresDisponibles(string pTitulo)
        {
            using (IUnitOfWork unitOfWork = new UnitOfWork(new AccountManagerDbContext()))
            {
                int cantEjemplaresDisponibles = 0;
                LibroDTO libroDTO = buscarLibro(pTitulo);
                List<Ejemplar> listaEjemplares = libroDTO.Ejemplares;
                if (listaEjemplares == null)
                {
                    cantEjemplaresDisponibles = 0;
                }
                else
                { 
                    foreach (var ejemplar in listaEjemplares)
                    {
                        if (ejemplar.estaDisponible())
                        {
                            cantEjemplaresDisponibles += 1; 
                        }
                    }
                }
                return cantEjemplaresDisponibles;
            }
        }
        public List<PrestamoDTO> listaPrestamos()
        {
            using (IUnitOfWork unitOfWork = new UnitOfWork(new AccountManagerDbContext()))
            {
                IEnumerable<Prestamo> listaPrestamo = unitOfWork.PrestamoRepository.GetAll();
                List<PrestamoDTO> listaPrestamosDTO = new List<PrestamoDTO>();
                foreach (var prestamo in listaPrestamo)
                {
                    PrestamoDTO prestamoDTO = new PrestamoDTO
                    {
                        IDEjemplar = prestamo.Ejemplar.ID,
                        FechaDevolucion = prestamo.FechaDevolucion,
                        FechaPrestamo = prestamo.FechaPrestamo,
                        FechaRealDevolucion = prestamo.FechaRealDevolucion,
                        Usuario = prestamo.Usuario
                    };
                    listaPrestamosDTO.Add(prestamoDTO);
                }
                return listaPrestamosDTO;
            }
        }
        public List<PrestamoDTO> prestamosPorUsuario(string pNombreUsuario)
        {
            using (IUnitOfWork unitOfWork = new UnitOfWork(new AccountManagerDbContext()))
            {
                List<PrestamoDTO> listaTodosLosPrestamos = listaPrestamos();
                List<PrestamoDTO> listaPrestamosPorUsuario = new List<PrestamoDTO>();
                foreach (var prestamo in listaTodosLosPrestamos)
                {
                    if (prestamo.Usuario.NombreUsuario == pNombreUsuario)
                    {
                        listaTodosLosPrestamos.Add(prestamo);
                    }
                }
                return listaTodosLosPrestamos;
            }
        }
        public UsuarioDTO buscarUsuario(string pNombreUsuario)
        {
            using (IUnitOfWork unitOfWork = new UnitOfWork(new AccountManagerDbContext()))
            {
                Usuario userToDTO = unitOfWork.UsuarioRepository.buscarUsuario(pNombreUsuario);
                if (userToDTO != null)
                {
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
                else { return null; }
            }
        }
        public List<Libro> consultaLibrosDisponibles()
        {
            using (IUnitOfWork unitOfWork = new UnitOfWork(new AccountManagerDbContext()))
            {
                return unitOfWork.LibroRepository.listaLibros();
            }
        }
        public LibroDTO buscarLibro(string pTitulo)
        {
            using (IUnitOfWork unitOfWork = new UnitOfWork(new AccountManagerDbContext()))
            {
                Libro LibroToDTO = unitOfWork.LibroRepository.buscarTitulo(pTitulo);
                if (LibroToDTO != null)
                {
                    LibroDTO libroDTO = new LibroDTO
                    {
                        ISBN = LibroToDTO.Isbn,
                        Titulo = LibroToDTO.Titulo,
                        Autor = LibroToDTO.Autor,
                        Ejemplares = LibroToDTO.Ejemplares
                    };
                    return libroDTO;
                }
                else { return null; }
            }
        }


        public void modificarUsuario(string pNombreUsuario, string pContraseña, string pMail, int pScore, Manager.Domain.Rango pRango)
        {
            using (IUnitOfWork unitOfWork = new UnitOfWork(new AccountManagerDbContext()))
            {
                Usuario user = unitOfWork.UsuarioRepository.buscarUsuario(pNombreUsuario);
                user.NombreUsuario = pNombreUsuario;
                user.Contraseña = pContraseña;
                user.Mail = pMail;
                user.Score = pScore;
                user.RangoUsuario = pRango;
                unitOfWork.Complete();
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
        public void agregarLibro(LibroDTO pLibroDTO)
        {
            using (IUnitOfWork unitOfWork = new UnitOfWork(new AccountManagerDbContext()))
            {
                Libro libroCargar = new Libro
                {
                    Isbn = pLibroDTO.ISBN,
                    Titulo = pLibroDTO.Titulo,
                    Autor = pLibroDTO.Autor
                };

                unitOfWork.LibroRepository.Add(libroCargar);
                unitOfWork.Complete();
            }
        }
        public void agregarEjemplar(EjemplarDTO pEjemplarDTO)
        {
            using (IUnitOfWork unitOfWork = new UnitOfWork(new AccountManagerDbContext()))
            {
                Libro libro = unitOfWork.LibroRepository.buscarISBN(pEjemplarDTO.Libro.ISBN);
                Ejemplar ejemplar = new Ejemplar
                {
                    Libro = libro,
                    Prestamos = pEjemplarDTO.Prestamos
                };
                unitOfWork.EjemplarRepository.Add(ejemplar);
                unitOfWork.Complete();
            }
        }
        public void cambiarRango(string pNombreUsuario)
        {
            using (IUnitOfWork unitOfWork = new UnitOfWork(new AccountManagerDbContext()))
            {
                UsuarioDTO userDTO = buscarUsuario(pNombreUsuario);
                if (userDTO.NombreUsuario == null)
                {
                   // throw new Exception
                }
                else 
                {
                    if (userDTO.RangoUsuario == Rango.Admin)
                    {
                        userDTO.RangoUsuario = Rango.Cliente;
                        unitOfWork.Complete();
                    }
                    else
                    {
                        userDTO.RangoUsuario = Rango.Admin;
                        unitOfWork.Complete();
                    }
                }
            }
        }

        public List<LibroDTO> consultaLibro(string pTituloLibro)
        {
            IconsultaAPI apiConsultas = new consultaAPI();
            return apiConsultas.Consulta(pTituloLibro);
        }
    }
}
