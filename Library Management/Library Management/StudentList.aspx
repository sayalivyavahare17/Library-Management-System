<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentList.aspx.cs" Inherits="Library_Management.StudentList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Student List</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2>Student List</h2>
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
        <asp:TextBox ID="TxtName" runat="server"></asp:TextBox>
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>

    </form>
</body>
</html>
