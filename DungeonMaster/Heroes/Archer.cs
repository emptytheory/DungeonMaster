using DungeonMaster.Equipment;
using DungeonMaster.Stats;

namespace DungeonMaster.Heroes
{
    public class Archer : Hero
    {
        public override HeroAttributes LevelAttributes { get; protected set; } = new(strength: 1, dexterity: 7, intelligence: 1);
        protected override HeroAttributes AttributesGain { get; } = new(strength: 1, dexterity: 5, intelligence: 1);
        protected override int DamageAttributeValue => TotalAttributes().Dexterity;
        protected override List<WeaponType> ValidWeaponTypes { get; } = new() { WeaponType.Bow };
        protected override List<ArmorType> ValidArmorTypes { get; } = new() { ArmorType.Mail, ArmorType.Leather };

        public Archer(string name) : base(name) { }

    }
}
