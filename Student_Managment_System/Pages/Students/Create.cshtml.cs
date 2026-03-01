using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySqlConnector;
using System.ComponentModel.DataAnnotations;

namespace Student_Managment_System.Pages.Students
{
    public class CreateModel : PageModel
    {
        [BindProperty, Required]
        public string Name { get; set; } = "";

        [BindProperty, Required, EmailAddress]
        public string Email { get; set; } = "";

        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("User") == null)
            {
                return RedirectToPage("/Account/Login");
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (HttpContext.Session.GetString("User") == null)
            {
                return RedirectToPage("/Account/Login");
            }

            if (!ModelState.IsValid)
                return Page();

            using (var connection = new MySqlConnection(
                "Server=localhost;Port=3306;Database=studentdb;Uid=root;pwd=Harshu@87"))
            {
                connection.Open();
                var command = new MySqlCommand(
                    "INSERT INTO Students (Name, Email) VALUES (@name, @email)", connection
                );

                command.Parameters.AddWithValue("@name", Name);
                command.Parameters.AddWithValue("@email", Email);

                command.ExecuteNonQuery();
            }

            return RedirectToPage("/Students/Index");
        }
    }
}