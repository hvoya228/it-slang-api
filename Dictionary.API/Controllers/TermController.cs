using Dictionary.BLL.Interfaces;
using Dictionary.Data.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;

namespace Dictionary.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TermController : ControllerBase
{
    private readonly ITermService _service;

    public TermController(ITermService service)
    {
        _service = service;
    }
    
    [HttpGet("Get")]
    public async Task<ActionResult<IEnumerable<TermDto>>> Get()
    {
        return Ok(await _service.Get());
    }
    
    [HttpPost]
    public async Task<ActionResult> Insert([FromBody] TermDto modelDto)
    {
        return Ok(await _service.Insert(modelDto));
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteById(Guid id)
    {
        return Ok(await _service.DeleteById(id));
    }
}