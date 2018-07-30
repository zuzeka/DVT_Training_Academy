using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrainingAcademy.BL.Abstract;
using TrainingAcademy.BL.Concrete;
using TrainingAcademy.DAL;

namespace TrainingAcademy.UI.Controllers
{
    public class CoursesController : Controller
    {
        ICourse _ICourse;

        public CoursesController(ICourse _iCourse)
        {
            _ICourse = _iCourse;
        }

        // GET: Courses
        public ActionResult Index()
        {
            // Call Web-API         
            // deserialize response 
            

            return View(_ICourse.GetCourses());
        }

        // GET: Courses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Courses/Create
        [HttpPost]
        public ActionResult Create(DAL.Course course)
        {

            if (ModelState.IsValid)
            {
                _ICourse.AddOrUpdateCourse(course);
                _ICourse.Commit();
                return RedirectToAction("Index");
            }

            return View(course);
        }


        // GET: Courses/Edit/5
        public ActionResult Edit(int id)
        {
            if (id > 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DAL.Course course = _ICourse.GetCoursebyid(id);
            return View(course);
        }

        // POST: Courses/Edit/5
        [HttpPost]
        public ActionResult Edit(DAL.Course course)
        {
            if(ModelState.IsValid)
            {
                _ICourse.AddOrUpdateCourse(course);
                _ICourse.Commit();
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Courses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DAL.Course course = _ICourse.GetCoursebyid(id);
           
            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            _ICourse.RemoveCourse(id);
            _ICourse.Commit();
            return RedirectToAction("Index");
        }
    }
}
