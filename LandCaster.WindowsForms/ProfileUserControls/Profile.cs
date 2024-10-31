using LandCaster.BLL;
using LandCaster.Entities.DTOs;
using LandCaster.Entitites.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LandCaster.WindowsForms.ProfileModule
{
    public partial class Profile : UserControl
    {
        public Profile()
        {
            InitializeComponent();

        }
        public void SetUserData(User user)
        {
            LBNombre.Text = user.NormalizedUserName;
            LBUsuario.Text = user.UserName;
            LBCorreoElectronico.Text = user.Email;
            LBTelefono.Text = user.PhoneNumber;

        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
           
        }
    }
}
