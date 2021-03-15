<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true" CodeFile="SizingBeamSummary.aspx.cs" Inherits="OPS_SizingBeamSummary" %>


<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="tableheader" colspan="4">
                <asp:Label ID="Label16" runat="server" Text="Sizing Beam Summary"></asp:Label>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                    SelectCommand="MONTH_NAMES" SelectCommandType="StoredProcedure">
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:misjctdev %>" SelectCommand="
    SELECT  DISTINCT mc_type
                FROM    production..szg_check_register_h order by mc_type"></asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                    SelectCommand="jct_ops_szg_beam_summary" SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="radDDLMonth" Name="month" 
                            PropertyName="SelectedValue" Type="Int16" />
                        <asp:ControlParameter ControlID="radDDLYear" Name="year" 
                            PropertyName="SelectedValue" Type="Int16" />
                        <asp:ControlParameter ControlID="radDDLSection" Name="section" 
                            PropertyName="SelectedValue" Type="String" />
                        <asp:ControlParameter ControlID="radDDLStock" Name="stock" 
                            PropertyName="SelectedValue" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 124px">
                <asp:Label ID="Label17" runat="server" Text="Select Month"></asp:Label>
            </td>
            <td class="NormalText">
                
                <telerik:RadDropDownList ID="radDDLMonth" runat="server" 
                    DataSourceID="SqlDataSource1" DataTextField="monthName" 
                    DataValueField="monthNumber" Skin="Sitefinity">
                </telerik:RadDropDownList>
            </td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 124px">
                <asp:Label ID="Label18" runat="server" Text="Select Year"></asp:Label>
            </td>
            <td class="NormalText">
                <telerik:RadDropDownList ID="radDDLYear" runat="server" 
                    DataTextField="monthName" DataValueField="monthNumber" SelectedText="2013" 
                    Skin="Sitefinity">
                    <Items>
                        <telerik:DropDownListItem runat="server" Text="2010" />
                        <telerik:DropDownListItem runat="server" Text="2011" />
                        <telerik:DropDownListItem runat="server" Text="2012" />
                        <telerik:DropDownListItem runat="server" Selected="True" Text="2013" />
                        <telerik:DropDownListItem runat="server" Text="2014" />
                         <telerik:DropDownListItem runat="server" Text="2015" />
                          <telerik:DropDownListItem runat="server" Text="2016" />
                    </Items>
                </telerik:RadDropDownList>
            </td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 124px">
                <asp:Label ID="Label19" runat="server" Text="Section"></asp:Label>
            </td>
            <td class="NormalText">
                <telerik:RadDropDownList ID="radDDLSection" runat="server" 
                    DataSourceID="SqlDataSource2" DataTextField="mc_type" DataValueField="mc_type" 
                    SelectedText="2013" Skin="Sitefinity" AppendDataBoundItems="True">
                    <Items>
                        <telerik:DropDownListItem runat="server" DropDownList="radDDLSection" 
                            Text="ALL" />
                    </Items>
                </telerik:RadDropDownList>
            </td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 124px">
                <asp:Label ID="Label20" runat="server" Text="Stock"></asp:Label>
            </td>
            <td class="NormalText">
                <telerik:RadDropDownList ID="radDDLStock" runat="server" 
                    DataTextField="mc_type" DataValueField="mc_type" SelectedText="ALL" 
                    Skin="Sitefinity">
                    <Items>
                        <telerik:DropDownListItem runat="server" DropDownList="radDDLStock" 
                            Selected="True" Text="ALL" />
                        <telerik:DropDownListItem runat="server" DropDownList="radDDLStock" 
                            Text="STOCK" />
                    </Items>
                </telerik:RadDropDownList>
            </td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <telerik:RadButton ID="radFetch" runat="server" Skin="Sitefinity" Text="Fetch" 
                            onclick="radFetch_Click">
                        </telerik:RadButton>
                        <telerik:RadButton ID="radReset" runat="server" Skin="Sitefinity" Text="Reset" 
                            onclick="radReset_Click">
                        </telerik:RadButton>
                           <telerik:RadButton ID="radExcel" runat="server" onclick="radExcel_Click" 
                            Skin="Sitefinity" Text="Excel">
                        </telerik:RadButton>
                    </ContentTemplate>

                    <Triggers>
                        <asp:PostBackTrigger ControlID="radExcel" />
                    </Triggers>

                </asp:UpdatePanel>
             
            </td>
        </tr>
        <tr>
            <td class="NormalText" colspan="4">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="100">
                    <ProgressTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Image/load.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
        </tr>
        </table>
    <table style="width:100%;">
        <tr>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Panel ID="Panel1" runat="server" Width="1000px" ScrollBars="Horizontal" Visible="false">
                            <telerik:RadGrid ID="RadGrid1" runat="server" 
                                AllowPaging="True" CellSpacing="0" GridLines="None" 
                                Width="100%" onpageindexchanged="RadGrid1_PageIndexChanged" 
                                onprerender="RadGrid1_PreRender" 
onneeddatasource="RadGrid1_NeedDataSource" 
                                onpagesizechanged="RadGrid1_PageSizeChanged">
                                <ClientSettings>
                                    <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                                </ClientSettings>
                                <MasterTableView>
                                    <CommandItemSettings ExportToPdfText="Export to PDF" />
                                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" 
                                        Visible="True">
                                        <HeaderStyle Width="20px" />
                                    </RowIndicatorColumn>
                                    <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" 
                                        Visible="True">
                                        <HeaderStyle Width="20px" />
                                    </ExpandCollapseColumn>
                                    <EditFormSettings>
                                        <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                        </EditColumn>
                                    </EditFormSettings>
                                    <PagerStyle PageSizeControlType="RadComboBox" />
                                </MasterTableView>
                                <PagerStyle PageSizeControlType="RadComboBox" />
                                <FilterMenu EnableImageSprites="False">
                                </FilterMenu>
                            </telerik:RadGrid>
                        </asp:Panel>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="radFetch" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        </table>
</asp:Content>

