using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using TodoApi.Models;

namespace TodoApi.Controllers;

[ApiController]
[Route("api/fibonacci")]
public class FibonacciController : ControllerBase
{
    [HttpPost("series")]
    public IActionResult GetFibonacciSeries([FromBody] FibonacciModel input)
    {
        if (input.Number < 0)
        {
            return BadRequest("Please provide a non-negative number.");
        }

        List<int> fibonacciSeries = GenerateFibonacciSeries(input.Number);
        return Ok(fibonacciSeries);
    }

    private List<int> GenerateFibonacciSeries(int n)
    {
        List<int> fibonacciSeries = new List<int>();
        if (n >= 1)
        {
            fibonacciSeries.Add(0);
        }
        if (n >= 2)
        {
            fibonacciSeries.Add(1);
        }

        for (int i = 2; i < n; i++)
        {
            int next = fibonacciSeries[i - 1] + fibonacciSeries[i - 2];
            if (next <= n)
            {
                fibonacciSeries.Add(next);
            }
            else
            {
                break;
            }
        }

        return fibonacciSeries;
    }
}
