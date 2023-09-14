using DungeonMaster.Equipment;

namespace DungeonMaster.Test.Equipment
{
    public class WeaponTests
    {
        [Fact]
        public void Constructor_SettingFieldsThroughConstructor_ValuesOfFieldsShouldMatchWhatIsPassedToTheConstructor()
        {
            string expectedName = "Sting";
            WeaponType expectedWeaponType = WeaponType.Dagger;
            int expectedWeaponDamage = 1;
            int expectedRequiredLevel = 2;
            var expected = (expectedName, expectedWeaponType, expectedWeaponDamage, expectedRequiredLevel);

            Weapon weapon = new(expectedName, expectedWeaponType, expectedWeaponDamage, expectedRequiredLevel);
            string actualName = weapon.Name;
            WeaponType actualWeaponType = weapon.WeaponType;
            int actualWeaponDamage = weapon.WeaponDamage;
            int actualRequiredLevel = weapon.ReqiredLevel;
            var actual = (actualName, actualWeaponType, actualWeaponDamage, actualRequiredLevel);

            Assert.Equal(expected, actual);

        }
    }
}
