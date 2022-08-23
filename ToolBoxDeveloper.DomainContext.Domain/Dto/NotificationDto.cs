namespace ToolBoxDeveloper.DomainContext.Domain.Dto
{
    public class NotificationDto
    {
        public NotificationDto(string mensagem)
        {
            Mensagem = mensagem;
        }

        public string Mensagem { get; }
    }
}
