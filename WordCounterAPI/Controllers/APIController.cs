using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WordCounterAPI.Classes;
using WordCounterAPI.Interfaces;
using static System.Net.WebRequestMethods;

namespace WordCounterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIController : ControllerBase
    {
        private readonly IWordCountService _wordCountService;
        public APIController(IWordCountService wordCountService)
        {
            _wordCountService = wordCountService;
        }

        [HttpPost("/api/wordcount")]
        public async Task<IActionResult> Wordcount(IFormFile textDocument)
        {
            if (textDocument == null || textDocument.Length == 0) return BadRequest("File is empty");
            if (Path.GetExtension(textDocument.FileName).ToUpper() != ".TXT") return BadRequest("Invalid file format, only '.txt' files are accepted.");

            string fileContent;
            using(StreamReader reader = new StreamReader(textDocument.OpenReadStream()))
            {
                fileContent = await reader.ReadToEndAsync();
            }

            var result = _wordCountService.CountWords(fileContent);
            return Ok(result);
        }
    }
}