using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Domain.Entity
{
    public class PersonalAnalystDetail
    {
        public Guid? PersonalAnalystId { get; set; }
        [ForeignKey("PersonalAnalystId")]
        public PersonalAnalyst? PersonalAnalyst { get; set; }
        public Guid? SkinId { get; set; }
        [ForeignKey("SkinTypeId")]
        public Skin? Skins { get; set; }
    }
}
