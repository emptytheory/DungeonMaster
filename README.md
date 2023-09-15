# DungeonMaster
DungeonMaster is a .NET 7 console application written in C# that simulates a simple RPG character system. It's inspired by classic RPG games and allows developers to model and expand upon different character classes.

## Features
* Predefined character classes: Archer, Barbarian, Swashbuckler, and Wizard.
* Ability to define new character classes by inheriting from the Hero class.

## Defining New Character Classes
To define a new character class, create a class that inherits from Hero and provide the following:

* Initial level attributes: stats at level 1
* Attribute gain: stat increases on level-up
* Damage attribute: the stat used for damage calculation
* Valid weapon types: types of weapons equippable by the class
* Valid armor types: types of armor equippable by the class

## Example: The Wizard Class
```
public class Wizard : Hero
{
    public override HeroAttributes LevelAttributes { get; protected set; } = new(strength: 1, dexterity: 1, intelligence: 8);
    protected override HeroAttributes AttributesGain { get; } = new(strength: 1, dexterity: 1, intelligence: 5);
    protected override int DamageAttributeValue => TotalAttributes().Intelligence;
    protected override List<WeaponType> ValidWeaponTypes { get; } = new() { WeaponType.Staff, WeaponType.Wand };
    protected override List<ArmorType> ValidArmorTypes { get; } = new() { ArmorType.Cloth };

    public Wizard(string name) : base(name) { }

}
```
The five fields are defining the wizard class as

* having these initial stats: __strength: 1, dexterity: 1, intelligence: 8__,
* increasing those stats per level by this much: __strength: 1, dexterity: 1, intelligence: 5__,
* having __intelligence__ as its damage attribute (notice this is implemeted by having DamageAttributeValue return TotalAttributes().Intelligence),
* being able to eqip __staffs__ and __wands__ only, and
* being able to wear __cloth__ only.

## Hero Methods
Each hero offers the following public methods:

* __void LevelUp()__: Increase the hero's level.
* __void Equip(Weapon weapon)__ and __void Equip(Armor armor)__: Equip weapons or armor.
* __double Damage()__: Calculate the hero's damage output.
* __HeroAttributes TotalAttributes()__: Retrieve the hero's current attributes.
* __void Display()__: Print detailed hero information.

## Running the Application
Prerequisites:

* .NET 7 SDK
* Visual Studio (latest version recommended)
* xUnit for C#

Instructions:

* Clone this repository.
* Open the solution in Visual Studio.
* Install xUnit for C# via NuGet if not already installed.
* Run the tests through the Test Explorer in Visual Studio.
