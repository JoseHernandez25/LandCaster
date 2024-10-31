﻿namespace LandCaster.WindowsForms.Hinge
{
    partial class Hinge
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
            panel1 = new Panel();
            Verbisagra = new Button();
            label1 = new Label();
            dataGridHinges = new DataGridView();
            dataGridView1 = new DataGridView();
            panel2 = new Panel();
            verComponentes = new Button();
            label2 = new Label();
            panel3 = new Panel();
            hinges1 = new Hinges();
            components1 = new Components();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridHinges).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ButtonHighlight;
            panel1.Controls.Add(Verbisagra);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(dataGridHinges);
            panel1.Location = new Point(14, 18);
            panel1.Name = "panel1";
            panel1.Size = new Size(498, 382);
            panel1.TabIndex = 5;
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
            label1.Size = new Size(79, 23);
            label1.TabIndex = 1;
            label1.Text = "Bisagras";
            // 
            // dataGridHinges
            // 
            dataGridHinges.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridHinges.Location = new Point(31, 69);
            dataGridHinges.Name = "dataGridHinges";
            dataGridHinges.Size = new Size(438, 277);
            dataGridHinges.TabIndex = 0;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(31, 69);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(438, 277);
            dataGridView1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ButtonHighlight;
            panel2.Controls.Add(verComponentes);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(dataGridView1);
            panel2.Location = new Point(518, 18);
            panel2.Name = "panel2";
            panel2.Size = new Size(498, 382);
            panel2.TabIndex = 6;
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
            // panel3
            // 
            panel3.BackColor = SystemColors.ButtonHighlight;
            panel3.Controls.Add(hinges1);
            panel3.Controls.Add(components1);
            panel3.Location = new Point(14, 406);
            panel3.Name = "panel3";
            panel3.Size = new Size(1003, 289);
            panel3.TabIndex = 7;
            // 
            // hinges1
            // 
            hinges1.Location = new Point(11, 0);
            hinges1.Name = "hinges1";
            hinges1.Size = new Size(999, 297);
            hinges1.TabIndex = 1;
            // 
            // components1
            // 
            components1.Location = new Point(0, 1);
            components1.Name = "components1";
            components1.Size = new Size(1002, 293);
            components1.TabIndex = 0;
            components1.Load += components1_Load;
            // 
            // Hinge
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Hinge";
            Size = new Size(1030, 710);
         //   Load += Hinge_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridHinges).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private DataGridView dataGridHinges;
        private DataGridView dataGridView1;
        private Panel panel2;
        private Label label2;
        private Button Verbisagra;
        private Button verComponentes;
        private Panel panel3;
        private Components components1;
        private Hinges hinges1;
    }
}