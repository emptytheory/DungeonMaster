using DungeonMaster.Equipment.Armor;
using DungeonMaster.Equipment;
using DungeonMaster.Equipment.Weapon;
using DungeonMaster.Stats;

namespace DungeonMaster.Heroes
{
    internal class Wizard : Hero
    {
        protected override List<WeaponType> ValidWeaponTypes { get; set; } = new() { WeaponType.Staff, WeaponType.Wand };
        protected override List<ArmorType> ValidArmorTypes { get; set; } = new() { };
        protected override HeroAttributes AttributesGain { get; set; } = new()
        {
            Strength = 1,
            Dexterity = 1,
            Intelligence = 5
        };
        protected override HeroAttributes LevelAttributes { get; set; } = new()
        {
            Strength = 1,
            Dexterity = 1,
            Intelligence = 8
        };

        public Wizard(string name) : base(name)
        {
            //ValidWeaponTypes = new() {WeaponType.Staff, WeaponType.Wand};
            //LevelAttributes = new()
            //{
            //    Strength = 1,
            //    Dexterity = 1,
            //    Intelligence = 8
            //};
            //AttributesGain = new()
            //{
            //    Strength = 1,
            //    Dexterity = 1,
            //    Intelligence = 5
            //};
        }

        public override int Damage()
        {
            int baseDamage = Equipment[Slot.Weapon] is Weapon weapon ? weapon.WeaponDamage : 1;

            return baseDamage + TotalAttributes().Intelligence;
        }
    }
}
