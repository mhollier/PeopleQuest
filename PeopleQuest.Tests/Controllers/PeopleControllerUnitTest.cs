using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Effort.DataLoaders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PeopleQuest.Controllers;
using PeopleQuest.Models;

namespace PeopleQuest.Tests.Controllers
{
    [TestClass]
    public class PeopleControllerUnitTest
    {
        private PeopleQuestContext ctx;
        private Mock<HttpContextBase> httpContextMock;

        [TestInitialize]
        public void Initialize()
        {
            // Initialize a simple in-memory database context using Effort (http://effort.codeplex.com).
            var conn = Effort.DbConnectionFactory.CreateTransient(new EmptyDataLoader());
            ctx = new PeopleQuestContext(conn);
            ctx.Persons.Add(new Person
            {
                Id = 1,
                FirstName = "Tyrion",
                LastName = "Lannister",
                Address1 = "King's Landing",
                BirthDate = DateTime.Parse("1/1/1977"),
                Interests = "Drinking, Sarcasm, Companionship",
            });
            ctx.Persons.Add(new Person
            {
                Id = 2,
                FirstName = "Cersei",
                LastName = "Lannister",
                Address1 = "King's Landing",
                BirthDate = DateTime.Parse("1/1/1975"),
                Interests = "Treachery, Plotting, Brotherly Love",
            });
            ctx.SaveChanges();

            // Initialize mock controller context
            httpContextMock = new Mock<HttpContextBase>();
            var mockRequest = new Mock<HttpRequestBase>();
            httpContextMock.SetupGet(x => x.Request).Returns(mockRequest.Object);
        }

        [TestMethod]
        public void Index()
        {
            // Arrange
            var controller = new PeopleController(ctx);
            controller.ControllerContext = new ControllerContext(httpContextMock.Object, new RouteData(), controller);

            // Act
            var result = controller.Index();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void Details_BadRequest()
        {
            // Arrange
            var controller = new PeopleController(ctx);

            // Act
            var result = controller.Details(null);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(HttpStatusCodeResult));
        }

        [TestMethod]
        public void Details_Invalid_Identifier()
        {
            // Arrange
            var controller = new PeopleController(ctx);

            // Act
            var result = controller.Details(999);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(HttpNotFoundResult));
        }

        [TestMethod]
        public void Details()
        {
            // Arrange
            const int personId = 2;
            var controller = new PeopleController(ctx);

            // Act
            var result = controller.Details(personId);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ViewResult));

            var viewResult = (ViewResult)result;
            Assert.IsNotNull(viewResult.Model);
            Assert.IsInstanceOfType(viewResult.Model, typeof(Person));
            var personResult = (Person)viewResult.Model;
            Assert.AreEqual(personId, personResult.Id);
        }

        [TestMethod]
        public void Create()
        {
            // Arrange
            var controller = new PeopleController(ctx);

            // Act
            var result = controller.Create();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(HttpStatusCodeResult));
        }

        [TestMethod]
        public void Create2()
        {
            // Arrange
            var controller = new PeopleController(ctx);

            // Act
            var newPerson = new Person
            {
                Id = 3,
                FirstName = "Jon",
                LastName = "Snow",
                Address1 = "The Wall",
                BirthDate = new DateTime(1989, 1, 1),
                Interests = "Wildlings, Night's Watch, Direwolves, Redheads",
            };
            var result = controller.Create(newPerson);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
            Assert.IsNotNull(ctx.Persons.Find(newPerson.Id));
        }


    }
}
