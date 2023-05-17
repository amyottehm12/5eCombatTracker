using _5eCombatTracker.API.Interfaces.Repositories;
using _5eCombatTracker.API.Interfaces.Services;
using _5eCombatTracker.Data.DTO;
using _5eCombatTracker.Data.Models;
using AutoMapper;

namespace _5eCombatTracker.API.Services
{
    public class MonsterService : IMonsterService
    {
        private IMonsterRepository _monsterRepository;
        private readonly MapperConfiguration _mapperConfiguration;
        private Mapper _mapper;
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

        public async Task<MonsterDTO> GetMonsterById(int id)
        {
            Monster monster = await _monsterRepository.GetMonsterById(id);
            return _mapper.Map<Monster, MonsterDTO>(monster);
        }

        public async Task<MonsterDTO> GetMonsterByName(string name)
        {
            Monster monster = await _monsterRepository.GetMonsterByName(name);
            return _mapper.Map<Monster, MonsterDTO>(monster);
        }

        public async Task<List<string>> GetAllMonsters()
        {
            List<Monster> monsters = await _monsterRepository.GetAllMonsters();
            return _mapper.Map<List<Monster>, List<string>>(monsters);
        }
    }
}
