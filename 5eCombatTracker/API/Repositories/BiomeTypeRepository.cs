using _5eCombatTracker.API.Interfaces.Repositories;
using _5eCombatTracker.API.Interfaces.Services;
using _5eCombatTracker.Data.Helpers;
using _5eCombatTracker.Data.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace _5eCombatTracker.API.Repositories
{
    public class BiomeTypeRepository : IBiomeTypeRepository
    {
        public DataContext _dataContext;
        public BiomeTypeRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<BiomeType>> GetAllBiomeTypesAsync()
        {
            List<BiomeType> biomeTypes = await _dataContext.BiomeTypes
                .ToListAsync();

            return biomeTypes;
        }
    }
}
