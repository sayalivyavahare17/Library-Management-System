<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentDashboard.aspx.cs" Inherits="Library_Management.StudentDashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Student Dashboard</title>
    <style>
        #form1 {
            text-align:center;
        }
        #SProfile {
            position:fixed;
            top:28px;
            left:1362px;
            height: 34px;
            width: 97px;
        }
        #BBooks {
            position:relative;
            text-align:center;
            border-radius:10px;
            padding:10px;
            margin:10px;
            margin-top:250px;
            font-size:larger;
            font-family:'Times New Roman';

        }
        #Fine {
            border-radius:10px;
            font-size:larger;
             font-family:'Times New Roman';
        }
        #ABooks {
            border-radius:10px;
            font-size:larger;
             font-family:'Times New Roman';
        }
        #dropDownListProfile {
            position:fixed;
            top:31px;
            left:1339px;
        }
    </style>
    <link href="css/bootstrap.css" rel="stylesheet" type="text/css" media="all"/>
    <link href="css/style.css" rel="stylesheet" type="text/css" media="all"/>
</head>
<body>
    <form id="form1" runat="server">
        <br />
    <div >

        <asp:Button ID="BBooks" runat="server" Height="181px" Text="Borrowed Books" Width="195px" />
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Fine" runat="server" Height="181px" Text="Fine" Width="195px" />
&nbsp;&nbsp; &nbsp;&nbsp;
        <asp:Button ID="ABooks" runat="server" Height="181px" Text="Availability of Books" Width="195px" />
        <asp:DropDownList ID="dropDownListProfile" runat="server" AutoPostBack="true" Height="25px" Width="132px" OnSelectedIndexChanged="dropDownListProfile_SelectedIndexChanged">
        
        </asp:DropDownList>

    </div>
        <br />
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
    </form>
</body>
</html>
