using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Models
{
    public class Company
    {
        public Company()
        {
            Departments = new List<Department>();
            Customers = new List<Customer>();
        }
        public IEnumerable<Department> Departments { get; set; }
        public IEnumerable<Customer> Customers { get; set; }
        public string OUI { get; set; } // Key  (Organizationally Unique Identifier)

        [Required]
        [MaxLength(50)]
        public string CName { get; set; }
    }
}
