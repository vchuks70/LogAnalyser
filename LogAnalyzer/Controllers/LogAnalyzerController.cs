using Domain.DTO;
using Domain.Interface;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogAnalyzer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogAnalyzerController : ControllerBase
    {
        public IReadTextFilesService ReadTextFilesService { get; set; }

        public LogAnalyzerController(IReadTextFilesService readTextFilesService)
        {
            ReadTextFilesService = readTextFilesService;
        }

        [HttpDelete("get-number-of-logs-10")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<int> GetNumberOfLogs10(FilePathWithTimeRangeDto file)
        {
            var response = ReadTextFilesService.GetNumberOfLogs10(file.filePath, file.start, file.end);
          
                return Ok(response);
           
        }



        [HttpDelete("delete-of-logs-11")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<bool> DeleteOfLogs11(FilePathWithTimeRangeDto file)
        {
            var response = ReadTextFilesService.DeleteOfLogs11(file.filePath, file.start, file.end);
            if (response == true)
            {
                return Ok();
            }
            return BadRequest();
        }
            

        [HttpPost("count-unique-errors-12")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<List<Duplicate>> ReadFile12(FilePathDto file)
        {
            var response = ReadTextFilesService.ReadFile12(file.filePath);
            if (response is null)
            {
                return BadRequest();
            }
                return Ok(response);
          
        }

        [HttpPost("count-duplicate-errors-13")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<int> CountDuplicate13(FilePathDto file)
        {
            var response = ReadTextFilesService.CountDuplicate13(file.filePath);
            return Ok(response);

        }

        [HttpPost("search-logs-per-directory14")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<string[]> SearchLogsPerDirectory14(FilePathDto file)
        {
            var response = ReadTextFilesService.SearchLogsPerDirectory14(file.filePath);
            if (response is null)
            {
                return BadRequest();
            }
            return Ok(response);

        }

        [HttpPost("search-logs-per-size-15")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<List<FileProperty>> SearchLogsPerSize15(FilePathWithSizeRangeDto file)
        {
            var response = ReadTextFilesService.SearchLogsPerSize15(file.filePath, file.smallSize, file.LargeSize);
            if (response is null)
            {
                return BadRequest();
            }
            return Ok(response);

        }


        [HttpPost("archive-logs-from-period-16")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<bool> ArchiveLogsFromPeriod16(FilePathWithTimeRangeDto file)
        {
            var response = ReadTextFilesService.ArchiveLogsFromPeriod16(file.filePath, file.start, file.end);
            if (response == false)
            {
                return BadRequest();
            }
            return Ok(response);

        }

        [HttpDelete("delete-archive-logs-from-period-17")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<bool> DeleterchiveLogsFromPeriod17(FilePathWithTimeRangeDto file)
        {
            var response = ReadTextFilesService.DeleterchiveLogsFromPeriod17(file.filePath, file.start, file.end);
            if (response == false)
            {
                return BadRequest();
            }
            return Ok(response);

        }
    }
}
