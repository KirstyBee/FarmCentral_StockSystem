using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FarmCentral_StockSystem.Views.Employee
{

    public partial class Farmers : System.Web.UI.Page
    {
        Models.Functions Con;


        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.Functions();

            if (!IsPostBack) // Ensure data binding only occurs on initial page load, not on postbacks
            {
                DisplayFarmers();
            }
        }


 //---------------------------------------------------------------------------------------------------
        // Method to display farmers' data in the GridView
        private void DisplayFarmers()
        {
            string Query = "select * from FarmerTbl";
            DataTable farmersData = Con.getData(Query);
            if (farmersData.Rows.Count > 0)
            {
                FarmerGV.DataSource = farmersData;
                FarmerGV.DataBind();
            }
            else
            {
                // Handle the situation when no data is available
            }
        }


//---------------------------------------------------------------------------------------------------
        // Override method to verify rendering in a server form
        public override void VerifyRenderingInServerForm(Control control)
        {
            //base.VerifyRenderingInServerForm(control);
        }


//---------------------------------------------------------------------------------------------------
        // Method to save farmer's information
        public void SavedInfo()
        {
            try
            {
                if (Fname.Value == "" || Fsurname.Value == "" || Femail.Value == "" || Fpassword.Value == "" || Fphone.Value == "")
                {
                    ErrMsg.InnerText = "Missing Information";
                }
                else
                {
                    string FnameTb = Fname.Value;
                    string FsurnameTb = Fsurname.Value;
                    string FemailTb = Femail.Value;
                    string FpasswordTb = Fpassword.Value;
                    string FphoneTb = Fphone.Value;

                    string Query = "insert into FarmerTbl values('{0}','{1}','{2}','{3}','{4}')";
                    Query = string.Format(Query, FnameTb, FsurnameTb, FemailTb, FpasswordTb, FphoneTb);
                    Con.SetData(Query);
                    DisplayFarmers();
                    ErrMsg.InnerText = "Farmer Has Been Added";
                }

            }
            catch (Exception Ex)
            {
                ErrMsg.InnerText = Ex.Message;
            }
        }


//---------------------------------------------------------------------------------------------------
        // Method to edit farmer's information
        public void EditInfo()
        {
            try
            {
                if (Fname.Value == "" || Fsurname.Value == "" || Femail.Value == "" || Fpassword.Value == "" || Fphone.Value == "")
                {
                    ErrMsg.InnerText = "Missing Information";
                }
                else
                {
                    string FnameTb = Fname.Value;
                    string FsurnameTb = Fsurname.Value;
                    string FemailTb = Femail.Value;
                    string FpasswordTb = Fpassword.Value;
                    string FphoneTb = Fphone.Value;

                    string Query = "update FarmerTbl set FarmName ='{0}',FarmSurname ='{1}',FarmEmail ='{2}',FarmPassword ='{3}',ContactInformation ='{4}' where FarmId = {5}";
                    Query = string.Format(Query, FnameTb, FsurnameTb, FemailTb, FpasswordTb, FphoneTb, FarmerGV.SelectedRow.Cells[1].Text);
                    Con.SetData(Query);
                    DisplayFarmers();
                    ErrMsg.InnerText = "Your Information Has Been Updated";
                }

            }
            catch (Exception Ex)
            {
                ErrMsg.InnerText = Ex.Message;
            }
        }


//---------------------------------------------------------------------------------------------------
        // Method to delete a farmer's record
        public void DeleteFarmer()
        {
            try
            {
                if (Fname.Value == "")
                {
                    ErrMsg.InnerText = "Missing Information";
                }
                else
                {
                    string FnameTb = Fname.Value;


                    string Query = "delete from FarmerTbl where FarmId = {0}";
                    Query = string.Format(Query, FarmerGV.SelectedRow.Cells[1].Text);
                    Con.SetData(Query);
                    DisplayFarmers();
                    ErrMsg.InnerText = "Sucessfully Deleted";
                }

            }
            catch (Exception Ex)
            {
                ErrMsg.InnerText = Ex.Message;
            }
        }


//---------------------------------------------------------------------------------------------------
        // Event handler for the Save button click event
        protected void btnsave_Click(object sender, EventArgs e)
        {
            SavedInfo();
        }


 //---------------------------------------------------------------------------------------------------
        int Key = 0;
        // Event handler for the SelectedIndexChanged event of the FarmerGV GridView
        protected void FarmerGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow selectedRow = FarmerGV.SelectedRow;

            if (selectedRow != null)
            {
                string farmerId = FarmerGV.DataKeys[selectedRow.RowIndex].Value.ToString();

                Fname.Value = selectedRow.Cells[2].Text;
                Fsurname.Value = selectedRow.Cells[3].Text;
                Femail.Value = selectedRow.Cells[4].Text;
                Fpassword.Value = selectedRow.Cells[5].Text;
                Fphone.Value = selectedRow.Cells[6].Text;

                Key = Convert.ToInt32(farmerId);
            }
            else
            {
                // Handle the situation when no row is selected
            }
        }


//---------------------------------------------------------------------------------------------------
        // Event handler for the Edit button click event
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            EditInfo();
        }


//---------------------------------------------------------------------------------------------------
        // Event handler for the Delete button click event
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteFarmer();
        }
        }
    }

//---------------------------------------------------------------------------------------------------


