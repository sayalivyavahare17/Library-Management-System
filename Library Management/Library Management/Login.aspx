<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Library_Management.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Form</title>
    <style>
        #form1 {
            margin:150px 400px 150px 400px;
            background-color:ThreeDLightShadow;
            text-align:center;
            padding:15px;
            border-radius:20px;

        }
        #Textbox1{
            border-radius:5px;
        }
         #Textbox2{
            border-radius:5px;
        }
         #Button1{
            border-radius:5px;
        }
         #dropDownList {
            position:fixed;
            top:350px;
            left:686px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Login Form</h2>
    <asp:Panel ID="Panel1" runat="server" Height="300px">
            <br />
            <asp:Label ID="Label1" runat="server" Text="Label">Email:</asp:Label>
            <asp:TextBox ID="TextBox1" runat="server" ></asp:TextBox>
            <br />
          
            <br />
            <asp:Label ID="Label2" runat="server" Text="Label">Password:</asp:Label>
            <asp:TextBox ID="TextBox2" runat="server" TextMode="Password" ></asp:TextBox>
            <br />
        <br />
        <asp:Label ID="Label5" runat="server" Text="Label">Select User type:</asp:Label>
        <br />
         <asp:DropDownList ID="dropDownList" runat="server" AutoPostBack="true" Height="25px" Width="132px" OnSelectedIndexChanged="dropDownList_SelectedIndexChanged">
        
        </asp:DropDownList>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Login" />
            <br />
            <br />
            

            <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
            <br />
            <br />
        <asp:Label ID="Label4" runat="server" Text="Label">Don't have an Account?</asp:Label>
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Register here" />

        </asp:Panel>
    </form>
</body>
</html>
