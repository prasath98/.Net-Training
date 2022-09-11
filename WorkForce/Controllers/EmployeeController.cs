using Core.Abstraction.IEmployeeService;
using Core.ViewModel;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace WorkForce.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService  employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Employees))]
        public async Task<IActionResult> GetAllEmployee(int employeeId)
        {
            var result = await _employeeService.GetAllEmployee(employeeId);
            if (result != null)
                return new OkObjectResult(result);
            else
                return new NoContentResult();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Employees))]
        public async Task<IActionResult> CreateEmployee(Employee employee)
        {
            await _employeeService.CreateEmployee(employee);
            return new OkObjectResult(employee);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Employees))]
        public async Task<IActionResult> UpdateEmployee(Employee employee)
        {
           var result = await _employeeService.UpdateEmployee(employee);
            return new OkObjectResult(result);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Employees))]
        public async Task<IActionResult> DeleteEmployee(int EmployeeId)
        {
            var result = await _employeeService.DeleteEmployee(EmployeeId);
            return new OkObjectResult(result);
        }
    }
}
