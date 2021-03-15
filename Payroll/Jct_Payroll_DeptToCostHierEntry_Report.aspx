<%@ Page Title="" Language="C#" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="true" CodeFile="Jct_Payroll_DeptToCostHierEntry_Report.aspx.cs" Inherits="Payroll_Jct_Payroll_DeptToCostHierEntry_Report" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  
    <table class="mytable">
        <tr>
            <td class="tableheader" colspan="4">
                DeptToCost(Hier) 
                Report :
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Plant
            </td>
            <td class="NormalText">
                <asp:DropDownList ID="ddlplant" runat="server" CssClass="combobox" 
                    >

                    
                </asp:DropDownList>
            </td>
            <td class="labelcells">
                Department
            </td>
            <td class="NormalText">
                <asp:DropDownList ID="ddldepartment" runat="server" CssClass="combobox">
                
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Report Group
            </td>
            <td class="NormalText">
                <asp:DropDownList ID="ddldedtype" runat="server" AutoPostBack="True" CssClass="combobox">
                <asp:ListItem Selected="True">ALL</asp:ListItem>
                    <asp:ListItem >A</asp:ListItem>
                    <asp:ListItem>B</asp:ListItem>
                    <asp:ListItem>C</asp:ListItem>
                    <asp:ListItem>D</asp:ListItem>
                    <asp:ListItem>E</asp:ListItem>
                    <asp:ListItem>F</asp:ListItem>
                    <asp:ListItem>G</asp:ListItem>
                    <asp:ListItem>H</asp:ListItem>
                    <asp:ListItem>I</asp:ListItem>
                    <asp:ListItem>J</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="labelcells">
                Report Serial
            </td>
            <td class="NormalText">
                
                <asp:TextBox ID="txtdedamount" runat="server" CssClass="textbox" MaxLength="4" Width="50px"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="txtdedamount_FilteredTextBoxExtender" runat="server"
                    Enabled="True" TargetControlID="txtdedamount" ValidChars=".0123456789">
                </cc1:FilteredTextBoxExtender>
                
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                &nbsp;
            </td>
            <td class="NormalText">
                &nbsp;
            </td>
            <td class="NormalText">
                <asp:LinkButton ID="lnkexcel" runat="server" Visible="true" CssClass="buttonXL"
                    Height="32px" OnClick="lnkexcel_Click" Width="32px"></asp:LinkButton>
            </td>
            <td class="NormalText">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:LinkButton ID="lnksave" runat="server" CssClass="buttonc" OnClick="lnksave_Click"
                    ValidationGroup="A">Fetch</asp:LinkButton>
                <asp:LinkButton ID="lnkreset" runat="server" CssClass="buttonc" CausesValidation="False"
                    OnClick="lnkreset_Click">Reset</asp:LinkButton>                             
                <asp:LinkButton ID="lnkreset0" runat="server" CssClass="buttonc" onclick="lnkreset0_Click" 
                    >Back</asp:LinkButton>                             
            </td>
        </tr>
        <tr>
            <td class="NormalText" colspan="4">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="Panel1" runat="server" Height="350px" ScrollBars="Both" Width="1000px" Visible = "false">
                            <asp:GridView ID="grdDetail" runat="server" EnableModelValidation="True" Width="100%">
                                <AlternatingRowStyle CssClass="GridAI" />
                                <Columns>
                                </Columns>
                                <HeaderStyle CssClass="GridHeader" />
                                <PagerStyle CssClass="PageStyle" />
                                <RowStyle CssClass="Griditem" />
                            </asp:GridView>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>

