using WebApplication1.Models;
using WebApplication1.Repositories.Interfaces;
using WebApplication1.Service.Interfaces;

namespace WebApplication1.Service
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repo;

        public StudentService(IStudentRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Student>> GetAllStudents()
            => await _repo.GetAll();

        public async Task<Student> GetStudent(int id)
        {
            var s = await _repo.GetById(id);
            if (s == null) throw new KeyNotFoundException("Student not found");     
            return s;
        }

        public async Task AddStudent(Student student)
            => await _repo.Add(student);

        public async Task UpdateStudent(int id, Student student)
        {
            var s = await _repo.GetById(id);
            if (s == null) throw new KeyNotFoundException("Student not found");

            s.Name = student.Name;
            s.Email = student.Email;
            s.Age = student.Age;
            s.Course = student.Course;

            await _repo.Update(s);
        }

        public async Task DeleteStudent(int id)
        {
            var s = await _repo.GetById(id);
            if (s == null) throw new KeyNotFoundException("Student not found");

            await _repo.Delete(s);
        }
    }
}
