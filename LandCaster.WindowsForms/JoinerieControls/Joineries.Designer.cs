namespace LandCaster.WindowsForms.JoinerieControls
{
    partial class Joineries
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
            PanelJoinerie = new Panel();
            LBJoinerie = new Label();
            dataGridViewJoinerie = new DataGridView();
            PanelJoinerie.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewJoinerie).BeginInit();
            SuspendLayout();
            // 
            // PanelJoinerie
            // 
            PanelJoinerie.Controls.Add(dataGridViewJoinerie);
            PanelJoinerie.Controls.Add(LBJoinerie);
            PanelJoinerie.Location = new Point(3, 3);
            PanelJoinerie.Name = "PanelJoinerie";
            PanelJoinerie.Size = new Size(1033, 760);
            PanelJoinerie.TabIndex = 0;
            // 
            // LBJoinerie
            // 
            LBJoinerie.AutoSize = true;
            LBJoinerie.Font = new Font("Tahoma", 14.25F);
            LBJoinerie.Location = new Point(13, 13);
            LBJoinerie.Name = "LBJoinerie";
            LBJoinerie.Size = new Size(83, 23);
            LBJoinerie.TabIndex = 0;
            LBJoinerie.Text = "Armados";
            // 
            // dataGridViewJoinerie
            // 
            dataGridViewJoinerie.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewJoinerie.Location = new Point(13, 39);
            dataGridViewJoinerie.Name = "dataGridViewJoinerie";
            dataGridViewJoinerie.Size = new Size(1017, 339);
            dataGridViewJoinerie.TabIndex = 1;
            // 
            // Joineries
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(PanelJoinerie);
            Name = "Joineries";
            Size = new Size(1039, 766);
            PanelJoinerie.ResumeLayout(false);
            PanelJoinerie.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewJoinerie).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel PanelJoinerie;
        private Label LBJoinerie;
        private DataGridView dataGridViewJoinerie;
    }
}
