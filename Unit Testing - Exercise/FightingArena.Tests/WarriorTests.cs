namespace FightingArena.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class WarriorTests
    {
        private Warrior _jozo;
        [SetUp]
        public void SetUp()
        {
            this._jozo = new Warrior("Jozo", 50, 100);
        }
        //Ctor tests:
        [Test]
        public void ConstructorShouldSetValuesToProps()
        {
            //Arange
            string name = "jozo";
            int damage = 50;
            int hp = 100;
            //Act
            this._jozo = new Warrior(name, damage, hp);
            //Assert
            Assert.AreEqual(name, this._jozo.Name, "Name not set correctly.");
            Assert.AreEqual(damage, this._jozo.Damage, "Damage not set correctly.");
            Assert.AreEqual(hp, this._jozo.HP, "Hp not set correctly.");
        }
        //Prop validation tests:
        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void NameCannotBeNullOrEmpty(string name)
        {
            Exception nameException = Assert.Throws<ArgumentException>(
                () => this._jozo = new Warrior(name, 50, 100),
                "Exception is not thrown.");
            Assert.AreEqual("Name should not be empty or whitespace!", nameException.Message, "Massegaes are not the same.");
        }
        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(int.MinValue)]
        public void DamageCannotBeZeroOrLess(int damage)
        {
            Exception damageException = Assert.Throws<ArgumentException>(
                () => this._jozo = new Warrior("Jozo", damage, 100),
                "Exception is not thrown.");
            Assert.AreEqual("Damage value should be positive!", damageException.Message, "Massegaes are not the same.");
        }
        [Test]
        [TestCase(-1)]
        [TestCase(int.MinValue)]
        public void HpCannotBeZero(int hp)
        {
            Exception hpException = Assert.Throws<ArgumentException>(
                () => this._jozo = new Warrior("Jozo", 50, hp),
                "Exception is not thrown.");
            Assert.AreEqual("HP should not be negative!", hpException.Message, "Massegaes are not the same.");
        }
        //Attack method tests:
        [Test]
        public void CannotAttackIfHelthUnder30()
        {
            //Arange
            Warrior warriorWhoesHealthIsUnder30 = new Warrior("jozo1", 50, 30);
            //Assert
            Exception attacExceptoin = Assert.Throws<InvalidOperationException>(
                () => warriorWhoesHealthIsUnder30.Attack(this._jozo), "Exception is not thrown.");
            Assert.AreEqual("Your HP is too low in order to attack other warriors!", attacExceptoin.Message, "Massegaes are not the same.");
        }
        [Test]
        public void CannotAttackWorrirWhoesHealthIsUnder30()
        {
            //Arange
            Warrior warriorWhoesHealthIsUnder30 = new Warrior("jozo1", 50, 30);
            //Assert
            Exception attacExceptoin = Assert.Throws<InvalidOperationException>(
                () => this._jozo.Attack(warriorWhoesHealthIsUnder30), "Exception is not thrown.");
            Assert.AreEqual("Enemy HP must be greater than 30 in order to attack him!", attacExceptoin.Message, "Massegaes are not the same.");
        }
        [Test]
        public void CannotAttackWorrirWhoesDamageIsMoreThanWorrirHealth()
        {
            //Arange
            Warrior warriorWhoesDamageIsMoreThan100Health = new Warrior("jozo1", 101, 31);
            //Assert
            Exception attacExceptoin = Assert.Throws<InvalidOperationException>(
                () => this._jozo.Attack(warriorWhoesDamageIsMoreThan100Health), "Exception is not thrown.");
            Assert.AreEqual("You are trying to attack too strong enemy", attacExceptoin.Message, "Massegaes are not the same.");
        }
        [Test]
        public void AttackMethodShouldDeacriceWorrirHealth()
        {
            //Arange
            Warrior warrior = new Warrior("jozo1", 50, 100);
            //Act
            warrior.Attack(this._jozo);
            //Assert
            Assert.AreEqual(100 - 50, warrior.HP, "Warrior hp is not deacrised.");
        }
        [Test]
        public void AttackMethodShouldDeacriceAttackerHealth()
        {
            //Arange
            Warrior warrior = new Warrior("jozo1", 50, 100);
            //Act
            warrior.Attack(this._jozo);
            //Assert
            Assert.AreEqual(100 - 50, this._jozo.HP, "Warrior hp is not deacrised.");
        }
        [Test]
        public void AttackMethodShouldSetHealthToZeroIfWarrirIsKilled()
        {
            //Arange
            Warrior warrior = new Warrior("jozo1", 1000, 100);
            //Act
            warrior.Attack(this._jozo);
            //Assert
            Assert.AreEqual(0, this._jozo.HP, "Warrior hp is not set to zero.");
        }
    }
}