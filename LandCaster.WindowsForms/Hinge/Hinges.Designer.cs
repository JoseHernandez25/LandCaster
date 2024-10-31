namespace LandCaster.WindowsForms.Hinge
{
    partial class Hinges
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
            BtnEliminar = new Button();
            BtnEditar = new Button();
            BtnAgregar = new Button();
            textBox1 = new TextBox();
            label2 = new Label();
            textBox2 = new TextBox();
            label1 = new Label();
            textBox3 = new TextBox();
            label3 = new Label();
            textBox4 = new TextBox();
            label4 = new Label();
            textBox5 = new TextBox();
            label5 = new Label();
            textBox6 = new TextBox();
            label6 = new Label();
            textBox7 = new TextBox();
            label7 = new Label();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ButtonHighlight;
            panel2.Controls.Add(textBox7);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(textBox6);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(textBox5);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(textBox4);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(textBox3);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(textBox2);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(BtnEliminar);
            panel2.Controls.Add(BtnEditar);
            panel2.Controls.Add(BtnAgregar);
            panel2.Controls.Add(textBox1);
            panel2.Controls.Add(label2);
            panel2.Location = new Point(1, -1);
            panel2.Name = "panel2";
            panel2.Size = new Size(1003, 294);
            panel2.TabIndex = 7;
            panel2.Paint += panel2_Paint;
            // 
            // BtnEliminar
            // 
            BtnEliminar.BackColor = Color.FromArgb(0, 91, 166);
            BtnEliminar.FlatStyle = FlatStyle.Popup;
            BtnEliminar.ForeColor = Color.White;
            BtnEliminar.Location = new Point(577, 235);
            BtnEliminar.Name = "BtnEliminar";
            BtnEliminar.Size = new Size(91, 39);
            BtnEliminar.TabIndex = 8;
            BtnEliminar.Text = "Eliminar";
            BtnEliminar.UseVisualStyleBackColor = false;
            BtnEliminar.Click += BtnEliminar_Click;
            // 
            // BtnEditar
            // 
            BtnEditar.BackColor = Color.FromArgb(0, 91, 166);
            BtnEditar.FlatStyle = FlatStyle.Popup;
            BtnEditar.ForeColor = Color.White;
            BtnEditar.Location = new Point(462, 235);
            BtnEditar.Name = "BtnEditar";
            BtnEditar.Size = new Size(91, 39);
            BtnEditar.TabIndex = 7;
            BtnEditar.Text = "Editar";
            BtnEditar.UseVisualStyleBackColor = false;
            BtnEditar.Click += BtnEditar_Click;
            // 
            // BtnAgregar
            // 
            BtnAgregar.BackColor = Color.FromArgb(0, 91, 166);
            BtnAgregar.FlatStyle = FlatStyle.Popup;
            BtnAgregar.ForeColor = Color.White;
            BtnAgregar.Location = new Point(352, 235);
            BtnAgregar.Name = "BtnAgregar";
            BtnAgregar.Size = new Size(91, 39);
            BtnAgregar.TabIndex = 6;
            BtnAgregar.Text = "Agregar";
            BtnAgregar.UseVisualStyleBackColor = false;
            BtnAgregar.Click += BtnAgregar_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(219, 41);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(196, 23);
            textBox1.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(100, 44);
            label2.Name = "label2";
            label2.Size = new Size(46, 15);
            label2.TabIndex = 0;
            label2.Text = "Código";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(219, 85);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(196, 23);
            textBox2.TabIndex = 10;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(100, 88);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 9;
            label1.Text = "Nombre";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(219, 126);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(196, 23);
            textBox3.TabIndex = 12;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(100, 129);
            label3.Name = "label3";
            label3.Size = new Size(69, 15);
            label3.TabIndex = 11;
            label3.Text = "Descripción";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(219, 166);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(196, 23);
            textBox4.TabIndex = 14;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(100, 169);
            label4.Name = "label4";
            label4.Size = new Size(73, 15);
            label4.TabIndex = 13;
            label4.Text = "Observación";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(680, 41);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(196, 23);
            textBox5.TabIndex = 16;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(561, 44);
            label5.Name = "label5";
            label5.Size = new Size(46, 15);
            label5.TabIndex = 15;
            label5.Text = "Ángulo";
            // 
            // textBox6
            // 
            textBox6.Location = new Point(680, 85);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(196, 23);
            textBox6.TabIndex = 18;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(561, 88);
            label6.Name = "label6";
            label6.Size = new Size(35, 15);
            label6.TabIndex = 17;
            label6.Text = "Tipos";
            // 
            // textBox7
            // 
            textBox7.Location = new Point(680, 126);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(196, 23);
            textBox7.TabIndex = 20;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(561, 129);
            label7.Name = "label7";
            label7.Size = new Size(45, 15);
            label7.TabIndex = 19;
            label7.Text = "Marcas";
            // 
            // Hinges
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel2);
            Name = "Hinges";
            Size = new Size(1003, 294);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private Button BtnEliminar;
        private Button BtnEditar;
        private Button BtnAgregar;
        private TextBox textBox1;
        private Label label2;
        private TextBox textBox7;
        private Label label7;
        private TextBox textBox6;
        private Label label6;
        private TextBox textBox5;
        private Label label5;
        private TextBox textBox4;
        private Label label4;
        private TextBox textBox3;
        private Label label3;
        private TextBox textBox2;
        private Label label1;
    }
}
