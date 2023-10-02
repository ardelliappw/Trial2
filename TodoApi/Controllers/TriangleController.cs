using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using TodoApi.Models;

namespace TodoApi.Controllers;

[ApiController]
[Route("api/triangle")]
public class TriangleController : ControllerBase
{
    [HttpPost("type")]
    public IActionResult GetTriangleType([FromBody] Triangle input)
    {
        if (IsTriangleValid(input.SideA, input.SideB, input.SideC))
        {
            if (input.SideA == input.SideB && input.SideB == input.SideC)
            {
                return Ok("Equilateral Triangle");
            }
            else if (input.SideA == input.SideB || input.SideA == input.SideC || input.SideB == input.SideC)
            {
                return Ok("Isosceles Triangle");
            }
            else
            {
                return Ok("Scalene Triangle");
            }
        }
        else
        {
            return BadRequest("Invalid triangle sides. The sum of any two sides must be greater than the third side.");
        }
    }

    private bool IsTriangleValid(double a, double b, double c)
    {
        return a + b > c && a + c > b && b + c > a;
    }
}
