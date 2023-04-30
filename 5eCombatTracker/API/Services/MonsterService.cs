using _5eCombatTracker.API.Interfaces;
using _5eCombatTracker.Data.DTO;
using _5eCombatTracker.Data.Helpers;
using _5eCombatTracker.Data.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
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
            });
        }


        public async Task<MonsterDTO> GetMonster(string name)
        {
            MonsterDTO monster = _dataContext.Monster
                .ProjectTo<MonsterDTO>(_mapperConfiguration)
                .FirstOrDefault(m => m.Name == name.ToLower());

            return monster;
        }

        public async Task<List<string>> GetAllMonsters()
        {
            List<string> monsters = _dataContext.Monster
                .ProjectTo<string>(_mapperConfiguration)
                .ToList();

            return monsters;
        }
    }
}
