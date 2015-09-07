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
	public partial class AddBorrower : Form
	{
		public AddBorrower ()
		{
			InitializeComponent ();
		}

		private void button1_Click (object sender, EventArgs e)
		{
			try {
				string myConnection = "datasource=localhost;port=3306;username=root;password=";
				string query = "insert into library.borrower_details(name, card_no, contact_no, fine) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','0');";
				string query_login = "insert into library.login_credential (username,id) values ('" + textBox1.Text + "','" + textBox2.Text + "');";
				MySqlConnection myConn = new MySqlConnection (myConnection);
				// MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
				MySqlCommand cmdDataBase = new MySqlCommand (query, myConn);
				MySqlCommand cmdDataBase_login = new MySqlCommand (query_login, myConn);
				MySqlDataReader myReader;
				MySqlDataReader myReader_login;

				myConn.Open ();
				//  DataSet ds = new DataSet();
				myReader = cmdDataBase.ExecuteReader ();


				while (myReader.Read ()) {

				}
				myConn.Close ();
				myConn.Open ();
				myReader_login = cmdDataBase_login.ExecuteReader ();
				while (myReader_login.Read ()) {

				}
				MessageBox.Show ("Saved");
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
