using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using Biblioflash.Manager.Exceptions;
using Biblioflash.Manager.DTO;

namespace Biblioflash.Manager.Domain
{
        public class EnvioMails
        {
            public void EnvioMail(string to, string asunto, Notificacion notif)
            {
                try
                {
                    string from = "";
                    string displayName = "BibliotecaFlash";
                    string password = "";
                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress(from, displayName);
                    mail.To.Add(to);
                    mail.Subject = asunto;
                    mail.IsBodyHtml = true;
                    mail.Body =  @$"<h2 style='color:#4F5D75'> Estimado: {notif.Usuario.NombreUsuario}</h2>
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

        public void EnviarMail(Notificacion notif)
        {
            string to = notif.Usuario.Mail;
            string asunto = "Prestamo Biblioflash";
            EnvioMail(to,asunto,notif);
        }
    }
}

