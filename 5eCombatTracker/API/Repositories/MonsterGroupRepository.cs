using _5eCombatTracker.API.Interfaces.Repositories;
using _5eCombatTracker.Data.Helpers;
using _5eCombatTracker.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace _5eCombatTracker.API.Repositories
{
    public class MonsterGroupRepository : IMonsterGroupRepository
    {

        private DataContext _dataContext;
        public MonsterGroupRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }


        public async Task<List<MonsterGroup>> GetMonsterGroupByMonsterGroupId(int id)
        {
            return await _dataContext.MonsterGroups
                .Where(mg => mg.MonsterGroupId == id)
                .Include(mg => mg.Monster)
                .ToListAsync();
        }
    }
}
