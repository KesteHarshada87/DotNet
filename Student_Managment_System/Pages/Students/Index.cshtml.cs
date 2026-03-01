using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySqlConnector;
using System.Collections.Generic;

namespace Student_Managment_System.Pages.Students
{
    public class IndexModel : PageModel
    {
        public List<StudentInfo> StudentsList { get; set; } = new();

        [BindProperty(SupportsGet = true)]
        public string? SearchTerm { get; set; }

        public void OnGet()
        {
            using (var connection = new MySqlConnection(
                "Server=localhost;Port=3306;Database=studentdb;Uid=root;Pwd=Harshu@87;"))
            {
                connection.Open();

                string sql = @"
                    SELECT s.Id, s.Name, s.Email,
                    GROUP_CONCAT(c.CourseName SEPARATOR ', ') AS Courses
                    FROM students s
                    LEFT JOIN studentcourses sc ON s.Id = sc.StudentId
                    LEFT JOIN courses c ON sc.CourseId = c.Id
                ";

                if (!string.IsNullOrWhiteSpace(SearchTerm))
                {
                    sql += " WHERE s.Name LIKE @search OR s.Email LIKE @search ";
                }

                sql += " GROUP BY s.Id, s.Name, s.Email";

                var command = new MySqlCommand(sql, connection);

                if (!string.IsNullOrWhiteSpace(SearchTerm))
                {
                    command.Parameters.AddWithValue("@search", "%" + SearchTerm + "%");
                }

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        StudentsList.Add(new StudentInfo
                        {
                            Id = reader.GetInt32("Id"),
                            Name = reader.GetString("Name"),
                            Email = reader.GetString("Email"),
                            Courses = reader["Courses"]?.ToString() ?? ""
                        });
                    }
                }
            }
        }

        public class StudentInfo
        {
            public int Id { get; set; }
            public string Name { get; set; } = "";
            public string Email { get; set; } = "";
            public string Courses { get; set; } = "";
        }
    }
}