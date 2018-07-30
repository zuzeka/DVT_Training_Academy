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
   public class ConcreteCourse:ICourse
    {
        DVTEntities _context;
        public ConcreteCourse (DVTEntities Context)
        {
            _context = Context;
        }
        //Get List
        public IEnumerable<Course> GetCourses()
        {
            return _context.Courses.ToList();
        }
       //Add
        public void AddOrUpdateCourse(Course course)
        {
            if (course.CourseID == default(int))
            {
                _context.Courses.Add(course);
            }
            else
            {
                //exisitng entity update
                _context.Entry(course).State = EntityState.Modified;
            }
        }
       
        //Delete
        public void RemoveCourse(int id)
        {
            var course = _context.Courses.Find(id);
            _context.Courses.Remove(course);
        }
        public Course GetCoursebyid(int? id)
        {
            Course entity = _context.Courses.FirstOrDefault(x => x.CourseID == id);

            if (entity != null)
                _context.Courses.Find(entity);
            else
                throw new Exception("Course not found");
            return entity;

        }
        //Save to db
        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
