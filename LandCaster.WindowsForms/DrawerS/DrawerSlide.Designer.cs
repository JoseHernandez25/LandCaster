namespace LandCaster.WindowsForms.DrawerS
{
    partial class DrawerSlide
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
            verComponentes = new Button();
            label2 = new Label();
            dataGridView1 = new DataGridView();
            panel1 = new Panel();
            Verbisagra = new Button();
            label1 = new Label();
            dataGridEmployees = new DataGridView();
            panel3 = new Panel();
            drawerSlides = new DrawerSlides();
            componetsDrawer = new ComponetsDrawer();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridEmployees).BeginInit();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ButtonHighlight;
            panel2.Controls.Add(verComponentes);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(dataGridView1);
            panel2.Location = new Point(518, 28);
            panel2.Name = "panel2";
            panel2.Size = new Size(498, 382);
            panel2.TabIndex = 8;
            // 
            // verComponentes
            // 
            verComponentes.Location = new Point(408, 352);
            verComponentes.Name = "verComponentes";
            verComponentes.Size = new Size(75, 23);
            verComponentes.TabIndex = 3;
            verComponentes.Text = "Ver";
            verComponentes.UseVisualStyleBackColor = true;
            verComponentes.Click += verComponentes_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Tahoma", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(31, 28);
            label2.Name = "label2";
            label2.Size = new Size(124, 23);
            label2.TabIndex = 1;
            label2.Text = "Componentes";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(31, 69);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(438, 277);
            dataGridView1.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ButtonHighlight;
            panel1.Controls.Add(Verbisagra);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(dataGridEmployees);
            panel1.Location = new Point(14, 28);
            panel1.Name = "panel1";
            panel1.Size = new Size(498, 382);
            panel1.TabIndex = 7;
            // 
            // Verbisagra
            // 
            Verbisagra.Location = new Point(405, 352);
            Verbisagra.Name = "Verbisagra";
            Verbisagra.Size = new Size(75, 23);
            Verbisagra.TabIndex = 2;
            Verbisagra.Text = "Ver";
            Verbisagra.UseVisualStyleBackColor = true;
            Verbisagra.Click += Verbisagra_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(31, 28);
            label1.Name = "label1";
            label1.Size = new Size(101, 23);
            label1.TabIndex = 1;
            label1.Text = "Correderas";
            // 
            // dataGridEmployees
            // 
            dataGridEmployees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridEmployees.Location = new Point(31, 69);
            dataGridEmployees.Name = "dataGridEmployees";
            dataGridEmployees.Size = new Size(438, 277);
            dataGridEmployees.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ButtonHighlight;
            panel3.Controls.Add(drawerSlides);
            panel3.Controls.Add(componetsDrawer);
            panel3.Location = new Point(15, 419);
            panel3.Name = "panel3";
            panel3.Size = new Size(1003, 294);
            panel3.TabIndex = 9;
            // 
            // drawerSlides
            // 
            drawerSlides.Location = new Point(0, 2);
            drawerSlides.Name = "drawerSlides";
            drawerSlides.Size = new Size(1003, 295);
            drawerSlides.TabIndex = 1;
            // 
            // componetsDrawer
            // 
            componetsDrawer.Location = new Point(-1, 0);
            componetsDrawer.Name = "componetsDrawer";
            componetsDrawer.Size = new Size(1004, 294);
            componetsDrawer.TabIndex = 0;
            // 
            // DrawerSlide
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "DrawerSlide";
            Size = new Size(1027, 727);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridEmployees).EndInit();
            panel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private Button verComponentes;
        private Label label2;
        private DataGridView dataGridView1;
        private Panel panel1;
        private Button Verbisagra;
        private Label label1;
        private DataGridView dataGridEmployees;
        private Panel panel3;
        private DrawerSlides drawerSlides;
        private ComponetsDrawer componetsDrawer;
    }
}
