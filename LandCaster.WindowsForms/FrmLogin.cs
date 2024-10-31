using LandCaster.BLL;
using LandCaster.DAL.Repository.IRepository;
using LandCaster.Entities.DTOs;
using LandCaster.Entitites.Entities;
using LandCaster.WindowsForms.ProfileModule;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LandCaster.WindowsForms
{
    public partial class FrmLogin : Form
    {
        private readonly IManageLogic _manageLogic;


        public FrmLogin(IManageLogic manageLogic)
        {
            _manageLogic = manageLogic;

            InitializeComponent();
        }


        private async void FrmLogin_Load(object sender, EventArgs e)

        {
            //var data = await _manageLogic.User.GetUsersAsync();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private  void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void login_Click(object sender, EventArgs e)
        {
            var credentials = new Credentials
            {
                Email = user.Text,
                Password = password.Text
            };
            var data = await _manageLogic.Auth.Login(credentials);
            if (data?.Value?.User == null)
            {
                MessageBox.Show($"{data?.Value?.message}");
            }
            else
            {
                // Close the login form
                this.Hide();

                // Open the Dashboard form
                Dashboard dashboard = new Dashboard(_manageLogic);
                dashboard.Show();


                //MessageBox.Show($"Bienvenido, {data?.Value?.User.NormalizedUserName}"); 
                User loggedInUser = data.Value.User;
                dashboard.profile.SetUserData(loggedInUser);
            }
        }


        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
