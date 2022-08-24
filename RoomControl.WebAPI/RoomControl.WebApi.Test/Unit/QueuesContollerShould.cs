using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using RoomControl.Core.Contracts;
using Microsoft.Extensions.Logging;
using Moq;
using RoomControl.Data.Model;
using RoomControl.Shared.Controllers;
using RoomControl.Shared.Mapper;
using Xunit;

namespace RoomsControl.WebApi.Test.Controllers
{
    public class QueuesContollerShould
    {
        private readonly IServiceQueues _serviceQueues ;
        private readonly IMapper _mapper;
        private readonly ILogger<QueuesController> _logger;

        public QueuesContollerShould()
        {
            //Act Service
            var mockServiceQueue = new Mock<IServiceQueues>();
            mockServiceQueue.Setup(t => t.GetAllAsync()).ReturnsAsync(GetQueues());

            _serviceQueues = mockServiceQueue.Object;

            //Act Mapper
            var mapperConfiguratio = new MapperConfiguration(c => c.AddProfile<QueueProfile>());
            _mapper = mapperConfiguratio.CreateMapper();

            //Act Logger
            var mockLogger = new Mock<ILogger<QueuesController>>();
            //mockLogger.Setup(t => t.LogInformation(It.IsAny<string>()));
            _logger = mockLogger.Object;

        }

        //[Fact]
        //public async Task ReturnAllQueues()
        //{
        //    var controller = new QueuesController(_serviceQueues, _mapper, _logger);

        //    var result = await controller.GetAll();

        //    //Assert
        //    //Assert.NotEmpty(result.Result);
        //    Assert.True(result.Value.Count == GetQueues().Count);
        //}

        private List<Queue> GetQueues()
        {
            return new List<Queue>{ 
                new Queue { Id = 1, Active = true, Name = "Queue Simple" }, 
                new Queue { Id = 2, Active = true, Name = "Queue VIP" } 
            }; 
        }
    }
}
