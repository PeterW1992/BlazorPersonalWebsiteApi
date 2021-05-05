using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorPersonalWebsite.Models
{
    public class JobApplicationCreateModel
    {
        public string JobApplicationRef { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime AppliedDateTime { get; set; }
    }
}
