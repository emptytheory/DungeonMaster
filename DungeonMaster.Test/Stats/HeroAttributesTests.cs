using DungeonMaster.Stats;

namespace DungeonMaster.Test.Stats
{
    public class HeroAttributesTests
    {
        [Fact]
        public void Constructor_EmptyConstructor_ValuesShouldBeZero()
        {
            HeroAttributes attributes = new();
            var expected = (strength: 0, dexterity: 0, intelligence: 0);

            var actual = (strength: attributes.Strength, dexterity: attributes.Dexterity, intelligence: attributes.Intelligence);

            Assert.Equal(expected, actual);

        }

        [Fact]
        public void Constructor_SettingAttributesInConstructor_ValuesShouldBeAsPassed()
        {
            HeroAttributes attributes = new(strength: 1, dexterity: 2, intelligence: 3);
            var expected = (strength: 1, dexterity: 2, intelligence: 3);

            var actual = (strength: attributes.Strength, dexterity: attributes.Dexterity, intelligence: attributes.Intelligence);

            Assert.Equal(expected, actual);

        }
    }
}
