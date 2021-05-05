using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorPersonalWebsite.Models
{
    public class JobApplication
    {
        public int Id { get; set; }

        public string JobApplicationRef { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime DateApplied { get; set; }

        public JobApplicationOutcome Outcome { get; set; }
    }
}
