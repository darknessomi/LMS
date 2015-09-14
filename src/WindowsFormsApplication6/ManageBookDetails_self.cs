using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication6
{
	public partial class ManageBookDetails_self : Form
	{
		public string id { get; set; }
		public ManageBookDetails_self ()
		{
			InitializeComponent ();
		}

		public ManageBookDetails_self (string id)
		{
			this.id = id;
			InitializeComponent ();
		}
			
		private void button4_Click (object sender, EventArgs e)
		{
			ViewBookDetails f = new ViewBookDetails (id);
			f.Visible = true;
			this.Close ();
		}

		private void button5_Click (object sender, EventArgs e)
		{
			ViewIssued f = new ViewIssued (id);
			f.Visible = true;
			this.Close ();
		}

		private void button6_Click (object sender, EventArgs e)
		{
			Return f = new Return (id);
			f.Visible = true;
			this.Close ();
		}

		private void button7_Click (object sender, EventArgs e)
		{
			BorrowerMenu f = new BorrowerMenu (id);
			f.Visible = true;
			this.Close ();
		}
	}
}
