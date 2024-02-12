using Lab3___zadanieContextConnection;
using Lab3___zadanieContextConnection.Entities;
using Lab3zadanie.Controllers;
using Lab3zadanie.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace EmployeeControllerTests
{
        public class EmployeeControllerTests
        {
            private readonly Mock<IEmployeeService> _employeeServiceMock;
            private readonly Mock<AppDbContext> _contextMock;
            private readonly EmployeeController _controller;

            public EmployeeControllerTests()
            {
                _employeeServiceMock = new Mock<IEmployeeService>();
                _contextMock = new Mock<AppDbContext>();
                _controller = new EmployeeController(_employeeServiceMock.Object, _contextMock.Object);
            }

            [Fact]
            public void Index_ReturnsAViewResult_WithAListOfEmployee()
            {
                var employees = new List<EmployeeEntity>
            {
                new EmployeeEntity()
                {
                   Id = 1,
                   FirstName = "Jan",
                   LastName = "Kowalski",
                   PESEL = "12345678901",
                   Department = "IT",
                   EmploymentDate = new DateTime(2021-12-12),
                   TerminationDate = new DateTime(2021-12-10)
                },
                new EmployeeEntity()
                {
                     Id = 2,
                     FirstName = "Adam",
                     LastName = "Nowak",
                     PESEL = "12345678902",
                     Department = "HR",
                     EmploymentDate = new DateTime(2021-12-12),
                     TerminationDate = new DateTime(2021-12-10)
                }
            };

                _employeeServiceMock.Setup(service => service.FindAll()).Returns(employees);

                var result = _controller.Index();

                var viewResult = Assert.IsType<ViewResult>(result);

                var model = Assert.IsAssignableFrom<IEnumerable<Employee>>(viewResult.ViewData.Model);

                Assert.Equal(employees.Count, model.Count());
            }


            [Fact]
            public void Create_Post_ValidModel_ReturnsRedirectToIndex()
            {
                var employee = new Employee {};
                _employeeServiceMock.Setup(x => x.Add(It.IsAny<EmployeeEntity>()));

                var result = _controller.Create(employee);

                var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
                Assert.Equal("Index", redirectToActionResult.ActionName);
            }

            [Fact]
            public void Create_Post_InvalidModel_ReturnsViewWithModel()
            {
                var employee = new Employee {};
                _controller.ModelState.AddModelError("Error", "Model error");

                var result = _controller.Create(employee);

                var viewResult = Assert.IsType<ViewResult>(result);
                Assert.IsType<Employee>(viewResult.Model);
            }

            [Fact]
            public void DeleteConfirmed_ExistingEmployee_ReturnsRedirectToIndex()
            {
                var employeeId = 1;
                _employeeServiceMock.Setup(x => x.FindById(employeeId))
                    .Returns(new EmployeeEntity() {});
                _employeeServiceMock.Setup(x => x.Delete(employeeId));

                var result = _controller.DeleteConfirmed(employeeId);

                var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
                Assert.Equal("Index", redirectToActionResult.ActionName);
            }

            [Fact]
            public void DeleteConfirmed_NonExistingEmployee_ReturnsNotFound()
            {
                var employeeId = 1;
                _employeeServiceMock.Setup(x => x.FindById(employeeId))
                    .Returns((EmployeeEntity)null);

                var result = _controller.DeleteConfirmed(employeeId);

                Assert.IsType<NotFoundResult>(result);
            }
        }
}
