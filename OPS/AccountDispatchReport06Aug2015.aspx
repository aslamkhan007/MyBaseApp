<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/OPS/MasterPage.master" CodeFile="AccountDispatchReport.aspx.cs" Inherits="OPS_AccountDispatchReport" %>

<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register Src="~/FlashMessage.ascx" TagName="FlashMessage" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
 <table style="width: 88%; height: 264px;">
        <tr>
            <td style="height: 41px;" colspan="2">
                <asp:Label ID="Label1" runat="server" Text="Account Dispatch Report"></asp:Label>
            </td>
            <td style="height: 41px">
            </td>
            <td style="height: 41px" colspan="2">
            </td>
        </tr>
        <tr>
     
         <td style="width: 70px">
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
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_FromDate"
                            Width="20px" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </ContentTemplate>
                   <%-- <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="grdView" 
                            EventName="SelectedIndexChanged" />
                    </Triggers>--%>
                </asp:UpdatePanel>
            </td>
           
         <td style="width:95px">
                <asp:Label ID="Label2" runat="server" CssClass="labelcells" Text="To Date"></asp:Label>
            </td>
            <td class="NormalText" style="width: 38px">
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
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_ToDate"
                            Width="20px" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </ContentTemplate>
                  </asp:UpdatePanel>
            </td>
           
           <td style="text-align: center">
                <asp:UpdatePanel ID="UpdatePanel21" runat="server">
                    <ContentTemplate>
                <asp:Label ID="Message" runat="server" CssClass="labelcells" ForeColor="Red" Text=""></asp:Label>
                        <asp:LinkButton ID="lnkFetch" runat="server" CssClass="buttonc" Visible="false" onclick="lnkFetch_Click" 
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
         <td style="width: 31px; ">
                &nbsp;
          
            </td>
        </tr>
       <tr>
       
        <td class="NormalText" style="width: 100px">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="100">
                    <ProgressTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Image/load.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
            
        </tr>
        <tr>
            <td colspan="5">
                <asp:Panel ID="Panel1" runat="server" Height="561px" ScrollBars="Both" Visible="false" Width="1080px">
                    <div>
                        <asp:UpdatePanel ID="UpdatePanel22"  Visible="false" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="grdView" runat="server"  Visible="false" AutoGenerateColumns="True" TabIndex="50"
                                    Height="106px" Width="870px">
                                    <AlternatingRowStyle CssClass="GridAI" />
                                 
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