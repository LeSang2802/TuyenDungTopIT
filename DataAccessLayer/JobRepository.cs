using Microsoft.AspNetCore.Builder;
using System.ComponentModel.DataAnnotations;
using TuyenDungTopIT.Database;
using TuyenDungTopIT.Models;

namespace TuyenDungTopIT.DataAccessLayer
{
    public class JobRepository
    {
        private readonly ApplicationDbContext _context;

        public JobRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Phương thức tìm kiếm công việc
        public IEnumerable<Jobs> SearchJobs(string keywords)
        {
            

            return _context.Jobs
                           .Where(job => job.Title.Contains(keywords) ||
                                         job.Description.Contains(keywords))
                           .ToList();
        }

        public IEnumerable <Jobs> getAllJobs()
        {


            return _context.Jobs.ToList();
        }

        public void AddJob(Jobs job)
        {
            _context.Jobs.Add(job);
            _context.SaveChanges();
        }


        public Jobs GetJobById(int id)
        {
            return _context.Jobs.FirstOrDefault(j => j.JobId == id); // Lấy công việc theo ID
        }

        public void UpdateJob(Jobs job)
        {
            var existingJob = _context.Jobs.FirstOrDefault(j => j.JobId == job.JobId);
            if (existingJob != null)
            {
                existingJob.Title = job.Title;
                existingJob.Description = job.Description;
                existingJob.CompanyName = job.CompanyName;
                existingJob.Location = job.Location;
                existingJob.Salary = job.Salary;

                _context.Jobs.Update(existingJob); // Cập nhật công việc
                _context.SaveChanges(); // Lưu thay đổi vào DB
            }
        }


        public void DeleteJob(Jobs job)
        {
            _context.Jobs.Remove(job); // Xóa công việc khỏi DbSet
            _context.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu
        }



    }
}
