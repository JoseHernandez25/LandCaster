using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LandCaster.WindowsForms.DrawerS
{
    public partial class DrawerSlide : UserControl
    {
        public DrawerSlide()
        {
            InitializeComponent();
        }

        private void Verbisagra_Click(object sender, EventArgs e)
        {
            componetsDrawer.Visible = false;
            drawerSlides.Visible = true;
        }

        private void verComponentes_Click(object sender, EventArgs e)
        {
            componetsDrawer.Visible = true;
            drawerSlides.Visible = false;
        }
    }
}
