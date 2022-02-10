using System.Collections.Generic;

namespace Infrastructure.Models
{
    public class Customer
    {
        public Customer()
        {
            Projects = new List<Project>();
        }
        public int Id { get; set; }
        public string FullName { get; set; }

        public string CompanyId { get; set; }
        public Company Company { get; set; }

        public IEnumerable<Project> Projects { get; set; }
    }
}
