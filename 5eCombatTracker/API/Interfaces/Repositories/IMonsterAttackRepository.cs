using _5eCombatTracker.Data.Models;

namespace _5eCombatTracker.API.Interfaces.Repositories
{
    public interface IMonsterAttackRepository
    {
        public Task<MonsterAttack> GetMonsterAttackByIdRandom(int id);
    }
}
