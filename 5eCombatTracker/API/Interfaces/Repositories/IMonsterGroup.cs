using _5eCombatTracker.Data.Models;

namespace _5eCombatTracker.API.Interfaces.Repositories
{
    public interface IMonsterGroupRepository
    {
        public Task<List<MonsterGroup>> GetMonsterGroupByMonsterGroupId(int id);
    }
}
