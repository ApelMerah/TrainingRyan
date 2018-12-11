using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Calvin.Entities
{
    public partial class Division
    {
        public Division()
        {
            Employee = new HashSet<Employee>();
        }

        public Guid DivisionID { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [InverseProperty("Division")]
        public virtual ICollection<Employee> Employee { get; set; }
    }
}
