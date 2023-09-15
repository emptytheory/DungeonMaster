using DungeonMaster.Stats;

namespace DungeonMaster.Equipment
{
    public class Armor : Item
    {
        public ArmorType ArmorType { get; }
        public HeroAttributes ArmorAttribute { get; }

        public Armor(string name, ArmorType type, HeroAttributes armorAttribute, Slot slot, int requiredLevel) : base(name, requiredLevel)
        {
            ArmorType = type;
            ArmorAttribute = armorAttribute;
            Slot = slot;
        }
    }
}
