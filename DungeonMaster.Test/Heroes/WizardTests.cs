using DungeonMaster.Heroes;
using DungeonMaster.Stats;
using Xunit.Sdk;

namespace DungeonMaster.Test.Heroes
{
    public class WizardTests
    {
        [Fact]
        public void LevelAttributes_GetLevelAttributes_ShouldReturnWizardStats()
        {
            //Arrange
            Wizard wizard = new("Gandalf");
            HeroAttributes expected = new(strength: 1, dexterity: 1, intelligence: 8);

            //Act
            HeroAttributes actual = wizard.LevelAttributes;

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void LevelUp_ShouldIncreaseLevelByOne()
        {
            Wizard wizard = new("Gandalf");
            int beforeLevelUp = wizard.Level;
            int expected = beforeLevelUp + 1;

            wizard.LevelUp();
            int actual = wizard.Level;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void LevelUp_ShouldIncreaseLevelAttributesBySpecificAmounts()
        {
            Wizard wizard = new("Gandalf");
            HeroAttributes wizardAttributeGain = new(strength: 1, dexterity: 1, intelligence: 5);
            HeroAttributes beforeLevelUp = wizard.LevelAttributes;
            HeroAttributes expected = beforeLevelUp.Add(wizardAttributeGain);

            wizard.LevelUp();
            HeroAttributes actual = wizard.LevelAttributes;

            Assert.Equal(expected, actual);
        }


    }
}
