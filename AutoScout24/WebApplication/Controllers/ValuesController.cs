using System.Collections.Generic;
using System.IO;
using Data_Transfer_Object;
using Data_Transfer_Object.Result;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace WebApplication.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ValuesController : ControllerBase
  {
    // GET api/values
    [HttpGet]
    public ActionResult<IEnumerable<string>> Get()
    {
      return new string[] { "value1", "value2" };
    }

    // GET api/values/5
    [HttpGet("{id}")]
    public ActionResult<string> Get(int id)
    {
      return "value";
    }

    // POST api/values/upload
    [HttpPost("upload")]
    public ReportResult Post([FromBody] FileData fileData)
    {
      if (fileData == null ||  string.IsNullOrEmpty(fileData.listingFile))
      {
        throw new FileNotFoundException("File is not attached");
      }
      
      ListingService service = new ListingService();

      var result = service.GetReportResult(fileData.listingFile);
      
      return result;
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
  }
}
