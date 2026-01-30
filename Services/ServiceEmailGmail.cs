using System.Net;
using System.Net.Mail;
using NETPortafolio.Models;

namespace NETPortafolio.Services
{
    public interface IServiceEmail
    {
        Task Enviar(ContactViewModel contacto);
    }
    public class ServiceEmailGmail : IServiceEmail
    {
        readonly IConfiguration configuration;
        public ServiceEmailGmail(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task Enviar(ContactViewModel contacto)
        {
            /*Estos son datos sensibles por ende se colocan en un administrador de secretos de usuario*/
            var emailEmisor = configuration.GetValue<string>("CONFIGURATION_EMAIL:EMAIL");
            var password = configuration.GetValue<string>("CONFIGURATION_EMAIL:PASSWORD");
            /*Estos datos son datos globales que podemos ponerlos en un proveedor de configuración (appsettings.json)*/
            var host = configuration.GetValue<string>("CONFIGURATION_EMAIL:HOST");
            var puerto = configuration.GetValue<int>("CONFIGURATION_EMAIL:PUERTO");

            var smtpClient = new SmtpClient(host, puerto);
            /*Conexión SSL segura*/
            smtpClient.EnableSsl = true;
            /*Con esto indico que no utilizaré las credenciales por defecto ya que, enviaré mis credenciales con las variables emailEmisor y password*/
            smtpClient.UseDefaultCredentials = false;
            /*Aquí envio mis credenciales*/
            smtpClient.Credentials = new NetworkCredential(emailEmisor, password);
            /*Contruyo mi mensaje*/
            var mensaje = new MailMessage(emailEmisor, emailEmisor, $"El cliente {contacto.Nombre} ({contacto.Email}) quiere contactarte", contacto.Mensaje);

            await smtpClient.SendMailAsync(mensaje);
        }
    }
}
