using Microsoft.AspNetCore.Builder;
using System.Security.Cryptography;
using TuyenDungTopIT.DataAccessLayer;
using TuyenDungTopIT.Models;

namespace TuyenDungTopIT.BusinessLogicLayer
{
    public class JobService
    {


        private readonly JobRepository _jobRepository;

        public JobService(JobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }

        public IEnumerable<Jobs> SearchJobs(string keywords)
        {
            if (string.IsNullOrWhiteSpace(keywords))
            {
                return new List<Jobs>();
            }
            return _jobRepository.SearchJobs(keywords);
        }

        // 1. Lấy danh sách tất cả công việc
        public IEnumerable <Jobs> GetAllJobs()
        {
            return _jobRepository.getAllJobs();
        }

        public void AddJob(Jobs job)
        {
            if (job == null) throw new ArgumentNullException(nameof(job));

            job.PostedAt = DateTime.Now; // Gán ngày hiện tại
            job.UpdatedAt = DateTime.Now; // Gán ngày hiện tại cho UpdatedAt
            _jobRepository.AddJob(job);
        }

        public Jobs GetJobById(int id)
        {
            return _jobRepository.GetJobById(id); // Gọi repository để lấy công việc theo ID
        }

        public void UpdateJob(Jobs job)
        {
            if (job == null) throw new ArgumentNullException(nameof(job));
            job.UpdatedAt = DateTime.Now;
            _jobRepository.UpdateJob(job); // Gọi repository để cập nhật công việc
        }


        public void DeleteJob(int id)
        {
            var job = _jobRepository.GetJobById(id);
            if (job == null) throw new ArgumentNullException(nameof(job));

            _jobRepository.DeleteJob(job); // Gọi repository để xóa công việc
        }


    }
}
