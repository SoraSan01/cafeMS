/*
 * Created by SharpDevelop.
 * User: Ralph
 * Date: 5/11/2023
 * Time: 5:05 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace cafeMS
{
	partial class RegisterUser
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.TextBox UpasswordTb;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox usernameTb;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox UnameTb;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox EmailTb;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.PictureBox closePb;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterUser));
			this.label4 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.EmailTb = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.UpasswordTb = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.usernameTb = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.UnameTb = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.closePb = new System.Windows.Forms.PictureBox();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.closePb)).BeginInit();
			this.SuspendLayout();
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.ForeColor = System.Drawing.Color.White;
			this.label4.Location = new System.Drawing.Point(64, 8);
			this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(191, 39);
			this.label4.TabIndex = 11;
			this.label4.Text = "REGISTER NEW ACCOUNT";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.Gainsboro;
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel2.Controls.Add(this.EmailTb);
			this.panel2.Controls.Add(this.label7);
			this.panel2.Controls.Add(this.button1);
			this.panel2.Controls.Add(this.UpasswordTb);
			this.panel2.Controls.Add(this.label5);
			this.panel2.Controls.Add(this.usernameTb);
			this.panel2.Controls.Add(this.label2);
			this.panel2.Controls.Add(this.UnameTb);
			this.panel2.Controls.Add(this.label1);
			this.panel2.Location = new System.Drawing.Point(0, 56);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(320, 320);
			this.panel2.TabIndex = 1;
			// 
			// EmailTb
			// 
			this.EmailTb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.EmailTb.Location = new System.Drawing.Point(120, 192);
			this.EmailTb.MaxLength = 30;
			this.EmailTb.Name = "EmailTb";
			this.EmailTb.Size = new System.Drawing.Size(144, 20);
			this.EmailTb.TabIndex = 31;
			// 
			// label7
			// 
			this.label7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.ForeColor = System.Drawing.Color.Black;
			this.label7.Location = new System.Drawing.Point(32, 192);
			this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(80, 22);
			this.label7.TabIndex = 30;
			this.label7.Text = "Email";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.BackColor = System.Drawing.Color.Lime;
			this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
			this.button1.FlatAppearance.BorderColor = System.Drawing.Color.White;
			this.button1.FlatAppearance.BorderSize = 2;
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.button1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button1.ForeColor = System.Drawing.Color.White;
			this.button1.Location = new System.Drawing.Point(32, 248);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(256, 50);
			this.button1.TabIndex = 26;
			this.button1.Text = "CREATE ACCOUNT";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// UpasswordTb
			// 
			this.UpasswordTb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.UpasswordTb.Location = new System.Drawing.Point(120, 137);
			this.UpasswordTb.MaxLength = 20;
			this.UpasswordTb.Name = "UpasswordTb";
			this.UpasswordTb.PasswordChar = '*';
			this.UpasswordTb.Size = new System.Drawing.Size(144, 20);
			this.UpasswordTb.TabIndex = 21;
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.ForeColor = System.Drawing.Color.Black;
			this.label5.Location = new System.Drawing.Point(32, 137);
			this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(80, 22);
			this.label5.TabIndex = 20;
			this.label5.Text = "Password";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// usernameTb
			// 
			this.usernameTb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.usernameTb.Location = new System.Drawing.Point(120, 80);
			this.usernameTb.MaxLength = 20;
			this.usernameTb.Name = "usernameTb";
			this.usernameTb.Size = new System.Drawing.Size(144, 20);
			this.usernameTb.TabIndex = 19;
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.Color.Black;
			this.label2.Location = new System.Drawing.Point(32, 80);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(80, 22);
			this.label2.TabIndex = 18;
			this.label2.Text = "Username";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// UnameTb
			// 
			this.UnameTb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.UnameTb.Location = new System.Drawing.Point(120, 28);
			this.UnameTb.MaxLength = 20;
			this.UnameTb.Name = "UnameTb";
			this.UnameTb.Size = new System.Drawing.Size(144, 20);
			this.UnameTb.TabIndex = 17;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.Black;
			this.label1.Location = new System.Drawing.Point(32, 28);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 22);
			this.label1.TabIndex = 16;
			this.label1.Text = "Name";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// closePb
			// 
			this.closePb.Cursor = System.Windows.Forms.Cursors.Hand;
			this.closePb.Image = ((System.Drawing.Image)(resources.GetObject("closePb.Image")));
			this.closePb.Location = new System.Drawing.Point(286, 2);
			this.closePb.Name = "closePb";
			this.closePb.Size = new System.Drawing.Size(30, 30);
			this.closePb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.closePb.TabIndex = 17;
			this.closePb.TabStop = false;
			this.closePb.Click += new System.EventHandler(this.ClosePbClick);
			// 
			// RegisterUser
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(24)))), ((int)(((byte)(69)))));
			this.ClientSize = new System.Drawing.Size(318, 398);
			this.Controls.Add(this.closePb);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.panel2);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "RegisterUser";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "RegisterUser";
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.RegisterUserMouseDown);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.RegisterUserMouseMove);
			this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.RegisterUserMouseUp);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.closePb)).EndInit();
			this.ResumeLayout(false);

		}
	}
}
