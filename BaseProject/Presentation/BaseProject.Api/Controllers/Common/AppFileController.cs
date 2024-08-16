using Microsoft.AspNetCore.Mvc;

namespace BaseProject.Api.Controllers.Common
{
    [Route("api/[controller]")]
    [ApiController]
   
    //[Authorize(AuthenticationSchemes = "Admin")]
    public class AppFileController : ControllerBase
    {
        readonly IConfiguration _configuration;

        public AppFileController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetBaseStorageUrl()
        {
            var storageUrl = new
            {
                Url = _configuration["Storage:BaseStorageUrl"]
            };

            return Ok(storageUrl);
        }
    }
}
