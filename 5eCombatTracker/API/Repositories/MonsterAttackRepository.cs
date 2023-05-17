using _5eCombatTracker.API.Interfaces.Repositories;
using _5eCombatTracker.Data.DTO;
using _5eCombatTracker.Data.Helpers;
using _5eCombatTracker.Data.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace _5eCombatTracker.API.Repositories
{
    public class MonsterAttackRepository : IMonsterAttackRepository
    {
        private DataContext _dataContext;
        public MonsterAttackRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<MonsterAttack> GetMonsterAttackByIdRandom(int id)
        {
            MonsterAttack attack = await _dataContext.MonsterAttacks
                .Where(x => x.MonsterId == id)
                .OrderBy(x => Guid.NewGuid())
                .FirstOrDefaultAsync();

            return attack;
        }
    }
}
