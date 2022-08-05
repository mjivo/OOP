using System;
using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        private int _validHealth = 100;
        private int _invalidHealth = -1;
        private int _validExperience = 100;

        private Dummy testDeadDummy;
        private Dummy testAliveDummy;

        [SetUp]
        public void TestInitialize()
        {
            testDeadDummy = new Dummy(this._invalidHealth, this._validExperience);
            testAliveDummy = new Dummy(this._validHealth, this._validExperience);
        }
        [Test]
        public void LosesHealthIfHitted()
        {
            int attackPoints = 10;
            Dummy testDummy = new Dummy(this._validHealth, this._validExperience);
            testDummy.TakeAttack(attackPoints);
            Assert.That(testDummy.Health, Is.EqualTo(this._validHealth - attackPoints), "Dummy is not losing health");
        }
        [Test]
        public void DeadDummyCannotBeAttacted_Exception()
        {
            Assert.That(() => testDeadDummy.TakeAttack(1), Throws.InvalidOperationException, "Dead dummy can't be attacked");
        }
        [Test]
        public void DeadDummyCanGetXp()
        {
            Assert.That(new Dummy(this._invalidHealth, this._validExperience).GiveExperience(), Is.EqualTo(this._validExperience), "Death dummy dosen't give his xp");
        }
        [Test]
        public void AliveDummyCannotGetXp_Exception()
        {
            Assert.That(() => testAliveDummy.GiveExperience(), Throws.InvalidOperationException, "Alive dummy gives xp");
        }
    }
}