using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Test_10_06_2025.contracts.requests;
using Test_10_06_2025.contracts.responses;
using Test_10_06_2025.services.abstractions;

namespace Test_10_06_2025.Controllers;
[ApiController]
public class controller: ControllerBase
{
    private Iservice service;

    public controller(Iservice service)
    {
        this.service = service;
    }
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery]bool? filterByReleaseDate, CancellationToken token = default)
    {
        bookListResponse response = await service.ListBooks(filterByReleaseDate ,token);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> AddBook([FromBody]BookToAdd book, CancellationToken cancellationToken)
    {
        if (await service.AddBook(book, cancellationToken))
        {
            return Ok("Book added");
        }
        else
        {
            return BadRequest();
        }
    }
}