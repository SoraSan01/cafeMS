﻿using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
using System.Data;

namespace cafeMS
{
    public partial class RegisterAdmin : Form
    {
        private Point mouseOffset;
        private bool isMouseDown = false;

        private MySqlConnection cn;
        private MySqlCommand cm;

        public RegisterAdmin()
        {
            cn = new MySqlConnection();
            cn.ConnectionString = "server=localhost; user id=root;password=; database=cafems;";
            InitializeComponent();
        }

        private void txtclear()
        {
            UnameTb.Text = "";
            usernameTb.Text = "";
            UpasswordTb.Text = "";
            EmailTb.Text = "";
        }

        void Button1Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(UnameTb.Text) || string.IsNullOrEmpty(usernameTb.Text) || string.IsNullOrEmpty(UpasswordTb.Text) || string.IsNullOrWhiteSpace(EmailTb.Text))
            {
                MessageBox.Show("Please fill in all fields.");
            }
            else
            {
                try
                {
                    cn.Open();

                    // Check if the name, username, or email already exist in the database
                    string query = "SELECT COUNT(*) FROM admin WHERE name = @name OR username = @uname OR email = @email";
                    using (MySqlCommand checkCommand = new MySqlCommand(query, cn))
                    {
                        checkCommand.Parameters.AddWithValue("@name", UnameTb.Text);
                        checkCommand.Parameters.AddWithValue("@uname", usernameTb.Text);
                        checkCommand.Parameters.AddWithValue("@email", EmailTb.Text);

                        int count = Convert.ToInt32(checkCommand.ExecuteScalar());
                        if (count > 0)
                        {
                            MessageBox.Show("Name, username, or email already exists. Please choose different values.");
                            return;
                        }
                    }

                    // If no duplicates found, insert the new admin
                    cm = new MySqlCommand("INSERT INTO admin (name, username, password, email) VALUES (@name, @uname, @upass, @email)", cn);
                    cm.Parameters.AddWithValue("@name", UnameTb.Text);
                    cm.Parameters.AddWithValue("@uname", usernameTb.Text);
                    cm.Parameters.AddWithValue("@upass", UpasswordTb.Text);
                    cm.Parameters.AddWithValue("@email", EmailTb.Text);
                    cm.ExecuteNonQuery();

                    MessageBox.Show("Registered Successfully");
                    txtclear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    if (cn.State == ConnectionState.Open)
                        cn.Close();
                }
            }
        }

        void Button2Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        void RegisterAdminMouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                Point mousePos = Control.MousePosition;
                mousePos.Offset(mouseOffset.X, mouseOffset.Y);
                Location = mousePos;
            }
        }

        void RegisterAdminMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = false;
            }
        }

        void RegisterAdminMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseOffset = new Point(-e.X, -e.Y);
                isMouseDown = true;
            }
        }
    }
}
