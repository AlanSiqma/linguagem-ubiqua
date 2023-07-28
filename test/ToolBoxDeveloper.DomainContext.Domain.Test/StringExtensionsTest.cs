using Xunit;

namespace ToolBoxDeveloper.DomainContext.Domain.Test
{
    public class StringExtensionsTest
    {
        [Theory(DisplayName = "Verificar se o valor é nulo ou tem espaços vazios")]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void IsNullOrEmptyOrWhiteSpace_ShouldReturnTrue(string value)
        {
            // Act
            bool result = string.IsNullOrWhiteSpace(value);

            // Assert
            Assert.True(result);
        }

        [Theory(DisplayName = "Verificar se o valor não é nulo e não tem espaços vazios")]
        [InlineData("Teste")]
        [InlineData("1")]
        [InlineData("asd")]
        public void IsNotNullOrEmptyOrWhiteSpace_ShouldReturnFalse(string value)
        {
            // Act
            bool result = string.IsNullOrWhiteSpace(value);

            // Assert
            Assert.False(result);
        }
    }
}
