using CRUD_Operation_With_AJAX.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Operation_With_AJAX.Controllers
{
    public class VisitorsController : Controller
    {
        private readonly GuestDbContext db;
        public VisitorsController(GuestDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            return View(db.Visitors.ToList());
        }

        public IActionResult Create()
        {


            return View();
        }

        [HttpPost]
        public IActionResult Create(Visitor visitor)
        {
            if (ModelState.IsValid)
            {
                db.Visitors.Add(visitor);
                db.SaveChanges();
                return PartialView("_success");
            }
            return PartialView("_error");

        }


        public IActionResult Edit(int? id)
        {
            var vist = db.Visitors.FirstOrDefault(x => x.Id == id);
            if (vist == null)
            {
                return NotFound();
            }

            return View(vist);


        }

        [HttpPost]
        public IActionResult Edit(Visitor visitor)
        {
            if (ModelState.IsValid)
            {
                db.Visitors.Update(visitor);
                db.SaveChanges();
                return PartialView("_success");
            }


            return View(visitor);

        }

        public IActionResult Delete(int? id)
        {
            var vist = db.Visitors.FirstOrDefault(x => x.Id == id);
            if (vist == null)
            {
                return NotFound();
            }

            return View(vist);

        }

        [HttpPost]
        public IActionResult Delete(int id)
        {

            var vist = db.Visitors.First(x => x.Id == id);
            if (vist == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                db.Visitors.Remove(vist);
                db.SaveChanges();
                return PartialView("_success");
            }
            return View(id);

        }




    }
}