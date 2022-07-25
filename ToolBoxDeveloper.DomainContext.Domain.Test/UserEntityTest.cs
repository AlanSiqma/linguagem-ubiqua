using System;
using ToolBoxDeveloper.DomainContext.MVC.Domain.Entities;
using Xunit;

namespace ToolBoxDeveloper.DomainContext.Domain.Test
{
    public class UserEntityTest
    {
        [Fact]
        public void CreateObjetSuccess()
        {
            //Arrange
            string password = "123456@asd";
            string email = "joares@gmail.com";

            //Act
            UserEntity user = new UserEntity(email);
            user.SetPassword(password);

            //Assert 
            Assert.Equal(email, user.Email);
        }
        [Theory(DisplayName = "Erro ao criar objeto, email invalido")]
        [InlineData("")]
        [InlineData(null)]
        public void CreateObjetEmailNotSuccess(string email)
        {
            //Arrange && Act && Assert
            Assert.Throws<ArgumentNullException>(() => new UserEntity(email));
        }

        [Theory(DisplayName = "Erro ao criar objeto, senha invalida")]
        [InlineData("")]
        [InlineData(null)]
        public void CreateObjetPasswordNotSuccess(string password)
        {
            //Arrange
            string email = "joares@gmail.com";
            UserEntity user = new UserEntity(email);
            
            //Act && Assert
            Assert.Throws<ArgumentNullException>(() => user.SetPassword(password));
        }
    }
}
