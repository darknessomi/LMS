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
    
	public partial class IssueBook : Form
	{
		//int d, m, y;
		int n = 0;

		public string id { get; set; }


		public IssueBook (string id)
		{
			this.id = id;
			InitializeComponent ();
		}
		public IssueBook ()
		{
			this.id = "admin";
			InitializeComponent ();
		}

		private void IssueBook_Load (object sender, EventArgs e)
		{
			fillCombo1 ();
			fillCombo2 ();
		}


		void fillCombo1 ()
		{
			try {
				
				string query = "select * from library.book_database ";
				MySqlConnection myConn = DB.GetDB();
				// MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
				MySqlCommand cmdDataBase = new MySqlCommand (query, myConn);
				MySqlDataReader myReader;

				myConn.Open ();

				myReader = cmdDataBase.ExecuteReader ();

				while (myReader.Read ()) {
					string sname = myReader.GetString ("book_id");
					string scopies = myReader.GetString ("no_of_copies");
					int i = int.Parse (scopies);
					if (i > 0)
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
				
				if (this.id == "admin") {
					string query = "select * from library.borrower_details ";
					MySqlConnection myConn = DB.GetDB();
					// MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
					MySqlCommand cmdDataBase = new MySqlCommand (query, myConn);
					MySqlDataReader myReader;

					myConn.Open ();

					myReader = cmdDataBase.ExecuteReader ();

					while (myReader.Read ()) {
						string sname = myReader.GetString ("card_no");
						comboBox2.Items.Add (sname);

					}




					myConn.Close ();
				}else{
					comboBox2.Items.Add (this.id);
				}

			} catch (Exception ex) {
				MessageBox.Show (ex.Message);
			}
		}

		private void button1_Click (object sender, EventArgs e)
		{
			string y1 = dateTimePicker1.Value.Year.ToString ();
			string y2 = dateTimePicker2.Value.Year.ToString ();
			string m1 = dateTimePicker1.Value.Month.ToString ();
			string m2 = dateTimePicker2.Value.Month.ToString ();
			string d1 = dateTimePicker1.Value.Day.ToString ();
			string d2 = dateTimePicker2.Value.Day.ToString ();
			//d = int.Parse(d2);
			//m = int.Parse(m2);
			//y = int.Parse(y2);
            
			try {
				
				string query = "insert into library.borrowed_books(book_id, card_no, issue_date, due_date) values ('" + (string)comboBox1.SelectedItem + "','" + (string)comboBox2.SelectedItem + "','" + y1 + "-" + m1 + "-" + d1 + "','" + y2 + "-" + m2 + "-" + d2 + "');";
				MySqlConnection myConn = DB.GetDB();
				// MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
				MySqlCommand cmdDataBase = new MySqlCommand (query, myConn);
				MySqlDataReader myReader;

				myConn.Open ();
				//  DataSet ds = new DataSet();
				myReader = cmdDataBase.ExecuteReader ();
				myConn.Close ();
				change ();
				fun ();
                

			} catch (Exception ex) {
				MessageBox.Show (ex.Message);
			}
		}

		void change ()
		{
			try {
				
				string query = "select no_of_copies from library.book_database where book_id='" + (string)comboBox1.SelectedItem + "';";
				MySqlConnection myConn = DB.GetDB();
				//// MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
				MySqlCommand cmdDataBase = new MySqlCommand (query, myConn);
				MySqlDataReader myReader;

				myConn.Open ();

				myReader = cmdDataBase.ExecuteReader ();
				string sno;
                
				while (myReader.Read ()) {
					sno = myReader.GetString ("no_of_copies");
                    
					n = int.Parse (sno);
				}

				n = n - 1;

				myConn.Close ();
			} catch (Exception ex) {
				MessageBox.Show (ex.Message);
			}
		}

		void fun ()
		{
			try {

				
				string query = "update library.book_database set no_of_copies=" + n.ToString () + " where book_id='" + (string)comboBox1.SelectedItem + "';";
				MySqlConnection myConn = DB.GetDB();
				MySqlCommand cmdDataBase = new MySqlCommand (query, myConn);
				MySqlDataReader myReader;


				myConn.Open ();
				myReader = cmdDataBase.ExecuteReader ();
                
				MessageBox.Show ("Issued");

				while (myReader.Read ()) {
				}

				myConn.Close ();

			} catch (Exception ex) {
				MessageBox.Show (ex.Message);
			}


		}

		private void button2_Click (object sender, EventArgs e)
		{
			MainMenu f = new MainMenu ();
			f.Visible = true;
			this.Close ();
		}
	}
        
    


}





    


