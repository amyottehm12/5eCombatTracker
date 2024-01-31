using _5eCombatTracker.API.Interfaces.Repositories;
using _5eCombatTracker.API.Interfaces.Services;
using _5eCombatTracker.Data.DTO;
using _5eCombatTracker.Data.Models;
using AutoMapper;

namespace _5eCombatTracker.API.Services
{
    /// <summary>
    /// Handles generating attacks for given monsters
    /// </summary>
    public class MonsterAttackService : IMonsterAttackService
    {
        private IMonsterAttackRepository _mosnterAttackRepository;
        private readonly MapperConfiguration _mapperConfiguration;
        private Mapper _mapper;

        /// <summary>
        /// Constructor using monster attack repository, creates maps needed for responses
        /// </summary>
        /// <param name="monsterAttackRepository">Monster attack repository</param>
        public MonsterAttackService(IMonsterAttackRepository monsterAttackRepository)
        {
            _mapperConfiguration = new MapperConfiguration(mc =>
            {
                mc.CreateMap<MonsterAttack, MonsterAttackDTO>();
                //This maps the name item, from the FK table DamageType, right into the DTO. so we don't have to transfer the whole damage type object
                mc.CreateMap<MonsterAttack, string>().ConvertUsing(dt => dt.DamageType.Name);
            });
            _mapper = new Mapper(_mapperConfiguration);
            _mosnterAttackRepository = monsterAttackRepository;
        }

        /// <summary>
        /// Returns a random monster attack via monster ID
        /// </summary>
        /// <param name="id">ID of monster to generate attack</param>
        /// <returns></returns>
        public async Task<MonsterAttackDTO> GetRandomMonsterAttack(int id)
        {

            MonsterAttack monsterAttack = await _mosnterAttackRepository.GetMonsterAttackByIdRandom(id);

            return _mapper.Map<MonsterAttack, MonsterAttackDTO>(monsterAttack);
        }
    }
}
