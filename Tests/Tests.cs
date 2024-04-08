using NUnit.Framework;
using System.Net.Http;

namespace HTSM_api.Tests
{
    static class HttpResponseMessageExtensions
    {

        internal static void WriteRequestToConsole(this HttpResponseMessage response)
        {
            if (response is null)
            {
                return;
            }

            var request = response.RequestMessage;
            Console.WriteLine($"{request?.Method} ");
            Console.WriteLine($"{request?.RequestUri} ");
            Console.WriteLine($"HTTP/{request?.Version}");
        }
        public class Tests
        {
         

            private static HttpClient httpClient = new()
            {
                BaseAddress = new Uri("https://localhost:32770/api"),
            };

            [SetUp]
            public void Setup()
            {
            }

            [Test]
            public static async Task Test1()
            {
                await GetRequest("/TodoItems");



            }

            public static async Task GetRequest(String endpoint)
            {
                using HttpResponseMessage response = await httpClient.GetAsync(endpoint);

                response.EnsureSuccessStatusCode().WriteRequestToConsole();

                var jsonResponse = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"{jsonResponse}\n");


            }

            
        }
    }
}
