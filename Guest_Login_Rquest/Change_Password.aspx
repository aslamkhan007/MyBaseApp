<%@ Page Title="" Language="VB" MasterPageFile="~/Guest_Login_Rquest/Admin.master" AutoEventWireup="false" CodeFile="Change_Password.aspx.vb" Inherits="Guest_Login_Rquest_Change_Password" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <asp:Panel ID="Panel1" runat="server">
        <table style="width: 107%;">
            <tr>
                <td style="width: 63px">
                    &nbsp;</td>
                <td style="width: 179px">
                    <div ID="Di3">
                        <h2>
                            <asp:Label ID="lblUserName" runat="server" Text="UserName"></asp:Label>
                        </h2>
                    </div>
                </td>
                <td>
                    &nbsp;<asp:TextBox ID="txtUsername" runat="server" CssClass="textbox"></asp:TextBox>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 63px">
                    &nbsp;
                </td>
                <td style="width: 179px">
                    <div ID="Div1">
                        <h2>
                            <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
                        </h2>
                    </div>
                </td>
                <td>
                    &nbsp;<asp:TextBox ID="txtPassword" runat="server" CssClass="textbox"></asp:TextBox>
                </td>
            </tr>
        </table>
        <table style="width: 107%;">
            <tr>
                <td align="center">
                    <asp:Button ID="btnSave" runat="server" CssClass="cssbutton" Text="Save" />
                    <asp:Button ID="btnClose" runat="server" CssClass="cssbutton" Text="Close" />
                    <asp:Button ID="btnRequest" runat="server" CssClass="cssbutton" 
                        PostBackUrl="~/Guest_Login_Rquest/Guest_Internet_Login_Request.aspx" 
                        Text="Internet Request" />
                    <asp:Button ID="btnHome" runat="server" CssClass="cssbutton" 
                        PostBackUrl="~/Emp_Home.aspx" Text="Home" />
                    <asp:Button ID="btnReport" runat="server" CssClass="cssbutton" 
                        PostBackUrl="~/Guest_Login_Rquest/Report.aspx" Text="Report" />
                </td>
            </tr>
            <tr>
                <td align="center">
                    &nbsp;</td>
            </tr>
        </table>
        <table style="width: 107%;">
            <tr>
                <td style="width: 232px">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
        <table style="width: 100%;">
            <tr>
                <td style="width: 87px">
                    &nbsp;</td>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                        DataKeyNames="Trans_no" DataSourceID="SqlDataSource1" 
                        EnableModelValidation="True" Width="700px" CssClass="GridViewStyle">
                        <Columns>
                            <asp:CommandField ShowEditButton="True" ShowInsertButton="True" />
                            <asp:BoundField DataField="Trans_no" HeaderText="Trans_no" 
                                InsertVisible="False" ReadOnly="True" SortExpression="Trans_no">
                            <ControlStyle CssClass="textbox" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Username" HeaderText="Username" 
                                SortExpression="Username">
                            <ControlStyle CssClass="textbox" Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Password" HeaderText="Password" 
                                SortExpression="Password">
                            <ControlStyle CssClass="textbox" Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status">
                            <ControlStyle CssClass="textbox" Width="20px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="UsedBY_Guest" HeaderText="UsedBY_Guest" 
                                SortExpression="UsedBY_Guest">
                            <ControlStyle CssClass="textbox" Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="UsedDate" HeaderText="UsedDate" 
                                SortExpression="UsedDate">
                            <ControlStyle CssClass="textbox" Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="DeactivationDate" HeaderText="DeactivationDate" 
                                SortExpression="DeactivationDate">
                            <ControlStyle CssClass="textbox" Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="RequestID" HeaderText="RequestID" 
                                SortExpression="RequestID">
                            <ControlStyle CssClass="textbox" Width="50px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="SecurityCode" HeaderText="SecurityCode" 
                                SortExpression="SecurityCode">
                            <ControlStyle CssClass="textbox" Width="100px" />
                            </asp:BoundField>
                        </Columns>
                        <HeaderStyle CssClass="HeaderStyle" />
                        <RowStyle CssClass="RowStyle" />
                        <SelectedRowStyle CssClass="SelectedRowStyle" />
                    </asp:GridView>
                    </ContentTemplate>
                    </asp:UpdatePanel>
                    
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:misjctdev %>" InsertCommand="INSERT INTO [Jct_Guest_Internet_LoginDetail] ([Username], [Password], [Status], [UsedBY_Guest], [UsedDate], [DeactivationDate], [RequestID], [SecurityCode]) VALUES (@Username, @Password, @Status, @UsedBY_Guest, @UsedDate, @DeactivationDate, @RequestID, @SecurityCode)" 
                        SelectCommand="SELECT [Trans_no], [Username], [Password], [Status], [UsedBY_Guest], [UsedDate], [DeactivationDate], [RequestID], [SecurityCode] FROM [Jct_Guest_Internet_LoginDetail]" 
                        UpdateCommand="UPDATE [Jct_Guest_Internet_LoginDetail] SET [Username] = @Username, [Password] = @Password, [Status] = @Status, [UsedBY_Guest] = @UsedBY_Guest, [UsedDate] = @UsedDate, [DeactivationDate] = @DeactivationDate, [RequestID] = @RequestID, [SecurityCode] = @SecurityCode WHERE [Trans_no] = @Trans_no" 
                        DeleteCommand="DELETE FROM [Jct_Guest_Internet_LoginDetail] WHERE [Trans_no] = @Trans_no">
                        <DeleteParameters>
                            <asp:Parameter Name="Trans_no" Type="Int32" />
                        </DeleteParameters>
                        <InsertParameters>
                            <asp:Parameter Name="Username" Type="String" />
                            <asp:Parameter Name="Password" Type="String" />
                            <asp:Parameter Name="Status" Type="String" />
                            <asp:Parameter Name="UsedBY_Guest" Type="String" />
                            <asp:Parameter Name="UsedDate" Type="DateTime" />
                            <asp:Parameter Name="DeactivationDate" Type="DateTime" />
                            <asp:Parameter Name="RequestID" Type="Int32" />
                            <asp:Parameter Name="SecurityCode" Type="Int32" />
                        </InsertParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="Username" Type="String" />
                            <asp:Parameter Name="Password" Type="String" />
                            <asp:Parameter Name="Status" Type="String" />
                            <asp:Parameter Name="UsedBY_Guest" Type="String" />
                            <asp:Parameter Name="UsedDate" Type="DateTime" />
                            <asp:Parameter Name="DeactivationDate" Type="DateTime" />
                            <asp:Parameter Name="RequestID" Type="Int32" />
                            <asp:Parameter Name="SecurityCode" Type="Int32" />
                            <asp:Parameter Name="Trans_no" Type="Int32" />
                        </UpdateParameters>
                    </asp:SqlDataSource>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 87px">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>

