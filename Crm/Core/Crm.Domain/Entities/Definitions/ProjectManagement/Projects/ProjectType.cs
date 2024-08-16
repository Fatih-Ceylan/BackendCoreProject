using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Core.UtilityDomain.Entities;

namespace GCrm.Domain.Entities.Definitions.ProjectManagement.Projects
{
    public  class ProjectType : BaseEntity
    {
        public string  Name { get; set; } //proje tipi adı

        public ICollection<Project>  Projects { get; set; }
    }
}
