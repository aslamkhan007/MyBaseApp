<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true"  CodeFile="Costing_Count_Master.aspx.cs" Inherits="OPS_Costing_Count_Master" %>
<%@ Register Src="FlashMessage.ascx" TagName="FlashMessage" TagPrefix="uc1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script>
    function NumberOnly() {
        var AsciiValue = event.keyCode
        if ((AsciiValue >= 48 && AsciiValue <= 57) || (AsciiValue == 8 || AsciiValue == 127))
            event.returnValue = true;
        else
            event.returnValue = false;
    }
       
        </script>
     <script src="../Scripts/jquery-1.4.3.min.js" type="text/javascript"></script>  
    <script src="../Scripts/jquery.tablesorter.js" type="text/javascript"></script>  
    <script type="text/javascript">
        $(document).ready(function () {
            $("#grdView").tablesorter();
        });   
    </script> 

<table style="width: 88%; height: 264px;">
        <tr>
            <td style="height: 41px;" colspan="2">
                <asp:Label ID="Label1" runat="server" Text="Costing Count Master"></asp:Label>
            </td>
            <td style="width: 51px; height: 41px;">
                <asp:Label ID="Label16" runat="server" CssClass="labelcells" Text="Action" Visible="False"></asp:Label>
            </td>
            <td style="height: 41px">
                <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddl_action" runat="server" CssClass="combobox" Visible="False">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="height: 41px">
                &nbsp;</td>
            <td style="height: 41px" colspan="5">
            </td>
        </tr>
        <tr>
            <td style="width: 94px">
                <asp:Label ID="Label12" runat="server" CssClass="labelcells" Text="Tran.No."></asp:Label>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txttranno" runat="server" CssClass="textbox" Width="80px"></asp:TextBox>
                          <asp:ImageButton ID="imb_tran_fetch" runat="server" Height="12px" ImageUrl="~/Image/Buttons_Tabs/Arrow_Right.png"
                            Style="width: 15px" />
                                         </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="width: 51px">
                &nbsp;
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td style="width: 94px">
                <asp:Label ID="Label3" runat="server" Text="Count Code" CssClass="labelcells" Width="90px"></asp:Label>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtCountCode" runat="server" CssClass="textbox" Width="60px"
                            AutoPostBack="True" MaxLength="6"></asp:TextBox>
                         
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="width: 51px">
                <asp:Label ID="Label5" runat="server" Text="Count Desc." CssClass="labelcells"></asp:Label>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtCountDesc" runat="server" CssClass="textbox" Width="150px" 
                            AutoPostBack="True" MaxLength="15"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                &nbsp;
            </td>
            <td colspan="5">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 94px">
                <asp:Label ID="Label4" runat="server" Text="Count Type" CssClass="labelcells"></asp:Label>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlCountType" runat="server" CssClass="combobox" AutoPostBack="false"
                            Width="130px" >
                            <asp:ListItem Text="Select" Value=""></asp:ListItem>
                            <asp:ListItem Text="Single" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Double" Value="2"></asp:ListItem>
                                <asp:ListItem Text="Tripple" Value="3"></asp:ListItem>
                                
                            </asp:DropDownList>
                       
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="width: 51px">
               <asp:Label ID="Label2" runat="server" Text="Actual Count" CssClass="labelcells"></asp:Label>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                 <ContentTemplate>
                        <asp:TextBox ID="txtActualCount" runat="server" CssClass="textbox"
                            Width="60px"  ></asp:TextBox>
                       
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                &nbsp;
            </td>
            <td colspan="5">
                &nbsp;
            </td>
        </tr>
           <tr>
            <td style="width: 94px">
                <asp:Label ID="Label6" runat="server" Text="Count Usage" CssClass="labelcells"></asp:Label>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlCountUsage" runat="server" CssClass="combobox" 
                            Width="130px" >
                                 <asp:ListItem Text="Select" Value=""></asp:ListItem>
                            <asp:ListItem Text="Warp" Value="W"></asp:ListItem>
                                <asp:ListItem Text="Weft" Value="F"></asp:ListItem>
                                <asp:ListItem Text="Both" Value="B"></asp:ListItem>
                                </asp:DropDownList>
                       
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="width: 51px">
               <asp:Label ID="Label7" runat="server" Text="Sequence No" CssClass="labelcells"></asp:Label>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                 <ContentTemplate>
                        <asp:TextBox ID="txtSequenceNo" runat="server" CssClass="textbox" 
                            Width="60px" onkeypress="return NumberOnly()" ></asp:TextBox>
                       
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                &nbsp;
            </td>
            <td colspan="5">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 94px">
                <asp:Label ID="Label14" runat="server" CssClass="labelcells" Text="Eff. From(mm/dd/yyyy)"
                    Width="60px"></asp:Label>
            </td>
           <%--  <td colspan="1" class="textcells">
                <ew:calendarpopup ID="txt_efffrom" runat="server" BackColor="WhiteSmoke" Culture="English (United Kingdom)"
                    Font-Names="Tahoma" Font-Size="8pt" Text="..." UpperBoundDate="12/31/9990 23:59:00"
                    Width="77px">
                    <ClearDateStyle BackColor="#E0E0E0" />
                    <DayHeaderStyle BackColor="OrangeRed" />
                    <MonthYearSelectedItemStyle BackColor="Silver" />
                    <TodayDayStyle BackColor="#FFC0C0" />
                    <MonthHeaderStyle BackColor="Gray" />
                    <GoToTodayStyle BackColor="#E0E0E0" />
                </ew:calendarpopup>
               </td>--%>
           <%-- <td style="height: 67px">
                <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_efffrom" runat="server" CssClass="textbox" Width="109px"  ReadOnly="true"
                            Height="16px"  ></asp:TextBox>
                       
                      <cc1:CalendarExtender ID="CalExt1" runat="server" Format="MM/dd/yyyy" TargetControlID="txt_efffrom">
                        </cc1:CalendarExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>--%>
            <td class="NormalText" style="width: 152px">
                <asp:UpdatePanel ID="UpdatePanel7" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_efffrom" runat="server" CssClass="textbox" Width="60px"></asp:TextBox>
                        <cc1:CalendarExtender ID="txt_efffrom_CalendarExtender" runat="server" TargetControlID="txt_efffrom">
                        </cc1:CalendarExtender>
                        <cc1:MaskedEditValidator ID="MEV6" runat="server" ControlExtender="MEE6" ControlToValidate="txt_efffrom"
                            Display="Dynamic" InvalidValueMessage="Invalid" IsValidEmpty="true" EmptyValueMessage="*" 
                            TooltipMessage="MM/DD/YYYY" Width="114px">
                        </cc1:MaskedEditValidator>
                        <cc1:MaskedEditExtender ID="MEE6" runat="server" Mask="99/99/9999" MaskType="Date"
                            TargetControlID="txt_efffrom">
                        </cc1:MaskedEditExtender>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="grdView" 
                            EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>

            <td style="width: 51px">
                <asp:Label ID="Label15" runat="server" CssClass="labelcells" Text="Eff. To(mm/dd/yyyy)"></asp:Label>
            </td>
           
            <td class="NormalText" style="width: 152px">
                <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_effto" runat="server" CssClass="textbox" Width="60px" ></asp:TextBox>
                        <cc1:CalendarExtender ID="txt_effto_CalendarExtender" runat="server" TargetControlID="txt_effto">
                        </cc1:CalendarExtender>
                        <cc1:MaskedEditValidator ID="MaskedEditValidator1" runat="server" ControlExtender="MEE6" ControlToValidate="txt_effto"
                            Display="Dynamic" InvalidValueMessage="Invalid" IsValidEmpty="true" EmptyValueMessage="*"
                            TooltipMessage="MM/DD/YYYY" Width="114px">
                        </cc1:MaskedEditValidator>
                        <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" Mask="99/99/9999" MaskType="Date"
                            TargetControlID="txt_effto">
                        </cc1:MaskedEditExtender>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="grdView" 
                            EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
           <%-- <td>
                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_effto" runat="server" CssClass="textbox" Width="109px" onkeypress="popupCalendar()"
                            Height="16px" ReadOnly="True"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalExt2" runat="server" Format="MM/dd/yyyy" TargetControlID="txt_effto">
                        </cc1:CalendarExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>--%>
            <td>
                &nbsp;
            </td>
            <td colspan="5">
                &nbsp;
            </td>
        </tr>
        <%--  <tr>
            <td style="width: 94px">
                &nbsp;</td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                </asp:UpdatePanel>
            </td>
            <td style="width: 51px">
                &nbsp;</td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                </asp:UpdatePanel>
            </td>
            
        </tr>--%>
        <tr>
           <td colspan="10">
            <asp:Panel ID="Panel1" runat="server" BorderStyle="Solid" Height="150px" 
                    ScrollBars="Both" Width="750px">
                    <div>
                        <asp:UpdatePanel ID="UpdatePanel22" runat="server">
                             <ContentTemplate>
                                <asp:GridView ID="grdView" runat="server" AutoGenerateColumns="False"  onselectedindexchanged="grdView_SelectedIndexChanged" DataKeyNames="tran_no">
                                    <Columns>
              <%--  <asp:Panel runat="server" BorderStyle="Solid" Height="400px" ScrollBars="Both">
                    <div>
                        <asp:UpdatePanel ID="UpdatePanel22" runat="server">
                            <ContentTemplate>
                                
                                  <asp:GridView ID="grdView" runat="server" AutoGenerateColumns="False"  Width="700px"
                                    onselectedindexchanged="grdView_SelectedIndexChanged" DataKeyNames="tran_no">                                    
                                    <Columns>  --%>                                   
                                        <%--<asp:CommandField ShowSelectButton="True" />--%>
                                        <%--<asp:BoundField DataField="type_code" HeaderText="Type Code"  />--%>
                                         
                                        <asp:ButtonField DataTextField="tran_no" HeaderText="Tran No" CommandName="Select" />                                       
                                     <%--   <asp:BoundField HeaderText="Count Code" DataField="count_code"  SortExpression="count_code"   />--%>
                                      <asp:BoundField HeaderText="Count Code" DataField="count_code" />
                                        <asp:BoundField HeaderText="Count Desc." DataField="count_desc" />
                                        <asp:BoundField HeaderText="Count Type" DataField="count_type"  />                                        
                                        <asp:BoundField HeaderText="Actual Count" DataField="actual_count" />
                                        <asp:BoundField HeaderText="Count Usage" DataField="count_usage" />
                                        <asp:BoundField DataField="sequence_no" HeaderText="Sequence No" />                                        
                                        <asp:BoundField HeaderText="Effective From" DataField="eff_from" />
                                        <asp:BoundField HeaderText="Effective To" DataField="eff_to" />
                                        <asp:BoundField HeaderText="Status" DataField="Status" />
                                        <asp:BoundField HeaderText="Company" DataField="Company_code" />
                                        
                                       
                                    </Columns>
                                    <HeaderStyle CssClass="GridHeader" />
                                </asp:GridView>

                                
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td style="width: 94px">
                <asp:UpdatePanel ID="UpdatePanel23" runat="server">
                    <ContentTemplate>
                        <asp:LinkButton ID="lbt_apply" runat="server" CssClass="buttonc" Visible="False">APPLY</asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td colspan="4" align="center">
                <asp:UpdatePanel ID="UpdatePanel21" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="FMsg1" runat="server" ForeColor="Red" Text=""></asp:Label>
                        
                        <asp:LinkButton ID ="btnAdd" runat="server" Text="ADD" CssClass="buttonc" onclick="btnAdd_Click"  />                       
                       <asp:LinkButton ID ="btnRefresh" runat="server" Text="Refresh" CssClass="buttonc" onclick="btnRefresh_Click"  /> 
                       <asp:LinkButton ID="btnAuthorize" runat="server" Text="Authorize" CssClass="buttonc" onclick="btnAuthorize_Click"
                           />
                        <asp:LinkButton ID="btnDelete" runat="server" Text="Delete" CssClass="buttonc" 
                            onclick="btnDelete_Click"  />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td colspan="5">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 94px">
                &nbsp;
            </td>
            <td colspan="4">
                <asp:UpdatePanel ID="UpdatePanel24" runat="server">
                    <ContentTemplate>
                     <%--   <uc1:FlashMessage ID="FMsg1" runat="server" EnableTheming="true" EnableViewState="true"
                            FadeInDuration="2" FadeInSteps="2" FadeOutDuration="2" FadeOutSteps="2" Visible="true" />--%>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td colspan="5">
                &nbsp;
            </td>
        </tr>
    </table>

</asp:Content>


