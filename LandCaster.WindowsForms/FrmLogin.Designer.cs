namespace LandCaster.WindowsForms
{
    partial class FrmLogin
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
            Button login;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            user = new TextBox();
            password = new TextBox();
            sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            login = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // login
            // 
            login.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            login.Location = new Point(406, 219);
            login.Name = "login";
            login.RightToLeft = RightToLeft.Yes;
            login.Size = new Size(260, 44);
            login.TabIndex = 0;
            login.Text = "Iniciar sesion";
            login.UseMnemonic = false;
            login.UseVisualStyleBackColor = true;
            login.Click += login_Click;
            // 
            // panel1
            // 
            panel1.AllowDrop = true;
            panel1.BackColor = SystemColors.Window;
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(200, 330);
            panel1.TabIndex = 5;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.LOGO_LANDCASTER_OFICIAL;
            pictureBox1.Location = new Point(24, 57);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(152, 179);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Gainsboro;
            label1.Location = new Point(443, 23);
            label1.Name = "label1";
            label1.Size = new Size(180, 33);
            label1.TabIndex = 6;
            label1.Text = "Iniciar Sesion";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Gainsboro;
            label2.Location = new Point(260, 97);
            label2.Name = "label2";
            label2.Size = new Size(81, 24);
            label2.TabIndex = 7;
            label2.Text = "Usuario";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Century Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Gainsboro;
            label3.Location = new Point(260, 149);
            label3.Name = "label3";
            label3.Size = new Size(130, 24);
            label3.TabIndex = 8;
            label3.Text = "Contraseña";
            label3.Click += label3_Click;
            // 
            // user
            // 
            user.Location = new Point(406, 98);
            user.Name = "user";
            user.Size = new Size(260, 23);
            user.TabIndex = 9;
            // 
            // password
            // 
            password.AcceptsTab = true;
            password.Location = new Point(406, 149);
            password.Name = "password";
            password.PasswordChar = '•';
            password.Size = new Size(260, 23);
            password.TabIndex = 10;
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoValidate = AutoValidate.EnableAllowFocusChange;
            BackColor = Color.FromArgb(0, 91, 166);
            ClientSize = new Size(780, 330);
            Controls.Add(password);
            Controls.Add(user);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(panel1);
            Controls.Add(login);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Load += FrmLogin_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

#pragma warning disable CS0169 // El campo 'FrmLogin.login' nunca se usa
        private Button login;
#pragma warning restore CS0169 // El campo 'FrmLogin.login' nunca se usa
        private Panel panel1;
        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox user;
        private TextBox password;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
    }
}