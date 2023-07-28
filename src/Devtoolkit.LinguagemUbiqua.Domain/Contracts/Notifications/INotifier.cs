using System.Collections.Generic;
using Devtoolkit.LinguagemUbiqua.Domain.Dto;

namespace Devtoolkit.LinguagemUbiqua.Domain.Contracts.Notifications
{
    public interface INotifier
    {
        bool HasNotification();
        List<NotificationDto> GetNotifications();
        void Handle(NotificationDto notificacao);
        void ClearNotification();
    }
}
