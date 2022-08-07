using System;
using ToolBoxDeveloper.DomainContext.Domain.Extensions;
using Xunit;

namespace ToolBoxDeveloper.DomainContext.Domain.Test
{
    public class CrypExtensionTest
    {
        [Theory(DisplayName = "Encriptando senha com suceso")]
        [InlineData("12456")]
        [InlineData("321456")]
        [InlineData("ASdasd!@Asdas")]

        public void EncryptSucess(string value)
        {
            //Arrange && Act && Assert
            Assert.DoesNotMatch(value,value.Encrypt());
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
