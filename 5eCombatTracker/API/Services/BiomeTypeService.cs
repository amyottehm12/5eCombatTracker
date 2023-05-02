using _5eCombatTracker.API.Interfaces;
using _5eCombatTracker.Data.DTO;
using _5eCombatTracker.Data.Helpers;
using _5eCombatTracker.Data.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace _5eCombatTracker.API.Services
{
    public class BiomeTypeService : IBiomeTypeService
    {
        public DataContext _dataContext;
        private readonly MapperConfiguration _mapperConfiguration;
        public BiomeTypeService(DataContext dataContext)
        {
            _dataContext = dataContext;
            _mapperConfiguration = new MapperConfiguration(mc =>
            {
                mc.CreateMap<BiomeType, string>()
                .ConvertUsing(bt => bt.Name);
            });
        }

        public async Task<List<string>> GetAllBiomes()
        {
            List<string> biomeTypes = await _dataContext.BiomeType
                .ProjectTo<string>(_mapperConfiguration)
                .ToListAsync();

            return biomeTypes;
        }
    }
}
