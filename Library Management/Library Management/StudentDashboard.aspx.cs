using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library_Management
{
    public partial class StudentDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //bindProfile();
                try
                {
                    if (Session["Id"].ToString() != "")
                    {
                        String name = Session["Name"].ToString();
                        String id = Request.Cookies["StudentCookies"].Value;

                        bindProfile();
                    }
                    else
                    {
                        Response.Redirect("Login.aspx", true);
                    }
                }
                catch (Exception ex)
                {
                    Response.Redirect("Login.aspx", true);
                }
            }

            
        }
        public void bindProfile()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Name"));
            dt.Columns.Add(new DataColumn("ID"));
            

            //Now Add Values
            dt.Rows.Add("--Select--","0");
            dt.Rows.Add("Profile", "1");
            dt.Rows.Add("LogOut", "2");

            dropDownListProfile.DataSource = dt;
            dropDownListProfile.DataBind();
            dropDownListProfile.DataTextField = "Name";
            dropDownListProfile.DataValueField = "ID";
            dropDownListProfile.DataBind();


        }

        protected void dropDownListProfile_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dropDownListProfile.SelectedItem.ToString() == "Profile" || dropDownListProfile.SelectedValue.ToString() == "1")
            {
                Response.Redirect("Profile.aspx", true);
            }
            else if (dropDownListProfile.SelectedItem.ToString() == "LogOut")
            {
                Response.Redirect("Login.aspx", true);
            }
        }

    }
 }
