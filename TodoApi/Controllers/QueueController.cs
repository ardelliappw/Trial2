using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

using TodoApi.Models;

[ApiController]
[Route("api/queue")]
public class QueueController : ControllerBase
{
    private Queue<string> stringQueue = new Queue<string>();

    [HttpPost("enqueue")]
    public IActionResult Enqueue([FromBody] string item)
    {
        stringQueue.Enqueue(item);
        return Ok($"Enqueued: {item}");
    }

    [HttpGet("dequeue")]
    public IActionResult Dequeue()
    {
        try
        {
            var item = stringQueue.Dequeue();
            return Ok($"Dequeued: {item}");
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("count")]
    public IActionResult Count()
    {
        return Ok($"Queue count: {stringQueue.Count}");
    }
}
