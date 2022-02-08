using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Infrastructure.Enums;

namespace Infrastructure.Models
{
    public class Project
    {
        public Project()
        {
            Employees = new List<Employee>();
        }
        public IEnumerable<Employee> Employees { get; set; }
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }

        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string ProjectName { get; set; }
        public double? Cost { get; set; }
        public ProjectState State { get; set; }
    }
}
