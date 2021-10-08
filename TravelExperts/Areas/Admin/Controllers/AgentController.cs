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
    public class AgentController : Controller
    {
        private TravelExpertsUnitOfWork data { get; set; }
        public AgentController(TravelExpertsContext ctx) => data = new TravelExpertsUnitOfWork(ctx);

        // GET: AgentController
        //public ActionResult Index()
        //{
        //    var q = new QueryOptions<Agent>();
        //    q.OrderBy = s => s.AgentId;

        //    var agents = data.Agents.List(q);
        //    return View(agents);
        //}

        //// GET: AgentController/Details/5
        //public ActionResult Details(int id)
        //{
        //    var book = data.Agents.Get(new QueryOptions<Agent>
        //    {
        //        Where = b => b.AgentId == id
        //    });
        //    return View(book);
        //}

        //// GET: AgentController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: AgentController/Create
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

        //// GET: AgentController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: AgentController/Edit/5
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

        //// GET: AgentController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: AgentController/Delete/5
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
