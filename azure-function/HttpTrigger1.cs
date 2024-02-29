using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Company.Function
{
    public class HttpTrigger1
    {
        private readonly ILogger<HttpTrigger1> _logger;
        private static readonly List<string> items = new List<string>();

        public HttpTrigger1(ILogger<HttpTrigger1> logger)
        {
            _logger = logger;
        }

        [Function("HttpTrigger1")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            return new OkObjectResult("Welcome to Azure Functions!");
        }

        [Function("CreateItem")]
        public async Task<IActionResult> CreateItem([HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req, ILogger log)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var newItem = JsonSerializer.Deserialize<string>(requestBody);
            // Assume items is your data store
            items.Add(newItem);
            return new OkObjectResult(newItem);
        }

        [Function("GetItems")]
        public IActionResult GetItems([HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req, ILogger log)
        {
            // Returns all items
            return new OkObjectResult(items);
        }

        [Function("GetItem")]
        public IActionResult GetItem([HttpTrigger(AuthorizationLevel.Function, "get", Route = "GetItem/{id}")] HttpRequest req, ILogger log, int id)
        {
            // Returns a single item by index
            if (id >= 0 && id < items.Count)
            {
                return new OkObjectResult(items[id]);
            }
            return new NotFoundResult();
        }

        [Function("UpdateItem")]
        public async Task<IActionResult> UpdateItem([HttpTrigger(AuthorizationLevel.Function, "put", Route = "UpdateItem/{id}")] HttpRequest req, ILogger log, int id)
        {
            if (id >= 0 && id < items.Count)
            {
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                var updatedItem = JsonSerializer.Deserialize<string>(requestBody);
                items[id] = updatedItem;
                return new OkObjectResult(updatedItem);
            }
            return new NotFoundResult();
        }

        [Function("DeleteItem")]
        public IActionResult DeleteItem([HttpTrigger(AuthorizationLevel.Function, "delete", Route = "DeleteItem/{id}")] HttpRequest req, ILogger log, int id)
        {
            if (id >= 0 && id < items.Count)
            {
                items.RemoveAt(id);
                return new OkResult();
            }
            return new NotFoundResult();
        }

    }
}
