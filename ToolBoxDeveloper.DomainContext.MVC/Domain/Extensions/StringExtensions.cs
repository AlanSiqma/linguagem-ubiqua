namespace ToolBoxDeveloper.DomainContext.MVC.Domain.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNullOrEmptyOrWhiteSpace(this string value)
        {
            if (string.IsNullOrEmpty(value) && string.IsNullOrWhiteSpace(value))
                return true;

            return false;
        }
    }
}
