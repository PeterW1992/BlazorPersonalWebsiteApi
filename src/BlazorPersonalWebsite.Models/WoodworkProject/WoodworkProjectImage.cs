using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorPersonalWebsite.Models
{
    public class WoodworkProjectImage
    {

        public int WoodworkProjectImageId { get; set; }
        public string ImageUrl { get; set; }

        public string Description { get; set; }

        public int WoodworkProjectId { get; set; }

        public WoodworkProject WoodworkProject { get; set; }
    }
}
