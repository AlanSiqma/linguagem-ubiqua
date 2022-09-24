using System;
using ToolBoxDeveloper.DomainContext.Domain.Entities;
using Xunit;

namespace ToolBoxDeveloper.DomainContext.Domain.Test
{
    public class UserEntityTest
    {
        string email = "joares@gmail.com";
        [Fact]
        public void CreateObjetSuccess()
        {
            //Arrange
            string password = "123456@asd";            

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
            Assert.Throws<ArgumentException>(() => new UserEntity(email));
        }

        [Theory(DisplayName = "Erro ao criar objeto, senha invalida")]
        [InlineData("")]
        [InlineData(null)]
        public void CreateObjetPasswordNotSuccess(string password)
        {
            //Arrange          
            UserEntity user = new UserEntity(email);
            
            //Act && Assert
            Assert.Throws<ArgumentException>(() => user.SetPassword(password));
        }
    }
}
