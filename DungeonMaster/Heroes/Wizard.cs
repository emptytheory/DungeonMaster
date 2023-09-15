using DungeonMaster.Equipment;
using DungeonMaster.Stats;

namespace DungeonMaster.Heroes
{
    public class Wizard : Hero
    {
        public override HeroAttributes LevelAttributes { get; protected set; } = new(strength: 1, dexterity: 1, intelligence: 8);
        protected override HeroAttributes AttributesGain { get; } = new(strength: 1, dexterity: 1, intelligence: 5);
        protected override int DamageAttributeValue => TotalAttributes().Intelligence;
        protected override List<WeaponType> ValidWeaponTypes { get; } = new() { WeaponType.Staff, WeaponType.Wand };
        protected override List<ArmorType> ValidArmorTypes { get; } = new() { ArmorType.Cloth };

        public Wizard(string name) : base(name) { }

    }
}
