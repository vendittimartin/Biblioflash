using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using Biblioflash.Manager.Exceptions;

namespace Biblioflash.Manager.Domain
{
        public class EnvioMails
        {
            public void EnvioMail(string to, string asunto, string body)
            {
                try
                {
                    string from = "biblioflash@outlook.es";
                    string displayName = "BibliotecaFlash";
                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress(from, displayName);
                    mail.To.Add(to);
                    mail.Subject = asunto;
                    mail.Body = body;

                    SmtpClient client = new SmtpClient("smtp-mail.outlook.com", 587);
                    client.Credentials = new NetworkCredential(from, "Biblioflash");
                    client.EnableSsl = true;
                    client.Send(mail);
                }
                catch (SendMailFailedException ex)
                {
                    throw new SendMailFailedException(ex.Message);
                }
            }

        public void EnviarMail(Notificacion pNotificacion)
        {
            string to = pNotificacion.Usuario.Mail;
            string asunto = pNotificacion.Asunto;
            string descripcion = pNotificacion.Descripcion;
            EnvioMail(to,asunto,descripcion);
        }
    }
}

