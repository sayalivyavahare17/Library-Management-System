<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" EnableEventValidation="true" Inherits="Library_Management.Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Student Registration</title>
     <style>
        #form1 {
            background-color:ThreeDLightShadow;
            text-align:center;
            padding:15px;
            border-radius:20px;
            margin:150px 300px 150px 300px;

        }
        #Button1 {
            border-radius:5px;
            background-color:lightcyan;
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Registration Form</h2>
    <div>

         <asp:label ID="Label1" runat="server" text="Label">FirstName:</asp:label>
        <asp:TextBox ID="txtFName" runat="server"></asp:TextBox>

        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Label">MiddleName:</asp:Label>
        <asp:TextBox ID="txtMName" runat="server"  style="width: 168px"></asp:TextBox>

        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="Label">LastName:</asp:Label>
        <asp:TextBox ID="txtLName" runat="server" style="width: 168px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label4" runat="server" Text="Label">Email:</asp:Label>
        <asp:TextBox ID="txtEmail" runat="server" style="width: 168px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label5" runat="server" Text="Label">MobileNo:</asp:Label>
        <asp:TextBox ID="txtMobileNo" runat="server" style="width: 168px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label6" runat="server" Text="Label">Class:</asp:Label>
        <asp:TextBox ID="txtClass" runat="server" style="width: 168px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label7" runat="server" Text="Label">RollNo:</asp:Label>
        <asp:TextBox ID="txtRollNo" runat="server" style="width: 168px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label8" runat="server" Text="Label">Password:</asp:Label>
        <asp:TextBox ID="txtPassword" runat="server" style="width: 168px"></asp:TextBox>
        
        <br />
        <br />
         
        <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click"  />
        
        <br />
        <br />
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <br />
        <asp:Image ID="Image1" width="75px" height="50px" BorderWidth="2" runat="server" />

        <br />
        <br />
        <asp:Button ID="btnUpload" runat="server" Text="Upload"  class="btn btn-Normal btn-primary" OnClick="btnUpload_Click"  />
        <br />
        <br />
        
        <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
        <br />
        <br />
        <asp:Label ID="Label9" runat="server" Text=""></asp:Label>
        <asp:GridView ID="GridView1" runat="server"></asp:GridView>
        <br />
        <br />
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false" OnRowCommand="GridView2_RowCommand1" >
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="SrNo" />
                <asp:BoundField DataField="FirstName" HeaderText="Student Name" />
                <asp:BoundField DataField="MobileNo" HeaderText="Mobile No" />
                
                
                <asp:TemplateField HeaderText="Action">
                    
                    <ItemTemplate>
                        <asp:Button ID="Button2" Text="Edit" runat="server" CommandName="EditRecord" CommandArgument="<%Container.DataItemIndex %>" />
                        
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Action">
                    
                    <ItemTemplate>
                        <asp:Button ID="Button3" Text="Delete" runat="server" CommandName="DeleteRecord" CommandArgument="<%Container.DataItemIndex %>" />
                        
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

    </div>
    </form>
</body>
</html>
