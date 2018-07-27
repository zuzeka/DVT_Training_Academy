using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingAcademy.BL.Abstract;
using TrainingAcademy.DAL;

namespace TrainingAcademy.BL.Concrete
{
   public class CourseRepository : ICourse
    {
        DVTEntities _context;
        public CourseRepository(DVTEntities Context)
        {
            _context = Context;
        }
        public void AddCourse(Course entity)
        {
            _context.Courses.Add(entity);
        }

        public Course EditCourse(int id)
        {
            return _context.Courses.Find(id);
        }

        public IEnumerable<Course> GetCourses()
        {
            return _context.Courses.ToList();
        }
       

        public void RemoveCourse(int id)
        {
            Course entity = EditCourse(id);
            _context.Courses.Remove(entity);
        }
        public void Comit()
        {
            _context.SaveChanges();
        }

        public Course GetCoursebyid(int id)
        {
          return  _context.Courses.Find(id);
        }
    }
}
