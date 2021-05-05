using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorPersonalWebsite.Models
{
    public class SoftwareProjectImage
    {
        public int SoftwareProjectImageId { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }

        public int SoftwareProjectId { get; set; }

        public SoftwareProject SoftwareProject { get; set; }
    }
}
