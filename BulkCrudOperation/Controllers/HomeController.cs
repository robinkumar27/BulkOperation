using BulkCrudOperation.Common;
using BulkCrudOperation.IService;
using BulkCrudOperation.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BulkCrudOperation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        IStudentService _IStudentService = null;
        private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, IConfiguration Configuration, IStudentService IStudentService)
        {
            _logger = logger;
            _configuration = Configuration;
            _IStudentService= IStudentService;
        }

        public IActionResult Index()
        {
            string ? constr = _configuration.GetConnectionString("DefaultConnection");
            Global.ConnectionString = constr;
            BulkSave();
            return View();
        }
        private void BulkSave()
        { 
            List<Student> oStudents = new List<Student>();
            int intTotalStudent = 100;
            for (int i = 1; i <= intTotalStudent; i++)
            {
                oStudents.Add( new Student()
                {
                   StudentId = i,
                   Name = "sTUDENT_" + i.ToString(),
                    Roll = "Roll_" +i.ToString(),
                });
            }
            string message = _IStudentService.BulkSave(oStudents);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}