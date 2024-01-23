using Microsoft.VisualStudio.TestTools.UnitTesting;
using _5eCombatTracker.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _5eCombatTracker.API.Interfaces.Repositories;
using Moq;
using _5eCombatTracker.API.Interfaces.Services;
using _5eCombatTracker.Data.Models;

namespace _5eCombatTracker.API.Services.Tests
{
    [TestClass()]
    public class BiomeTypeServiceTests
    {
        /// <summary>
        /// Will correctly map just the Name values from the full results set of the repository
        /// </summary>
        [TestMethod()]
        public void GetAllBiomesTest()
        {
            var mockRepository = new Mock<IBiomeTypeRepository>();
            var service = new BiomeTypeService(mockRepository.Object);
            var mockedResult = new List<BiomeType>() { 
                new BiomeType { Id = 1, Name = "TestBiome1", Description = "Test Description Biome1" },
                new BiomeType { Id = 2, Name = "TestBiome2", Description = "Test Description Biome2" } 
            };
            var expectedResult = new List<string> { "TestBiome1", "TestBiome2" };

            Task<List<BiomeType>> successTask = Task.FromResult(mockedResult);
            mockRepository.Setup(x => x.GetAllBiomeTypesAsync()).Returns(successTask);

            var actualResult = service.GetAllBiomes().Result;

            Assert.IsNotNull(actualResult);
            CollectionAssert.AreEquivalent(expectedResult, actualResult);
        }
    }
}