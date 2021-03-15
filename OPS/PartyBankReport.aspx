<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/OPS/MasterPage.master"
    CodeFile="PartyBankReport.aspx.cs" Inherits="OPS_PartyBankReport" %>

<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register Src="~/FlashMessage.ascx" TagName="FlashMessage" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <table style="width: 88%; height: 264px;">
        <tr>
            <td style="height: 41px;" colspan="2">
                <asp:Label ID="Label1" runat="server" Text="Party Bank Detail Report"></asp:Label>
            </td>
            <td style="height: 41px">
            </td>
            <td style="height: 41px" colspan="5">
            </td>
        </tr>
        <tr>
     
         <td style="width: 51px">
                <asp:Label ID="Label15" runat="server" CssClass="labelcells" Text="From Date"></asp:Label>
            </td>
            <td class="NormalText" style="width: 38px">
                <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_FromDate" runat="server" CssClass="textbox" 
                            Width="100px" TabIndex="70"></asp:TextBox>
                        <cc1:CalendarExtender ID="txt_From_CalendarExtender" runat="server" TargetControlID="txt_FromDate">
                        </cc1:CalendarExtender>
                        <cc1:MaskedEditValidator ID="ME1" runat="server" ControlExtender="MEE1"
                            ControlToValidate="txt_FromDate" Display="Dynamic" InvalidValueMessage="Invalid"
                            IsValidEmpty="true" EmptyValueMessage="*" TooltipMessage="MM/DD/YYYY" >
                        </cc1:MaskedEditValidator>
                        <cc1:MaskedEditExtender ID="MEE1" runat="server" Mask="99/99/9999"
                            MaskType="Date" TargetControlID="txt_FromDate">
                        </cc1:MaskedEditExtender>
                        
                    </ContentTemplate>
                   <%-- <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="grdView" 
                            EventName="SelectedIndexChanged" />
                    </Triggers>--%>
                </asp:UpdatePanel>
            </td>
           
         <td style="width: 51px">
                <asp:Label ID="Label2" runat="server" CssClass="labelcells" Text="To Date"></asp:Label>
            </td>
            <td class="NormalText" style="width: 102px">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_ToDate" runat="server" CssClass="textbox" 
                            Width="100px" TabIndex="70"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_ToDate">
                        </cc1:CalendarExtender>
                        <cc1:MaskedEditValidator ID="MV1" runat="server" ControlExtender="MExtender1"
                            ControlToValidate="txt_ToDate" Display="Dynamic" InvalidValueMessage="Invalid"
                            IsValidEmpty="true" EmptyValueMessage="*" TooltipMessage="MM/DD/YYYY" >
                        </cc1:MaskedEditValidator>
                        <cc1:MaskedEditExtender ID="MExtender1" runat="server" Mask="99/99/9999"
                            MaskType="Date" TargetControlID="txt_ToDate">
                        </cc1:MaskedEditExtender>
                        
                    </ContentTemplate>
                 
                </asp:UpdatePanel>
            </td>
           
           <td colspan="15" style="text-align: center">
                <asp:UpdatePanel ID="UpdatePanel21" runat="server">
                    <ContentTemplate>
                        <asp:LinkButton ID="lnkBack" runat="server" CssClass="buttonc" onclick="lnkBack_Click" 
                              >Back</asp:LinkButton>
                        <asp:LinkButton ID="lnkFetch" runat="server" CssClass="buttonc" onclick="lnkFetch_Click" 
                              >Fetch</asp:LinkButton>
                                 <asp:LinkButton ID="lnkExcel" runat="server" CssClass="buttonc" onclick="lnkExcel_Click" 
                              >Excel</asp:LinkButton>
                       
                    </ContentTemplate>
                     <Triggers>
                        <asp:PostBackTrigger ControlID="lnkExcel" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
           
           
        
        </tr>
        <tr>
         <td style="width: 31px; height: 13px;">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="20">
                <asp:Panel ID="Panel1" runat="server" Height="261px" ScrollBars="Both" Width="890px">
                    <div>
                        <asp:UpdatePanel ID="UpdatePanel22" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="grdView" runat="server" AutoGenerateColumns="False" TabIndex="50"
                                    Height="106px" Width="870px">
                                    <AlternatingRowStyle CssClass="GridAI" />
                                    <Columns>
                                        <asp:BoundField HeaderText="BANK" DataField="BankType" />
                                        <asp:BoundField HeaderText="OPENING BALANCE" DataField="OpBal" />
                                        <asp:BoundField HeaderText="YARN" DataField="YRN" />
                                        <asp:BoundField HeaderText="DOM" DataField="DOM" />
                                        <asp:BoundField HeaderText="DELHI" DataField="DLI" />
                                        <asp:BoundField HeaderText="HOME" DataField="HOME" />
                                        <asp:BoundField HeaderText="MUMBAI" DataField="MUM" />
                                        <asp:BoundField HeaderText="NYLON" DataField="NYLON" />
                                        <asp:BoundField HeaderText="PHAGWARA" DataField="PGW" />
                                        <asp:BoundField HeaderText="RMG" DataField="RMG" />
                                        <asp:BoundField HeaderText="RSHOP" DataField="RSHOP" />
                                        <asp:BoundField HeaderText="WASTE" DataField="WASTE" />
                                    </Columns>
                                    <FooterStyle CssClass="FooterStyle" />
                                    <HeaderStyle CssClass="GridHeader" />
                                    <PagerStyle CssClass="PagerStyle" />
                                    <RowStyle CssClass="GridItem" />
                                    <SelectedRowStyle CssClass="GridRowGreen" />
                                </asp:GridView>
                            </ContentTemplate>
                          <%--  <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="grdView" EventName="SelectedIndexChanged" />
                            </Triggers>--%>
                        </asp:UpdatePanel>
                    </div>
                </asp:Panel>
            </td>
        </tr>
    </table>
    
</asp:Content>
