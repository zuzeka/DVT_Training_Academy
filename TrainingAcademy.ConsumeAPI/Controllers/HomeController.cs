using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TrainingAcademy.ConsumeAPI.Helper;
using TrainingAcademy.ConsumeAPI.Models;

namespace TrainingAcademy.ConsumeAPI.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var APIHelper = new APIHelper<List<DTOJson>>();
            var result = await APIHelper.GetCourses("api/Courses/GetCourses");
            return View(result);
        }
        [HttpPost]
        public async Task<ActionResult> AddCourse(DTOJson dTO)
        {
            var apiHelper = new APIHelper<DTOJson>();
            var result = await apiHelper.ClientPostRequest("api/Courses/AddCourse", dTO);
            return View(result);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateCourse(int id, DTOJson dTO)
        {
            var apiHelper = new APIHelper<DTOJson>();
            var result = await apiHelper.ClientPutRequest("api/Courses/UpdateCourse",dTO);
            return View(result);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteCourse(string RequestURDTOJson, DTOJson dTO)
        {
            var apiHelper = new APIHelper<DTOJson>();
            var result = await apiHelper.ClientDeleteRequest("api/Courses/DeleteCourse");

            return View(result);
        }
    }
}
