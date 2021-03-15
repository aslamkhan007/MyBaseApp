<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CrystalView.aspx.cs" MasterPageFile="~/Payroll/MasterPage.master"
    Inherits="CrystalView" %>
<%--<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CrystalView.aspx.cs" 
    Inherits="CrystalView" %>--%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%--<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>--%>	


<%@ Register Assembly="CrystalDecisions.Web, Version=10.2.3600.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">



 <%--<form id="form2" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager> --%>

    <table class="mytable">
        <tr>
            <td class="tableheader" colspan="4">
                Salary Sheet
            </td>
        </tr>
			

		<tr>
            <td class="labelcells">
                YearMonth
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txttodate" runat="server" CssClass="textbox" Width="80px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txttodate"
                    ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
            <td class="labelcells">
                &nbsp;
            </td>
            <td class="NormalText">
            </td>
        </tr>
		
		
		
        <tr>
            <td class="labelcells">
                Plant
            </td>
            <td class="NormalText">
                   <asp:DropDownList ID="ddlplant" runat="server" CssClass="combobox" AutoPostBack="True" OnSelectedIndexChanged="ddlplant_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td class="labelcells">
                Location
            </td>
            <td class="NormalText">
                 <asp:DropDownList ID="ddlLocation" runat="server" CssClass="combobox">
                </asp:DropDownList>
            </td>
        </tr>
		
		        <tr>
            <td class="labelcells">Department
            </td>
            <td class="NormalText">

                <asp:dropdownlist id="ddldepartment" runat="server" cssclass="combobox">
                </asp:dropdownlist>
          
            </td>
            <td class="labelcells">PayMent Mode</td>
            <td class="NormalText"><asp:dropdownlist id="ddlPaymode" runat="server" cssclass="combobox">
                <asp:ListItem>Bank</asp:ListItem>
                <asp:ListItem>Cash</asp:ListItem>
                </asp:dropdownlist></td>
        </tr>
		
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:LinkButton ID="lnkFetch" runat="server" CssClass="buttonc" ValidationGroup="A"
                    OnClick="lnkFetch_Click">Fetch</asp:LinkButton>
                <asp:LinkButton ID="lnkreset" runat="server" CssClass="buttonc" OnClick="lnkreset_Click">Reset</asp:LinkButton>
            </td>
        </tr>

        <tr>
            <td class="tableheader" colspan="4">
            </td>
        </tr>
    </table>
    <cr:crystalreportviewer ID="CrystalReportViewer1" runat="server" AutoDataBind="True"
        GroupTreeImagesFolderUrl="" Height="1202px" ReportSourceID="CrystalReportSource1"
        ToolbarImagesFolderUrl="" ToolPanelWidth="200px" Width="1104px" />
    <cr:crystalreportsource ID="CrystalReportSource1" runat="server">
        <Report FileName="Payroll_Salary_Sheet.rpt">
        </Report>
    </cr:crystalreportsource>
</asp:Content>
         <%--</form>--%>