using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections.Generic;
using System.Linq;
using ToolBoxDeveloper.DomainContext.Domain.Contracts.Notifications;
using ToolBoxDeveloper.DomainContext.Domain.Dto;
using ToolBoxDeveloper.DomainContext.MVC.Extensions;

namespace ToolBoxDeveloper.DomainContext.MVC.TagHelpers
{
    public class MessageTagHelper : TagHelper
    {
        private readonly INotifier _notifier;

        #region properties alert
        private readonly string _div = "div";
        private readonly string _alert = "alert";
        private readonly string _closeButton = "<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\">\r\n    <span aria-hidden=\"true\">&times;</span>\r\n  </button>";
        private readonly string _role = "role";
        #endregion
        public MessageTagHelper(INotifier notifier)
        {
            this._notifier = notifier;
        }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (this._notifier.HasNotification())
            {
                string text = string.Empty;
                List<NotificationDto> notifications = this._notifier.GetNotifications();

                output.TagName = _div;
                output.AddClassAlert(notifications.Any(x => x.Error));
                output.Attributes.Add(_role, _alert);

                foreach (var item in notifications)
                    text += $"<p>{item.Mensagem}</p>";

                text += _closeButton;

                output.Content.SetHtmlContent(text);

                this._notifier.ClearNotification();
            }
        }

    }
}
