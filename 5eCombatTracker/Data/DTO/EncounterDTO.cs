namespace _5eCombatTracker.Data.DTO
{
    public class EncounterDTO
    {
        public string Name { get; set; }
        public int MonsterGroupId { get; set; }
        public List<EncounterMonsterDTO> Monsters { get; set; }
    }
}
