using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApplication6
{
	public partial class Return : Form
	{
		DateTime dt;
		int year;
		int month;
		int day;
		int fine;
		public string id { get; set; }
		string myConnection = DB.GetDB();
		public Return ()
		{
			this.id = "admin";
			InitializeComponent ();
			fillCombo1 ();
			fillCombo2 ();

		}

		public Return (string id)
		{
			this.id = id;
			InitializeComponent ();
			fillCombo1 ();
			fillCombo2 ();

		}

		void fillCombo1 ()
		{
			try {
				
				string query;
				if (id == null) {
					query = "select * from library.borrowed_books;";
				} else {
					query = "select * from library.borrowed_books where card_no='" + id + "';";
				}
				MySqlConnection myConn = new MySqlConnection (myConnection);
				// MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
				MySqlCommand cmdDataBase = new MySqlCommand (query, myConn);
				MySqlDataReader myReader;

				myConn.Open ();

				myReader = cmdDataBase.ExecuteReader ();

				while (myReader.Read ()) {
					string sname = myReader.GetString ("book_id");
//					string scopies = myReader.GetString ("no_of_copies");
//					int i = int.Parse (scopies);

					comboBox1.Items.Add (sname);

				}

				myConn.Close ();

			} catch (Exception ex) {
				MessageBox.Show (ex.Message);
			}
		}

		void fillCombo2 ()
		{
			try {
				string query;
				if (id == null) {
					query = "select * from library.borrowed_books;";
				} else {
					query = "select * from library.borrowed_books where card_no='" + id + "';";
				}
				MySqlConnection myConn = new MySqlConnection (myConnection);
				// MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
				MySqlCommand cmdDataBase = new MySqlCommand (query, myConn);
				MySqlDataReader myReader;

				myConn.Open ();

				myReader = cmdDataBase.ExecuteReader ();

				while (myReader.Read ()) {
					comboBox2.Items.Add (myReader.GetString ("card_no"));

				}

				myConn.Close ();

			} catch (Exception ex) {
				MessageBox.Show (ex.Message);
			}
		}

		public  void retdate ()
		{

			try {
				
//				MessageBox.Show("select * from library.borrowed_books where book_id=" + (string)comboBox1.SelectedItem + " and card_no=" + (string)comboBox2.SelectedItem + ";");
				string query = "select * from library.borrowed_books where book_id=" + (string)comboBox1.SelectedItem + " and card_no=" + (string)comboBox2.SelectedItem + ";";
				MySqlConnection myConn = new MySqlConnection (myConnection);
				//// MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
				MySqlCommand cmdDataBase = new MySqlCommand (query, myConn);
				MySqlDataReader myReader;

				myConn.Open ();

				myReader = cmdDataBase.ExecuteReader ();

				while (myReader.Read ()) {
					dt = Convert.ToDateTime (myReader.GetString ("due_date"));
					year = dt.Year;
					month = dt.Month;
					day = dt.Day;
//					MessageBox.Show (year.ToString () + month.ToString () + day.ToString ());

				}



				myConn.Close ();

				DateTime dt1 = System.DateTime.Now;
				int year1 = dt1.Year;
				int month1 = dt1.Month;
				int day1 = dt1.Day;
				int ret = year * 10000 + month * 100 + day;
				int ret1 = year1 * 10000 + month1 * 100 + day1;
				if (ret1 > ret) {
					fine = ret1 - ret;
					MessageBox.Show("You have been fined $" + fine.ToString());
				}

			} catch (Exception ex) {
				MessageBox.Show (ex.Message);
			}





		}

		void retfine ()
		{

			try {
				
				string query = "select * from library.borrower_details where card_no='" + (string)comboBox2.SelectedItem + "';";
				MySqlConnection myConn = new MySqlConnection (myConnection);
				//// MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
				MySqlCommand cmdDataBase = new MySqlCommand (query, myConn);
				MySqlDataReader myReader;

				myConn.Open ();

				myReader = cmdDataBase.ExecuteReader ();
				int fineold;
				while (myReader.Read ()) {
					fineold = int.Parse (myReader.GetString ("fine"));
					fine += fineold;
				}



				myConn.Close ();



			} catch (Exception ex) {
				MessageBox.Show (ex.Message);
			}



		}

		void finecal ()
		{

			retfine ();
			try {

				
				string query = "update library.borrower_details set fine=" + fine.ToString () + " where card_no='" + (string)comboBox2.SelectedItem + "';";
				MySqlConnection myConn = new MySqlConnection (myConnection);
				MySqlCommand cmdDataBase = new MySqlCommand (query, myConn);
				MySqlDataReader myReader;


				myConn.Open ();
				myReader = cmdDataBase.ExecuteReader ();



				MessageBox.Show ("Returned");

				while (myReader.Read ()) {
				}



				myConn.Close ();

			} catch (Exception ex) {
				MessageBox.Show (ex.Message);
			}

		}

		void add_copies ()
		{

			try {

				
				string query = "update library.book_database set no_of_copies=no_of_copies+1 where book_id='" + (string)comboBox1.SelectedItem + "';";
				MySqlConnection myConn = new MySqlConnection (myConnection);
				MySqlCommand cmdDataBase = new MySqlCommand (query, myConn);
				MySqlDataReader myReader;


				myConn.Open ();
				myReader = cmdDataBase.ExecuteReader ();
				while (myReader.Read ()) {
				}

				myConn.Close ();

			} catch (Exception ex) {
				MessageBox.Show (ex.Message);
			}

		}

		private void button1_Click (object sender, EventArgs e)
		{

			try {
				retdate ();
				finecal ();
				add_copies ();
				string query = "delete from library.borrowed_books where book_id='" + (string)comboBox1.SelectedItem + "' and card_no='" + (string)comboBox2.SelectedItem + "';";
				MySqlConnection myConn = new MySqlConnection (myConnection);
				// MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
				MySqlCommand cmdDataBase = new MySqlCommand (query, myConn);
				MySqlDataReader myReader;

				myConn.Open ();
				//  DataSet ds = new DataSet();
				myReader = cmdDataBase.ExecuteReader ();
				myConn.Close ();



			} catch (Exception ex) {
				MessageBox.Show (ex.Message);
			}
		}

		private void button2_Click (object sender, EventArgs e)
		{
			if (id == "admin") {
				ManageBookDetails f = new ManageBookDetails ();
				f.Visible = true;
			} else {
				ManageBookDetails_self f = new ManageBookDetails_self ();
				f.Visible = true;
			}
			this.Close ();
		}
	}
}
