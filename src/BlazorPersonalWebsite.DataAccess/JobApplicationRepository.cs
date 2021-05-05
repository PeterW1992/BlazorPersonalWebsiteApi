using BlazorPersonalWebsite.Models;
using BlazorPersonalWebsite.Models.Interfaces;
using System;
using System.Collections.Generic;

namespace BlazorPersonalWebsite.DataAccess
{
    public class JobApplicationRepository : IJobApplicationRepository
    {
        List<JobApplication> _jobApplications = new List<JobApplication>();

        public JobApplication AddJobApplication(JobApplicationCreateModel jobApplicationCreateModel)
        {
            int jobId = _jobApplications.Count + 1;

            _jobApplications.Add(
                new JobApplication
                {
                    Id = jobId,
                    JobApplicationRef = jobId.ToString(),
                    DateApplied = jobApplicationCreateModel.AppliedDateTime,
                    Description = jobApplicationCreateModel.Description,
                    Title = jobApplicationCreateModel.Title
                });

            return _jobApplications.Find(j => j.Id == jobId);
        }

        public JobApplication GetJobApplication(string uniqueRef)
        {
            throw new NotImplementedException();
        }

        public List<JobApplication> ListJobApplications()
        {
            return _jobApplications;
        }

        public bool RemoveJobApplication(string jobApplicationRef)
        {
            JobApplication jobApplication = _jobApplications.Find(j => j.JobApplicationRef == jobApplicationRef);

            if (jobApplication != null)
            {
                _jobApplications.Remove(jobApplication);
                return true;
            }

            return false;
        }
    }
}
