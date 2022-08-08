namespace Database.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class DatabaseTests
    {
        private Database db;
        [SetUp]
        public void SetUp()
        {
            db = new Database();
        }
        //Ctor tests
        [TestCase(new int[] { })]
        [TestCase(new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void ConstructorShouldShouldWorkWithLessThan16Elements(int[] data)
        {
            //Arange
            Database database = new Database(data);

            //Act
            int[] databaseData = database.Fetch();

            //Assert
            Assert.AreEqual(data.Length, database.Count, "Count not set");
            CollectionAssert.AreEqual(data, databaseData, "Date not set");
        }
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19 })]
        public void ConstructorShouldShouldNotWorkWith17Elements(int[] data)
        {
            Assert.Throws<InvalidOperationException>(delegate
            {
                new Database(data);
            }, "Array's capacity must be exactly 16 integers!");
        }
        //Count getter
        [Test]
        public void CountReturnsZeroWheneDatabaseEmpty()
        {
            Database database = new Database();
            Assert.AreEqual(0, database.Count, "Count dose not returns zero.");
        }
        [Test]
        public void CountMethdShouldReturnActulCount()
        {
            int[] data = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
            Database database = new Database(data);

            int databaseCount = database.Count;
            int expectedCount = data.Length;

            Assert.AreEqual(expectedCount, databaseCount, "Count getter does not retun actul count.");
        }
        //Add Method test
        [Test]
        public void AddMethodSholdAddItemsAtTheLastPossistion()
        {
            //Arange
            Database database = new Database(new int[] { 0, 0, 0, 0, });
            const int appendNumber = 1;
            //Act
            database.Add(appendNumber);
            //Assert
            Assert.AreEqual(appendNumber, database.Fetch()[database.Count - 1], "Add does not add the element at end of the sequence.");
        }
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18 })]
        public void AddMethodSholdNotAddMoreThanMaxEllements(int[] numsToAdd)
        {
            //Arange
            Database database = new Database(new int[] { });
            //Assert
            Assert.Throws<InvalidOperationException>(delegate
            {
                //Act
                for (int i = 0; i < numsToAdd.Length; i++)
                {
                    database.Add(numsToAdd[i]);
                }
            }, "Array's capacity must be exactly 16 integers!");
        }
        [Test]
        public void AddMethodSholdIncraseTheCount()
        {
            //Arange
            Database database = new Database(new int[] { 0, 0, 0, 0, });
            int appendNumber = 1;
            int excpectedCount = database.Count + 1;
            //Act
            database.Add(appendNumber);
            //Assert
            Assert.AreEqual(excpectedCount, database.Count, "Add does not add the element at end of the sequence.");
        }
        //[Test]
        //public void AddMethodSholdNotIncraseTheCountWheneElementsAreMoreThanTheMaxCount()
        //{
        //    //Arange
        //    Database database = new Database(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 });
        //    int appendNumber = 1;
        //    int excpectedCount = database.Count;
        //    //Act
        //    database.Add(appendNumber);
        //    //Assert
        //    Assert.Throws<InvalidOperationException>(delegate
        //    {
        //        database.Add(appendNumber);
        //        Assert.AreEqual(excpectedCount, database.Count, "Add method incrases count even though there are max numbers.");

        //    }, "Array's capacity must be exactly 16 integers!");
        //}
        [TestCase(new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void AddMethodSholdIncraseTheCount(int[] numsToAdd)
        {
            //Arange
            Database database = new Database(new int[] { });
            //Act
            int excpectedCount = numsToAdd.Length;
            for (int i = 0; i < numsToAdd.Length; i++)
            {
                database.Add(numsToAdd[i]);
            }
            //Assert
            Assert.AreEqual(excpectedCount, database.Count, "Add does not add the element at end of the sequence.");
        }
        [TestCase(new int[] { })]
        [TestCase(new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void FetchShuldReturnData(int[] data)
        {
            //Arange
            Database database = new Database(data);
            //Assert
            CollectionAssert.AreEqual(data, database.Fetch(), "Featch does not return the data");
        }
        [Test]
        public void RemoveShuldRemoveTheLastElement()
        {
            //Arange
            int[] data = new int[] { 1, 2, 3 };
            Database database = new Database(data);
            database.Add(0);
            //Act
            database.Remove();
            //Assert
            CollectionAssert.AreEqual(data, database.Fetch(), "Remove dose not remove the last element");
            Assert.AreEqual(data.Length, database.Count, "Remove does not lower the count");
        }
        [Test]
        public void RemoveShouldNotWorkWithEmptyData()
        {
            //Arange
            int[] data = new int[] { };
            Database database = new Database(data);
            Assert.Throws<InvalidOperationException>(delegate
            {
                database.Remove();
            }, "The collection is empty!");
        }
    }
}
