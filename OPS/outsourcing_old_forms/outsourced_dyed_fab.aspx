<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true" CodeFile="outsourced_dyed_fab.aspx.cs" Inherits="OPS_outsourced_dyed_fab" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%">
        <tr>
            <td class="tableheader" colspan="6">
                Outsourced&nbsp; Fabric Purchase Request</td>
        </tr>
        <tr>
            <td class="NormalText"   colspan="4">
                <asp:RadioButtonList ID="rdlst" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="rdlst_SelectedIndexChanged" 
                    RepeatDirection="Horizontal" CssClass="combobox">
                    <asp:ListItem Value="marketing">Request By Mkt</asp:ListItem>
                    <asp:ListItem Value="Planning">Request By Planning</asp:ListItem>
                    <asp:ListItem Value="Rawmaterial">Request By Rawmaterial</asp:ListItem>
                    <asp:ListItem>WardRobe items</asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <td class="NormalText"  >
                <asp:Label ID="lbid" runat="server"></asp:Label>
            </td>
            <td class="NormalText"  >
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText">
                Quantity required</td>
            <td class="NormalText">
                <asp:TextBox ID="txtqtyreq" runat="server" CssClass="textbox" MaxLength="8" 
                    Width="50px"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="txtqtyreq_FilteredTextBoxExtender" 
                    runat="server" TargetControlID="txtqtyreq" ValidChars=".0123456789">
                </cc1:FilteredTextBoxExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtqtyreq" ErrorMessage="cnt be blank" 
                    ValidationGroup="mandatory">*</asp:RequiredFieldValidator>
            </td>
            <td class="NormalText">
                Plant</td>
            <td class="NormalText">
                <asp:DropDownList ID="ddlplant" runat="server" CssClass="combobox">
                    <asp:ListItem>Cotton</asp:ListItem>
                    <asp:ListItem>Taffeta</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="NormalText">
                Fabric Type</td>
            <td class="NormalText">
                <asp:TextBox ID="txtfbtype" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:AutoCompleteExtender ID="txtfbtype_AutoCompleteExtender" runat="server" 
                    CompletionInterval="100" 
                    CompletionListCssClass="autocomplete_completionListElement" 
                    CompletionSetCount="100" MinimumPrefixLength="1" 
                    ServiceMethod="ops_fetch_itemtype" ServicePath="~/webservice.asmx" 
                    TargetControlID="txtfbtype">
                </cc1:AutoCompleteExtender>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                Payment/delivery terms</td>
            <td class="NormalText">
                <asp:TextBox ID="txtpayment" runat="server" CssClass="textbox" 
                    TextMode="MultiLine"></asp:TextBox>
            </td>
            <td class="NormalText">
                Delivery upto</td>
            <td class="NormalText">
                <asp:TextBox ID="txtdeli" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td class="NormalText">
                Delivery date</td>
            <td class="NormalText">
                <asp:TextBox ID="txtdelivdt" runat="server" CssClass="textbox" Width="60px"></asp:TextBox>
                <cc1:TextBoxWatermarkExtender ID="txtdelivdt_TextBoxWatermarkExtender" 
                    runat="server" Enabled="True" TargetControlID="txtdelivdt" 
                    WatermarkText="DD/MM/YY">
                </cc1:TextBoxWatermarkExtender>
                <cc1:CalendarExtender ID="txtdelivdt_CalendarExtender" runat="server" 
                    TargetControlID="txtdelivdt">
                </cc1:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                Parallel sort(if any)</td>
            <td>
                <asp:TextBox ID="txtsort" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td class="NormalText">
                Sale order (if any)</td>
            <td>
                <asp:TextBox ID="txtso" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td class="NormalText">
                New number(if any)</td>
            <td>
                <asp:TextBox ID="txtnum" runat="server" CssClass="textbox" Width="60px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                Finish fabric`s customer name</td>
            <td>
                <asp:TextBox ID="txtcust" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:AutoCompleteExtender ID="txtcust_AutoCompleteExtender" runat="server" 
                    CompletionInterval="100" 
                    CompletionListCssClass="autocomplete_completionListElement" 
                    CompletionSetCount="100" MinimumPrefixLength="1" ServiceMethod="OPS_Customer" 
                    ServicePath="~/webservice.asmx" TargetControlID="txtcust">
                </cc1:AutoCompleteExtender>
            </td>
            <td class="NormalText">
                Reference marketing executive</td>
            <td>
                <asp:TextBox ID="txtmkt" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:AutoCompleteExtender ID="txtmkt_AutoCompleteExtender" runat="server" 
                    CompletionInterval="100" 
                    CompletionListCssClass="autocomplete_completionListElement" 
                    CompletionSetCount="100" MinimumPrefixLength="1" ServiceMethod="mktnames" 
                    ServicePath="~/webservice.asmx" TargetControlID="txtmkt">
                </cc1:AutoCompleteExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="txtmkt" ErrorMessage="cnt be blank" 
                    ValidationGroup="mandatory">*</asp:RequiredFieldValidator>
            </td>
            <td class="NormalText">
                GroupName</td>
            <td>
                <asp:DropDownList ID="ddlgrp" runat="server" DataSourceID="SqlDataSource1" 
                    DataTextField="Column1" DataValueField="Column1" CssClass="combobox">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:misjctdev %>" SelectCommand=" select  '' union select item_group_no+ '     '+group_desc from   miserp.som.dbo.m_item_group where group_type = 'SBITEM'  
