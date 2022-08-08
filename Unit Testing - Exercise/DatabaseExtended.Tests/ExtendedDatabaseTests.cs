namespace DatabaseExtended.Tests
{
    using System;
    using ExtendedDatabase;
    using NUnit.Framework;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Person _personJozo;
        private Person[] _people;
        private Person[] _people17;
        private Database peopleDatabase;
        [SetUp]
        public void SetUp()
        {
            _people = new Person[16]
            {
                new Person(0,"jozo"),
                new Person(1,"jozo1"),
                new Person(2,"jozo2"),
                new Person(3,"jozo3"),
                new Person(4,"jozo4"),
                new Person(5,"jozo5"),
                new Person(6,"jozo6"),
                new Person(7,"jozo7"),
                new Person(8,"jozo8"),
                new Person(9,"jozo9"),
                new Person(10,"jozo10"),
                new Person(11,"jozo11"),
                new Person(12,"jozo12"),
                new Person(13,"jozo13"),
                new Person(14,"jozo14"),
                new Person(15,"jozo15")
            };
            _people17 = new Person[17]
            {
                new Person(0,"jozo0"),
                new Person(1,"jozo1"),
                new Person(2,"jozo2"),
                new Person(3,"jozo3"),
                new Person(4,"jozo4"),
                new Person(5,"jozo5"),
                new Person(6,"jozo6"),
                new Person(7,"jozo7"),
                new Person(8,"jozo8"),
                new Person(9,"jozo9"),
                new Person(10,"jozo10"),
                new Person(11,"jozo11"),
                new Person(12,"jozo12"),
                new Person(13,"jozo13"),
                new Person(14,"jozo14"),
                new Person(15,"jozo15"),
                new Person(16,"jozo16")
            };
            peopleDatabase = new Database(this._people);
            this._personJozo = new Person(1, "jozo");
        }
        //Ctor tests
        [Test]
        public void ConstructorShuldWrokWithLessThan16Elements()
        {
            Database database = new Database(this._people);
            for (int i = 0; i < this._people.Length; i++)
            {
                database.Remove();
            }
        }
        [Test]
        public void ConstructorShuldNotWrokWith17Elements()
        {
            Assert.AreEqual("Provided data length should be in range [0..16]!",
            Assert.Throws<ArgumentException>(delegate
            {
                Database database = new Database(this._people17);
            }, "Exception is not thrown").Message,
            "Exception Message is not the same.");
        }
        //Add methods test shoud incrase the count
        [Test]
        public void AddMethodShouldNotAddElementsWheneIsFull()
        {
            //Arange
            Database database = new Database(this._people);
            //Assert
            Assert.AreEqual("Array's capacity must be exactly 16 integers!",
            Assert.Throws<InvalidOperationException>(() => database.Add(this._personJozo), "Exception is not thrown").Message,
            "Exception Message is not the same.");
        }
        [Test]
        public void AddMethodShouldNotAddUsersWithTheSameName()
        {
            //Arange
            Database database = new Database(this._personJozo);
            //Assert
            Assert.AreEqual("There is already user with this username!",
            Assert.Throws<InvalidOperationException>(() => database.Add(this._personJozo), "Exception is not thrown").Message,
            "Exception Message is not the same.");
        }
        [Test]
        public void AddMethodShouldNotAddUsersWithTheSameId()
        {
            //Arange
            Database database = new Database(new Person(this._personJozo.Id, this._personJozo.UserName + " "));
            //Assert
            Assert.AreEqual("There is already user with this Id!",
            Assert.Throws<InvalidOperationException>(() => database.Add(this._personJozo), "Exception is not thrown").Message,
            "Exception Message is not the same.");
            Assert.AreEqual(1, database.Count, "Add method incrases count in case of invalid user.");
        }
        //Remove Method tests:
        [Test]
        public void RemoveShouldRemoveTheLastPerson()
        {
            //Arange
            Database database = new Database(this._people);
            //Act
            database.Remove();
            //Assert
            Assert.AreEqual(this._people.Length - 1, database.Count);
        }
        [Test]
        public void RemoveMethodShouldNotExecuteWhenCollectionIsEmpty()
        {
            //Arange
            Database emptyDatabase = new Database();
            //Assert
            Assert.Throws<InvalidOperationException>(emptyDatabase.Remove);
        }
        //Find by username tests:
        [Test]
        [TestCase("jozo")]
        [TestCase("jozo1")]
        public void FindByUsernameShouldFindPersonByUsername(string name)
        {
            //Act
            Person result = this.peopleDatabase.FindByUsername(name);
            //Assert
            Assert.AreEqual(name, result.UserName);
        }
        [Test]
        [TestCase("jozo1000")]
        public void FindByUsernameShould_ThrowInvalidOperationExceptionIfUsernameDoesNotExist(string testUsername)
        {
            Assert.AreEqual("No user is present by this username!",
            Assert.Throws<InvalidOperationException>(() => peopleDatabase.FindByUsername(testUsername),
            "Exception is not thrown").Message,
            "Exception Message is not the same.");
        }
        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void FindByUsernameShould_ThrowArgumentNullExceptionIfUsernameIsNullOrEmpty(string testUsername)
        {
            //Assert
            Assert.Throws<ArgumentNullException>(() => this.peopleDatabase.FindByUsername(testUsername), "Exception is not thrown");
            //Assert.AreEqual("Username parameter is null!",
            //Assert.Throws<ArgumentNullException>(() => peopleDatabase.FindByUsername(testUsername),
            //"Exception is not thrown").Message,
            //"Exception Message is not the same.");
        }
        //FindById tests:
        [Test]
        [TestCase(15)]
        public void FindByIdShouldReturnPersonById(long id)
        {
            //Act
            Person result = peopleDatabase.FindById(id);
            //Assert
            Assert.AreEqual(id, result.Id, "FindById method is not wroking");
        }
        [Test]
        public void FindByIdShould_ThrowInvalidOperationExceptionIfIdDoesNotExist()
        {
            //Assert
            Assert.AreEqual("No user is present by this ID!",
            Assert.Throws<InvalidOperationException>(() => peopleDatabase.FindById(int.MaxValue),
            "Exception is not thrown").Message,
            "Exception Message is not the same.");
        }
        [Test]
        public void FindByIdShould_ThrowArgumentOutOfRangeExceptionForNegativeValues()
        {
            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => this.peopleDatabase.FindById(-23451343513), "Exception is not thrown");
            //Assert.AreEqual("Id should be a positive number!",
            //Assert.Throws<ArgumentOutOfRangeException>(() => this.peopleDatabase.FindById(-23451343513),
            //"Exception is not thrown").Message,
            //"Exception Message is not the same.");
        }
    }
}