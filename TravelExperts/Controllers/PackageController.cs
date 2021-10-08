using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelExperts.Models;

namespace TravelExperts.Controllers
{
    public class PackageController : Controller
    {
        private TravelExpertsUnitOfWork data { get; set; }
        public PackageController(TravelExpertsContext ctx) => data = new TravelExpertsUnitOfWork(ctx);


        // GET: PackageController
        //[Authorize(Roles = "Admin,Customer")]
        public ViewResult Index(PackagesGridDTO values)
        {
            var q = new QueryOptions<Package>();
            q.OrderBy = s => s.PackageId;

            var packages = data.Packages.List(q);
            return View(packages);
        }

        
        // GET: PackageController/Details/5
        public ActionResult Details(int id)
        {
                var book = data.Packages.Get(new QueryOptions<Package>
                {
                    Where = b => b.PackageId == id
                });
                return View(book);
        }

        
        // GET: PackageController/Create
        public ActionResult Create()
        {
            return View();
        }

        
        // POST: PackageController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        // GET: PackageController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        
        // POST: PackageController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        
        // GET: PackageController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }


        // POST: PackageController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
