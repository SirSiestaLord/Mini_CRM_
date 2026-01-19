using Mini_CRM.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Mini_CRM.Controllers
{ //Şirketler için veritabanı işlemlerini yöneten denetleyici
    public class CompaniesController : Controller
    {
        private readonly MiniCrmContext db = new MiniCrmContext();

        // LIST
        public ActionResult Index()
        {
            var companies = db.Companies
                              .OrderByDescending(c => c.CompanyId)
                              .ToList();

            return View("~/Views/Pages/companylist.cshtml", companies);
       
        }

        // CREATE (GET)
        public ActionResult Create()
        {
            return View();
        }

        // CREATE (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Company company)
        {
      
                db.Companies.Add(company);
                db.SaveChanges();
                return RedirectToAction("Index");

        }

        // EDIT (GET)
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var company = db.Companies.Find(id);
            if (company == null)
                return HttpNotFound();

            return View(company);
        }

        // EDIT (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Company company)
        {
            if (ModelState.IsValid)
            {
                db.Entry(company).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(company);
        }

        public ActionResult Delete(int id)
        {
            var company = db.Companies.Find(id);
            if (company != null)
            {
                db.Companies.Remove(company);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }


        // DISPOSE
        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();

            base.Dispose(disposing);
        }
    }
}
