using System;
using Infrastructure.Enums;

namespace Infrastructure.Models
{
    public class Employee : People
    {
        public decimal? Salary { get; set; }
        public Position? Position { get; set; }
        public TimeSpan? Experience { get; set; }

        public Project CurrentProject { get; set; }
        public int? ProjectId { get; set; }

        public  Department Department { get; set; }
        public  int DepartmentNumber { get; set; }
        public string DepartmentAddress { get; set; }
    }
}
