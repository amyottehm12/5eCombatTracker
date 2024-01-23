using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using _5eCombatTracker.API.Interfaces.Repositories;
using _5eCombatTracker.Data.Models;
using _5eCombatTracker.Data.DTO;
using Newtonsoft.Json;

namespace _5eCombatTracker.API.Services.Tests
{
    /// <summary>
    /// Happy path test for monster attack
    /// </summary>
    [TestClass()]
    public class MonsterAttackServiceTests
    {
        [TestMethod()]
        public void GetRandomMonsterAttackTest()
        {
            var mockRepository = new Mock<IMonsterAttackRepository>();
            var service = new MonsterAttackService(mockRepository.Object);

            MonsterAttack mockRepositoryResult = StubMonsterAttack();
            Task<MonsterAttack> successResult = Task.FromResult(mockRepositoryResult);
            mockRepository
                .Setup(x => x.GetMonsterAttackByIdRandom(1))
                .Returns(successResult);
            MonsterAttackDTO expectedResult = StubMonsterAttackDTO();

            var actualResult = service.GetRandomMonsterAttack(1).Result;
            var actualJSON = JsonConvert.SerializeObject(actualResult);
            var expectedJSON = JsonConvert.SerializeObject(expectedResult);

            Assert.IsNotNull(actualResult);
            Assert.AreEqual(expectedJSON, actualJSON);
        }

        public MonsterAttack StubMonsterAttack()
        {
            return new MonsterAttack()
            {
                Id = 1,
                DamageBonus = 1,
                DamageDie = 6,
                DescriptionSet =
                new List<string> { "Test attack description 1", "Test attack description 1" },
                ExtraEffect = "none",
                WeaponName = "Test attack",
                HitRoll = 20,
                MonsterId = 1,
                Monster = StubMonster()
            };
        }

        public Monster StubMonster()
        {
            return new Monster()
            {
                AC = 12,
                Alignment = "Test",
                CR = "1",
                HP = 2,
                Id = 3,
                Legendary = "false",
                Name = "Skeleton",
                Size = "Medium",
                Source = "Base",
                Speed = "30",
                Type = "1",
                URL = "1",
                _Cha = 10,
                _Con = 10,
                _Dex = 10,
                _Int = 10,
                _Str = 10,
                _Wis = 10
            };
        }

        public MonsterAttackDTO StubMonsterAttackDTO()
        {
            return new MonsterAttackDTO()
            {
                DamageBonus = 1,
                DamageDie = 6,
                ExtraEffect = "none",
                HitRoll = 20,
                WeaponName = "Test attack"
            };
        }
    }
}