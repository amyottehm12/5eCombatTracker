using _5eCombatTracker.Data.Models;

namespace _5eCombatTracker.API.Interfaces.Repositories
{
    public interface IEncounterRepository
    {
        public Task<Encounter> GetEncounterByBiomeNameRandom(string name);
    }
}
