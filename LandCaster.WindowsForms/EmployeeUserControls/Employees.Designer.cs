namespace LandCaster.WindowsForms
{
    partial class Employees
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            panel2 = new Panel();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            textBox3 = new TextBox();
            label4 = new Label();
            textBox2 = new TextBox();
            label3 = new Label();
            textBox1 = new TextBox();
            label2 = new Label();
            panel1 = new Panel();
            label1 = new Label();
            dataGridEmployees = new DataGridView();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridEmployees).BeginInit();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ButtonHighlight;
            panel2.Controls.Add(button3);
            panel2.Controls.Add(button2);
            panel2.Controls.Add(button1);
            panel2.Controls.Add(textBox3);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(textBox2);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(textBox1);
            panel2.Controls.Add(label2);
            panel2.Location = new Point(17, 437);
            panel2.Name = "panel2";
            panel2.Size = new Size(1003, 294);
            panel2.TabIndex = 5;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(0, 91, 166);
            button3.FlatStyle = FlatStyle.Popup;
            button3.ForeColor = Color.White;
            button3.Location = new Point(882, 236);
            button3.Name = "button3";
            button3.Size = new Size(91, 39);
            button3.TabIndex = 8;
            button3.Text = "Eliminar";
            button3.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(0, 91, 166);
            button2.FlatStyle = FlatStyle.Popup;
            button2.ForeColor = Color.White;
            button2.Location = new Point(785, 236);
            button2.Name = "button2";
            button2.Size = new Size(91, 39);
            button2.TabIndex = 7;
            button2.Text = "Editar";
            button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(0, 91, 166);
            button1.FlatStyle = FlatStyle.Popup;
            button1.ForeColor = Color.White;
            button1.Location = new Point(688, 236);
            button1.Name = "button1";
            button1.Size = new Size(91, 39);
            button1.TabIndex = 6;
            button1.Text = "Agregar";
            button1.UseVisualStyleBackColor = false;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(583, 79);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(196, 23);
            textBox3.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(522, 82);
            label4.Name = "label4";
            label4.Size = new Size(55, 15);
            label4.TabIndex = 4;
            label4.Text = "Telefono:";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(185, 120);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(196, 23);
            textBox2.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(66, 123);
            label3.Name = "label3";
            label3.Size = new Size(70, 15);
            label3.TabIndex = 2;
            label3.Text = "Contraseña:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(185, 79);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(196, 23);
            textBox1.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(66, 82);
            label2.Name = "label2";
            label2.Size = new Size(113, 15);
            label2.TabIndex = 0;
            label2.Text = "Nombre de Usuario:";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ButtonHighlight;
            panel1.Controls.Add(label1);
            panel1.Controls.Add(dataGridEmployees);
            panel1.Location = new Point(18, 35);
            panel1.Name = "panel1";
            panel1.Size = new Size(1003, 382);
            panel1.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(31, 28);
            label1.Name = "label1";
            label1.Size = new Size(101, 23);
            label1.TabIndex = 1;
            label1.Text = "Empleados";
            // 
            // dataGridEmployees
            // 
            dataGridEmployees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridEmployees.Location = new Point(31, 69);
            dataGridEmployees.Name = "dataGridEmployees";
            dataGridEmployees.Size = new Size(943, 287);
            dataGridEmployees.TabIndex = 0;
            // 
            // Employees
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Employees";
            Size = new Size(1039, 766);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridEmployees).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private Button button3;
        private Button button2;
        private Button button1;
        private TextBox textBox3;
        private Label label4;
        private TextBox textBox2;
        private Label label3;
        private TextBox textBox1;
        private Label label2;
        private Panel panel1;
        private Label label1;
        private DataGridView dataGridEmployees;
    }
}
