using FluentAssertions;
using FormulaApp.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaApp.Test.Systems.Controllers
{
    public class TestFansControllers
    {
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

    }
}
