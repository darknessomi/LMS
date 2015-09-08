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
	public partial class BorrowerMenu : Form
	{
		public string id { get; set; }
		public BorrowerMenu ()
		{
			InitializeComponent ();
		}

		public BorrowerMenu (string id)
		{
			this.id = id;
			InitializeComponent ();
		}

		private void button3_Click (object sender, EventArgs e)
		{
			IssueBook f = new IssueBook ();
			f.Visible = true;
			this.Close ();
		}

		private void button4_Click (object sender, EventArgs e)
		{
			Login f = new Login ();
			f.Visible = true;
			this.Close ();
		}

		private void button1_Click (object sender, EventArgs e)
		{
			ManageBookDetails_self f1 = new ManageBookDetails_self ();
			f1.Visible = true;
			this.Close ();
		}

		private void button2_Click (object sender, EventArgs e)
		{
			UpdateBorrower_self f = new UpdateBorrower_self (id);
			f.Visible = true;
			this.Close ();

		}

		private void button5_Click (object sender, EventArgs e)
		{
			Login f = new Login ();
			f.Visible = true;
			this.Close ();
		}
	}
}
