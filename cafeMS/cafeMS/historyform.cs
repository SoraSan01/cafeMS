using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using DataTable = System.Data.DataTable;
using Application = Microsoft.Office.Interop.Excel.Application;
using MySql.Data.MySqlClient;




namespace cafeMS
{
    public partial class historyform : Form
    {
        private System.Drawing.Point mouseOffset;
        private bool isMouseDown = false;

        MySqlConnection cn;
        MySqlCommand cm;
        DataTable dt;

        public historyform()
        {
            cn = new MySqlConnection();
            cn.ConnectionString = "server=localhost; user id=root;password=; database=cafems;";
            InitializeComponent();

            dt = new DataTable();
            historyDGV.DataSource = dt;

            sortTb.TextChanged += SortTbTextChanged;
            historyDGV.CellDoubleClick += HistoryDGVCellDoubleClick;
        }

        void ClosePbClick(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to close the application?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
            	System.Windows.Forms.Application.Exit();
            }
        }

        public void populatehistory()
        {
            cn.Open();

		    string query = "SELECT ID, name, date, items, price, qty, total, payment, Pchange FROM history";
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
                System.Drawing.Point mousePos = Control.MousePosition;
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
                mouseOffset = new System.Drawing.Point(-e.X, -e.Y);
                isMouseDown = true;
            }
        }

        void HistoryDGVCellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        void HistoryDGVCellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
		    {
		        DataGridViewRow selectedRow = historyDGV.Rows[e.RowIndex];
		        string name = selectedRow.Cells["name"].Value.ToString();
		        string date = selectedRow.Cells["date"].Value.ToString();
		        string items = selectedRow.Cells["items"].Value.ToString();
		        string price = selectedRow.Cells["price"].Value.ToString();
		        string qty = selectedRow.Cells["qty"].Value.ToString();
		        string total = selectedRow.Cells["total"].Value.ToString();
		        string payment = selectedRow.Cells["payment"].Value.ToString();
		        string change = selectedRow.Cells["Pchange"].Value.ToString();
		
		        PrintData1(name, date, items, price, qty, total, payment, change);
		    }
        }

        void PrintDocument1PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
        	// Define the fonts and other formatting styles
			System.Drawing.Font headingFont = new System.Drawing.Font("Arial", 20, FontStyle.Bold);
			System.Drawing.Font contentFont = new System.Drawing.Font("Arial", 15);
			System.Drawing.Font itemFont = new System.Drawing.Font("Arial", 15);
			Brush brush = Brushes.Black;
			int lineHeight = (int)contentFont.GetHeight() + 5;
			int leftMargin = 50;
			int topMargin = 50;
			
			// Retrieve the print data
			string name = printData.Name;
			string date = printData.Date;
			string items = printData.Items;
			string qty = printData.Qty;
			string price = printData.Price;
			string total = printData.Total;
			string payment = printData.Payment;
			string change = printData.Change;
			
			// Draw the company name
			string companyName = "CAFE NATEN";
			e.Graphics.DrawString(companyName, headingFont, brush, leftMargin, topMargin);
			topMargin += lineHeight * 2;
			
			// Draw a line
			e.Graphics.DrawLine(new Pen(brush), leftMargin, topMargin, e.PageBounds.Width - leftMargin, topMargin);
			topMargin += lineHeight;
			
			// Draw the heading
			e.Graphics.DrawString("Receipt", headingFont, brush, leftMargin, topMargin);
			topMargin += lineHeight * 2;
			
			// Draw the name and date
			e.Graphics.DrawString("Name: " + name, contentFont, brush, leftMargin, topMargin);
			topMargin += lineHeight;
			e.Graphics.DrawString("Date: " + date, contentFont, brush, leftMargin, topMargin);
			topMargin += lineHeight * 2;
			
			// Draw the item details
			e.Graphics.DrawString("Items:", contentFont, brush, leftMargin, topMargin);
			topMargin += lineHeight * 2;
			
			string[] itemLines = items.Split('|');
			string[] qtyLines = qty.Split('|');
			string[] priceLines = price.Split('|');
			int maxItemLength = itemLines.Max(item => item.Length);
			for (int i = 0; i < itemLines.Length; i++)
			{
			    string itemLine = itemLines[i].PadRight(maxItemLength);
			    e.Graphics.DrawString(itemLine, itemFont, brush, leftMargin + 200, topMargin);
			    e.Graphics.DrawString(qtyLines[i], itemFont, brush, e.PageBounds.Width - leftMargin - 200, topMargin);
			    e.Graphics.DrawString(priceLines[i], itemFont, brush, e.PageBounds.Width - leftMargin - 300, topMargin);
			    topMargin += lineHeight * 4;
			}
			
			// Draw a line
			e.Graphics.DrawLine(new Pen(brush), leftMargin, topMargin + 100, e.PageBounds.Width - leftMargin, topMargin + 100);
			topMargin += lineHeight;
			
			// Draw the total, payment, and change
			e.Graphics.DrawString("Total: ", contentFont, brush, leftMargin + 200, topMargin + 200);e.Graphics.DrawString(total, itemFont, brush, e.PageBounds.Width - leftMargin - 300, topMargin + 200);
			topMargin += lineHeight;
			topMargin += lineHeight;
			e.Graphics.DrawString("Payment: ", contentFont, brush, leftMargin + 200, topMargin + 200);e.Graphics.DrawString(payment, itemFont, brush, e.PageBounds.Width - leftMargin - 300, topMargin + 200);
			topMargin += lineHeight;
			topMargin += lineHeight;
			e.Graphics.DrawString("Change: ", contentFont, brush, leftMargin + 200, topMargin + 200); e.Graphics.DrawString(change, itemFont, brush, e.PageBounds.Width - leftMargin - 300, topMargin + 200);
			topMargin += lineHeight;
			topMargin += lineHeight;
		}

        private PrintData printData;

        private void PrintData1(string name, string date, string items, string price, string qty, string total, string payment, string change)
        {
            printData = new PrintData(name, date, items, price, qty, total, payment, change);

            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(PrintDocument1PrintPage);

            PrintPreviewDialog printDialog = new PrintPreviewDialog();
            printDialog.Document = pd;
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                pd.Print();
            }
        }
		void PictureBox1Click(object sender, EventArgs e)
		{
            var excelApp = new Application();
		    var workbook = excelApp.Workbooks.Add();
		    var worksheet = workbook.ActiveSheet as Worksheet;
		
		    // Set the starting cell to D4
		    Range startingCell = worksheet.Range["D4"];
		
		    // Set the column width based on the maximum text length in each column
		    for (int j = 0; j < historyDGV.Columns.Count; j++)
		    {
		        int maxLength = 0;
		
		        // Find the maximum text length in the column (including the header)
		        string headerCellValue = historyDGV.Columns[j].HeaderText;
		        int headerLength = headerCellValue.Length;
		        if (headerLength > maxLength)
		            maxLength = headerLength;
		
		        for (int i = 0; i < historyDGV.Rows.Count; i++)
		        {
		            string cellValue = historyDGV.Rows[i].Cells[j].Value.ToString() + "";
		            int cellLength = cellValue.Length;
		
		            if (cellLength > maxLength)
		                maxLength = cellLength;
		        }
		
		        // Set the column width based on the maximum text length with some padding
		        Range columnRange = startingCell.Offset[0, j];
		        columnRange.ColumnWidth = maxLength + 2;
		
		        // Set the header value
		        Range headerCell = startingCell.Offset[-1, j];
		        headerCell.Value = headerCellValue;
		        headerCell.Font.Bold = true;
		        headerCell.HorizontalAlignment = XlHAlign.xlHAlignCenter;
		    }
		    
		    // Add cafe name above the header row
		    Range cafeNameCell = startingCell.Offset[-2, 0];
		    cafeNameCell.Value = "Cafe Name: CAFE NATEN";
		    cafeNameCell.Font.Bold = true;
		
		    // Populate the data and format cells
		    for (int i = 0; i < historyDGV.Rows.Count; i++)
		    {
		        for (int j = 0; j < historyDGV.Columns.Count; j++)
		        {
		            Range cell = startingCell.Offset[i, j];
		            cell.Value = historyDGV.Rows[i].Cells[j].Value;
		            cell.HorizontalAlignment = XlHAlign.xlHAlignCenter;
		            cell.WrapText = true;
		        }
		    }
		
		    excelApp.Visible = true;
		}

        private class PrintData
        {
            public string Name { get; set; }
            public string Date { get; set; }
            public string Items { get; set; }
            public string Price { get; set; }
            public string Qty { get; set; }
            public string Total { get; set; }
            public string Payment { get; set; }
            public string Change { get; set; }

            public PrintData(string name, string date, string items, string price, string qty, string total, string payment, string change)
            {
                Name = name;
                Date = date;
                Items = items;
                Price = price;
                Qty = qty;
                Total = total;
                Payment = payment;
                Change = change;
            }
        }
    }
}
