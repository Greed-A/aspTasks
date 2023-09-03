using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

// Controller для сложения нечетных чисел
[Route("api/sum")]
[ApiController]
public class SumController : ControllerBase
{
    [HttpPost]
    public IActionResult SumOddNumbers([FromBody] List<int> numbers)
    {
        int sum = 0;
        for (int i = 0; i < numbers.Count; i += 2)
        {
            if (numbers[i] % 2 != 0)
            {
                sum += numbers[i];
            }
        }
        return Ok(Math.Abs(sum));
    }
}
