using BulkCrudOperation.Models;
using BulkCrudOperation.Service;

namespace BulkCrudOperation.IService
{
    public interface IStudentService
    {
        string BulkSave(List<Student> oStudents);
        string BulkUpdate(List<Student> oStudents);
        string BulkDelete(List<Student> oStudents);
        string BulkMerge(List<Student> oStudents);
    }
}
