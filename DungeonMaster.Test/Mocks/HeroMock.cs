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

        public override HeroAttributes LevelAttributes { get; protected set; } = new();

        protected override List<WeaponType> ValidWeaponTypes => new() { WeaponType.Bow };

        protected override List<ArmorType> ValidArmorTypes => new() { ArmorType.Leather };

        public override double Damage()
        {
            return 0.0;
        }
    }
}
