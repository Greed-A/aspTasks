using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// Controller для сортировки
[Route("api/sort")]
[ApiController]
public class SortController : ControllerBase
{
    [HttpPost]
    public IActionResult SortNumbers([FromBody] List<int> numbers)
    {
        for (int i = 0; i < numbers.Count - 1; i++)
        {
            for (int j = 0; j < numbers.Count - 1 - i; j++)
            {
                if (numbers[j] > numbers[j + 1])
                {
                    int temp = numbers[j];
                    numbers[j] = numbers[j + 1];
                    numbers[j + 1] = temp;
                }
            }
        }
        return Ok(numbers);
    }
}
