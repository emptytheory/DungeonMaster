namespace DungeonMaster.Equipment
{
    public class Weapon : Item
    {
        public WeaponType WeaponType { get; }
        public int WeaponDamage { get; }

        public Weapon(string name, WeaponType type, int weaponDamage, int requiredLevel) : base(name, requiredLevel)
        {
            Slot = Slot.Weapon;
            WeaponDamage = weaponDamage;
            WeaponType = type;
        }
    }
}