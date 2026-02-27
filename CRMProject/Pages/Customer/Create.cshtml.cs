using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace CRMproject.Pages.Customers
{
    public class create : PageModel
    {
         [BindProperty, Required(ErrorMessage = "Enter the name")] 
        public string name { get; set; } =""; 
        [BindProperty, Required(ErrorMessage = "Enter the email"), 
EmailAddress(ErrorMessage = "Invalid email format")] 
        public string email { get; set; } =""; 
        [BindProperty, Required(ErrorMessage = "Enter the phone number")] 
        public string phone { get; set; }="";
        public string ErrorMessage { get; private set; }

        private readonly ILogger<create> _logger;

        public create(ILogger<create> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }

        public void OnPost() 
        { 
            if (!ModelState.IsValid) 
            { 
                 Console.WriteLine("Form is Invalid"); 
                return; 
            } 
            try 
            { 
                using (var connection = new MySqlConnector.MySqlConnection("Server=localhost;Port=3306;Database=dkte;Uid=root;Pwd=Harshu@87;")) 
                { 
                    connection.Open();    
                    var command = new MySqlConnector.MySqlCommand("INSERT INTO Customers (name, email, phone) VALUES (@CustName, @CustEmail, @CustPhone)", connection); 
                    command.Parameters.AddWithValue("@CustName", name); 
                    command.Parameters.AddWithValue("@CustEmail", email); 
                    command.Parameters.AddWithValue("@CustPhone", phone); 
                    int i= command.ExecuteNonQuery();
                    if (i > 0)
                    {
                        Console.WriteLine("Customer added successfully");
                        RedirectToPage("/Customer/Index");
                    }
                    else
                    {
                        Console.WriteLine("Failed to add customer");
                    }
                }      
            } 
            catch (Exception ex) 
            { 
                Console.WriteLine("Error adding customer."+$"Error: {ex.Message}"); 
                ErrorMessage = ex.Message; 
                return; 
            } 
 
            Response.Redirect("/Customer/Index"); 
        }

        
    }
}