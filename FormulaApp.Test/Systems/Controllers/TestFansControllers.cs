using FluentAssertions;
using FormulaApp.API.Controllers;
using FormulaApp.API.Models;
using FormulaApp.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaApp.Test.Systems.Controllers
{
    public class TestFansControllers
    {
        /*
        [Fact]
        public async Task Get_OnSuccess_ReturnsStatusCode_200()
        {
            // Arrange What the test needs to run
            var fansController = new FansController();

            // Act
            var result = (OkObjectResult) await fansController.GetFans();


            // Assert

            result.StatusCode.Should().Be(200);
        }
        */

        [Fact]
        public async Task Get_OnSuccess_ReturnsStatusCode_200()
        {
            // Arrange What the test needs to run
            var mockFanService = new Mock<IFanService>();
            mockFanService.Setup(service => service.GetAllFans())
                .ReturnsAsync(new List<Fan>());

            var fansController = new FansController(mockFanService.Object);

            // Act
            var result = (OkObjectResult)await fansController.GetFans();


            // Assert

            result.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task Get_OnSuccess_InvokeService()
        {
            // Arrange What the test needs to run
            var mockFanService = new Mock<IFanService>();
            mockFanService.Setup(service => service.GetAllFans())
                .ReturnsAsync(new List<Fan>());

            var fansController = new FansController(mockFanService.Object);

            // Act
            var result = (OkObjectResult)await fansController.GetFans();


            // Assert
            // Checks if service is being called
            mockFanService.Verify(service => service.GetAllFans(), Times.Once());

        }
        [Fact]
        public async Task Get_OnSuccess_ReturnListOfFans()
        {
            // Arrange What the test needs to run
            var mockFanService = new Mock<IFanService>();
            mockFanService.Setup(service => service.GetAllFans())
                .ReturnsAsync(new List<Fan>());

            var fansController = new FansController(mockFanService.Object);

            // Act
            var result = (OkObjectResult)await fansController.GetFans();
            
            
            // Assert
            //Verify that result is an ok status 200
            result.Should().BeOfType<OkObjectResult>();

            //Verify that body response is a list of fans
            result.Value.Should().BeOfType<List<Fan>>();
            

        }
    }
}
