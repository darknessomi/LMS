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
	public partial class Login : Form
	{
		string myConnection = DB.GetDB ();

		public Login ()
		{
			InitializeComponent ();
		}

		private void button1_Click (object sender, EventArgs e)
		{
			try {
				
				MySqlConnection myConn = new MySqlConnection (myConnection);
				// MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
				MySqlCommand SelectCommand = new MySqlCommand ("select * from library.login_credential where username='" + textBox1.Text + "' and password='" + textBox2.Text + "';", myConn);
				MySqlDataReader myReader;

				myConn.Open ();
				//  DataSet ds = new DataSet();
				myReader = SelectCommand.ExecuteReader ();
				int count = 0;
				while (myReader.Read ()) {
					count++;
				}

				if (count == 1) {
					if (int.Parse (myReader.GetString ("id")) < 500) {
						MainMenu f1 = new MainMenu ();
						f1.Visible = true;
						this.Hide ();
					} else {
						BorrowerMenu f1 = new BorrowerMenu (myReader.GetString ("id"));
						f1.Visible = true;
						this.Hide ();
					}
				} else {
					MessageBox.Show ("Incorrect username/password");
				}
                
				myConn.Close ();

			} catch (Exception ex) {
				MessageBox.Show (ex.Message);
			}
		}
	}
}
