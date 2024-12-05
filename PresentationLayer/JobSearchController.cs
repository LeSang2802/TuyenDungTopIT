using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TuyenDungTopIT.BusinessLogicLayer;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace TuyenDungTopIT.PresentationLayer
{
    public class JobSearchController : Controller
    {
        private readonly JobService _jobservice;

        public JobSearchController(JobService jobservice)
        {
            _jobservice = jobservice;
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}

        public IActionResult Index()
        {
            var jobs = _jobservice.GetAllJobs(); // Gọi hàm để lấy danh sách công việc
            return View(jobs); // Truyền dữ liệu đã lấy vào view
        }



        public IActionResult searchJobs(string keywords)
        {
            string a = keywords;
            return View("Index", _jobservice.SearchJobs(keywords)) ; 
        }
    }
}
