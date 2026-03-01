using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySqlConnector;
using System.Collections.Generic;

namespace Student_Managment_System.Pages.Students
{
    public class AssignCourseModel : PageModel
    {
        [BindProperty]
        public int StudentId { get; set; }

        [BindProperty]
        public List<int> SelectedCourses { get; set; } = new();

        public string StudentName { get; set; } = "";

        public List<CourseInfo> CoursesList { get; set; } = new();

        public void OnGet(int id)
        {
            StudentId = id;

            using var connection = new MySqlConnection(
                "Server=localhost;Port=3306;Database=studentdb;Uid=root;Pwd=Harshu@87;");
            connection.Open();

            // Get student name
            string studentSql = "SELECT Name FROM students WHERE Id=@id";
            using (var studentCmd = new MySqlCommand(studentSql, connection))
            {
                studentCmd.Parameters.AddWithValue("@id", id);
                var result = studentCmd.ExecuteScalar();
                if (result != null)
                {
                    StudentName = result.ToString()!;
                }
            }

            // Get all courses
            string sql = "SELECT * FROM courses";
            using var command = new MySqlCommand(sql, connection);
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                CoursesList.Add(new CourseInfo
                {
                    Id = reader.GetInt32("Id"),
                    CourseName = reader.GetString("CourseName")
                });
            }
        }

        public IActionResult OnPost()
        {
            using var connection = new MySqlConnection(
                "Server=localhost;Port=3306;Database=studentdb;Uid=root;Pwd=Harshu@87;");
            connection.Open();

            // Delete old assignments
            string deleteSql = "DELETE FROM studentcourses WHERE StudentId=@id";
            using (var deleteCmd = new MySqlCommand(deleteSql, connection))
            {
                deleteCmd.Parameters.AddWithValue("@id", StudentId);
                deleteCmd.ExecuteNonQuery();
            }

            // Insert new selected courses
            foreach (var courseId in SelectedCourses)
            {
                string insertSql =
                    "INSERT INTO studentcourses (StudentId, CourseId) VALUES (@sid, @cid)";

                using var insertCmd = new MySqlCommand(insertSql, connection);
                insertCmd.Parameters.AddWithValue("@sid", StudentId);
                insertCmd.Parameters.AddWithValue("@cid", courseId);
                insertCmd.ExecuteNonQuery();
            }

            return RedirectToPage("/Students/Index");
        }

        public class CourseInfo
        {
            public int Id { get; set; }
            public string CourseName { get; set; } = "";
        }
    }
}