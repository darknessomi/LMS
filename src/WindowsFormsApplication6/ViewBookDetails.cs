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
	public partial class ViewBookDetails : Form
	{
		public string id { get; set; }
		
		public ViewBookDetails ()
		{
			this.id = "admin";
			InitializeComponent ();
		}
		public ViewBookDetails (string id)
		{
			this.id = id;
			InitializeComponent ();
		}

		private void ViewBookDetails_Load (object sender, EventArgs e)
		{
			try {
				
				string query = "select * from library.book_database ;";
				MySqlConnection myConn = DB.GetDB();

				MySqlCommand cmdDataBase = new MySqlCommand (query, myConn);
				// MySqlDataReader myReader;

				MySqlDataAdapter sda = new MySqlDataAdapter ();
				sda.SelectCommand = cmdDataBase;
				DataTable dbDataset = new DataTable ();
				sda.Fill (dbDataset);
				BindingSource bsource = new BindingSource ();
				bsource.DataSource = dbDataset;
				dataGridView1.DataSource = bsource;
				sda.Update (dbDataset);

			} catch (Exception ex) {
				MessageBox.Show (ex.Message);
			}
		}

		private void button1_Click (object sender, EventArgs e)
		{
			if (id == "admin") {
				ManageBookDetails f = new ManageBookDetails ();
				f.Visible = true;
			} else {
				ManageBookDetails_self f = new ManageBookDetails_self (id);
				f.Visible = true;
			}
			this.Close ();
		}
	}
}
