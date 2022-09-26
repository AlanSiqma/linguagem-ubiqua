using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text.Encodings.Web;

namespace ToolBoxDeveloper.DomainContext.MVC.Extensions
{
    public static class TagHelperOutputExtensions
    {
        private static readonly string _alert = "alert";
        private static readonly string _danger = "alert-danger";
        private static readonly string _primary = "alert-primary";
        private static readonly string _dismissible = "alert-dismissible";
        private static readonly string _fade = "fade";
        private static readonly string _show = "show";
        public static void AddClassAlert(this TagHelperOutput output, bool anyError)
        {
            output.AddClass(_alert, HtmlEncoder.Default);

            if (anyError)
                output.AddClass(_danger, HtmlEncoder.Default);
            else
                output.AddClass(_primary, HtmlEncoder.Default);

            output.AddClass(_dismissible, HtmlEncoder.Default);
            output.AddClass(_fade, HtmlEncoder.Default);
            output.AddClass(_show, HtmlEncoder.Default);
        }
    }
}
