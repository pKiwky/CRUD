using Application.Dto;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Common {

    [ApiController]
    [Route("api/[controller]")]
    public class APIController : ControllerBase {
        protected IActionResult Handle<T>(KernelControllerResponse<T> kernelControllerResponse) where T : class {
            if (kernelControllerResponse == null) {
                return NoContent();
            }

            if (kernelControllerResponse.Errors != null) {
                return BadRequest(kernelControllerResponse);
            }

            return Ok(kernelControllerResponse);
        }
    }

}