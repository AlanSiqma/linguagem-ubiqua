using System;
using Devtoolkit.LinguagemUbiqua.Domain.Entities;
using Xunit;

namespace Devtoolkit.LinguagemUbiqua.Domain.Test
{
    public class DomainContextEntityTest
    {
        private DomainContextEntity CreateMockDomainContextEntity()
        {
            return new DomainContextEntity("ToolBoxDeveloper", "DomainContext", "Teste1", "Teste1", "Teste unitário", "joares");
        }

        [Fact(DisplayName = "Criar objeto com sucesso")]
        public void CreateObjectSuccess()
        {
            // Arrange
            string organization = "ToolBoxDeveloper";

            // Act
            DomainContextEntity domainContext = CreateMockDomainContextEntity();

            // Assert
            Assert.Equal(organization, domainContext.Organization);
        }

        [Theory(DisplayName = "Múltiplas instâncias com parâmetros vazios DomainContextEntity")]
        [InlineData("", "DomainContext", "Teste1", "Teste1", "Teste unitário", "joares")]
        [InlineData("ToolBoxDeveloper", "", "Teste1", "Teste1", "Teste unitário", "joares")]
        [InlineData("ToolBoxDeveloper", "DomainContext", "", "Teste1", "Teste unitário", "joares")]
        [InlineData("ToolBoxDeveloper", "DomainContext", "Teste1", "", "Teste unitário", "joares")]
        [InlineData("ToolBoxDeveloper", "DomainContext", "Teste1", "Teste1", "", "joares")]
        [InlineData("ToolBoxDeveloper", "DomainContext", "Teste1", "Teste1", "Teste unitário", "")]
        public void CreateObjectParametersEmpty(string organization, string domain, string context, string key, string description, string userRegister)
        {
            // Arrange, Act & Assert
            Assert.Throws<ArgumentException>(() => new DomainContextEntity(organization, domain, context, key, description, userRegister));
        }

        [Theory(DisplayName = "Múltiplas instâncias com parâmetros nulos DomainContextEntity")]
        [InlineData(null, "DomainContext", "Teste1", "Teste1", "Teste unitário", "joares")]
        [InlineData("ToolBoxDeveloper", null, "Teste1", "Teste1", "Teste unitário", "joares")]
        [InlineData("ToolBoxDeveloper", "DomainContext", null, "Teste1", "Teste unitário", "joares")]
        [InlineData("ToolBoxDeveloper", "DomainContext", "Teste1", null, "Teste unitário", "joares")]
        [InlineData("ToolBoxDeveloper", "DomainContext", "Teste1", "Teste1", null, "joares")]
        [InlineData("ToolBoxDeveloper", "DomainContext", "Teste1", "Teste1", "Teste unitário", null)]
        public void CreateObjectParametersNull(string organization, string domain, string context, string key, string description, string userRegister)
        {
            // Arrange, Act & Assert
            Assert.Throws<ArgumentException>(() => new DomainContextEntity(organization, domain, context, key, description, userRegister));
        }
    }
}
