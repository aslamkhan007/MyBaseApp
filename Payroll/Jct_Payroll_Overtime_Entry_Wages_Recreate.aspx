<%@ Page Title="" Language="C#" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="true"
    CodeFile="Jct_Payroll_Overtime_Entry_Wages_Recreate.aspx.cs" Inherits="Payroll_Jct_Payroll_Overtime_Entry_Wages_Recreate" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="mytable">
        <tr>
            <td class="tableheader" colspan="4">
                Extra Time Entry(Wages):
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Overtime Date
            </td>
            <td class="NormalText">
               
                        <asp:TextBox ID="TxtOvertimeDate" runat="server" Style="text-transform: capitalize;"
                            CssClass="textbox" AutoPostBack="True" MaxLength="7" 
                            ontextchanged="TxtOvertimeDate_TextChanged"></asp:TextBox>
                        <cc1:MaskedEditValidator ID="MaskedEditValidator3" runat="server" Width="114px" ControlToValidate="TxtOvertimeDate"
                            Display="Dynamic" ControlExtender="MaskedEditExtender4" TooltipMessage="MM/DD/YYYY"
                            IsValidEmpty="False" EmptyValueMessage="*" InvalidValueMessage="The Date is invalid"></cc1:MaskedEditValidator>
                        <cc1:CalendarExtender ID="CalFrom2" runat="server" TargetControlID="TxtOvertimeDate"
                            Animated="False" Format="MM/dd/yyyy" PopupPosition="TopLeft">
                        </cc1:CalendarExtender>
                        &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp
                        <cc1:MaskedEditExtender ID="MaskedEditExtender4" runat="server" TargetControlID="TxtOvertimeDate"
                            MaskType="Date" Mask="99/99/9999">
                        </cc1:MaskedEditExtender>
                    
            </td>
            <td class="labelcells">
                <%--<asp:Label ID="Label10" runat="server">Overtime Reason</asp:Label>--%>
            </td>
            <td class="labelcells">
               
                        <%--<asp:TextBox ID="TxtOvertimeReason" runat="server" CssClass="textbox" MaxLength="50" 
                            Width="300px" Enabled="False"></asp:TextBox>                           
                             <cc1:TextBoxWatermarkExtender
                                ID="TextBoxWatermarkExtender4" runat="server" WatermarkCssClass="watermark" WatermarkText="Give the appropriate reason here"
                                TargetControlID="TxtOvertimeReason">
                            </cc1:TextBoxWatermarkExtender>--%>
                   
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Employee Code:
            </td>
            <td class="NormalText">
                
                        <asp:TextBox ID="txtEmpCode" runat="server" Style="text-transform: capitalize;" CssClass="textbox"
                            OnTextChanged="txtEmpCode_TextChanged" AutoPostBack="True" MaxLength="10" Width="100px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEmpCode"
                            ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                   
            </td>
            <td class="labelcells">
                <asp:Label ID="SrCode" runat="server" Text="Sr No" Visible="False" ></asp:Label>
            </td>
            <td class="labelcells">
                <asp:Label ID="SrId" runat="server" ></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
               
      

                        <asp:Label ID="Label1" runat="server"> Employee Name</asp:Label>
                    
            </td>
            <td class="labelcells">
                
                        <asp:Label ID="Label2" runat="server"  Width="220px"></asp:Label>
                   
            </td>
            <td class="labelcells">
                &nbsp;
            </td>
            <td class="labelcells">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="labelcells">
               
                        <asp:Label ID="LblDept" runat="server">Department Name</asp:Label>
                    
            </td>
            <td class="labelcells">
                
                        <asp:Label ID="LblDeptname" runat="server" Width="220px"></asp:Label>
                    
            </td>
            <td class="labelcells">
                
                        <asp:Label ID="LblDesg" runat="server">SubDepartment</asp:Label>
                    
            </td>
            <td class="labelcells">
                
                        <asp:Label ID="LblDesgName" runat="server"></asp:Label>
                   
            </td>
        </tr>
        <tr>
            <td class="labelcells">
               
                        <asp:Label ID="Label3" runat="server" >Inpunch</asp:Label>
                    
            </td>
            <td class="labelcells">
               
                        <asp:Label ID="Label4" runat="server"  Width="220px"></asp:Label>
                    
            </td>
            <td class="labelcells">
           
                <asp:Label ID="Label5" runat="server" >OutPunch</asp:Label>
                
            </td>
            <td class="labelcells">
             
                <asp:Label ID="Label6" runat="server" ></asp:Label>
                 
            </td>
        </tr>
        <tr>
            <td class="labelcells">
             
                <asp:Label ID="LblOvertime" runat="server" Visible="True"> Overtime Hours</asp:Label>
                 
            </td>
            <td class="labelcells">
                
                        <asp:TextBox ID="TxtOvertimeHours" runat="server" Style="text-transform: capitalize;"
                            CssClass="textbox" AutoPostBack="True" MaxLength="7" Width="31px" Wrap="False"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtOvertimeHours"
                            ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                        <asp:Label ID="Lblhrs" runat="server" Visible="True">Hours</asp:Label>
                   
            </td>
            <td class="labelcells">
            </td>
            <td class="labelcells">
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:LinkButton ID="lnkupdate" runat="server" CssClass="buttonc" ValidationGroup="A"
                    OnClick="lnkupdate_Click" Enabled="False">Update</asp:LinkButton>
                <asp:LinkButton ID="lnkreset" runat="server" CssClass="buttonc" OnClick="lnkreset_Click">Reset</asp:LinkButton>
            </td>
        </tr>
        <%--<tr>
            <td class="NormalText" colspan="4">
                <asp:Panel ID="Panel1" runat="server" Height="200px" ScrollBars="Vertical" 
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
        </tr>--%>
    </table>
</asp:Content>
