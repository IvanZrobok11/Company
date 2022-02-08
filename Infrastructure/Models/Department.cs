using System.Collections.Generic;

namespace Infrastructure.Models
{
    public class Department
    {
        public Department()
        {
            Employees = new List<Employee>();
        }
        public IEnumerable<Employee> Employees { get; set; }
        public string Address { get; set; }

        public Company Company { get; set; }
        public string CompanyId { get; set; }

        public int DNumber { get; set; }
    }
}