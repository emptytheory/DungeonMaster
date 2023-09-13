using DungeonMaster.Equipment.Item;
using DungeonMaster.Stats;
using DungeonMaster.Exceptions;
using System.Text;


namespace DungeonMaster.Heroes
{
    internal abstract class Hero
    {
        protected string Name { get; }
        protected int Level { get; set; } = 1;
        protected abstract HeroAttributes AttributesGain { get; set; }
        protected abstract HeroAttributes LevelAttributes { get; set; }
        protected Dictionary<Slot, Item?> Equipment = new Dictionary<Slot, Item?>()
        {
            {Slot.Weapon, null},
            {Slot.Head, null},
            {Slot.Body, null},
            {Slot.Legs, null}
        };
        protected abstract List<WeaponType> ValidWeaponTypes { get; set; }
        protected abstract List<ArmorType> ValidArmorTypes { get; set; }

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
            if (ValidWeaponTypes.Contains(weapon.WeaponType))
                throw new InvalidWeaponException($"This hero cannot equip a/an {weapon.Name}.");

            if (weapon.ReqiredLevel > Level)
                throw new InvalidWeaponException($"A hero must be at least level {weapon.ReqiredLevel} to equip a/an {weapon.Name}.");

            Equipment[Slot.Weapon] = weapon;
        }

        // Equip - for equipping armor 
        public void Equip(Armor armor)
        {
            if (ValidArmorTypes.Contains(armor.ArmorType))
                throw new InvalidWeaponException($"This hero cannot wear a/an {armor.Name.ToLower()}.");

            if (armor.ReqiredLevel > Level)
                throw new InvalidWeaponException($"A hero must be at least level {armor.ReqiredLevel} to equip a/an {armor.Name.ToLower()}.");

            Equipment[armor.Slot] = armor;
        }

        // Damage – damage is calculated on the fly and not stored
        public abstract int Damage();

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

            return new()
            {
                Strength = strength,
                Dexterity = dexterity,
                Intelligence = intelligence
            };
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
