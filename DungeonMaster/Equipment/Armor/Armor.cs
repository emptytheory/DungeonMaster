using DungeonMaster.Stats;

namespace DungeonMaster.Equipment.Armor
{
    internal class Armor : Item
    {
        public ArmorType ArmorType { get; }
        public HeroAttributes ArmorAttribute { get; }

        public Armor(string name, ArmorType type, HeroAttributes armorAttibutes, Slot slot) : base(name)
        {
            ArmorType = type;
            ArmorAttribute = armorAttibutes;
            Slot = slot;
        }
    }
}
