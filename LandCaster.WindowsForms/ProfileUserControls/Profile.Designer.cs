namespace LandCaster.WindowsForms.ProfileModule
{
    partial class Profile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Profile));
            panel1 = new Panel();
            LBNombre = new Label();
            label = new Label();
            label3 = new Label();
            label5 = new Label();
            panel2 = new Panel();
            LBTelefono = new Label();
            LBCorreoElectronico = new Label();
            LBUsuario = new Label();
            LBRol = new Label();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackgroundImage = (Image)resources.GetObject("panel1.BackgroundImage");
            panel1.BackgroundImageLayout = ImageLayout.Stretch;
            panel1.Location = new Point(13, 27);
            panel1.Name = "panel1";
            panel1.Size = new Size(211, 208);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // LBNombre
            // 
            LBNombre.AutoEllipsis = true;
            LBNombre.AutoSize = true;
            LBNombre.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LBNombre.Location = new Point(230, 49);
            LBNombre.Name = "LBNombre";
            LBNombre.Size = new Size(81, 25);
            LBNombre.TabIndex = 1;
            LBNombre.Text = "Nombre";
            // 
            // label
            // 
            label.AutoEllipsis = true;
            label.AutoSize = true;
            label.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label.Image = (Image)resources.GetObject("label.Image");
            label.ImageAlign = ContentAlignment.MiddleLeft;
            label.Location = new Point(338, 114);
            label.Name = "label";
            label.Size = new Size(84, 17);
            label.TabIndex = 2;
            label.Text = "       Usuario:";
            // 
            // label3
            // 
            label3.AutoEllipsis = true;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Image = (Image)resources.GetObject("label3.Image");
            label3.ImageAlign = ContentAlignment.MiddleLeft;
            label3.Location = new Point(536, 114);
            label3.Name = "label3";
            label3.Size = new Size(148, 17);
            label3.TabIndex = 3;
            label3.Text = "       Correo Electronico:";
            // 
            // label5
            // 
            label5.AutoEllipsis = true;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Image = (Image)resources.GetObject("label5.Image");
            label5.ImageAlign = ContentAlignment.MiddleLeft;
            label5.Location = new Point(338, 191);
            label5.Name = "label5";
            label5.Size = new Size(85, 17);
            label5.TabIndex = 4;
            label5.Text = "      Telefono:";
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ControlLightLight;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(LBTelefono);
            panel2.Controls.Add(LBCorreoElectronico);
            panel2.Controls.Add(LBUsuario);
            panel2.Controls.Add(LBRol);
            panel2.Controls.Add(panel1);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(LBNombre);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label);
            panel2.Location = new Point(21, 31);
            panel2.Name = "panel2";
            panel2.Size = new Size(990, 262);
            panel2.TabIndex = 5;
            // 
            // LBTelefono
            // 
            LBTelefono.AutoSize = true;
            LBTelefono.Location = new Point(429, 193);
            LBTelefono.Name = "LBTelefono";
            LBTelefono.Size = new Size(0, 15);
            LBTelefono.TabIndex = 8;
            // 
            // LBCorreoElectronico
            // 
            LBCorreoElectronico.AutoSize = true;
            LBCorreoElectronico.Location = new Point(690, 116);
            LBCorreoElectronico.Name = "LBCorreoElectronico";
            LBCorreoElectronico.Size = new Size(0, 15);
            LBCorreoElectronico.TabIndex = 7;
            // 
            // LBUsuario
            // 
            LBUsuario.AutoSize = true;
            LBUsuario.Location = new Point(428, 116);
            LBUsuario.Name = "LBUsuario";
            LBUsuario.Size = new Size(0, 15);
            LBUsuario.TabIndex = 6;
            // 
            // LBRol
            // 
            LBRol.AutoEllipsis = true;
            LBRol.AutoSize = true;
            LBRol.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LBRol.Image = (Image)resources.GetObject("LBRol.Image");
            LBRol.ImageAlign = ContentAlignment.MiddleLeft;
            LBRol.Location = new Point(536, 191);
            LBRol.Name = "LBRol";
            LBRol.Size = new Size(54, 17);
            LBRol.TabIndex = 5;
            LBRol.Text = "      Rol:";
            // 
            // Profile
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel2);
            Name = "Profile";
            Size = new Size(1039, 322);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label LBNombre;
        private Label label;
        private Label label3;
        private Label label5;
        private Panel panel2;
        private Label LBRol;
        private Label LBUsuario;
        private Label LBCorreoElectronico;
        private Label LBTelefono;
    }
}
