using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class CoffeeController : ControllerBase
{
    private readonly CoffeeService _coffeeService;
    public CoffeeController(CoffeeService coffeeService)
    {
        _coffeeService = coffeeService;
    }

    [HttpGet]
    public Task<List<Coffee>> GetAll()
    {
        return _coffeeService.GetAll();
    }

    [HttpGet("{id}")]
    public Task<Coffee> GetById(string id)
    {
        return _coffeeService.GetById(id);
    }

    [HttpPost]
    public Task<Coffee> Create([FromBody] Coffee coffee)
    {
        return _coffeeService.Create(coffee);
    }

    [HttpPut("{id}")]
    public Task<Coffee> Update(string id, [FromBody] Coffee coffee)
    {
        return _coffeeService.Update(id, coffee);
    }

    [HttpDelete]
    public Task Delete(string id)
    {
        return _coffeeService.Delete(id);
    }
}