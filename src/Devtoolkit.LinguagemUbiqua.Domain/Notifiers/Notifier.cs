using Devtoolkit.LinguagemUbiqua.Domain.Contracts.Notifications;
using Devtoolkit.LinguagemUbiqua.Domain.Dto;
using System.Collections.Generic;
using System.Linq;

namespace Devtoolkit.LinguagemUbiqua.Domain.Notifications
{
    public class Notifier : INotifier
    {
        private List<NotificationDto> _notifications;

        public Notifier()
        {
            _notifications = new List<NotificationDto>();
        }

        public void Handle(NotificationDto notificacao)
        {
            _notifications.Add(notificacao);
        }

        public List<NotificationDto> GetNotifications()
        {
            return _notifications;
        }

        public bool HasNotification()
        {
            return _notifications.Any();
        }

        public void ClearNotification()
        {
            _notifications = new List<NotificationDto>();
        }
    }
}
