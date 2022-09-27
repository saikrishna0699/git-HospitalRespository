using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Models
{
    public class HospitalModel
    {
        [Key]
        public int Id { get; set; }
        public string HospitalName { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public string Specailist { get; set; }

    }
}
