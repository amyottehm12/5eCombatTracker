using _5eCombatTracker.Data.Models;

namespace _5eCombatTracker.API.Interfaces.Repositories
{
    public interface IMonsterRepository
    {
        public Task<List<Monster>> GetAllMonsters();
        public Task<Monster> GetMonsterById(int id);
        public Task<Monster> GetMonsterByName(string name);
    }
}
