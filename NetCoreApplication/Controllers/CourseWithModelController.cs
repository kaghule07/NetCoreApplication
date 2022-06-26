using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCoreApplication.Models;

namespace NetCoreApplication.Controllers
{
    public class CourseWithModelController : Controller
    {
        CourseDAL db = new CourseDAL();
        // GET: CourseWithModelController
        public ActionResult Index()
        {
            var cr = db.GetAllCourse();
            return View(cr);
        }

        // GET: CourseWithModelController/Details/5
        public ActionResult Details(int id)
        {
            var cr = db.GetCourseById(id);
            return View(cr);
        }

        // GET: CourseWithModelController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CourseWithModelController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Course cr)
        {
            try
            {
                db.Save(cr);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CourseWithModelController/Edit/5
        public ActionResult Edit(int id)
        {
            Course cr = db.GetCourseById(id);
            return View(cr);
        }

        // POST: CourseWithModelController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Course cr)
        {
            try
            {
                db.Update(cr);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CourseWithModelController/Delete/5
        public ActionResult Delete(int id)
        {
            Course cr = db.GetCourseById(id);
            return View(cr);
        }

        // POST: CourseWithModelController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                db.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
