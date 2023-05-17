using _5eCombatTracker.Data.Models;

namespace _5eCombatTracker.API.Interfaces.Repositories
{
    public interface IBiomeTypeRepository
    {
        public Task<List<BiomeType>> GetAllBiomeTypesAsync();
    }
}
