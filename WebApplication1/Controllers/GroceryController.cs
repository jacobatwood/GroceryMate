using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using GroceryMate.Models;

[Route("api/[controller]")]
[ApiController]
public class GroceryController : ControllerBase
{
    private static List<Grocery> groceries = new List<Grocery>
    {
        new Grocery { Id = 1, Name = "Apples", Price = 2.99m, Quantity = 5 },
        new Grocery { Id = 2, Name = "Milk", Price = 3.49m, Quantity = 1 }
    };

    [HttpGet]
    public IActionResult GetAllGroceries()
    {
        return Ok(groceries);
    }

    [HttpGet("{id}")]
    public IActionResult GetGroceryById(int id)
    {
        var grocery = groceries.Find(g => g.Id == id);
        if (grocery == null) return NotFound("Grocery not found");
        return Ok(grocery);
    }

    [HttpPost]
    public IActionResult AddGrocery([FromBody] Grocery grocery)
    {
        grocery.Id = groceries.Count + 1;
        groceries.Add(grocery);
        return Ok(groceries);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateGrocery(int id, [FromBody] Grocery updatedGrocery)
    {
        var grocery = groceries.Find(g => g.Id == id);
        if (grocery == null) return NotFound("Grocery not found");

        grocery.Name = updatedGrocery.Name;
        grocery.Price = updatedGrocery.Price;
        grocery.Quantity = updatedGrocery.Quantity;
        return Ok(grocery);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteGrocery(int id)
    {
        var grocery = groceries.Find(g => g.Id == id);
        if (grocery == null) return NotFound("Grocery not found");

        groceries.Remove(grocery);
        return Ok(groceries);
    }
}