using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.Extensions.Logging;
using NetCoreApplication.Models;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.AspNetCore.Http;

namespace NetCoreApplication.Controllers
{
    public class CourseController : Controller
    {

        CourseDAL context = new CourseDAL();
        public IActionResult List()
        {
            ViewBag.CourseList = context.GetAllCourse();
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(IFormCollection form)
        {
            Course c = new Course();
            c.Name = form["name"];
            c.Fees = Convert.ToDouble(form["fees"]);
            int res = context.Save(c);
            if (res == 1)
                return RedirectToAction("List");
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Course cr = context.GetCourseById(id);
            ViewBag.Name = cr.Name;
            ViewBag.Fees = cr.Fees;
            ViewBag.Id = cr.Id;
            return View();
        }
        [HttpPost]
        public IActionResult Edit(IFormCollection form)
        {
            Course cr = new Course();
            cr.Name = form["name"];
            cr.Fees = Convert.ToDouble(form["fees"]);
            cr.Id = Convert.ToInt32(form["Id"]);
            int res = context.Update(cr);
            if (res == 1)
                return RedirectToAction("List");
            return View();
        }
        public IActionResult Delete(int id)
        {
            Course cr = context.GetCourseById(id);
            ViewBag.Name = cr.Name;
            ViewBag.Fees = cr.Fees;
            ViewBag.Id = cr.Id;
            return View();
        }
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            int res = context.Delete(id);
            if (res == 1)
                return RedirectToAction("List");
            return View();
        }
    }
}
