<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true" CodeFile="MR Feedback Reportaspx.aspx.cs" Inherits="OPS_MR_Feedback_Reportaspx" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <table style="width:100%;">
        <tr>
            <td class="tableheader">
                <asp:Label ID="Label18" runat="server" Text="MR Costing Feedback Report"></asp:Label>
            &nbsp;:</td>
        </tr>
    </table>
    <table style="width:100%;">
        <tr>
            <td class="NormalText" style="width: 108px">
                <asp:Label ID="Label20" runat="server" Text="From Date"></asp:Label>
            </td>
            <td class="NormalText" style="width: 166px">
                <asp:TextBox ID="txtFrom" runat="server" CssClass="textbox" Columns="10" 
                    MaxLength="10"></asp:TextBox>
            
                <cc1:CalendarExtender ID="txtFrom_CalendarExtender" runat="server" 
                    TargetControlID="txtFrom">
                </cc1:CalendarExtender>

                <cc1:MaskedEditExtender ID="MEE1" runat="server" Mask="99/99/9999" 
                    MaskType="Date" TargetControlID="txtFrom">
                </cc1:MaskedEditExtender>
                <cc1:MaskedEditValidator ID="MEV1" runat="server" ControlExtender="MEE1" 
                    ControlToValidate="txtFrom" Display="Dynamic" EmptyValueMessage="ENTER DATE!!" 
                    ErrorMessage="MEV1" InvalidValueMessage="INVALID DATE" 
                    TooltipMessage="MM/DD/YYYY" ValidationGroup="mandatory"></cc1:MaskedEditValidator>

            </td>
            <td class="NormalText" style="width: 78px">
                <asp:Label ID="Label24" runat="server" Text="To Date"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtTo" runat="server" CssClass="textbox" Columns="10" 
                    MaxLength="10"></asp:TextBox>
             
                <cc1:CalendarExtender ID="txtTo_CalendarExtender" runat="server" 
                    TargetControlID="txtTo">
                </cc1:CalendarExtender>

                <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" 
                    Mask="99/99/9999" MaskType="Date" TargetControlID="txtTo">
                </cc1:MaskedEditExtender>
                <cc1:MaskedEditValidator ID="MaskedEditValidator1" runat="server" 
                    ControlExtender="MEE1" ControlToValidate="txtTo" Display="Dynamic" 
                    EmptyValueMessage="ENTER DATE!!" ErrorMessage="MEV1" 
                    InvalidValueMessage="INVALID DATE" TooltipMessage="MM/DD/YYYY" 
                    ValidationGroup="mandatory"></cc1:MaskedEditValidator>

            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 108px">
             
                <asp:Label ID="Label23" runat="server" Text="SanctionNoteID"></asp:Label>
             
            </td>
            <td class="NormalText" style="width: 166px">
               
                        <asp:TextBox ID="txtSancitonNOte" runat="server" AutoPostBack="True" 
                            CssClass="textbox" 
                            ToolTip="Please enter your unique SanctionNoteId. E.g- 1935 "></asp:TextBox>
               
            </td>
            <td class="NormalText" style="width: 78px">
                &nbsp;</td>
            <td class="NormalText">
            
                &nbsp;</td>
        </tr>

           <%--   <tr>
            <td class="NormalText" style="width: 108px">
                Report Type</td>
            <td class="NormalText" style="width: 166px">
                  <asp:DropDownList ID="ddlReporttype" runat="server" CssClass="combobox">                      
                      <asp:ListItem>GroupWise</asp:ListItem>
                      <asp:ListItem>Individual</asp:ListItem>
                  </asp:DropDownList>
            </td>
            <td class="NormalText" style="width: 78px">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>--%>
        <%--<asp:Panel ID="Panel2" runat="server">--%>

              <tr>
            <td class="NormalText" style="width: 108px">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="100">
                    <ProgressTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Image/load.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
                  </td>
            <td class="NormalText" style="width: 166px">
                  &nbsp;</td>
            <td class="NormalText" style="width: 78px">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        </table>

    <%--<asp:Panel ID="Panel2" runat="server">--%>


    <table style="width:100%;">
        <tr>
            <td class="buttonbackbar">
                   <asp:UpdatePanel ID="UpdatePanel2" runat="server" RenderMode="Inline">
                    <ContentTemplate>
                        <asp:LinkButton ID="lnkSearch" runat="server" CssClass="buttonc" 
                            onclick="lnkSearch_Click">Search</asp:LinkButton>
                        
                    </ContentTemplate>
                </asp:UpdatePanel>
                  <asp:LinkButton ID="lnkExcel" runat="server" CssClass="buttonc" onclick="lnkExcel_Click">Excel</asp:LinkButton>
                        
                        <%--<asp:Panel ID="Panel2" runat="server">--%>
                        
                        <asp:LinkButton ID="lnkreset" runat="server" CssClass="buttonc" 
                            onclick="lnkreset_Click" style="height: 22px">Reset</asp:LinkButton>
                       
            </td>
        </tr>
    </table>
    <table style="width:100%;">
        <tr>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" >
                    <ContentTemplate>
                     <%--<asp:Panel ID="Panel2" runat="server">--%>                    
                        <asp:Panel ID="Panel1" Width="1000px" runat="server" Height="200px" ScrollBars="Horizontal">
                            <asp:GridView ID="GridView1" runat="server" 
                                EmptyDataText="No Data Available" 
                                Width="100%" EnableModelValidation="True" 
                                ShowFooter="True" 
                              >
                                <AlternatingRowStyle CssClass="GridAI" />
                                <HeaderStyle CssClass="GridHeader" />
                                <PagerStyle CssClass="PagerStyle" />
                                <RowStyle CssClass="GridItem" />
                                   <Columns>
                              
