using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoBAC.Models;
using System;

namespace ProyectoBAC.Controllers
{
    public class PersonController : Controller
    {

        private static List<Persona> model = new List<Persona>();

        // GET: PersonController
        public ActionResult Index()
        {

            return View(model);
        }

        // GET: PersonController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PersonController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Persona persona)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    persona.CreatedAt = DateTime.Now;
                    persona.Id = model.Count > 0 ? model.Max(p => p.Id) + 1 : 1;
                    persona.FullName = persona.FullName.Trim();
                    model.Add(persona);
                    return RedirectToAction("Index");
                }
                return View(persona);
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonController/Edit/5
        public ActionResult Edit(int id)
        {
            var persona = model.FirstOrDefault(p => p.Id == id);
            if (persona == null)
            {
                return NotFound();
            }
            else
            {

                persona.FullName = persona.FullName.Trim();
            }
            return View(persona);
        }

        // POST: PersonController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Persona persona)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var existingPerson = model.FirstOrDefault(p => p.Id == id);
                    if (existingPerson != null)
                    {
                        existingPerson.FullName = persona.FullName;
                        existingPerson.HomePhone = persona.HomePhone;
                        existingPerson.CellPhone = persona.CellPhone;
                        existingPerson.BirthYear = persona.BirthYear;
                    }
                    return RedirectToAction(nameof(Index));
                }
                return View(persona);
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonController/Delete/5
        public ActionResult Delete(int id)
        {
            var persona = model.FirstOrDefault(p => p.Id == id);
            if (persona == null)
            {
                return NotFound();
            }
            return View(persona);
        }

        // POST: PersonController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var persona = model.FirstOrDefault(p => p.Id == id);
                if (persona != null)
                {
                    model.Remove(persona);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
