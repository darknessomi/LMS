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
	public partial class DeleteBorrower : Form
	{
		public DeleteBorrower ()
		{
			InitializeComponent ();
			fillCombo ();
		}

		void fillCombo ()
		{
			try {
				string myConnection = "datasource=localhost;port=3306;username=root;password=";
				string query = "select * from library.borrower_details ";
				MySqlConnection myConn = new MySqlConnection (myConnection);
				// MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
				MySqlCommand cmdDataBase = new MySqlCommand (query, myConn);
				MySqlDataReader myReader;

				myConn.Open ();

				myReader = cmdDataBase.ExecuteReader ();

				while (myReader.Read ()) {
					string sname = myReader.GetString ("card_no");
					comboBox1.Items.Add (sname);

				}




				myConn.Close ();

			} catch (Exception ex) {
				MessageBox.Show (ex.Message);
			}
		}

		private void button1_Click (object sender, EventArgs e)
		{
			try {
				string myConnection = "datasource=localhost;port=3306;username=root;password=";
				string query = "delete from library.borrower_details where card_no='" + (string)comboBox1.SelectedItem + "';";
				string query_login = "delete from library.login_credential where id='" + (string)comboBox1.SelectedItem + "';";
				MySqlConnection myConn = new MySqlConnection (myConnection);

				MySqlCommand cmdDataBase = new MySqlCommand (query, myConn);
				MySqlCommand cmdDataBase_login = new MySqlCommand (query_login, myConn);
				MySqlDataReader myReader;
				MySqlDataReader myReader_login;

				myConn.Open ();

				myReader = cmdDataBase.ExecuteReader ();

				while (myReader.Read ()) {

				}
					
				myConn.Close ();
				myConn.Open ();
				myReader_login = cmdDataBase_login.ExecuteReader ();
				while (myReader_login.Read ()) {

				}
				MessageBox.Show ("Deleted");
				myConn.Close ();

			} catch (Exception ex) {
				MessageBox.Show (ex.Message);
			}
		}

		private void button2_Click (object sender, EventArgs e)
		{
			ManageBorrower f = new ManageBorrower ();
			f.Visible = true;
			this.Close ();
		}
	}
}
