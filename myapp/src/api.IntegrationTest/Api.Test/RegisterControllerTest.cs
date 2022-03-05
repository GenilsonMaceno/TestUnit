using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using src.Repositories;
using Xunit;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using webapitest;
using Api;

namespace apitest
{
    public class RegisterControllerTest
    {
        private readonly HttpClient _client;

        public RegisterControllerTest(){
            var server = new TestServer(new WebHostBuilder()
                     .UseEnvironment("Development")
                     .UseStartup<StartupTest>());

            _client = server.CreateClient();
        }

        [Theory]
        [InlineData("Get")]
        public async Task RegisterGetAll(string method)
        {
            //arrange
            var request = new HttpRequestMessage(new HttpMethod(method), "/api/register/");

            //act
            var response = await _client.SendAsync(request);

            //assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
