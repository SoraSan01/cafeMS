using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;

namespace cafeMS
{
	public partial class historyform : Form
	{
		private Point mouseOffset;
    	private bool isMouseDown = false;
    	
		MySqlConnection cn;
		MySqlCommand cm;
		MySqlDataReader dr;
		DataTable dt;
		
		public historyform()
		{
			cn = new MySqlConnection();
			cn.ConnectionString = "server=localhost; user id=root;password=; database=cafems;";
			InitializeComponent();
			
			dt = new DataTable();
            historyDGV.DataSource = dt;

            sortTb.TextChanged += SortTbTextChanged;

		}
		void ClosePbClick(object sender, EventArgs e)
		{
			if (MessageBox.Show("Are you sure you want to Close Application?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
			    Application.Exit();
			}
		}
		
		public void populatehistory()
		{
			cn.Open();

		    string query = "SELECT ID, name, date, items, qty, total FROM history";
		    cm = new MySqlCommand(query, cn);
		    dt = new DataTable();
		    MySqlDataAdapter adapter = new MySqlDataAdapter(cm);
		    adapter.Fill(dt);
		    historyDGV.DataSource = dt;
		
		    cn.Close();
			
		}
		
		void HistoryformLoad(object sender, EventArgs e)
		{
			populatehistory();
		}
		void HistoryDGVCellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			
		}
		void HistoryDGVCellPainting(object sender, DataGridViewCellPaintingEventArgs e)
		{
			
		}
		void SortTbTextChanged(object sender, EventArgs e)
		{
			
			string searchText = sortTb.Text.Trim();

            if (searchText == string.Empty)
            {
                historyDGV.DataSource = dt;
            }
            else
            {
		        DataView dataView = dt.DefaultView;
		        dataView.RowFilter = "name LIKE '%" + searchText + "%' OR " +
		                             "CONVERT(ID, 'System.String') LIKE '%" + searchText + "%' OR " +
		                             "date LIKE '%" + searchText + "%' OR " +
		                             "CONVERT(total, 'System.String') LIKE '%" + searchText + "%' OR " +
		                             "items LIKE '%" + searchText + "%'";
		        historyDGV.DataSource = dataView.ToTable();
            }
			
		}
		void Label5Click(object sender, EventArgs e)
		{
			AdminSection adminform = new AdminSection();
			adminform.Show();
			this.Hide();
		}
		void HistoryformMouseMove(object sender, MouseEventArgs e)
		{
			if (isMouseDown)
	        {
	            Point mousePos = Control.MousePosition;
	            mousePos.Offset(mouseOffset.X, mouseOffset.Y);
	            Location = mousePos;
	        }
		}
		void HistoryformMouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
	        {
	            isMouseDown = false;
	        }
		}
		void HistoryformMouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
	        {
	            mouseOffset = new Point(-e.X, -e.Y);
	            isMouseDown = true;
	        }
		}
			
	}
}
