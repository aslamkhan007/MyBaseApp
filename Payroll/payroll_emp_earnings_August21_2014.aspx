<%@ Page Title="" Language="C#" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="true" CodeFile="payroll_emp_earnings.aspx.cs" Inherits="PayRoll_payroll_emp_earnings" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="mytable">
        <tr>
            <td class="tableheader" colspan="2">
                Employee Earning Details</td>
        </tr>
        <tr>
            <td colspan="2" align="center">

          <%--       <asp:HyperLink ID="hypbasicdetail" runat="server" CssClass="buttonc" 
                                           NavigateUrl="~/PayRoll/Payroll_Official_Detail.aspx">BasicDetail</asp:HyperLink>
                <asp:HyperLink ID="hypeaddres" runat="server" CssClass="buttonc" 
                                           NavigateUrl="~/PayRoll/payroll_personal_detail.aspx">PersonalDetail</asp:HyperLink>
                <asp:HyperLink ID="hypeEarning" runat="server" CssClass="buttonc" 
                                           NavigateUrl="~/PayRoll/payroll_emp_earnings.aspx">Earnings</asp:HyperLink>
                <asp:HyperLink ID="hypededuct" runat="server" CssClass="buttonc">Deductions</asp:HyperLink>--%>

            <%--     <asp:LinkButton ID="lnkbtnbasicdetails" runat="server" CssClass="buttonc" 
                                            ValidationGroup="A" onclick="lnkbtnbasicdetails_Click">basic details</asp:LinkButton>
                                        <asp:LinkButton ID="lnkbtnpersonal" runat="server" CssClass="buttonc" 
                                            ValidationGroup="A" onclick="lnkbtnpersonal_Click">personal </asp:LinkButton>
                                        <asp:LinkButton ID="lnkbtnearning" runat="server" CssClass="buttonc" 
                                            ValidationGroup="A" onclick="lnkbtnearning_Click">Earning </asp:LinkButton>
                                        <asp:LinkButton ID="lnkbtndeduction" runat="server" CssClass="buttonc" 
                                            ValidationGroup="A" onclick="lnkbtndeduction_Click">Deductions</asp:LinkButton>--%>

                                            
                    <asp:ImageButton ID="ImageOfficial" runat="server" 
                    ImageUrl="~/Image/Official_Info.png" onclick="ImageOfficial_Click" 
                    ValidationGroup="A" />

                   <asp:ImageButton ID="ImagePersonal" runat="server" 
                    ImageUrl="~/Image/Personal_Info.png" onclick="ImagePersonal_Click" 
                    ValidationGroup="A" />

                        <asp:ImageButton ID="ImageEarnings" runat="server" 
                    ImageUrl="~/Image/Earnings_Info_Red.png" onclick="ImageEarnings_Click" 
                    ValidationGroup="A" />

                   <asp:ImageButton ID="ImageDeductions" runat="server" 
                    ImageUrl="~/Image/Deductions_Info.png" onclick="ImageDeductions_Click" 
                    ValidationGroup="A" />

            </td>
              
        </tr>
      
        <tr>
            <td class="labelcells" colspan="2">
                Earnings</td>
              
        </tr>
      
        <tr>
            <td class="NormalText" style="width: 59px">
                Desigination</td>
            <td class="NormalText">
                <asp:DropDownList ID="ddldesigin" runat="server" AutoPostBack="True" 
                    CssClass="combobox" onselectedindexchanged="ddldesigin_SelectedIndexChanged1" 
                 >
                </asp:DropDownList>
        
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 59px">
                Basic Pay</td>
            <td class="NormalText">
                <asp:TextBox ID="txtbasic" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="txtbasic_FilteredTextBoxExtender" 
                    runat="server" Enabled="True" TargetControlID="txtbasic" 
                    ValidChars=".1234567890">
                </cc1:FilteredTextBoxExtender>
            </td>
        </tr>

        <tr>
            <td class="NormalText" colspan="2">
                    
                     <asp:Label ID="lbtxtall" runat="server" Text="Allowances" Visible="False"></asp:Label>
            </td>
        </tr>
    
        <tr>
            <td class="NormalText" colspan="2">
                         <asp:DataList ID="DataList1" runat="server" 
                    onitemdatabound="DataList1_ItemDataBound">
                    <ItemTemplate>
                        <table style="width:100%;">
                            <tr>
                                <td>
                                    <asp:Label ID="lballw" runat="server" Text='<%# Eval("allowances") %>'></asp:Label>
                                   
                                </td>
                                <td  width="275px">
                                    <asp:Label ID="lbprmID" runat="server" Text='<%# Eval("Sr_no") %>' 
                                        Visible="False"></asp:Label>
                                </td>
                                 
                                <td width="200px">
                                    <asp:TextBox ID="txtallw" runat="server" CssClass="textbox" Visible="False" ></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="txtallw_FilteredTextBoxExtender" 
                                        runat="server" Enabled="True" TargetControlID="txtallw" 
                                        ValidChars=".1234567890">
                                    </cc1:FilteredTextBoxExtender>
                                            <br />
                                    <asp:DropDownList ID="ddlallw" runat="server" CssClass="combobox" 
                                        Visible="False">
                                    </asp:DropDownList>
                                </td>

         
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:DataList>      
                    
            </td>
        </tr>
        
   </table>
    <%--<table>
        <tr>
            <td  >
                <asp:DataList ID="DataList1" runat="server" 
                    onitemdatabound="DataList1_ItemDataBound">
                    <ItemTemplate>
                        <table style="width:100%;">
                            <tr>
                                <td >
                                    <asp:Label ID="lballw" runat="server" Text='<%# Eval("allowances") %>'></asp:Label>
                                   
                                </td>
                                <td >
                                    <asp:Label ID="lbprmID" runat="server" Text='<%# Eval("Sr_no") %>' 
                                        Visible="False"></asp:Label>
                                </td>
                                 
                                <td  >
                                    <asp:TextBox ID="txtallw" runat="server" CssClass="textbox" Visible="False" ></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="txtallw_FilteredTextBoxExtender" 
                                        runat="server" Enabled="True" TargetControlID="txtallw" 
                                        ValidChars=".1234567890">
                                    </cc1:FilteredTextBoxExtender>
                                    <br />
                                    <asp:DropDownList ID="ddlallw" runat="server" CssClass="combobox" 
                                        Visible="False">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:DataList>
            </td>
        </tr>
       
        </table>--%>
        <table class="mytable">
        <tr>
        <td class="buttonbackbar">
            <asp:LinkButton ID="lnksave" runat="server" CssClass="buttonc" 
                onclick="lnksave_Click">Save</asp:LinkButton>
            <asp:LinkButton ID="lnkreset" runat="server" CssClass="buttonc" 
                onclick="lnkreset_Click">Reset</asp:LinkButton>
        </td>
        </tr>
       </table>
</asp:Content>

