using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingAcademy.DAL;

namespace TrainingAcademy.BL.Abstract
{
    public interface ICourse
    {
        void AddCourse(Course entity );
        IEnumerable<Course> GetCourses();
        Course GetCoursebyid(int id);
        void RemoveCourse(int id);
        Course EditCourse(int id);
        void Comit();
    }
}
