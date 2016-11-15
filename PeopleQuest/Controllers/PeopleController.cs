using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using PagedList;
using PeopleQuest.Models;

namespace PeopleQuest.Controllers
{
    [Authorize]
    public class PeopleController : Controller
    {
        private readonly PeopleQuestContext ctx;

        public PeopleController()
        {
            ctx = new PeopleQuestContext();
        }

        public PeopleController(PeopleQuestContext ctx)
        {
            this.ctx = ctx;
        }

        // GET: People
        [AllowAnonymous]
        public async Task<ActionResult> Index(string currentFilter = null, string searchTerm = null, int page = 1)
        {
            await Task.Delay(500);

            // Replace the current search term if it has changed
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                searchTerm = currentFilter;
            }
            ViewBag.CurrentFilter = searchTerm;

            var people = from p in ctx.Persons
                where searchTerm == null || p.FirstName.ToUpper().Contains(searchTerm.ToUpper())
                      || p.LastName.ToUpper().Contains(searchTerm.ToUpper())
                orderby p.LastName, p.FirstName
                select new PersonSummaryViewModel
                {
                    Id = p.Id,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    Address1 = p.Address1,
                    Address2 = p.Address2,
                    BirthDate = p.BirthDate,
                    Interests = p.Interests
                };

            var pagedModel = people.ToPagedList(page, 5);
            // Return a partial view for AJAX requests or a full view for normal GET requests.
            return Request.IsAjaxRequest() ? (ActionResult) PartialView("_PeopleList", pagedModel) : View(pagedModel);
        }

        /// <summary>
        /// Get the photograph for a given person.
        /// </summary>
        /// <param name="id">The unique person identifier.</param>
        /// <returns></returns>
        [AllowAnonymous]
        public FileContentResult GetPicture(int id)
        {
            var image = ctx.Persons.Find(id).Image;
            return image != null ? new FileContentResult(image, "image/jpg") : GetDefaultPicture();
        }

        private static FileContentResult GetDefaultPicture()
        {
            var converter = new ImageConverter();
            var bytes = (byte[]) converter.ConvertTo(Resource.DefaultUser, typeof(byte[]));
            return new FileContentResult(bytes, "image/png");
        }

        // GET: People/Details/5
        [AllowAnonymous]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = ctx.Persons.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // GET: People/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: People/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,BirthDate,Address1,Address2,Interests,Image")] Person person)
        {
            if (ModelState.IsValid)
            {
                ctx.Persons.Add(person);
                ctx.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(person);
        }

        // GET: People/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = ctx.Persons.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: People/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,BirthDate,Address1,Address2,Interests,Image")] Person person)
        {
            if (ModelState.IsValid)
            {
                ctx.Entry(person).State = EntityState.Modified;
                ctx.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(person);
        }

        // GET: People/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = ctx.Persons.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Person person = ctx.Persons.Find(id);
            ctx.Persons.Remove(person);
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                ctx.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
