using System;
using ToolBoxDeveloper.DomainContext.Domain.Dto;
using Xunit;

namespace ToolBoxDeveloper.DomainContext.Domain.Test
{
    public class DomainContextDtoTest
    {
        [Fact]
        public void SetEmailSuccess()
        {
            //Arange
            string email = "joares@gmail.com";
            DomainContextDto dto = this.MoqDomainContextDto();

            //Act
            dto.SetEmail(email);

            //Arrange
            Assert.Equal(email, dto.UserRegister);
        }
        [Theory(DisplayName = "Alterando userRegister sem sucesso")]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]

        public void SetEmailNotSuccess(string email)
        {
            //Arange
            DomainContextDto dto = this.MoqDomainContextDto();

            //Act && Arrange
            Assert.Throws<ArgumentException>(() => dto.SetEmail(email));
        }

        private DomainContextDto MoqDomainContextDto()
        {
            return new()
            {
                Id = Guid.NewGuid().ToString(),
                Organization = "ToolBoDevelopr",
                Domain = "DomainContext",
                Context = "Teste1",
                Key = "Teste1",
                Description = "Teste unitario"
            };
        }
    }
}
