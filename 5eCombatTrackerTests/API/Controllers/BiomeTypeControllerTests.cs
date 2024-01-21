using _5eCombatTracker.API.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Net;

namespace _5eCombatTracker.API.Controllers.Tests
{
    [TestClass()]
    public class BiomeTypeControllerTests
    {
        /// <summary>
        /// Controller succesfully pulls back data from the service layer
        /// </summary>
        [TestMethod()]
        public void GetAllBiomesTest()
        {
            var mockService = new Mock<IBiomeTypeService>();
            var controller = new BiomeTypeController(mockService.Object);
            List<string> expectedResult = new List<string> { "TestBiome1", "TestBiome2" };
            Task<List<string>> successTask = Task.FromResult(expectedResult);
            mockService.Setup(x => x.GetAllBiomes()).Returns(successTask);

            IActionResult actionResult = controller.GetAllBiomes().Result;
            var contentResult = actionResult as OkObjectResult;

            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Value);
            Assert.AreEqual(expectedResult, contentResult.Value);
            Assert.AreEqual(200, contentResult.StatusCode);
        }

        /// <summary>
        /// Controller fails to find data from the repository layer
        /// </summary>
        [TestMethod()]
        public void GetAllBiomesTest_NotFoundResult()
        {
            var mockService = new Mock<IBiomeTypeService>();
            var controller = new BiomeTypeController(mockService.Object);
            
            var actionResult = controller.GetAllBiomes().Result;

            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
        }
    }
}