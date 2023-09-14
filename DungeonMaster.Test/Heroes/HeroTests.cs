using DungeonMaster.Equipment;
using DungeonMaster.Exceptions;
using DungeonMaster.Heroes;
using DungeonMaster.Test.Mocks;

namespace DungeonMaster.Test.Heroes
{
    public class HeroTests
    {
        [Fact]
        public void Name_GetNameOfHero_ShouldReturnNameGivenInConstructor()
        {
            //Arrange
            string expected = "name";
            Hero hero = new HeroMock(expected);

            //Act
            string actual = hero.Name;

            //Assert
            Assert.Equal(expected, actual);

        }

        [Fact]
        public void Level_GetLevelOfHero_ShouldReturnOne()
        {
            //Arrange
            int expected = 1;
            Hero hero = new HeroMock("name");

            //Act
            int actual = hero.Level;

            //Assert
            Assert.Equal(expected, actual);

        }

        [Fact]
        public void EquipWeapon_InvalidWeaponType_ShouldThrowInvalidWeaponException()
        {
            Hero hero = new HeroMock("name");
            Weapon weapon = new(name: "weaponName", type: WeaponType.Sword, weaponDamage: 0, requiredLevel: 1);
            string expected = $"This hero cannot equip a/an {weapon.Name}.";

            var exception = Assert.Throws<InvalidWeaponException>(() => hero.Equip(weapon));
            string actual = exception.Message;

            Assert.Equal(expected, actual);

        }

        [Fact]
        public void EquipWeapon_WeaponTooHighLevel_ShouldThrowInvalidWeaponException()
        {
            Hero hero = new HeroMock("name");
            Weapon weapon = new(name: "weaponName", type: WeaponType.Bow, weaponDamage: 0, requiredLevel: 2);
            string expected = $"A hero must be at least level {weapon.ReqiredLevel} to equip a/an {weapon.Name}.";

            var exception = Assert.Throws<InvalidWeaponException>(() => hero.Equip(weapon));
            string actual = exception.Message;

            Assert.Equal(expected, actual);

        }

        //

        [Fact]
        public void EquipArmor_InvalidArmorType_ShouldThrowInvalidArmorException()
        {
            Hero hero = new HeroMock("name");
            Armor armor = new(name: "armorName", type: ArmorType.Mail, armorAttibutes: new(), slot: Slot.Legs, requiredLevel: 1);
            string expected = $"This hero cannot wear a/an {armor.Name}.";

            var exception = Assert.Throws<InvalidArmorException>(() => hero.Equip(armor));
            string actual = exception.Message;

            Assert.Equal(expected, actual);

        }

        [Fact]
        public void EquipArmor_ArmorTooHighLevel_ShouldThrowInvalidArmorException()
        {
            Hero hero = new HeroMock("name");
            Armor armor = new(name: "armorName", type: ArmorType.Leather, armorAttibutes: new(), slot: Slot.Legs, requiredLevel: 2);
            string expected = $"A hero must be at least level {armor.ReqiredLevel} to equip a/an {armor.Name}.";

            var exception = Assert.Throws<InvalidArmorException>(() => hero.Equip(armor));
            string actual = exception.Message;

            Assert.Equal(expected, actual);

        }

    }
}