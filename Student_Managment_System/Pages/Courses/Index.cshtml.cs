using Microsoft.AspNetCore.Mvc.RazorPages;
using MySqlConnector;
using System.Collections.Generic;

namespace Student_Managment_System.Pages.Courses
{
    public class IndexModel : PageModel
    {
        public List<CourseInfo> CoursesList = new List<CourseInfo>();

        public void OnGet()
        {
            using (var connection = new MySqlConnection(
                "Server=localhost;Port=3306;Database=studentdb;Uid=root;Pwd=Harshu@87;"))
            {
                connection.Open();

                var command = new MySqlCommand(
                    "SELECT * FROM Courses", connection);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        CoursesList.Add(new CourseInfo
                        {
                            Id = reader.GetInt32("Id"),
                            CourseName = reader.GetString("CourseName"),
                            Credits = reader.GetInt32("Credits")
                        });
                    }
                }
            }
        }

        public class CourseInfo
        {
            public int Id { get; set; }
            public string CourseName { get; set; } = "";
            public int Credits { get; set; }
        }
    }
}