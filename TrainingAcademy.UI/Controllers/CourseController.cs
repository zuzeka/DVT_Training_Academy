using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrainingAcademy.BL.Abstract;
using TrainingAcademy.DAL;

namespace TrainingAcademy.UI.Controllers
{
    public class CourseController : Controller
    {
        private ICourse _ICourse;
        public CourseController(ICourse _iCourse)
        {
            //inject implement dependecy Injection here.
            _ICourse = _iCourse;

        }

        // GET: Course/ List Courses
        public ActionResult Index()
        {
            
            return View(_ICourse.GetCourses());
        }

        // GET: Course/Create, a course
        public ActionResult Create()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult Create(Course course)
        {
            _ICourse.AddCourse(course);
            _ICourse.Comit();
            return View();
        }

        // GET: Course/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_ICourse.GetCoursebyid(id));
        }

        // POST: Course/Edit/5
        [HttpPost]
        public ActionResult Edit()
        {
            try
            {


                //_ICourse.EditCourse();
                //_ICourse.Comit();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Course/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Course/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
