using DungeonMaster.Heroes;
using DungeonMaster.Stats;

namespace DungeonMaster.Test.Heroes
{
    public class BarbarianTests
    {
        [Fact]
        public void LevelAttributes_GetLevelAttributes_ShouldReturnBarbarianStats()
        {
            Barbarian barbarian = new("Barbara");
            HeroAttributes expected = new(strength: 5, dexterity: 2, intelligence: 1);

            HeroAttributes actual = barbarian.LevelAttributes;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void LevelUp_ShouldIncreaseLevelByOne()
        {
            Barbarian barbarian = new("Barbara");
            int beforeLevelUp = barbarian.Level;
            int expected = beforeLevelUp + 1;

            barbarian.LevelUp();
            int actual = barbarian.Level;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void LevelUp_ShouldIncreaseLevelAttributesBySpecificAmounts()
        {
            Barbarian barbarian = new("Barbara");
            HeroAttributes barbarianAttributeGain = new(strength: 3, dexterity: 2, intelligence: 1);
            HeroAttributes beforeLevelUp = barbarian.LevelAttributes;
            HeroAttributes expected = beforeLevelUp.Add(barbarianAttributeGain);

            barbarian.LevelUp();
            HeroAttributes actual = barbarian.LevelAttributes;

            Assert.Equal(expected, actual);
        }

    }
}
