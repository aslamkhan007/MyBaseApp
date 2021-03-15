<%@ Page Title="" Language="C#" MasterPageFile="Main.master" AutoEventWireup="true" CodeFile="CoLeave.aspx.cs" Inherits="Payroll_CoLeave" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="tileTable" style="height: 100%;">
    <table cellpadding="2" cellspacing="1" style="width: 100%" class="tblMain">
        <tr>
            <td  colspan="4" class="content-sub-heading">
                Compensatory Leave Form</td>
        </tr>
        <tr>
            <td class="CellWidth10">                
                <b>Type</b></td>
            <td class="CellWidth40">
            <asp:DropDownList ID="ddltype" runat="server" class="btn btn-default btn-sm"  
                    AutoPostBack="True" onselectedindexchanged="ddltype_SelectedIndexChanged">            
                    <asp:ListItem>Full Day</asp:ListItem>
                    <asp:ListItem>Half Day</asp:ListItem>                    
                </asp:DropDownList>                
            </td>
            <td class="CellWidth10" ><b>Employee Name</b></td>
            <td class="CellWidth40" >                
                <i><asp:Label ID="txtemp" runat="server"  ></asp:Label>               </i> 
                
            </td>
        </tr>
        <tr>
            <td class="CellWidth10" >                
                <b>Date</b></td>
            <td class="CellWidth40" >                
                <asp:TextBox ID="txtdate" runat="server"  Width="25%"></asp:TextBox>
                <cc1:CalendarExtender ID="txtdate_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txtdate">
                </cc1:CalendarExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtdate" ErrorMessage="Please select date" 
                    ValidationGroup="mandatory"></asp:RequiredFieldValidator>               
            </td>
            <td class="CellWidth10" >
                <b>No Of Days</b></td>
            <td class="CellWidth40" >

            <asp:DropDownList ID="txtdays" runat="server" class="btn btn-default btn-sm"  
                    >                                
                    <asp:ListItem>0.5</asp:ListItem>
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                </asp:DropDownList>
<%--                <asp:TextBox ID="txtdays" runat="server"  
                    ToolTip="1 , 0.5 or 2.0 only" Width="40px"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="txtdays_FilteredTextBoxExtender" 
                    runat="server" TargetControlID="txtdays" ValidChars=".1250">
                </cc1:FilteredTextBoxExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtdays" ErrorMessage="Please enter no.of days" 
                    ValidationGroup="mandatory"></asp:RequiredFieldValidator>--%>
            </td>
        </tr>
        <tr>
            <td class="CellWidth10">                
               <b> Purpose</b></td>
            <td colspan="3" class="CellWidth90">                
                     <asp:TextBox ID="txtpurpose" runat="server"    Height="50px" 
                    TextMode="MultiLine"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="txtpurpose" ErrorMessage="Cannot be blank" 
                    ValidationGroup="mandatory"></asp:RequiredFieldValidator>
            </td>
            
        </tr>
      
        <tr>
            <td  colspan="4" style="text-align:center;">                
                  <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                    <ContentTemplate>
                <asp:LinkButton ID="lnkapply" runat="server" class="btn btn-brand"   ValidationGroup="mandatory"
                    onclick="lnkapply_Click">Apply</asp:LinkButton>
                <asp:LinkButton ID="lnkreset" runat="server"  class="btn btn-brand" 
                    onclick="lnkreset_Click">Reset</asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>

                <tr>
            <td colspan="4">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="10">
                    <ProgressTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Image/load.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
        </tr>
    </table>
        </div>
</asp:Content>


