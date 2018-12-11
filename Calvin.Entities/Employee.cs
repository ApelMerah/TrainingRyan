using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Calvin.Entities
{
    public partial class Employee
    {
        public Guid EmployeeID { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public Guid DivisionID { get; set; }

        [ForeignKey("DivisionID")]
        [InverseProperty("Employee")]
        public virtual Division Division { get; set; }
    }
}