and status ='O'  
"></asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                Freight charges</td>
            <td>
                <asp:DropDownList ID="ddlfreight" runat="server" CssClass="combobox">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Buyer</asp:ListItem>
                    <asp:ListItem>supplier</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="NormalText">
                Packing Details</td>
            <td>
                <asp:DropDownList ID="ddlpack" runat="server" CssClass="combobox">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Roll</asp:ListItem>
                    <asp:ListItem>Lump</asp:ListItem>
                    <asp:ListItem>Taka</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="NormalText">
                End Use</td>
            <td class="NormalText">
                <asp:TextBox ID="txtspecial" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
        </tr>
      <tr>
            <td class="NormalText">
                <asp:Label ID="lbpurchase" runat="server" Text="Purchase price"></asp:Label>
            </td>
            <td style="height: 16px">
                <asp:TextBox ID="TextBox1" runat="server" CssClass="textbox" Width="50px" 
                    Visible="False"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" 
                    runat="server" Enabled="True" TargetControlID="txtpurchase" 
                    ValidChars=".0123456789">
                </cc1:FilteredTextBoxExtender>
                <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" 
                    CssClass="NormalText" oncheckedchanged="CheckBox1_CheckedChanged" 
                    Text="Same as ReqQty" Visible="False" />
            </td>
            <td class="NormalText">
                <asp:Label ID="lbfinshprice" runat="server" Text="Finish Sale price" 
                    Visible="False"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtfinishsale" runat="server" CssClass="textbox" Width="50px" 
                    Visible="False"></asp:TextBox>
            </td>
            <td class="NormalText">
                </td>
            <td class="NormalText">
                </td>
        </tr>
        <tr>
            <td class="NormalText">
                <asp:Label ID="lbprchse" runat="server" Text="Purchase(Qty)" Visible="False"></asp:Label>
            </td>
            <td style="height: 16px">
                <asp:TextBox ID="txtpurchase" runat="server" CssClass="textbox" Width="50px" 
                    Visible="False"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="txtpurchase_FilteredTextBoxExtender" 
                    runat="server" Enabled="True" TargetControlID="txtpurchase" 
                    ValidChars=".0123456789">
                </cc1:FilteredTextBoxExtender>
                <asp:CheckBox ID="chkpur" runat="server" AutoPostBack="True"  Visible="false"
                    CssClass="NormalText" oncheckedchanged="CheckBox1_CheckedChanged" 
                    Text="Same as ReqQty" />
            </td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                </td>
            <td class="NormalText">
                </td>
        </tr>
        <tr>
            <td class="NormalText" colspan="6">
                Remarks
                <br />
                <asp:TextBox ID="txtremark" runat="server" CssClass="textbox" 
                    TextMode="MultiLine" Height="51px" Width="611px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="NormalText" colspan="6">
                </td>
        </tr>
        <tr>
            <td class="NormalText" colspan="6">
                <asp:Panel ID="Panel1" runat="server" ScrollBars="Both" Width="900px" Height="150px">
                    <asp:GridView ID="grdDetail" runat="server" AutoGenerateSelectButton="True" 
                        onselectedindexchanged="grdDetail_SelectedIndexChanged" Width="100%">
                        <AlternatingRowStyle CssClass="GridAI" />
                        <HeaderStyle CssClass="GridHeader" />
                        <PagerStyle CssClass="PageStyle" />
                        <RowStyle CssClass="GridItem" />
                        <SelectedRowStyle CssClass="GridRowGreen" />
                    </asp:GridView>
                </asp:Panel>
            </td>
           
        </tr>
    
        <tr>
            <td class="buttonbackbar" colspan="6">
                <asp:LinkButton ID="lnksave" runat="server" CssClass="buttonc" 
                    onclick="LinkButton4_Click" ValidationGroup="mandatory">Save</asp:LinkButton>
                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="buttonc" 
                    onclick="LinkButton1_Click">Clear</asp:LinkButton>
                <asp:LinkButton ID="LinkButton2" runat="server" CssClass="buttonc" 
                    onclick="LinkButton2_Click">Delete</asp:LinkButton>
                <asp:LinkButton ID="lnkupd" runat="server" CssClass="buttonc" 
                    onclick="LinkButton3_Click">Update</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="NormalText" colspan="6">
                &nbsp;</td>
            <%--<table style="width: 100%;" class="tableback">
        <tr>
            <td valign="top">
                <asp:Label ID="Label1" runat="server" Font-Size="Small" Text="Authorizing Hierarchy"></asp:Label>
            </td>
        </tr>
        <tr>
            <td valign="top">
                Add Level
            </td>
        </tr>
        <tr>
            <td valign="top">
                <table style="width: 100%;">
                    <tr>
                        <td colspan="3" valign="top">
                            <asp:UpdatePanel ID="UpdatePanel8" runat="server" RenderMode="Inline">
                                <ContentTemplate>
                                    <asp:TextBox ID="txtEmployee" runat="server" CssClass="textbox" Width="200px"></asp:TextBox>
                                    <asp:LinkButton ID="cmdSearch" runat="server" CssClass="searchbluesmall" Height="16px"
                                        Width="16px" onclick="cmdSearch_Click"></asp:LinkButton>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td width="50%">
                            <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                <ContentTemplate>
                                    <asp:Panel ID="Panel2" runat="server" Height="200px" ScrollBars="Both" Width="450px">
                                        <asp:CheckBoxList ID="ChkEmpList" runat="server" CellPadding="0" CellSpacing="0"
                                            Height="99px" RepeatColumns="1" Width="502px">
                                        </asp:CheckBoxList>
                                    </asp:Panel>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                        <td>
                            <asp:LinkButton ID="btnTransfer" runat="server" onclick="btnTransfer_Click">Level</asp:LinkButton>
                            <br />
                            <br />
                            
                            <asp:LinkButton ID="cmdCC" runat="server" onclick="cmdCC_Click">Notify</asp:LinkButton>
                            <br />
                            <br />
                            <asp:LinkButton ID="imgRemoveItem" runat="server" Height="21px" ToolTip="Click To Clear All Selected Items"
                                Width="24px" CssClass="btncross" onclick="imgRemoveItem_Click">X</asp:LinkButton>
                            <br />
                        </td>
                        <td valign="top" width="50%">
                            <asp:UpdatePanel ID="UpdatePanel10" runat="server" RenderMode="Inline" UpdateMode="Conditional">
                                <ContentTemplate>
                                    Level<br />
                                    <asp:CheckBoxList ID="ChkDynamicListing" runat="server">
                                    </asp:CheckBoxList>
                                    <hr />
                                    Notify<br />
                                    <asp:CheckBoxList ID="chkNotify" runat="server">
                                    </asp:CheckBoxList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table style="width: 100%;" class="tableback">
        <tr>
            <td valign="top">
               
                <asp:UpdatePanel ID="UpdatePanel11" runat="server" UpdateMode="always">
                    <ContentTemplate>
                        <asp:Panel ID="Panel3" runat="server" Height="150px" ScrollBars="Vertical">
                            <asp:GridView ID="GrdEmployee" runat="server" Width="99%">
                                <PagerStyle CssClass="PagerStyle" />
                                <AlternatingRowStyle CssClass="GridAI" />
                                <EmptyDataTemplate>
                                    No Data Found...! ! !
                                </EmptyDataTemplate>
                                <HeaderStyle CssClass="GridHeader" />
                                <RowStyle CssClass="GridItem" />
                                <SelectedRowStyle CssClass="GridRowGreen" />
                            </asp:GridView>
                        </asp:Panel>
                    </ContentTemplate>
                    
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    <table style="width: 100%;" class="tableback">
        <tr>
            <td class="tableback">
                Attachments..
            </td>
        </tr>
        <tr>
            <td valign="top">
              
                <span style="font-family: Arial">Click to add files</span>&nbsp;&nbsp;
                <input id="Button2" onclick="AddFileUpload()" type="button" value="add" onclick="return Button2_onclick()" />
                <div id="FileUploadContainer">
              
                </div>
              
            </td>
        </tr>
    </table>
    <table style="width: 100%;" class="tableback">
        <tr>
            <td valign="top" class="buttonbackbar">
                <asp:LinkButton ID="cmdApply" runat="server" BorderStyle="None" CssClass="buttonc"
                    ValidationGroup="GrpApply">Apply</asp:LinkButton>
                &nbsp;<asp:LinkButton ID="cmdReset" runat="server" BorderStyle="None" CssClass="buttonc">Reset</asp:LinkButton>
            </td>
        </tr>
    </table>
    <table style="width: 100%;" class="tableback">
        <tr>
            <td valign="top" colspan="3">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td valign="top">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td valign="top">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td valign="top" colspan="3">
                &nbsp;
                <asp:FileUpload ID="FileUpload1" runat="server" Height="0px" Width="0px" />
                &nbsp; &nbsp;
            </td>
        </tr>
    </table>--%>
        </tr>
    </table>

 <%--<table style="width: 100%;" class="tableback">
        <tr>
            <td valign="top">
                <asp:Label ID="Label1" runat="server" Font-Size="Small" Text="Authorizing Hierarchy"></asp:Label>
            </td>
        </tr>
        <tr>
            <td valign="top">
                Add Level
            </td>
        </tr>
        <tr>
            <td valign="top">
                <table style="width: 100%;">
                    <tr>
                        <td colspan="3" valign="top">
                            <asp:UpdatePanel ID="UpdatePanel8" runat="server" RenderMode="Inline">
                                <ContentTemplate>
                                    <asp:TextBox ID="txtEmployee" runat="server" CssClass="textbox" Width="200px"></asp:TextBox>
                                    <asp:LinkButton ID="cmdSearch" runat="server" CssClass="searchbluesmall" Height="16px"
                                        Width="16px" onclick="cmdSearch_Click"></asp:LinkButton>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td width="50%">
                            <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                <ContentTemplate>
                                    <asp:Panel ID="Panel2" runat="server" Height="200px" ScrollBars="Both" Width="450px">
                                        <asp:CheckBoxList ID="ChkEmpList" runat="server" CellPadding="0" CellSpacing="0"
                                            Height="99px" RepeatColumns="1" Width="502px">
                                        </asp:CheckBoxList>
                                    </asp:Panel>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                        <td>
                            <asp:LinkButton ID="btnTransfer" runat="server" onclick="btnTransfer_Click">Level</asp:LinkButton>
                            <br />
                            <br />
                            
                            <asp:LinkButton ID="cmdCC" runat="server" onclick="cmdCC_Click">Notify</asp:LinkButton>
                            <br />
                            <br />
                            <asp:LinkButton ID="imgRemoveItem" runat="server" Height="21px" ToolTip="Click To Clear All Selected Items"
                                Width="24px" CssClass="btncross" onclick="imgRemoveItem_Click">X</asp:LinkButton>
                            <br />
                        </td>
                        <td valign="top" width="50%">
                            <asp:UpdatePanel ID="UpdatePanel10" runat="server" RenderMode="Inline" UpdateMode="Conditional">
                                <ContentTemplate>
                                    Level<br />
                                    <asp:CheckBoxList ID="ChkDynamicListing" runat="server">
                                    </asp:CheckBoxList>
                                    <hr />
                                    Notify<br />
                                    <asp:CheckBoxList ID="chkNotify" runat="server">
                                    </asp:CheckBoxList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table style="width: 100%;" class="tableback">
        <tr>
            <td valign="top">
               
                <asp:UpdatePanel ID="UpdatePanel11" runat="server" UpdateMode="always">
                    <ContentTemplate>
                        <asp:Panel ID="Panel3" runat="server" Height="150px" ScrollBars="Vertical">
                            <asp:GridView ID="GrdEmployee" runat="server" Width="99%">
                                <PagerStyle CssClass="PagerStyle" />
                                <AlternatingRowStyle CssClass="GridAI" />
                                <EmptyDataTemplate>
                                    No Data Found...! ! !
                                </EmptyDataTemplate>
                                <HeaderStyle CssClass="GridHeader" />
                                <RowStyle CssClass="GridItem" />
                                <SelectedRowStyle CssClass="GridRowGreen" />
                            </asp:GridView>
                        </asp:Panel>
                    </ContentTemplate>
                    
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    <table style="width: 100%;" class="tableback">
        <tr>
            <td class="tableback">
                Attachments..
            </td>
        </tr>
        <tr>
            <td valign="top">
              
                <span style="font-family: Arial">Click to add files</span>&nbsp;&nbsp;
                <input id="Button2" onclick="AddFileUpload()" type="button" value="add" onclick="return Button2_onclick()" />
                <div id="FileUploadContainer">
              
                </div>
              
            </td>
        </tr>
    </table>
    <table style="width: 100%;" class="tableback">
        <tr>
            <td valign="top" class="buttonbackbar">
                <asp:LinkButton ID="cmdApply" runat="server" BorderStyle="None" CssClass="buttonc"
                    ValidationGroup="GrpApply">Apply</asp:LinkButton>
                &nbsp;<asp:LinkButton ID="cmdReset" runat="server" BorderStyle="None" CssClass="buttonc">Reset</asp:LinkButton>
            </td>
        </tr>
    </table>
    <table style="width: 100%;" class="tableback">
        <tr>
            <td valign="top" colspan="3">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td valign="top">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td valign="top">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td valign="top" colspan="3">
                &nbsp;
                <asp:FileUpload ID="FileUpload1" runat="server" Height="0px" Width="0px" />
                &nbsp; &nbsp;
            </td>
        </tr>
    </table>--%>

   <table width="100%" cellpadding="0" cellspacing="0" style="height: 100%">
       
        <tr>
            <td class="labelcells">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="Panel2" runat="server" Width="644px" CssClass="panelbg" 
                            Visible="False" >
                            <table style="width:100%;" cellpadding="1px" cellspacing="1px" border="1px">
                                <tr>
                                    <td align="left" colspan="1" height="10px">
                                        <asp:Label ID="Label18" runat="server" Font-Bold="True" 
                                            Text="Select Request Type"></asp:Label>
                                        <cc1:ModalPopupExtender ID="ModalPopUp_PageLoad" runat="server" 
                                            BackgroundCssClass="modalBackground" 
                                            PopupControlID="Panel2" TargetControlID="Label18">
                                        </cc1:ModalPopupExtender>
                                    </td>
                                    <td align="left" height="10px">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td align="left" class="labelcells" style="width: 177px; height: 20px;">
                                        <asp:Label ID="Label17" runat="server" Text="Select Your Request Mode"></asp:Label>
                                    </td>
                                    <td align="left" class="labelcells" style="height: 20px">
                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                            <ContentTemplate>
                                                <asp:RadioButtonList ID="rblType" runat="server" CssClass="combobox" 
                                                    RepeatDirection="Horizontal" 
                                                    onselectedindexchanged="rblType_SelectedIndexChanged">
                                                    <asp:ListItem>FABRIC</asp:ListItem>
                                                    <asp:ListItem>YARN</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" class="labelcells" style="width: 177px">
                                        &nbsp;</td>
                                    <td align="left" class="labelcells">
                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                            <ContentTemplate>
                                                <asp:LinkButton ID="lnkbutton" runat="server" CssClass="buttonc" 
                                                    onclick="lnkbutton_Click">Enter</asp:LinkButton>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                                    ControlToValidate="rblType" 
                                                    ErrorMessage="Please select Request Mode First" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        </table>



</asp:Content>

