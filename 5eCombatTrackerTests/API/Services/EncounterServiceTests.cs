using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using _5eCombatTracker.API.Interfaces.Repositories;
using _5eCombatTracker.Data.Models;
using _5eCombatTracker.Data.DTO;
using Newtonsoft.Json;

namespace _5eCombatTracker.API.Services.Tests
{
    [TestClass()]
    public class EncounterServiceTests
    {
        [TestMethod()]
        public void GetRandomEncounterTest()
        {
            var mockedEncounterRepository = new Mock<IEncounterRepository>();
            var mockMonsterGroupRepository = new Mock<IMonsterGroupRepository>();
            var service = new EncounterService(mockedEncounterRepository.Object, mockMonsterGroupRepository.Object);

            Encounter mockedEncounterResponse = StubEncounter();
            Task<Encounter> successTask = Task.FromResult(mockedEncounterResponse);
            mockedEncounterRepository
                .Setup(x => x.GetEncounterByBiomeNameRandom("Dungeon"))
                .Returns(successTask);
            List<MonsterGroup> mockedMonsterGroupResponse = StubMonsterGroup();
            Task<List<MonsterGroup>> successMonsterTask = Task.FromResult(mockedMonsterGroupResponse);
            mockMonsterGroupRepository
                .Setup(x => x.GetMonsterGroupByMonsterGroupId(1))
                .Returns(successMonsterTask);
            EncounterDTO expectedResult = StubEncounterDTO();

            var actualResult = service.GetRandomEncounter(Data.Enums.BiomeTypeEnum.Dungeon).Result;
            var actualJSON = JsonConvert.SerializeObject(actualResult);
            var expectedJSON = JsonConvert.SerializeObject(expectedResult);

            Assert.IsNotNull(actualResult);
            Assert.AreEqual(actualJSON, expectedJSON);
        }

        public Encounter StubEncounter()
        {
            return new Encounter()
            {
                EncounterId = 1,
                BiomeTypeId = 1,
                MonsterGroupId = 1,
                Name = "The Skeletons"
            };
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

        public List<MonsterGroup> StubMonsterGroup()
        {
            return new List<MonsterGroup>()
            {
                new MonsterGroup
                {
                    MonsterGroupId = 1,
                    MonsterId = 1,
                    Quantity = 2,
                    Monster = new Monster()
                    {
                        Id = 1,
                        Name = "Skeleton",
                        AC = 11,
                        HP = 10,
                    }
                }
            };
        }
    }
}