using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTry1.Models;

namespace WebTry1.Controllers
{
    public class ProductController : Controller
    {
        akshopEntities1 context = new akshopEntities1();
        [HttpGet]
        public ActionResult Index()
        {

            return View(context.products.ToList());
        }
        [HttpGet]
        public ActionResult Add()
        {
            ViewBag.brands = context.brands.ToList();
            ViewBag.categories = context.categories.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Add(product product)
        {
            context.products.Add(product);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var productToDelete = context.products.Find(id);
            context.products.Remove(productToDelete);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}