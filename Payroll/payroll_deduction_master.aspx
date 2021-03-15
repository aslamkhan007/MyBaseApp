<%@ Page Title="" Language="C#" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="true" CodeFile="payroll_deduction_master.aspx.cs" Inherits="Payroll_payroll_deduction_master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <table style="width: 100%" >
        <tr>
            <td class="tableheader" colspan="4">
                Deduction Master:</td>
        </tr>
        <tr>
            <td class="labelcells">
                Deduction Code</td>
            <td class="NormalText">
                <asp:TextBox ID="txtDeducshortdescrip" runat="server" CssClass="textbox"  style="text-transform: uppercase"
                    MaxLength="20" 
                    ToolTip="Like PF For Provident Fund and may contain upto 20 characters"></asp:TextBox>
              
                <asp:RequiredFieldValidator ID="Reqdeductionlongdesc" runat="server" 
                    ControlToValidate="txtDeducshortdescrip" 
                    ErrorMessage="Short Description!!" ValidationGroup="A" Display="Dynamic"></asp:RequiredFieldValidator>
            </td>
            <td class="labelcells">
                <asp:Label ID="lblDeductionCode" runat="server" Text="Deduction Code" 
                    Visible="False"></asp:Label>
            </td>
            <td class="labelcells">
                <asp:Label ID="lbcodeid" runat="server" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
            Description</td>
            <td class="NormalText">
                  <asp:TextBox ID="txtDeducLongdescrip" runat="server" CssClass="textbox"  style="text-transform: uppercase"
                      MaxLength="100" ToolTip="Type of Deduction Like Provident Fund"></asp:TextBox>
              
                <asp:RequiredFieldValidator ID="ReqdeductionShortdescrip" runat="server" 
                    ControlToValidate="txtDeducLongdescrip" ErrorMessage="Long Description!!" 
                      ValidationGroup="A" Display="Dynamic"></asp:RequiredFieldValidator>
            </td>
            <td class="labelcells">
                <asp:Label ID="lblDeductionType" runat="server" Text="Deduction Type"></asp:Label>
            </td>
            <td class="labelcells">
                <asp:DropDownList ID="ddlDeductionType" runat="server" AutoPostBack="True" 
                    CssClass="combobox" 
                    ToolTip="Specify The Type of Deduction">
                    <asp:ListItem>FIXED</asp:ListItem>
                    <asp:ListItem>VARIABLE</asp:ListItem>
                    <asp:ListItem>LOAN</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Uom</td>
            <td class="NormalText">
                <asp:DropDownList ID="ddluom" runat="server" CssClass="combobox" 
                    AutoPostBack="True" 
                    ToolTip="Unit of measurement wheather in rupees or percentage" 
                    onselectedindexchanged="ddluom_SelectedIndexChanged">
                    <asp:ListItem>RUPEES</asp:ListItem>
                    <asp:ListItem>PERCENTAGE</asp:ListItem>               
                </asp:DropDownList>
             </td>
            <td class="labelcells">
                <asp:Label ID="lblDeductionOn" runat="server" Text="Deduction On" 
                    Visible="False"></asp:Label>
            </td>
            <td class="labelcells">
            <asp:DropDownList ID="ddldeductionOn" runat="server" CssClass="combobox" 
                    AutoPostBack="True" 
                    ToolTip="Parameter Specifying the Base of Deduction" Visible="False" 
                    AppendDataBoundItems="True" >
                    <asp:ListItem Selected="True"></asp:ListItem>
                    <asp:ListItem>Basic</asp:ListItem>
                    <asp:ListItem>Gross</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Value</td>
            <td class="NormalText">
            <asp:TextBox ID="txtUnitValue" runat="server" CssClass="textbox" Width="70px"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtUnitValue" ValidChars="0123456789.">
                </cc1:FilteredTextBoxExtender>
        <asp:RequiredFieldValidator ID="ReqUnitValue" runat="server" 
            ControlToValidate="txtUnitValue" ErrorMessage="Unit Value!!" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
            <td class="labelcells">
                &nbsp;</td>
            <td class="labelcells">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="labelcells">
                Effective From</td>
            <td class="NormalText">                         
                <asp:TextBox ID="txtefffrm" runat="server" CssClass="textbox" Width="70px"></asp:TextBox>
        
         <%--           <cc1:MaskedEditExtender ID="MEE2" runat="server" MaskType="Date" 
                    Mask="99/99/9999" TargetControlID="txteffto" >
                </cc1:MaskedEditExtender>
                <cc1:MaskedEditValidator ID="MEV2" runat="server" 
                    ControlExtender="MEE2" ControlToValidate="txteffto" Display="Dynamic" 
                     ErrorMessage="MEV2" InvalidValueMessage="INVALID DATE"  
                TooltipMessage="MM/DD/YYYY" IsValidEmpty="False" 
                EmptyValueMessage="ENTER DATE!!" ValidationGroup="A"                       
                    ></cc1:MaskedEditValidator>  --%>

                <cc1:calendarextender ID="txtefffrm_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txtefffrm">
                </cc1:calendarextender>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ControlToValidate="txtefffrm" ErrorMessage="From Date!!" ValidationGroup="A"></asp:RequiredFieldValidator>

            </td>
            <td class="labelcells">
                Effective To</td>
            <td class="NormalText">
                <asp:TextBox ID="txteffto" runat="server" CssClass="textbox" Width="70px"></asp:TextBox>
                <cc1:calendarextender ID="txteffto_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txteffto">
                </cc1:calendarextender>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
            ControlToValidate="txteffto" ErrorMessage="To Date!!" ValidationGroup="A"></asp:RequiredFieldValidator>
          <%--           <cc1:MaskedEditExtender ID="MEE2" runat="server" MaskType="Date" 
                    Mask="99/99/9999" TargetControlID="txteffto" >
                </cc1:MaskedEditExtender>
                <cc1:MaskedEditValidator ID="MEV2" runat="server" 
                    ControlExtender="MEE2" ControlToValidate="txteffto" Display="Dynamic" 
                     ErrorMessage="MEV2" InvalidValueMessage="INVALID DATE"  
                TooltipMessage="MM/DD/YYYY" IsValidEmpty="False" 
                EmptyValueMessage="ENTER DATE!!" ValidationGroup="A"                       
                    ></cc1:MaskedEditValidator>  --%>              
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:LinkButton ID="lnkadd" runat="server" CssClass="buttonc" 
                     ValidationGroup="A" onclick="lnkadd_Click">Add</asp:LinkButton>
                <asp:LinkButton ID="lnkupdate" runat="server" CssClass="buttonc" 
                     ValidationGroup="A" onclick="lnkupdate_Click">Update</asp:LinkButton>
                <asp:LinkButton ID="lnkdelete" runat="server" CssClass="buttonc" 
                    onclick="lnkdelete_Click">Delete</asp:LinkButton>
                <asp:LinkButton ID="lnkreset" runat="server" CssClass="buttonc" 
                    onclick="lnkreset_Click">Reset</asp:LinkButton>
            </td>
        </tr>
             <tr>
            <td class="NormalText" colspan="4">
                <asp:Panel ID="Panel1" runat="server" Height="200px" ScrollBars="Vertical" 
                    Visible="False" Width="1000px">
                    <asp:GridView ID="grdDetail" runat="server" AutoGenerateSelectButton="True" 
                    Width="100%" onselectedindexchanged="grdDetail_SelectedIndexChanged" 
  >
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

