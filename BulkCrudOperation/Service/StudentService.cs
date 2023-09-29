using BulkCrudOperation.Common;
using BulkCrudOperation.IService;
using BulkCrudOperation.Models;
using Dapper;
using Microsoft.Data.SqlClient;


namespace BulkCrudOperation.Service
{
    public class StudentService : IStudentService
    {
        public string BulkDelete(List<Student> oStudents)
        {
            using (var connection = new SqlConnection(Global.ConnectionString))
            {
                int totalRows = 0;
                //var totalRows = connection.(oStudents);
                if (totalRows > 0)
                {
                    return "Delete";

                }
                return "Failed";
            }
        }

        public string BulkMerge(List<Student> oStudents)
        {
            using (var connection = new SqlConnection(Global.ConnectionString))
            {
                int totalRows = 0;
                //var totalRows = connection.BulkMerge(oStudents);
                if (totalRows > 0)
                {
                    return "Merge";

                }
                return "Failed";
            }
        }

        public string BulkSave(List<Student> oStudents)
        {

            using (var connection = new SqlConnection(Global.ConnectionString))

            {
                connection.Open();
                var trans = connection.BeginTransaction();
                connection.Execute(@"Insert Student (StudentId,Name,Roll) Values (@StudentId,@Name,@Roll)", oStudents, transaction: trans);
                trans.Commit();
                connection.Close();
            }
            return "Saved";
        }

        public string BulkUpdate(List<Student> oStudents)
        {
            using (var connection = new SqlConnection(Global.ConnectionString))
            {
                // var totalRows = connection.BulkUpdate(oStudents);
                int totalRows = 0;
                if (totalRows > 0)
                {
                    return "Update";

                }
                return "Failed";
            }
        }
    }
}
