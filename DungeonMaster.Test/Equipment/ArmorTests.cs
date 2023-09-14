using DungeonMaster.Stats;
using DungeonMaster.Equipment;

namespace DungeonMaster.Test.Equipment
{
    public class ArmorTests
    {
        [Fact]
        public void Constructor_SettingFieldsThroughConstructor_ValuesOfFieldsShouldMatchWhatIsPassedToTheConstructor()
        {
            string expectedName = "Mithril Mail";
            ArmorType expectedArmorType = ArmorType.Mail;
            HeroAttributes expectedArmorAttribute = new(1, 2, 3);
            int expectedRequiredLevel = 4;
            Slot expectedSlot = Slot.Body;
            var expected = (expectedName, expectedArmorType, expectedArmorAttribute, expectedSlot, expectedRequiredLevel);


            Armor armor = new(expectedName, expectedArmorType, expectedArmorAttribute, expectedSlot, expectedRequiredLevel);
            var actual = (armor.Name, armor.ArmorType, armor.ArmorAttribute, armor.Slot, armor.ReqiredLevel);

            Assert.Equal(expected, actual);


        }
    }
}
