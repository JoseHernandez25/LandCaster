namespace LandCaster.WindowsForms
{
    partial class Inventory
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
            checkedListBox1 = new CheckedListBox();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            tabPage3 = new TabPage();
            button1 = new Button();
            button2 = new Button();
            label1 = new Label();
            panel1 = new Panel();
            inventoryForm1 = new InventoryControls.InventoryForm();
            panel2 = new Panel();
            textBox1 = new TextBox();
            tabControl1.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // checkedListBox1
            // 
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Items.AddRange(new object[] { "Fabrica 1", "Fabrica 2", "Fabrica 3" });
            checkedListBox1.Location = new Point(24, 68);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(113, 58);
            checkedListBox1.TabIndex = 0;
            checkedListBox1.SelectedIndexChanged += checkedListBox1_SelectedIndexChanged;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Location = new Point(20, 132);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(815, 210);
            tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = SystemColors.ControlDark;
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(807, 182);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Stock";
            tabPage1.Click += tabPage1_Click;
            // 
            // tabPage2
            // 
            tabPage2.BackColor = SystemColors.ControlDark;
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(807, 182);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Entradas";
            tabPage2.Click += tabPage2_Click;
            // 
            // tabPage3
            // 
            tabPage3.BackColor = SystemColors.ControlDark;
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(807, 182);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Salidas";
            tabPage3.Click += tabPage3_Click;
            // 
            // button1
            // 
            button1.Location = new Point(198, 68);
            button1.Name = "button1";
            button1.Size = new Size(169, 25);
            button1.TabIndex = 3;
            button1.Text = "Generar orden de compra";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // button2
            // 
            button2.Location = new Point(660, 68);
            button2.Name = "button2";
            button2.Size = new Size(113, 25);
            button2.TabIndex = 4;
            button2.Text = "Agregar producto";
            button2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(24, 28);
            label1.Name = "label1";
            label1.Size = new Size(95, 23);
            label1.TabIndex = 5;
            label1.Text = "Inventario";
            label1.Click += label1_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ButtonHighlight;
            panel1.Controls.Add(inventoryForm1);
            panel1.Location = new Point(22, 388);
            panel1.Name = "panel1";
            panel1.Size = new Size(845, 179);
            panel1.TabIndex = 6;
            panel1.Paint += panel1_Paint;
            // 
            // inventoryForm1
            // 
            inventoryForm1.Location = new Point(-7, -23);
            inventoryForm1.Name = "inventoryForm1";
            inventoryForm1.Size = new Size(849, 206);
            inventoryForm1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ButtonHighlight;
            panel2.Controls.Add(textBox1);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(tabControl1);
            panel2.Controls.Add(button2);
            panel2.Controls.Add(checkedListBox1);
            panel2.Controls.Add(button1);
            panel2.Location = new Point(18, 17);
            panel2.Name = "panel2";
            panel2.Size = new Size(849, 352);
            panel2.TabIndex = 7;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(396, 68);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(236, 23);
            textBox1.TabIndex = 6;
            textBox1.Text = "Buscador";

            // 
            // Inventory
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            Controls.Add(panel1);
            Controls.Add(panel2);
            Name = "Inventory";
            Size = new Size(896, 619);
            Load += InventoryControlcs_Load;
            tabControl1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private CheckedListBox checkedListBox1;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private Button button1;
        private Button button2;
        private Label label1;
        private Panel panel1;
        private InventoryControls.InventoryForm inventoryForm1;
        private Panel panel2;
        private TextBox textBox1;
    }
}
