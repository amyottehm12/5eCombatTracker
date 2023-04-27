﻿using _5eCombatTracker.API.Interfaces;
using _5eCombatTracker.Data.DTO;
using _5eCombatTracker.Data.Helpers;
using _5eCombatTracker.Data.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Xml.Linq;

namespace _5eCombatTracker.API.Services
{
    public class MonsterService : IMonsterService
    {
        private DataContext _dataContext;
        private readonly IMapper _mapper;
        private readonly MapperConfiguration _mapperConfiguration;
        public MonsterService(DataContext dataContext, IMapper mappper)
        {
            _dataContext = dataContext;
            _mapper = mappper;
            _mapperConfiguration = new MapperConfiguration(mc =>
            {
                mc.CreateMap<Monster, MonsterDTO>()
                .ForMember(dto => dto.Name, conf => conf.MapFrom(monster => monster.Name))
                .ForMember(dto => dto.AC, conf => conf.MapFrom(monster => monster.HP))
                .ForMember(dto => dto.HP, conf => conf.MapFrom(monster => monster.AC));
            });
        }


        public async Task<MonsterDTO> GetMonster(string name)
        {
            MonsterDTO monster = new MonsterDTO();
            monster = _dataContext.Monster
                .ProjectTo<MonsterDTO>(_mapperConfiguration)
                .FirstOrDefault(m => m.Name == name);

            return monster;
        }

        public async Task<List<string>> GetAllMonsters()
        {
            List<string> monsters = new List<string>();
            monsters = _dataContext.Monster
                .ProjectTo<MonsterDTO>(_mapperConfiguration)
                .Select(x => x.Name)
                .ToList();

            return monsters;
        }
    }
}
