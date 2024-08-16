using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Utilities.Core.UtilityDomain.Entities.RedisCache;
using Utilities.Infrastructure.UtilityInfrastructure.Services.RedisCache.InterFaces;

namespace HR.Api.Controllers.RedisCache
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class CacheController : ControllerBase
    {
        private readonly IRedisCacheService _redisCacheService;

        public CacheController(IRedisCacheService redisCacheService)
        {
            _redisCacheService = redisCacheService;
        }

        [HttpGet("[action]/{key}")]
        public async Task<IActionResult> Get([FromRoute] string key)
        {
            return Ok(await _redisCacheService.GetValueAsync(key));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Set([FromBody] RedisCacheRequestModel redisCacheRequestModel)
        {
            string jsonObj = JsonConvert.SerializeObject(redisCacheRequestModel);
            await _redisCacheService.SetValueAsync(redisCacheRequestModel.Key, jsonObj, new TimeSpan(0, 10, 0));

            //await _redisCacheService.SetStringAsync(redisCacheRequestModel.Key, redisCacheRequestModel.Value);
            return Ok();
        }

        [HttpDelete("[action]/{key}")]
        public async Task<IActionResult> Delete(string key)
        {
            await _redisCacheService.Clear(key);
            return Ok();
        }
    }
}
