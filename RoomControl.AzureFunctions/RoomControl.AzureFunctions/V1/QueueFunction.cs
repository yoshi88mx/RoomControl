using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RoomControl.AzureFunctions.V1
{
    public static class QueueFunction
    {
        [FunctionName(nameof(AddQueueByBussinesId))]
        public static async Task<IActionResult> AddQueueByBussinesId(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "v1/queues/{bussinesid}")] HttpRequest req,
            [CosmosDB(databaseName: "RoomControl",
            collectionName:"Queues",
            ConnectionStringSetting = "CosmosDB",
            CreateIfNotExists =true)] IAsyncCollector<Queue> collector,
            string bussinesid)
        {
            var cuerpo = await new StreamReader(req.Body).ReadToEndAsync();
            var input = JsonConvert.DeserializeObject<Queue>(cuerpo);
            var queue = new Queue
            {
                Id = Guid.NewGuid(),
                IdBussinesPK = bussinesid,
                Name = input.Name,
                Active = input.Active,
                MinutesSpentOnCleanUp = input.MinutesSpentOnCleanUp,
                CreationDate = DateTime.Now,
                Images = input.Images
            };
            await collector.AddAsync(queue);
            return new OkObjectResult(queue);
        }

        [FunctionName(nameof(GetAllQueuesByBussinesId))]
        public static async Task<IActionResult> GetAllQueuesByBussinesId(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "v1/queues/{bussinesid}")] HttpRequest req,
            [CosmosDB(databaseName: "RoomControl",
            collectionName:"Queues",
            ConnectionStringSetting = "CosmosDB",
            PartitionKey = "{bussinesId}",
            CreateIfNotExists =true)] IEnumerable<Queue> listaDocumentos)
        {
            if (listaDocumentos != null)
            {
                if (listaDocumentos.Any())
                {
                    return new OkObjectResult(listaDocumentos);
                }
            }
            return new NoContentResult();
        }

        [FunctionName(nameof(GetQueueByIdAndBussinesId))]
        public static async Task<IActionResult> GetQueueByIdAndBussinesId(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "v1/queues/{bussinesid}/{id}")] HttpRequest req,
            [CosmosDB(databaseName: "RoomControl",
            collectionName:"Queues",
            ConnectionStringSetting = "CosmosDB",
            PartitionKey = "{bussinesId}",
            Id = "{id}",
            CreateIfNotExists = true)]Queue queue)
        {
            if (queue == null)
            {
                return new NotFoundObjectResult("Not found");
            }
            return new OkObjectResult(queue);
        }

        [FunctionName(nameof(PutQueueByIdAndBussinesId))]
        public static async Task<IActionResult> PutQueueByIdAndBussinesId(
            [HttpTrigger(AuthorizationLevel.Anonymous, "put", Route = "v1/queues/{bussinesid}/{id}")] HttpRequest req,
            [CosmosDB(databaseName: "RoomControl",
            collectionName:"Queues",
            ConnectionStringSetting = "CosmosDB",
            PartitionKey = "{bussinesId}",
            Id = "{id}",
            CreateIfNotExists = true)]Queue queue)
        {
            if (queue == null)
            {
                return new NotFoundObjectResult("Not found");
            }
            var cuerpo = await new StreamReader(req.Body).ReadToEndAsync();
            var input = JsonConvert.DeserializeObject<Queue>(cuerpo);

            queue.Name = input.Name;
            queue.Active = input.Active;
            queue.MinutesSpentOnCleanUp = input.MinutesSpentOnCleanUp;
            queue.ModificationDate = DateTime.Now;
            queue.Images = input.Images;

            return new OkObjectResult(queue);
        }

        [FunctionName(nameof(DeleteImageFromQueueByIdAndBussinesId))]
        public static async Task<IActionResult> DeleteImageFromQueueByIdAndBussinesId(
            [HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "v1/queues/{bussinesid}/{id}/images/{index}")] HttpRequest req,
            [CosmosDB(databaseName: "RoomControl",
            collectionName:"Queues",
            ConnectionStringSetting = "CosmosDB",
            PartitionKey = "{bussinesId}",
            Id = "{id}",
            CreateIfNotExists = true)]Queue queue,
            int index)
        {
            if (queue == null)
            {
                return new NotFoundObjectResult("Not found");
            }

            queue.Images.RemoveAt(index);

            return new OkObjectResult(queue);
        }

        [FunctionName(nameof(AddImageFromQueueByIdAndBussinesId))]
        public static async Task<IActionResult> AddImageFromQueueByIdAndBussinesId(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "v1/queues/{bussinesid}/{id}/images/")] HttpRequest req,
            [Blob("images", FileAccess.Write, Connection = "BlobStorageAccount")] BlobContainerClient cloudBlobContainer,
            [CosmosDB(databaseName: "RoomControl",
            collectionName:"Queues",
            ConnectionStringSetting = "CosmosDB",
            PartitionKey = "{bussinesId}",
            Id = "{id}",
            CreateIfNotExists = true)]Queue queue)
        {
            if (queue == null)
            {
                return new NotFoundObjectResult("Not found");
            }

            await cloudBlobContainer.CreateIfNotExistsAsync();

            var file = req.Form.Files.FirstOrDefault();
            var blobName =
              $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";

            blobName = blobName.Replace("\"", "");

            using (var fileStream = file.OpenReadStream())
            {
                var info = await cloudBlobContainer.UploadBlobAsync(blobName, fileStream);
                queue.Images.Add(new Image { ImagePath = $"{cloudBlobContainer.Uri}/{blobName}" });

            }

            return new OkResult();
        }

        public class Queue
        {
            [JsonProperty("id")]
            public Guid? Id { get; set; }

            [JsonProperty("idBussinesPK")]
            public string IdBussinesPK { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("active")]
            public bool Active { get; set; }

            [JsonProperty("minutesSpentOnCleanUp")]
            public int MinutesSpentOnCleanUp { get; set; }

            [JsonProperty("creationDate")]
            public DateTime CreationDate { get; set; }

            [JsonProperty("modificationDate")]
            public DateTime ModificationDate { get; set; }

            [JsonProperty("images")]
            public List<Image> Images { get; set; } = new List<Image>();

            [JsonProperty("rooms")]
            public List<Room> Rooms { get; set; } = new List<Room>();

            [JsonProperty("roomOnScreen")]
            public RoomOnScreen RoomOnScreen { get; set; } = new RoomOnScreen();
        }

        public class Image
        {
            [JsonProperty("imagePath")]
            public string ImagePath { get; set; }
        }


    }
}
