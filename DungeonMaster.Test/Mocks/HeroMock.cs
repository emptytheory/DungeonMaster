using DungeonMaster.Equipment;
using DungeonMaster.Heroes;
using DungeonMaster.Stats;

namespace DungeonMaster.Test.Mocks
{
    internal class HeroMock : Hero
    {
        public HeroMock(string name) : base(name)
        {
        }

        protected override HeroAttributes AttributesGain => new();
        protected override int DamageAttributeValue => TotalAttributes().Strength;

        public override HeroAttributes LevelAttributes { get; protected set; } = new();

        protected override List<WeaponType> ValidWeaponTypes => new() { WeaponType.Bow, WeaponType.Staff };

        protected override List<ArmorType> ValidArmorTypes => new() { ArmorType.Leather, ArmorType.Cloth };

    }
}