<%--                                   <asp:TemplateField HeaderText="Courier ID">
                                       <ItemTemplate>
                                           <asp:Label ID="lblOrdernoF" runat="server" Text='<%# Eval("Courier ID") %>'></asp:Label>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                   <asp:TemplateField HeaderText="Party Name">
                                       <ItemTemplate>
                                           <asp:Label ID="lblLineItemF" runat="server" Text='<%# Eval("Party Name") %>'></asp:Label>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                   <asp:TemplateField HeaderText="Status">
                                       <ItemTemplate>
                                           <asp:Label ID="lblSortF" runat="server" Text='<%# Eval("Status") %>'></asp:Label>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Tracking ID">
                                       <ItemTemplate>
                                           <asp:Label ID="lblVariantF" runat="server" Text='<%# Eval("Tracking ID") %>'></asp:Label>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Cost">
                                       <ItemTemplate>
                                           <asp:Label ID="lblCost" runat="server" Text='<%# Eval("Cost") %>'></asp:Label>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Account No">
                                       <ItemTemplate>
                                           <asp:Label ID="lblAccountNo" runat="server" Text='<%# Eval("AccountNo") %>'></asp:Label>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Booking No">
                                       <ItemTemplate>
                                           <asp:Label ID="lblBookingNo" runat="server" Text='<%# Eval("BookingNo") %>'></asp:Label>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Courier">
                                       <ItemTemplate>
                                           <asp:Label ID="lblPlantF" runat="server" Text='<%# Eval("Courier") %>'></asp:Label>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Delivery">
                                       <ItemTemplate>
                                           <asp:Label ID="lblClothTypeF" runat="server" Text='<%# Eval("Delivery") %>'></asp:Label>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                        <asp:TemplateField HeaderText="DispatchDt">
                                       <ItemTemplate>
                                           <asp:Label ID="lblDispatchDt" runat="server" Text='<%# Eval("DispatchDt") %>'></asp:Label>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                   <asp:TemplateField HeaderText="Authorized Date">
                                       <ItemTemplate>
                                           <asp:Label ID="lblReqdtF" runat="server" Text='<%# Eval("Authorized Date") %>'></asp:Label>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Subject">
                                       <ItemTemplate>
                                           <asp:Label ID="lblSubject" runat="server" Text='<%# Eval("Subject") %>'></asp:Label>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Address">
                                       <ItemTemplate>
                                           <asp:Label ID="lblAddress" runat="server" Text='<%# Eval("Address") %>'></asp:Label>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Request By">
                                       <ItemTemplate>
                                           <asp:Label ID="lblReqBy" runat="server" Text='<%# Eval("Request By") %>'></asp:Label>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Remarks">
                                       <ItemTemplate>
                                           <asp:Label ID="lblRemarks1" runat="server" Text='<%# Eval("Remarks") %>'></asp:Label>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Ref No">
                                       <ItemTemplate>
                                           <asp:Label ID="lblRemarks" runat="server" Text='<%# Eval("RefNo") %>'></asp:Label>
                                       </ItemTemplate>
                                   </asp:TemplateField>--%>
                       
                    </Columns>
                            </asp:GridView>
                        </asp:Panel>
                    </ContentTemplate>
                 <%--   <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="lnkSearch" EventName="Click" />
                    </Triggers>--%>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>

  <%--   <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="lnkSearch" EventName="Click" />
                    </Triggers>--%>

</asp:Content>
