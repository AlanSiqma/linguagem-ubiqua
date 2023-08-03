using Devtoolkit.LinguagemUbiqua.Domain.Dto;
using System;
using Xunit;

namespace Devtoolkit.LinguagemUbiqua.Domain.Test
{
    public class DomainContextDtoTest
    {
        private static DomainContextDto CreateMockDomainContextDto()
        {
            return new DomainContextDto
            {
                Id = Guid.NewGuid().ToString(),
                Organization = "ToolBoxDeveloper",
                Domain = "DomainContext",
                Context = "Teste1",
                Key = "Teste1",
                Description = "Teste unitário"
            };
        }

        [Fact]
        public void SetEmailSuccess()
        {
            //Arange
            string email = "joares@gmail.com";
            DomainContextDto dto = CreateMockDomainContextDto();

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
            // Arrange
            DomainContextDto dto = CreateMockDomainContextDto();

            // Act && Assert
            Assert.Throws<ArgumentException>(() => dto.SetEmail(email));
        }
    }
}
