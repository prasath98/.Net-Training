using Core.ViewModel;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Abstraction.IEmployeeService
{
    public interface IEmployeeService
    {
        Task<Employees?> GetAllEmployee(int EmployeeId);
        Task<Employees> CreateEmployee(Employee employee);
        Task<Employees?> UpdateEmployee(Employee employee);
        Task<Employees?> DeleteEmployee(int EmployeeId);
    }
}
