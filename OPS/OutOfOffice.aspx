﻿<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true" CodeFile="OutOfOffice.aspx.cs" Inherits="OPS_OutOfOffice" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="tableheader" colspan="5">
                <asp:Label ID="Label20" runat="server" Text="Out of Office "></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 105px">
                <asp:Label ID="Label16" runat="server" Text="From Date"></asp:Label>
            </td>
            <td class="NormalText" style="width: 104px">
                <asp:TextBox ID="txtDateFrom" runat="server" CssClass="textbox"></asp:TextBox>
                 <cc1:CalendarExtender ID="txtDateFrom_CalendarExtender" runat="server" 
                    TargetControlID="txtDateFrom">
                </cc1:CalendarExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtDateFrom" Display="Dynamic" 
                    ErrorMessage="** RequiredField"></asp:RequiredFieldValidator>
            </td>
            <td class="NormalText" style="width: 70px">
                <asp:Label ID="Label17" runat="server" Text="To Date"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtDateTo" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txtDateTo_CalendarExtender" runat="server" 
                    TargetControlID="txtDateTo">
                </cc1:CalendarExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtDateTo" Display="Dynamic" ErrorMessage="** RequiredField"></asp:RequiredFieldValidator>
            </td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 105px">
                <asp:Label ID="Label22" runat="server" Text="Concerned Person"></asp:Label>
            </td>
            <td class="NormalText" colspan="3">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtEmployee" runat="server" CssClass="textbox" Width="200px" 
                            AutoPostBack="True" ontextchanged="txtEmployee_TextChanged"></asp:TextBox>
                              <div id="div1" style="display:none;">   
                                        <cc1:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server" 
                                            CompletionInterval="10" CompletionListCssClass="AutoExtender" 
                                            CompletionListElementID="div1" 
                                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight" 
                                            CompletionListItemCssClass="AutoExtenderList" CompletionSetCount="20" 
                                            MinimumPrefixLength="1" ServiceMethod="GetEmployee_OPS" 
                                            ServicePath="~/WebService.asmx" TargetControlID="txtEmployee">
                                        </cc1:AutoCompleteExtender>
                                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 105px">
                <asp:Label ID="Label19" runat="server" Text="Select Plant"></asp:Label>
            </td>
            <td class="NormalText" style="width: 104px">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlPlant" runat="server" AutoPostBack="True" 
                            CssClass="combobox">
                            <asp:ListItem>All</asp:ListItem>
                            <asp:ListItem>Cotton</asp:ListItem>
                            <asp:ListItem>Taffeta</asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="NormalText" style="width: 70px">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 105px">
                <asp:Label ID="Label18" runat="server" Text="Select Area"></asp:Label>
            </td>
            <td class="NormalText" colspan="2">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:CheckBoxList ID="chbArea" runat="server" DataSourceID="SqlDataSource1" DataTextField="AreaName" 
                    DataValueField="AreaCode" AppendDataBoundItems="True" AutoPostBack="True" 
                        onselectedindexchanged="chbArea_SelectedIndexChanged" RepeatColumns="2" 
                        RepeatDirection="Horizontal">
                     <asp:ListItem>All</asp:ListItem>
                    </asp:CheckBoxList>
                 
                  <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:misjctdev %>"
                            SelectCommand="SELECT AreaName,AreaCode FROM Jct_Ops_SanctioNote_Area_Master WHERE STATUS='A' AND AreaCode NOT IN (1005,1006,1013,1025,1015,1018,1019,1020,1021,1022,1024,1023,1026,1027) ORDER BY AreaName ASC">
                        </asp:SqlDataSource>
                      

                </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlPlant" 
                            EventName="SelectedIndexChanged" />
                              <asp:AsyncPostBackTrigger ControlID="chbArea" 
                            EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 105px">
                <asp:Label ID="Label21" runat="server" Text="Remarks"></asp:Label>
            </td>
            <td class="NormalText" colspan="3">
                <asp:TextBox ID="txtRemarks" runat="server" CssClass="textbox" Height="50px" 
                    MaxLength="500" TextMode="MultiLine" Width="200px"></asp:TextBox>
            </td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="5">
                
                        <asp:LinkButton ID="lnkApply" runat="server" CssClass="buttonc" 
                            onclick="lnkApply_Click">Apply</asp:LinkButton>
                        <asp:LinkButton ID="lnkReset" runat="server" CssClass="buttonc">Reset</asp:LinkButton>
                  
            </td>
        </tr>
        </table>
    
    
        <asp:Panel ID="Panel1" runat="server">

            <asp:GridView ID="grd" runat="server" 
                EnableModelValidation="True" Width="1005px" 
                onselectedindexchanged="grd_SelectedIndexChanged" >
                <AlternatingRowStyle CssClass="GridAI" />
               
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                </Columns>
               
                <HeaderStyle CssClass="GridHeader" />
                <PagerStyle CssClass="PagerStyle" />
                <RowStyle CssClass="GridItem" />
            </asp:GridView>

               <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                    
                 SelectCommand="SELECT [SrNo], [UserCode], Convert(varchar,[DateFrom],103) as DateFrom, Convert(varchar,[DateTo],103) as DateTo, [STATUS], [REMARKS] FROM [JCT_OPS_SANCTIONNOTE_OUT_OF_OFFICE] WHERE ([STATUS] = @STATUS) AND ([EntryBy] = @UserCode)">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="A" Name="STATUS" Type="String" />
                        <asp:SessionParameter DefaultValue="" Name="UserCode" SessionField="EmpCode" 
                            Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>


        </asp:Panel>

   
</asp:Content>

