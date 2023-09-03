using System;
using System.Collections.Generic;
using System.Net.Http;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Number of task:");
            int task = Convert.ToInt32(Console.ReadLine());
            switch (task)
            {
                case 1:
                    Console.WriteLine("Введите последовательность чисел:");
                    Console.WriteLine("Ответ: " + await SumOddNumbersAsync(ParserToInt(task, Console.ReadLine())));
                    break;
                case 2:
                    Console.WriteLine("Введите последовательность:");
                    Console.WriteLine("Ответ: " + await CheckPalindromeAsync(Console.ReadLine()));
                    //await CheckPalindromeAsync(Console.ReadLine());
                    break;
                case 3:
                    Console.WriteLine("Введите последовательность чисел:");
                    Console.WriteLine("Ответ: " + ParserToString(await SortNumbersAsync(ParserToInt(task, Console.ReadLine()))));
                    break;
                default:
                    break;
            }
        }

    }

    public static List<int> ParserToInt(int task, string str)
    {
        List<int> lst = new List<int>();
        str = str.Trim(' ');
        string[] arrStr = str.Split(',');
        for(int i = 0; i < arrStr.Length; i++)
        {
            lst.Add(Convert.ToInt32(arrStr[i]));
        }
        return lst;
    }

    public static string ParserToString(List<int> listInt)
    {
        string str = "";
        foreach(int lst in listInt)
        {
            if(str == "")
            {
                str = lst.ToString();
                continue;
            }
            str += "," + lst.ToString();
        }
        return str;
    }

    static async Task<int> SumOddNumbersAsync(List<int> numbers)
    {
        using (HttpClient client = new HttpClient())
        {
            string url = "http://localhost:65446/api/sum";
            string jsonRequest = JsonSerializer.Serialize(numbers);
            HttpContent content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(url, content);

            if (response.IsSuccessStatusCode)
            {
                Stream responseStream = await response.Content.ReadAsStreamAsync();
                StreamReader reader = new StreamReader(responseStream);
                string jsonResponse = await reader.ReadToEndAsync();
                int sum = JsonSerializer.Deserialize<int>(jsonResponse);
                return sum;
            }
            else
            {
                throw new Exception("Ошибка при выполнении запроса");
            }
        }
    }

    static async Task<bool> CheckPalindromeAsync(string input)
    {
        using (HttpClient client = new HttpClient())
        {
            string url = "http://localhost:65446/api/palindrome";
            string jsonRequest = JsonSerializer.Serialize(input);
            HttpContent content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(url, content);

            if (response.IsSuccessStatusCode)
            {
                Stream responseStream = await response.Content.ReadAsStreamAsync();
                StreamReader reader = new StreamReader(responseStream);
                string jsonResponse = await reader.ReadToEndAsync();
                bool isPalindrome = JsonSerializer.Deserialize<bool>(jsonResponse);
                return isPalindrome;
            }
            else
            {
                throw new Exception("Ошибка при выполнении запроса");
            }
        }
    }

    static async Task<List<int>> SortNumbersAsync(List<int> numbers)
    {
        using (HttpClient client = new HttpClient())
        {
            string url = "http://localhost:65446/api/sort";
            string jsonRequest = JsonSerializer.Serialize(numbers);
            HttpContent content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(url, content);

            if (response.IsSuccessStatusCode)
            {
                Stream responseStream = await response.Content.ReadAsStreamAsync();
                StreamReader reader = new StreamReader(responseStream);
                string jsonResponse = await reader.ReadToEndAsync();
                List<int> sortedNumbers = JsonSerializer.Deserialize<List<int>>(jsonResponse);
                string str;
                return sortedNumbers;
            }
            else
            {
                throw new Exception("Ошибка при выполнении запроса");
            }
        }
    }
}
