using Microsoft.AspNetCore.Mvc;
using P2PRestServer.Models;
using P2PRestServer.Repositories;

namespace P2PRestServer.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RestController : ControllerBase
{
    private readonly FileEndpointsRepository _repository;

    public RestController(FileEndpointsRepository repository)
    {
        _repository = repository;
    }

    [HttpGet("{filename}")]
    public ActionResult<List<FileEndPoint>> GetPeers(string filename)
    {
        var endpoints = _repository.GetFileEndPoints(filename);
        if (endpoints.Any())
        {
            return Ok(endpoints);
        }
        return NotFound();
    }

    [HttpPost("{filename}")]
    public ActionResult RegisterFileEndPoint(string filename, [FromBody] FileEndPoint fileEndPoint)
    {
        _repository.AddFileEndPoint(filename, fileEndPoint);
        return Ok();
    }

    [HttpDelete("{filename}")]
    public ActionResult DeleteFileEndPoint(string filename, [FromBody] FileEndPoint fileEndPoint)
    {
        _repository.RemoveFileEndPoint(filename, fileEndPoint);
        return Ok();
    }

    [HttpGet]
    public ActionResult<List<string>> GetAllFilenames()
    {
        var filenames = _repository.GetAllFilenames();
        return Ok(filenames);
    }
}