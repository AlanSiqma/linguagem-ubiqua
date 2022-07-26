using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace ToolBoxDeveloper.DomainContext.MVC.Domain.Extensions
{
    public static class CrypExtension
    {
        public static string Encrypt(this string Texto)
        {
            byte[] Hash;
            StringBuilder Retorno = new StringBuilder();

            using (HashAlgorithm Algoritmo = SHA256.Create())
                Hash = Algoritmo.ComputeHash(Encoding.Unicode.GetBytes(Texto));

            foreach (byte B in Hash)
                Retorno.AppendFormat(CultureInfo.InvariantCulture, "{0:X2}", B);

            return Retorno.ToString();
        }
    }
}