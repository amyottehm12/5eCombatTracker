using _5eCombatTracker.Data.DTO;

namespace _5eCombatTracker.API.Interfaces.Services
{
    public interface IMonsterService
    {
        public Task<MonsterDTO> GetMonsterById(int id);
        public Task<MonsterDTO> GetMonsterByName(string name);
        public Task<List<string>> GetAllMonsters();
    }
}
