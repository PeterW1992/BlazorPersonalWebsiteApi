using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorPersonalWebsite.Models
{
    public class SoftwareProjectUpdateModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime DateCreated { get; set; }

        public List<SoftwareProjectImageUpdateModel> Images { get; set; }
    }
}
