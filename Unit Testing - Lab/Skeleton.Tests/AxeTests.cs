using System;
using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        [Test]
        public void TakingDurability()
        {
            Axe axe = new Axe(5, 100);
            axe.Attack(new Dummy(50, 100));
            Assert.AreEqual(99, axe.DurabilityPoints);
        }
        [Test]
        public void AttackingWithBrokenWeapon()
        {
            Axe axe = new Axe(5, 1);
            Dummy validDummy = new Dummy(10, 100);
            axe.Attack(validDummy);
            Assert.Throws<InvalidOperationException>(delegate
            {
                axe.Attack(validDummy);
            }, "Axe is broken.");
        }
    }
}