/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MySqlConnector;

namespace CRLproject.Pages.customers;
{
    public class index : PageModel
    {
        public List<CustomerInfo> listCustomers { get; set; } = []; 
        // public void OnGet() 
        // { 
            
        // }
        
        private readonly ILogger<index> _logger;

        public index(ILogger<index> logger)
        {
            _logger = logger;
        }

       public void OnGet()
        {
             { 
            try{ 
            using (var connection = new MySqlConnection 
("Server=localhost;Port=3306;Database=dkte;Uid=root;Pwd=root;")) 
            { 
                connection.Open();    
                var command = new MySqlCommand("SELECT * FROM customers", 
connection); 
                using (var reader = command.ExecuteReader()) 
                { 
                    while (reader.Read()) 
                    { 
                        listCustomers.Add(new CustomerInfo 
                        { 
                            Id = reader.GetInt32(0),    
                            Name = reader.GetString(1), 
                            Email = reader.GetString(2), 
                            Phone = reader.GetString(3) 
                        }); 
                    } 
                } 
            } 
            } 
            catch (Exception ex)            { 
                Console.WriteLine($"Error retrieving customers: {ex.Message}"); 
             
            }    
            

        }
        public class CustomerInfo 
            { 
           public int Id { get; set; } 
            public string Name { get; set; } 
            public string Email { get; set; } 
            public string Phone { get; set; } 
            } 

    }
}
}
*/
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MySqlConnector;

namespace CRLproject.Pages.Customer
{
    public class IndexModel : PageModel
    {
        public List<CustomerInfo> listCustomers { get; set; }
            = new List<CustomerInfo>();

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            try
            {
                using (var connection = new MySqlConnection(
                    "Server=localhost;Port=3306;Database=dkte;Uid=root;Pwd=Harshu@87;"))
                {
                    connection.Open();

                    var command = new MySqlCommand(
                        "SELECT * FROM customers", connection);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listCustomers.Add(new CustomerInfo
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Email = reader.GetString(2),
                                Phone = reader.GetString(3)
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving customers: {ex.Message}");
            }
        }

        public class CustomerInfo
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
        }
    }
}