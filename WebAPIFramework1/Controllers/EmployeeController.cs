using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebAPIFramework1.Models;

namespace WebAPIFramework1.Controllers
{
    public class EmployeeController : ApiController
    {
        TestDBEntities testDBEntities = new TestDBEntities();

        public List<Employee> GetEmployees()
        {
            return testDBEntities.Employees.ToList();
        }

        public Employee GetEmployeeByID(int id)
        {
            return testDBEntities.Employees.Find(id);
        }

        [HttpPost]
        public string SaveEmployee([FromBody] Employee employee)
        {
            testDBEntities.Employees.Add(employee);
            testDBEntities.SaveChanges();
            return "The Employee is created";
        }

        [HttpPut]
        public string UpdateEmployee([FromBody] Employee employee)
        {
            Employee emp = testDBEntities.Employees.Find(employee.ID);
            emp.Name = employee.Name;
            emp.Age = employee.Age;
            emp.Qualification = employee.Qualification;
            testDBEntities.SaveChanges();
            return "The Employee is Updated";
        }

        [HttpDelete]
        public string DeleteEmployee(int Id)
        {
            Employee emp = testDBEntities.Employees.Find(Id);
            if (emp != null)
            {
                testDBEntities.Employees.Remove(emp);
                testDBEntities.SaveChanges();
                return $"The Employee with id = {Id.ToString()} was removed";
            }
            else
            {
                return $"The Employee with id = {Id.ToString()} does not exist";
            }
        }
    }
}
