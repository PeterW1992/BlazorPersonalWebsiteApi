using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorPersonalWebsite.Models
{
    public class WoodworkProjectCreateModel
    {
        public string ProjectRef { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime DateCreated { get; set; }

        public List<WoodworkProjectImageUpdateModel> Images { get; set; }
    }
}
