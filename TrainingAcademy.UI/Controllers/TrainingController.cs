using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrainingAcademy.BL.Abstract;

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
                _training.Insert(dTraining);
            }

            return View();
        }

    }
}