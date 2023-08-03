using Devtoolkit.LinguagemUbiqua.Domain.Entities;
using System;
using Xunit;

namespace Devtoolkit.LinguagemUbiqua.Domain.Test
{
    public class UserEntityTest
    {
        readonly string validEmail = "joares@gmail.com";

        [Fact(DisplayName = "Criar objeto com sucesso")]
        public void CreateObjectSuccess()
        {
            // Arrange
            string password = "123456@asd";

            // Act
            UserEntity user = new (validEmail);
            user.SetPassword(password);

            // Assert
            Assert.Equal(validEmail, user.Email);
        }

        [Theory(DisplayName = "Erro ao criar objeto, e-mail inválido")]
        [InlineData("")]
        [InlineData(null)]
        public void CreateObjectEmailNotSuccess(string invalidEmail)
        {
            // Arrange, Act & Assert
            Assert.Throws<ArgumentException>(() => new UserEntity(invalidEmail));
        }

        [Theory(DisplayName = "Erro ao criar objeto, senha inválida")]
        [InlineData("")]
        [InlineData(null)]
        public void CreateObjectPasswordNotSuccess(string invalidPassword)
        {
            // Arrange
            UserEntity user = new (validEmail);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => user.SetPassword(invalidPassword));
        }
    }
}
