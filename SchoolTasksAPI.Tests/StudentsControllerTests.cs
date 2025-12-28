using Xunit;
using Microsoft.AspNetCore.Mvc;
using SchoolTasksAPI.Controllers;
using SchoolTasksAPI.Entities;
using SchoolTasksAPI.Data;
using System.Collections.Generic;

namespace SchoolTasksAPI.Tests
{
    public class StudentsControllerTests
    {
        private readonly StudentsController _controller;

        public StudentsControllerTests()
        {
            // במקום DataContext אמיתי, נשתמש ב-FakeContext
            IDataContext context = new FakeContext();
            _controller = new StudentsController(context);
        }

        [Fact]
        public void GetAll_ReturnsOk()
        {
            var result = _controller.GetAll();
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void GetById_UnknownId_ReturnsNotFound()
        {
            int unknownId = 999;
            var result = _controller.GetById(unknownId);
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Delete_ExistingId_ReturnsNoContent()
        {
            int existingId = 1;
            var result = _controller.Delete(existingId);
            Assert.IsType<NoContentResult>(result);
        }
    }
}
