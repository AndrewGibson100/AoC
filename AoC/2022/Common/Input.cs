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
            _client.DefaultRequestHeaders.Add("Cookie", "session=");
        }
        public static async Task<string> GetInput(int day) =>
            await (await _client.GetAsync($"{day}/input"))
            .Content
            .ReadAsStringAsync();
    }
}
