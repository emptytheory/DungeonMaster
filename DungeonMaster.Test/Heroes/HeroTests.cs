using DungeonMaster.Equipment;
using DungeonMaster.Exceptions;
using DungeonMaster.Heroes;
using DungeonMaster.Stats;
using DungeonMaster.Test.Mocks;

namespace DungeonMaster.Test.Heroes
{
    public class HeroTests
    {
        [Fact]
        public void Constructor_SetNameInConstructor_NameShouldBeAsGivenInConstructor()
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
        public void Level_GetLevelOfNewlyCreatedHero_ShouldReturnOne()
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

        [Fact]
        public void EquipArmor_InvalidArmorType_ShouldThrowInvalidArmorException()
        {
            Hero hero = new HeroMock("name");
            Armor armor = new(name: "armorName", type: ArmorType.Mail, armorAttribute: new(), slot: Slot.Legs, requiredLevel: 1);
            string expected = $"This hero cannot wear a/an {armor.Name}.";

            var exception = Assert.Throws<InvalidArmorException>(() => hero.Equip(armor));
            string actual = exception.Message;

            Assert.Equal(expected, actual);

        }

        [Fact]
        public void EquipArmor_ArmorTooHighLevel_ShouldThrowInvalidArmorException()
        {
            Hero hero = new HeroMock("name");
            Armor armor = new(name: "armorName", type: ArmorType.Leather, armorAttribute: new(), slot: Slot.Legs, requiredLevel: 2);
            string expected = $"A hero must be at least level {armor.ReqiredLevel} to equip a/an {armor.Name}.";

            var exception = Assert.Throws<InvalidArmorException>(() => hero.Equip(armor));
            string actual = exception.Message;

            Assert.Equal(expected, actual);

        }

        [Fact]
        public void TotalAttrubutes_NoEquipment_ShouldReturnUnmodifiedStats()
        {
            Hero hero = new HeroMock("name");
            HeroAttributes expected = hero.LevelAttributes;

            HeroAttributes actual = hero.TotalAttributes();

            Assert.Equal(expected, actual);

        }

        [Fact]
        public void TotalAttrubutes_OnePieceOfArmor_ShouldReturnModifiedStats()
        {
            Hero hero = new HeroMock("name");
            HeroAttributes armorStats = new(1, 2, 3);
            Armor armor = new("Shirt", ArmorType.Cloth, armorAttribute: armorStats, Slot.Body, requiredLevel: 1);
            HeroAttributes expected = hero.LevelAttributes.Add(armorStats);

            hero.Equip(armor);
            HeroAttributes actual = hero.TotalAttributes();

            Assert.Equal(expected, actual);

        }

        [Fact]
        public void TotalAttrubutes_TwoPiecesOfArmor_ShouldReturnModifiedStats()
        {
            Hero hero = new HeroMock("name");
            HeroAttributes armorStats1 = new(1, 2, 3);
            HeroAttributes armorStats2 = new(4, 5, 6);
            Armor armor1 = new("Shirt", ArmorType.Cloth, armorAttribute: armorStats1, Slot.Body, requiredLevel: 1);
            Armor armor2 = new("Hat", ArmorType.Leather, armorAttribute: armorStats2, Slot.Head, requiredLevel: 1);
            HeroAttributes expected = hero.LevelAttributes.Add(armorStats1.Add(armorStats2));

            hero.Equip(armor1);
            hero.Equip(armor2);
            HeroAttributes actual = hero.TotalAttributes();

            Assert.Equal(expected, actual);

        }

        [Fact]
        public void TotalAttrubutes_ReplacedPieceOfArmor_ShouldRetrnStatsModifiedByLastEquippedArmorOnly()
        {
            Hero hero = new HeroMock("name");
            HeroAttributes armorStats1 = new(1, 2, 3);
            HeroAttributes armorStats2 = new(4, 5, 6);
            Armor armor1 = new("Shirt", ArmorType.Cloth, armorAttribute: armorStats1, Slot.Body, requiredLevel: 1);
            Armor armor2 = new("Different Shirt", ArmorType.Leather, armorAttribute: armorStats2, Slot.Body, requiredLevel: 1);
            HeroAttributes expected = hero.LevelAttributes.Add(armorStats2);

            hero.Equip(armor1);
            hero.Equip(armor2);
            HeroAttributes actual = hero.TotalAttributes();

            Assert.Equal(expected, actual);

        }

        [Fact]
        public void Damage_NoWeapon_ShouldReturnOnePlusDamageAttributeValueOverHundred()
        {
            Hero hero = new HeroMock("name");
            int DamageAttributeValue = hero.TotalAttributes().Strength;
            double expected = 1 + (DamageAttributeValue / 100.0);

            double actual = hero.Damage();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Damage_WeaponEquipped_DamageShouldBeModifiedByWeaponDamage()
        {
            Hero hero = new HeroMock("Jareth");
            int weaponDamage = 2;
            Weapon weapon = new("David", WeaponType.Bow, weaponDamage, requiredLevel: 1);
            int DamageAttributeValue = hero.TotalAttributes().Strength;
            double expected = weaponDamage * (1 + DamageAttributeValue / 100.0);

            hero.Equip(weapon);
            double actual = hero.Damage();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Damage_ReplacedWeapon_DamageShouldBeModifiedByLastWeaponEquipped()
        {
            Hero hero = new HeroMock("Jareth");
            int weaponDamage1 = 1;
            int weaponDamage2 = 2;
            Weapon weapon1 = new("David", WeaponType.Bow, weaponDamage1, requiredLevel: 1);
            Weapon weapon2 = new("David", WeaponType.Bow, weaponDamage2, requiredLevel: 1);
            int DamageAttributeValue = hero.TotalAttributes().Strength;
            double expected = weaponDamage2 * (1 + DamageAttributeValue / 100.0);

            hero.Equip(weapon1);
            hero.Equip(weapon2);
            double actual = hero.Damage();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Damage_WeaponAndArmorEquipped_DamageShouldBeModifiedByWeaponDamageAndArmorAttribute()
        {
            Hero hero = new HeroMock("Jareth");
            int weaponDamage = 1;
            Weapon weapon = new("David", WeaponType.Bow, weaponDamage, requiredLevel: 1);
            HeroAttributes armorStats = new(strength: 1, dexterity: 0, intelligence: 0);
            Armor armor = new("Hat", ArmorType.Leather, armorAttribute: armorStats, Slot.Head, requiredLevel: 1);
            int DamageAttributeValue = hero.TotalAttributes().Add(armorStats).Strength;
            double expected = weaponDamage * (1 + DamageAttributeValue / 100.0);

            hero.Equip(weapon);
            hero.Equip(armor);
            double actual = hero.Damage();

            Assert.Equal(expected, actual);
        }
    }
}