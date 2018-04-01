using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using InfoPole.Core.Entities;
using InfoPole.Core.Models;
using InfoPole.Core.Services;
using InfoPole.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InfoPole.Controllers
{
    [Produces("application/json")]
    [Route("MarkupTag")]
    public class MarkupTagsController : Controller
    {
        private FileProcessingService _fpSvc;
        private IServerCacheService _cache;
        private IMarkupTagsFileParser _markupTagsParser;

        public MarkupTagsController(
                FileProcessingService fileProcService,
                IServerCacheService cache,
                IMarkupTagsFileParser markupTagsFileParser
            )
        {
            this._fpSvc = fileProcService;
            this._cache = cache;
            this._markupTagsParser = markupTagsFileParser;
        }

        [HttpPost("file")]
        [DisableRequestSizeLimit]
        public async Task<IActionResult> File()
        {
            var files = Request.Form.Files;
            var result = new OperationResult();

            foreach (var file in files)
            {
                var path = Path.GetTempPath() + file.FileName;
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
                var fileStream = new FileStream(path, FileMode.CreateNew);
                try
                {
                    await file.CopyToAsync(fileStream);
                    fileStream.Close();

                    result = this._fpSvc.ProcessMarkupTagsFile(path, this._markupTagsParser);
                }
                catch (Exception exp)
                {
                    fileStream.Close();
                    return StatusCode(500, exp.Message);
                }
            }

            return Ok(result);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var markupTags = this._cache.GetList<MarkupTag>();
            return Ok(markupTags);
        }

        [HttpGet("id")]
        public IActionResult Get(long id)
        {

            return Ok();
        }

    }
}
