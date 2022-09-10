using ItemService.Common.PkRandom;
using ItemService.Domain.Item;
using Microsoft.AspNetCore.Mvc;

namespace ItemService.Controllers;

[ApiController]
[Route("[controller]")]
public class ItemController : ControllerBase
{
    private readonly ILogger<ItemController> _logger;

    public ItemController(ILogger<ItemController> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Replace a user character
    /// </summary>
    /// <param name="dropRate">Drop Rate (1 - 5000)</param>
    /// <param name="seed">Seed value</param>
    /// <returns>Replaced character id.</returns>
    /// <response code="200">Returns character id.</response>
    /// <response code="400">The id is not valid.</response>
    /// <response code="404">User not found.</response>
    /// <response code="500">Internal server error.</response>
    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType(typeof(ItemBase), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult Get([FromQuery] int dropRate, [FromQuery] int seed)
    {
        if (seed != 0)
        {
            PkRandom.SetSeed(seed);
        }
        var staff = new Staff(dropRate == 0 ? 1000 : dropRate);
        return Ok(staff);
    }
}