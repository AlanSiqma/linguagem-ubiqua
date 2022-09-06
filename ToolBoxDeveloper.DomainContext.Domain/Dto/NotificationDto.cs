using System;

namespace ToolBoxDeveloper.DomainContext.Domain.Dto
{
    public class NotificationDto
    {
     
        public NotificationDto(string mensagem,bool error = false)
        {
            Mensagem = mensagem;
            Error = error;
        }

        public NotificationDto(Exception argumentException)
        {
            this.Mensagem = argumentException.Message;
            this.Error = true;
        }
        public bool Error { get; set; }

        public string Mensagem { get; }
    }
}
