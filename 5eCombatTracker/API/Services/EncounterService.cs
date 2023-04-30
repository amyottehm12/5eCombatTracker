using _5eCombatTracker.API.Interfaces;
using _5eCombatTracker.Data.DTO;
using _5eCombatTracker.Data.Helpers;
using _5eCombatTracker.Data.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Newtonsoft.Json;
using static _5eCombatTracker.Data.Enums;

namespace _5eCombatTracker.API.Services
{
    public class EncounterService : IEncounterService
    {
        private readonly IMonsterService _monsterService;
        public DataContext _dataContext;
        private readonly MapperConfiguration _mapperConfiguration;
        public EncounterService(DataContext dataContext, IMonsterService monsterService)
        {
            _monsterService = monsterService;
            _dataContext = dataContext;
            _mapperConfiguration = new MapperConfiguration(mc =>
            {
                mc.CreateMap<RandomEncounter, EncounterDTO>()
                .ForMember(dto => dto.Name, conf => conf.MapFrom(encounter => encounter.Name))
                .ForMember(dto => dto.Monsters, conf => conf.MapFrom(encounter => encounter.MonsterGroup));
            });
        }

        public async Task<EncounterDTO> GetRandomEncounter(BiomeTypeEnum biomeType)
        {
            EncounterDTO encounter = _dataContext.RandomEncounter
                .Where(x => x.Biome.Name == biomeType.ToString())
                .ProjectTo<EncounterDTO>(_mapperConfiguration)
                .OrderBy(x => Guid.NewGuid())
                .FirstOrDefault();

            return encounter;
        }

        private List<RandomEncounter> GetAllEncountersByType(BiomeTypeEnum biomeType)
        {
            List<RandomEncounter> encounter = new List<RandomEncounter>();
            return encounter = _dataContext.RandomEncounter
                .Where(x => x.Biome.Name == biomeType.ToString())
                .ToList();
        }
    }
}