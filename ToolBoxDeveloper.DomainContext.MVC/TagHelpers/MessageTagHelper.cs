using Microsoft.AspNetCore.Razor.TagHelpers;
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
                output.Content.SetContent("Add Tag Helper");
                this._notifier.ClearNotification();
            }
        }
    }
}
