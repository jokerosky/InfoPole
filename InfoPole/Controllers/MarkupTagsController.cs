using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InfoPole.Controllers
{
    [Produces("application/json")]
    [Route("MarkupTag")]
    public class MarkupTagsController : Controller
    {
        [HttpPost("file")]
        [DisableRequestSizeLimit]
        public async Task<IActionResult> File()
        {
            var files = Request.Form.Files;
            var fnum = files.Count;
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



                }
                catch (Exception exp)
                {
                    fileStream.Close();
                    return StatusCode(500, exp.Message);
                }
            }


            return Ok(fnum);
        }
    }
}
