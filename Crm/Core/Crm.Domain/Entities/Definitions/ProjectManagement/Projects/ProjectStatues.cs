using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Utilities.Core.UtilityDomain.Entities;

namespace GCrm.Domain.Entities.Definitions.ProjectManagement.Projects
{
    public  class ProjectStatues : BaseEntity
    {
        public string  Name { get; set; }
        public ICollection<Project>  Projects { get; set; }
    }
}
