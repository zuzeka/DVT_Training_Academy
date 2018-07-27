using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrainingAcademy.BL.Abstract;
using TrainingAcademy.DAL;
using AutoMapper;
using System.Net;

namespace TrainingAcademy.UI.Controllers
{
    public class TrainingController : Controller
    {
        private readonly ITraining _training;
        public TrainingController(ITraining training)
        {
            _training = training;
        }

        // GET: Training
        public ActionResult Index()
        {
            return View(_training.GetAll());
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(DAL.Training dTraining)
        {
            if (ModelState.IsValid)
            {
                //_training.Insert(Mapper.Map<Training>(dTraining));
                _training.Insert(dTraining);
                //_training.Save();
                return RedirectToAction("Index");
            }

            return View();
        }

        //public ActionResult Delete(int id)
        //{
        //    _training.Delete(id);
        //    return View();
        //}
        // GET: /Movies/Delete/5
        public ActionResult Delete(int id)
        {
            id = 1;
            if (ModelState.IsValid)
            {
                _training.Delete(id);
            }
            return View();
        }

        //// POST: /Movies/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Movie movie = db.Movies.Find(id);
        //    db.Movies.Remove(movie);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

    }
}