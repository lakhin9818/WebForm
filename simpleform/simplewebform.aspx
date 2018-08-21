<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="simplewebform.aspx.cs" Inherits="simpleform.simplewebform" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>name</td>
                    <td><asp:TextBox id="name" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Age</td>
                    <td><asp:TextBox ID="age" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Adress</td>
                    <td><asp:TextBox ID="address" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td></td>
                    <td><asp:Button Text="save" ID="save" runat="server" OnClick="save_Click"/>
                        <asp:Button Text="reset" ID="reset" runat="server" OnClick="reset_Click"/></td>
                </tr>
                <tr>
                    <td></td>
                    <td><asp:GridView ID="grd" runat="server" OnRowCommand="grd_RowCommand" AutoGenerateColumns="false" >
                        <Columns>
                            <asp:TemplateField HeaderText="name" >
                                <ItemTemplate>
                                    <%#Eval("name") %>
                                </ItemTemplate>

                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="age" >
                                <ItemTemplate>
                                    <%#Eval("age") %>
                                </ItemTemplate>

                            </asp:TemplateField> <asp:TemplateField HeaderText="address" >
                                <ItemTemplate>
                                    <%#Eval("address") %>
                                </ItemTemplate>

                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="delete" >
                                <ItemTemplate>
                                 <asp:LinkButton id="delete" runat="server" Text="delete" CommandName="DLT" CommandArgument='<%#Eval("id") %>' ></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                             <asp:TemplateField HeaderText="edit" >
                                <ItemTemplate>
                                 <asp:LinkButton id="edit" runat="server" Text="edit" CommandName="EDT" CommandArgument='<%#Eval("id") %>' ></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        </asp:GridView></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
