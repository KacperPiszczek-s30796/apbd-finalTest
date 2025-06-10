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
    public async Task<IActionResult> Get( CancellationToken token = default)
    {
        bookListResponse response = service.ListBooks(token).Result;
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> AddBook(BookToAdd book, CancellationToken cancellationToken)
    {
        if (service.AddBook(book, cancellationToken).Result)
        {
            return Ok();
        }
        else
        {
            return BadRequest();
        }
    }
}