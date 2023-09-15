using DungeonMaster.Equipment;
using DungeonMaster.Stats;

namespace DungeonMaster.Heroes
{
    public class Swashbuckler : Hero
    {
        public override HeroAttributes LevelAttributes { get; protected set; } = new(strength: 2, dexterity: 6, intelligence: 1);
        protected override HeroAttributes AttributesGain { get; } = new(strength: 1, dexterity: 4, intelligence: 1);
        protected override int DamageAttributeValue => TotalAttributes().Dexterity;
        protected override List<WeaponType> ValidWeaponTypes { get; } = new() { WeaponType.Dagger, WeaponType.Sword };
        protected override List<ArmorType> ValidArmorTypes { get; } = new() { ArmorType.Mail, ArmorType.Leather };

        public Swashbuckler(string name) : base(name) { }

    }
}
