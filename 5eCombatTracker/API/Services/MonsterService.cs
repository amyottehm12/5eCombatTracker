using _5eCombatTracker.API.Interfaces;
using _5eCombatTracker.Data.DTO;
using _5eCombatTracker.Data.Helpers;
using _5eCombatTracker.Data.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace _5eCombatTracker.API.Services
{
    public class MonsterService : IMonsterService
    {
        private DataContext _dataContext;
        private readonly MapperConfiguration _mapperConfiguration;
        public MonsterService(DataContext dataContext)
        {
            _dataContext = dataContext;
            _mapperConfiguration = new MapperConfiguration(mc =>
            {
                mc.CreateMap<Monster, MonsterDTO>()
                .ForMember(dto => dto.Name, conf => conf.MapFrom(monster => monster.Name))
                .ForMember(dto => dto.AC, conf => conf.MapFrom(monster => monster.HP))
                .ForMember(dto => dto.HP, conf => conf.MapFrom(monster => monster.AC));

                mc.CreateMap<Monster, string>()
                .ConvertUsing(m => m.Name);

                mc.CreateMap<MonsterAttacks, MonsterAttackDTO>();
            });
        }


        public async Task<MonsterDTO> GetMonster(string name)
        {
            MonsterDTO monster = await _dataContext.Monster
                .ProjectTo<MonsterDTO>(_mapperConfiguration)
                .FirstOrDefaultAsync(m => m.Name == name.ToLower());

            return monster;
        }

        public async Task<List<string>> GetAllMonsters()
        {
            List<string> monsters = await _dataContext.Monster
                .ProjectTo<string>(_mapperConfiguration)
                .ToListAsync();

            return monsters;
        }

        public async Task<MonsterAttackDTO> GetRandomMonsterAttack(string monster)
        {
            MonsterAttackDTO monsterAttack = await _dataContext.MonsterAttacks
                .Where(x => x.MonsterId.Name == monster)
                .ProjectTo<MonsterAttackDTO>(_mapperConfiguration)
                .OrderBy(x => Guid.NewGuid())
                .FirstOrDefaultAsync();

            return monsterAttack;
        }
    }
}
