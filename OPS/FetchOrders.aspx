<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true" CodeFile="FetchOrders.aspx.cs" Inherits="OPS_FetchOrders" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%;">
        <tr>
            <td class="tableheader" colspan="4">
                <asp:Label ID="Label16" runat="server" Text="Fetch Orders "></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 127px">
                <asp:Label ID="Label17" runat="server" Text="DateFrom"></asp:Label>
            </td>
            <td class="NormalText" style="width: 128px">
                <asp:TextBox ID="txtDateFrom" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txtDateFrom_CalendarExtender" runat="server" 
                    TargetControlID="txtDateFrom">
                </cc1:CalendarExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtDateFrom" Display="Dynamic" ErrorMessage="**"></asp:RequiredFieldValidator>
            </td>
            <td class="NormalText" style="width: 82px">
                <asp:Label ID="Label18" runat="server" Text="DateTo"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtDateTo" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txtDateTo_CalendarExtender" runat="server" 
                    TargetControlID="txtDateTo">
                </cc1:CalendarExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtDateTo" Display="Dynamic" ErrorMessage="**"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 127px">
                <asp:Label ID="Label19" runat="server" Text="Select Year"></asp:Label>
            </td>
            <td class="NormalText" style="width: 128px">
                <asp:DropDownList ID="ddlYear" runat="server" CssClass="combobox">
                    <asp:ListItem>2013</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="NormalText" style="width: 82px">
                <asp:Label ID="Label20" runat="server" Text="Select Month"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:DropDownList ID="ddlMonth" runat="server" CssClass="combobox">
                    <asp:ListItem Value="01">January</asp:ListItem>
                    <asp:ListItem Value="02">February</asp:ListItem>
                    <asp:ListItem Value="03">March</asp:ListItem>
                    <asp:ListItem Value="04">April</asp:ListItem>
                    <asp:ListItem Value="05">May</asp:ListItem>
                    <asp:ListItem Value="06">June</asp:ListItem>
                    <asp:ListItem Value="07">July</asp:ListItem>
                    <asp:ListItem Value="08">August</asp:ListItem>
                    <asp:ListItem Value="09">September</asp:ListItem>
                    <asp:ListItem Value="10">October</asp:ListItem>
                    <asp:ListItem Value="11">November</asp:ListItem>
                    <asp:ListItem Value="12">December</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 127px">
                <asp:Label ID="Label24" runat="server" Text="Select Plant"></asp:Label>
            </td>
            <td class="NormalText" style="width: 128px">
                <asp:DropDownList ID="ddlPlant" runat="server" CssClass="combobox">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Cotton</asp:ListItem>
                    <asp:ListItem>Taffeta</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="NormalText" style="width: 82px">
                <asp:Label ID="Label25" runat="server" Text="Sort No"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtSortNo" runat="server" Columns="10" CssClass="textbox" 
                    MaxLength="10"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 127px">
                <asp:Label ID="Label23" runat="server" Text="Order No"></asp:Label>
            </td>
            <td class="NormalText" style="width: 128px">
                <asp:TextBox ID="txtOrderNo" runat="server" Columns="20" CssClass="textbox" MaxLength="20"></asp:TextBox>
            </td>
            <td class="NormalText" style="width: 82px">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:LinkButton ID="lnkFetch" runat="server" CssClass="buttonc" 
                            onclick="lnkFetch_Click">Fetch</asp:LinkButton>
                        <asp:LinkButton ID="lnkAdd" runat="server" CssClass="buttonc" 
                            onclick="lnkAdd_Click">Add</asp:LinkButton>
                        <asp:LinkButton ID="lnkReset" runat="server" CssClass="buttonc">Reset</asp:LinkButton>
                    </ContentTemplate>
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
    <table style="width: 100%;">
    <tr>
    <td class="NormalText">
    <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                           <asp:Panel ID="pnlOption" runat="server" CssClass="panelbg"  style="float:left;" Visible="False" >
                     <asp:CheckBoxList ID="chbOption" runat="server" RepeatDirection="Horizontal"  
                                   AutoPostBack="True" onselectedindexchanged="chbOption_SelectedIndexChanged">
                         <asp:ListItem Selected="True">OrderNo</asp:ListItem>
                         <asp:ListItem Selected="True">Items</asp:ListItem>
                     </asp:CheckBoxList>
                     </asp:Panel>
                     </ContentTemplate>
                     </asp:UpdatePanel>
    </td>
    </tr>
        <tr>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                    
                        <asp:Panel ID="pnlOrders" runat="server" CssClass="panelbg" Height="200px"  style="float:left;"
                            ScrollBars="Vertical" Visible="False" Width="150px">
                            <asp:CheckBoxList ID="chbOrderList" runat="server" 
                                DataSourceID="SqlDataSource1" DataTextField="order_no" 
                                DataValueField="order_no" 
                                onselectedindexchanged="chbOrderList_SelectedIndexChanged">
                            </asp:CheckBoxList>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                                SelectCommand="JCT_OPS_FETCH_SaleOrders" SelectCommandType="StoredProcedure">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="txtDateFrom" Name="DATEFROM" 
                                        PropertyName="Text" Type="String" />
                                    <asp:ControlParameter ControlID="txtDateTo" Name="DATETO" PropertyName="Text" 
                                        Type="String" />
                                    <asp:ControlParameter ControlID="txtOrderNo" DefaultValue=" " Name="orderno" 
                                        PropertyName="Text" Type="String" />
                                         <asp:ControlParameter ControlID="txtSortNo" DefaultValue=" " Name="SortNo" 
                                        PropertyName="Text" Type="String" />
                                         <asp:ControlParameter ControlID="ddlPlant" DefaultValue=" " Name="Plant" 
                                        PropertyName="Text" Type="String" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                              </asp:Panel>
                              </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="lnkFetch" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="lnkAdd" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
                  <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                      
                        <asp:Panel ID="pnlItems" runat="server"  CssClass="panelbg" Height="200px"  style="float:left;"
                            ScrollBars="Vertical" Visible="False" Width="300px">
                             <asp:CheckBoxList ID="chbItems" runat="server" DataSourceID="SqlDataSource2" 
                                 DataTextField="Items" DataValueField="Items" >
                            </asp:CheckBoxList>
                             <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                                 ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                                 SelectCommand="JCT_OPS_FETCH_SALEORDERS_LINEITEM" 
                                 SelectCommandType="StoredProcedure">
                                 <SelectParameters>
                                     <asp:ControlParameter ControlID="chbOrderList" Name="ORDERNO" 
                                         PropertyName="SelectedValue" Type="String" />
                                 </SelectParameters>
                             </asp:SqlDataSource>
                        </asp:Panel>
                       </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="chbOrderList" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="lnkAdd" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>

