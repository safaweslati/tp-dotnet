using System.Data.SQLite;

namespace tp3dotnet.Models
{
    public class Personal_info
    {
        public List<Person> GetAllPerson()
        {
            List<Person> list = new List<Person>();
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
                        Person person = new Person();
                        person.id = (int)reader["id"];
                        person.first_name = (string)reader["first_name"];
                        person.last_name = (string)reader["last_name"];
                        person.email = (string)reader["email"];
//                        person.Date_birth = (DateTime)reader["date_birth"];
                        person.image = (string)reader["image"];
                        person.country = (string)reader["country"];
                        list.Add(person);
                    }
                }
                dbCon.Close();
            }
            return list;
        }
        public Person GetPerson(int id) {
            {
                List<Person> list = GetAllPerson();
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].id == id)
                    {
                        return list[i];
                    }
                }
                return null;

            }
        }
    }
}
