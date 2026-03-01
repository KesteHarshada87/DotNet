using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySqlConnector;

namespace Student_Managment_System.Pages.Courses
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public string CourseName { get; set; } = "";

        [BindProperty]
        public int Credits { get; set; }

        public IActionResult OnPost()
        {
            using (var connection = new MySqlConnection(
                "Server=localhost;Port=3306;Database=studentdb;Uid=root;Pwd=Harshu@87;"))
            {
                connection.Open();

                var command = new MySqlCommand(
                    "INSERT INTO Courses (CourseName, Credits) VALUES (@name, @credits)",
                    connection);

                command.Parameters.AddWithValue("@name", CourseName);
                command.Parameters.AddWithValue("@credits", Credits);

                command.ExecuteNonQuery();
            }

            return RedirectToPage("/Courses/Index");
        }
    }
}