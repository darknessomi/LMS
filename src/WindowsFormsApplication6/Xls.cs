using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using ExcelLibrary.SpreadSheet;

namespace WindowsFormsApplication6
{
	public class Xls
	{
		int line = 0;

		public Xls ()
		{
		}

		public void ExportBook ()
		{
			try {
				string file = "LMS_ExportBook.xls";
				string query = "select * from library.book_database ;";
				MySqlConnection myConn = DB.GetDB ();

				MySqlCommand cmdDataBase = new MySqlCommand (query, myConn);
				MySqlDataReader myReader;

				myConn.Open ();
				myReader = cmdDataBase.ExecuteReader ();
				Workbook workbook = new Workbook ();
				Worksheet worksheet = new Worksheet ("Book Sheet");
				worksheet.Cells [0, 0] = new Cell ("Book ID");
				worksheet.Cells [0, 1] = new Cell ("Book Title");
				worksheet.Cells [0, 2] = new Cell ("Book Author");
				worksheet.Cells [0, 3] = new Cell ("Book Genre");
				worksheet.Cells [0, 4] = new Cell ("Book Copies");
				worksheet.Cells [0, 5] = new Cell (DateTime.Now, @"YYYY\-MM\-DD");
				line = 1;
				while (myReader.Read ()) {
					worksheet.Cells [line, 0] = new Cell (myReader.GetString ("book_id"));
					worksheet.Cells [line, 1] = new Cell (myReader.GetString ("title"));
					worksheet.Cells [line, 2] = new Cell (myReader.GetString ("author"));
					worksheet.Cells [line, 3] = new Cell (myReader.GetString ("genre"));
					worksheet.Cells [line, 4] = new Cell (myReader.GetString ("no_of_copies"));
					line++;
				}
				myConn.Close ();
				worksheet.Cells.ColumnWidth [0, 1] = 3000;
				workbook.Worksheets.Add (worksheet);
				workbook.Save (file);
				MessageBox.Show ("Export Success\n" + (line - 1) + " data is exported");
			} catch (Exception ex) {
				MessageBox.Show (ex.Message);
			}
		}

		public void ImportBook ()
		{
			try {
				string file = "LMS_ImportBook.xls";
				MySqlConnection myConn = DB.GetDB ();
				MySqlDataReader myReader;
				FileStream fileStream = new FileStream (file, FileMode.Open);
				Workbook workbook = Workbook.Load (fileStream);
				Worksheet worksheet = workbook.Worksheets [0];
				line = 0;
				for (int i = 1; i <= worksheet.Cells.LastRowIndex; i++) {
					myConn.Open ();
					string query = "insert into library.book_database(book_id, title, author, genre, no_of_copies) values ('" + worksheet.Cells [i, 0] + "','" + worksheet.Cells [i, 1] + "','" + worksheet.Cells [i, 2] + "','" + worksheet.Cells [i, 3] + "'," + worksheet.Cells [i, 4] + ");";
					MySqlCommand cmdDataBase = new MySqlCommand (query, myConn);
					myReader = cmdDataBase.ExecuteReader ();
					while (myReader.Read ()) {

					}
					myConn.Close ();
					line++;
				}
				fileStream.Close ();

				MessageBox.Show ("Import Success\n" + line + " data is exported");
			} catch (Exception ex) {
				MessageBox.Show (ex.Message);
			}
		}

		public void ExportBorrower ()
		{
			try {
				string file = "LMS_ExportBorrower.xls";
				string query = "select * from library.borrower_details ;";
				string query_login = "select * from library.login_credential ;";
				MySqlConnection myConn = DB.GetDB ();

				MySqlCommand cmdDataBase = new MySqlCommand (query, myConn);
				MySqlDataReader myReader;


				myConn.Open ();
				myReader = cmdDataBase.ExecuteReader ();
				Workbook workbook = new Workbook ();
				Worksheet worksheet = new Worksheet ("Borrower Sheet");
				worksheet.Cells [0, 0] = new Cell ("Borrower ID");
				worksheet.Cells [0, 1] = new Cell ("Borrower Name");
				worksheet.Cells [0, 2] = new Cell ("Borrower Contact");
				worksheet.Cells [0, 3] = new Cell ("Borrower Fine");
				worksheet.Cells [0, 4] = new Cell ("Borrower Passwd");
				worksheet.Cells [0, 5] = new Cell (DateTime.Now, @"YYYY\-MM\-DD");
				line = 2;
				while (myReader.Read ()) {
					worksheet.Cells [line, 2] = new Cell (myReader.GetString ("contact_no"));
					worksheet.Cells [line, 3] = new Cell (myReader.GetString ("fine"));
					line++;
				}
				myConn.Close ();
				MySqlCommand cmdDataBase_login = new MySqlCommand (query_login, myConn);
				MySqlDataReader myReader_login;
				myConn.Open ();
				myReader_login = cmdDataBase_login.ExecuteReader ();
				line = 1;
				while (myReader_login.Read ()) {
					worksheet.Cells [line, 0] = new Cell (myReader_login.GetString ("id"));
					worksheet.Cells [line, 1] = new Cell (myReader_login.GetString ("username"));
					worksheet.Cells [line, 4] = new Cell (myReader_login.GetString ("password"));
					line++;
				}
				myConn.Close ();
				worksheet.Cells.ColumnWidth [0, 1] = 3000;
				workbook.Worksheets.Add (worksheet);
				workbook.Save (file);
				MessageBox.Show ("Export Success\n" + (line - 1) + " data is exported");
			} catch (Exception ex) {
				MessageBox.Show (ex.Message);
			}
		}

		public void ImportBorrower ()
		{
			try {
				string file = "LMS_ImportBorrower.xls";
				MySqlConnection myConn = DB.GetDB ();
				MySqlDataReader myReader;
				MySqlDataReader myReader_login;
				FileStream fileStream = new FileStream (file, FileMode.Open);
				Workbook workbook = Workbook.Load (fileStream);
				Worksheet worksheet = workbook.Worksheets [0];
				line = 0;
				for (int i = 1; i <= worksheet.Cells.LastRowIndex; i++) {
					myConn.Open ();
					string query = "insert into library.borrower_details(name, card_no, contact_no, fine) values ('" + worksheet.Cells [i, 1] + "','" + worksheet.Cells [i, 0] + "','" + worksheet.Cells [i, 2] + "','0');";
					string query_login = "insert into library.login_credential (username,password,id) values ('" + worksheet.Cells [i, 1] + "','" + worksheet.Cells [i, 2] + "','" + worksheet.Cells [i, 0] + "');";
					MySqlCommand cmdDataBase = new MySqlCommand (query, myConn);
					MySqlCommand cmdDataBase_login = new MySqlCommand (query_login, myConn);
					myReader = cmdDataBase.ExecuteReader ();
					while (myReader.Read ()) {

					}
					myConn.Close ();
					myConn.Open ();
					myReader_login = cmdDataBase_login.ExecuteReader ();
					while (myReader_login.Read ()) {

					}
					myConn.Close ();
					line++;
				}
				fileStream.Close ();

				MessageBox.Show ("Import Success\n" + line + " data is exported");
			} catch (Exception ex) {
				MessageBox.Show (ex.Message);
			}
		}
	}
}

