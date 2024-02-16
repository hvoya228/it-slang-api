using Dictionary.BLL.Interfaces;
using Dictionary.Data.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;

namespace Dictionary.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UseFrequencyController : ControllerBase
{
    private readonly IUseFrequencyService _service;

    public UseFrequencyController(IUseFrequencyService service)
    {
        _service = service;
    }
    
    [HttpGet("Get")]
    public async Task<ActionResult<IEnumerable<UseFrequencyDto>>> Get()
    {
        return Ok(await _service.Get());
    }
    
    [HttpPost]
    public async Task<ActionResult> Insert([FromBody] UseFrequencyDto modelDto)
    {
        return Ok(await _service.Insert(modelDto));
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteById(Guid id)
    {
        return Ok(await _service.DeleteById(id));
    }
}