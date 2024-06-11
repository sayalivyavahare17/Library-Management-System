using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library_Management
{
    public partial class Registration : System.Web.UI.Page
    {
       public static Int64 studentIdTemp = 0;
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename=F:\\.Net\\Library Management\\Library Management\\App_Data\\Library.mdf;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                btnUpdate.Visible = false;
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
                    string pathName = Server.MapPath("~/images/");
                    string imgname = "";
                    imgname = dt.Rows[0][9].ToString();
                    if (imgname == "" || imgname == null)
                    {

                    }
                    else
                    {
                        Image1.ImageUrl = pathName + imgname;
                        Image1.Height = 250;
                        Image1.Width = 250;
                        Image1.DataBind();
                    }
                    txtFName.Text = dt.Rows[0][1].ToString();
                    txtMName.Text = dt.Rows[0][2].ToString();
                    txtLName.Text = dt.Rows[0][3].ToString();
                    txtEmail.Text = dt.Rows[0][4].ToString();
                    txtMobileNo.Text = dt.Rows[0][5].ToString();
                    txtClass.Text = dt.Rows[0][6].ToString();
                    txtRollNo.Text = dt.Rows[0][7].ToString();
                    txtPassword.Text = dt.Rows[0][8].ToString();
                    btnUpdate.Visible = true;
                    studentIdTemp = studentId;

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
                Label9.Text = "Record deleted successfully";
                bindStudentList();

            }


        }





        protected void Button1_Click(object sender, EventArgs e)
        {
            Label9.Text = "";
            if (txtFName.Text == "")
            {
                txtFName.Focus();
                Label9.Text = "Please enter First Name";
                return;
            }
            if (txtMName.Text == "")
            {
                txtMName.Focus();
                Label9.Text = "Please enter Middle Name";
                return;
            }
            if (txtLName.Text == "")
            {
                txtLName.Focus();
                Label9.Text = "Please enter Last Name";
                return;
            }
            if (txtEmail.Text == "")
            {
                txtEmail.Focus();
                Label9.Text = "Please enter Email";
                return;
            }
            if (txtMobileNo.Text == "")
            {
                txtMobileNo.Focus();
                Label9.Text = "Please enter Mobile No";
                return;
            }
            if (txtClass.Text == "")
            {
                txtClass.Focus();
                Label9.Text = "Please enter Class";
                return;
            }
            if (txtRollNo.Text == "")
            {
                txtRollNo.Focus();
                Label9.Text = "Please enter Roll No";
                return;
            }
            if (txtPassword.Text == "")
            {
                txtPassword.Focus();
                Label9.Text = "Please enter Password";
                return;
            }
            if (FileUpload1.HasFile)
            {

                string pathName = "";
                string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                string extension = Path.GetExtension(FileUpload1.PostedFile.FileName);
                if (extension == ".png" || extension == ".jpg" || extension == ".jpeg")
                {
                    string targetPath =Server.MapPath("images");
                    if (!System.IO.Directory.Exists(targetPath))
                    {
                        System.IO.Directory.CreateDirectory(targetPath);
                        pathName = Server.MapPath("~/images/");

                        FileUpload1.SaveAs(pathName + filename);
                        //  fileToUpload.PostedFile.SaveAs(targetPath + ImageFileName);
                    }
                    else
                    {
                        pathName = Server.MapPath("~/images/");

                        FileUpload1.SaveAs(pathName + filename);
                        //fileToUpload.PostedFile.SaveAs(targetPath + ImageFileName);
                    }

                    pathName = Server.MapPath("~/images/");
                    FileUpload1.SaveAs(pathName + filename);

                    try
                    {
                        int result = 0;
                        string str = "INSERT INTO REGISTRATION (FirstName,MiddleName,LastName,Email,MobileNo,Class,RollNo,Password,image) VALUES('" + txtFName.Text + "','" + txtMName.Text + "','" + txtLName.Text + "','" + txtEmail.Text + "','" + txtMobileNo.Text + "','" + txtClass.Text + "','" + txtRollNo.Text + "','" + txtPassword.Text + "','" + filename + "')";
                        SqlCommand cmd = new SqlCommand(str, con);
                        con.Open();
                        //cmd.ExecuteScalar();
                        result = int.Parse(cmd.ExecuteNonQuery().ToString());
                        con.Close();
                        if (result > 0)
                        {
                            clear();
                            Label9.Text = "Registration done successfully";

                        }

                    }
                    catch (Exception ex)
                    {
                        Label9.Text = "error: " + ex;
                    }
                }
                else
                {
                    Label9.Text = "Please upload valid image file";
                    return;
                }
            }
        }

        

        

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            #region
            Label9.Text = "";
            if (txtFName.Text == "")
            {
                txtFName.Focus();
                Label9.Text = "Please enter First Name";
                return;
            }
            if (txtMName.Text == "")
            {
                txtMName.Focus();
                Label9.Text = "Please enter Middle Name";
                return;
            }
            if (txtLName.Text == "")
            {
                txtLName.Focus();
                Label9.Text = "Please enter Last Name";
                return;
            }
            if (txtEmail.Text == "")
            {
                txtEmail.Focus();
                Label9.Text = "Please enter Email";
                return;
            }
            if (txtMobileNo.Text == "")
            {
                txtMobileNo.Focus();
                Label9.Text = "Please enter Mobile No";
                return;
            }
            if (txtClass.Text == "")
            {
                txtClass.Focus();
                Label9.Text = "Please enter Class";
                return;
            }
            if (txtRollNo.Text == "")
            {
                txtRollNo.Focus();
                Label9.Text = "Please enter Roll No";
                return;
            }
            if (txtPassword.Text == "")
            {
                txtPassword.Focus();
                Label9.Text = "Please enter Password";
                return;
            }
            #endregion

            try
            {
                int result = 0;
                string updatestr = "UPDATE REGISTRATION SET FirstName='" + txtFName.Text + "',MiddleName='" + txtMName.Text + "',LastName='" + txtLName.Text + "',Email='" + txtEmail.Text + "',MobileNo='" + txtMobileNo.Text + "',Class='" + txtClass.Text + "',RollNo='" + txtRollNo.Text + "',Password='" + txtPassword.Text + "'  where id=" + studentIdTemp + "";
                SqlCommand cmd = new SqlCommand(updatestr, con);
                con.Open();
                //cmd.ExecuteScalar();
                result = int.Parse(cmd.ExecuteNonQuery().ToString());
                con.Close();
                if (result > 0)
                {
                    studentIdTemp = 0;
                    clear();
                    Label9.Text = "Record updated successfully";
                    btnUpdate.Visible = false;
                    bindStudentList();

                }

            }
            catch (Exception ex)
            {
                Label9.Text = "error: " + ex;
            }
        }

        public void clear()
        {
            txtFName.Text = "";
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            string pathName = "";
            string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
            string extension = Path.GetExtension(FileUpload1.PostedFile.FileName);
            if (extension == ".png" || extension == ".jpg")
            {
                pathName = Server.MapPath("~/images/");
                FileUpload1.SaveAs(pathName + filename);


            }
            if (extension == ".pdf")
            {
                pathName = Server.MapPath("~/docs/");
                FileUpload1.SaveAs(pathName + filename);
            }


        }


       
    }
    }
 