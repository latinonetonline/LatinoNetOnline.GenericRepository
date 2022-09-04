using LatinoNetOnline.GenericRepository.Demo.Controllers;
using LatinoNetOnline.GenericRepository.Demo.Entities;
using LatinoNetOnline.GenericRepository.Moq;
using LatinoNetOnline.GenericRepository.Repositories;

using Microsoft.AspNetCore.Mvc;

using Moq;

namespace LatinoNetOnline.GenericRepository.Demo.Tests
{
    public class BooksControllerTests
    {
        [Fact]
        public async Task GetAllAsync_Expected_Ok()
        {
            Mock<IRepository<Book>> repository = new();

            repository.Setup_GetAllAsync()
                .ReturnsAsync(new List<Book>());

            BooksController controller = new(repository.Object);

            var result = await controller.GetAllAsync();

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetById_When_IdExists_Expected_Ok()
        {
            Mock<IRepository<Book>> repository = new();

            repository.Setup_FirstOrDefaultAsync_1()
                .ReturnsAsync(new Book());

            BooksController controller = new(repository.Object);

            var result = await controller.GetAsync(It.IsAny<int>());

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetById_When_IdDontExists_Expected_NotFound()
        {
            Mock<IRepository<Book>> repository = new();


            BooksController controller = new(repository.Object);

            var result = await controller.GetAsync(It.IsAny<int>());

            Assert.IsType<NotFoundResult>(result);
        }


        [Fact]
        public async Task PostAsync_Expected_Ok()
        {
            Mock<IRepository<Book>> repository = new();

            BooksController controller = new(repository.Object);

            var result = await controller.PostAsync(It.IsAny<Book>());

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task PutAsync_Expected_Ok()
        {
            Mock<IRepository<Book>> repository = new();

            repository.Setup_FirstOrDefaultAsync_1()
                .ReturnsAsync(new Book());

            BooksController controller = new(repository.Object);

            var result = await controller.PutAsync(It.IsAny<int>(), new Book
            {
                Title = "test",
                Author = "test"
            });

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task PutAsync_When_IdDontExists_Expected_BadRequest()
        {
            Mock<IRepository<Book>> repository = new();

            BooksController controller = new(repository.Object);

            var result = await controller.PutAsync(It.IsAny<int>(), It.IsAny<Book>());

            Assert.IsType<BadRequestResult>(result);
        }


        [Fact]
        public async Task DeleteAsync_Expected_Ok()
        {
            Mock<IRepository<Book>> repository = new();

            repository.Setup_FirstOrDefaultAsync_1()
                .ReturnsAsync(new Book());

            BooksController controller = new(repository.Object);

            var result = await controller.DeleteAsync(It.IsAny<int>());

            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task DeleteAsync_When_IdDontExists_Expected_BadRequest()
        {
            Mock<IRepository<Book>> repository = new();

            BooksController controller = new(repository.Object);

            var result = await controller.DeleteAsync(It.IsAny<int>());

            Assert.IsType<BadRequestResult>(result);
        }
    }
}