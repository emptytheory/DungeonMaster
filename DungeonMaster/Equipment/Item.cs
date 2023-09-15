namespace DungeonMaster.Equipment
{
    public abstract class Item
    {
        public string Name { get; }
        public int ReqiredLevel { get; }
        public Slot Slot { get; protected set; }

        public Item(string name, int requiredLevel)
        {
            Name = name;
            ReqiredLevel = requiredLevel;
        }

    }
}
