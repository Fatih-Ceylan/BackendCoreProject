using Microsoft.AspNetCore.Mvc;
using Utilities.Infrastructure.UtilityInfrastructure.Services.Excel;

namespace GCrm.Api.Controllers.Definitions
{
    [Route("api/[controller]")]
    [ApiController]
   
    //[Authorize(AuthenticationSchemes = "Admin")]
    public class CustomerExcelController : ControllerBase
    {
        readonly ExcelService _excelService;

        public CustomerExcelController(ExcelService  excelService)
        {
            _excelService = excelService;
        }


        //[HttpPost]
        //public async Task<IActionResult> UploadExcel(IFormFile file)
        //{
            
        //    var filePath = ""; // Dosya yolunu almak için gerekli kodu buraya ekleyin

        //    // Excel dosyasını içeri aktar
        //    var result = await _excelService.ImportExcel(filePath);

        //    // İşlem sonucuna göre yanıt döndür
        //    if (result.Success)
        //    {
        //        return Ok(result.Message);
        //    }
        //    else
        //    {
        //        return BadRequest(result.Message);
        //    }
        //}

    }
}
