using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AgendaCourtier.Models;


namespace AgendaCourtier.Controllers
{
    public class AppointmentsController : Controller
    {
        AgendaCourtierEntities db = new AgendaCourtierEntities();

        // GET: Appointments
        public ActionResult Appointments(int? idBroker)
        {
            ViewBag.idBroker = new SelectList(db.Brokers, "idBroker", "lastname");
            ViewBag.idCustomer = new SelectList(db.Customers,"idCustomer", "lastname");
            return View();
        }

        [HttpPost]
        public ActionResult Appointments(Appointments appointments)
        {
            if (ModelState.IsValid)
            {
                var rdv = db.Appointments.Where(model => model.idBroker == appointments.idBroker && model.dateHour.Hour == appointments.dateHour.Hour && model.dateHour.Month == appointments.dateHour.Month && model.dateHour.Year == appointments.dateHour.Year && model.dateHour.Day == appointments.dateHour.Day).FirstOrDefault();

                if (rdv == null)
                {
                    db.Appointments.Add(appointments);
                    db.SaveChanges();
                    TempData["SuccessMessage"] = "Enregistré avec succès";
                    return RedirectToAction("AppointmentsList");
                }
                else
                {
                    TempData["ErrorMessage"] = "Ce rendez-vous existe déja pour ce courtier";
                    return RedirectToAction("Appointments");
                }

                //return RedirectToAction("AppointmentsList");
            }
            ViewBag.idBroker = new SelectList(db.Brokers, "idBroker", "lastname", appointments.idBroker);
            ViewBag.idCustomer = new SelectList(db.Customers, "idCustomer", "lastname", appointments.idCustomer);

            return View(appointments);
        }

        public ActionResult AppointmentsList()
        {
            var appointments = db.Appointments.Include(model => model.Brokers);
            return View(appointments.ToList());
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointments appointments = db.Appointments.Find(id);
            if (appointments == null)
            {
                return HttpNotFound();
            }
            return View(appointments);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var appointments = db.Appointments.Where(model => model.idAppointment == id).First();
            db.Appointments.Remove(appointments);
            db.SaveChanges();
            TempData["successMessage"] = "Supprimer";

            var list = db.Appointments.ToList();
            return RedirectToAction("AppointmentsList");
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointments appointments = db.Appointments.Find(id);
            if (appointments == null)
            {
                return HttpNotFound();
            }
            return View(appointments);
        }
    }
}