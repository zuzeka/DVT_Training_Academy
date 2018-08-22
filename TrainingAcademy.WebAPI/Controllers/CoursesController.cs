using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TrainingAcademy.BL.Abstract;
using TrainingAcademy.DAL;
using TrainingAcademy;
using TrainingAcademy.WebAPI.Models;
using TrainingAcademy.UI;


namespace TrainingAcademy.WebAPI.Controllers
{
    [RoutePrefix("api/Courses")]
    public class CoursesController : ApiController
    {
        private ICourse _iCourse;

        public CoursesController()
        { }
        public CoursesController(ICourse iCourse)
        {
            this._iCourse = iCourse;
        }
        [HttpGet]
        // GET: api/Courses
        [Route("GetCourses")]
        public IEnumerable<CourseDTO> GetCourses()
        {
            var list = _iCourse.GetCourses().ToList();

            var CourseList = list.Select(x => new CourseDTO()
            {
                CourseID = x.CourseID,
                CourseCode = x.CourseCode,
                CourseName = x.CourseName,
                CourseDescription = x.CourseDescription

            }).ToList();

            return CourseList;        
        }

        // GET: api/Courses/5
        [Route("GetCoursebyid/{courseId}")]
        public IHttpActionResult GetCoursebyid(int id)
        {
            var entity = _iCourse.GetCoursebyid(id);
            if (entity != null)
            {
                Request.CreateResponse(HttpStatusCode.OK, entity);
            }
            return Ok(entity);

        }

        // POST: api/Courses
        [HttpPost]
        //[AcceptVerbs("POST", "PUT")]
        [Route("AddCourse")]
       
        public HttpResponseMessage AddCourse([FromBody]CourseDTO dTO)
        {
            /*DAL.Course*/
            DAL.Course course = new DAL.Course()
            {
                CourseID = dTO.CourseID,
                CourseCode = dTO.CourseCode,
                CourseName = dTO.CourseName,
                CourseDescription = dTO.CourseDescription,
                DateCreated = dTO.DateCreated,
                DateModified = dTO.DateModified


            };
            _iCourse.AddOrUpdateCourse(course);
            _iCourse.Commit();
            var message = Request.CreateResponse(HttpStatusCode.Created, course);
            return message;

        }

        // PUT: api/Courses/5//update
        [HttpPut]
        //[AcceptVerbs("POST", "PUT")]
        [Route("UpdateCourse")]
        public IHttpActionResult UpdateCourse(int id, [FromBody]CourseDTO dTO)
        {

            DAL.Course course = new DAL.Course()
            {
                CourseID = dTO.CourseID,
                CourseCode = dTO.CourseCode,
                CourseName = dTO.CourseName,
                CourseDescription = dTO.CourseDescription,
                DateCreated = dTO.DateCreated,
                DateModified = dTO.DateModified


            };
            _iCourse.AddOrUpdateCourse(course);
            var message = Request.CreateResponse(HttpStatusCode.Created, course);
            return Ok(message);
        }

        // DELETE: api/Courses/5
        [HttpDelete]
        [Route("DeleteCourse")]
        public HttpResponseMessage DeleteCourse(int id)
        {
            _iCourse.RemoveCourse(id);
            _iCourse.Commit();
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
