<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true"
    CodeFile="Costing_Mixing_Master.aspx.cs" Inherits="OPS_Costing_Mixing_Master" %>
<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register Src="FlashMessage.ascx" TagName="FlashMessage" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

<script>
function NumberOnly()
        {
           var AsciiValue=event.keyCode
            if((AsciiValue>=48 && AsciiValue<=57) || (AsciiValue==8 || AsciiValue==127))
                event.returnValue=true;
            else
                event.returnValue=false;
        }
       
        </script>

        <script type="text/jscript" language="jscript">

            function popupCalendar() {

                var dateField = document.getElementById('dateField');


                if (dateField.style.display == 'none')
                    dateField.style.display = 'block';
                else
                    dateField.style.display = 'none';
            }

            
        
        
        </script>

    <table style="width: 88%; height: 264px;">
        <tr>
            <td style="height: 41px;" colspan="2">
                <asp:Label ID="Label1" runat="server" Text="Costing Mixing Master"></asp:Label>
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
            </td>
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
                <asp:Label ID="Label3" runat="server" Text="Mixing Code" CssClass="labelcells" Width="60px"></asp:Label>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtMixingCode" runat="server" CssClass="textbox" Width="60px" Enabled="False"
                             MaxLength="6"></asp:TextBox>
                         
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="width: 51px">
                <asp:Label ID="Label5" runat="server" Text="Desc." CssClass="labelcells"></asp:Label>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtMixingDesc" runat="server" CssClass="textbox" Width="200px" Enabled="False"
                             MaxLength="15"></asp:TextBox>
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
                <asp:Label ID="Label4" runat="server" Text="Sequence No" CssClass="labelcells"></asp:Label>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtSequence" runat="server" CssClass="textbox" AutoPostBack="false"
                            Width="60px" onkeypress="return NumberOnly()" MaxLength="3"></asp:TextBox>
                       
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="width: 51px">
                &nbsp;
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
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
                        <asp:TextBox ID="txt_efffrom" runat="server" CssClass="textbox" Width="60px" ></asp:TextBox>
                        <cc1:CalendarExtender ID="txt_efffrom_CalendarExtender" runat="server" TargetControlID="txt_efffrom">
                        </cc1:CalendarExtender>
                        <cc1:MaskedEditValidator ID="MEV6" runat="server" ControlExtender="MEE6" ControlToValidate="txt_efffrom"
                            Display="Dynamic" InvalidValueMessage="Invalid" IsValidEmpty="true" EmptyValueMessage="*"
                            TooltipMessage="MM/DD/YYYY" Width="114px" >
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
                       <cc1:MaskedEditValidator ID="MEV7" runat="server" ControlExtender="MEE6" ControlToValidate="txt_effto"
                            Display="Dynamic" InvalidValueMessage="Invalid" IsValidEmpty="true" EmptyValueMessage="*"
                            TooltipMessage="MM/DD/YYYY" Width="114px">
                        </cc1:MaskedEditValidator>
                        <cc1:MaskedEditExtender ID="MEE7" runat="server" Mask="99/99/9999" MaskType="Date"
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
                <asp:Panel ID="Panel1" runat="server" BorderStyle="Solid" Height="150px" ScrollBars="Both" Width="750px">
                    <div>
                        <asp:UpdatePanel ID="UpdatePanel22" runat="server">
                            <ContentTemplate>
                                <%--GRID HERE --%>
                                  <asp:GridView ID="grdView" runat="server" AutoGenerateColumns="False"  
                                    onselectedindexchanged="grdView_SelectedIndexChanged" 
                                    DataKeyNames="tran_no" onsorting="grdView_Sorting">                                    
                                    <Columns>                                    
                                        <%--<asp:CommandField ShowSelectButton="True" />--%>
                                        <%--<asp:BoundField DataField="type_code" HeaderText="Type Code"  />--%>
                                         
                                        <asp:ButtonField DataTextField="tran_no" HeaderText="Tran No" CommandName="Select" />                                       
                                        <asp:BoundField HeaderText="Mixing Code" DataField="mixing_code" />
                                        <asp:BoundField HeaderText="Mixing Desc." DataField="mixing_desc" />
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
                       <%-- <asp:LinkButton ID="lbt_apply" runat="server" CssClass="buttonc" Visible="False">APPLY</asp:LinkButton>--%>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td colspan="4" align="center">
                <asp:UpdatePanel ID="UpdatePanel21" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="FMsg1" runat="server" ForeColor="Red" Text="" ></asp:Label>
                        
                        <asp:LinkButton ID ="btnAdd" runat="server" Text="ADD" CssClass="buttonc" onclick="btnAdd_Click" />
                       <asp:LinkButton ID ="btnRefresh" runat="server" Text="Refresh" CssClass="buttonc" onclick="btnRefresh_Click"  /> 
                       <asp:LinkButton ID="btnAuthorize" runat="server" Text="Authorize" CssClass="buttonc"
                            OnClick="btnAuthorize_Click" />
                        <asp:LinkButton ID="btnDelete" runat="server" Text="Delete" CssClass="buttonc" OnClick="btnDelete_Click" />
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
