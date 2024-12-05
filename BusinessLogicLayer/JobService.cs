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

        // 2. Đăng một công việc mới
        public void PostJob(Jobs jobDetails)
        {
        }


        // 4. Cập nhật thông tin công việc
        public void UpdateJob(int jobId, Jobs jobDetails)
        {
        }

        // 5. Xóa công việc
        public void DeleteJob(int jobId)
        {
        }

        
    }
}
