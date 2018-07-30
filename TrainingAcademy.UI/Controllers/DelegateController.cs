using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrainingAcademy.BL.Abstract;
using TrainingAcademy.UI.ViewModel;

namespace TrainingAcademy.UI.Controllers
{
    public class DelegateController : Controller
    {
        private readonly IDelegate _delegate;
        public DelegateController(IDelegate @delegate)
        {
            _delegate = @delegate;
        }

        public ActionResult Index()
        {
            return View(_delegate.ListDelegate());
        }
        // GET: Delegate/Create
        public ActionResult Create()
        {
            ViewBag.DietaryID = new SelectList(_delegate.GetDietaries(), "DietaryID", "DietaryDescription");
            return View();
        }

        // POST: Delegate/Create
        [HttpPost]
        public ActionResult Create(DAL.Delegate @delegate)
        {
            try
            {
                _delegate.AddDelegate(@delegate);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public ActionResult Edit(int id)
        {
            ViewBag.DietaryID = new SelectList(_delegate.GetDietaries(), "DietaryID", "DietaryDescription");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View(_delegate.GetDelegate(id));
            return View();
        }

        // POST: Register/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                _delegate.UpdateDelegate(id);
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
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View(_delegate.GetDelegate(id));
            
        }

        // POST: Register/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                _delegate.RemoveDelegate(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


    }
}
