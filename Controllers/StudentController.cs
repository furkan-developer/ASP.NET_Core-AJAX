using System.Text.Json;
using AJAX.Models;
using Microsoft.AspNetCore.Mvc;

namespace AJAX.Controllers
{
    [Route("[controller]")]
    public class StudentController : Controller
    {
        public static List<StudentModel> _students = new List<StudentModel>();
        public StudentController(List<StudentModel> students)
        {
            _students = students;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_students);
        }

        [HttpGet("GetDetailsById/{id}")]
        public JsonResult GetDetailsById([FromRoute]int id)
        {
            var student = _students.Where(d => d.Id.Equals(id)).FirstOrDefault();
            JsonResponseViewModel model = new JsonResponseViewModel();
            if (student != null)
            {
                model.ResponseCode = 0;
                model.ResponseMessage = JsonSerializer.Serialize(student);
            }
            else
            {
                model.ResponseCode = 1;
                model.ResponseMessage = "No record available";
            }
            return Json(model);
        }

        [HttpPost("InsertStudent")]
        public JsonResult InsertStudent(IFormCollection formcollection)
        {
            StudentModel student = new StudentModel();
            student.Email = formcollection["email"];
            student.Name = formcollection["name"];
            JsonResponseViewModel model = new JsonResponseViewModel();
            //MAKE DB CALL and handle the response
            if (student != null)
            {
                model.ResponseCode = 0;
                model.ResponseMessage = JsonSerializer.Serialize(student);
            }
            else
            {
                model.ResponseCode = 1;
                model.ResponseMessage = "No record available";
            }
            return Json(model);
        }
        
        [HttpPut("UpdateStudent")]
        public JsonResult UpdateStudent(IFormCollection formcollection)
        {
            StudentModel student = new StudentModel();
            student.Id = int.Parse(formcollection["id"]);
            student.Email = formcollection["email"];
            student.Name = formcollection["name"];
            JsonResponseViewModel model = new JsonResponseViewModel();
            //MAKE DB CALL and handle the response
            if (student != null)
            {
                model.ResponseCode = 0;
                model.ResponseMessage = JsonSerializer.Serialize(student);
            }
            else
            {
                model.ResponseCode = 1;
                model.ResponseMessage = "No record available";
            }
            return Json(model);
        }

        [HttpDelete("DeleteStudent")]
        public JsonResult DeleteStudent(IFormCollection formcollection)
        {
            StudentModel student = new StudentModel();
            student.Id = int.Parse(formcollection["id"]);
            JsonResponseViewModel model = new JsonResponseViewModel();
            //MAKE DB CALL and handle the response
            if (student != null)
            {
                model.ResponseCode = 0;
                model.ResponseMessage = JsonSerializer.Serialize(student);
            }
            else
            {
                model.ResponseCode = 1;
                model.ResponseMessage = "No record available";
            }
            return Json(model);
        }
    }
}