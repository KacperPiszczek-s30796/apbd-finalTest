using Microsoft.AspNetCore.Mvc;
using Test_10_06_2025.services.abstractions;

namespace Test_10_06_2025.Controllers;
[ApiController]
public class controller
{
    private Iservice service;

    public controller(Iservice service)
    {
        this.service = service;
    }
}