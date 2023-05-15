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
                mc.CreateMap<Monster, MonsterDTO>();

                mc.CreateMap<Monster, string>()
                .ConvertUsing(m => m.Name);
            });
        }

        public async Task<MonsterDTO> GetMonsterById(int id)
        {
            MonsterDTO monster = await _dataContext.Monsters
                .ProjectTo<MonsterDTO>(_mapperConfiguration)
                .FirstOrDefaultAsync(m => m.Id == id);

            return monster;
        }

        public async Task<MonsterDTO> GetMonsterByName(string name)
        {
            MonsterDTO monster = await _dataContext.Monsters
                .ProjectTo<MonsterDTO>(_mapperConfiguration)
                .FirstOrDefaultAsync(m => m.Name.ToLower() == name.ToLower());

            return monster;
        }

        public async Task<List<string>> GetAllMonsters()
        {
            List<string> monsters = await _dataContext.Monsters
                .ProjectTo<string>(_mapperConfiguration)
                .ToListAsync();

            return monsters;
        }
    }
}
