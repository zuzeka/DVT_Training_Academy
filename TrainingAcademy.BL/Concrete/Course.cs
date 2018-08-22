using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingAcademy.BL.Abstract;
using TrainingAcademy.DAL;
using System.Data.Entity;

namespace TrainingAcademy.BL.Concrete
{
    public class Course : ICourse
    {
        DVTEntities _context;
        public Course(DVTEntities Context)
        {
            _context = Context;
        }
        //Get List
        public IEnumerable<DAL.Course> GetCourses()
        {
            return _context.Courses.ToList();
        }
        //Add
        public void AddOrUpdateCourse(DAL.Course course)
        {
            if (course.CourseID == default(int))
            {
                _context.Courses.Add(course);
            }
            else
            {
                _context.Entry(course).State = EntityState.Modified;
            }
        }

        //Delete
        public void RemoveCourse(int id)
        {
            var course = _context.Courses.Find(id);
            _context.Courses.Remove(course);
        }
        public DAL.Course GetCoursebyid(int? id)
        {
            try
            {
                DAL.Course entity = _context.Courses.FirstOrDefault(x => x.CourseID == id);

                if (entity != null)
                    _context.Courses.Find(id);
                else
                    throw new Exception("Course not found");
                return entity;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }


        }
        //Save to db
        public void Commit()
        {
            try
            {
                _context.SaveChanges();
            }
            catch(System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }


        }
    }
}
