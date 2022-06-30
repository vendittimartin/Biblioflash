using Biblioflash.Manager.Exceptions;
using System.Net;
using System.Net.Mail;
using Biblioflash.Manager.DAL;
using System.Configuration;

namespace Biblioflash.Manager.Domain
{
    public class EnvioMails : IEstrategiaNotificacion
    {
        AppSettingsReader lector = new AppSettingsReader();
        public void NotificarUsuario(Notificacion notif)
        {
            try
            {
                string from = ConfigurationManager.AppSettings.Get("mail");
                string displayName = "BibliotecaFlash";
                string password = ConfigurationManager.AppSettings.Get("password");
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(from, displayName);
                mail.To.Add(notif.Usuario.Mail);
                mail.Subject = "Prestamo Biblioflash";
                mail.IsBodyHtml = true;
                mail.Body = @$"<h2 style='color:#4F5D75'> Estimado: {notif.Usuario.NombreUsuario}</h2>
                                    <p> Le informamos que posee un prestamo próximo a vencerse del libro:<h4 style = 'color:#4F5D75'>{notif.Prestamo.Ejemplar.Libro.Titulo}</h4></p>
                                    <p> La fecha de devolución del mismo es el día: <h4 style = 'color:#4F5D75'>{notif.Prestamo.FechaDevolucion}</h4></p>
                                    <p> Por favor, acérquese a la biblioteca para devolver el libro.</p>
                                    <br>
                                    <p> Saludos.Atte.</p>
                                    <h4 style = 'color:#4F5D75'> Biblioflash.</h4>";
                SmtpClient client = new SmtpClient("smtp-mail.outlook.com", 587);
                client.Credentials = new NetworkCredential(from, password);
                client.EnableSsl = true;
                client.Send(mail);
            }
            catch (SendMailFailedException ex)
            {
                throw new SendMailFailedException(ex.Message);
            }
        }
    }
}

