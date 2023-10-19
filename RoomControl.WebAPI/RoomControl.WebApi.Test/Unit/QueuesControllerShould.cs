using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using RoomControl.Core.Contracts;
using RoomControl.Data.Model;
using RoomControl.Shared.Dtos;
using RoomControl.Shared.Mapper;
using RoomControl.WebApi.Controllers;
using Xunit;

namespace RoomsControl.WebApi.Test.Unit
{
    public class QueuesControllerShould
    {
        private readonly IServiceQueues _serviceQueues ;
        private readonly IMapper _mapper;
        private readonly ILogger<QueuesController> _logger;

        public QueuesControllerShould()
        {
            //Act Service
            var mockServiceQueue = new Mock<IServiceQueues>();
            mockServiceQueue.Setup(t => t.GetAllAsync()).ReturnsAsync(GetQueues());

            _serviceQueues = mockServiceQueue.Object;

            //Act Mapper
            var mapperConfiguration = new MapperConfiguration(c => c.AddProfile<QueueProfile>());
            _mapper = mapperConfiguration.CreateMapper();

            //Act Logger
            var mockLogger = new Mock<ILogger<QueuesController>>();
            _logger = mockLogger.Object;
        }

        [Fact]
        public async Task ReturnAllQueues()
        {
            var controller = new QueuesController(_serviceQueues, _mapper, _logger);

            var result = await controller.GetAll();

            var okResultObject = result.Result as OkObjectResult;
            var lists = okResultObject?.Value as List<QueueDto>;

            //Assert
            Assert.True(lists?.Count == 2);
        }

        private List<Queue> GetQueues()
        {
            return new List<Queue>{ 
                new() { Id = 1, Active = true, Name = "Queue Simple" }, 
                new() { Id = 2, Active = true, Name = "Queue VIP" } 
            }; 
        }
    }
}
