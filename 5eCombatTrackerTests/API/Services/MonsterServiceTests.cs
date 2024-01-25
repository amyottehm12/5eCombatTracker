using Microsoft.VisualStudio.TestTools.UnitTesting;
using _5eCombatTracker.Data.Models;
using Moq;
using _5eCombatTracker.API.Interfaces.Repositories;
using _5eCombatTracker.Data.DTO;
using Newtonsoft.Json;

namespace _5eCombatTracker.API.Services.Tests
{
    [TestClass()]
    public class MonsterServiceTests
    {
        /// <summary>
        /// Happy path test for getting monster by ID
        /// </summary>
        [TestMethod()]
        public void GetMonsterById()
        {
            var mockRepository = new Mock<IMonsterRepository>();
            var service = new MonsterService(mockRepository.Object);

            Monster mockRepositoryResponse = StubMonster();
            Task<Monster> successResponse = Task.FromResult(mockRepositoryResponse);
            mockRepository.Setup(x => x.GetMonsterById(1)).Returns(successResponse);
            MonsterDTO expectedResult = StubMonsterDTO();

            var actualResult = service.GetMonsterById(1).Result;
            var actualJSON = JsonConvert.SerializeObject(actualResult);
            var expectedJSON = JsonConvert.SerializeObject(expectedResult);

            Assert.IsNotNull(actualResult);
            Assert.AreEqual(actualJSON, expectedJSON);
        }

        /// <summary>
        /// Happy path test for getting monster by name
        /// </summary>
        [TestMethod()]
        public void GetMonsterByNameTest()
        {
            var mockRepository = new Mock<IMonsterRepository>();
            var service = new MonsterService(mockRepository.Object);

            Monster mockRepositoryResponse = StubMonster();
            Task<Monster> successResponse = Task.FromResult(mockRepositoryResponse);
            mockRepository.Setup(x => x.GetMonsterByName("Skeleton")).Returns(successResponse);
            MonsterDTO expectedResult = StubMonsterDTO();

            var actualResult = service.GetMonsterByName("Skeleton").Result;
            var actualJSON = JsonConvert.SerializeObject(actualResult);
            var expectedJSON = JsonConvert.SerializeObject(expectedResult);

            Assert.IsNotNull(actualResult);
            Assert.AreEqual(actualJSON, expectedJSON);
        }

        /// <summary>
        /// Happy path test for getting all monsters. 
        /// this one has a mapping from List of MonsterDTO to List of string
        /// </summary>
        [TestMethod()]
        public void GetAllMonstersTest()
        {
            var mockRepository = new Mock<IMonsterRepository>();
            var service = new MonsterService(mockRepository.Object);

            List<Monster> mockRepositoryResponse = new List<Monster>();
            mockRepositoryResponse.Add(StubMonster());
            mockRepositoryResponse.Add(StubSecondMonster());
            Task<List<Monster>> successResponse = Task.FromResult(mockRepositoryResponse);
            mockRepository.Setup(x => x.GetAllMonsters()).Returns(successResponse);
            List<string> expectedResult = StubMonsterList();

            var actualResult = service.GetAllMonsters().Result;
            var actualJSON = JsonConvert.SerializeObject(actualResult);
            var expectedJSON = JsonConvert.SerializeObject(expectedResult);

            Assert.IsNotNull(actualResult);
            Assert.AreEqual(actualJSON, expectedJSON);
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

        public Monster StubSecondMonster()
        {
            return new Monster()
            {
                AC = 12,
                Alignment = "Test",
                CR = "1",
                HP = 2,
                Id = 4,
                Legendary = "false",
                Name = "Zombie",
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

        public MonsterDTO StubMonsterDTO()
        {
            return new MonsterDTO()
            {
                Id = 3,
                AC = 12,
                HP = 2,
                Name = "Skeleton"
            };
        }

        public List<string> StubMonsterList()
        {
            return new List<string>
            {
                "Skeleton", "Zombie"
            };
        }
    }
}