using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySqlConnector;

namespace Student_Managment_System.Pages.Account
{
    public class LoginModel : PageModel
    {
        public string ErrorMessage { get; set; }

        public IActionResult OnPost(string Username, string Password)
        {
            using (var connection = new MySqlConnection(
                "Server=localhost;Port=3306;Database=studentdb;Uid=root;Pwd=Harshu@87;"))
            {
                connection.Open();

                string sql = "SELECT * FROM Users WHERE Username=@username AND Password=@password";

                var command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@username", Username);
                command.Parameters.AddWithValue("@password", Password);

                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    HttpContext.Session.SetString("User", Username);
                    return RedirectToPage("/Students/Index");
                }
            }

            ErrorMessage = "Invalid Username or Password";
            return Page();
        }
    }
}