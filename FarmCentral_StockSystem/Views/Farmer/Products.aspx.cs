using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FarmCentral_StockSystem.Views.Farmer
{
    public partial class Products : System.Web.UI.Page
    {
        Models.Functions Con;

        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.Functions();
            //GetCategory();
            DisplayProducts();
        }


//------------------------------------------------------------------------------------
        // Override method to verify rendering in a server form
        public override void VerifyRenderingInServerForm(Control control)
        {
            //base.VerifyRenderingInServerForm(control);
        }


//-------------------------------------------------------------------------------------
        // Method to display products in the GridView
        private void DisplayProducts()
        {
            string Query = "select * from ProductTbl where FarmId = " + Session["FarmId"].ToString();
            ProductGV.DataSource = Con.getData(Query);
            ProductGV.DataBind();
        }


//-------------------------------------------------------------------------------------
        // Event handler for the Save button click event
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Pname.Value == "" || Pprice.Value == "" || Pquantity.Value == "")
                {
                    ErrMsg.InnerText = "Missing Information";
                }
                else
                {
                    string PnameTb = Pname.Value;
                    string PpriceTb = Pprice.Value;
                    string PquantityTb = Pquantity.Value;
                    string PexDate = Exdate.Value;

                    string Query = "INSERT INTO ProductTbl (PrName, PrPrice, PrQty, PrExpDate, FarmId) " +
                                   "VALUES (@Pname, @Pprice, @Pquantity, @PexDate, @FarmId)";

                    // Database connection string
                    string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\FarmCentralDb1.mdf;Integrated Security=True";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand(Query, connection);
                        command.Parameters.AddWithValue("@Pname", PnameTb);
                        command.Parameters.AddWithValue("@Pprice", PpriceTb);
                        command.Parameters.AddWithValue("@Pquantity", PquantityTb);
                        command.Parameters.AddWithValue("@PexDate", DateTime.Parse(PexDate));
                        command.Parameters.AddWithValue("@FarmId", Session["FarmId"].ToString());
                        command.ExecuteNonQuery();
                    }

                    DisplayProducts();
                    ErrMsg.InnerText = "Product Added";
                }
            }
            catch (Exception ex)
            {
                ErrMsg.InnerText = "An error occurred while adding the product: " + ex.Message;
            }
        }


//-------------------------------------------------------------------------------------
        // Event handler for the Edit button click event
        protected void BtnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (Pname.Value == "" || Pprice.Value == "" || Pquantity.Value == "")
                {
                    ErrMsg.InnerText = "Missing Information";
                }
                else
                {
                    string PnameTb = Pname.Value;
                    string PpriceTb = Pprice.Value;
                    string PquantityTb = Pquantity.Value;
                    string PexDate = Exdate.Value;

                    string Query = "UPDATE ProductTbl SET PrName = @Pname, PrPrice = @Pprice, PrQty = @Pquantity, PrExpDate = @PexDate WHERE FarmId = @FarmId AND PrId = @PrId";


                    string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\FarmCentralDb1.mdf;Integrated Security=True";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand(Query, connection);
                        command.Parameters.AddWithValue("@Pname", PnameTb);
                        command.Parameters.AddWithValue("@Pprice", PpriceTb);
                        command.Parameters.AddWithValue("@Pquantity", PquantityTb);
                        command.Parameters.AddWithValue("@PexDate", PexDate);
                        command.Parameters.AddWithValue("@FarmId", Session["FarmId"].ToString());
                        command.Parameters.AddWithValue("@PrId", ProductGV.SelectedRow.Cells[1].Text);

                        command.ExecuteNonQuery();
                    }
                    
                    DisplayProducts();
                    ErrMsg.InnerText = "Updated Successfully";
                }
            }
            catch (Exception ex)
            {
                ErrMsg.InnerText = "An error occurred while adding the product: " + ex.Message;
            }
        }


//-------------------------------------------------------------------------------------
        int Key = 0;

        // Event handler for the SelectedIndexChanged event of the ProductGV GridView
        protected void ProductGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            Pname.Value = ProductGV.SelectedRow.Cells[2].Text;
            Pprice.Value = ProductGV.SelectedRow.Cells[3].Text;
            Pquantity.Value = ProductGV.SelectedRow.Cells[4].Text;
            Exdate.Value = ProductGV.SelectedRow.Cells[5].Text;


            if (Pname.Value == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(ProductGV.SelectedRow.Cells[1].Text);
            }
        }


//-------------------------------------------------------------------------------------
        // Event handler for the Delete button click event
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (Pname.Value == "" )
                {
                    ErrMsg.InnerText = "Missing Information";
                }
                else
                {
                    string PnameTb = Pname.Value;
                    string PpriceTb = Pprice.Value;
                    string PquantityTb = Pquantity.Value;
                    string PexDate = Exdate.Value;

                    string Query = "delete from ProductTbl where FarmId = @FarmId AND PrId = @PrId";


                    string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\FarmCentralDb1.mdf;Integrated Security=True";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand(Query, connection);
                        command.Parameters.AddWithValue("@Pname", PnameTb);
                        command.Parameters.AddWithValue("@Pprice", PpriceTb);
                        command.Parameters.AddWithValue("@Pquantity", PquantityTb);
                        command.Parameters.AddWithValue("@PexDate", PexDate);
                        command.Parameters.AddWithValue("@FarmId", Session["FarmId"].ToString());
                        command.Parameters.AddWithValue("@PrId", ProductGV.SelectedRow.Cells[1].Text);

                        command.ExecuteNonQuery();
                    }

                    DisplayProducts();
                    ErrMsg.InnerText = "Successfully Delete";
                }
            }
            catch (Exception ex)
            {
                ErrMsg.InnerText = "An error occurred while adding the product: " + ex.Message;
            }
        }
    }
}
//-------------------------------------------------------------------------------------    

