using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelExperts.Models;

namespace TravelExperts.Areas.Admin.Controllers
{
    public class AgencyController : Controller
    {

        private TravelExpertsUnitOfWork data { get; set; }
        public AgencyController(TravelExpertsContext ctx) => data = new TravelExpertsUnitOfWork(ctx);

        //// GET: AgencyController
        //public ActionResult Index()
        //{
        //    var q = new QueryOptions<Agency>();
        //    q.OrderBy = s => s.AgencyId;

        //    var agencies = data.Agencies.List(q);
        //    return View(agencies);
        //}

        //// GET: AgencyController/Details/5
        //public ActionResult Details(int id)
        //{
        //    var book = data.Agencies.Get(new QueryOptions<Agency>
        //    {
        //        Where = b => b.AgencyId == id
        //    });
        //    return View(book);
        //}

        //// GET: AgencyController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: AgencyController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: AgencyController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: AgencyController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: AgencyController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: AgencyController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
