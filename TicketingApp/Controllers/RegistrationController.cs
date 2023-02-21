using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using TicketingApp.Models;

namespace TicketingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

  
    public class RegistrationController : ControllerBase
    {
    
        [HttpPost]
        [Route("Signup")]
        public string Registration(Registration reg_obj)
        {
            SqlConnection connection = new SqlConnection("Server=(localdb)\\MSSQLLocalDB; Database=TicketApp; Trusted_Connection=True");
            SqlCommand command = new SqlCommand("INSERT INTO [User](Name,Password) VALUES('"+reg_obj.Name+ "','"+reg_obj.Password+"')", connection);
            connection.Open();
            int record = command.ExecuteNonQuery();
            connection.Close();
            if (record>0)
            {
                return "User Added";
            }
            else
            {
                return "Error";
            }
        }

        [HttpPost]
        [Route("Login")]
        public string Login(Registration reg_obj)
        {
            SqlConnection connection = new SqlConnection("Server=(localdb)\\MSSQLLocalDB; Database=TicketApp; Trusted_Connection=True");
            SqlDataAdapter command = new SqlDataAdapter("SELECT * FROM [User] WHERE Name='" + reg_obj.Name + "' AND Password='" + reg_obj.Password +"'", connection);
            DataTable datatable = new DataTable();
            command.Fill(datatable);
            if (datatable.Rows.Count > 0)
            {
                return "Logged In";
            }
            else
            {
                return "Invalid User"; 
            }
        }

    }
}
