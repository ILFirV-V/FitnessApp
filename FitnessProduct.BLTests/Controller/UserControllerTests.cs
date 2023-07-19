using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fitness.BL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Controller.Tests
{
    [TestClass()]
    public class UserControllerTests
    {
        [TestMethod()]
        public void SetNewUserDataTest()
        {
            //Arrange
            var userName = Guid.NewGuid().ToString();
            var birthDate = DateTime.Now.AddYears(-18);
            var weight = 90;
            var height = 190;
            var gender = "men";
            var firstController = new UserController(userName);

            //Act
            firstController.SetNewUserData(gender, birthDate, weight, height);

            var secondController = new UserController(userName);

            //Assert
            Assert.AreEqual(userName, secondController.CurrentUser.Name);
            Assert.AreEqual(birthDate, secondController.CurrentUser.BirthDate);
            Assert.AreEqual(weight, secondController.CurrentUser.Weight);
            Assert.AreEqual(height, secondController.CurrentUser.Height);
            Assert.AreEqual(gender, secondController.CurrentUser.Gender.Name);
        }

        [TestMethod()]
        public void SaveTest()
        {
            //Arrange
            var userName = Guid.NewGuid().ToString();
            
            //Act
            var controller = new UserController(userName);

            //Assert
            Assert.AreEqual(userName, controller.CurrentUser.Name);
        }
    }
}