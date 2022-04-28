using ArtOrder03.Areas.Admin.Controllers;
using ArtOrder03.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ArtOrder03.Test.Controllers
{
    public class HomeControllerTest
    {
        [Fact]
        public void ShouldReturnView()
        {
            var controller = new HomeController();
            var result = controller.Index;

            Assert.NotNull(result);
            //Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void IndexShouldReturnView()
        {
            // Arrange
            var homeController = new HomeController();

            // Act
            var result = homeController.Index();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
        }

    }
}
