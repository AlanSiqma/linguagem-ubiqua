namespace ToolBoxDeveloper.DomainContext.MVC.Domain.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNullOrEmptyOrWhiteSpace(this string value)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                return true;

            return false;
        }
        public static bool IsNotNumber(this string value)
        {
            int n;
            return !int.TryParse(value, out n);
        }
    }
}
