<%@ Page Title="" Language="C#" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="true" CodeFile="payroll_emp_Deduction_Mapping.aspx.cs" Inherits="Payroll_payroll_emp_Deduction_Mapping" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <table style="width: 100%" >
        <tr>
            <td class="tableheader" colspan="2">
                Employee Deduction Mapping </td>
        </tr>        
        <tr>     
            <td class="labelcells" style="width: 109px">
                   &nbsp;&nbsp;&nbsp;
                   <asp:Label ID="lblEmployeeName" runat="server" Text="Employee Name"></asp:Label>
            </td>
            <td class="NormalText">
             <asp:UpdatePanel ID="Updtxtemployeename" runat="server">           
            <ContentTemplate> 
                <asp:TextBox ID="txtEmployeeName" runat="server" CssClass="textbox" 
                    Width="250px" AutoPostBack="True" 
                    ontextchanged="txtEmployeeName_TextChanged"></asp:TextBox>
                <cc1:AutoCompleteExtender ID="txtEmployeeName_AutoCompleteExtender" 
                    runat="server" ServiceMethod="GetEmployee_sh" ServicePath="~/WebService.asmx"  CompletionListCssClass="autocomplete_ListItem1"
                    TargetControlID="txtEmployeeName">
                </cc1:AutoCompleteExtender> 
                <asp:LinkButton ID="cmdSearch" runat="server" CssClass="searchbluesmall"  Height="16px" 
                Width="16px" 
                    ValidationGroup="A" onclick="cmdSearch_Click" ></asp:LinkButton>
                     <asp:RequiredFieldValidator ID="ReqEmployeename" runat="server" 
                    ControlToValidate="txtEmployeeName" Display="Dynamic" 
                    ErrorMessage="**EmployeeName Required" ValidationGroup="A"></asp:RequiredFieldValidator>
           </ContentTemplate>
           </asp:UpdatePanel>
            </td>
        </tr>        
        <tr>     
            <td class="labelcells" colspan="2">
                   &nbsp;&nbsp;&nbsp; Deductions:</td>
        </tr>        
        </table>
   
    <table style="width: 100%" >
        
        <tr>     
            <td class="NormalText">
                   <asp:Panel ID="Panel1" runat="server" Height="550px" ScrollBars="Vertical" 
                    Visible="False" Width="1200px">
          <asp:UpdatePanel ID="Updchklist" runat="server">           
            <ContentTemplate> 
              <asp:CheckBoxList ID="chklist" runat="server" DataTextField="Deduction_Long_Description" 
                        DataValueField="Deduction_Code" AutoPostBack="True" >
              </asp:CheckBoxList>
            </ContentTemplate>
            </asp:UpdatePanel>
                       <br />
                </asp:Panel>
            </td>
            <td class="labelcells">
               </td>
            <td class="labelcells">
            </td>
        </tr>
        <tr>
            
            <td class="buttonbackbar" colspan="3">
            <asp:UpdatePanel ID="UpdBtn" runat="server">           
            <ContentTemplate>
                <asp:LinkButton ID="lnkadd" runat="server" CssClass="buttonc" 
                     ValidationGroup="A" onclick="lnkadd_Click">Save</asp:LinkButton>
                <asp:LinkButton ID="lnkreset" runat="server" CssClass="buttonc" onclick="lnkreset_Click" 
                >Reset</asp:LinkButton>
            </ContentTemplate>
            </asp:UpdatePanel>
            </td>            
        </tr>
             <tr>
            <td class="NormalText" colspan="3">                
            </td>                    
        </tr>
    </table>
</asp:Content>

