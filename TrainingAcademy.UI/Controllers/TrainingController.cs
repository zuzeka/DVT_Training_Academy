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
            ViewBag.TrainingPaymentID = new SelectList(_training.GetPaymentDesc(), "TrainingPaymentID", "TrainingPaymentDescription");
            ViewBag.CourseID = new SelectList(_training.GetCourse(), "CourseID", "CourseCode");
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

        public ActionResult Delete(int id)
        {
            return View(_training.getById(id));
        }

        // POST: Trainings/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _training.Delete(id);
            return RedirectToAction("Index");
        }

        // GET: Trainings/Edit/5
        public ActionResult Update(int id)
        {
            ViewBag.TrainingPaymentID = new SelectList(_training.GetPaymentDesc(), "TrainingPaymentID", "TrainingPaymentDescription", _training.CurrentTrainingPaymentID(id));
            ViewBag.CourseID = new SelectList(_training.GetCourse(), "CourseID", "CourseCode", _training.CurrentCourseID(id));
            
            return View(_training.getById(id));
        }

        // POST: Trainings/Edit/5
        [HttpPost]
        public ActionResult Update(DAL.Training training)
        {
            ViewBag.TrainingPaymentID = new SelectList(_training.GetPaymentDesc(), "TrainingPaymentID", "TrainingPaymentDescription", _training.UpdateTrainingPaymentID(training));
            ViewBag.CourseID = new SelectList(_training.GetCourse(), "CourseID", "CourseCode", _training.UpdateCourseID(training));
            _training.Update(training);

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            ViewBag.TrainingPaymentID = new SelectList(_training.GetPaymentDesc(), "TrainingPaymentID", "TrainingPaymentDescription", _training.CurrentTrainingPaymentID(id));
            ViewBag.CourseID = new SelectList(_training.GetCourse(), "CourseID", "CourseCode", _training.CurrentCourseID(id));

            return View(_training.getById(id));
        }
    }
}