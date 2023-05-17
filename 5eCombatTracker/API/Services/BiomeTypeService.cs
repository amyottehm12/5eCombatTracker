using _5eCombatTracker.API.Interfaces.Repositories;
using _5eCombatTracker.API.Interfaces.Services;
using _5eCombatTracker.Data.Models;
using AutoMapper;

namespace _5eCombatTracker.API.Services
{
    public class BiomeTypeService : IBiomeTypeService
    {
        private IBiomeTypeRepository _biomeTypeRepository;
        private readonly MapperConfiguration _mapperConfiguration;
        private Mapper _mapper;
        public BiomeTypeService(IBiomeTypeRepository biomeTypeRepository)
        {
            _mapperConfiguration = new MapperConfiguration(mc =>
            {
                mc.CreateMap<BiomeType, string>()
                .ConvertUsing(bt => bt.Name);
            });
            _mapper = new Mapper(_mapperConfiguration);
            _biomeTypeRepository = biomeTypeRepository;
        }

        public async Task<List<string>> GetAllBiomes()
        {
            List<BiomeType> biomeTypes = await _biomeTypeRepository.GetAllBiomeTypesAsync();
            return _mapper.Map<List<BiomeType>, List<string>>(biomeTypes);
        }
    }
}
