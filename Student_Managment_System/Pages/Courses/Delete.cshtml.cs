using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySqlConnector;

namespace Student_Managment_System.Pages.Courses
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public int Id { get; set; }

        public string CourseName { get; set; } = "";
        public int Credits { get; set; }

        public IActionResult OnGet(int id)
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
                    else
                    {
                        return RedirectToPage("/Courses/Index");
                    }
                }
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            using (var connection = new MySqlConnection(
                "Server=localhost;Port=3306;Database=studentdb;Uid=root;Pwd=Harshu@87;"))
            {
                connection.Open();

                var command = new MySqlCommand(
                    "DELETE FROM Courses WHERE Id=@id", connection);

                command.Parameters.AddWithValue("@id", Id);
                command.ExecuteNonQuery();
            }

            return RedirectToPage("/Courses/Index");
        }
    }
}