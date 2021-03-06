using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterviewRESTfulEndPoint.Models;
using Microsoft.Extensions.Logging;

namespace InterviewRESTfulEndPoint.Services
{
    public interface IInterviewRepositoryService
    {
        public void AddAnInterview(Interview interview);

        public Interview GetInterview(int id);

        public void DeleteAllInterviews();
        public void DeleteInterview(int id);
        public void UpdateInterview(Interview interview);

        public List<Interview> GetRange(int start,int count);
    }

    public class InterviewRepositoryService : IInterviewRepositoryService
    {
        private List<Interview> localRepository;
        private readonly ILogger<InterviewRepositoryService> _logger;
        // inject database for user validation
        public InterviewRepositoryService(ILogger<InterviewRepositoryService> logger)
        {
            _logger = logger;
            localRepository = new List<Interview>();
        }

        public void AddAnInterview(Interview interview)
        {
            localRepository.Add(interview);
        }

        public void DeleteAllInterviews()
        {
            localRepository.Clear();
        }

        public Interview GetInterview(int id)
        {
            return localRepository.Where(e => e.ID == id).OrderBy(e => e.ID).FirstOrDefault();
        }

        public List<Interview> GetRange(int start,int count)
        {
            return localRepository.Skip(start).Take(count).ToList();
        }

        public void DeleteInterview(int id)
        {
            var tmp = localRepository.Where(e => e.ID != id).ToList();
            localRepository.Clear();
            foreach(var i in tmp)
            {
                localRepository.Add(i);
            }
        }

        public void UpdateInterview(Interview interview)
        {
            // first delete the interview with the corresponding id
            var tmp = localRepository.Where(e => e.ID != interview.ID).ToList();
            localRepository.Clear();
            foreach (var i in tmp)
            {
                localRepository.Add(i);
            }
            localRepository.Add(interview);
        }
    }
}

