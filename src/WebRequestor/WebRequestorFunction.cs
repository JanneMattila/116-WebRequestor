using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net.Http;

namespace WebRequestor
{
    public static class WebRequestorFunction
    {
        private static readonly HttpClient _client = new HttpClient();

        [FunctionName("get")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            var url = req.Query["url"];
            log.LogInformation($"Web Requestor started with url {url}.");

            if (string.IsNullOrWhiteSpace(url))
            {
                return new BadRequestObjectResult(
                    new WebRequestData()
                    {
                        Error = "Missing required query parameter 'url'."
                    });
            }

            var data = await _client.GetStringAsync(url);

            return new OkObjectResult(
                new WebRequestData()
                {
                    Length = data.Length,
                    Sample = data.Substring(0, 5000)
                });
        }
    }
}
