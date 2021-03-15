<%@ Page Title="" Language="C#" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="true" CodeFile="Jct_Payroll_JCT_HR_CTC_Insurance.aspx.cs" Inherits="Payroll_Jct_Payroll_JCT_HR_CTC_Insurance" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  
    <table class="mytable">
        <tr>
            <td class="tableheader" colspan="4">
               Insurance For CTC :
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
                </td>
            <td class="NormalText">
                </td>
        </tr>
        <tr>

        <td class="labelcells">
                EmployeeCode</td>
            <td class="NormalText">
                
                <asp:TextBox ID="txtemployeecode" runat="server" CssClass="textbox"  AutoPostBack="True"
                    MaxLength="7" Width="100px" ontextchanged="txtemployeecode_TextChanged"></asp:TextBox>
               
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtemployeecode"
                    ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>

            <td class="labelcells">
                <%--SapCode--%>
                EmployeeName
                </td>
            <td class="labelcells">
<%--                <asp:TextBox ID="txtSapcode" runat="server" CssClass="textbox" MaxLength="10" 
                    Width="120px" ontextchanged="txtSapcode_TextChanged"  AutoPostBack="True"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="txtdedamount_FilteredTextBoxExtender0" 
                    runat="server" Enabled="True" TargetControlID="txtSapcode" 
                    ValidChars=".0123456789">
                </cc1:FilteredTextBoxExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtSapcode" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>--%>
                <asp:Label ID="lbemployeename" runat="server"></asp:Label>
            </td>
            
        </tr>
          <tr>
            <td class="labelcells">
                E_GME</td>
            <td class="NormalText">
                <asp:TextBox ID="txtGME" runat="server" CssClass="textbox" MaxLength="9" 
                    Width="60px"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" 
                    runat="server" Enabled="True" TargetControlID="txtGME" 
                    ValidChars=".0123456789">
                </cc1:FilteredTextBoxExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="txtGME" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
            <td class="labelcells">
                E_GPA</td>
            <td class="NormalText">
                
                <asp:TextBox ID="txtGPA" runat="server" CssClass="textbox" MaxLength="9" Width="60px"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                    Enabled="True" TargetControlID="txtGPA" ValidChars=".0123456789">
                </cc1:FilteredTextBoxExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtGPA"
                    ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                E_GroupTermPolicy</td>
            <td class="NormalText">
                <asp:TextBox ID="txtGrouppolicy" runat="server" CssClass="textbox" MaxLength="9" 
                    Width="60px"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" 
                    Enabled="True" TargetControlID="txtGrouppolicy" ValidChars=".0123456789">
                </cc1:FilteredTextBoxExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                    ControlToValidate="txtGrouppolicy" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
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
                <asp:LinkButton ID="lnkreset0" runat="server" CssClass="buttonc" 
                    CausesValidation="False" onclick="lnkreset0_Click1"
                    >Report</asp:LinkButton>
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


