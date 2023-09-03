using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

// Controller для проверки на палиндром
[Route("api/palindrome")]
[ApiController]
public class PalindromeController : ControllerBase
{
    [HttpPost]
    public IActionResult CheckPalindrome([FromBody] string input)
    {
        string reversedInput = new string(input.Reverse().ToArray());
        bool isPalindrome = input.Equals(reversedInput, StringComparison.OrdinalIgnoreCase);
        return Ok(isPalindrome);
    }
}
