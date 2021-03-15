<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true" CodeFile="jct_ops_jobwork_common.aspx.cs" Inherits="OPS_jct_ops_jobwork_common" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%" >
        <tr>
            <td class="tableheader" colspan="4">
                Jobwork Invoice :</td>
        </tr>
        <tr>
            <td class="labelcells">
            
                Request Id</td>
            <td class="NormalText">
               <%-- <asp:Label ID="lbcodeid" runat="server" Visible="False"></asp:Label>--%>
                <asp:DropDownList ID="ddlrequestid" runat="server" CssClass="combobox" 
                    onselectedindexchanged="ddlrequestid_SelectedIndexChanged" 
                    AutoPostBack="True" AppendDataBoundItems="True" 
                    ToolTip="PLEASE SELECT REQUEST ID FROM LIST">
                    <asp:ListItem></asp:ListItem>
                                
                </asp:DropDownList>
                
            </td>
            <td class="labelcells">
                <asp:Label ID="lblInvoiceNo" runat="server" Text="Invoice No" Visible="False"></asp:Label>
            </td>
            <td class="labelcells">
                
              <asp:Label ID="lblInvoiceNoCode" runat="server" Visible="False"></asp:Label>
                
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                <asp:Label ID="mkt" runat="server" Text="Mkt Exe" Visible="False"></asp:Label>
  &nbsp;&nbsp;&nbsp;&nbsp;
            
                <asp:Label ID="lblmktref" runat="server" Text="Mkt Reference" Visible="False"></asp:Label>
            </td>
            <td class="labelcells">
                <asp:Label ID="sort" runat="server" Text="Sort" Visible="False"></asp:Label>
&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblSortNo" runat="server" Text="Sort No" Visible="False"></asp:Label>
                
            </td>
            <td class="labelcells">
                <asp:Label ID="Quantity" runat="server" Text="Quantity" Visible="False"></asp:Label>
&nbsp;
                <asp:Label ID="lblQuantity" runat="server" Text="Quantity" Visible="False"></asp:Label>
            </td>
            <td class="labelcells">
                <asp:Label ID="Construction" runat="server" Text="Construction" Visible="False"></asp:Label>
&nbsp;
                
                <asp:Label ID="lblConstruction" runat="server" Text="Construction  " 
                    Visible="False"></asp:Label>
                
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Excise Roll No</td>
            <td class="labelcells">
                
                <asp:TextBox ID="txtExciseRollNo" runat="server" CssClass="textbox" 
                    MaxLength="100" ToolTip="PLEASE INPUT LESS THAN 100 WORDS"></asp:TextBox>
           <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
             ControlToValidate="txtExciseRollNo" ErrorMessage="PLEASE ENTER EXCISE ROLL NO *" 
                    ValidationGroup="A">*</asp:RequiredFieldValidator>
                
            </td>
            <td class="labelcells">
                &nbsp;</td>
            <td class="labelcells">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="labelcells">
                Transport Mode</td>
            <td class="NormalText">
                <asp:DropDownList ID="ddlTransportMode" runat="server" CssClass="combobox" 
                    AppendDataBoundItems="True" AutoPostBack="True" 
                    ToolTip="SELECT MODE OF TRANSPORT FROM LIST">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Air</asp:ListItem>
                    <asp:ListItem>Road</asp:ListItem>
                    <asp:ListItem>Sea</asp:ListItem>
                    <asp:ListItem>Courier</asp:ListItem>
                    <asp:ListItem>Train</asp:ListItem>
                                
                </asp:DropDownList></td>
            <td class="labelcells">
                Tariff Classification No</td>
            <td class="labelcells">
                <asp:TextBox ID="txtTariffClassficationNo" runat="server" CssClass="textbox" 
                    ToolTip="ONLY IN NUMERIC VALUE"></asp:TextBox>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="txtTariffClassficationNo" 
                    ErrorMessage="PLEASE ENTER TARIFF CLASSIFICATION NO *" ValidationGroup="A">*</asp:RequiredFieldValidator>

               <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" 
              ValidChars="0123456789." TargetControlID="txtTariffClassficationNo">
             </cc1:FilteredTextBoxExtender>  
                
                </td>
        </tr>
        <tr>
            <td class="labelcells">
                Rolls</td>
            <td class="NormalText">
                <asp:TextBox ID="txtRolls" runat="server" CssClass="textbox" Width="70px" 
                    ToolTip="INTEGER VALUE "></asp:TextBox>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
             ControlToValidate="txtRolls" ErrorMessage="PLEASE ENTER ROLLS*" 
                    ValidationGroup="A">*</asp:RequiredFieldValidator>

                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" 
              ValidChars="0123456789." TargetControlID="txtRolls">
             </cc1:FilteredTextBoxExtender>  
                
            </td>
            <td class="labelcells">
                Gross Weight</td>
            <td class="labelcells">
                <asp:TextBox ID="txtGrossWt" runat="server" CssClass="textbox" 
                    ToolTip="ONLY NUMERIC VALUES "></asp:TextBox>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ControlToValidate="txtGrossWt" ErrorMessage="PLEASE ENTER GROSS WT *" 
                    ValidationGroup="A">*</asp:RequiredFieldValidator>
                
            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" 
              ValidChars="0123456789." TargetControlID="txtGrossWt">
             </cc1:FilteredTextBoxExtender>  


            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Remarks</td>
            <td class="NormalText">
                <asp:TextBox ID="txtRemarks" runat="server" TextMode="MultiLine" 
                    CssClass="textbox" MaxLength="4" 
                    ToolTip="SPECIAL REMARKS REGARDING INVOICE"></asp:TextBox>
                </td>
            <td class="labelcells">
            </td>
            <td class="labelcells">
            </td>
        </tr>
        <tr>
            <td class="labelcells" colspan="4">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                    DisplayMode="List" ValidationGroup="A" />
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:LinkButton ID="lnkadd" runat="server" CssClass="buttonc" 
                    onclick="lnkadd_Click" ValidationGroup="A">Add</asp:LinkButton>
                <%--<asp:LinkButton ID="lnkupdate" runat="server" CssClass="buttonc" 
                    onclick="lnkupdate_Click" ValidationGroup="A">Update</asp:LinkButton>--%>
                <asp:LinkButton ID="lnkdelete" runat="server" CssClass="buttonc" 
                    onclick="lnkdelete_Click" ValidationGroup="A">Delete</asp:LinkButton>
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

