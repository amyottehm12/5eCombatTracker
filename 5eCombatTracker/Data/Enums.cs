﻿using Newtonsoft.Json.Converters;
using System.Text.Json.Serialization;

namespace _5eCombatTracker.Data
{
    public class Enums
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public enum BiomeTypeEnum
        {
            Forest = 1,
            Mountains = 2,
            Dungeon = 3
        }
    }
}
