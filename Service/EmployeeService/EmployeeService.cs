using Core.Abstraction.IEmployeeService;
using Core.ViewModel;
using Data;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.EmployeeService
{
    public class EmployeeService:IEmployeeService
    {
        private readonly EmployeeDbContext _dbContext;

        public EmployeeService(EmployeeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Employees?> GetAllEmployee(int EmployeeId)
        {
            var result = await _dbContext.Employees.FirstOrDefaultAsync(s => s.EmployeeID == EmployeeId);
            return result ?? null;           
        }

        public async Task<Employees> CreateEmployee(Employee employee)
        {
            var result = new Employees();
            if (employee != null)
            {
                result.Name = employee.Name;
                result.Status = employee.status;
                result.LockStatus = employee.lockstatus;
                result.Manager = employee.Manager;
                result.Wfm_Manager = employee.wfm_manager;
                result.Experience = employee.Experience;
                result.ProfileId = employee.profile_Id;
                result.Email = employee.Email;
                await _dbContext.Employees.AddAsync(result);
                await _dbContext.SaveChangesAsync();
                return result;
            }
            return result;
        }

        public async Task<Employees?> UpdateEmployee(Employee employee)
        {
            var result = await _dbContext.Employees.FirstOrDefaultAsync(s => s.EmployeeID == employee.Employee_Id);
            if (result != null)
            {
                result.Name = employee.Name;
                result.Status = employee.status;
                result.LockStatus = employee.lockstatus;
                result.Manager = employee.Manager;
                result.Wfm_Manager = employee.wfm_manager;
                result.Experience = employee.Experience;
                result.ProfileId = employee.profile_Id;
                result.Email = employee.Email;
                _dbContext.Employees.Update(result);
                await _dbContext.SaveChangesAsync();
                return result;
            }
            return new Employees();
        }

        public async Task<Employees?> DeleteEmployee(int EmployeeId)
        {
            var result = await _dbContext.Employees.FirstOrDefaultAsync(s => s.EmployeeID == EmployeeId);
            if(result !=null)
            {
                _dbContext.Employees.Remove(result);
                await _dbContext.SaveChangesAsync();
                return result;
            }
            return new Employees();
        }

        public List<Employees> GetEmployee()
        {
            var result = _dbContext.Employees.Include(s=> s.SkillMaps).ThenInclude(s =>s.Skills).ToList();
            return result;
        }
    }
}
