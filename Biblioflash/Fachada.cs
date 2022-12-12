using Biblioflash.Manager.API;
using Biblioflash.Manager.DAL;
using Biblioflash.Manager.DAL.EntityFramework;
using Biblioflash.Manager.Domain;
using Biblioflash.Manager.DTO;
using Biblioflash.Manager.Exceptions;
using Biblioflash.Manager.Log;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Biblioflash.Manager.Services;
using System.Configuration;

namespace Biblioflash
{
    public class Fachada
    {
        EnvioMails em = new EnvioMails();
        Log oLog = new Log($@"{Directory.GetCurrentDirectory()}\Log"); //Se obtiene la direccion de instalacion del programa para guardar el log en ella
        public List<UsuarioDTO> ListaUsuarios()
        {
            using (IUnitOfWork unitOfWork = new UnitOfWork(new AccountManagerDbContext()))
            {
                IEnumerable<Usuario> listaUsuario = unitOfWork.UsuarioRepository.GetAll();
                return listaUsuario.Select(u => new UsuarioDTO { Contraseña = u.Contraseña, NombreUsuario = u.NombreUsuario, Mail = u.Mail, Score = u.Score, RangoUsuario = u.RangoUsuario}).ToList();
            }
        }
        public void NotificarUsuarios() //Notificar usuarios con préstamos próximos a vencerse (48hs) verificando que ese préstamo no esté previamente notificado
        {
            using (IUnitOfWork unitOfWork = new UnitOfWork(new AccountManagerDbContext()))
            {
                List<Prestamo> listaPrestamos = unitOfWork.PrestamoRepository.PrestamosAVencerse();
                foreach (var prestamo in listaPrestamos)
                {
                   Notificacion notificacion = unitOfWork.NotificacionRepository.BuscarNotificacion(prestamo.ID);
                   if (notificacion == null)
                   {
                       Notificacion notif = new Notificacion
                       {
                          Usuario = prestamo.Usuario,
                          Prestamo = prestamo,
                          Fecha = DateTime.Now,
                          Descripcion = "Su prestamo está próximo a vencerse."
                       };
                       unitOfWork.NotificacionRepository.Add(notif);
                       unitOfWork.Complete();
                       em.NotificarUsuario(notif);
                       oLog.Add($"Se lanzo una notificacion {notif.ID} al usuario {notif.Usuario}");
                   }
                }
            }
        }
        public List<EjemplarDTO> ListaEjemplaresDisponibles(string Titulo) 
        {
            using (IUnitOfWork unitOfWork = new UnitOfWork(new AccountManagerDbContext()))
            {
                Libro libro = unitOfWork.LibroRepository.BuscarTitulo(Titulo);
                List<Ejemplar> listaEjemplares = libro.Ejemplares;
                return listaEjemplares.Where(u => u.EstaDisponible() == true).Select(u => new EjemplarDTO
                {
                    ID = u.ID,
                    Libro = GetLibroDTO(u.Libro.Titulo),
                    Prestamos = GetPrestamoDTOs(u.ID)
                }).ToList();
            }
        }
        public LibroDTO GetLibroDTO(string titulo)
        {
            using (IUnitOfWork unitOfWork = new UnitOfWork(new AccountManagerDbContext()))
            {
                Libro libro = unitOfWork.LibroRepository.BuscarTitulo(titulo);
                LibroDTO DTO = new LibroDTO()
                {
                    ISBN = libro.Isbn,
                    Autor = libro.Autor,
                    Titulo = libro.Titulo,
                    Ejemplares = libro.Ejemplares
                };
                return DTO;
            }
        }
        public List<PrestamoDTO> ListaPrestamos() 
        {
            using (IUnitOfWork unitOfWork = new UnitOfWork(new AccountManagerDbContext()))
            {
                IEnumerable<Prestamo> prestamos = unitOfWork.PrestamoRepository.GetAll();
                List<PrestamoDTO> listaPrestamosDTO = new List<PrestamoDTO>();
                foreach (var prestamo in prestamos.ToList())
                {
                    PrestamoDTO prestamo1 = new PrestamoDTO
                    {
                        IDEjemplar = prestamo.Ejemplar.ID,
                        FechaPrestamo = prestamo.FechaPrestamo,
                        FechaDevolucion = prestamo.FechaDevolucion,
                        FechaRealDevolucion = prestamo.FechaRealDevolucion,
                        ID = prestamo.ID,
                        estadoDevolucion = prestamo.estadoPrestamo,
                        Usuario = new UsuarioDTO { NombreUsuario = prestamo.Usuario.NombreUsuario },
                        Libro = new LibroDTO { Titulo = prestamo.Ejemplar.Libro.Titulo }
                    };
                    listaPrestamosDTO.Add(prestamo1);
                }
                return listaPrestamosDTO;
            }
        }

