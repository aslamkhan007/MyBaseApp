<%@ Page Title="" Language="C#" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="true" CodeFile="Payroll_Bank_master.aspx.cs" Inherits="Payroll_Payroll_Bank_master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<table style="width: 100%" >
        <tr>
            <td class="tableheader" colspan="4">
                Bank Master</td>
        </tr>


       
        <tr>
            <td class="labelcells">
                Plant</td>
            <td class="NormalText">
                <asp:DropDownList ID="ddlplant" runat="server" CssClass="combobox" 
                    AutoPostBack="True" onselectedindexchanged="ddlplant_SelectedIndexChanged">
                </asp:DropDownList>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="ddlplant" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
            <td class="labelcells">
                <asp:Label ID="lblSrNo" runat="server" Text="Sr No" Visible="False"></asp:Label>
            </td>
            <td class="labelcells">
                <asp:Label ID="lbsrid" runat="server" Visible="False"></asp:Label>
            </td>
             </tr>
            <tr>
            <td class="labelcells">
                Location</td>
            <td class="labelcells">
                
                <asp:DropDownList ID="ddlLocation" runat="server" AutoPostBack="True" 
                    CssClass="combobox" 
                    onselectedindexchanged="ddlLocation_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="ddlLocation" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                
            </td>  
           <td class="labelcells">
                <asp:Label ID="lblBankCode" runat="server" Text="Bank Code" Visible="False"></asp:Label>
            </td>
            <td class="labelcells">
                <asp:Label ID="lbcodeid" runat="server" Visible="False"></asp:Label>
            </td> 
        </tr>
        <tr>
            <td class="labelcells">
                Bank Name</td>
            <td class="NormalText">
            
                <asp:TextBox ID="txtBankName" runat="server" CssClass="textbox" style="text-transform:capitalize;"
                    Width="300px" MaxLength="35"></asp:TextBox>
            
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                    ControlToValidate="txtBankName" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            
            </td>
              <td class="labelcells">
                Email Id</td>
              <td class="NormalText">
            
                <asp:TextBox ID="TxtEmail" runat="server" CssClass="textbox" Width="220px"></asp:TextBox>
                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                    ControlToValidate="TxtEmail" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>--%>
            <asp:RegularExpressionValidator 
            ID="RegularExpressionValidator2" runat="server"  
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="TxtEmail"
            ErrorMessage="Input valid Internet URL!" ValidationGroup="A" ></asp:RegularExpressionValidator>
             <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1"
                                runat="server" WatermarkCssClass="watermark" WatermarkText="local-part@domain" targetcontrolid="TxtEmail">
                            </cc1:TextBoxWatermarkExtender>
            </td>        
            </tr>

                 <tr> 
                 
            <td class="labelcells">
                Address</td>
            <td class="NormalText">
                <asp:TextBox ID="txtaddress" runat="server" style="text-transform:capitalize;"
                    CssClass="textbox" Width="300px" MaxLength="60"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="txtaddress" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
            <td class="labelcells">
                City</td>
            <td class="NormalText">
             <asp:TextBox ID="txtcity" runat="server" CssClass="textbox" MaxLength="30"></asp:TextBox>
                     <cc1:AutoCompleteExtender ID="txtCity_AutoCompleteExtender" runat="server" 
                            CompletionInterval="10" CompletionSetCount="20" MinimumPrefixLength="1" 
                            ServiceMethod="Jct_Payroll_City_List"   CompletionListCssClass="AutoExtender" 
                            ServicePath="~/WebService.asmx" 
                            CompletionListElementID="divwidth" 
                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight" 
                            CompletionListItemCssClass="AutoExtenderList"
                            TargetControlID="txtcity">
                        </cc1:AutoCompleteExtender>           
            </td>
   
        </tr>
                    <tr>
             <td class="labelcells">
                State</td>
            <td class="NormalText"> 
             <asp:TextBox ID="txtstate" runat="server" CssClass="textbox" MaxLength="30"></asp:TextBox>
                     <cc1:AutoCompleteExtender ID="txtState_AutoCompleteExtender" runat="server" 
                            CompletionInterval="10" CompletionSetCount="20" MinimumPrefixLength="1" 
                            ServiceMethod="Jct_Payroll_State_List"   CompletionListCssClass="AutoExtender" 
                            ServicePath="~/WebService.asmx" 
                            CompletionListElementID="divwidth" 
                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight" 
                            CompletionListItemCssClass="AutoExtenderList"
                            TargetControlID="txtstate">
                        </cc1:AutoCompleteExtender>
            
            </td>
            <td class="labelcells">
                Country</td>
            <td class="NormalText">
                <asp:DropDownList ID="ddlcountry" runat="server" CssClass="combobox">
                    <asp:ListItem Value="01">India</asp:ListItem>              
                </asp:DropDownList>
            </td>

       
       </tR>
        <tr>
            <td class="labelcells">
                Contact Person</td>
            <td class="NormalText" >
                <asp:TextBox ID="txtContactPerson" runat="server" CssClass="textbox" style="text-transform:capitalize;"
                    MaxLength="30"></asp:TextBox>    
            </td>
            <td class="labelcells">
                Contact No</td>
            <td class="NormalText" >
                <asp:TextBox ID="txtMobile" runat="server" CssClass="textbox" MaxLength="12"></asp:TextBox> 
         <%--       <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                    ErrorMessage="Enter Valid Mobile No." ControlToValidate="txtMobile" 
                    ValidationExpression="^[789]\d{9}$"></asp:RegularExpressionValidator>--%>
            </td>
        </tr>
        <tr>
        <td class="labelcells">
                IFSC Code</td>
            <td class="NormalText">
                <asp:TextBox ID="TxtIfsc" runat="server" style="text-transform:capitalize;"
                    CssClass="textbox" Width="100px" MaxLength="15"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                    ControlToValidate="TxtIfsc" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
      
            <td class="labelcells">
                Website</td>
            <td class="NormalText" >
                <asp:TextBox ID="TxtWebsite" runat="server" CssClass="textbox" MaxLength="40" 
                    Width="220px"></asp:TextBox>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                    ControlToValidate="TxtWebsite" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
             <asp:RegularExpressionValidator 
            ID="RegularExpressionValidator1" runat="server"  ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?" ControlToValidate="TxtWebsite"
            ErrorMessage="Input valid Internet URL!" ValidationGroup="A"></asp:RegularExpressionValidator>
              <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2"
                                runat="server" WatermarkCssClass="watermark" WatermarkText="https://www.yourwebsitename.com" targetcontrolid="TxtWebsite">
                            </cc1:TextBoxWatermarkExtender>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Effective From</td>
            <td class="NormalText">
                
                <asp:TextBox ID="txtefffrm" runat="server" CssClass="textbox" Width="70px"></asp:TextBox>
                <cc1:calendarextender ID="txtefffrm_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txtefffrm">
                </cc1:calendarextender>
              
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ControlToValidate="txtefffrm" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
            <td class="labelcells">
                Effective To</td>
            <td class="NormalText">
                <asp:TextBox ID="txteffto" runat="server" CssClass="textbox" Width="70px"></asp:TextBox>
                <cc1:calendarextender ID="txteffto_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txteffto">
                </cc1:calendarextender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                    ControlToValidate="txteffto" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
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

