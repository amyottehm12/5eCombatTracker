using _5eCombatTracker.Data.DTO;

namespace _5eCombatTracker.API.Interfaces
{
    public interface IMonsterAttackService
    {
        public Task<MonsterAttackDTO> GetRandomMonsterAttack(int id);

    }
}