        public List<PrestamoDTO> ListaPrestamosNoDevueltos()
        {
            using (IUnitOfWork unitOfWork = new UnitOfWork(new AccountManagerDbContext()))
            {
                IEnumerable<Prestamo> prestamos = unitOfWork.PrestamoRepository.PrestamosNoDevueltos();
                List<PrestamoDTO> listaPrestamosDTO = new List<PrestamoDTO>();
                foreach (var prestamo in prestamos.ToList())
                {
                    PrestamoDTO prestamo1 = new PrestamoDTO
                    {
                        IDEjemplar = prestamo.Ejemplar.ID,
                        FechaPrestamo = prestamo.FechaPrestamo,
                        FechaDevolucion = prestamo.FechaDevolucion,
                        FechaRealDevolucion = prestamo.FechaRealDevolucion,
                        ID = prestamo.ID,
                        estadoDevolucion = prestamo.estadoPrestamo,
                        Usuario = new UsuarioDTO { NombreUsuario = prestamo.Usuario.NombreUsuario },
                        Libro = new LibroDTO { Titulo = prestamo.Ejemplar.Libro.Titulo }
                    };
                    listaPrestamosDTO.Add(prestamo1);
                }
                return listaPrestamosDTO;
            }
        }
        public UsuarioDTO RecuperarUsuario(long ID) //Se obtienen los datos de un usuario asociado al préstamo indicado
        {
            using (IUnitOfWork unitOfWork = new UnitOfWork(new AccountManagerDbContext()))
            {
                Usuario user = unitOfWork.PrestamoRepository.Get(ID).Usuario;
                return new UsuarioDTO { NombreUsuario = user.NombreUsuario, Contraseña = user.Contraseña, Mail = user.Mail, RangoUsuario = user.RangoUsuario, Score = user.Score};
            }
        }
        public LibroDTO RecuperarLibro(long ID) //Se obtienen los datos de un libro asociado al préstamo indicado
        {
            using (IUnitOfWork unitOfWork = new UnitOfWork(new AccountManagerDbContext()))
            {
                Libro libro = unitOfWork.PrestamoRepository.Get(ID).Ejemplar.Libro;
                return new LibroDTO() { ISBN = libro.Isbn, Autor = libro.Autor, Ejemplares = libro.Ejemplares, Titulo = libro.Titulo };
            }
        }

        public EjemplarDTO RecuperarID(long ID)
        {
            using (IUnitOfWork unitOfWork = new UnitOfWork(new AccountManagerDbContext()))
            {
                Ejemplar ej = unitOfWork.PrestamoRepository.Get(ID).Ejemplar;
                return new EjemplarDTO() { ID = ej.ID, Prestamos = GetPrestamoDTOs(ej.ID)};
            }
        }
        public List<PrestamoDTO> GetPrestamoDTOs(long IDEj) {
            List<PrestamoDTO> listPrestamosDTO = new List<PrestamoDTO>();
            using (IUnitOfWork unitOfWork = new UnitOfWork(new AccountManagerDbContext()))
            {
                Ejemplar ejemplar = unitOfWork.EjemplarRepository.Get(IDEj);
                foreach (var prestamo in ejemplar.Prestamos)
                {
                    PrestamoDTO prestamo1 = new PrestamoDTO
                    {
                        IDEjemplar = prestamo.Ejemplar.ID,
                        FechaPrestamo = prestamo.FechaPrestamo,
                        FechaDevolucion = prestamo.FechaDevolucion,
                        FechaRealDevolucion = prestamo.FechaRealDevolucion,
                        ID = prestamo.ID,
                        estadoDevolucion = prestamo.estadoPrestamo
                    };
                    listPrestamosDTO.Add(prestamo1);
                }
                return listPrestamosDTO;
            }
        }
        public PrestamoDTO PrestamosPorID(Int64 pID)
        {
            using (IUnitOfWork unitOfWork = new UnitOfWork(new AccountManagerDbContext()))
            {
                Prestamo prestamo = unitOfWork.PrestamoRepository.BuscarPrestamo(pID);
                return new PrestamoDTO() { ID = prestamo.ID, estadoDevolucion = prestamo.estadoPrestamo, FechaDevolucion = prestamo.FechaDevolucion, FechaPrestamo = prestamo.FechaPrestamo, FechaRealDevolucion = prestamo.FechaRealDevolucion, IDEjemplar = prestamo.Ejemplar.ID, Usuario = new UsuarioDTO { NombreUsuario = prestamo.Usuario.NombreUsuario} };
            }
        }

