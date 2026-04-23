using WebApplication1.Models;

namespace WebApplication1.Repositories.Interfaces
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAll();
        Task<Student?> GetById(int id);
        Task Add(Student student);
        Task Update(Student student);
        Task Delete(Student student);
    }
}
