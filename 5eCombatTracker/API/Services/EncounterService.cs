using _5eCombatTracker.API.Interfaces;
using _5eCombatTracker.Data.DTO;
using _5eCombatTracker.Data.Helpers;
using _5eCombatTracker.Data.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Newtonsoft.Json;
using static _5eCombatTracker.Data.Enums;

namespace _5eCombatTracker.API.Services
{
    public class EncounterService : IEncounterService
    {
        public DataContext _dataContext;
        private readonly MapperConfiguration _mapperConfiguration;
        public EncounterService(DataContext dataContext)
        {
            _dataContext = dataContext;
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
        }

        public async Task<EncounterDTO> GetRandomEncounter(BiomeTypeEnum biomeType)
        {
            var query = _dataContext.Encounters
                .ProjectTo<EncounterDTO>(_mapperConfiguration)
                .OrderBy(x => Guid.NewGuid());

            var blah = query.ToQueryString();

           
            EncounterDTO encounter =  await query.FirstOrDefaultAsync();

            encounter.Monsters = await _dataContext.MonsterGroups
                .Where(x => x.MonsterGroupId == encounter.MonsterGroupId)
                .ProjectTo<EncounterMonsterDTO>(_mapperConfiguration).ToListAsync();

            return encounter;
        }
    }
}