        public bool PuedeExtenderPrestamo(string userID, int CantDias)
        {
            using (IUnitOfWork unitOfWork = new UnitOfWork(new AccountManagerDbContext()))
            {
                Usuario usuario = unitOfWork.UsuarioRepository.BuscarUsuario(userID);
                if (usuario.ExtenderPrestamo(CantDias))
                {
                    return true;
                }
                else { return false; } 
            }
        }
        public void ExtenderPrestamo(long ID, string userID, int cantDias) //Se extiende la fecha de devolución de un préstamo verificando que los días indicados sean posibles debido a su score
        {  
            using (IUnitOfWork unitOfWork = new UnitOfWork(new AccountManagerDbContext()))
            {
                try {
                        Prestamo prestamo = unitOfWork.PrestamoRepository.BuscarPrestamo(ID);
                        prestamo.FechaDevolucion = prestamo.FechaDevolucion.AddDays(cantDias);
                        unitOfWork.Complete();
                        oLog.Add($"Se extendió un prestamo" + "usuario: " + userID + "id prestamo: " + prestamo.ID + "dias: " + cantDias + "fecha: " + prestamo.FechaDevolucion);
                }
                catch (Exception ex)
                {
                    oLog.Add("Error al extender un prestamo: " + ex.Message);
                    throw new Exception(ex.Message);
                }
            }
        }
        public List<PrestamoDTO> PrestamosDelUsuario(string pNombreUsuario) //Solicita los prestamos del usuario a partir del inicio de sesión (verificado que existe) 
        {
            using (IUnitOfWork unitOfWork = new UnitOfWork(new AccountManagerDbContext()))
            {
                List<Prestamo> listaTodosLosPrestamos = unitOfWork.PrestamoRepository.PrestamoUsuario(pNombreUsuario);
                List<PrestamoDTO> listaPrestamosPorUsuario = new List<PrestamoDTO>();
                foreach (var prestamo in listaTodosLosPrestamos.ToList())
                {
                    PrestamoDTO prestamo1 = new PrestamoDTO
                    {
                        IDEjemplar = prestamo.Ejemplar.ID,
                        FechaPrestamo = prestamo.FechaPrestamo,
                        FechaDevolucion = prestamo.FechaDevolucion,
                        FechaRealDevolucion = prestamo.FechaRealDevolucion,
                        ID = prestamo.ID,
                        estadoDevolucion = prestamo.estadoPrestamo,
                        Usuario = new UsuarioDTO { NombreUsuario = prestamo.Usuario.NombreUsuario },
                        Libro = new LibroDTO { Titulo = prestamo.Ejemplar.Libro.Titulo}
                    };
                    listaPrestamosPorUsuario.Add(prestamo1);
                }
                return listaPrestamosPorUsuario;
            }
        }
        public List<PrestamoDTO> PrestamosPorUsuarioX(string pNombreUsuario) //Lista de todos los préstamos de un usuario en formato DTO
        {
            using (IUnitOfWork unitOfWork = new UnitOfWork(new AccountManagerDbContext()))
            {
                List<Prestamo> listaTodosLosPrestamos = unitOfWork.UsuarioRepository.BuscarUsuario(pNombreUsuario).Prestamos;
                List<PrestamoDTO> listaPrestamosPorUsuario = new List<PrestamoDTO>();
                foreach (var prestamo in listaTodosLosPrestamos.ToList())
                {
                    PrestamoDTO prestamo1 = new PrestamoDTO
                    {
                        IDEjemplar = prestamo.Ejemplar.ID,
                        FechaPrestamo = prestamo.FechaPrestamo,
                        FechaDevolucion = prestamo.FechaDevolucion,
                        FechaRealDevolucion = prestamo.FechaRealDevolucion,
                        ID = prestamo.ID,
                        estadoDevolucion = prestamo.estadoPrestamo
                    };
                    prestamo1.Usuario = RecuperarUsuario(prestamo.ID);
                    prestamo1.Libro = RecuperarLibro(prestamo1.ID);
                    listaPrestamosPorUsuario.Add(prestamo1);
                }
                return listaPrestamosPorUsuario;
            }
        }
        public List<PrestamoDTO> PrestamosPorEjemplar(int pIdEjemplar)
        {
            List<PrestamoDTO> listaTodosLosPrestamos = ListaPrestamos();
            return listaTodosLosPrestamos.Where(x => x.IDEjemplar == pIdEjemplar).ToList();
        }
        public bool RegistrarPrestamo(string pUsuario, Int64 pEjemplarID) 
        {
            using (IUnitOfWork unitOfWork = new UnitOfWork(new AccountManagerDbContext()))
            {
                Usuario usuario = unitOfWork.UsuarioRepository.BuscarUsuario(pUsuario);
                if (!(usuario != null)) { return false; }
                Ejemplar ejemplar = unitOfWork.EjemplarRepository.Get(pEjemplarID);
                if (!(ejemplar != null)) { return false;  }
                if (ejemplar.EstaDisponible())
                {
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
                    oLog.Add($"Se registró el prestamo {prestamo.ID}, al usuario {prestamo.Usuario.NombreUsuario}, con el ejemplar {prestamo.Ejemplar.ID}");
                    return true;
                }
                else { return false; }
            }
        }
        public void RegistrarDevolucion(Int64 pPrestamoID, string pEstado) //Registar devolución indicando el estado del ejemplar para establecer score correspondiente
        { 
            using (IUnitOfWork unitOfWork = new UnitOfWork(new AccountManagerDbContext()))
            {
                Prestamo prestamo = unitOfWork.PrestamoRepository.Get(pPrestamoID);
                prestamo.estadoPrestamo = pEstado;
                prestamo.registrarAtraso();
                prestamo.registrarDevolucion();
                unitOfWork.Complete();
                oLog.Add($"Se registró una nueva devolución del prestamo: {prestamo.ID}");
            }
        }
        public List<UsuarioDTO> BuscarUsuarioSimilitud(string pNombreUsuario) //Busqueda de usuario por comparacion de caracteres
        {
            using (IUnitOfWork unitOfWork = new UnitOfWork(new AccountManagerDbContext()))
            {
                IEnumerable<Usuario> listUsuarios = unitOfWork.UsuarioRepository.BuscarUsuarioSimilitud(pNombreUsuario);
                List<UsuarioDTO> usuarios = new List<UsuarioDTO>();
                foreach (var usuario in listUsuarios)
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
                return usuarios;
            }
        }
        public UsuarioDTO BuscarUsuario(string pNombreUsuario) //Busqueda de usuario por igualdad de caracteres
        {
            using (IUnitOfWork unitOfWork = new UnitOfWork(new AccountManagerDbContext()))
            {
                Usuario userToDTO = unitOfWork.UsuarioRepository.BuscarUsuario(pNombreUsuario);
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
        public List<LibroDTO> ConsultaLibrosDisponibles() //Listado de libros disponibles
        {
            using (IUnitOfWork unitOfWork = new UnitOfWork(new AccountManagerDbContext()))
            {
                List<Libro> listaLibros = unitOfWork.LibroRepository.ListaLibros();
                return listaLibros.Select(x => new LibroDTO() { Autor = x.Autor, Ejemplares = x.Ejemplares, ISBN = x.Isbn, Titulo = x.Titulo}).ToList();
            }
        }
        public List<LibroDTO> BuscarLibroSimilitud(string pTitulo) //Busqueda de libro por similitud de caracteres
        {
            using (IUnitOfWork unitOfWork = new UnitOfWork(new AccountManagerDbContext()))
            {
                IEnumerable<Libro> Libros = unitOfWork.LibroRepository.BuscarLibroSimilitud(pTitulo);
                List<LibroDTO> libros = new List<LibroDTO>();
                foreach (var x in Libros)
                {
                    LibroDTO libroDTO = new LibroDTO()
                    { ISBN = x.Isbn, Titulo = x.Titulo, Autor = x.Autor };
                    libros.Add(libroDTO);
                }
                return libros;
            }
        }
        public LibroDTO BuscarLibro(string pTitulo) //Busqueda de libro por igualdad de caracteres
        {
            using (IUnitOfWork unitOfWork = new UnitOfWork(new AccountManagerDbContext()))
            {
                Libro LibroToDTO = unitOfWork.LibroRepository.BuscarTitulo(pTitulo);
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
                else 
                { 
                    return null; 
                }
            }
        }
        public void ModificarUsuario(string pNombreUsuario, string pContraseña, string pMail, int pScore, Rango pRango) 
        {
            using (IUnitOfWork unitOfWork = new UnitOfWork(new AccountManagerDbContext()))
            {
                Usuario user = unitOfWork.UsuarioRepository.BuscarUsuario(pNombreUsuario);
                user.NombreUsuario = pNombreUsuario;
                user.Contraseña = Encriptador.GetSHA256(pContraseña);
                user.Mail = pMail;
                user.Score = pScore;
                user.RangoUsuario = pRango;
                unitOfWork.Complete();
            }
            oLog.Add($"Se modificó el usuario {pNombreUsuario}");
        }
        public void RegistrarUsuario(string pNombreUsuario, string pContraseña, string pMail) 
        {
            int score = Convert.ToInt32(ConfigurationManager.AppSettings["scoreInicial"]);
            using (IUnitOfWork unitOfWork = new UnitOfWork(new AccountManagerDbContext()))
            {
                Usuario user = new Usuario
                {
                    NombreUsuario = pNombreUsuario,
                    Score = score,
                    Mail = pMail,
                    RangoUsuario = Rango.Cliente
                };
                user.setContraseña(pContraseña);
                unitOfWork.UsuarioRepository.Add(user);
                unitOfWork.Complete();
                oLog.Add($"Se registró un nuevo usuario : {pNombreUsuario}");
            }
        }
        public void AgregarLibro(long ISBN, string Titulo, string Autor) 
        {
            using (IUnitOfWork unitOfWork = new UnitOfWork(new AccountManagerDbContext()))
            {
                Libro libroCargar = new Libro
                {
                    Isbn = ISBN,
                    Titulo = Titulo,
                    Autor = Autor
                };
                unitOfWork.LibroRepository.Add(libroCargar);
                unitOfWork.Complete();
                oLog.Add($"Se agregó un nuevo libro {libroCargar.ID} con el isb: {libroCargar.Isbn}");
            }
        }
        public void AgregarEjemplar(long ISBN) 
        {
            using (IUnitOfWork unitOfWork = new UnitOfWork(new AccountManagerDbContext()))
            {
                Libro libro = unitOfWork.LibroRepository.BuscarISBN(ISBN);
                Ejemplar ejemplar = new Ejemplar
                {
                    Libro = libro
                };
                unitOfWork.EjemplarRepository.Add(ejemplar);
                unitOfWork.Complete();
                oLog.Add($"Se agregó un nuevo ejemplar {ejemplar.ID} del libro {ejemplar.Libro}");
            }
        }
        public EjemplarDTO BuscarEjemplarDisponible(Int64 id) //Se devuelve el primer ejemplar disponible encontrado de un libro
        {
            using (IUnitOfWork unitOfWork = new UnitOfWork(new AccountManagerDbContext()))
            {
                IEnumerable<Ejemplar> ejemplar = unitOfWork.EjemplarRepository.GetAll();
                var list = ejemplar.Where(e => e.ID == id).ToList();
                return list.Where(e=> e.EstaDisponible() == true).Select(x => new EjemplarDTO() { ID = x.ID, Libro = GetLibroDTO(x.Libro.Titulo), Prestamos = GetPrestamoDTOs(x.ID)}).FirstOrDefault();
            }
        }   
        public bool BuscarPrestamoEjemplar(long id) //Devuelve si el ejemplar indicado se encuentra prestado actualmente
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
                            if (id == nombre)
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
        public void CambiarRango(string pNombreUsuario)
        {
            using (IUnitOfWork unitOfWork = new UnitOfWork(new AccountManagerDbContext()))
            {
                if (pNombreUsuario != "")
                {
                    UsuarioDTO userDTO = BuscarUsuario(pNombreUsuario);
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
                    throw new IllegalUsernameException("El nombre del usuario no puede estar vacío.");
                }
                oLog.Add($"Se modificó el rango del usuario {pNombreUsuario}");
            }
        }
        public List<LibroDTO> ConsultaLibro(string pTituloLibro) //Se realiza una consulta a la API buscando determinado libro
        {  
            IconsultaAPI apiConsultas = new ConsultaAPI();
            oLog.Add($"Se ha realizado una consulta a la API");
            return apiConsultas.Consulta(pTituloLibro);
        }

        public UsuarioDTO IniciarSesion(string password, string idUsuario)
        {
            using (IUnitOfWork unitOfWork = new UnitOfWork(new AccountManagerDbContext()))
            {
                var user = unitOfWork.UsuarioRepository.BuscarUsuario(idUsuario);
                if (user != null)
                {
                    if (Encriptador.Decrypt(user.Contraseña) == password)
                    {
                        return new UsuarioDTO { NombreUsuario = user.NombreUsuario, Contraseña = user.Contraseña, Mail = user.Mail, RangoUsuario = user.RangoUsuario, Score = user.Score };
                    }
                    else
                    {
                        return null;
                    }
                }
                else { return null; }
            }
        }
    }
}
