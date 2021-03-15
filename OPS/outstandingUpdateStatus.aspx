<%@ Page Language="VB" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="false" CodeFile="outstandingUpdateStatus.aspx.vb" Inherits="outstandingUpdateStatus" title="Outstanding Update Status" MaintainScrollPositionOnPostback="true" %>  
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <script language="javascript" type="text/javascript">
// <!CDATA[

function TABLE1_onclick() {

//}

// ]]>
</script>

    <table style="width:100%">
        <tr>
            <td class="tableheader" colspan="5">
                Outstanding Reasons( A/C &amp; Sales)</td>
        </tr>
    </table>
    <table style="width: 100%">
        <tr>
            <td class="labelcells" style="height: 16px; text-align: center;" colspan="4">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="labelcells" style="width: 99px; height: 16px;">
                &nbsp;</td>
            <td class="NormalText" style="height: 16px">
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        </asp:UpdatePanel>
                        
            </td>
            <td class="labelcells" style="width: 100px; height: 16px;">
                &nbsp;</td>
            <td style="height: 16px">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells" style="width: 99px">
                Customer</td>
            
                              <td class="NormalText" style="width: 200px">

                    <div id="divwidth" style="display:none;">   
                        </div>
                              
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:TextBox ID="TxtCustomer" runat="server" AutoPostBack="True" 
                            CssClass="textbox" TabIndex="2" Width="200"></asp:TextBox>
                        <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" 
                            CompletionInterval="10" CompletionListCssClass="AutoExtender" 
                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight" 
                            CompletionListItemCssClass="AutoExtenderList" CompletionSetCount="20" 
                            MinimumPrefixLength="1" ServiceMethod="OPS_Customer" 
                            ServicePath="~/CityService.asmx" TargetControlID="TxtCustomer">
                        </cc1:AutoCompleteExtender>
                        <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender3" runat="server" 
                            TargetControlID="TxtCustomer" WatermarkCssClass="normalfld" WatermarkText="ALL">
                        </cc1:TextBoxWatermarkExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
                      
                        
                        
            </td>



 
            <td class="labelcells" style="width: 100px">
                Order No</td>
            <td>
                 
                                 <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                     <ContentTemplate>
                                         <asp:TextBox ID="TxtOrder" runat="server" AutoPostBack="True" 
                                             CssClass="textbox" TabIndex="2" Width="200"></asp:TextBox>
                                         <cc1:AutoCompleteExtender ID="TxtOrder_AutoCompleteExtender" runat="server" 
                                             CompletionInterval="10" CompletionListCssClass="AutoExtender" 
                                             CompletionListHighlightedItemCssClass="AutoExtenderHighlight" 
                                             CompletionListItemCssClass="AutoExtenderList" CompletionSetCount="20" 
                                             MinimumPrefixLength="1" ServiceMethod="OPS_Customer" 
                                             ServicePath="~/CityService.asmx" TargetControlID="TxtOrder">
                                         </cc1:AutoCompleteExtender>
                                         <cc1:TextBoxWatermarkExtender ID="TxtOrder_TextBoxWatermarkExtender" 
                                             runat="server" TargetControlID="TxtOrder" WatermarkCssClass="normalfld" 
                                             WatermarkText="ALL">
                                         </cc1:TextBoxWatermarkExtender>
                                     </ContentTemplate>
                                 </asp:UpdatePanel>
                        
                        
            </td>
        </tr>
        <tr>
            <td class="labelcells" style="width: 99px; height: 11px">
                &nbsp;</td>
            
                              <td class="NormalText" style="width: 200px; height: 11px;">

                                  &nbsp;</td>



 
            <td class="labelcells" style="width: 100px; height: 11px">
                <asp:Button ID="BtnGet" runat="server" Text="Fetch" CssClass="ButtonBack" 
                    BackColor="Black" CausesValidation="False" />
                </td>
            <td style="height: 11px">
                 
                                 &nbsp;</td>
        </tr>
        <tr>
            <td class="tableheader" style="height: 30px" colspan="4">
                Satus For Update<asp:GridView ID="GridView1" runat="server" AllowPaging="True"  
                     PageSize="5"   width="100%" GridLines="None"  CssClass="GridViewStyle" 
                     
                    EnableModelValidation="True">
                    <PagerSettings Mode="NumericFirstLast" PageButtonCount="20" />
                    <Columns>
                        <asp:TemplateField HeaderText="Reasons">
                            <ItemTemplate>
                                <asp:DropDownList ID="ddlreasons" runat="server" CssClass="textbox">
                                    <asp:ListItem>Sample</asp:ListItem>
                                    <asp:ListItem>Cash</asp:ListItem>
                                    <asp:ListItem>RG/FOC</asp:ListItem>
                                    <asp:ListItem>ShortRec.</asp:ListItem>
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>Rate</asp:ListItem>
                                    <asp:ListItem>Credit</asp:ListItem>
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>Freight</asp:ListItem>
                                    <asp:ListItem></asp:ListItem>
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Date">
                            <ItemTemplate>
                                <asp:TextBox ID="Txtdate" runat="server" CssClass="textbox" 
                                 ></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Amount">
                            <ItemTemplate>
                                <asp:TextBox ID="Txtamt" runat="server" Height="16px" Width="73px"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Dr/Cr">
                            <ItemTemplate>
                                <asp:DropDownList ID="DropDownList1" runat="server" Height="22px" 
                                 
                                    style="margin-bottom: 0px" Width="50px">
                                    <asp:ListItem>Dr</asp:ListItem>
                                    <asp:ListItem>Cr</asp:ListItem>
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                  
    <RowStyle CssClass="RowStyle" />

    <EmptyDataRowStyle CssClass="EmptyRowStyle" />

    <PagerStyle CssClass="PagerStyle" />

    <SelectedRowStyle CssClass="SelectedRowStyle" />

    <HeaderStyle CssClass="HeaderStyle" />

    <EditRowStyle CssClass="EditRowStyle" />

    <AlternatingRowStyle CssClass="AltRowStyle" />


                </asp:GridView>
                                            </td>
            
        </tr>
        <tr>
            <td style="width: 99px" class="labelcells">
                Change Status </td>
            <td style="width: 93px" class="textcells">
                <asp:DropDownList ID="txtRemarksToUpdate" runat="server" CssClass="combobox">
                    <asp:ListItem></asp:ListItem>
                     <asp:ListItem>ALL</asp:ListItem>
                    <asp:ListItem>APPROVAL AWAITED </asp:ListItem>
                    <asp:ListItem>BACK GREY</asp:ListItem>
                    <asp:ListItem>DEFENCE</asp:ListItem>
                    <asp:ListItem>DEVELOPMENT SAMPLES</asp:ListItem>
                    <asp:ListItem>DOMESTIC/LOCAL</asp:ListItem>
                    <asp:ListItem>EXCESS/COTODS</asp:ListItem>
                    <asp:ListItem>GARMENTING</asp:ListItem>
                    <asp:ListItem>HOLD</asp:ListItem>
                    <asp:ListItem>INCOMPLETE ORDER</asp:ListItem>
                    <asp:ListItem>LIABILITY - STOCK SALE</asp:ListItem>
                    <asp:ListItem>N/A</asp:ListItem>
                    <asp:ListItem>ORDER CANCELLED</asp:ListItem>
                    <asp:ListItem>OUTSOURCED DOSUTI</asp:ListItem>
                    <asp:ListItem>READY FOR DESPATCH</asp:ListItem>
                    <asp:ListItem>REJECTED</asp:ListItem>
                    <asp:ListItem>SAMPLE SURPLUS</asp:ListItem>
                    <asp:ListItem>TAFETTA REMNANT</asp:ListItem>
                    <asp:ListItem>TT PAYMENT AWAITED</asp:ListItem>
                    <asp:ListItem>TAFFETA</asp:ListItem>
                    <asp:ListItem>YARN STOCK</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td style="width: 100px" class="labelcells">
                Change&nbsp; Date</td>
            <td cssclass="textcells">
                        <asp:UpdatePanel ID="From" runat="server" RenderMode="Inline">
                    <ContentTemplate>
                        <asp:TextBox  ID="txtDate" TabIndex="3" runat="server" Width="70px"
                            CssClass="textbox" Enabled="True" MaxLength="8" ></asp:TextBox>
                        <cc1:MaskedEditValidator ID="MaskedEditValidator1" runat="server" Width="114px" 
                            ControlToValidate="txtDate"
                            Display="Dynamic" 
                            ControlExtender="MaskedEditExtender1" 
                            TooltipMessage="MM/DD/YYYY"
                            IsValidEmpty="False" 
                            EmptyValueMessage="*" 
                            InvalidValueMessage="The Date is invalid">
                          &nbsp;&nbsp;
                          </cc1:MaskedEditValidator>
                          
                          <cc1:CalendarExtender
                                ID="CalFrom" runat="server" TargetControlID="txtDate" Animated="False" Format="MM/dd/yyyy">
                            </cc1:CalendarExtender>
                        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                        <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtDate"
                            MaskType="Date" Mask="99/99/9999">
                        </cc1:MaskedEditExtender>
                      
                    </ContentTemplate>
                </asp:UpdatePanel></td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4" style="height: 6px">
                <asp:Button ID="btnUpdate" runat="server" Text="Update" 
                    CssClass="ButtonBack" BackColor="Black" />
                <asp:Button ID="Check" runat="server" Text="Check" CssClass="ButtonBack" BackColor="Black" />
                <asp:Button ID="UnCheck" runat="server" Text="UnCheck" CssClass="ButtonBack" BackColor="Black"/>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:LinkButton ID="LinkButton1" runat="server">LinkButton</asp:LinkButton>
                <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            </td>
        </tr>
    </table>
</asp:Content>

