<%@ Page Title="" Language="C#" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="true" CodeFile="payroll_dept_master.aspx.cs" Inherits="PayRoll_payroll_dept_master" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="mytable">
        <tr>
            <td class="tableheader" colspan="4">
            Department Master</td>
        </tr>
        <tr>
            <td class="labelcells">
                Category</td>
            <td class="NormalText">
                <asp:DropDownList ID="ddlcat" runat="server" CssClass="combobox" 
                    AutoPostBack="True" onselectedindexchanged="ddlcat_SelectedIndexChanged">
                    <asp:ListItem Selected="True">Department</asp:ListItem>
                    <asp:ListItem>SubDepartment</asp:ListItem>
                    <asp:ListItem></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="labelcells">
                <asp:Label ID="lbcode" runat="server" Text="Label" Visible="False"></asp:Label>
            </td>
            <td class="labelcells">
                <asp:Label ID="lbid" runat="server" Text="Label" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                <asp:Label ID="lbdept" runat="server" Text="Department" Visible="False"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:DropDownList ID="ddldept" runat="server" CssClass="combobox" 
                    DataSourceID="SqlDataSource1" DataTextField="Department" 
                    DataValueField="Deptcode" Visible="False">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                    SelectCommand="SELECT distinct   Department_Long_Description AS[Department] ,Department_code AS [Deptcode] FROM JCT_payroll_department_master WHERE STATUS='A'">
                </asp:SqlDataSource>
            </td>
            <td class="labelcells">
                &nbsp;</td>
            <td class="labelcells">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="labelcells">
                ShortDescription</td>
            <td class="NormalText">
                <asp:TextBox ID="txtshrtdesc" runat="server" CssClass="textbox"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtshrtdesc" 
                    ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
            <td class="labelcells">
                &nbsp;</td>
            <td class="labelcells">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="labelcells">
                LongDescription</td>
            <td class="NormalText">
                <asp:TextBox ID="txtname" runat="server" CssClass="textbox"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtname" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
            <td class="labelcells">
                &nbsp;</td>
            <td class="labelcells">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="labelcells">
                Effective From</td>
            <td class="NormalText">
                <asp:TextBox ID="txteff_frm" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txteff_frm_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txteff_frm">
                </cc1:CalendarExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="txteff_frm" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
            <td class="labelcells">
                Effective To</td>
            <td class="NormalText">
                <asp:TextBox ID="txteff_to" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txteff_to_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txteff_to">
                </cc1:CalendarExtender>
            </td>
        </tr>
      <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:LinkButton ID="lnkadd" runat="server" CssClass="buttonc" 
                    onclick="lnkadd_Click" ValidationGroup="A">Add</asp:LinkButton>
                <asp:LinkButton ID="lnkupdate" runat="server" CssClass="buttonc" 
                    onclick="lnkupdate_Click" ValidationGroup="A">Update</asp:LinkButton>
                <asp:LinkButton ID="lnkdelete" runat="server" CssClass="buttonc" 
                    onclick="lnkdelete_Click" ValidationGroup="A">Delete</asp:LinkButton>
                <asp:LinkButton ID="lnkreset" runat="server" CssClass="buttonc" 
                    onclick="lnkreset_Click">Reset</asp:LinkButton>
            </td>
        </tr>
             <tr>
            <td class="NormalText" colspan="4">
                <asp:Panel ID="Panel1" runat="server" Height="200px" ScrollBars="Vertical" 
                    Visible="False" Width="1000px">
                    <asp:GridView ID="grdDetail" runat="server" AutoGenerateSelectButton="True" 
                    Width="100%" 
    onselectedindexchanged="grdDetail_SelectedIndexChanged">
                        <AlternatingRowStyle CssClass="GridAI" />
                        <HeaderStyle CssClass="HeaderStyle" />
                        <PagerStyle CssClass="PageStyle" />
                        <RowStyle CssClass="GridItem" />
                        <SelectedRowStyle CssClass="GridRowGreen" />
                    </asp:GridView>
                </asp:Panel>
            </td>
       
       
       
        </tr>
    </table>
</asp:Content>

