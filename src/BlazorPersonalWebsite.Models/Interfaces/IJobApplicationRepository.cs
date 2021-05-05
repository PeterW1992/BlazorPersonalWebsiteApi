using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorPersonalWebsite.Models.Interfaces
{
    public interface IJobApplicationRepository
    {
        public List<JobApplication> ListJobApplications();

        public JobApplication GetJobApplication(string uniqueRef);

        public JobApplication AddJobApplication(JobApplicationCreateModel jobApplicationCreateModel);

        public bool RemoveJobApplication(string uniqueRef);
    }
}
