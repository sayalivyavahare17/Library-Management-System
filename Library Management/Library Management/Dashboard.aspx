<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Library_Management.Dashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Librarian Dashboard</title>
    <style>
        #form1 {
            text-align:center;
           
        }
        #TotalBooks {
            text-align:center;
            border-radius:10px;
            padding:20px;
            margin:15px;
            margin-top:200px;
            font-size:larger;
        }
        #StudentList {
            text-align:center;
            border-radius:10px;
            padding:20px;
            margin:15px;
            margin-top:200px;
            font-size:larger;
        }

        #LogOut {
            position:fixed;
            top:28px;
            left:1362px;
            border-radius:4px;
        }
        
    </style>
    
</head>
<body style="height: 780px; background-image: url('library.jpg') ;" >
    <form id="form1"  runat="server">
    
    <div >
        <asp:Button ID="TotalBooks" runat="server" Height="231px" Text="Total Books" Width="253px" />

    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="StudentList" runat="server" Height="231px" Text="Student List" OnClick="StudentList_Click" Width="253px" />
        <asp:Button ID="LogOut" runat="server" Height="38px" Text="Log Out" OnClick="LogOut_Click" Width="90px" />
    </div>

    </form>
        
</body>
</html>
