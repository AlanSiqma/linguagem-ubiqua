﻿using System;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace ToolBoxDeveloper.DomainContext.Domain.Extensions
{
    public static class CrypExtension
    {
        public static string Encrypt(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                throw new ArgumentException("Valor não pode ser nulo, estar vazio ou conter apenas espaços");

            byte[] hashBytes;
            StringBuilder stringBuilder = new StringBuilder();

            using (HashAlgorithm Algoritmo = SHA256.Create())
                hashBytes = Algoritmo.ComputeHash(Encoding.Unicode.GetBytes(text));

            foreach (byte hashByte in hashBytes)
                stringBuilder.AppendFormat(CultureInfo.InvariantCulture, "{0:X2}", hashByte);

            return stringBuilder.ToString();
        }
    }
}