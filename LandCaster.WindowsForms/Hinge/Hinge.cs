using LandCaster.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LandCaster.WindowsForms.Hinge
{
    public partial class Hinge : UserControl
    {
        public readonly IManageLogic _manageLogic;
        public Hinge(IManageLogic manageLogic)
        {
            _manageLogic = manageLogic;
            InitializeComponent();
        }
        private async void Hinge_Load(object sender, EventArgs e)
        {
            dataGridHinges.DataSource = await _manageLogic.Hinge.GetHingeAsync();
        }
        private void components1_Load(object sender, EventArgs e)
        {

        }

        private void Verbisagra_Click(object sender, EventArgs e)
        {
            hinges1.Visible = true;
            components1.Visible = false;
        }

        private void verComponentes_Click(object sender, EventArgs e)
        {
            hinges1.Visible = false;
            components1.Visible = true;
        }

 
    }
}
