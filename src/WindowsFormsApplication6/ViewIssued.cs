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
	public partial class ViewIssued : Form
	{
		public string id { get; set; }


		public ViewIssued ()
		{
			this.id = "admin";
			InitializeComponent ();
		}

		public ViewIssued (string id)
		{
			this.id = id;
			InitializeComponent ();
		}

		private void ViewIssued_Load (object sender, EventArgs e)
		{
			try {
				string query;
				if (id == null) {
					query = "select * from library.borrowed_books;";
				} else {
					query = "select * from library.borrowed_books where card_no='" + id + "';";
				}
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

		private void Back_Click (object sender, EventArgs e)
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
