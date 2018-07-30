using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrainingAcademy.BL.Abstract;

namespace TrainingAcademy.UI.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IRegister _register;
        public RegisterController(IRegister register)
        {
            _register = register;
        }
        public ActionResult Index()
        {
            return View(_register.ListRegistration());
        }
        // GET: Delegate/Create
        public ActionResult Create()
        {
           
            return View();
        }

        // POST: Delegate/Create
        [HttpPost]
        public ActionResult Create(DAL.Registration registration)
        {
            try
            {
                _register.RegisterTraining(registration);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public ActionResult Edit(int id)
        {
            ViewBag.DietaryID = new SelectList(_register.ListRegistration(), "DietaryID", "DietaryDescription");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            return View(_register.GetRegister(id));
        }

        // POST: Register/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                _register.UpdateRegister(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Register/Delete/5
        public ActionResult Delete(int id)
        {
            ViewBag.DietaryID = new SelectList(_register.ListRegistration(), "DietaryID", "DietaryDescription");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            return View(_register.GetRegister(id));
        }

        // POST: Register/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                _register.RemoveRegister(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
