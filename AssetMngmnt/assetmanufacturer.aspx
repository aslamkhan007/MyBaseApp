<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="assetmanufacturer.aspx.cs" Inherits="AssetMngmnt_assetmanufacturer" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="mytable">
        <tr>
            <td class="tableheader" colspan="4">
                <asp:Label ID="Label18" runat="server" Text="Asset Manufacturer Master"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 175px" >
                Type</td>
            <td class="NormalText" style="width: 134px">
                                     <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                <asp:DropDownList ID="ddltype" runat="server" CssClass="combobox" 
                    onselectedindexchanged="ddltype_SelectedIndexChanged" AutoPostBack="True">
                    <asp:ListItem>Vendor</asp:ListItem>
                    <asp:ListItem>Manufacturer</asp:ListItem>
                </asp:DropDownList>
                                           </ContentTemplate>
                </asp:UpdatePanel>
            </td>
             
         
            <td class="NormalText" style="width: 137px">
              
                <asp:Label
                    ID="manufucatureid" runat="server" Visible="False">Manufacturerid</asp:Label>
            </td>
             
         
            <td class="NormalText">
              
            <asp:Label ID="lblmanufactureid" runat="server" Visible="False"></asp:Label>
            </td>
             
         
        </tr>
        <tr>
            <td class="NormalText" style="width: 175px" >
                Effective From</td>
            <td class="NormalText">
                                     <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                <asp:TextBox ID="txtefffrm" runat="server" CssClass="textbox" Width="70px"></asp:TextBox>


                                <cc1:MaskedEditExtender ID="MEE1" runat="server" 
                    Mask="99/99/9999" MaskType="Date" TargetControlID="txtefffrm">
                </cc1:MaskedEditExtender>
                <cc1:MaskedEditValidator ID="MEV1" runat="server" 
                    ControlExtender="MEE1" ControlToValidate="txtefffrm" Display="Dynamic" 
                    EmptyValueMessage="ENTER DATE!!" ErrorMessage="MEV1" 
                    InvalidValueMessage="INVALID DATE" TooltipMessage="MM/DD/YYYY" 
                    ValidationGroup="mandatory" Width="70px"></cc1:MaskedEditValidator>

                <cc1:CalendarExtender ID="txtefffrm_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txtefffrm">
                </cc1:CalendarExtender>
                   </ContentTemplate>
                </asp:UpdatePanel>
            </td>
             
         
            <td class="NormalText" style="width: 137px">
                EffectiveTo</td>
             
         
            <td class="NormalText">
                                     <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>

                <asp:TextBox ID="txteffto" runat="server" CssClass="textbox" Width="70px"></asp:TextBox>

                                                <cc1:MaskedEditExtender ID="MEE2" runat="server" 
                    Mask="99/99/9999" MaskType="Date" TargetControlID="txteffto">
                </cc1:MaskedEditExtender>
                <cc1:MaskedEditValidator ID="MEV2" runat="server" 
                    ControlExtender="MEE2" ControlToValidate="txteffto" Display="Dynamic" 
                    EmptyValueMessage="ENTER DATE!!" ErrorMessage="MEV2" 
                    InvalidValueMessage="INVALID DATE" TooltipMessage="MM/DD/YYYY" 
                    ValidationGroup="mandatory"></cc1:MaskedEditValidator>

                <cc1:CalendarExtender ID="txteffto_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txteffto">
                </cc1:CalendarExtender>
                                 </ContentTemplate>
                </asp:UpdatePanel>
            </td>
             
         
        </tr>
        <tr>
            <td class="NormalText" style="width: 175px" >
                &nbsp;Name</td>
            <td class="NormalText" colspan="3">
                                     <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>

                <asp:TextBox ID="txtmanfactname" runat="server" CssClass="textbox" Width="200px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtmanfactname" Display="Dynamic" ErrorMessage="**" ValidationGroup="A"></asp:RequiredFieldValidator>
                                 </ContentTemplate>
                </asp:UpdatePanel>
            </td>
         
        </tr>
        <tr>
            <td class="NormalText" style="width: 175px" >
                Description</td>
            <td class="NormalText" style="width: 134px">
                                     <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                    <ContentTemplate>

                <asp:TextBox ID="txtmanufactdesc" runat="server" CssClass="textbox" Height="50px" TextMode="MultiLine" Width="200px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtmanufactdesc" Display="Dynamic" ErrorMessage="**" ValidationGroup="A"></asp:RequiredFieldValidator>
                
                 </ContentTemplate>
                </asp:UpdatePanel>
            </td>
       
            <td class="NormalText" style="width: 137px">
                Contact Number</td>
       
            <td class="NormalText">
                                     <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                    <ContentTemplate>

                <asp:TextBox ID="txtcontactnum" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="txtcontactnum_FilteredTextBoxExtender" 
                    runat="server" Enabled="True" TargetControlID="txtcontactnum" 
                    ValidChars="0123456789">
                </cc1:FilteredTextBoxExtender>
                
                 </ContentTemplate>
                </asp:UpdatePanel>
            </td>
       
        </tr>
        <tr>
            <td class="NormalText" style="width: 175px" >
                Address</td>
            <td class="NormalText" style="width: 134px">
                                     <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                    <ContentTemplate>

                <asp:TextBox ID="txtaddress" runat="server" CssClass="textbox" 
                    TextMode="MultiLine" Height="50px" Width="200px"></asp:TextBox>
                    
                 </ContentTemplate>
                </asp:UpdatePanel>
            </td>
       
            <td class="NormalText" style="width: 137px">
                E-mail</td>
       
            <td class="NormalText">
                                     <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                    <ContentTemplate>

                <asp:TextBox ID="txtemail" runat="server" CssClass="textbox" Width="200px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ControlToValidate="txtemail" Display="Dynamic" ErrorMessage="Invalid Email" 
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="A"></asp:RegularExpressionValidator>
                    
                 </ContentTemplate>
                </asp:UpdatePanel>
            </td>
       
        </tr>
        <tr>
            <td class="NormalText" colspan="4" >
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="100">
                    <progresstemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Image/load.gif" />
                    </progresstemplate>
                </asp:UpdateProgress>
            </td>
       
        </tr>
        <tr>

            <td class="buttonbackbar" colspan="4">
                         <asp:UpdatePanel ID="Updbuttons" runat="server">
                    <ContentTemplate>
                <asp:LinkButton ID="lnkadd" runat="server" CssClass="buttonc" 
                    onclick="lnkadd_Click" ValidationGroup="A">Add</asp:LinkButton>

                        <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="lnkdel"
                            ConfirmText="Are u sure To Delete ?">
                        </cc1:ConfirmButtonExtender>

                <asp:LinkButton ID="lnkdel" runat="server" CssClass="buttonc" 
                    onclick="lnkdel_Click" ValidationGroup="A">Delete</asp:LinkButton>
                <asp:LinkButton ID="lnkupdate" runat="server" CssClass="buttonc" 
                    onclick="lnkupdate_Click" ValidationGroup="A">Update</asp:LinkButton>
                <asp:LinkButton ID="lnkreset" runat="server" CssClass="buttonc" 
                    onclick="lnkreset_Click">Reset</asp:LinkButton>
                <asp:Label ID="lbid" runat="server" Text="Label" Visible="False"></asp:Label>
            </td>
                           </ContentTemplate>
                </asp:UpdatePanel>
 
        </tr>
        <tr>
            <td class="NormalText" colspan="4">
                                     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                <asp:GridView ID="grdDetail" runat="server" AutoGenerateSelectButton="True" 
                    Width="100%" onselectedindexchanged="grdDetail_SelectedIndexChanged">
                    <AlternatingRowStyle CssClass="GridAI" />
                    <HeaderStyle CssClass="HeaderStyle" />
                    <PagerStyle CssClass="PageStyle" />
                    <RowStyle CssClass="GridItem" />
                    <SelectedRowStyle CssClass="GridRowGreen" />
                </asp:GridView>
            </td>
       
                                  </ContentTemplate>
                </asp:UpdatePanel>
       
        </tr>
    </table>
</asp:Content>

