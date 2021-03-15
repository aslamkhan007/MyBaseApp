<%@ Page Title="" Language="C#" MasterPageFile="~/Courier Tracking System/MasterPage.master" AutoEventWireup="true" CodeFile="Serial_Master.aspx.cs" Inherits="Courier_Tracking_System_Serial_Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="tableheader" colspan="3">
                <asp:Label ID="Label18" runat="server" Text="Generate Serial Number"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 172px">
                <asp:Label ID="Label19" runat="server" Text="Prefix"></asp:Label>
            </td>
            <td class="NormalText" style="width: 141px">
                <asp:TextBox ID="txtPrefix" runat="server" CssClass="NormalText" MaxLength="3"></asp:TextBox>
            </td>
            <td class="NormalText">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtPrefix" ErrorMessage="*Not More than 3 Words"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 172px">
                <asp:Label ID="Label20" runat="server" Text="PostFix"></asp:Label>
            </td>
            <td class="NormalText" style="width: 141px">
                <asp:TextBox ID="txtPostfix" runat="server" CssClass="NormalText" MaxLength="4"></asp:TextBox>
            </td>
            <td class="NormalText">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtPostfix" ErrorMessage="*Enter Current Year"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 172px">
                <asp:Label ID="Label21" runat="server" Text="Remarks"></asp:Label>
            </td>
            <td class="NormalText" style="width: 141px">
                <asp:TextBox ID="txtRemarks" runat="server" CssClass="NormalText"></asp:TextBox>
            </td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="3">
                <asp:LinkButton ID="lnkAdd" runat="server" CssClass="buttonc" 
                    onclick="lnkAdd_Click">Add</asp:LinkButton>
                <asp:LinkButton ID="lnkEdit" runat="server" CssClass="buttonc">Edit</asp:LinkButton>
                <asp:LinkButton ID="lnkDelete" runat="server" CssClass="buttonc">Delete</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="3">
                <asp:LinkButton ID="lnkFirst" runat="server" CssClass="buttonc">First</asp:LinkButton>
                <asp:LinkButton ID="lnkNext" runat="server" CssClass="buttonc">Next</asp:LinkButton>
                <asp:LinkButton ID="lnkPrevious" runat="server" CssClass="buttonc">Previous</asp:LinkButton>
                <asp:LinkButton ID="lnkLast" runat="server" CssClass="buttonc">Last</asp:LinkButton>
                <asp:LinkButton ID="lnkSearch" runat="server" CssClass="buttonc">Search</asp:LinkButton>
            </td>
        </tr>
    </table>
    <table style="width:100%;">
        <tr>
            <td class="NormalText" colspan="3">
                <asp:Panel ID="Panel1" runat="server" CssClass="panelbg">
                    <asp:GridView ID="GridView1" runat="server" CssClass="GridView" 
                        EnableModelValidation="True" AutoGenerateColumns="False" 
                        DataKeyNames="Sr_no" DataSourceID="SqlDataSource1">
                        <Columns>
                            <asp:BoundField DataField="Sr_no" HeaderText="Sr_no" InsertVisible="False" 
                                ReadOnly="True" SortExpression="Sr_no" />
                            <asp:BoundField DataField="UserCode" HeaderText="UserCode" 
                                SortExpression="UserCode" />
                            <asp:BoundField DataField="Prefix" HeaderText="Prefix" 
                                SortExpression="Prefix" />
                            <asp:BoundField DataField="PostFix" HeaderText="PostFix" 
                                SortExpression="PostFix" />
                            <asp:BoundField DataField="Remarks" HeaderText="Remarks" 
                                SortExpression="Remarks" />
                            <asp:BoundField DataField="STATUS" HeaderText="STATUS" 
                                SortExpression="STATUS" />
                            <asp:BoundField DataField="EntryDate" HeaderText="EntryDate" 
                                SortExpression="EntryDate" />
                        </Columns>
                        <HeaderStyle CssClass="HeaderStyle" />
                        <RowStyle CssClass="RowStyle" />
                        <SelectedRowStyle CssClass="SelectedRowStyle" />
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                        SelectCommand="SELECT [Sr_no], [UserCode], [Prefix], [PostFix], [Remarks], [STATUS], [EntryDate] FROM [jct_courier_serial_master]">
                    </asp:SqlDataSource>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 172px">
                &nbsp;</td>
            <td class="NormalText" style="width: 141px">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 172px">
                &nbsp;</td>
            <td class="NormalText" style="width: 141px">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 172px">
                &nbsp;</td>
            <td class="NormalText" style="width: 141px">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 172px">
                &nbsp;</td>
            <td class="NormalText" style="width: 141px">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

