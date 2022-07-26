using ToolBoxDeveloper.DomainContext.MVC.Domain.Extensions;
using Xunit;

namespace ToolBoxDeveloper.DomainContext.Domain.Test
{
    public class StringExtensionsTest
    {
        [Theory(DisplayName = "valor é nulo ou tem espaços vazios")]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]

        public void IsNullOrEmptyOrWhiteSpace(string value)
        {
            //Arrange && Act && Assert
            Assert.True(value.IsNullOrEmptyOrWhiteSpace());
        }
        [Theory(DisplayName = "valor não é nulo ou e não tem espaços vazios")]
        [InlineData("Teste")]
        [InlineData("1")]
        [InlineData("asd")]

        public void IsNotNullOrEmptyOrWhiteSpace(string value)
        {
            //Arrange && Act && Assert
            Assert.False(value.IsNullOrEmptyOrWhiteSpace());
        }
    }
}
