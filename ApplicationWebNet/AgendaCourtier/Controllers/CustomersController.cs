using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using AgendaCourtier.Models;
using System.Web.Mvc;
using System.Net;
using PagedList;
using PagedList.Mvc;

namespace AgendaCourtier.Controllers
{
    public class CustomersController : Controller
    {
        AgendaCourtierEntities db = new AgendaCourtierEntities();

        // GET: Customers
        public ActionResult Customers()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Customers(Customers customers)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customers);
                db.SaveChanges();
                TempData["SuccessMessage"] = "Enregistré avec succès";

                return RedirectToAction("CustomersList");
            }
            return View(customers);
        }
        public ActionResult CustomersList(string searchBy, string search, int? page, string sortBy)
        {
            ViewBag.SortlastnameParameter = string.IsNullOrEmpty(sortBy) ? "lastname desc" : "";
            ViewBag.SortfirstnameParameter = sortBy == "firstname" ? "firstname desc" : "firstname";

            var customers = db.Customers.AsQueryable();

            if (searchBy == "firstname")
            {
                customers = customers.Where(model => model.firstname.Contains(search) || search == null);
            }
            else
            {
                customers = customers.Where(model => model.lastname.Contains(search) || search == null);
            }
            switch (sortBy)
            {
                case "lastname desc":
                    customers = customers.OrderByDescending(model => model.lastname);
                    break;
                case "firstname desc":
                    customers = customers.OrderByDescending(model => model.firstname);
                    break;
                case "firstname":
                    customers = customers.OrderBy(model => model.firstname);
                    break;
                default:
                    customers = customers.OrderBy(model => model.lastname);
                    break;
            }
            return View(customers.ToPagedList(page ?? 1, 5));
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var customers = db.Customers.Where(model => model.idCustomer == id).First();
            db.Customers.Remove(customers);
            db.SaveChanges();
            TempData["SuccessMessage"] = "Supprimer";

            var list = db.Customers.ToList();
            return RedirectToAction("CustomersList", list);
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customers customers = db.Customers.Find(id);
            if (customers == null)
            {
                return HttpNotFound();
            }
            return View(customers);
        }
        public ActionResult Edit(int? id)
        {
            Customers customers = db.Customers.Find(id);
            if (customers == null)
            {
                return HttpNotFound();
            }
            return View(customers);
        }

        [HttpPost]
        public ActionResult Edit(Customers customers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customers).State = EntityState.Modified;
                db.SaveChanges();
                TempData["SuccessMessage"] = "Modifications enregistrées";

                return RedirectToAction("CustomersList");
            }
            return View(customers);
        }
    }
}