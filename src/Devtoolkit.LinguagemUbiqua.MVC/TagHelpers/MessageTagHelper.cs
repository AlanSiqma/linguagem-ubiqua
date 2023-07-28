using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Devtoolkit.LinguagemUbiqua.Domain.Contracts.Notifications;
using Devtoolkit.LinguagemUbiqua.Domain.Dto;
using Devtoolkit.LinguagemUbiqua.MVC.Extensions;

namespace Devtoolkit.LinguagemUbiqua.MVC.TagHelpers
{
    public class MessageTagHelper : TagHelper
    {
        private readonly INotifier _notifier;
        private const string DivTagName  = "div";
        private const string AlertClassName  = "alert";
        private const string CloseButtonHtml  = "<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\">\r\n    <span aria-hidden=\"true\">&times;</span>\r\n  </button>";
        private const string RoleAttributeName  = "role";       
        public MessageTagHelper(INotifier notifier)
        {
            _notifier = notifier;
        }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (_notifier.HasNotification())
            {
                List<NotificationDto> notifications = _notifier.GetNotifications();

                output.TagName = DivTagName ;
                output.AddClassAlert(notifications.Any(x => x.Error));
                output.Attributes.Add(RoleAttributeName , AlertClassName );

                StringBuilder stringBuilder = new StringBuilder();
                foreach (var item in notifications)
                    stringBuilder.Append($"<p>{item.Mensagem}</p>");

                stringBuilder.Append(CloseButtonHtml );

                output.Content.SetHtmlContent(stringBuilder.ToString());

                _notifier.ClearNotification();
            }
        }

    }
}