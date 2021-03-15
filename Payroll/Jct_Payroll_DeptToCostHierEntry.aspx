<%@ Page Title="" Language="C#" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="true"
    CodeFile="Jct_Payroll_DeptToCostHierEntry.aspx.cs" Inherits="Payroll_Jct_Payroll_DeptToCostHierEntry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  
    <table class="mytable">
        <tr>
            <td class="tableheader" colspan="4">
                DeptToCost(Hier) :
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
                    <asp:ListItem Selected="True">A</asp:ListItem>
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
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtdedamount"
                    ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
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
                <asp:LinkButton ID="lnkexcel" runat="server" Visible="false" CssClass="buttonXL"
                    Height="32px" OnClick="lnkexcel_Click" Width="32px"></asp:LinkButton>
            </td>
            <td class="NormalText">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:LinkButton ID="lnksave" runat="server" CssClass="buttonc" OnClick="lnksave_Click"
                    ValidationGroup="A">Save</asp:LinkButton>
                <asp:LinkButton ID="lnkreset" runat="server" CssClass="buttonc" CausesValidation="False"
                    OnClick="lnkreset_Click">Reset</asp:LinkButton>
                <asp:LinkButton ID="lnksave0" runat="server" CssClass="buttonc" 
                    ValidationGroup="A" onclick="lnksave0_Click">Deactive</asp:LinkButton>
                <asp:LinkButton ID="lnksave1" runat="server" CssClass="buttonc" onclick="lnksave1_Click" >Report</asp:LinkButton>
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
