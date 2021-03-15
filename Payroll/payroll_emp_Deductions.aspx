<%@ Page Title="" Language="C#" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="true"
    CodeFile="payroll_emp_Deductions.aspx.cs" Inherits="Payroll_payroll_emp_Deductions" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

<style type="text/css">

div#main1
{
    width:800px;
    margin-right:auto;
    margin-left:auto;
}


</style>

    <table class="mytable">
   
        <tr>
            <td class="tableheader">
                Employee Deductions
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:ImageButton ID="ImageOfficial" runat="server" ImageUrl="~/Image/Official_Info.png"
                    OnClick="ImageOfficial_Click" ValidationGroup="A" />
                <asp:ImageButton ID="ImagePersonal" runat="server" ImageUrl="~/Image/Personal_Info.png"
                    OnClick="ImagePersonal_Click" ValidationGroup="A" />
                <asp:ImageButton ID="ImageEarnings" runat="server" ImageUrl="~/Image/Earnings_Info_Red.png"
                    OnClick="ImageEarnings_Click" ValidationGroup="A" />
                <asp:ImageButton ID="ImageDeductions" runat="server" ImageUrl="~/Image/Deductions_Info.png"
                    OnClick="ImageDeductions_Click" ValidationGroup="A" />
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" style="font-size: 16px;">
                DESIGNATION:
                <asp:DropDownList ID="ddldesigin" runat="server" AutoPostBack="True" CssClass="combobox"
                    OnSelectedIndexChanged="ddldesigin_SelectedIndexChanged1">
                </asp:DropDownList>
            </td>
        </tr>   
    </table>

     
        <table class="mytable">
        <tr>     
            <td>           
                <asp:DataList ID="DataList1" runat="server" OnItemDataBound="DataList1_ItemDataBound">
                    <ItemTemplate>
                        <table style="width: 100%;">
                            <tr>
                                <td width="200px" class="labelcells">
                                    <asp:Label ID="lballw" runat="server" Text='<%# Eval("allowances") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbprmID" runat="server" Text='<%# Eval("Sr_no") %>' Visible="False"></asp:Label>
                                </td>
                                <td width="200px" class="labelcells">
                                    <asp:TextBox ID="txtallw" runat="server" CssClass="textbox" Visible="False" Width="80"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="txtallw_FilteredTextBoxExtender" runat="server"
                                        Enabled="True" TargetControlID="txtallw" ValidChars=".1234567890">
                                    </cc1:FilteredTextBoxExtender>

                                     <asp:RequiredFieldValidator ID="Reqallw" runat="server" ControlToValidate="txtallw"
                                        ErrorMessage="*" ValidationGroup="B"></asp:RequiredFieldValidator>


                                    <br />
                                    <asp:DropDownList ID="ddlallw" runat="server" CssClass="combobox" Visible="False" Width="80">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:DataList>
                
            </td>
        </tr>
    </table>
   <%--   </div>--%>

    <table class="mytable">
        <tr>
            <td class="buttonbackbar">
                <asp:LinkButton ID="lnksave" runat="server" CssClass="buttonc" 
                    OnClick="lnksave_Click" ValidationGroup="B">Save</asp:LinkButton>                
            </td>
        </tr>
    </table>
</asp:Content>
