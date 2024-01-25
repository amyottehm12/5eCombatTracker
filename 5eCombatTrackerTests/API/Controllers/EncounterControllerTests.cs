using _5eCombatTracker.API.Interfaces.Services;
using _5eCombatTracker.Data.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using static _5eCombatTracker.Data.Enums;

namespace _5eCombatTracker.API.Controllers.Tests
{
    [TestClass()]
    public class EncounterControllerTests
    {
        [TestMethod()]
        public void GetRandomEncounterTest()
        {
            var mockService = new Mock<IEncounterService>();
            var controller = new EncounterController(mockService.Object);
            EncounterDTO expectedResult = StubEncounterDTO();
            Task<EncounterDTO> SuccessResult = Task.FromResult(expectedResult);
            BiomeTypeEnum biomeType = BiomeTypeEnum.Dungeon;
            mockService.Setup(x => x.GetRandomEncounter(biomeType)).Returns(SuccessResult);

            IActionResult actionResult = controller.GetRandomEncounter(biomeType).Result;
            var contentResult = actionResult as OkObjectResult;
            var actualResult = contentResult.Value;

            Assert.IsNotNull(actualResult);
            Assert.AreEqual(expectedResult, actualResult);
            Assert.AreEqual(200, contentResult.StatusCode);
        }

        [TestMethod()]
        public void GetRandomEncounterTest_NotFoundResult()
        {
            var mockService = new Mock<IBiomeTypeService>();
            var controller = new BiomeTypeController(mockService.Object);

            var actionResult = controller.GetAllBiomes().Result;

            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
        }


        public EncounterDTO StubEncounterDTO()
        {
            return new EncounterDTO()
            {
                Name = "The Skeletons",
                MonsterGroupId = 1,
                Monsters = new List<EncounterMonsterDTO>
                {
                    new EncounterMonsterDTO {
                        Quantity = 2,
                        Monster = new MonsterDTO
                        {
                            Id = 1,
                            Name = "Skeleton",
                            AC = 11,
                            HP = 10,
                        }
                    }
                }
            };
        }
    }
}