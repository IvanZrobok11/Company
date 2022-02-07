using System.Collections.Generic;

namespace Infrastructure.Models
{
    public class Department
    {
        public Department()
        {
            Emploees = new List<Employee>();
        }
        public IEnumerable<Employee> Emploees { get; set; }
        public string Location { get; set; }

        public Company Company { get; set; }
        public string CompanyId { get; set; }

        public int Id { get; set; }
        public int DNumber { get; set; }
    }
}