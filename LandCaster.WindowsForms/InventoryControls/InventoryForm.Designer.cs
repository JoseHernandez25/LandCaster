namespace LandCaster.WindowsForms.InventoryControls
{
    partial class InventoryForm
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
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            textBox2 = new TextBox();
            label3 = new Label();
            textBox1 = new TextBox();
            label2 = new Label();
            textBox5 = new TextBox();
            label5 = new Label();
            SuspendLayout();
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(0, 91, 166);
            button3.FlatStyle = FlatStyle.Popup;
            button3.ForeColor = Color.White;
            button3.Location = new Point(463, 149);
            button3.Name = "button3";
            button3.Size = new Size(91, 39);
            button3.TabIndex = 17;
            button3.Text = "Eliminar";
            button3.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(0, 91, 166);
            button2.FlatStyle = FlatStyle.Popup;
            button2.ForeColor = Color.White;
            button2.Location = new Point(355, 149);
            button2.Name = "button2";
            button2.Size = new Size(91, 39);
            button2.TabIndex = 16;
            button2.Text = "Editar";
            button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(0, 91, 166);
            button1.FlatStyle = FlatStyle.Popup;
            button1.ForeColor = Color.White;
            button1.Location = new Point(242, 149);
            button1.Name = "button1";
            button1.Size = new Size(91, 39);
            button1.TabIndex = 15;
            button1.Text = "Agregar";
            button1.UseVisualStyleBackColor = false;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(367, 75);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(68, 23);
            textBox2.TabIndex = 12;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(265, 78);
            label3.Name = "label3";
            label3.Size = new Size(84, 15);
            label3.TabIndex = 11;
            label3.Text = "Stock minimo:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(160, 75);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(68, 23);
            textBox1.TabIndex = 10;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(103, 78);
            label2.Name = "label2";
            label2.Size = new Size(39, 15);
            label2.TabIndex = 9;
            label2.Text = "Stock:";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(585, 75);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(68, 23);
            textBox5.TabIndex = 19;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(481, 78);
            label5.Name = "label5";
            label5.Size = new Size(86, 15);
            label5.TabIndex = 18;
            label5.Text = "Stock maximo:";
            // 
            // InventoryForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(textBox5);
            Controls.Add(label5);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox2);
            Controls.Add(label3);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Name = "InventoryForm";
            Size = new Size(830, 245);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button3;
        private Button button2;
        private Button button1;
        private TextBox textBox2;
        private Label label3;
        private TextBox textBox1;
        private Label label2;
        private TextBox textBox5;
        private Label label5;
    }
}
