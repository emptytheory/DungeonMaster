namespace DungeonMaster.Equipment
{
    internal abstract class Item
    {
        public string Name { get; }
        public int ReqiredLevel { get; }
        public Slot Slot { get; protected set; }

        public Item(string name)
        {
            Name = name;
        }

    }
}
