using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Moq;
using WebApplication1.Models;
using WebApplication1.Repositories.Interfaces;
using WebApplication1.Service;
using Xunit;

public class StudentServiceTests
{
    private readonly Mock<IStudentRepository> _repoMock;
    private readonly StudentService _service;

    public StudentServiceTests()
    {
        _repoMock = new Mock<IStudentRepository>();
        _service = new StudentService(_repoMock.Object);
    }

    [Fact]
    public async Task GetStudent_ReturnsStudent_WhenExists()
    {
        var student = new Student
        {
            Id = 1,
            Name = "Kedar",
            Email = "k@gmail.com",
            Age = 22,
            Course = "CS"
        };

        _repoMock.Setup(r => r.GetById(1)).ReturnsAsync(student);

        var result = await _service.GetStudent(1);

        Assert.NotNull(result);
        Assert.Equal("Kedar", result.Name);
    }

    [Fact]
    public async Task GetStudent_ThrowsException_WhenNotFound()
    {
        _repoMock.Setup(r => r.GetById(1)).ReturnsAsync((Student?)null);

        await Assert.ThrowsAsync<KeyNotFoundException>(() => _service.GetStudent(1));
    }

    [Fact]
    public async Task AddStudent_CallsRepository()
    {
        var student = new Student
        {
            Name = "Test",
            Email = "t@test.com",
            Age = 20,
            Course = "IT"
        };

        await _service.AddStudent(student);

        _repoMock.Verify(r => r.Add(student), Times.Once);
    }
}