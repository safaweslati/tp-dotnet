using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Data.SqlTypes;
using System.Diagnostics;
using tp3dotnet.Models;

namespace tp3dotnet.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public void Connection()
        {
            SQLiteConnection dbCon = new SQLiteConnection("Data Source=C:\\Users\\safaw\\source\\repos\\tp3dotnet\\2022 GL3 .NET Framework TP3 - SQLite database.db");
            dbCon.Open();
            using (dbCon)
            {
                SQLiteCommand command = new SQLiteCommand("select * from personal_info", dbCon);
                SQLiteDataReader reader = command.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        int id = (int)reader["id"];
                        string first_name = (string)reader["first_name"];
                        string last_name = (string)reader["last_name"];
                        string email = (string)reader["email"];
                        DateTime date_birth = (DateTime)reader["date_birth"];
                        string image = (string)reader["image"];
                        string country = (string)reader["country"];
                        Debug.WriteLine("id = {0} first_name={1} last_name={2} email={3} date_birth = {4} image = {5} country = {6}", id, first_name, last_name, email, date_birth, image, country);
                    }

                }
            }
        }
    }
}