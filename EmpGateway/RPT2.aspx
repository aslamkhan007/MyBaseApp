<%@ Page Language="VB" MasterPageFile="MasterPage.master" AutoEventWireup="false" CodeFile="RPT2.aspx.vb" Inherits="RPT2" title="Guest Requests" %>
<%@ Register Src="FlashMessage.ascx" TagName="FlashMessage" TagPrefix="uc1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.2.3600.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
     
     

    <table style="width: 100%;">
    <tr>
        <td class="tableheader">
        
            Guest House Request Report<asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
        </td>
    </tr>
    <tr>
        <td style="height: 37px" class="textcells">
        
                            <table style="width:100%;" __designer:mapid="3c6">
                                <tr __designer:mapid="3c7">
                                    <td style="width: 117px" __designer:mapid="3c8">
                                        <asp:Label ID="Label2" runat="server" Text="Company" CssClass="labelcells"></asp:Label>
                                    </td>
                                    <td style="width: 199px" __designer:mapid="3ca">
                                        <asp:UpdatePanel ID="UpdatePanel8" runat="server" RenderMode="Inline">
                                            <ContentTemplate>
                                               
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <asp:UpdatePanel ID="UpdatePanel31" runat="server">
                                            <ContentTemplate>
                                                <span>
                                                <asp:DropDownList ID="DdlComp" runat="server" AutoPostBack="True" 
                                                    Font-Names="Tahoma" Font-Size="8pt" Width="140px">
                                                </asp:DropDownList>
                                                </span>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                    <td style="width: 201px" __designer:mapid="3d1" class="labelcells">
                                        <asp:Label ID="Label37" runat="server" Text="Stay Required"></asp:Label>
                                    </td>
                                    <td __designer:mapid="3d2" class="textcells">
                                        <span __designer:mapid="3d7">
                                        <asp:UpdatePanel ID="UpdatePanel33" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="DrpAccom" runat="server" CssClass="combobox" 
                                                    Width="102px" AutoPostBack="True">
                                                     <asp:ListItem Value="Y">YES</asp:ListItem>
                                                        <asp:ListItem Value="N">NO</asp:ListItem>
                                                        <asp:ListItem Value="ALL"  Selected="True">ALL</asp:ListItem>
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        </span>
                                    </td>
                                </tr>
                                <tr __designer:mapid="3f5">
                                    <td class="labelcells" style="width: 117px" __designer:mapid="3f6">
                                        <asp:Label ID="Label42" runat="server" Text="Meals"></asp:Label>
                                    </td>
                                    <td style="width: 199px" __designer:mapid="3f8">
                                        <asp:UpdatePanel ID="UpdatePanel43" runat="server" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="DrpMeals" runat="server" CssClass="combobox" Width="95px">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="CMDCLEAR" EventName="Click" />
                                                <asp:AsyncPostBackTrigger ControlID="DrpAccom" 
                                                    EventName="SelectedIndexChanged" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </td>
                                    <td class="labelcells" style="width: 201px" __designer:mapid="3fc">
                                        <asp:Label ID="Label40" runat="server" Text="Guest House"></asp:Label>
                                    </td>
                                    <td __designer:mapid="3fd" class="textcells">
                                        <asp:UpdatePanel ID="UpdatePanel41" runat="server" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <span>
                                                <asp:DropDownList ID="DdlAccomm" runat="server" 
                                                    Font-Names="Tahoma" Font-Size="8pt" Width="111px">
                                                </asp:DropDownList>
                                                </span>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="CMDCLEAR" EventName="Click" />
                                                <asp:AsyncPostBackTrigger ControlID="DrpAccom" 
                                                    EventName="SelectedIndexChanged" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr __designer:mapid="3fe">
                                    <td class="labelcells" style="width: 117px" __designer:mapid="3ff">
                                        <asp:Label ID="Label34" runat="server" CssClass="labelcells" Text="Guest Name"></asp:Label>
                                    </td>
                                    <td style="width: 199px" __designer:mapid="401">
                                        <span __designer:mapid="402">
                                        <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                                            <ContentTemplate>
                                                <span>
                                                <asp:TextBox ID="TxtName" runat="server" CssClass="textbox" Font-Names="Tahoma" 
                                                    Width="175px"></asp:TextBox>
                                                </span>
                                                <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" 
                                                    TargetControlID="TxtName" WatermarkCssClass="watermark" 
                                                    WatermarkText="Guest Name Here">
                                                </cc1:TextBoxWatermarkExtender>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        </span>
                                    </td>
                                    <td class="labelcells" style="width: 201px" __designer:mapid="407">
                                        <asp:Label ID="Label41" runat="server" Text="Booked By"></asp:Label>
                                    </td>
                                    <td __designer:mapid="409" class="textcells">
                                        <asp:UpdatePanel ID="UpdatePanel42" runat="server">
                                            <ContentTemplate>
                                                <asp:TextBox ID="TxtBookedBy" runat="server" CssClass="textbox" MaxLength="25" 
                                                    Width="162px"></asp:TextBox>
                                                <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server" 
                                                    TargetControlID="TxtBookedBy" WatermarkCssClass="watermark" 
                                                    WatermarkText="Enter Employee Name Here">
                                                </cc1:TextBoxWatermarkExtender>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr __designer:mapid="3fe">
                                    <td class="labelcells" style="width: 117px; height: 34px;" 
                                        __designer:mapid="3ff">
                                        <asp:Label ID="Label38" runat="server" Text="From Date"></asp:Label>
                                    </td>
                                    <td style="width: 199px; height: 34px;" __designer:mapid="401" 
                                        class="textcells">
                                        <asp:UpdatePanel ID="UpdatePanel21" runat="server"><ContentTemplate>
                                        <asp:TextBox ID="Datefrom" runat="server" AccessKey="d" CssClass="textbox" 
                                            MaxLength="8" TabIndex="3" Width="70px"></asp:TextBox>
                                                <cc1:MaskedEditValidator ID="MaskedEditValidator1" runat="server" 
                                            ControlExtender="MaskedEditExtender1" ControlToValidate="Datefrom" 
                                            Display="Dynamic" EmptyValueMessage="*" Height="16px" 
                                            InvalidValueMessage="The Date is invalid" IsValidEmpty="False" 
                                            TooltipMessage="MM/DD/YYYY" Width="90px"></cc1:MaskedEditValidator><cc1:CalendarExtender ID="CalFrom" runat="server" Animated="False" Format="MM/dd/yyyy" PopupPosition="TopRight" TargetControlID="Datefrom"></cc1:CalendarExtender><cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="Datefrom"></cc1:MaskedEditExtender>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                    <td class="labelcells" style="width: 201px; height: 34px;" 
                                        __designer:mapid="407">
                                        <asp:Label ID="Label39" runat="server" Text="To Date"></asp:Label>
                                    </td>
                                    <td __designer:mapid="409" class="textcells" style="height: 34px">
                                        <asp:UpdatePanel ID="UpdatePanel34" runat="server">
                                            <ContentTemplate>
                                                <asp:TextBox ID="Dateto" runat="server" 
                                                    CssClass="textbox" MaxLength="8" TabIndex="4" Width="70px" ></asp:TextBox>
                                                <cc1:MaskedEditValidator ID="MaskedEditValidator2" runat="server" 
                                                    ControlExtender="MaskedEditExtender2" ControlToValidate="Dateto" 
                                                    Display="Dynamic" EmptyValueMessage="*" 
                                                    InvalidValueMessage="The Date is invalid " IsValidEmpty="False" 
                                                    TooltipMessage="MM/DD/YYYY"></cc1:MaskedEditValidator>
                                                <cc1:CalendarExtender ID="CalTo" runat="server" Animated="False" 
                                                    Format="MM/dd/yyyy" PopupPosition="TopRight" TargetControlID="Dateto">
                                                </cc1:CalendarExtender>
                                                <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" 
                                                    Mask="99/99/9999" MaskType="Date" TargetControlID="Dateto">
                                                </cc1:MaskedEditExtender></ContentTemplate></asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr __designer:mapid="40d">
                                    <td class="labelcells" style="width: 117px; height: 33px;" 
                                        __designer:mapid="40e">
                                        <asp:Panel ID="Panel6" runat="server" CssClass="panel">
                                            <asp:UpdatePanel ID="UpdatePanel35" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <span>
                                                    <asp:RadioButtonList ID="RLFood" runat="server" Font-Bold="True" 
                                                        Font-Names="Tahoma" Font-Size="8pt" ForeColor="#404040" Height="18px" 
                                                        RepeatDirection="Horizontal" Width="188px">
                                                        <asp:ListItem Value="Veg">Veg</asp:ListItem>
                                                        <asp:ListItem Value="Non-Veg">Non-Veg</asp:ListItem>
                                                        <asp:ListItem Value="Both"  Selected="True">Both</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                    </span>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </asp:Panel>
                                    </td>
                                    <td style="width: 199px; height: 33px;" __designer:mapid="417" 
                                        class="labelcells">
                                        <asp:Panel ID="Panel7" runat="server" CssClass="panel">
                                          
                                                    <asp:UpdatePanel ID="UpdatePanel37" runat="server">
                                                        <ContentTemplate>
                                                            <span>
                                                            <asp:RadioButtonList ID="RLDrink1" runat="server" Font-Bold="True" 
                                                                Font-Names="Tahoma" Font-Size="8pt" ForeColor="#404040" 
                                                                RepeatDirection="Horizontal" Width="239px" Height="20px">
                                                                <asp:ListItem Value="Y">Drinks  Yes</asp:ListItem>
                                                                <asp:ListItem Value="N">Drinks No</asp:ListItem>
                                                                <asp:ListItem Value="Both"  Selected="True">Both</asp:ListItem>
                                                            </asp:RadioButtonList>
                                                            </span>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                              
                                        </asp:Panel>
                                    </td>
                                    <td class="labelcells" style="width: 201px; height: 33px;" 
                                        __designer:mapid="420">
                                        <asp:Panel ID="Panel8" runat="server" CssClass="panel">
                                            <span>
                                            <asp:UpdatePanel ID="UpdatePanel39" runat="server">
                                                <ContentTemplate>
                                                    <span>
                                                    <asp:RadioButtonList ID="RLCharge" runat="server" Font-Bold="True" 
                                                        Font-Names="Tahoma" Font-Size="8pt" ForeColor="#404040" 
                                                        RepeatDirection="Horizontal" Width="234px">
                                                        <asp:ListItem Value="Y">Chared Yes</asp:ListItem>
                                                        <asp:ListItem Value="N">Charged No</asp:ListItem>
                                                        <asp:ListItem Value="Both"  Selected="True">Both</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                    </span>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                            </span>
                                        </asp:Panel>
                                    </td>
                                    <td __designer:mapid="42a" class="labelcells" style="height: 33px">
                                        <asp:Panel ID="Panel9" runat="server" CssClass="panel">
                                            <asp:UpdatePanel ID="UpdatePanel40" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <span>
                                                    <asp:RadioButtonList ID="RadioButtonList6" runat="server" 
                                                        Height="21px" RepeatDirection="Horizontal" Width="152px" 
                                                        Font-Names="Tahoma" Font-Size="8pt">
                                                        <asp:ListItem  Value="N">Outsider</asp:ListItem>
                                                        <asp:ListItem Value="Y">JCTian</asp:ListItem>
                                                        <asp:ListItem Value="Both" Selected="True">Both</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                    </span>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                </table>
        </td>
    </tr>
    <tr>
        <td>
            <%--   </asp:Panel>--%>
                <table style="width: 100%;">
                                
                <tr>
             <td class="buttonbackbar">
                                
                                            <asp:UpdatePanel ID="UpdatePanel44" runat="server">
                                                <ContentTemplate>
                                                    <asp:LinkButton ID="LinkButton5" 
    runat="server" CssClass="buttonc" 
                                        Height="22px" Width="84px">Fetch</asp:LinkButton>
                                                    <asp:LinkButton ID="LinkButton6" runat="server" CausesValidation="False" 
                                                        CssClass="buttonc" Height="22px" Width="84px">Close</asp:LinkButton>
                                                    <asp:LinkButton ID="CMDCLEAR" runat="server" CausesValidation="False" 
                                                        CssClass="buttonc" Height="22px" Width="84px">Clear</asp:LinkButton>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                       
                        </td>
                   
                </tr>
                
                <tr>
             <td>
                                
                                        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                            <ProgressTemplate>
                                                <asp:Image ID="ProgressBar" runat="server" Height="10px" 
                                                    ImageUrl="~/Image/loading.gif" Width="70px" />
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                       
                        </td>
                   
                </tr>
                
                <tr>
             <td class="labelcells">
   
                         <asp:UpdatePanel ID="UpdatePanel45" runat="server">
                             <ContentTemplate>
                                 <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" 
                     AutoDataBind="true" BestFitPage="False" DisplayGroupTree="False" 
                                     EnableParameterPrompt="False">
                                 </CR:CrystalReportViewer>
                                 <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
                                     <Report FileName="EmpGateway\rptGuest.rpt">
                                     </Report>
                                 </CR:CrystalReportSource>
                             </ContentTemplate>
                             <Triggers>
                                 <asp:PostBackTrigger ControlID="CrystalReportViewer1" />
                                 <asp:AsyncPostBackTrigger ControlID="LinkButton5" EventName="Click" />
                             </Triggers>
                         </asp:UpdatePanel>
                    
                    </td>
                   
                </tr>
                
                    </table>
         <%--   </asp:Panel>--%>
        </td>
       
    </tr>
    </table>
    
</asp:Content>