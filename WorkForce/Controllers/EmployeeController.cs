using Core.Abstraction.IEmployeeService;
using Core.ViewModel;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace WorkForce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService  employeeService)
        {
            _employeeService = employeeService;
        }


        [HttpGet,Route("GetEmployee")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Employees))]
        public IActionResult GetEmployee()
        {
            var result = _employeeService.GetEmployee();
            if (result != null)
                return new OkObjectResult(result);
            else
                return new NoContentResult();
        }

        [HttpGet, Route("GetAllEmployee")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Employees))]
        public async Task<IActionResult> GetAllEmployee(int employeeId)
        {
            var result = await _employeeService.GetAllEmployee(employeeId);
            if (result != null)
                return new OkObjectResult(result);
            else
                return new NoContentResult();
        }

        [HttpPost, Route("CreateEmployee")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Employees))]
        public async Task<IActionResult> CreateEmployee(Employee employee)
        {
            await _employeeService.CreateEmployee(employee);
            return new OkObjectResult(employee);
        }

        [HttpPut, Route("UpdateEmployee")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Employees))]
        public async Task<IActionResult> UpdateEmployee(Employee employee)
        {
           var result = await _employeeService.UpdateEmployee(employee);
            return new OkObjectResult(result);
        }

        [HttpDelete, Route("DeleteEmployee")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Employees))]
        public async Task<IActionResult> DeleteEmployee(int EmployeeId)
        {
            var result = await _employeeService.DeleteEmployee(EmployeeId);
            return new OkObjectResult(result);
        }
    }
}
