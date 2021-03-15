<%@ Page Language="C#"  MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="true" CodeFile="CrystalviewHspWageSlip.aspx.cs" Inherits="CrystalviewHspWageSlip" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%--<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>--%>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.2.3600.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

<%--<form id="form2" runat="server">
    <asp:scriptmanager id="ScriptManager1" runat="server"></asp:scriptmanager>--%>

    <table class="mytable">
        <tr>
            <td class="tableheader" colspan="4">Wages Slip
            </td>
        </tr>


        <tr>
            <td class="labelcells">YearMonth
            </td>
            <td class="NormalText">
                <asp:textbox id="txttodate" runat="server" cssclass="textbox" width="80px"></asp:textbox>
                <asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" controltovalidate="txttodate"
                    errormessage="*" validationgroup="A"></asp:requiredfieldvalidator>
            </td>
            <td class="labelcells">&nbsp;
            </td>
            <td class="NormalText"></td>
        </tr>



        <tr>
            <td class="labelcells">Plant
            </td>
            <td class="NormalText">
                
                <asp:dropdownlist id="ddlplant" runat="server" cssclass="combobox" autopostback="True" onselectedindexchanged="ddlplant_SelectedIndexChanged">
                </asp:dropdownlist>
            </td>
            <td class="labelcells">Location
            </td>
            <td class="NormalText">
                <asp:dropdownlist id="ddlLocation" runat="server" cssclass="combobox">
                </asp:dropdownlist>
            </td>
        </tr>
        
        <tr>
            <td class="labelcells">Department
            </td>
            <td class="NormalText">

             <asp:dropdownlist id="ddldepartment" runat="server" cssclass="combobox">
                </asp:dropdownlist>
          
            </td>
            <td class="labelcells">Type</td>
            <td class="NormalText">
             <%--   <asp:dropdownlist id="ddlPaymode" runat="server" cssclass="combobox" onselectedindexchanged="ddlPaymode_SelectedIndexChanged" AutoPostBack="True">
                <asp:ListItem Selected="True">Earning</asp:ListItem>
                <asp:ListItem>Deduction</asp:ListItem>
                </asp:dropdownlist>--%>
            </td>
        </tr>

        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:linkbutton id="lnkFetch" runat="server" cssclass="buttonc" validationgroup="A"
                    onclick="lnkFetch_Click">Fetch</asp:linkbutton>
                <asp:linkbutton id="lnkreset" runat="server" cssclass="buttonc" onclick="lnkreset_Click">Reset</asp:linkbutton>
            </td>
        </tr>

        <tr>
            <td class="tableheader" colspan="4"></td>
        </tr>
    </table>
    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="True"
        GroupTreeImagesFolderUrl="" Height="1202px" ReportSourceID="CrystalReportSource1"
        ToolbarImagesFolderUrl="" ToolPanelWidth="200px" Width="1104px" />
    <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
        <Report FileName="HspWageSlip.rpt">
        </Report>
    </CR:CrystalReportSource>
    </asp:Content>
<%--</form>--%>
