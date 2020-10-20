using Castle.Core.Configuration;
using JwtAuthenticationApi.Controllers;
using JwtAuthenticationApi.Models;
using JwtAuthenticationApi.Repository;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace JwtTesting
{
    public class Tests
    {
       

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void IsTokenNotNullIsTokenNotNull_When_ValidUserCredentialsAreUsed()
        {
            Mock<AuthenticationManager> auth = new Mock<AuthenticationManager>("Thisismyprivatekey");     
            var controller = new AuthenticationController(auth.Object);
            var res = controller.AuthenticateUser(new User { UserName = "Sai_Krishna", Password = "passcode" }) as OkObjectResult;
            Assert.AreEqual(200,res.StatusCode);
        }

       [Test]
        public void IsTokenNull_When_InvalidUserCredentialsAreUsed()
        {
            Mock<AuthenticationManager> auth = new Mock<AuthenticationManager>("Thisismyprivatekey");
            var controller = new AuthenticationController(auth.Object);
            var res = controller.AuthenticateUser(new User { UserName = "sai", Password = "nopass" }) as OkObjectResult;
            Assert.IsNull(res);
        }
    }
}