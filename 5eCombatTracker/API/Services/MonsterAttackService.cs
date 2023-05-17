using _5eCombatTracker.API.Interfaces.Repositories;
using _5eCombatTracker.API.Interfaces.Services;
using _5eCombatTracker.Data.DTO;
using _5eCombatTracker.Data.Models;
using AutoMapper;

namespace _5eCombatTracker.API.Services
{
    public class MonsterAttackService : IMonsterAttackService
    {
        private IMonsterAttackRepository _mosnterAttackRepository;
        private readonly MapperConfiguration _mapperConfiguration;
        private Mapper _mapper;
        public MonsterAttackService(IMonsterAttackRepository monsterAttackRepository)
        {
            _mapperConfiguration = new MapperConfiguration(mc =>
            {
                mc.CreateMap<MonsterAttack, MonsterAttackDTO>();
            });
            _mapper = new Mapper(_mapperConfiguration);
            _mosnterAttackRepository = monsterAttackRepository;
        }

        public async Task<MonsterAttackDTO> GetRandomMonsterAttack(int id)
        {

            MonsterAttack monsterAttack = await _mosnterAttackRepository.GetMonsterAttackByIdRandom(id);

            return _mapper.Map<MonsterAttack, MonsterAttackDTO>(monsterAttack);
        }
    }
}
