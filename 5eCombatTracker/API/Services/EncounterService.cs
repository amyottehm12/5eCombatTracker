using _5eCombatTracker.API.Interfaces;
using _5eCombatTracker.Data.DTO;
using _5eCombatTracker.Data.Helpers;
using _5eCombatTracker.Data.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using static _5eCombatTracker.Data.Enums;

namespace _5eCombatTracker.API.Services
{
    public class EncounterService : IEncounterService
    {
        public DataContext _dataContext;
        private readonly IMapper _mapper;
        private readonly MapperConfiguration _mapperConfiguration;
        public EncounterService(DataContext dataContext, IMapper mappper)
        {
            _dataContext = dataContext; 
            _mapper = mappper;
            _mapperConfiguration = new MapperConfiguration(mc =>
            {
                mc.CreateMap<RandomEncounter, EncounterDTO>()
                .ForMember(dto => dto.Name, conf => conf.MapFrom(encounter => encounter.Name))
                .ForMember(dto => dto.Monsters, conf => conf.MapFrom(encounter => encounter.MonsterGroup));
            });
        }

        public EncounterDTO GetRandomEncounter(BiomeTypeEnum biomeType)
        {
            var encounter = _dataContext.RandomEncounter
                .Where(x => x.Biome.Name == biomeType.ToString())
                .ProjectTo<EncounterDTO>(_mapperConfiguration)
                .OrderBy(x => Guid.NewGuid())
                .FirstOrDefault();

            return encounter;
        }

        public List<RandomEncounter> GetAllEncountersByType(BiomeTypeEnum biomeType)
        {
            List<RandomEncounter> encounter = new List<RandomEncounter>();
            return encounter = _dataContext.RandomEncounter
                .Where(x => x.Biome.Name == biomeType.ToString())
                .ToList();
        }
    }
}
