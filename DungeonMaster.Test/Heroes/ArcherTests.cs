using DungeonMaster.Heroes;
using DungeonMaster.Stats;

namespace DungeonMaster.Test.Heroes
{
    public class ArcherTests
    {
        [Fact]
        public void LevelAttributes_GetLevelAttributes_ShouldReturnArcherStats()
        {
            Archer archer = new("Legolas");
            HeroAttributes expected = new(strength: 1, dexterity: 7, intelligence: 1);

            HeroAttributes actual = archer.LevelAttributes;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void LevelUp_ShouldIncreaseLevelByOne()
        {
            Archer archer = new("Legolas");
            int beforeLevelUp = archer.Level;
            int expected = beforeLevelUp + 1;

            archer.LevelUp();
            int actual = archer.Level;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void LevelUp_ShouldIncreaseLevelAttributesBySpecificAmounts()
        {
            Archer archer = new("Legolas");
            HeroAttributes archerAttributeGain = new(strength: 1, dexterity: 5, intelligence: 1);
            HeroAttributes beforeLevelUp = archer.LevelAttributes;
            HeroAttributes expected = beforeLevelUp.Add(archerAttributeGain);

            archer.LevelUp();
            HeroAttributes actual = archer.LevelAttributes;

            Assert.Equal(expected, actual);
        }

    }
}
