using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineExamSystem.Services.Interfaces;

namespace OnlineExamSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionImportController : ControllerBase
    {
        private readonly IExcelImportService _excelImportService;
        public QuestionImportController(IExcelImportService excelImportService)
        {
            _excelImportService = excelImportService;
        }
        [HttpPost("upload")]
        public async Task<IActionResult> Upload(IFormFile file,int exanId)
        {
            var result=await _excelImportService.ImportQuestions(file,exanId);
            return Ok(result);
        }


    }
}
