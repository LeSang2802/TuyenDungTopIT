using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TuyenDungTopIT.BusinessLogicLayer;
using TuyenDungTopIT.Models;
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

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Jobs job)
        {
            if (ModelState.IsValid)
            {
                _jobservice.AddJob(job); // Gọi JobService để thêm công việc
                return RedirectToAction("Index"); // Chuyển hướng về trang danh sách công việc
            }

            return View(job); // Nếu dữ liệu không hợp lệ, hiển thị lại form với lỗi
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var job = _jobservice.GetJobById(id); // Gọi service để lấy công việc theo ID
            if (job == null)
            {
                return NotFound(); // Trả về lỗi nếu không tìm thấy công việc
            }
            return View(job); // Hiển thị công việc trong form sửa
        }

        [HttpPost]
        public IActionResult Edit(Jobs job)
        {
            if (ModelState.IsValid)
            {
                _jobservice.UpdateJob(job); // Gọi service để cập nhật công việc
                return RedirectToAction("Index"); // Chuyển hướng về danh sách công việc
            }
            return View(job); // Nếu dữ liệu không hợp lệ, hiển thị lại form với lỗi
        }



        [HttpGet]
        public IActionResult Delete(int id)
        {
            var job = _jobservice.GetJobById(id); // Gọi service để lấy công việc theo ID
            if (job == null)
            {
                return NotFound(); // Trả về lỗi nếu không tìm thấy công việc
            }
            return View(job); // Hiển thị thông tin công việc trong form xác nhận xóa
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _jobservice.DeleteJob(id); // Gọi service để xóa công việc
            return RedirectToAction("Index"); // Chuyển hướng về danh sách công việc
        }


    }
}
