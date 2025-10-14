using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_DemoOOP.Demographics
{
    internal class Employee: Person
    {
        public int DeptNo { get; set; }
        public int EmployeeNo { get; set; }
        public double Salary { get; set; }

        public Employee(int id, string name, DateOnly dateOfBirth, int deptNo, int employeeNo, double salary): base(id, name, dateOfBirth)
        {
            DeptNo= deptNo;
            EmployeeNo= employeeNo;
            Salary= salary;
        }

        public override string GetData()
        {
            return $"{base.GetData()}, Employee #: {EmployeeNo}, Department #: {DeptNo}, Salary: {Salary}";
        }
    }
}
