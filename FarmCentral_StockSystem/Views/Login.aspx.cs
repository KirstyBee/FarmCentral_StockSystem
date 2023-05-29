using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.SessionState;


namespace FarmCentral_StockSystem.Views
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.Functions();
        }
//----------------------------------------------------------------------------
        public static string Fname;
        int key;


//---------------------------------------------------------------------------
        // Override method to verify rendering in a server form
        public override void VerifyRenderingInServerForm(Control control)
        {
            //base.VerifyRenderingInServerForm(control);
        }
        Models.Functions Con;


//---------------------------------------------------------------------------------
        // Event handler for the SignIn button click event
        protected void SignInBtn_Click(object sender, EventArgs e)
        {
            if (AdminRadioControl.Checked)
            {
                if (Email.Text == "Admin@gmail.com" && Password.Text == "Admin")
                {
                    Response.Redirect("Employee/EmployeeHome.aspx");
                }
                else
                {
                    errMsg.InnerText = "Admin does not exist";
                }
            }
            else
            {
                string Query = "SELECT FarmId, FarmName, FarmEmail, FarmPassword FROM FarmerTbl WHERE FarmEmail = '{0}' AND FarmPassword = '{1}'";
                Query = string.Format(Query, Email.Text, Password.Text);
                DataTable dt = Con.getData(Query);
                if (dt.Rows.Count == 0)
                {
                    errMsg.InnerText = "Wrong user";
                }
                else
                {
                    // Accessing a specific row and column
                    DataRow row = dt.Rows[0];  // Get the first row (index 0)

                    // Accessing value by column name
                    string farmId = row["FarmId"].ToString();

                   // Fname = Email.Text;
                   // key = Convert.ToInt32(dt.Rows[0][0].ToString());
                    Session["FarmId"] = farmId; // Store Fname in session
                    //Session["key"] = key; // Store key in session
                    Response.Redirect("Farmer/Products.aspx");
                }
            }

        }
    }
}