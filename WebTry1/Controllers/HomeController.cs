using Bogus;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTry1.Models;

namespace WebTry1.Controllers
{
    public class HomeController : Controller
    {
        akshopEntities1 context = new akshopEntities1();
        public ActionResult Index()
        {
            var fakeData = new Faker<brand>()
                .RuleFor(x => x.brand1, f => f.Name.FullName());

            var dataIs = fakeData.Generate(100);
            context.brands.AddRange(dataIs);
            context.SaveChanges();
            return View(context.brands.ToList());
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        public ActionResult Add(brand brand)
        {
             context.brands.Add(brand);
             context.SaveChanges();   
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var brandNameEdit = context.brands.Find(id);
            return View(brandNameEdit);
        }
        [HttpPost]
        public ActionResult Edit(int id, brand brand)
        {
            brand.id = id;
            //var editBrand = context.brands.Find(id);
            //editBrand.brand1 = brand.brand1;
            context.Entry(brand).State = EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var deleteBrand = context.brands.Find(id);
            context.brands.Remove(deleteBrand);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}