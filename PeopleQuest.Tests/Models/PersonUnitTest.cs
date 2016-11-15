using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PeopleQuest.Models;

namespace PeopleQuest.Tests.Models
{
    [TestClass]
    public class PersonUnitTest
    {
        [TestMethod]
        public void Age()
        {
            var ageYears = 26;
            var today = DateTime.Now;
            var person = new PersonSummaryViewModel
            {
                FirstName = "FirstName",
                LastName = "LastName",
                Address1 = "Address1",
                Address2 = "Address2",
                BirthDate = new DateTime(today.Year - ageYears, today.Month, today.Day),
                Interests = "Interests"
            };
            Assert.AreEqual(ageYears, person.Age);
        }

        [TestMethod]
        public void GetSet()
        {
            var person = new PersonSummaryViewModel
            {
                FirstName = "FirstName",
                LastName = "LastName",
                Address1 = "Address1",
                Address2 = "Address2",
                Interests ="Interests"
            };
            Assert.AreEqual("FirstName", person.FirstName);
            Assert.AreEqual("LastName", person.LastName);
            Assert.AreEqual("Address1", person.Address1);
            Assert.AreEqual("Address2", person.Address2);
            Assert.AreEqual("Interests", person.Interests);
        }
    }
}
