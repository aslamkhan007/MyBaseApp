
<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Grid.aspx.vb" Inherits="Grid" MasterPageFile="~/MasterPage.master" %>


    <asp:Content runat="server"  ContentPlaceHolderID="ContentPlaceHolder1" >
        &nbsp;<table style="width: 584px; height: 128px">
            <tr>
                <td style="width: 445px">
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Verdana" Text="Department Name"
                        Width="168px"></asp:Label><asp:DropDownList ID="DDLDeptname" runat="server" AppendDataBoundItems="True"
                            AutoPostBack="True" DataSourceID="Department" DataTextField="DEPTNAME" DataValueField="DEPTNAME"
                            Width="216px">
                        </asp:DropDownList>
                    <asp:Label ID="Label2" runat="server" Font-Names="Verdana" Width="72px"></asp:Label>
                    <asp:SqlDataSource ID="Department" runat="server" ConnectionString="<%$ ConnectionStrings:SaviorConnections %>"
                        SelectCommand="SELECT DEPTCODE +   ' - '   + DEPTNAME AS 'deptname' FROM DEPTMAST ORDER BY DEPTCODE">
                    </asp:SqlDataSource>
                </td>
                <td style="width: 17px">
                </td>
            </tr>
            <tr>
                <td style="width: 445px">
        <asp:GridView ID="GridView1" runat="server" Height="80px"
            HorizontalAlign="Left" Width="632px" AllowPaging="True" CellPadding="3" ForeColor="#333333" GridLines="None" SelectedIndex="0">
            <PagerSettings Position="TopAndBottom" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <EditRowStyle BackColor="#999999" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" BorderStyle="Inset" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" BorderStyle="Dotted" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        </asp:GridView>
                </td>
                <td style="width: 17px">
                </td>
            </tr>
            <tr>
                <td style="width: 445px">
                </td>
                <td style="width: 17px">
                </td>
            </tr>
        </table>
        </asp:Content> 
    
