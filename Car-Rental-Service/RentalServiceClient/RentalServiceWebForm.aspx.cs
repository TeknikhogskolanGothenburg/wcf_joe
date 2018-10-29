using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RentalServiceClient
{
    public partial class RentalServiceWebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            RentalService.RentalServiceTestClient client = new
            RentalService.RentalServiceTestClient("BasicHttpBinding_IRentalServiceTest");
            client.AddCar(TextBox1.Text, TextBox2.Text, Convert.ToInt32(TextBox3.Text), TextBox4.Text);
        }
    }
}