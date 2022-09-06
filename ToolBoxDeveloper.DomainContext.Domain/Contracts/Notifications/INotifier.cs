using System.Collections.Generic;
using ToolBoxDeveloper.DomainContext.Domain.Dto;

namespace ToolBoxDeveloper.DomainContext.Domain.Contracts.Notifications
{
    public interface INotifier
    {
        bool HasNotification();
        List<NotificationDto> GetNotifications();
        void Handle(NotificationDto notificacao);
        void ClearNotification();
    }
}
