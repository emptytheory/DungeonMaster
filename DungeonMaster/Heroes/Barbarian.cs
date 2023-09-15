using DungeonMaster.Equipment;
using DungeonMaster.Stats;

namespace DungeonMaster.Heroes
{
    public class Barbarian : Hero
    {
        public override HeroAttributes LevelAttributes { get; protected set; } = new(strength: 5, dexterity: 2, intelligence: 1);
        protected override HeroAttributes AttributesGain { get; } = new(strength: 3, dexterity: 2, intelligence: 1);
        protected override int DamageAttributeValue => TotalAttributes().Strength;
        protected override List<WeaponType> ValidWeaponTypes { get; } = new() { WeaponType.Hatchet, WeaponType.Mace, WeaponType.Sword };
        protected override List<ArmorType> ValidArmorTypes { get; } = new() { ArmorType.Mail, ArmorType.Plate };

        public Barbarian(string name) : base(name) { }

    }
}
