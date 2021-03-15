<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true"
    CodeFile="Costing_Serial_no_Master.aspx.cs" Inherits="OPS_Costing_Serial_no_Master" %>

<%@ Register Src="FlashMessage.ascx" TagName="FlashMessage" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        .FixedHeader
        {
            position: absolute;
            font-weight: bold;
            vertical-align: text-bottom;
        }
        .style6
        {
            height: 41px;
            width: 138px;
        }
        .style7
        {
            width: 138px;
        }
        .style8
        {
            height: 67px;
            width: 138px;
        }
    </style>
    <table style="width: 88%; height: 264px;">
        <tr>
            <td style="height: 41px;" colspan="2">
                <asp:Label ID="Label1" runat="server" Text="Costing Serial No Master"></asp:Label>
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
            <td colspan="5" class="style6">
            </td>
        </tr>
        <tr>
            <td style="width: 94px">
                <asp:Label ID="Label2" runat="server" CssClass="labelcells" Text="Type Code"></asp:Label>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtTypeCode" runat="server" CssClass="textbox" Width="60px" MaxLength="5"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="width: 51px">
                <asp:Label ID="Label12" runat="server" CssClass="labelcells" Text="Type"></asp:Label>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtType" runat="server" CssClass="textbox" Width="200px" 
                            MaxLength="25"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                &nbsp;</td>
            <td colspan="5" class="style7">
                <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td style="width: 94px; height: 67px;">
                <asp:Label ID="Label3" runat="server" Text="Prefix" CssClass="labelcells" Width="90px"></asp:Label>
            </td>
            <td style="height: 67px">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtPrefix" runat="server" CssClass="textbox" MaxLength="6" Width="60px"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="width: 51px; height: 67px;">
                <asp:Label ID="Label5" runat="server" Text="Suffix" CssClass="labelcells"></asp:Label>
            </td>
            <td style="height: 67px">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtSuffix" runat="server" CssClass="textbox" Width="60px"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="height: 67px">
                &nbsp;</td>
            <td colspan="5" class="style8">
                <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td style="width: 94px">
                <%-- <asp:Label ID="Label4" runat="server" Text="Count Value" CssClass="labelcells"></asp:Label>--%>
                <asp:Label ID="Label14" runat="server" CssClass="labelcells" Text="Eff. From(mm/dd/yyyy)"
                    Width="60px"></asp:Label>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <%-- <asp:TextBox ID="txtCountValue" runat="server" CssClass="textbox" 
                            Width="100px">
                        </asp:TextBox>--%>
                        <asp:TextBox ID="txt_efffrom" runat="server" CssClass="textbox" Width="60px" >
                        </asp:TextBox>
                         <cc1:CalendarExtender ID="txt_efffrom_CalendarExtender" runat="server" TargetControlID="txt_efffrom">
                        </cc1:CalendarExtender>
                        <cc1:MaskedEditValidator ID="MEV6" runat="server" ControlExtender="MEE6" ControlToValidate="txt_efffrom" 
                            Display="Dynamic" InvalidValueMessage="Invalid" IsValidEmpty="true" EmptyValueMessage="*"
                             TooltipMessage="MM/DD/YYYY" Width="114px"  >
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
                <%--<asp:Label ID="Label6" runat="server" Text="Serial No" CssClass="labelcells"></asp:Label>--%>
                <asp:Label ID="Label15" runat="server" CssClass="labelcells" Text="Eff. To(mm/dd/yyyy)"></asp:Label>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                        <%-- <asp:TextBox ID="txtSerialNo" runat="server" CssClass="textbox" 
                            Width="100px">
                        </asp:TextBox>--%>
                        <asp:TextBox ID="txt_effto" runat="server" CssClass="textbox" 
                            Width="60px"></asp:TextBox>
                      <cc1:CalendarExtender ID="txt_effto_CalendarExtender" runat="server" TargetControlID="txt_effto">
                        </cc1:CalendarExtender>
                        <cc1:MaskedEditValidator ID="MEV7" runat="server" ControlExtender="MEE6" ControlToValidate="txt_effto" 
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
            <td>
                &nbsp;</td>
            <td colspan="5" class="style7">
                <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td colspan="10">
                <asp:Panel ID="Panel1" runat="server" BorderStyle="Solid" Height="150px" ScrollBars="Both" Width="750px">
                    <div style="overflow: ">
                        <asp:UpdatePanel ID="UpdatePanel22" runat="server">
                            <ContentTemplate>
                                <%--GRID HERE  --%>
                                <asp:GridView ID="grdView" runat="server" AutoGenerateColumns="False"  
                                    HeaderStyle-CssClass="FixedHeader" OnSelectedIndexChanged="grdView_SelectedIndexChanged"
                                    DataKeyNames="type_code" >
                                    <Columns>
                                        <%--<asp:CommandField ShowSelectButton="True" />--%>
                                        <%--<asp:BoundField DataField="type_code" HeaderText="Type Code"  />--%>
                                        <asp:ButtonField DataTextField="type_code" HeaderText="Type Code" CommandName="Select" />
                                        <asp:BoundField HeaderText="type" DataField="Type" />
                                        <asp:BoundField HeaderText="Prefix" DataField="Prefix" />
                                        <asp:BoundField DataField="count_value" HeaderText="Count value" />
                                        <asp:BoundField HeaderText="Suffix" DataField="suffix" />
                                        <asp:BoundField HeaderText="Effective From" DataField="eff_from" />
                                        <asp:BoundField HeaderText="Effective To" DataField="eff_to" />
                                        <asp:BoundField HeaderText="Status" DataField="Active" />
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
                        <%--<asp:LinkButton ID="lbt_apply" runat="server" CssClass="buttonc" Visible="False">APPLY</asp:LinkButton>--%>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td colspan="4" align="center">
                <asp:UpdatePanel ID="UpdatePanel21" runat="server">
                    <ContentTemplate>
                        <asp:LinkButton ID="btnAdd" runat="server" Text="ADD" CssClass="buttonc" OnClick="btnAdd_Click" />
                        <%-- <asp:Button ID ="btnModify" runat="server" Text="Modify" CssClass="buttonc"  />
                        <asp:Button ID ="btnDelete" runat="server" Text="Delete" CssClass="buttonc"  />--%>
                        <asp:LinkButton ID="btnRefresh" runat="server" Text="Refresh" CssClass="buttonc" OnClick="btnRefresh_Click" />
                        <asp:LinkButton ID="btnAuthorize" runat="server" Text="Authorize" CssClass="buttonc"
                            OnClick="btnAuthorize_Click" />
                        <asp:LinkButton ID="btnDelete" runat="server" Text="Delete" CssClass="buttonc" OnClick="btnDelete_Click" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td colspan="5" class="style7">
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
                       <%-- <uc1:FlashMessage ID="FMsg" runat="server" EnableTheming="true" EnableViewState="true"
                            FadeInDuration="2" FadeInSteps="2" FadeOutDuration="2" FadeOutSteps="2" Visible="true" />--%>
                            <asp:Label ID="FMsg" runat="server" ForeColor="Red" ></asp:Label>
                               
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td colspan="5" class="style7">
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
