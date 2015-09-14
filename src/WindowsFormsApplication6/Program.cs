using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApplication6
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main ()
		{
			Application.EnableVisualStyles ();
			Application.SetCompatibleTextRenderingDefault (false);
			Application.Run (new Login ());
		}
	}
	static class DB
	{
		public static MySqlConnection GetDB()
		{
			MySqlConnection myConn = new MySqlConnection ("datasource=qingdao.imomi.info;port=3306;username=root;password=005623");
			return myConn;
		}
	}
}
