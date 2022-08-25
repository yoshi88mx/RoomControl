using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using System;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static RoomControl.AzureFunctions.V1.QueueFunction;

namespace RoomControl.AzureFunctions.V1
{
    public static class RoomFunction
    {
        [FunctionName(nameof(GetRoomByIdAndBussinesId))]
        public static async Task<IActionResult> GetRoomByIdAndBussinesId(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "v1/queues/{bussinesid}/{idQueue}/rooms/{idRoom}")] HttpRequest req,
            [CosmosDB(databaseName: "RoomControl",
            collectionName:"Queues",
            ConnectionStringSetting = "CosmosDB",
            PartitionKey = "{bussinesId}",
            Id = "{idQueue}",
            CreateIfNotExists = true)]Queue queue,
            string idRoom)
        {
            if (queue == null)
            {
                return new NotFoundObjectResult("Not found");
            }

            var room = queue.Rooms.FirstOrDefault(t => t.Id == idRoom);

            if (room == null)
            {
                return new NotFoundObjectResult("Not found");
            }

            return new OkObjectResult(room);
        }

        [FunctionName(nameof(AddRoomByBussinesId))]
        public static async Task<IActionResult> AddRoomByBussinesId(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "v1/queues/{bussinesid}/{idQueue}/rooms")] HttpRequest req,
            [CosmosDB(databaseName: "RoomControl",
            collectionName:"Queues",
            ConnectionStringSetting = "CosmosDB",
            PartitionKey = "{bussinesId}",
            Id = "{idQueue}",
            CreateIfNotExists = true)]Queue queue)
        {
            var input = await JsonSerializer.DeserializeAsync<Room>(req.Body);
            var room = new Room
            {
                Id = $"{Guid.NewGuid()}",
                Description = input.Description,
                Number = input.Number,
                Price = input.Price,
                State = input.State,
                CreationDate = DateTime.Now,
            };
            queue.Rooms.Add(room);
            return new OkObjectResult(queue);
        }

        [FunctionName(nameof(PutRoomByIdAndBussinesId))]
        public static async Task<IActionResult> PutRoomByIdAndBussinesId(
            [HttpTrigger(AuthorizationLevel.Anonymous, "put", Route = "v1/queues/{bussinesid}/{idQueue}/rooms/{idRoom}/")] HttpRequest req,
            [CosmosDB(databaseName: "RoomControl",
            collectionName:"Queues",
            ConnectionStringSetting = "CosmosDB",
            PartitionKey = "{bussinesId}",
            Id = "{idQueue}",
            CreateIfNotExists = true)]Queue queue,
            string idRoom)
        {
            if (queue == null)
            {
                return new NotFoundObjectResult("Not found");
            }

            var room = queue.Rooms.FirstOrDefault(t => t.Id == idRoom);

            if (room == null)
            {
                return new NotFoundObjectResult("Not found");
            }

            var input = await JsonSerializer.DeserializeAsync<Room>(req.Body);

            room.Number = input.Number;
            room.Active = input.Active;
            room.Description = input.Description;
            room.Price = input.Price;
            room.State = input.State;
            room.ModificationDate = DateTime.Now;

            return new OkObjectResult(queue);
        }

        [FunctionName(nameof(DeleteRoomByIdAndBussinesId))]
        public static async Task<IActionResult> DeleteRoomByIdAndBussinesId(
            [HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "v1/queues/{bussinesid}/{idQueue}/rooms/{idRoom}/")] HttpRequest req,
            [CosmosDB(databaseName: "RoomControl",
            collectionName:"Queues",
            ConnectionStringSetting = "CosmosDB",
            PartitionKey = "{bussinesId}",
            Id = "{idQueue}",
            CreateIfNotExists = true)]Queue queue,
            string idRoom)
        {
            if (queue == null)
            {
                return new NotFoundObjectResult("Not found");
            }

            var room = queue.Rooms.FirstOrDefault(t => t.Id == idRoom);

            if (room == null)
            {
                return new NotFoundObjectResult("Not found");
            }

            queue.Rooms.RemoveAll(t => t.Id == idRoom);

            room.ModificationDate = DateTime.Now;

            return new OkObjectResult(queue);
        }
    }

    public class Room
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("number")]
        public int Number { get; set; }

        [JsonPropertyName("active")]
        public bool Active { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("price")]
        public double Price { get; set; }

        [JsonPropertyName("state")]
        public string State { get; set; }

        [JsonPropertyName("creationDate")]
        public DateTime CreationDate { get; set; }

        [JsonPropertyName("modificationDate")]
        public DateTime ModificationDate { get; set; }
    }
}
