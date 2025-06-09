using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UploadExcel.PublicClasses;

namespace UploadExcel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadExcelController : ControllerBase
    {
        [HttpPost("upload")]
        public IActionResult UploadFile(IFormFile file)
        {
            return Ok(new UploadHandler().Upload(file));
        }
    }
}
