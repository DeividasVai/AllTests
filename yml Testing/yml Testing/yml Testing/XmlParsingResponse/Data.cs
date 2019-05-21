using System;
using System.Collections.Generic;
using System.Text;

namespace yml_Testing.XmlParsingResponse
{
    public class Data
    {
        public List<Employee> Employees { get; set; }

        public Data()
        {
            Employees = new List<Employee>
            {
                new Employee
                {
                    Id = "1",
                    Code = "DEVA",
                    Name = "Deividas"
                },
                new Employee
                {
                    Id = "2",
                    Code = "ILMA",
                    Name = "Ilja"
                },
                new Employee
                {
                    Id = "3",
                    Code = "ADY",
                    Name = "Ala"
                }
            };
        }

        public Employee GetEmployee(int id)
        {
            foreach (Employee employee in Employees)
            {
                if (employee.Id == id.ToString())
                    return employee;
            }

            return null;
        }

        public Employee GetEmployee(string id)
        {
            foreach (Employee employee in Employees)
            {
                if (employee.Id == id)
                    return employee;
            }

            return null;
        }
    }
}
