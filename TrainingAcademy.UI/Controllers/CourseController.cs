using System.Web.Mvc;
using TrainingAcademy.WebAPI.Helper;
using System.Threading.Tasks;
using TrainingAcademy.UI.Models;
using System.Collections.Generic;

namespace TrainingAcademy.UI.Controllers
{
    public class CourseController : Controller
    {
        // GET: Course
        public async Task<ActionResult> Index()
        {
            var APIHelper = new APIHelper<List<DTOJson>>();
            var result = await APIHelper.GetCourses("api/Courses/GetCourses");
            return View(result);
        }



    }
}