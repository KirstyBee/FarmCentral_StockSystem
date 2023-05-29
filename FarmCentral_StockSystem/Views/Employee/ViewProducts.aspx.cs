using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FarmCentral_StockSystem.Views.Employee
{
    public partial class ViewProducts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        //-------------------------------------------------------------------
        // Method to filter data based on user inputs
        public void FilterData()
        {
            string startDate = Request.Form["StartDateTextBox"];
            string endDate = Request.Form["EndDateTextBox"];
            string productName = ProductNameTextBox.Text;
            string farmId = txtFarmId.Text.Trim();

            string query = "SELECT * FROM ProductTbl WHERE 1=1";

            // Apply filters based on user inputs
            if (!string.IsNullOrEmpty(startDate) && !string.IsNullOrEmpty(endDate))
            {
                query += " AND PrExpDate >= @StartDate AND PrExpDate <= @EndDate";
            }

            if (!string.IsNullOrEmpty(productName))
            {
                query += " AND PrName LIKE @ProductName";
            }

            if (!string.IsNullOrEmpty(farmId))
            {
                query += " AND FarmId = @FarmId";
            }


//-------------------------------------------------------------------------------------------------
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\FarmCentralDb1.mdf;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);

                // Set parameter values for date range filter
                if (!string.IsNullOrEmpty(startDate) && !string.IsNullOrEmpty(endDate))
                {
                    command.Parameters.AddWithValue("@StartDate", DateTime.Parse(startDate));
                    command.Parameters.AddWithValue("@EndDate", DateTime.Parse(endDate));
                }

                // Set parameter value for product name filter
                if (!string.IsNullOrEmpty(productName))
                {
                    command.Parameters.AddWithValue("@ProductName", "%" + productName + "%");
                }

                // Set parameter value for farmId filter
                if (!string.IsNullOrEmpty(farmId))
                {
                    int farmIdValue;
                    if (int.TryParse(farmId, out farmIdValue))
                    {
                        command.Parameters.AddWithValue("@FarmId", farmIdValue);
                    }
                    else
                    {
                        // FarmId is not a valid integer, handle the situation 
                        ErrMsg.InnerText = "Invalid farmer";
                    }
                }

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                ProductGV.DataSource = dt;
                ProductGV.DataBind();
            }
    }
        //--------------------------------------------------------------------------------------------------
        // Event handler for the FilterButton click event
        protected void FilterButton_Click(object sender, EventArgs e)
        {
            FilterData();
        }

        //------------------------------------------------------------------------------------
        //Event handler for the SelectedIndexChanged event of the ProductGV GridView
        protected void ProductGV_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}



