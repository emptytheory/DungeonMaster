using DungeonMaster.Stats;
using DungeonMaster.Exceptions;
using System.Text;
using DungeonMaster.Equipment;

namespace DungeonMaster.Heroes
{
    public abstract class Hero
    {
        public string Name { get; }
        public int Level { get; protected set; } = 1;
        public abstract HeroAttributes LevelAttributes { get; protected set; }
        protected abstract HeroAttributes AttributesGain { get; }
        protected abstract int DamageAttributeValue { get; }
        protected abstract List<WeaponType> ValidWeaponTypes { get; }
        protected abstract List<ArmorType> ValidArmorTypes { get; }
        protected Dictionary<Slot, Item?> Equipment = new()
        {
            {Slot.Weapon, null},
            {Slot.Head, null},
            {Slot.Body, null},
            {Slot.Legs, null}
        };

        // Constructor – each hero is created by passing just a name.

        public Hero(string name)
        {
            Name = name;
        }

        // LevelUp – increases the level of a character by 1 and increases their LevelAttributes

        public void LevelUp()
        {
            Level++;
            LevelAttributes = LevelAttributes.Add(AttributesGain); 
        }

        // Equip - for equipping weapons
        public void Equip(Weapon weapon)
        {
            if (!ValidWeaponTypes.Contains(weapon.WeaponType))
                throw new InvalidWeaponException($"This hero cannot equip a/an {weapon.Name}.");

            if (weapon.ReqiredLevel > Level)
                throw new InvalidWeaponException($"A hero must be at least level {weapon.ReqiredLevel} to equip a/an {weapon.Name}.");

            Equipment[Slot.Weapon] = weapon;
        }

        // Equip - for equipping armor 
        public void Equip(Armor armor)
        {
            if (!ValidArmorTypes.Contains(armor.ArmorType))
                throw new InvalidArmorException($"This hero cannot wear a/an {armor.Name}.");

            if (armor.ReqiredLevel > Level)
                throw new InvalidArmorException($"A hero must be at least level {armor.ReqiredLevel} to equip a/an {armor.Name}.");

            Equipment[armor.Slot] = armor;
        }

        // Damage – damage is calculated on the fly and not stored
        public double Damage()
        {
            int baseDamage = Equipment[Slot.Weapon] is Weapon weapon ? weapon.WeaponDamage : 1;
            return baseDamage * (1 + DamageAttributeValue / 100d);
        }

        // TotalAttributes – calculated on the fly and not stored
        // Total = LevelAttributes + (Sum of ArmorAttribute for all Armor in Equipment) 
        public HeroAttributes TotalAttributes()
        {
            int strength = LevelAttributes.Strength;
            int dexterity = LevelAttributes.Dexterity;
            int intelligence = LevelAttributes.Intelligence;

            foreach (Armor armor in Equipment.Values.OfType<Armor>()) 
            {
                strength += armor.ArmorAttribute.Strength;
                dexterity += armor.ArmorAttribute.Dexterity;
                intelligence += armor.ArmorAttribute.Intelligence;
            }

            return new(strength, dexterity, intelligence);
        }

        //Display – details of Hero to be displayed
        public void Display()
        {
            HeroAttributes totalAttributes = TotalAttributes();
            string level = Level.ToString();
            string strength = totalAttributes.Strength.ToString();
            string dexterity = totalAttributes.Dexterity.ToString();
            string intelligence = totalAttributes.Intelligence.ToString();

            StringBuilder sb = new StringBuilder()
                .Append("Name: ").AppendLine(Name)
                .Append("Class: ").AppendLine(GetType().Name)
                .Append("Level: ").AppendLine(level)
                .Append("Total strength: ").AppendLine(strength)
                .Append("Total dexterity: ").AppendLine(dexterity)
                .Append("Total intelligence: ").AppendLine(intelligence)
                .Append("Damage: "); sb.Append(Damage());

            Console.WriteLine(sb.ToString());
        }
    }
}
