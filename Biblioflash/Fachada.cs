using System;
using System.Collections.Generic;
using System.Linq;
using Biblioflash.Manager.API;
using Biblioflash.Manager.DTO;
using Biblioflash.Manager.Domain;
using Biblioflash.Manager.DAL;
using Biblioflash.Manager.DAL.EntityFramework;
using Biblioflash.Manager.Exceptions;
using Biblioflash.Manager.Log;
using System.IO;
using System.Reflection;



namespace Biblioflash
{
    public class Fachada
    {
        EnvioMails em = new EnvioMails();
        Log oLog = new Log($@"{Directory.GetCurrentDirectory()}\Log"); //Se obtiene la direccion de instalacion del programa para guardar el log en ella
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
        public void notificarUsuarios() //Notificar usuarios con préstamos próximos a vencerse (48hs) verificando que ese préstamo no esté previamente notificado
        {
            List<PrestamoDTO> listaTodosLosPrestamos = listaPrestamos();
            foreach (var prestamo in listaTodosLosPrestamos)
            {
                if (prestamo.FechaRealDevolucion == null)
                {
                    if (prestamo.FechaDevolucion < DateTime.Now.AddDays(2))
                    {
                        using (IUnitOfWork unitOfWork = new UnitOfWork(new AccountManagerDbContext()))
                        {
                            Prestamo prestamo1 = unitOfWork.PrestamoRepository.buscarPrestamo(prestamo.ID);
                            Notificacion notificacion = unitOfWork.NotificacionRepository.buscarNotificacion(prestamo.ID);
                            if (notificacion == null)
                            {
                                Notificacion notif = new Notificacion
                                {
                                    Usuario = prestamo1.Usuario,
                                    Prestamo = prestamo1,
                                    Fecha = DateTime.Now,
                                    Descripcion = "Su prestamo está próximo a vencerse."
                            };
                                unitOfWork.NotificacionRepository.Add(notif);
                                unitOfWork.Complete();
                                em.EnviarMail(notif);
                                oLog.Add("Se notifico un usuario");
                            }
                        }
                    }
                }
            }
        }
        public int cantEjemplaresDisponibles(string pTitulo)
        {
            using (IUnitOfWork unitOfWork = new UnitOfWork(new AccountManagerDbContext()))
            {
                int cantEjemplaresDisponibles = 0;
                Libro libroDTO = unitOfWork.LibroRepository.buscarTitulo(pTitulo);
                if (libroDTO.Ejemplares.Count() == 0)
                {
                    return 0;
                }
                else
                { 
                    foreach (var ejemplar in libroDTO.Ejemplares)
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
                Libro libroDTO = unitOfWork.LibroRepository.buscarTitulo(pLibro.Titulo);
                List<Ejemplar> listaEjemplares = libroDTO.Ejemplares;
                List<Ejemplar> listaEjemplaresDisponibles = new List<Ejemplar>();
                if (listaEjemplares == null)
                {
                    return null;
                }
                else
                {
                    foreach (var ejemplar in listaEjemplares)
                    {
                        if (ejemplar.estaDisponible())
                        {
                            listaEjemplaresDisponibles.Add(ejemplar);
                        }
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
        public Usuario recuperarUsuario(PrestamoDTO pPrestamo) //Se obtienen los datos de un usuario asociado al préstamo indicado
        {
            using (IUnitOfWork unitOfWork = new UnitOfWork(new AccountManagerDbContext()))
            {
                return unitOfWork.PrestamoRepository.Get(pPrestamo.ID).Usuario;
            }
        }
        public Libro recuperarLibro(PrestamoDTO pPrestamo) //Se obtienen los datos de un libro asociado al préstamo indicado
        {
            using (IUnitOfWork unitOfWork = new UnitOfWork(new AccountManagerDbContext()))
            {
                return unitOfWork.PrestamoRepository.Get(pPrestamo.ID).Ejemplar.Libro;
            }
        }
        public Prestamo recuperarPrestamo(PrestamoDTO pPrestamo)
        {
            using (IUnitOfWork unitOfWork = new UnitOfWork(new AccountManagerDbContext()))
            {
                return unitOfWork.PrestamoRepository.Get(pPrestamo.ID);
            }
        }
        public Ejemplar recuperarID(PrestamoDTO pPrestamo) 
        {
            using (IUnitOfWork unitOfWork = new UnitOfWork(new AccountManagerDbContext()))
            {
                return unitOfWork.PrestamoRepository.Get(pPrestamo.ID).Ejemplar;
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
        public bool extenderPrestamo(PrestamoDTO pPrestamo, int cantDias) //Se extiende la fecha de devolución de un préstamo verificando que los días indicados sean posibles debido a su score
        {
            using (IUnitOfWork unitOfWork = new UnitOfWork(new AccountManagerDbContext()))
            {
                if (pPrestamo.Usuario.Score >= 5 * cantDias)
                {
                    Prestamo prestamo = unitOfWork.PrestamoRepository.buscarPrestamo(pPrestamo.ID);
                    prestamo.FechaDevolucion = prestamo.FechaDevolucion.AddDays(cantDias);
                    unitOfWork.Complete();
                    oLog.Add($"Se extendió un prestamo");
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public List<PrestamoDTO> prestamosPorUsuarioX(string pNombreUsuario) //Lista de todos los préstamos de un usuario en formato DTO
        {
            using (IUnitOfWork unitOfWork = new UnitOfWork(new AccountManagerDbContext()))
            { 
                List<Prestamo> listaTodosLosPrestamos = unitOfWork.UsuarioRepository.buscarUsuario(pNombreUsuario).Prestamos;
                List<PrestamoDTO> listaPrestamosPorUsuario = new List<PrestamoDTO>();
                foreach (var prestamo in listaTodosLosPrestamos.ToList())
                {
                    PrestamoDTO prestamo1 = new PrestamoDTO
                    {
                        Usuario = prestamo.Usuario,
                        IDEjemplar = prestamo.Ejemplar.ID,
                        FechaPrestamo = prestamo.FechaPrestamo,
                        FechaDevolucion = prestamo.FechaDevolucion,
                        FechaRealDevolucion = prestamo.FechaRealDevolucion,
                        ID = prestamo.ID,
                        estadoDevolucion = prestamo.estadoPrestamo
                    };
                    prestamo1.Libro = recuperarLibro(prestamo1);
                    listaPrestamosPorUsuario.Add(prestamo1);
                }
                return listaPrestamosPorUsuario;
            }
        }
        public List<PrestamoDTO> prestamosPorEjemplar(int pIdEjemplar)
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
        public void registrarPrestamo(string pUsuario, Int64 pEjemplarID)
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
                        Usuario = usuario
                    };
                ejemplar.Prestamos.Add(prestamo);
                usuario.Prestamos.Add(prestamo);
                unitOfWork.PrestamoRepository.Add(prestamo);
                unitOfWork.Complete();
                oLog.Add($"Se registró un prestamo");
            }
        }

        public void registrarDevolucion(Int64 pPrestamoID, string pEstado) //Registar devolución indicando el estado del ejemplar para establecer score correspondiente
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
                oLog.Add($"Se registró una nueva devolución");
            }
        }
        public List<UsuarioDTO> buscarUsuarioSimilitud(string pNombreUsuario) //Busqueda de usuario por comparacion de caracteres
        {
            using (IUnitOfWork unitOfWork = new UnitOfWork(new AccountManagerDbContext()))
            {
                IEnumerable<Usuario> listUsuarios = unitOfWork.UsuarioRepository.GetAll();
                List<UsuarioDTO> usuarios = new List<UsuarioDTO>();
                foreach (var usuario in listUsuarios)
                {
                    if (usuario.NombreUsuario.ToUpper().Contains(pNombreUsuario.ToUpper()))
                    {
                            UsuarioDTO usuarioDTO = new UsuarioDTO
                            {
                                NombreUsuario = usuario.NombreUsuario,
                                Score = usuario.Score,
                                Mail = usuario.Mail,
                                RangoUsuario = usuario.RangoUsuario,
                                Contraseña = usuario.Contraseña
                            };
                    usuarios.Add(usuarioDTO);
                    }
                }
                return usuarios;
            }
        }
        public UsuarioDTO buscarUsuario(string pNombreUsuario) //Busqueda de usuario por igualdad de caracteres
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
        public List<Libro> consultaLibrosDisponibles() //Listado de libros añadidos a través de la API
        {
            using (IUnitOfWork unitOfWork = new UnitOfWork(new AccountManagerDbContext()))
            {
                return unitOfWork.LibroRepository.listaLibros();
            }
        }
        public List<LibroDTO> buscarLibroSimilitud(string pTitulo) //Busqueda de libro por similitud de caracteres
        {
            using (IUnitOfWork unitOfWork = new UnitOfWork(new AccountManagerDbContext()))
            {
                pTitulo = pTitulo.ToUpper();
                IEnumerable<Libro> Libros = unitOfWork.LibroRepository.GetAll();
                List<LibroDTO> LibrosToDTO = new List<LibroDTO>();
                foreach(var libro in Libros)
                {
                    if (libro.Titulo.ToUpper().Contains(pTitulo))
                    { 
                        LibroDTO libroDTO = new LibroDTO
                        {
                            ISBN = libro.Isbn,
                            Titulo = libro.Titulo,
                            Autor = libro.Autor
                        };
                    LibrosToDTO.Add(libroDTO);
                    }
                }
                return LibrosToDTO;
            }
        }
        public LibroDTO buscarLibro(string pTitulo) //Busqueda de libro por igualdad de caracteres
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
        public void modificarUsuario(string pNombreUsuario, string pContraseña, string pMail, int pScore, Rango pRango)
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
            oLog.Add($"Se modificó el usuario {pNombreUsuario}");
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
                oLog.Add($"Se registró un nuevo usuario : {pNombreUsuario}");
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
                oLog.Add($"Se agregó un nuevo libro");
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
                oLog.Add($"Se agregó un nuevo ejemplar");
            }
        }
        public Ejemplar buscarEjemplarDisponible(Int64 id) //Se devuelve el primer ejemplar disponible encontrado de un libro
        {
            using (IUnitOfWork unitOfWork = new UnitOfWork(new AccountManagerDbContext()))
            {
                IEnumerable<Ejemplar> ejemplar = unitOfWork.EjemplarRepository.GetAll();
                foreach (var ej in ejemplar)
                {
                    if (id == ej.ID)
                    {
                        return ej;
                    }
                }
                return null;
            }
        }
        public bool buscarPrestamoEjemplar(Ejemplar ej) //Devuelve si el ejemplar indicado se encuentra prestado actualmente
        {
            using (IUnitOfWork unitOfWork = new UnitOfWork(new AccountManagerDbContext()))
            {
                IEnumerable<Prestamo> prestamos = unitOfWork.PrestamoRepository.GetAll();
                List<Prestamo> prestamos1 = new List<Prestamo>();
                foreach (var prestamo in prestamos)
                {
                    if (prestamo.FechaRealDevolucion == null)
                    {
                        prestamos1.Add(prestamo);
                    }
                }
                if (prestamos1.Count() != 0)
                {
                    foreach (var prestamo in prestamos1)
                    {
                        long nombre = prestamo.Ejemplar.ID;
                        if (ej.ID == nombre)
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    return true;
                }
            }
            return true;
        }
        public void cambiarRango(string pNombreUsuario)
        {
            using (IUnitOfWork unitOfWork = new UnitOfWork(new AccountManagerDbContext()))
            {
                if (pNombreUsuario != "")
                {
                    UsuarioDTO userDTO = buscarUsuario(pNombreUsuario);
                    if (userDTO.RangoUsuario == Rango.Admin)
                    {
                        userDTO.RangoUsuario = Rango.Cliente;
                    }
                    else
                    {
                        userDTO.RangoUsuario = Rango.Admin;
                    }
                    unitOfWork.Complete();
                }
                else
                {
                    oLog.Add($"Se modificó el rango de un usuario");
                    throw new IllegalUsernameException("El nombre del usuario no puede estar vacío.");
                }
            oLog.Add($"Se modificó el rango de un usuario");
            }
        }
        public List<LibroDTO> consultaLibro(string pTituloLibro) //Se realiza una consulta a la API buscando determinado libro
        {
            IconsultaAPI apiConsultas = new consultaAPI();
            oLog.Add($"Se ha realizado una consulta a la API");
            return apiConsultas.Consulta(pTituloLibro);
        }
    }
}
