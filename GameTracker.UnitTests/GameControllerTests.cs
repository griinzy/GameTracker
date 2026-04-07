using GameTracker.Services;
using GameTracker.ViewModels;
using GameTracker.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTracker.UnitTests
{
    [TestFixture]
    public class GameControllerTests
    {
        private Mock<IGameService> _mockService;
        private GameController _controller;

        [SetUp]
        public void Setup()
        {
            _mockService = new Mock<IGameService>();
            _controller = new GameController(_mockService.Object);
        }

        [TearDown]
        public void TearDown()
        {
            _controller.Dispose();
        }

        [Test]
        public async Task Details_ReturnsNotFound_WhenGameIsNull()
        {
            _mockService
                .Setup(s => s.GetGameDetailsByIdAsync(1))
                .ReturnsAsync((GameDetailsViewModel)null);

            var result = await _controller.Details(1);
            Assert.That(result, Is.TypeOf<NotFoundResult>());
        }

        [Test]
        public async Task Details_ReturnsModel_WhenGameExists()
        {
            var game = new GameDetailsViewModel { Id = 1 };
            _mockService
                .Setup(s => s.GetGameDetailsByIdAsync(1))
                .ReturnsAsync(game);

            var result = await _controller.Details(1) as ViewResult;

            Assert.That(result.Model, Is.EqualTo(game));
        }

        [Test]
        public async Task Create_RedirectsToIndex_WhenModelIsValid()
        {
            var result = await _controller.Create(new GameCreateViewModel()) as RedirectToActionResult;

            Assert.That(result.ActionName, Is.EqualTo("Index"));
        }
    }
}
