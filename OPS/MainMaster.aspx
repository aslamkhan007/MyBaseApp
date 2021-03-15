<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true" CodeFile="MainMaster.aspx.cs" Inherits="OPS_MainMaster" %>
<%@ Register Src="~/FlashMessage.ascx" TagName="flashmessage"
    TagPrefix="uc1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="tableheader" colspan="3">
                <asp:Label ID="Label16" runat="server" Text="Multi Master"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 103px">
                <asp:Label ID="Label21" runat="server" Text="Parent Category"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel13" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlParentCategory" runat="server" CssClass="combobox">
                        </asp:DropDownList>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="GridView1" 
                            EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="lnkSave" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="lnkReset" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="lnkUpdate" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="lnkDelete" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 103px">
                <asp:Label ID="Label17" runat="server" Text="Parameter Code"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtParamCode" runat="server"></asp:TextBox>
                    </ContentTemplate>
                     <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="GridView1" 
                            EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="lnkSave" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="lnkReset" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="lnkUpdate" EventName="Click" />
                           <asp:AsyncPostBackTrigger ControlID="lnkDelete" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 103px">
                <asp:Label ID="Label18" runat="server" Text="Parameter"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtParameter" runat="server"></asp:TextBox>
                    </ContentTemplate>
                     <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="GridView1" 
                            EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="lnkSave" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="lnkReset" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="lnkUpdate" EventName="Click" />
                           <asp:AsyncPostBackTrigger ControlID="lnkDelete" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 103px">
                <asp:Label ID="Label19" runat="server" Text="Description"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel16" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtDescription" runat="server" Height="59px" 
                            TextMode="MultiLine" Width="264px"></asp:TextBox>
                    </ContentTemplate>
                     <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="GridView1" 
                            EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="lnkSave" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="lnkReset" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="lnkUpdate" EventName="Click" />
                           <asp:AsyncPostBackTrigger ControlID="lnkDelete" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="height: 17px; width: 103px">
                <asp:Label ID="Label20" runat="server" Text="Remarks"></asp:Label>
            </td>
            <td class="NormalText" style="height: 17px">
                <asp:UpdatePanel ID="UpdatePanel17" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtRemarks" runat="server" Width="264px"></asp:TextBox>
                    </ContentTemplate>
                     <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="GridView1" 
                            EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="lnkSave" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="lnkReset" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="lnkUpdate" EventName="Click" />
                           <asp:AsyncPostBackTrigger ControlID="lnkDelete" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td class="NormalText" style="height: 17px">
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="3">
                <asp:UpdatePanel ID="UpdatePanel12" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:LinkButton ID="lnkSave" runat="server" CssClass="buttonc" 
                            onclick="lnkSave_Click">Save</asp:LinkButton>
                        <asp:LinkButton ID="lnkReset" runat="server" CssClass="buttonc" 
                            onclick="lnkReset_Click">Reset</asp:LinkButton>
                        <asp:LinkButton ID="lnkUpdate" runat="server" CssClass="buttonc" 
                            Enabled="False" onclick="lnkUpdate_Click">Update</asp:LinkButton>
                        <asp:LinkButton ID="lnkDelete" runat="server" CssClass="buttonc" 
                            onclick="lnkDelete_Click">Delete</asp:LinkButton>
                        <cc1:ConfirmButtonExtender ID="lnkDelete_ConfirmButtonExtender" runat="server" 
                            ConfirmText="Confirm Delete ?" TargetControlID="lnkDelete">
                        </cc1:ConfirmButtonExtender>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="GridView1" 
                            EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="NormalText" colspan="3">
                  <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                <ContentTemplate>
                  <uc1:flashmessage ID="FMsg" runat="server" EnableTheming="true" EnableViewState="true"
                            FadeInDuration="2" FadeInSteps="2" FadeOutDuration="4" FadeOutSteps="2" Visible="true">
                        </uc1:flashmessage>
                </ContentTemplate>
                </asp:UpdatePanel></td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 103px">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
    </table>
    <table style="width:100%;">
        <tr>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel11" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Panel ID="Panel1" runat="server">
                            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                                AutoGenerateColumns="False" CssClass="GridView" DataSourceID="SqlDataSource1" 
                                EmptyDataText="No Data Found" EnableModelValidation="True" 
                                onpageindexchanging="GridView1_PageIndexChanging" 
                                onselectedindexchanged="GridView1_SelectedIndexChanged" PageSize="20" 
                                Width="100%">
                                <Columns>
                                    <asp:CommandField ShowSelectButton="True" />
                                    <asp:BoundField DataField="PARENT_CATEGORY" HeaderText="PARENT_CATEGORY" 
                                        SortExpression="PARENT_CATEGORY" />
                                    <asp:BoundField DataField="PARAMETER_CODE" HeaderText="PARAMETER_CODE" 
                                        SortExpression="PARAMETER_CODE" />
                                    <asp:BoundField DataField="PARAMETER" HeaderText="PARAMETER" 
                                        SortExpression="PARAMETER" />
                                    <asp:BoundField DataField="DESCRIPTION" HeaderText="DESCRIPTION" 
                                        SortExpression="DESCRIPTION" />
                                    <asp:BoundField DataField="REMARKS" HeaderText="REMARKS" 
                                        SortExpression="REMARKS" />
                                </Columns>
                                <EditRowStyle CssClass="EditRowStyle" />
                                <HeaderStyle CssClass="HeaderStyle" />
                                <PagerStyle CssClass="PagerStyle" />
                                <RowStyle CssClass="RowStyle" />
                                <SelectedRowStyle CssClass="SelectedRowStyle" />
                            </asp:GridView>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                                
                                
                                SelectCommand="SELECT [PARENT_CATEGORY], [PARAMETER_CODE], [PARAMETER], [DESCRIPTION], [REMARKS] FROM [jct_ops_multi_master] WHERE ([Status] = @Status) order by Parent_Category">
                                <SelectParameters>
                                    <asp:Parameter DefaultValue="A" Name="Status" Type="String" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </asp:Panel>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="lnkSave" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="lnkReset" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="lnkUpdate" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="lnkDelete" EventName="Click" />
                       
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>

