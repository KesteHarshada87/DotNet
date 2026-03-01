using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySqlConnector;

namespace Student_Managment_System.Pages.Courses
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public int Id { get; set; }

        [BindProperty]
        public string CourseName { get; set; } = "";

        [BindProperty]
        public int Credits { get; set; }

        public void OnGet(int id)
        {
            using (var connection = new MySqlConnection(
                "Server=localhost;Port=3306;Database=studentdb;Uid=root;Pwd=Harshu@87;"))
            {
                connection.Open();

                var command = new MySqlCommand(
                    "SELECT * FROM Courses WHERE Id=@id", connection);

                command.Parameters.AddWithValue("@id", id);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Id = reader.GetInt32("Id");
                        CourseName = reader.GetString("CourseName");
                        Credits = reader.GetInt32("Credits");
                    }
                }
            }
        }

        public IActionResult OnPost()
        {
            using (var connection = new MySqlConnection(
                "Server=localhost;Port=3306;Database=studentdb;Uid=root;Pwd=Harshu@87;"))
            {
                connection.Open();

                var command = new MySqlCommand(
                    "UPDATE Courses SET CourseName=@name, Credits=@credits WHERE Id=@id",
                    connection);

                command.Parameters.AddWithValue("@name", CourseName);
                command.Parameters.AddWithValue("@credits", Credits);
                command.Parameters.AddWithValue("@id", Id);

                command.ExecuteNonQuery();
            }

            return RedirectToPage("/Courses/Index");
        }
    }
}