using _5eCombatTracker.API.Interfaces.Services;
using _5eCombatTracker.Data.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace _5eCombatTracker.API.Controllers.Tests
{
    [TestClass()]
    public class MonsterControllerTests
    {
        const int monsterId = 1;
        const string monsterName = "Skeleton";

        [TestMethod()]
        public void GetMonsterByIdAsyncTest()
        {
            var mockService = new Mock<IMonsterService>();
            var controller = new MonsterController(mockService.Object);
            MonsterDTO expectedResult = StubMonsterDTO();
            Task<MonsterDTO> successResult = Task.FromResult(expectedResult);
            mockService.Setup(x => x.GetMonsterById(monsterId)).Returns(successResult);

            IActionResult actionResult = controller.GetMonsterByIdAsync(monsterId).Result;
            var contentResult = actionResult as OkObjectResult;
            var actualResult = contentResult.Value;

            Assert.IsNotNull(actualResult);
            Assert.AreEqual(expectedResult, actualResult);
            Assert.AreEqual(200, contentResult.StatusCode);
        }

        [TestMethod()]
        public void GetMonsterByNameAsyncTest()
        {
            var mockService = new Mock<IMonsterService>();
            var controller = new MonsterController(mockService.Object);
            MonsterDTO expectedResult = StubMonsterDTO();
            Task<MonsterDTO> successResult = Task.FromResult(expectedResult);
            mockService.Setup(x => x.GetMonsterByName(monsterName)).Returns(successResult);

            IActionResult actionResult = controller.GetMonsterByNameAsync(monsterName).Result;
            var contentResult = actionResult as OkObjectResult;
            var actualResult = contentResult.Value;

            Assert.IsNotNull(actualResult);
            Assert.AreEqual(expectedResult, actualResult);
            Assert.AreEqual(200, contentResult.StatusCode);
        }

        [TestMethod()]
        public void GetAllMonstersTest()
        {
            var mockService = new Mock<IMonsterService>();
            var controller = new MonsterController(mockService.Object);
            List<string> expectedResult = new List<string> { "Skeleton", "Zombie" };
            Task<List<string>> successResult = Task.FromResult(expectedResult);
            mockService.Setup(x => x.GetAllMonsters()).Returns(successResult);

            IActionResult actionResult = controller.GetAllMonsters().Result;
            var contentResult = actionResult as OkObjectResult;
            var actualResult = contentResult.Value;

            Assert.IsNotNull(actualResult);
            Assert.AreEqual(expectedResult, actualResult);
            Assert.AreEqual(200, contentResult.StatusCode);
        }

        public MonsterDTO StubMonsterDTO()
        {
            return new MonsterDTO()
            {
                Id = monsterId,
                Name = monsterName,
                AC = 11,
                HP = 12
            };
        }
    }
}