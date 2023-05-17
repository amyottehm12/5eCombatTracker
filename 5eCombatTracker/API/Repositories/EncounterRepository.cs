using _5eCombatTracker.API.Interfaces.Repositories;
using _5eCombatTracker.Data.Helpers;
using _5eCombatTracker.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace _5eCombatTracker.API.Repositories
{
    public class EncounterRepository : IEncounterRepository
    {
        private DataContext _dataContext;
        public EncounterRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Encounter> GetEncounterByBiomeNameRandom(string name)
        {
            Encounter encounter = await _dataContext.Encounters
                .Where(e => e.BiomeType.Name == name)
                .OrderBy(x => Guid.NewGuid())
                .FirstOrDefaultAsync();

            return encounter;
        }
    }
}
