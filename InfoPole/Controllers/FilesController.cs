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
    [Route("files")]
    public class FilesController : Controller
    {
        private IList<DataFile> _files;
        private FileProcessingService _fileProcessingSvc;
        private IItemsSaver _saver;


        public FilesController( IServerCacheService cache, 
                                FileProcessingService fileProcessingSvc,
                                IItemsSaver saver)
        {
            this._files = cache.GetList<DataFile>();
            this._fileProcessingSvc = fileProcessingSvc;
            this._saver = saver;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var files = _files.ToList();
            return Ok(files);
        }

        [HttpPost]
        [DisableRequestSizeLimit]
        public async Task<IActionResult> Post(long searcherId)
        {
            if (searcherId == 0)
            {
                return StatusCode(400, "No searcher Id for the file");
            }

            var results = new List<DataFile>();
            var files = Request.Form.Files;
            var fnum = files.Count;
            foreach (var file in files)
            {
                var path = Path.GetTempPath() + file.FileName;
                System.IO.File.Delete(path);
                var fileStream = new FileStream(path, FileMode.CreateNew);
                try
                {
                    await file.CopyToAsync(fileStream);
                    fileStream.Close();
                    var result = this._fileProcessingSvc.ProcessFile(path, searcherId);
                    var dataFileRecord = new DataFile()
                    {
                        Name = file.FileName,
                        ProcessingDuration = result.ElapsedTime,
                        SearchEngineId = searcherId,
                        RecordsCount = result.Number,
                        Uploaded = DateTime.UtcNow

                    };
                    results.Add(dataFileRecord);
                    _files.Add(dataFileRecord);
                    _saver.SaveItem<DataFile>(dataFileRecord);

                }
                catch (Exception exp)
                {
                    fileStream.Close();
                    return StatusCode(500, exp.Message);
                }
                finally
                {
                    System.IO.File.Delete(path);
                }
            }

            return Ok(results);
        }
    }
}
