using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library_Management
{
    public partial class StudentList : System.Web.UI.Page
    {
        public static Int64 studentIdTemp = 0;
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename=F:\\.Net\\Library Management\\Library Management\\App_Data\\Library.mdf;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                
                bindStudentList();
            }
        }
        protected void bindStudentList()
        {
            try
            {
                DataTable dt = new DataTable();
                string query = "select * from Registration  ";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                con.Open();
                sda.Fill(dt);
                con.Close();
                if (dt.Rows.Count > 0)
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();

                    GridView2.DataSource = dt;
                    GridView2.DataBind();


                }
            }
            catch (Exception ex)
            {

            }
        }
        protected void GridView2_RowCommand1(object sender, GridViewCommandEventArgs e)
        {
            {
                if (e.CommandName == "EditRecord")
                {
                    int rowIndex = ((e.CommandSource as Button).NamingContainer as GridViewRow).RowIndex;

                    GridViewRow gv = GridView2.Rows[rowIndex];
                    //string Name = gv.Cells[1].Text;
                    //txtName.Text = Name;

                    try
                    {
                        Int64 studentId = Int64.Parse(gv.Cells[0].Text);
                        studentIdTemp = studentId;
                        fetchRecord(studentId);
                    }
                    catch
                    {

                    }
                }

                if (e.CommandName == "DeleteRecord")
                {
                    int rowIndex = ((e.CommandSource as Button).NamingContainer as GridViewRow).RowIndex;

                    GridViewRow gv = GridView2.Rows[rowIndex];
                    //string Name = gv.Cells[1].Text;
                    //txtName.Text = Name;

                    try
                    {
                        Int64 studentId = Int64.Parse(gv.Cells[0].Text);
                        studentIdTemp = studentId;
                        deleteRecord(studentId);
                    }
                    catch
                    {

                    }
                }
            }
        }
        public void fetchRecord(Int64 studentId)
        {
            try
            {
                DataTable dt = new DataTable();
                string query = "select * from Registration where id=" + studentId + " ";
                SqlDataAdapter Sda = new SqlDataAdapter(query, con);
                con.Open();
                Sda.Fill(dt);
                con.Close();
                if (dt.Rows.Count > 0)
                {
                    TxtName.Text = dt.Rows[0][1].ToString();

                }
            }

            catch
            {

            }

        }
        public void deleteRecord(Int64 studentId)
        {

            int result = 0;
            DataTable dt = new DataTable();
            string query = "delete from Registration where id=" + studentId + " ";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            result = int.Parse(cmd.ExecuteNonQuery().ToString());
            con.Close();
            if (result > 0)
            {
                studentIdTemp = 0;
                Label1.Text = "Record deleted successfully";
                bindStudentList();

            }


        }

    }
}