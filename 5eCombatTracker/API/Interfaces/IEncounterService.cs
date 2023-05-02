using _5eCombatTracker.Data.DTO;
using _5eCombatTracker.Data.Models;
using static _5eCombatTracker.Data.Enums;

namespace _5eCombatTracker.API.Interfaces
{
    public interface IEncounterService
    {
        public Task<EncounterDTO> GetRandomEncounter(BiomeTypeEnum biomeType);
    }
}
