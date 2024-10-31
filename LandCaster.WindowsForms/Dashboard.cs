using LandCaster.BLL;
using LandCaster.WindowsForms.ProfileModule;

namespace LandCaster.WindowsForms
{
    public partial class Dashboard : Form
    {
        private readonly IManageLogic _manageLogic;
        public Dashboard(IManageLogic manageLogic)
        {
            _manageLogic = manageLogic;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BtnUsers_Click(object sender, EventArgs e)
        {
            //users.Visible = true;
            //employees.Visible = false;
            customers.Visible = false;
        }

        private void BtnCustomers_Click(object sender, EventArgs e)
        {
            //users.Visible = false;
            //employees.Visible = false;
            customers.Visible = true;
        }

        private void BtnEmployees_Click(object sender, EventArgs e)
        {
            //users.Visible = false;
            //employees.Visible = true;
            customers.Visible = false;
        }
       
        //public Profile GetProfileControl()
        //{
        //    return profile;
        //}
    }
}
