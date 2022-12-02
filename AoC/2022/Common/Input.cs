using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC._2022.Common
{
    internal class Input
    {
        private static HttpClient _client;
        static Input()
        {
            _client = new();
            _client.BaseAddress = new Uri("https://adventofcode.com/2022/day/");
            _client.DefaultRequestHeaders.Add("Cookie", "session=53616c7465645f5fd0fe16bd00afacfe374646afc9118ceee5482183d088b1456ba043d5a31d097b97e874c754a6128fe9be4c62a7edc3b755f9d8cd4bb77c48;");
        }
        public static async Task<string> GetInput(int day) =>
            await (await _client.GetAsync($"{day}/input"))
            .Content
            .ReadAsStringAsync();
    }
}
