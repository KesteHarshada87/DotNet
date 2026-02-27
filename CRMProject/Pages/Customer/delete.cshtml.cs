using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySqlConnector;

namespace CRMProject.Pages.Customer
{
    public class Delete : PageModel
    {
        [BindProperty]
        public int Id { get; set; }

        public string Name { get; set; } = "";

        public string ErrorMessage { get; set; } = "";

        // Load customer details before delete
        public IActionResult OnGet(int Id)
        {
            this.Id = Id;

            try
            {
                using (var connection = new MySqlConnection(
                    "Server=localhost;Port=3306;Database=dkte;Uid=root;Pwd=Harshu@87;"))
                {
                    connection.Open();

                    var command = new MySqlCommand(
                        "SELECT name FROM customers WHERE id=@id",
                        connection);

                    command.Parameters.AddWithValue("@id", Id);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Name = reader.GetString(0);
                        }
                        else
                        {
                            return RedirectToPage("/Customer/Index");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }

            return Page();
        }

        // Delete after confirmation
        public IActionResult OnPost()
        {
            try
            {
                using (var connection = new MySqlConnection(
                    "Server=localhost;Port=3306;Database=dkte;Uid=root;Pwd=Harshu@87;"))
                {
                    connection.Open();

                    var command = new MySqlCommand(
                        "DELETE FROM customers WHERE id=@id",
                        connection);

                    command.Parameters.AddWithValue("@id", Id);

                    command.ExecuteNonQuery();
                }

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