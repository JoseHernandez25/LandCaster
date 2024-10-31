namespace LandCaster.WindowsForms
{
    public partial class Employees : UserControl
    {
       // public readonly IManageLogic _manageLogic;
        public Employees(/*IManageLogic manageLogic*/)
        //public readonly IManageLogic _manageLogic;
        public Employees(/*IManageLogic manageLogic*/)
        {
            //_manageLogic = manageLogic;
            InitializeComponent();
        }

       /* private async void Employees_Load(object sender, EventArgs e)
        {
            //var employee = await _manageLogic.User.GetUsersAsync();

            //dataGridEmployees.DataSource = employee.ToList();

        }
    }
}
