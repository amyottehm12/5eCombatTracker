using _5eCombatTracker.Data.DTO;

namespace _5eCombatTracker.API.Interfaces
{
    public interface IMonsterService
    {
        public Task<MonsterDTO> GetMonsters(string name);
        public Task<List<string>> GetAllMonsters();
    }
}
