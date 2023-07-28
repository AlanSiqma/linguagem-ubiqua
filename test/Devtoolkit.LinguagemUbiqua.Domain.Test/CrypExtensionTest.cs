using System;
using Devtoolkit.LinguagemUbiqua.Domain.Extensions;
using Xunit;

namespace Devtoolkit.LinguagemUbiqua.Domain.Test
{
    public class CrypExtensionTest
    {
        [Theory(DisplayName = "Encriptando senha com suceso")]
        [InlineData("12456")]
        [InlineData("321456")]
        [InlineData("ASdasd!@Asdas")]

        public void EncryptSucess(string value)
        {
            // Arrange && Act
            string encryptedValue = value.Encrypt();

            // Assert
            Assert.NotEqual(value, encryptedValue);
        }
        [Theory(DisplayName = "Encriptando sem suceso")]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]

        public void EncryptNotSucess(string value)
        {
            //Arrange && Act && Assert
            Assert.Throws<ArgumentException>(() => value.Encrypt());
        }
    }
}
