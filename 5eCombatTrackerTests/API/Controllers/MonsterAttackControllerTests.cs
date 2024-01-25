using Microsoft.VisualStudio.TestTools.UnitTesting;
using _5eCombatTracker.API.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _5eCombatTracker.API.Interfaces.Services;
using _5eCombatTracker.Data.DTO;
using Microsoft.AspNetCore.Mvc;
using Moq;
using static _5eCombatTracker.Data.Enums;

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
            };
        }
    }
}