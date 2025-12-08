using Xunit;
using Microsoft.AspNetCore.Mvc;
using SchoolTasksAPI.Controllers;
using SchoolTasksAPI.Entities;
using System.Collections.Generic;

namespace SchoolTasksAPI.Tests
{
    public class StudentsControllerTests
    {
        // שדה פרטי לקונטרולר
        private readonly StudentsController _controller;

        // בנאי (Constructor) שמאתחל את הקונטרולר לפני כל טסט
        public StudentsControllerTests()
        {
            _controller = new StudentsController();
        }

        // טסט 1: בדיקה ששליפת כל הסטודנטים מחזירה תשובה תקינה (OK)
        [Fact]
        public void GetAll_ReturnsOk()
        {
            // Arrange (הנתונים כבר בתוך הקונטרולר)

            // Act
            var result = _controller.GetAll();

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        // טסט 2: בדיקה ששליפת מזהה שלא קיים מחזירה שגיאת 404 (NotFound)
        [Fact]
        public void GetById_UnknownId_ReturnsNotFound()
        {
            // Arrange
            int unknownId = 999;

            // Act
            var result = _controller.GetById(unknownId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        // טסט 3: בדיקה שמחיקת סטודנט קיים מחזירה 204 (NoContent)
        [Fact]
        public void Delete_ExistingId_ReturnsNoContent()
        {
            // Arrange
            // אנחנו יודעים שיש ID=1 בגלל ה-DataContext
            int existingId = 1;

            // Act
            var result = _controller.Delete(existingId);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }
    }
}