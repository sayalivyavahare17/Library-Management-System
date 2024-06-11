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
    public partial class Login : System.Web.UI.Page
    
    {
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename=F:\\.Net\\Library Management\\Library Management\\App_Data\\Library.mdf;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindUserType();
            }

        }
       

        protected void Button1_Click(object sender, EventArgs e)
        {
            Label3.Text = "";


            if (TextBox1.Text == "" && TextBox2.Text == "")
            {
                Label3.Text = "Please enter valid Email & Password";


            }

            try
            {
                DataTable dt = new DataTable();
                string query = "select * from Registration where Email='" + TextBox1.Text + "' and Password='" + TextBox2.Text + "' ";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                con.Open();
                sda.Fill(dt);
                con.Close();
                if (dt.Rows.Count > 0)
                {
            //        Label3.Text = "Login Successfully...";
                    Session["Id"] = dt.Rows[0][0].ToString();
                    Session["Name"] = dt.Rows[0][1].ToString();

                    //Cookies
                    HttpCookie StudentCookies = new HttpCookie("StudentCookies");
                    StudentCookies.Value = dt.Rows[0][0].ToString();
                    StudentCookies.Expires = DateTime.Now.AddHours(1);
                    Response.Cookies.Add(StudentCookies);

                    Response.Redirect("StudentDashboard.aspx", true);
                    
                }
            }
            catch (Exception ex)
            {


            }
            //Response.Redirect("Dashboard.aspx", false);

             

          /*  if (dropDownList.SelectedItem.ToString() == "Librarian" || dropDownList.SelectedValue.ToString() == "1")
            {
                Response.Redirect("Dashboard.aspx", true);
            }
            else if (dropDownList.SelectedItem.ToString() == "Student")
            {
                Response.Redirect("StudentDashboard.aspx", true);
            } */

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registration.aspx", false);
        }
        public void bindUserType()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Name"));
            dt.Columns.Add(new DataColumn("ID"));

            //Now Add Values
            dt.Rows.Add("--Select--", "0");
            dt.Rows.Add("Librarian", "1");
            dt.Rows.Add("Student", "2");

            dropDownList.DataSource = dt;
            dropDownList.DataBind();
            dropDownList.DataTextField = "Name";
            dropDownList.DataValueField = "ID";
            dropDownList.DataBind();


        }
        
        protected void dropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}