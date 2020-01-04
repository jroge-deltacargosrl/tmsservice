using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TMS_Services.App_Utils;
using TMS_Services.Models.DTO;
using TMS_Services.Models.ViewModels;
using static TMS_Services.App_Utils.UtilsApiTms;

namespace TMS_Services.Models.DAL
{
    public class MailServiceDAL
    {

        public ResponseRequestDTO<GeneratePasswordUserViewDTO> sendMail(GeneratePasswordUserViewDTO model)
        {
            var response = new ResponseRequestDTO<GeneratePasswordUserViewDTO>
            {
                code = STATE_MAIL_OK,
                dateResponse = DateTime.UtcNow,
                modelResponse = model,
                message = "Credenciales Enviadas correctamente al usuario" 
            };


            var mailResponse = new MessageMail()
                .addFrom(EMAIL_EMISOR)
                .addToList(model.email)
                .addSubject(SUBJECT_GENERATE_PASSWORD)
                .addBodyMessage(formatMessageForGenerateCredentialsUser(model))
                .enableBodyHtml()
                .send();
            if (!mailResponse)
            {
                response.code = 400; // bad request
                response.message = "Error al enviar el correo con las credenciales de usuario";
            }
            return response;
        }
    }
}