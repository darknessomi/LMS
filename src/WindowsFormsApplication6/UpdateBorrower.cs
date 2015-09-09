﻿using System;
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
	public partial class UpdateBorrower : Form
	{

		public UpdateBorrower ()
		{
			InitializeComponent ();
			fillCombo ();
		}

		void fillCombo ()
		{
			try {
				
				string query = "select * from library.borrower_details ";
				MySqlConnection myConn = DB.GetDB();
				// MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
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
				
				string query = "update library.borrower_details set name='" + textBox1.Text + "', contact_no='" + textBox2.Text + "', fine='" + textBox4.Text + "' where card_no='" + (string)comboBox1.SelectedItem + "';";
				string query_login = "update library.login_credential set username='" + textBox1.Text + "' , password='" + textBox3.Text + "' where id='" + (string)comboBox1.SelectedItem + "';";
				MySqlConnection myConn = DB.GetDB();

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
				MessageBox.Show ("Updated");
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
