using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FarmCentral_StockSystem.Views.Farmer
{
    public partial class Categories : System.Web.UI.Page
    {
        Models.Functions Con;

        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.Functions();
            DisplayCategory();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            //base.VerifyRenderingInServerForm(control);
        }

        private void DisplayCategory()
        {
            string Query = "select * from CategoryTbl";
            CategoryGV.DataSource = Con.getData(Query);
            CategoryGV.DataBind();
        }


        public void SavedData()
        {
            try
            {
                if (Cname.Value == "" || Cremarks.Value == "")
                {
                    ErrMsg.InnerText = "Missing Information";
                }
                else
                {
                    string CatnameTb = Cname.Value;
                    string CatremarkTb = Cremarks.Value;

                    string Query = "insert into CategoryTbl values('{0}','{1}')";
                    Query = string.Format(Query, CatnameTb, CatremarkTb);
                    Con.SetData(Query);
                    DisplayCategory();
                    ErrMsg.InnerText = "Category Has Been Successfully Added";
                }

            }
            catch (Exception Ex)
            {
                ErrMsg.InnerText = Ex.Message;
            }
        }

        public void DeleteData()
        {
            try
            {
                if (Cname.Value == "")
                {
                    ErrMsg.InnerText = "Missing Information";
                }
                else
                {
                    string CatnameTb = Cname.Value;


                    string Query = "delete from CategoryTbl where CatId = {0}";
                    Query = string.Format(Query, CategoryGV.SelectedRow.Cells[1].Text);
                    Con.SetData(Query);
                    DisplayCategory();
                    ErrMsg.InnerText = "Sucessfully Deleted";
                }

            }
            catch (Exception Ex)
            {
                ErrMsg.InnerText = Ex.Message;
            }
        }

        public void EditData()
        {

            try
            {
                if (Cname.Value == "" || Cremarks.Value == "")
                {
                    ErrMsg.InnerText = "Missing Information";
                }
                else
                {
                    string CatnameTb = Cname.Value;
                    string CatremarkTb = Cremarks.Value;

                    string Query = "update CategoryTbl set CatName='{0}',CatDescription ='{1}' where CatId = {2}";
                    Query = string.Format(Query, CatnameTb, CatremarkTb, CategoryGV.SelectedRow.Cells[1].Text);
                    Con.SetData(Query);
                    DisplayCategory();
                    ErrMsg.InnerText = "Updated Sucessfully";
                }

            }
            catch (Exception Ex)
            {
                ErrMsg.InnerText = Ex.Message;
            }
        }



        protected void SaveBtn_Click(object sender, EventArgs e)
        {
            SavedData();
        }

        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            DeleteData();
        }

        int Key = 0;
        protected void CategoryGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            {
                Cname.Value = CategoryGV.SelectedRow.Cells[2].Text;
                Cremarks.Value = CategoryGV.SelectedRow.Cells[3].Text;


                if (Cname.Value == "")
                {
                    Key = 0;
                }
                else
                {
                    Key = Convert.ToInt32(CategoryGV.SelectedRow.Cells[1].Text);
                }
            }
        }

        protected void EditBtn_Click(object sender, EventArgs e)
        {
            EditData();
        }
    }
}
    
