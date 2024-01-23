using _5eCombatTracker.API.Interfaces.Repositories;
using _5eCombatTracker.API.Interfaces.Services;
using _5eCombatTracker.Data.DTO;
using _5eCombatTracker.Data.Models;
using AutoMapper;

namespace _5eCombatTracker.API.Services
{
    /// <summary>
    /// Service for handling general monster data transactions
    /// </summary>
    public class MonsterService : IMonsterService
    {
        private IMonsterRepository _monsterRepository;
        private readonly MapperConfiguration _mapperConfiguration;
        private Mapper _mapper;
        /// <summary>
        /// Creates a new Monster service, with mappings from monster to monster DTO
        /// </summary>
        /// <param name="monsterRepository">Monster repository to handle data communication</param>
        public MonsterService(IMonsterRepository monsterRepository)
        {
            _mapperConfiguration = new MapperConfiguration(mc =>
            {
                mc.CreateMap<Monster, MonsterDTO>();

                mc.CreateMap<Monster, string>()
                .ConvertUsing(m => m.Name);
            });
            _mapper = new Mapper(_mapperConfiguration);
            _monsterRepository = monsterRepository;
        }

        /// <summary>
        /// Gets monster via ID
        /// </summary>
        /// <param name="id">ID of monster to fetch</param>
        /// <returns>MonsterDTO</returns>
        public async Task<MonsterDTO> GetMonsterById(int id)
        {
            Monster monster = await _monsterRepository.GetMonsterById(id);
            return _mapper.Map<Monster, MonsterDTO>(monster);
        }

        /// <summary>
        /// Gets monster by name
        /// </summary>
        /// <param name="name">Name of monster to fetch</param>
        /// <returns>MonsterDTO</returns>
        public async Task<MonsterDTO> GetMonsterByName(string name)
        {
            Monster monster = await _monsterRepository.GetMonsterByName(name);
            return _mapper.Map<Monster, MonsterDTO>(monster);
        }

        /// <summary>
        /// Returns list of the names all monsters. This could be a large list.
        /// </summary>
        /// <returns>Monster names list</returns>
        public async Task<List<string>> GetAllMonsters()
        {
            List<Monster> monsters = await _monsterRepository.GetAllMonsters();
            return _mapper.Map<List<Monster>, List<string>>(monsters);
        }
    }
}
