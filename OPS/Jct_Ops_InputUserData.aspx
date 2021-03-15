<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true"
    CodeFile="Jct_Ops_InputUserData.aspx.cs" Inherits="OPS_Jct_Ops_InputUserData" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%">
        <tr>
            <td class="tableheader" colspan="4">
                Employee Address :</td>
        </tr>
        <tr>
            <td class="labelcells">
                <asp:Label ID="lblSrNo" runat="server" Text="Sr No" Visible="False"></asp:Label>
            </td>
            <td class="labelcells">
                <asp:Label ID="lbsrid" runat="server" Visible="False"></asp:Label>
            </td>
            <td class="labelcells">
                &nbsp;
            </td>
            <td class="NormalText">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Address1</td>
            <td class="NormalText">
                
                <asp:TextBox ID="txtadd1" runat="server" CssClass="textbox" MaxLength="50"  Style="text-transform: uppercase"
                    Width="200px"></asp:TextBox>
                
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="txtadd1" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                
            </td>
            <td class="labelcells">
                Address2
            </td>
            <td class="NormalText">
                
                <asp:TextBox ID="txtadd2" runat="server" CssClass="textbox" Style="text-transform: uppercase"
                    MaxLength="50" Width="200px"></asp:TextBox>
                
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                    ControlToValidate="txtadd2" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Address3</td>
            <td class="NormalText">
                <%--                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                    ControlToValidate="txtContactPerson" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator> --%>
                <asp:TextBox ID="txtadd3" runat="server" CssClass="textbox" MaxLength="50" Style="text-transform: uppercase"
                    Width="200px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ControlToValidate="txtadd3" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
            <td class="labelcells">
                &nbsp;&nbsp;City</td>
            <td class="NormalText">
                <asp:DropDownList ID="ddlCity" runat="server" CssClass="combobox">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                District</td>
            <td class="NormalText">
                <asp:DropDownList ID="ddlDistrict" runat="server" 
                    CssClass="combobox">
                </asp:DropDownList>
            </td>
            <td class="labelcells">
                PinCode</td>
            <td class="NormalText">
                
                
                
                <asp:TextBox ID="txtPin" runat="server" CssClass="textbox" Style="text-transform: uppercase"
                    MaxLength="30"></asp:TextBox>
                
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtPin" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>

                <cc1:FilteredTextBoxExtender ID="txtSanctionAmount_FilteredTextBoxExtender" runat="server"
                    Enabled="True" TargetControlID="txtPin" ValidChars=".1234567890">
                </cc1:FilteredTextBoxExtender>
                
                
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="labelcells">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:LinkButton ID="lnkadd" runat="server" CssClass="buttonc"
                    OnClick="lnkadd_Click" ValidationGroup="A">Add</asp:LinkButton>
                    <asp:LinkButton ID="lnkupdate" runat="server" CssClass="buttonc" 
                     onclick="lnkupdate_Click" Enabled="False" ValidationGroup="A">Update</asp:LinkButton>
                <asp:LinkButton ID="lnkreset" runat="server" CssClass="buttonc" OnClick="lnkreset_Click">Reset</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="NormalText" colspan="4">
                <asp:Panel ID="Panel1" runat="server" Height="200px" ScrollBars="Vertical" Visible="False"
                    Width="1000px">
                    <asp:GridView ID="grdDetail" runat="server" AutoGenerateSelectButton="True" Width="100%"
                        OnSelectedIndexChanged="grdDetail_SelectedIndexChanged">
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
