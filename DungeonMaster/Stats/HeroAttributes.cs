namespace DungeonMaster.Stats
{
    public class HeroAttributes
    {
        public int Strength { get; } = 0;
        public int Dexterity { get; } = 0;
        public int Intelligence { get; } = 0;

        public HeroAttributes(int strength, int dexterity, int intelligence)
        {
            Strength = strength;
            Dexterity = dexterity;
            Intelligence = intelligence;
        }

        public HeroAttributes() { }
        
        public HeroAttributes Add(HeroAttributes term)
        {
            return new HeroAttributes(strength: Strength + term.Strength,
                                      dexterity: Dexterity + term.Dexterity,
                                      intelligence: Intelligence + term.Intelligence);

        }

        public override string ToString()
        {
            return $"Strength: {Strength}\nDexterity: {Dexterity}\nIntelligence: {Intelligence}";

        }

        public override bool Equals(object? obj)
        {
            return obj is HeroAttributes attributes &&
                   Strength == attributes.Strength &&
                   Dexterity == attributes.Dexterity &&
                   Intelligence == attributes.Intelligence;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Strength, Dexterity, Intelligence);
        }
    }
}
