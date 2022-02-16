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
        public List<Ejemplar> listaEjemplaresDisponibles(LibroDTO pLibro)
        {
            using (IUnitOfWork unitOfWork = new UnitOfWork(new AccountManagerDbContext()))
            {
                List<Ejemplar> listaEjemplaresDisponibles = new List<Ejemplar>();
                foreach (var ejemplar in pLibro.Ejemplares)
                    {
                        if (ejemplar.estaDisponible())
                        {
                            listaEjemplaresDisponibles.Add(ejemplar);
                        }
                    }
                return listaEjemplaresDisponibles;
            }
        }
        public List<PrestamoDTO> listaPrestamos()
        {
            using (IUnitOfWork unitOfWork = new UnitOfWork(new AccountManagerDbContext()))
            {
                IEnumerable<Prestamo> listaUsuario = unitOfWork.PrestamoRepository.GetAll();
                List<PrestamoDTO> listaUsuariosDTO = new List<PrestamoDTO>();
                foreach (var usuario in listaUsuario)
                {
                    PrestamoDTO usuarioDTO = new PrestamoDTO
                    {
                        ID = usuario.ID,
                        FechaDevolucion = usuario.FechaDevolucion,
                        FechaPrestamo = usuario.FechaPrestamo,
                        FechaRealDevolucion = usuario.FechaRealDevolucion,
                    };
                    usuarioDTO.Usuario = recuperarUsuario(usuarioDTO);
                    Ejemplar ej = recuperarID(usuarioDTO);
                    usuarioDTO.IDEjemplar = ej.ID;
                    usuarioDTO.Libro = recuperarLibro(usuarioDTO);
                    listaUsuariosDTO.Add(usuarioDTO);
                }
                return listaUsuariosDTO;
            }
        }
        public Usuario recuperarUsuario(PrestamoDTO pPrestamo)
        {
            using (IUnitOfWork unitOfWork = new UnitOfWork(new AccountManagerDbContext()))
            {
                Prestamo prestamo = unitOfWork.PrestamoRepository.Get(pPrestamo.ID);
                return prestamo.Usuario;
            }
        }
        public Libro recuperarLibro(PrestamoDTO pPrestamo)
        {
            using (IUnitOfWork unitOfWork = new UnitOfWork(new AccountManagerDbContext()))
            {
                Prestamo prestamo = unitOfWork.PrestamoRepository.Get(pPrestamo.ID);
                return prestamo.Ejemplar.Libro;
            }
        }
        public Ejemplar recuperarID(PrestamoDTO pPrestamo)
        {
            using (IUnitOfWork unitOfWork = new UnitOfWork(new AccountManagerDbContext()))
            {
                Prestamo prestamo = unitOfWork.PrestamoRepository.Get(pPrestamo.ID);
                return prestamo.Ejemplar;
            }
        }
        public PrestamoDTO prestamosPorID(Int64 pID)
        {
            using (IUnitOfWork unitOfWork = new UnitOfWork(new AccountManagerDbContext()))
            {
                List<PrestamoDTO> listaTodosLosPrestamos = listaPrestamos();
                PrestamoDTO prestamoADevolver = new PrestamoDTO();
                foreach (var prestamo in listaTodosLosPrestamos.ToList())
                {
                    if (prestamo.ID == pID)
                    {
                        prestamoADevolver = prestamo;
                    }
                }
                return prestamoADevolver;
            }
        }
        public bool extenderPrestamo(PrestamoDTO pPrestamo, int cantDias)
        {
            using (IUnitOfWork unitOfWork = new UnitOfWork(new AccountManagerDbContext()))
            {
                if (pPrestamo.Usuario.Score >= 5 * cantDias)
                {
                    Prestamo prestamo = unitOfWork.PrestamoRepository.buscarPrestamo(pPrestamo.ID);
                    prestamo.FechaDevolucion = prestamo.FechaDevolucion.AddDays(cantDias);
                    unitOfWork.Complete();
                    return true;
                }
                else
                {
                    unitOfWork.Complete();
                    return false;
                }
            }
        }
        public List<PrestamoDTO> prestamosPorUsuario(string pNombreUsuario)
        {
            using (IUnitOfWork unitOfWork = new UnitOfWork(new AccountManagerDbContext()))
            {
                List<PrestamoDTO> listaTodosLosPrestamos = listaPrestamos();
                List<PrestamoDTO> listaPrestamosPorUsuario = new List<PrestamoDTO>();
                foreach (var prestamo in listaTodosLosPrestamos.ToList())
                {
                    if (prestamo.Usuario.NombreUsuario == pNombreUsuario)
                    {
                        listaPrestamosPorUsuario.Add(prestamo);
                    }
                }
                return listaPrestamosPorUsuario;
            }
        }
        public List<PrestamoDTO> prestamosPorEjemplar(int pIdEjemplar)
        {
            using (IUnitOfWork unitOfWork = new UnitOfWork(new AccountManagerDbContext()))
            {
                List<PrestamoDTO> listaTodosLosPrestamos = listaPrestamos();
                List<PrestamoDTO> listaPrestamosPorUsuario = new List<PrestamoDTO>();
                foreach (var prestamo in listaTodosLosPrestamos.ToList())
                {
                    if (prestamo.IDEjemplar == pIdEjemplar)
                    {
                        listaPrestamosPorUsuario.Add(prestamo);
                    }
                }
                return listaPrestamosPorUsuario;
            }
        }
        public void registrarPrestamo(string pUsuario, Int64 pEjemplarID, string pEstado)
        {
            using (IUnitOfWork unitOfWork = new UnitOfWork(new AccountManagerDbContext()))
            {
                Usuario usuario = unitOfWork.UsuarioRepository.buscarUsuario(pUsuario);
                Ejemplar ejemplar = unitOfWork.EjemplarRepository.Get(pEjemplarID);
                Prestamo prestamo = new Prestamo
                    {
                        FechaPrestamo = DateTime.Now,
                        FechaDevolucion = DateTime.Now.AddDays(5),
                        Ejemplar = ejemplar,
                        Usuario = usuario,
                        estadoPrestamo = pEstado
                    };
                    ejemplar.Prestamos.Add(prestamo);
                    usuario.Prestamos.Add(prestamo);
                    unitOfWork.PrestamoRepository.Add(prestamo);
                    unitOfWork.Complete();
            }
        }

        public void registrarDevolucion(Int64 pPrestamoID, string pEstado)
        {
            using (IUnitOfWork unitOfWork = new UnitOfWork(new AccountManagerDbContext()))
            {
                Prestamo prestamo = unitOfWork.PrestamoRepository.Get(pPrestamoID);
                int diasAtrasados = prestamo.diasAtrasados();
                if (diasAtrasados != 0)
                {
                    prestamo.Usuario.Score -= (2 * diasAtrasados);
                }

                if (pEstado == "Malo")
                {
                    prestamo.Usuario.Score -= 10;
                }
                else
                {
                    prestamo.Usuario.Score += 5;
                }
                prestamo.registrarDevolucion();
                unitOfWork.Complete();
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
                    Libro = libro
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
