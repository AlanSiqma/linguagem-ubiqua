using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Linq;
using System.Text.Encodings.Web;
using ToolBoxDeveloper.DomainContext.Domain.Contracts.Notifications;

namespace ToolBoxDeveloper.DomainContext.MVC.TagHelpers
{
    public class MessageTagHelper : TagHelper
    {
        private readonly INotifier _notifier;
        public MessageTagHelper(INotifier notifier)
        {
            this._notifier = notifier;
        }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (this._notifier.HasNotification())
            {
                var notifications = this._notifier.GetNotifications();

                output.TagName = "div";

                output.AddClass("alert", HtmlEncoder.Default);

                if (notifications.Any(x => x.Error))
                    output.AddClass("alert-danger", HtmlEncoder.Default);
                else
                    output.AddClass("alert-primary", HtmlEncoder.Default);

                output.AddClass("alert-dismissible", HtmlEncoder.Default);
                output.AddClass("fade", HtmlEncoder.Default);
                output.AddClass("show", HtmlEncoder.Default);
                output.Attributes.Add("role", "alert");

                var text = string.Empty;
                foreach (var item in notifications)
                    text += $"<p>{item.Mensagem}</p>";

                text += "<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\">\r\n    <span aria-hidden=\"true\">&times;</span>\r\n  </button>";

                output.Content.SetHtmlContent(text);

                this._notifier.ClearNotification();
            }
        }
    }
}
