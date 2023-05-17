using _5eCombatTracker.API.Services;
using _5eCombatTracker.Data.DTO;
using _5eCombatTracker.Data.Helpers;
using _5eCombatTracker.Data.Models;
using AutoMapper;

namespace _5eCombatTracker.API.Interfaces.Services
{
    public interface IBiomeTypeService
    {
        public Task<List<string>> GetAllBiomes();
    }
}
