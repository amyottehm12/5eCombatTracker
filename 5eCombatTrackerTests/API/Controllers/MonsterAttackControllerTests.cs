using Microsoft.VisualStudio.TestTools.UnitTesting;
using _5eCombatTracker.API.Interfaces.Services;
using _5eCombatTracker.Data.DTO;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace _5eCombatTracker.API.Controllers.Tests
{
    [TestClass()]
    public class MonsterAttackControllerTests
    {
        const int monsterId = 1;

        [TestMethod()]
        public void GetRandomMonsterAttackTest()
        {
            var mockService = new Mock<IMonsterAttackService>();
            var controller = new MonsterAttackController(mockService.Object);
            MonsterAttackDTO expectedResult = StubMonsterAttackDTO();
            Task<MonsterAttackDTO> SuccessResult = Task.FromResult(expectedResult);
            mockService.Setup(x => x.GetRandomMonsterAttack(monsterId)).Returns(SuccessResult);
            IActionResult actionResult = controller.GetRandomMonsterAttack(monsterId).Result;

            var contentResult = actionResult as OkObjectResult;
            var actualResult = contentResult.Value;

            Assert.IsNotNull(actualResult);
            Assert.AreEqual(expectedResult, actualResult);
            Assert.AreEqual(200, contentResult.StatusCode);
        }

        public MonsterAttackDTO StubMonsterAttackDTO()
        {
            return new MonsterAttackDTO
            {
                DamageBonus = 1,
                DamageDie = 6,
                ExtraEffect = "none",
                HitRoll = 2,
                WeaponName = "attack",
                NumberOfAttacks = 1,
                NumberOfDice = 1,
                DamageTypeName = "Slashing"
            };
        }
    }
}