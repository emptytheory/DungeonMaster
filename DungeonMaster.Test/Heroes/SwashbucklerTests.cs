using DungeonMaster.Heroes;
using DungeonMaster.Stats;

namespace DungeonMaster.Test.Heroes
{
    public class SwashbucklerTests
    {
        [Fact]
        public void LevelAttributes_GetLevelAttributes_ShouldReturnSwashbucklerStats()
        {
            Swashbuckler swashbuckler = new("Aria");
            HeroAttributes expected = new(strength: 2, dexterity: 6, intelligence: 1);

            HeroAttributes actual = swashbuckler.LevelAttributes;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void LevelUp_ShouldIncreaseLevelByOne()
        {
            Swashbuckler swashbuckler = new("Aria");
            int beforeLevelUp = swashbuckler.Level;
            int expected = beforeLevelUp + 1;

            swashbuckler.LevelUp();
            int actual = swashbuckler.Level;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void LevelUp_ShouldIncreaseLevelAttributesBySpecificAmounts()
        {
            Swashbuckler swashbuckler = new("Aria");
            HeroAttributes swashbucklerAttributeGain = new(strength: 1, dexterity: 4, intelligence: 1);
            HeroAttributes beforeLevelUp = swashbuckler.LevelAttributes;
            HeroAttributes expected = beforeLevelUp.Add(swashbucklerAttributeGain);

            swashbuckler.LevelUp();
            HeroAttributes actual = swashbuckler.LevelAttributes;

            Assert.Equal(expected, actual);
        }

    }
}
