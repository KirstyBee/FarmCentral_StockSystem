using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FarmCentral_StockSystem.Models
{
    public class Functions
    {
        private SqlConnection Con;
        private SqlCommand cmd;
        private DataTable dt;
        private SqlDataAdapter sda;
        private string ConnString;

        public Functions()
        {
            ConnString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\FarmCentralDb1.mdf;Integrated Security=True";
            Con = new SqlConnection(ConnString);
            cmd = new SqlCommand();
            cmd.Connection = Con;
        }


//-----------------------------------------------------------------------------------------
        // Retrieves data from the database based on the provided query
        public DataTable getData(string Query)
        {
            dt = new DataTable();
            sda = new SqlDataAdapter(Query, ConnString);
            sda.Fill(dt);
                return dt;
        }


//------------------------------------------------------------------------------------------
        // Executes the provided query for data manipulation (insert, update, delete)
        // Returns the number of affected rows
        public int SetData(string Query)
        {
            int Cnt = 0;
            if(Con.State == ConnectionState.Closed)
            {
                Con.Open();
            }
            cmd.CommandText = Query;
            Cnt = cmd.ExecuteNonQuery();
            Con.Close();
            return Cnt;
        }
    }
}
//--------------------------------------------------------------------------------------------