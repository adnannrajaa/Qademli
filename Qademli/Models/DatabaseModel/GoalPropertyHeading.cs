using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Qademli.Models.DatabaseModel
{
    public class GoalPropertyHeading
    {
        [Key]
        public int HeadingId { get; set; }
        public int GoalPropId { get; set; }
        public string Name { get; set; }
    }
}
