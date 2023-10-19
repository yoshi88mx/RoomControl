using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using RoomControl.Shared;
using RoomControl.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Xunit;

namespace RoomsControl.WebApi.Test.Integration
{
    public class QueueControllerIntegrationShould: IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly HttpClient httpClient;

        public QueueControllerIntegrationShould(WebApplicationFactory<Startup> factory)
        {
            httpClient = factory.CreateClient( new WebApplicationFactoryClientOptions {  BaseAddress = new Uri("https://localhost:5001/") });
        }

        [Fact]
        public async Task GetAll_ExpectMoreThan0()
        {
            var result = await httpClient.GetFromJsonAsync<List<QueueDto>>("api/v1/queues");

            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task GetById_ExpectJust1()
        {
            var result = await httpClient.GetFromJsonAsync<QueueDto>("api/v1/queues/1");

            Assert.NotNull(result);
            Assert.IsType<QueueDto>(result);
        }

        [Fact]
        public async Task AddOneQueueSuccessfully()
        {
            var result = await httpClient.PostAsJsonAsync("api/v1/queues/", new RequestAddQueueDto { Name = "NewQueue", Active = true});

            Assert.NotNull(result);
            result.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }
    }
}
