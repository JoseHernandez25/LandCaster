using LandCaster.BLL;

namespace LandCaster.WindowsForms
{
    partial class Dashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            panel1 = new Panel();
            panel6 = new Panel();
            tiendas = new Button();
            panel5 = new Panel();
            BtnEmployees = new Button();
            panel4 = new Panel();
            BtnCustomers = new Button();
            panel2 = new Panel();
            BtnUsers = new Button();
            pictureBox1 = new PictureBox();
            header = new Panel();
            panel3 = new Panel();
            users = new UsersModule.Users();
            employees = new Employees();
            customers = new Customers();
            panel1.SuspendLayout();
            panel6.SuspendLayout();
            panel5.SuspendLayout();
            panel4.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(panel6);
            panel1.Controls.Add(panel5);
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(200, 810);
            panel1.TabIndex = 0;
            // 
            // panel6
            // 
            panel6.Controls.Add(tiendas);
            panel6.Location = new Point(0, 320);
            panel6.Name = "panel6";
            panel6.Size = new Size(200, 67);
            panel6.TabIndex = 5;
            // 
            // tiendas
            // 
            tiendas.BackColor = Color.FromArgb(0, 91, 166);
            tiendas.BackgroundImageLayout = ImageLayout.None;
            tiendas.Cursor = Cursors.Hand;
            tiendas.FlatStyle = FlatStyle.Flat;
            tiendas.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tiendas.ForeColor = Color.White;
            tiendas.Image = (Image)resources.GetObject("tiendas.Image");
            tiendas.ImageAlign = ContentAlignment.MiddleLeft;
            tiendas.Location = new Point(0, 12);
            tiendas.Name = "tiendas";
            tiendas.Padding = new Padding(20, 0, 0, 0);
            tiendas.Size = new Size(200, 43);
            tiendas.TabIndex = 1;
            tiendas.Text = "Tiendas";
            tiendas.UseVisualStyleBackColor = false;
            // 
            // panel5
            // 
            panel5.Controls.Add(BtnEmployees);
            panel5.Location = new Point(0, 247);
            panel5.Name = "panel5";
            panel5.Size = new Size(200, 67);
            panel5.TabIndex = 4;
            panel5.Paint += panel5_Paint;
            // 
            // BtnEmployees
            // 
            BtnEmployees.BackColor = Color.FromArgb(0, 91, 166);
            BtnEmployees.BackgroundImageLayout = ImageLayout.None;
            BtnEmployees.Cursor = Cursors.Hand;
            BtnEmployees.FlatStyle = FlatStyle.Flat;
            BtnEmployees.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BtnEmployees.ForeColor = Color.White;
            BtnEmployees.Image = (Image)resources.GetObject("BtnEmployees.Image");
            BtnEmployees.ImageAlign = ContentAlignment.MiddleLeft;
            BtnEmployees.Location = new Point(0, 12);
            BtnEmployees.Name = "BtnEmployees";
            BtnEmployees.Padding = new Padding(20, 0, 0, 0);
            BtnEmployees.Size = new Size(200, 43);
            BtnEmployees.TabIndex = 1;
            BtnEmployees.Text = "Empleados";
            BtnEmployees.UseVisualStyleBackColor = false;
            BtnEmployees.Click += BtnEmployees_Click;
            // 
            // panel4
            // 
            panel4.Controls.Add(BtnCustomers);
            panel4.Location = new Point(0, 174);
            panel4.Name = "panel4";
            panel4.Size = new Size(200, 67);
            panel4.TabIndex = 3;
            // 
            // BtnCustomers
            // 
            BtnCustomers.BackColor = Color.FromArgb(0, 91, 166);
            BtnCustomers.BackgroundImageLayout = ImageLayout.None;
            BtnCustomers.Cursor = Cursors.Hand;
            BtnCustomers.FlatStyle = FlatStyle.Flat;
            BtnCustomers.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BtnCustomers.ForeColor = Color.White;
            BtnCustomers.Image = (Image)resources.GetObject("BtnCustomers.Image");
            BtnCustomers.ImageAlign = ContentAlignment.MiddleLeft;
            BtnCustomers.Location = new Point(0, 12);
            BtnCustomers.Name = "BtnCustomers";
            BtnCustomers.Padding = new Padding(20, 0, 0, 0);
            BtnCustomers.Size = new Size(200, 43);
            BtnCustomers.TabIndex = 1;
            BtnCustomers.Text = "Clientes";
            BtnCustomers.UseVisualStyleBackColor = false;
            BtnCustomers.Click += BtnCustomers_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(BtnUsers);
            panel2.Location = new Point(0, 101);
            panel2.Name = "panel2";
            panel2.Size = new Size(200, 67);
            panel2.TabIndex = 2;
            // 
            // BtnUsers
            // 
            BtnUsers.BackColor = Color.FromArgb(0, 91, 166);
            BtnUsers.BackgroundImageLayout = ImageLayout.None;
            BtnUsers.Cursor = Cursors.Hand;
            BtnUsers.FlatStyle = FlatStyle.Flat;
            BtnUsers.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BtnUsers.ForeColor = Color.White;
            BtnUsers.Image = (Image)resources.GetObject("BtnUsers.Image");
            BtnUsers.ImageAlign = ContentAlignment.MiddleLeft;
            BtnUsers.Location = new Point(0, 12);
            BtnUsers.Name = "BtnUsers";
            BtnUsers.Padding = new Padding(20, 0, 0, 0);
            BtnUsers.Size = new Size(200, 43);
            BtnUsers.TabIndex = 1;
            BtnUsers.Text = "Usuarios";
            BtnUsers.UseVisualStyleBackColor = false;
            BtnUsers.Click += BtnUsers_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.LOGO_LANDCASTER_OFICIAL;
            pictureBox1.Location = new Point(3, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(197, 83);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // header
            // 
            header.BackColor = Color.White;
            header.Dock = DockStyle.Top;
            header.Location = new Point(200, 0);
            header.Name = "header";
            header.Size = new Size(1039, 44);
            header.TabIndex = 2;
            // 
            // panel3
            // 
            panel3.Controls.Add(employees);
            panel3.Controls.Add(users);
            panel3.Controls.Add(employees);
            panel3.Controls.Add(customers);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(200, 44);
            panel3.Name = "panel3";
            panel3.Size = new Size(1039, 766);
            panel3.TabIndex = 3;
            panel3.Paint += panel3_Paint;
            // users
            // 
            users.Dock = DockStyle.Fill;
            users.Location = new Point(0, 0);
            users.Name = "users";
            users.Size = new Size(1039, 766);
            users.TabIndex = 2;
            users.Visible = false;
            // 
            // employees
            // 
            employees.Dock = DockStyle.Fill;
            employees.Location = new Point(0, 0);
            employees.Name = "employees";
            employees.Size = new Size(1039, 766);
            employees.TabIndex = 1;
            employees.Visible = false;
            // 
            // 
            // customers
            // 
            customers.Location = new Point(0, -3);
            customers.Name = "customers";
            customers.TabIndex = 0;
            customers.Visible = false;
            // employees
            employees.TabIndex = 0;
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(1239, 810);
            Controls.Add(panel3);
            Controls.Add(header);
            Controls.Add(panel1);
            Cursor = Cursors.AppStarting;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Dashboard";
            WindowState = FormWindowState.Maximized;
            panel1.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private PictureBox pictureBox1;
        private Button BtnUsers;
        private Panel panel2;
        private Panel header;
        private Panel panel3;
        private Panel panel4;
#pragma warning disable CS0169 // El campo 'Dashboard.button1' nunca se usa
        private Button button1;
#pragma warning restore CS0169 // El campo 'Dashboard.button1' nunca se usa
        private Panel panel5;
        private Button BtnEmployees;
        private Button BtnCustomers;
        private Panel panel6;
        private Button tiendas;
        private Employees employees;
        private Customers customers;
        private UsersModule.Users users;
    }
}