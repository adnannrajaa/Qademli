using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Qademli.Models.DatabaseModel
{
    public class CallSchedule
    {
        [Key]
        public int CallId { get; set; }
        public int UserId { get; set; }
        public string Mobile { get; set; }
        public DateTime CallDate { get; set; }
        public int Status { get; set; }

    }
}
