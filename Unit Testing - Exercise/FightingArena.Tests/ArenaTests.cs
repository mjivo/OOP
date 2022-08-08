namespace FightingArena.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using NUnit.Framework;

    [TestFixture]
    public class ArenaTests
    {
        private Warrior _jozo;
        [SetUp]
        public void SetUp()
        {
            this._jozo = new Warrior("jozo", 50, 100);
        }
        //Test Constructors
        [Test]
        public void ConstructorShouldReturnAnInitializedEmptyWarriorCollection()
        {
            //Arange
            Arena arena = new Arena();
            //Assert
            CollectionAssert.AreEqual(new List<Warrior>(), arena.Warriors);
        }
        //Count tests:
        [Test]
        public void CountShuldReturnCountOfWorrirs()
        {
            //Arange
            Arena arena = new Arena();
            //Act
            arena.Enroll(this._jozo);
            //Assert
            Assert.AreEqual(1, arena.Count, "Count is not working.");
        }
        //Warrirs prop tests:
        [Test]
        public void WarriorsShouldReturnListOfEnrolledWarriors()
        {
            //Arange
            Arena arena = new Arena();
            //Act
            List<Warrior> testWarriors = arena.Warriors.ToList();
            //Assert
            CollectionAssert.AreEqual(testWarriors, arena.Warriors);
        }
        //Enroll tests:
        [Test]
        public void EnrolShouldNotAddWorrirsWithTheSameName()
        {
            //Arange
            Arena arena = new Arena();
            //Act
            arena.Enroll(this._jozo);
            //Assert
            Exception enrollException = Assert.Throws<InvalidOperationException>(
                () => arena.Enroll(this._jozo),
                "Exception is not thrown.");
            Assert.AreEqual("Warrior is already enrolled for the fights!",
                enrollException.Message,
                "Exception msg is not the same.");
        }
        [Test]
        public void EnrollSholdAddWorrirsToList()
        {
            //Arange
            Arena arena = new Arena();
            List<Warrior> worrirs = new List<Warrior>();
            //Act
            for (int i = 1; i <= 10; i++)
            {
                Warrior warrior = new Warrior($"{i}", i, i);
                arena.Enroll(warrior);
                worrirs.Add(warrior);
            }
            CollectionAssert.AreEqual(worrirs, arena.Warriors, "Enrol does not add new worrirs.");
        }
        //Fitght method tests:
        [Test]
        public void FightMethodShouldThrowAnExceptionIfAttackerIsNotFound()
        {
            //Arange
            Arena arena = new Arena();
            arena.Enroll(this._jozo);
            //Assert
            Exception fitghException = Assert.Throws<InvalidOperationException>(
                () => arena.Fight("jozo", "jozo1"),
                "Exception is not thrown.");
            Assert.AreEqual("There is no fighter with name jozo1 enrolled for the fights!",
                fitghException.Message,
                "Exception msg is not the same.");
        }
        [Test]
        public void FightMethodShouldThrowAnExceptionIfDeffenderIsNotFound()
        {
            //Arange
            Arena arena = new Arena();
            arena.Enroll(this._jozo);
            //Assert
            Exception fitghException = Assert.Throws<InvalidOperationException>(
                () => arena.Fight("jozo1", "jozo"),
                "Exception is not thrown.");
            Assert.AreEqual("There is no fighter with name jozo1 enrolled for the fights!",
                fitghException.Message,
                "Exception msg is not the same.");
        }
        [Test]
        public void FightMethodShouldAttackWorrirs()
        {
            //Arange
            Arena arena = new Arena();
            arena.Enroll(this._jozo);
            arena.Enroll(new Warrior("jozo1", 50, 100));
            //Act
            arena.Fight("jozo", "jozo1");
            List<Warrior> warriors = (List<Warrior>)arena.Warriors;
            //Assert
            Assert.AreEqual(warriors[0].HP, warriors[1].HP,"Fight method does not attack warrirs.");
        }
        [Test]
        public void FightShouldWorkCorrectly()
        {
            Arena arena = new Arena();
            arena.Enroll(new Warrior("jozo", 10, 100));
            arena.Enroll(new Warrior("jozo1", 5, 50));
            arena.Fight("jozo", "jozo1");
            Warrior jozoWarrior = arena.Warriors.First(w => w.Name == "jozo");
            Warrior jozo1Warrior = arena.Warriors.First(w => w.Name == "jozo1");
            Assert.AreEqual(95, jozoWarrior.HP);
            Assert.AreEqual(40, jozo1Warrior.HP);
        }
    }
}
