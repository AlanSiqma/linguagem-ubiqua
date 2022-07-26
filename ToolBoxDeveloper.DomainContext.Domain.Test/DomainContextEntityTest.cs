using System;
using ToolBoxDeveloper.DomainContext.MVC.Domain.Entities;
using Xunit;

namespace ToolBoxDeveloper.DomainContext.Domain.Test
{
    public class DomainContextEntityTest
    {
        [Fact]
        public void CreateObjectSuccess()
        {
            //Arrage 
            string organization = "ToolBoDevelopr";

            //Act
            DomainContextEntity domainContext = new DomainContextEntity("ToolBoDevelopr", "DomainContext", "Teste1", "Teste1", "Teste unitario", "joares");
            
            //Assert 
            Assert.Equal(organization, domainContext.Organization);
        }
        [Theory(DisplayName = "Multipla instancias parametros vazios DomainContextEntity")]
        [InlineData("", "DomainContext", "Teste1", "Teste1", "Teste unitario", "joares")]
        [InlineData("ToolBoDevelopr", "", "Teste1", "Teste1", "Teste unitario", "joares")]
        [InlineData("ToolBoDevelopr", "DomainContext", "", "Teste1", "Teste unitario", "joares")]
        [InlineData("ToolBoDevelopr", "DomainContext", "Teste1", "", "Teste unitario", "joares")]
        [InlineData("ToolBoDevelopr", "DomainContext", "Teste1", "Teste1", "", "joares")]
        [InlineData("ToolBoDevelopr", "DomainContext", "Teste1", "Teste1", "Teste unitario", "")]

        public void CreateObjectParametersEmpty(string organization, string domain, string context, string key, string description, string userRegister)
        {
            //Arange && Act && Assert 
            Assert.Throws<ArgumentException>(() => new DomainContextEntity(organization, domain, context, key, description, userRegister));
        }
        [Theory(DisplayName = "Multipla instancias parametros nulos DomainContextEntity")]
        [InlineData(null, "DomainContext", "Teste1", "Teste1", "Teste unitario", "joares")]
        [InlineData("ToolBoDevelopr", null, "Teste1", "Teste1", "Teste unitario", "joares")]
        [InlineData("ToolBoDevelopr", "DomainContext", null, "Teste1", "Teste unitario", "joares")]
        [InlineData("ToolBoDevelopr", "DomainContext", "Teste1", null, "Teste unitario", "joares")]
        [InlineData("ToolBoDevelopr", "DomainContext", "Teste1", "Teste1", null, "joares")]
        [InlineData("ToolBoDevelopr", "DomainContext", "Teste1", "Teste1", "Teste unitario", null)]
        public void CreateObjectParametersNull(string organization, string domain, string context, string key, string description, string userRegister)
        {
            //Arange && Act && Assert 
            Assert.Throws<ArgumentException>(() => new DomainContextEntity(organization, domain, context, key, description, userRegister));
        }
    }
}
