namespace DungeonMaster.Stats
{
    internal class HeroAttributes
    {
        public required int Strength { get; init; }
        public required int Dexterity { get; init; }
        public required int Intelligence { get; init; }

        /*
        public HeroAttribute(int strength, int dexterity, int intelligence)
        {
            Strength = strength;
            Dexterity = dexterity;
            Intelligence = intelligence;
        }
        */

        public HeroAttributes() { }
        
        public HeroAttributes Add(HeroAttributes term)
        {
            return new HeroAttributes()
            {
                Strength = Strength + term.Strength,
                Dexterity = Dexterity + term.Dexterity,
                Intelligence = Intelligence + term.Intelligence
            };
        }

        public override string ToString()
        {
            return $"Strength: {Strength}\nDexterity: {Dexterity}\nIntelligence: {Intelligence}";

        }
    }
}
