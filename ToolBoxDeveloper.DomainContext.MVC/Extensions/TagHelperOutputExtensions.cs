using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text.Encodings.Web;

namespace ToolBoxDeveloper.DomainContext.MVC.Extensions
{
    public static class TagHelperOutputExtensions
    {
        private const string AlertClass = "alert";
        private const string DangerClass = "alert-danger";
        private const string PrimaryClass = "alert-primary";
        private const string DismissibleClass = "alert-dismissible";
        private const string FadeClass = "fade";
        private const string ShowClass = "show";

        public static void AddClassAlert(this TagHelperOutput output, bool anyError)
        {
            output.AddClass(AlertClass, HtmlEncoder.Default);

            if (anyError)
                output.AddClass(DangerClass, HtmlEncoder.Default);
            else
                output.AddClass(PrimaryClass, HtmlEncoder.Default);

            output.AddClass(DismissibleClass, HtmlEncoder.Default);
            output.AddClass(FadeClass, HtmlEncoder.Default);
            output.AddClass(ShowClass, HtmlEncoder.Default);
        }
    }

}
