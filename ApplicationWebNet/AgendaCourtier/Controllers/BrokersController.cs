using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using AgendaCourtier.Models;
using System.Web.Mvc;
using System.Net;
using PagedList;
using PagedList.Mvc;

namespace AgendaCourtier.Controllers
{
    public class BrokersController : Controller
    {
        AgendaCourtierEntities db = new AgendaCourtierEntities();

        // GET: Brokers
        public ActionResult Brokers()
        {
                return View();
        }

        [HttpPost]
        public ActionResult Brokers(Brokers brokers)
        {
            if (ModelState.IsValid)
            {
                db.Brokers.Add(brokers);
                db.SaveChanges();
                TempData["SuccessMessage"] = "Enregistré avec succès";

                return RedirectToAction("BrokersList");
            }
            return View(brokers);
        }

        public ActionResult BrokersList(string searchBy, string search, int? page)
        {
            if (searchBy == "firstname")
            {
                return View(db.Brokers.Where(model => model.firstname.Contains(search) || search == null).ToList().ToPagedList(page ?? 1, 5));
            }
            else
            {
                return View(db.Brokers.Where(model => model.lastname.Contains(search) || search == null).ToList().ToPagedList(page ?? 1, 5));
            }
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brokers brokers = db.Brokers.Find(id);
            if (brokers == null)
            {
                return HttpNotFound();
            }
            return View(brokers);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var brokers = db.Brokers.Where(model => model.idBroker == id).First();
            //Brokers brokers = db.Brokers.Find(id);
            db.Brokers.Remove(brokers);
            db.SaveChanges();
            TempData["successMessage"] = "Supprimer";

            return RedirectToAction("BrokersList");
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brokers brokers = db.Brokers.Find(id);
            if (brokers == null)
            {
                return HttpNotFound();
            }
            return View(brokers);
        }

        public ActionResult Edit(int? id)
        {

            Brokers brokers = db.Brokers.Find(id);
            if (brokers == null)
            {
                return HttpNotFound();
            }
            return View(brokers);
        }

        [HttpPost]
        public ActionResult Edit(Brokers brokers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(brokers).State = EntityState.Modified;
                db.SaveChanges();
                TempData["SuccessMessage"] = "Modifications enregistrées".ToString();

                return RedirectToAction("BrokersList");
            }
            return View(brokers);
        }

        public ActionResult BrokerAppointment(int? idBroker)
        {
            return RedirectToAction("Appointments", "Appointments", new { idBroker = idBroker });
        }

        public ActionResult ABlist(int? id)
        {
            return RedirectToAction("AppointmentsList", "Appointments");
        }
    }
}