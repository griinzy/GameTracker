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
    class AdminControllerTests
    {
        private Mock<IGameService> _mockService;
        private AdminController _controller;

        [SetUp]
        public void Setup()
        {
            _mockService = new Mock<IGameService>();
            _controller = new AdminController(_mockService.Object);
        }

        [TearDown]
        public void TearDown()
        {
            _controller.Dispose();
        }

        [Test]
        public async Task Edit_ReturnsNotFound_WhenGameIsNull()
        {
            _mockService
                .Setup(s => s.GetGameForEditByIdAsync(1))
                .ReturnsAsync((GameEditViewModel)null);

            var result = await _controller.Edit(1);

            Assert.That(result, Is.TypeOf<NotFoundResult>());
        }

        [Test]
        public async Task Edit_RedirectsToDetails_WhenValid()
        {
            var model = new GameEditViewModel { Id = 1 };

            var result = await _controller.Edit(model) as RedirectToActionResult;

            Assert.That(result.ActionName, Is.EqualTo("Details"));
            Assert.That(result.ControllerName, Is.EqualTo("Game"));
        }

        [Test]
        public async Task Delete_ReturnsNotFound_WhenGameIsNull()
        {
            _mockService
                .Setup(s => s.GetGameForDeletionByIdAsync(1))
                .ReturnsAsync((GameDeleteViewModel)null);

            var result = await _controller.Delete(1);

            Assert.That(result, Is.TypeOf<NotFoundResult>());
        }

        [Test]
        public async Task CreateGenre_RedirectsToIndex_WhenModelValid()
        {
            var result = await _controller.CreateGenre(new CreateGenreViewModel()) as RedirectToActionResult;

            Assert.That(result.ActionName, Is.EqualTo("Index"));
        }

        [Test]
        public async Task CreateDeveloper_RedirectsToIndex_WhenModelValid()
        {
            var result = await _controller.CreateDeveloper(new CreateDeveloperViewModel()) as RedirectToActionResult;

            Assert.That(result.ActionName, Is.EqualTo("Index"));
        }
    }
}
