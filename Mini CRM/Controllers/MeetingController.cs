using Mini_CRM.Models;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

public class MeetingsController : Controller
{//Görüşmeler için veritabanı işlemlerini yöneten denetleyici
    MiniCrmContext db = new MiniCrmContext();

    public ActionResult Index()
    {
        var meetings = db.Meetings
                         .Include(m => m.Company)
                         .OrderByDescending(m => m.MeetingDate)
                         .ToList();

        return View("~/Views/Pages/meetinglist.cshtml", meetings);
    }

    public ActionResult Create()
    {
        ViewBag.Companies = db.Companies
            .Select(c => new SelectListItem
            {
                Value = c.CompanyId.ToString(),
                Text = c.CompanyName
            }).ToList();

        return View();
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Meeting model)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Companies = db.Companies
                .Select(c => new SelectListItem
                {
                    Value = c.CompanyId.ToString(),
                    Text = c.CompanyName
                }).ToList();

            return View(model);
        }

        db.Meetings.Add(model);
        db.SaveChanges();

        return RedirectToAction("Index");
    }


    public ActionResult Edit(int id)
    {
        var meeting = db.Meetings.Find(id);
        if (meeting == null) return HttpNotFound();

        ViewBag.Companies = new SelectList(
            db.Companies.ToList(),
            "CompanyId",
            "CompanyName",
            meeting.CompanyId);

        return View("~/Views/Meetings/Edit.cshtml", meeting);
    }

    [HttpPost]
    public ActionResult Edit(Meeting model)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Companies = new SelectList(
                db.Companies.ToList(),
                "CompanyId",
                "CompanyName",
                model.CompanyId);

            return View("~/Views/Meetings/Edit.cshtml", model);
        }

        db.Entry(model).State = EntityState.Modified;
        db.SaveChanges();

        return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
        var meeting = db.Meetings.Find(id);
        if (meeting == null) return HttpNotFound();

        db.Meetings.Remove(meeting);
        db.SaveChanges();

        return RedirectToAction("Index");
    }
}
