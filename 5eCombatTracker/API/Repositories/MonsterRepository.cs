using _5eCombatTracker.API.Interfaces.Repositories;
using _5eCombatTracker.Data.Helpers;
using _5eCombatTracker.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace _5eCombatTracker.API.Repositories
{
    public class MonsterRepository : IMonsterRepository
    {
        private DataContext _dataContext;
        public MonsterRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Monster>> GetAllMonsters()
        {
            var monsters = await _dataContext.Monsters.ToListAsync();
            return monsters;
        }

        public async Task<Monster> GetMonsterById(int id)
        {
            var monster = await _dataContext.Monsters.FirstOrDefaultAsync(m => m.Id == id);
            return monster;
        }

        public async Task<Monster> GetMonsterByName(string name)
        {
            var monster = await _dataContext.Monsters.FirstOrDefaultAsync(m => m.Name == name);
            return monster;
        }
    }
}
