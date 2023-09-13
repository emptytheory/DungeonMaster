using DungeonMaster.Stats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonMaster.Equipment.Item
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
