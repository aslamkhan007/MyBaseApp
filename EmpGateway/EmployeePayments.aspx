<%@ Page Language="VB" MasterPageFile="MasterPage.master" AutoEventWireup="false" CodeFile="EmployeePayments.aspx.vb" Inherits="SalarySent" title="Salary Sent In Account For Month" %>

<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%">
        <tr>
            <td class="tableheader" colspan="2">
                <asp:Label ID="Label5" runat="server" BorderColor="Transparent" 
                    Text="Employee Payments"></asp:Label></td>
        </tr>
        <tr>
            <td class="textcells" style="height: 26px">
                <asp:DropDownList ID="ddlSal" runat="server" AutoPostBack="True" 
                    CssClass="combobox">
                    <asp:ListItem Value="Sal" Selected="True">Salary</asp:ListItem>
                    <asp:ListItem Value="Scr">Scooter Allowance</asp:ListItem>
                    <asp:ListItem Value="Car">Car Allowance</asp:ListItem>
                </asp:DropDownList>
            &nbsp;for
                <asp:DropDownList ID="ddlMonthYear" runat="server" AutoPostBack="True" 
                    CssClass="combobox">
                    <asp:ListItem Value="01">Jan</asp:ListItem>
                    <asp:ListItem Value="02">Feb</asp:ListItem>
                    <asp:ListItem Value="03">Mar</asp:ListItem>
                    <asp:ListItem Value="04">Apr</asp:ListItem>
                    <asp:ListItem Value="05">May</asp:ListItem>
                    <asp:ListItem Value="06">Jun</asp:ListItem>
                    <asp:ListItem Value="07">Jul</asp:ListItem>
                    <asp:ListItem Value="08">Aug</asp:ListItem>
                    <asp:ListItem Value="09">Sep</asp:ListItem>
                    <asp:ListItem Value="10">Oct</asp:ListItem>
                    <asp:ListItem Value="11">Nov</asp:ListItem>
                    <asp:ListItem Value="12">Dec</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="textcells" style="height: 26px">
                Transfer Date
                <ew:CalendarPopup ID="dtTransfer" runat="server" Culture="English (United Kingdom)"
                    Text="..." Width="64px">
                </ew:CalendarPopup>
            </td>
        </tr>
        <tr>
            <td class="textcells">
                <asp:CheckBoxList ID="cblDone" runat="server" 
                    DataSourceID="SqlDataSource1" DataTextField="designation" 
                    DataValueField="designation" Enabled="False">
                </asp:CheckBoxList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:misjctdev %>" SelectCommand="select distinct b.designation, b.seniority from jct_emp_salary_update a inner join JCT_Emp_Catg_Desg_Mapping b on a.catg = b.catg 
where a.monthyear = @monthyear and a.type = @paymenttype
order by seniority">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlMonthYear" Name="monthyear" 
                            PropertyName="SelectedValue" />
                        <asp:ControlParameter ControlID="ddlSal" Name="paymenttype" 
                            PropertyName="SelectedValue" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:CheckBoxList ID="cblPending" runat="server" 
                    DataSourceID="SqlDataSource2" DataTextField="designation" 
                    DataValueField="designation">
                </asp:CheckBoxList>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                    
                    SelectCommand="SELECT DISTINCT Designation, Seniority FROM JCT_Emp_Catg_Desg_Mapping WHERE  Designation NOT IN (SELECT DISTINCT b.Designation FROM jct_emp_salary_update AS a INNER JOIN JCT_Emp_Catg_Desg_Mapping AS b ON a.Catg = b.Catg  WHERE MonthYear = @monthyear AND type = @paymenttype ) ORDER BY Seniority">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlMonthYear" Name="monthyear" 
                            PropertyName="SelectedValue" />
                        <asp:ControlParameter ControlID="ddlSal" Name="paymenttype" 
                            PropertyName="SelectedValue" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2" class="buttonbackbar">
                <asp:Button ID="cmdapply" runat="server" CssClass="ButtonBack" Text="Apply" BackColor="Black"/>
                <asp:Button ID="cmdclear" runat="server" CssClass="ButtonBack" Text="Clear" BackColor="Black"/></td>
        </tr>
    </table>
</asp:Content>

