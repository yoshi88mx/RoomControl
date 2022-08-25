using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;
using static RoomControl.AzureFunctions.V1.QueueFunction;

namespace RoomControl.AzureFunctions.V1
{
    public static class ScreenFunction
    {
        [FunctionName(nameof(PutRoomOnScreenByIdAndBussinesId))]
        public static async Task<IActionResult> PutRoomOnScreenByIdAndBussinesId(
            [HttpTrigger(AuthorizationLevel.Anonymous, "put", Route = "v1/queues/{bussinesid}/{idQueue}/roomOnScreen")] HttpRequest req,
            [CosmosDB(databaseName: "RoomControl",
            collectionName:"Queues",
            ConnectionStringSetting = "CosmosDB",
            PartitionKey = "{bussinesId}",
            Id = "{idQueue}",
            CreateIfNotExists = true)]Queue queue)
        {
            if (queue == null)
            {
                return new NotFoundObjectResult("Not found");
            }
            var cuerpo = await new StreamReader(req.Body).ReadToEndAsync();
            var input = JsonConvert.DeserializeObject<RoomOnScreen>(cuerpo);

            queue.RoomOnScreen = input;
            queue.ModificationDate = DateTime.Now;

            return new OkObjectResult(queue);
        }
    }

    public class RoomOnScreen
    {
        [JsonProperty("number")]
        public string Number { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; } = string.Empty;

        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("state")]
        public string State { get; set; } = string.Empty;

        [JsonProperty("isAvailable")]
        public bool IsAvailable { get; set; }
    }
}
