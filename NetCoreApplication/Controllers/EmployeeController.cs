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
    public class EmployeeController : Controller
    {
        EmployeeDAL context = new EmployeeDAL();
        public IActionResult List()
        {
            ViewBag.EmployeeList = context.GetAllEmployee();
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
            Employee emp = new Employee();
            emp.Name = form["name"];
            emp.Salary = Convert.ToDouble(form["salary"]);
            int res = context.Save(emp);
            if (res == 1)
                return RedirectToAction("List");
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Employee emp = context.GetEmployeeById(id);
            ViewBag.Name = emp.Name;
            ViewBag.Salary = emp.Salary;
            ViewBag.Id = emp.Id;
            return View();
        }
        [HttpPost]
        public IActionResult Edit(IFormCollection form)
        {
            Employee emp = new Employee();
            emp.Name = form["name"];
            emp.Salary = Convert.ToDouble(form["salary"]);
            emp.Id = Convert.ToInt32(form["Id"]);
            int res = context.Update(emp);
            if (res == 1)
                return RedirectToAction("List");
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Employee emp = context.GetEmployeeById(id);
            ViewBag.Name = emp.Name;
            ViewBag.Salary = emp.Salary;
            ViewBag.Id = emp.Id;
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
