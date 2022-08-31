using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ToolBoxDeveloper.DomainContext.MVC.TagHelpers
{
    public class MessageTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Content.SetContent("Add Tag Helper");
            //base.Process(context, output);
        }
    }
}
