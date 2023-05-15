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
    public class MonsterAttackService : IMonsterAttackService
    {
        private DataContext _dataContext;
        private readonly MapperConfiguration _mapperConfiguration;
        public MonsterAttackService(DataContext dataContext)
        {
            _dataContext = dataContext;
            _mapperConfiguration = new MapperConfiguration(mc =>
            {
                mc.CreateMap<MonsterAttack, MonsterAttackDTO>();
            });
        }

        public async Task<MonsterAttackDTO> GetRandomMonsterAttack(int id)
        {
            MonsterAttackDTO monsterAttack = await _dataContext.MonsterAttacks
                .Where(x => x.MonsterId == id)
                .ProjectTo<MonsterAttackDTO>(_mapperConfiguration)
                .OrderBy(x => Guid.NewGuid())
                .FirstOrDefaultAsync();

            return monsterAttack;
        }
    }
}
