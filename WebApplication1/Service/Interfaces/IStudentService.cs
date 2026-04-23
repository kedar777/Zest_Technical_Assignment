using WebApplication1.Models;

namespace WebApplication1.Service.Interfaces
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetAllStudents();
        Task<Student> GetStudent(int id);
        Task AddStudent(Student student);
        Task UpdateStudent(int id, Student student);
        Task DeleteStudent(int id);
    }
}
