using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.API.Controllers
{
    public class JobpositionnouseController : Controller
    {
        // GET: JobpositionnouseController
        public ActionResult Index()
        {
            return View();
        }

        // GET: JobpositionnouseController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: JobpositionnouseController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: JobpositionnouseController/Create
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

        // GET: JobpositionnouseController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: JobpositionnouseController/Edit/5
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

        // GET: JobpositionnouseController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: JobpositionnouseController/Delete/5
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
