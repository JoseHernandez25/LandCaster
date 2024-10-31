namespace LandCaster.WindowsForms.DrawerS
{
    partial class ComponetsDrawer
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
            textBox3 = new TextBox();
            label4 = new Label();
            textBox2 = new TextBox();
            label3 = new Label();
            textBox1 = new TextBox();
            label2 = new Label();
            textBox4 = new TextBox();
            label1 = new Label();
            textBox5 = new TextBox();
            label5 = new Label();
            textBox6 = new TextBox();
            label6 = new Label();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ButtonHighlight;
            panel2.Controls.Add(textBox6);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(textBox5);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(textBox4);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(BtnEliminar);
            panel2.Controls.Add(BtnEditar);
            panel2.Controls.Add(BtnAgregar);
            panel2.Controls.Add(textBox3);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(textBox2);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(textBox1);
            panel2.Controls.Add(label2);
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1003, 294);
            panel2.TabIndex = 7;
            // 
            // BtnEliminar
            // 
            BtnEliminar.BackColor = Color.FromArgb(0, 91, 166);
            BtnEliminar.FlatStyle = FlatStyle.Popup;
            BtnEliminar.ForeColor = Color.White;
            BtnEliminar.Location = new Point(563, 210);
            BtnEliminar.Name = "BtnEliminar";
            BtnEliminar.Size = new Size(91, 39);
            BtnEliminar.TabIndex = 8;
            BtnEliminar.Text = "Eliminar";
            BtnEliminar.UseVisualStyleBackColor = false;
            BtnEliminar.Click += button3_Click;
            // 
            // BtnEditar
            // 
            BtnEditar.BackColor = Color.FromArgb(0, 91, 166);
            BtnEditar.FlatStyle = FlatStyle.Popup;
            BtnEditar.ForeColor = Color.White;
            BtnEditar.Location = new Point(462, 210);
            BtnEditar.Name = "BtnEditar";
            BtnEditar.Size = new Size(91, 39);
            BtnEditar.TabIndex = 7;
            BtnEditar.Text = "Editar";
            BtnEditar.UseVisualStyleBackColor = false;
        //    BtnEditar.Click += this.BtnEditar_Click
                ;
            // 
            // BtnAgregar
            // 
            BtnAgregar.BackColor = Color.FromArgb(0, 91, 166);
            BtnAgregar.FlatStyle = FlatStyle.Popup;
            BtnAgregar.ForeColor = Color.White;
            BtnAgregar.Location = new Point(361, 210);
            BtnAgregar.Name = "BtnAgregar";
            BtnAgregar.Size = new Size(91, 39);
            BtnAgregar.TabIndex = 6;
            BtnAgregar.Text = "Agregar";
            BtnAgregar.UseVisualStyleBackColor = false;
      //      BtnAgregar.Click += this.BtnAgregar_Click;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(258, 142);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(196, 23);
            textBox3.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(139, 145);
            label4.Name = "label4";
            label4.Size = new Size(38, 15);
            label4.TabIndex = 4;
            label4.Text = "Costo";
            label4.Click += label4_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(258, 101);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(196, 23);
            textBox2.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(139, 104);
            label3.Name = "label3";
            label3.Size = new Size(51, 15);
            label3.TabIndex = 2;
            label3.Text = "Nombre";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(258, 60);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(196, 23);
            textBox1.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(139, 63);
            label2.Name = "label2";
            label2.Size = new Size(46, 15);
            label2.TabIndex = 0;
            label2.Text = "Código";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(682, 60);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(196, 23);
            textBox4.TabIndex = 10;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(563, 63);
            label1.Name = "label1";
            label1.Size = new Size(56, 15);
            label1.TabIndex = 9;
            label1.Text = "Monedas";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(682, 101);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(196, 23);
            textBox5.TabIndex = 12;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(563, 104);
            label5.Name = "label5";
            label5.Size = new Size(40, 15);
            label5.TabIndex = 11;
            label5.Text = "Marca";
            // 
            // textBox6
            // 
            textBox6.Location = new Point(682, 142);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(196, 23);
            textBox6.TabIndex = 14;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(563, 145);
            label6.Name = "label6";
            label6.Size = new Size(45, 15);
            label6.TabIndex = 13;
            label6.Text = "Unidad";
            // 
            // ComponetsDrawer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel2);
            Name = "ComponetsDrawer";
            Size = new Size(1004, 294);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private Button BtnEliminar;
        private Button BtnEditar;
        private Button BtnAgregar;
        private TextBox textBox3;
        private Label label4;
        private TextBox textBox2;
        private Label label3;
        private TextBox textBox1;
        private Label label2;
        private TextBox textBox6;
        private Label label6;
        private TextBox textBox5;
        private Label label5;
        private TextBox textBox4;
        private Label label1;
    }
}
