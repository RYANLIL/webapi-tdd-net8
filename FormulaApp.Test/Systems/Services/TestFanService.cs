using FluentAssertions;
using FormulaApp.API.Configuration;
using FormulaApp.API.Models;
using FormulaApp.API.Services;
using FormulaApp.Test.Fixtures;
using FormulaApp.Test.Helpers;
using Microsoft.Extensions.Options;
using Moq;
using Moq.Protected;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace FormulaApp.Test.Systems.Services
{
    public  class TestFanService
    {
        [Fact]
        public async Task GetAllFans_OnInvoked_HttpGet()
        {
            // Arrange
            var url = "https://mywebsite.com/api/v1/fans";
            var response = FansFixture.GetFans();
            var mockHandler = MockHttpHandler<Fan>.SetupGetRequest(response);
            var httpClient = new HttpClient(mockHandler.Object);

            var config = Options.Create(new ApiServiceConfig()
            { 
                Url = url
            });


            var fanService = new FanService(httpClient, config);
            

            // Act
            await fanService.GetAllFans();


            // Assert 
            /**
             * Veriyfying Send async is only done once
             * Making sure the HttpRequest is a get method and is using the url from app config
             * in this case a mock config created above
             * 
             */
            mockHandler.Protected().Verify(
                "SendAsync", Times.Once(),
                ItExpr.Is<HttpRequestMessage>(r =>
                    r.Method == HttpMethod.Get && r.RequestUri.ToString() == url),
                ItExpr.IsAny<CancellationToken>()
            );
        }

        [Fact]
        public async Task GetAllFans_OnInvoked_ListOfFans()
        {
            // Arrange
            var url = "https://mywebsite.com/api/v1/fans";
            var response = FansFixture.GetFans();
            var mockHandler = MockHttpHandler<Fan>.SetupGetRequest(response);
            var httpClient = new HttpClient(mockHandler.Object);

            var config = Options.Create(new ApiServiceConfig()
            {
                Url = url
            });


            var fanService = new FanService(httpClient, config);


            // Act
            var results = await fanService.GetAllFans();


            // Assert 
            results.Should().BeOfType<List<Fan>>();
        }

        /**
         * Testing when no fans are found to return a empty list of fans
         */
        [Fact]
        public async Task GetAllFans_OnInvoked_ReturnEmptyList()
        {
            // Arrange
            var url = "https://mywebsite.com/api/v1/fans";
            var mockHandler = MockHttpHandler<Fan>.SetupReturnNotFound();
            var httpClient = new HttpClient(mockHandler.Object);

            var config = Options.Create(new ApiServiceConfig()
            {
                Url = url
            });


            var fanService = new FanService(httpClient, config);


            // Act
            var results = await fanService.GetAllFans();


            // Assert 
            results.Count.Should().Be(0);
        }


    } // End of Class
}
