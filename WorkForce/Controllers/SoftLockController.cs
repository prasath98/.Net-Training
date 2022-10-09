using Microsoft.AspNetCore.Mvc;
using Service.SoftLockService;
using Entities;
using Core.ViewModel;
using Core.Abstraction.ISoftLockService;

namespace WorkForce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SoftLockController : Controller
    {
        private readonly ISoftLockService _softLockService;

        public SoftLockController(ISoftLockService softLockService)
        {
            _softLockService = softLockService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SoftLock))]
        public async Task<IActionResult> GetSoftLock()
        {
            var result = await _softLockService.GetSoftLock();
            if (result != null)
                return new OkObjectResult(result);
            else
                return new NoContentResult();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SoftLock))]
        public async Task<IActionResult> CreateSoftLock(SoftLockDto softLock)
        {
            await _softLockService.CreateSoftLock(softLock);
            return new OkObjectResult(softLock);
        }

        [HttpPut, Route("UpdateSoftLock")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SoftLock))]
        public async Task<IActionResult> UpdateSoftLock(SoftLockDto softLock)
        {
            var result = await _softLockService.UpdateSoftLock(softLock);
            return new OkObjectResult(result);
        }

        [HttpPut, Route("DeleteSoftLock")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SoftLock))]
        public async Task<IActionResult> DeleteSoftLock(int LockId)
        {
            var result = await _softLockService.DeleteSoftLock(LockId);
            return new OkObjectResult(result);
        }
    }
}
