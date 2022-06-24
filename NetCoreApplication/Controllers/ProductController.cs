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
   
    public class ProductController : Controller
    {
        ProductDAL context = new ProductDAL();
        public IActionResult List()
        {
            ViewBag.ProductList = context.GetAllProducts();
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
            Product p=new Product();
            p.Name = form["name"];
            p.Price = Convert.ToDouble(form["price"]);
            int res = context.Save(p);
            if (res == 1)
                return RedirectToAction("List");
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Product prod = context.GetProductById(id);
            ViewBag.Name = prod.Name;
            ViewBag.Price = prod.Price;
            ViewBag.Id = prod.Id;
            return View();
        }
        [HttpPost]

        public IActionResult Edit(IFormCollection form)
        {
            Product prod = new Product();
            prod.Name = form["name"];
            prod.Price = Convert.ToDouble(form["price"]);
            prod.Id = Convert.ToInt32(form["Id"]);
            int res=context.Update(prod); 
            if(res==1)
                return RedirectToAction("List");
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Product prod = context.GetProductById(id);
            ViewBag.Name = prod.Name;
            ViewBag.Price = prod.Price;
            ViewBag.Id=prod.Id;
            return View();
        }
        [HttpPost]
        [ActionName ("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            int res = context.Delete(id);
            if (res == 1)
                return RedirectToAction("List");
            return View();
        }
    }
}
