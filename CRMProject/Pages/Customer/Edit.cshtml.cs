using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MySqlConnector;

namespace CRMProject.Pages.Customer
{
    public class Edit : PageModel
    {
        private readonly ILogger<Edit> _logger;

        // ✅ Properties (Professional Naming)
        [BindProperty,Required]
        public int Id { get; set; }

        [BindProperty,Required]
        public string Name { get; set; } = "";

        [BindProperty,Required]
        public string Email { get; set; } = "";
        public string Phone { get; set; } = "";

        public string ErrorMessage { get; set; } = "";
        public string SuccessMessage { get; set; } = "";

        // ✅ Load data when page opens
        public void OnGet(int Id)
        {
            try
            {
                using (var connection = new MySqlConnection(
                    "Server=localhost;Port=3306;Database=dkte;Uid=root;Pwd=Harshu@87;"))
                {
                    connection.Open();

                    var command = new MySqlCommand(
                        "SELECT * FROM customers WHERE id = @id",
                        connection);

                    command.Parameters.AddWithValue("@id", Id);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Id = reader.GetInt32(0);
                            Name = reader.GetString(1);
                            Email = reader.GetString(2);
                            Phone = reader.GetString(3);
                        }
                        else
                        {
                            ErrorMessage = "Customer not found.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

        // ✅ Update data when form is submitted
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                using (var connection = new MySqlConnection(
                    "Server=localhost;Port=3306;Database=dkte;Uid=root;Pwd=Harshu@87;"))
                {
                    connection.Open();

                    var command = new MySqlCommand(
                        "UPDATE customers SET name=@name, email=@email, phone=@phone WHERE id=@id",
                        connection);

                    command.Parameters.AddWithValue("@name", Name);
                    command.Parameters.AddWithValue("@email", Email);
                    command.Parameters.AddWithValue("@phone", Phone);
                    command.Parameters.AddWithValue("@id", Id);

                    command.ExecuteNonQuery();
                }

                SuccessMessage = "Customer updated successfully!";
                return RedirectToPage("/Customer/Index");
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return Page();
            }
        }
    }
}