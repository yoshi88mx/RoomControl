using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RoomControl.Core.Contracts;
using System;
using System.Threading.Tasks;

namespace RoomControl.Shared.Controllers
{
    [ApiController]
    [Route("api/v1/upload")]
    public class UploadController : ControllerBase
    {
        private readonly ILogger<UploadController> _logger;
        private readonly IServiceQueueImages _serviceQueueImages;
        private readonly IConfiguration _configuration;

        public UploadController(ILogger<UploadController> logger, IServiceQueueImages serviceRoomImages, IConfiguration configuration)
        {
            _logger = logger;
            _serviceQueueImages = serviceRoomImages;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<ActionResult> UploadImage([FromQuery] int queueId, [FromForm] RequestUploadRoomImage request)
        {
            try
            {
                _logger.LogInformation(nameof(UploadImage));
                var file = request.File;
                if (file.Length > 0)
                {
                    var azureBlobConnection = _configuration.GetConnectionString("AzureBlobAccount");
                    var container = new BlobContainerClient(azureBlobConnection, "images");
                    var createResponse = await container.CreateIfNotExistsAsync();
                    if (createResponse != null && createResponse.GetRawResponse().Status == 201)
                        await container.SetAccessPolicyAsync(Azure.Storage.Blobs.Models.PublicAccessType.Blob);
                    var blob = container.GetBlobClient(file.FileName);
                    await blob.DeleteIfExistsAsync(DeleteSnapshotsOption.IncludeSnapshots);
                    using (var fileStream = file.OpenReadStream())
                    {
                        await blob.UploadAsync(fileStream, new BlobHttpHeaders { ContentType = file.ContentType });
                    }
                    await _serviceQueueImages.AddAsync(blob.Uri.ToString(), queueId);
                    return Ok(blob.Uri.ToString());
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteImage([FromQuery] int idImage)
        {
            _logger.LogInformation(nameof(DeleteImage));
            await _serviceQueueImages.DeleteAsync(idImage);
            return Ok();
        }
    }

    public class RequestUploadRoomImage
    {
        public IFormFile File { get; set; }
    }
}
