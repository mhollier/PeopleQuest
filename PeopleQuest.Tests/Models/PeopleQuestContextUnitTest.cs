using System;
using System.Linq;
using Effort.DataLoaders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PeopleQuest.Models;

namespace PeopleQuest.Tests.Models
{
    [TestClass]
    public class PeopleQuestContextUnitTest
    {
        private PeopleQuestContext ctx;

        [TestInitialize]
        public void Initialize()
        {
        }

        [TestMethod]
        public void Query()
        {
            // Arrange
            var conn = Effort.DbConnectionFactory.CreateTransient(new EmptyDataLoader());
            ctx = new PeopleQuestContext(conn);
            ctx.Persons.Add(new Person
            {
                FirstName = "Tyrion",
                LastName = "Lannister",
                Address1 = "King's Landing",
                BirthDate = DateTime.Parse("1/1/1977"),
                Interests = "Drinking, Sarcasm, Companionship",
            });
            ctx.Persons.Add(new Person
            {
                FirstName = "Cersei",
                LastName = "Lannister",
                Address1 = "King's Landing",
                BirthDate = DateTime.Parse("1/1/1975"),
                Interests = "Treachery, Plotting, Brotherly Love",
            });
            ctx.SaveChanges();

            // Act
            var results = ctx.Persons.Where(p => p.FirstName == "Cersei").ToList();

            // Assert
            Assert.IsNotNull(results);
            Assert.AreEqual(1,results.Count);
        }

    }
}
