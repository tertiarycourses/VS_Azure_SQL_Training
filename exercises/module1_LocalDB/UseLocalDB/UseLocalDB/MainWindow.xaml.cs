using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UseLocalDB {
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window {
		public MainWindow() {
			InitializeComponent();
			currentConnection.StateChange += Connection_StateChange;
		}

		private void Connection_StateChange(object sender, System.Data.StateChangeEventArgs e) {
			ConnectionState.Text = $"Current Connection State: {currentConnection.State.ToString()}";
		}

		private SqlConnection currentConnection = new SqlConnection();
		private void Button_Click(object sender, RoutedEventArgs e) {
			if (currentConnection.State == System.Data.ConnectionState.Open)
			{
				return;
			}
			string executable = System.Reflection.Assembly.GetExecutingAssembly().Location;
			string path = (System.IO.Path.GetDirectoryName(executable));
			AppDomain.CurrentDomain.SetData("DataDirectory", path);

			var connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Tours.mdf;Integrated Security=True";


			currentConnection.ConnectionString = connectionString;
			currentConnection.Open();

		

			var cmd = new SqlCommand("Select Comment from Testimonials", currentConnection);
			var reader = cmd.ExecuteReader();

			while (reader.Read())
			{
				TestimonialListBox.Items.Add(reader[0].ToString());
			}

		}

		private void CloseButton_Click(object sender, RoutedEventArgs e) {
			if (currentConnection.State != System.Data.ConnectionState.Closed)
			{
				TestimonialListBox.Items.Clear();
				currentConnection.Close();
			}
		
		}
	}
}
