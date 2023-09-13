namespace DungeonMaster.Equipment.Weapon
{
    internal class Weapon : Item
    {
        public WeaponType WeaponType { get; }
        public int WeaponDamage { get; }

        public Weapon(string name, WeaponType type, int weaponDamage) : base(name)
        {
            Slot = Slot.Weapon;
            WeaponDamage = weaponDamage;
            WeaponType = type;
        }
    }
}