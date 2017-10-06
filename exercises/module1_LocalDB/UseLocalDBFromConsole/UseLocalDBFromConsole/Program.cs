using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseLocalDBFromConsole {
  class Program {
    static void Main(string[] args) {
      var currentConnection = new SqlConnection();
      if (currentConnection.State == System.Data.ConnectionState.Open)
      {
        return;
      }
      string executable = System.Reflection.Assembly.GetExecutingAssembly().Location;
      string path = (System.IO.Path.GetDirectoryName(executable));
      AppDomain.CurrentDomain.SetData("DataDirectory", path);


      var connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\NorthwindV13.mdf;Integrated Security=True";


      currentConnection.ConnectionString = connectionString;
      currentConnection.Open();

      var cmd = new SqlCommand("Select * from Shippers", currentConnection);
      var reader = cmd.ExecuteReader();

      reader.Read();

      Console.WriteLine(reader.GetString(1));
      Console.ReadLine();
    }
  }
}
