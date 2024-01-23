using _5eCombatTracker.API.Interfaces.Repositories;
using _5eCombatTracker.Data.Helpers;
using _5eCombatTracker.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace _5eCombatTracker.API.Repositories
{
    /// <summary>
    /// Repository layer for BiomeType, has EF queries to postgress
    /// </summary>
    public class BiomeTypeRepository : IBiomeTypeRepository
    {
        /// <summary>
        /// Context for EF
        /// </summary>
        public DataContext _dataContext;

        /// <summary>
        /// Initializes context for EF
        /// </summary>
        /// <param name="dataContext"></param>
        public BiomeTypeRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        /// <summary>
        /// Grabs all biome types
        /// </summary>
        /// <returns>Biome Type model</returns>
        public async Task<List<BiomeType>> GetAllBiomeTypesAsync()
        {
            List<BiomeType> biomeTypes = await _dataContext.BiomeTypes
                .ToListAsync();

            return biomeTypes;
        }
    }
}
