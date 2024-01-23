using _5eCombatTracker.API.Interfaces.Repositories;
using _5eCombatTracker.API.Interfaces.Services;
using _5eCombatTracker.Data.DTO;
using _5eCombatTracker.Data.Models;
using AutoMapper;
using static _5eCombatTracker.Data.Enums;

namespace _5eCombatTracker.API.Services
{
    public class EncounterService : IEncounterService
    {
        private IEncounterRepository _encounterRepository;
        private IMonsterGroupRepository _monsterGroupRepository;
        private readonly MapperConfiguration _mapperConfiguration;
        private Mapper _mapper;
        public EncounterService(IEncounterRepository encounterRepository, IMonsterGroupRepository monsterGroupRepository)
        {
            _mapperConfiguration = new MapperConfiguration(mc =>
            {
                mc.CreateMap<Encounter, EncounterDTO>();
                mc.CreateMap<MonsterGroup, EncounterMonsterDTO>()
                    .ConvertUsing(monsterGroup => new EncounterMonsterDTO
                    {
                        Monster = new MonsterDTO {
                            Id = monsterGroup.MonsterId,
                            Name = monsterGroup.Monster.Name,
                            AC = monsterGroup.Monster.AC,
                            HP = monsterGroup.Monster.HP
                        },
                        Quantity = monsterGroup.Quantity
                    });
            });
            _mapper = new Mapper(_mapperConfiguration);
            _encounterRepository = encounterRepository;
            _monsterGroupRepository = monsterGroupRepository;
        }

        public async Task<EncounterDTO> GetRandomEncounter(BiomeTypeEnum biomeType)
        {
            Encounter encounter = await _encounterRepository.GetEncounterByBiomeNameRandom(biomeType.ToString());
            if (encounter == null) { return null; }
            EncounterDTO encounterDTO = _mapper.Map<Encounter, EncounterDTO>(encounter);
            
            List<MonsterGroup> monsterGroup = await _monsterGroupRepository.GetMonsterGroupByMonsterGroupId(encounter.MonsterGroupId);
            if (monsterGroup == null) { return null; }
            encounterDTO.Monsters = _mapper.Map<List<MonsterGroup>, List<EncounterMonsterDTO>>(monsterGroup);

            return encounterDTO;
        }
    }
}