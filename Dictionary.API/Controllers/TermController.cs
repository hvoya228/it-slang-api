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
    
    [HttpGet("GetByText")]
    public async Task<ActionResult<IEnumerable<CompleteTermDto>>> GetByText(string text)
    {
        return Ok(await _service.GetByText(text));
    }
    
    [HttpGet("GetByCategoryId")]
    public async Task<ActionResult<IEnumerable<CompleteTermDto>>> GetByCategoryId(Guid categoryId)
    {
        return Ok(await _service.GetByCategoryId(categoryId));
    }
    
    [HttpGet("Get")]
    public async Task<ActionResult<IEnumerable<CompleteTermDto>>> Get()
    {
        return Ok(await _service.Get());
    }
    
    [HttpPost]
    public async Task<ActionResult> Insert([FromBody] TermDto model)
    {
        return Ok(await _service.Insert(model));
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteById(Guid id)
    {
        return Ok(await _service.DeleteById(id));
    }
}