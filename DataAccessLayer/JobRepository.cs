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


    }
}
