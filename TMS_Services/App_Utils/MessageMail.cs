using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using static TMS_Services.App_Utils.UtilsApiTms;
namespace TMS_Services.App_Utils
{
    public class MessageMail
    {
        public List<string> toList { get; set; } = new List<string>();
        public string from { get; set; }
        public string subject { get; set; }
        public string bodyMessage { get; set; }
        public bool isBodyHTML { get; set; } = false;

        public MessageMail addToList(params string[] to)
        {
            to.ToList().ForEach((v) => toList.Add(v));
            //this.toList.AddRange(toList);
            return this;
        }

        public MessageMail addFrom(string from)
        {
            this.from = from;
            return this;
        }

        public MessageMail addSubject(string subject)
        {
            this.subject = subject;
            return this;
        }

        public MessageMail addBodyMessage(string bodyMessage)
        {
            this.bodyMessage = bodyMessage;
            return this;
        }

        public MessageMail enableBodyHtml()
        {
            isBodyHTML = true;
            return this;
        }

        public bool send()
        {
            MailMessage mail = new MailMessage();
            // recorrer la lista de direcciones a las cuales se enviara el correo
            foreach (string dir in toList)
            {
                mail.To.Add(dir);
            }
            mail.From = new MailAddress(from);
            mail.Subject = subject;
            mail.SubjectEncoding = Encoding.UTF8; // codificacion UTF-8

            mail.Body = bodyMessage;
            mail.BodyEncoding = Encoding.UTF8;
            mail.IsBodyHtml = isBodyHTML;


            mail.Priority = MailPriority.Normal;
            // crear la instancia para el servidor SMTP
            SmtpClient smtp = new SmtpClient();
            smtp.Host = HOST;
            smtp.Port = PUERTO;
            smtp.EnableSsl = HABILITAR_SSL;
            smtp.UseDefaultCredentials = USAR_CREDENCIALES_DEFAULT;
            smtp.Credentials = new NetworkCredential(USER, PASS);
            smtp.Timeout = 200000;
            try
            {
                smtp.Send(mail);
                mail.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}