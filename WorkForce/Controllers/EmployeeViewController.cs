//using Core.ViewModel;
//using Data;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;

//namespace WorkForce.Controllers
//{
//    public class EmployeeViewControllers : Controller
//    {
//        private readonly EmployeeDbContext _dbContext;

//        public EmployeeViewControllers(EmployeeDbContext dbContext)
//        {
//            _dbContext = dbContext;

//        }
//        public IActionResult Index()
//        {
//            var employees = _dbContext.Employees.Include(s => s.SkillMaps).ThenInclude(s => s.Skills).Select(x => new Employee
//            {
//                Employee_Id = x.EmployeeID,
//                Email = x.Email,
//                Name = x.Name,
//                Manager = x.Manager,
//                wfm_manager = x.Wfm_Manager,
//                Skills = x.SkillMaps.Select(y => y.Skills.Name).ToList()
//            }).ToList();

//            return View(employees);
//        }
//    }
//}
