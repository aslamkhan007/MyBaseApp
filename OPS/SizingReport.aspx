<%@ Page Title="Sizing Report" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true" CodeFile="SizingReport.aspx.cs" Inherits="OPS_SizingReport" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="tableheader" colspan="4">
                <asp:Label ID="Label16" runat="server" Text="Sizing Report"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 66px">
                <asp:Label ID="Label17" runat="server" Text="Date From"></asp:Label>
            </td>
            <td class="NormalText" style="width: 212px">
                <asp:TextBox ID="txtDateFrom" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txtDateFrom_CalendarExtender" runat="server" 
                    TargetControlID="txtDateFrom">
                </cc1:CalendarExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtDateFrom" Display="Dynamic" ErrorMessage="**" 
                    ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
            <td class="NormalText" style="width: 85px">
                <asp:Label ID="Label18" runat="server" Text="Date To"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtDateTo" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txtDateTo_CalendarExtender" runat="server" 
                    TargetControlID="txtDateTo">
                </cc1:CalendarExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtDateTo" Display="Dynamic" ErrorMessage="**" 
                    ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 66px">
                <asp:Label ID="Label19" runat="server" Text="Sort No"></asp:Label>
            </td>
            <td class="NormalText" style="width: 212px">
                <asp:TextBox ID="txtSortNo" runat="server" CssClass="textbox" Columns="10" 
                    MaxLength="10"></asp:TextBox>
            </td>
            <td class="NormalText" style="width: 85px">
                <asp:Label ID="Label20" runat="server" Text="Order No"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtOrderNo" runat="server" CssClass="textbox" Columns="20" 
                    MaxLength="20"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 66px">
                <asp:Label ID="Label21" runat="server" Text="Issue No"></asp:Label>
            </td>
            <td class="NormalText" style="width: 212px">
                <asp:TextBox ID="txtIssueNo" runat="server" CssClass="textbox" Columns="15" 
                    MaxLength="15"></asp:TextBox>
            </td>
            <td class="NormalText" style="width: 85px">
                <asp:Label ID="Label22" runat="server" Text="Beam No"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtBeamNo" runat="server" CssClass="textbox" Columns="5" 
                    MaxLength="5"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 66px">
                <asp:Label ID="Label23" runat="server" Text="Type"></asp:Label>
            </td>
            <td class="NormalText" style="width: 212px">
                <asp:DropDownList ID="ddlType" runat="server" CssClass="combobox">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>S</asp:ListItem>
                    <asp:ListItem>D</asp:ListItem>
                    <asp:ListItem>H</asp:ListItem>
                    <asp:ListItem>F</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="NormalText" style="width: 85px">
                <asp:Label ID="Label24" runat="server" Text="Shed"></asp:Label>
            </td>
            <td class="NormalText">
                 <asp:DropDownList ID="ddlShed" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                            CssClass="combobox" DataSourceID="SqlDataSource1" DataTextField="PARAMETER" DataValueField="PARAMETER_CODE">
                            <asp:ListItem></asp:ListItem>
                        </asp:DropDownList>
                  <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:misjctdev %>"
                            SelectCommand="SELECT [PARAMETER_CODE], [PARAMETER] FROM [jct_ops_multi_master] WHERE (([Status] = @Status) AND ([PARENT_CATEGORY] = @PARENT_CATEGORY)) ORDER BY [PARAMETER]">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="A" Name="Status" Type="String" />
                                <asp:Parameter DefaultValue="WeavingShed" Name="PARENT_CATEGORY" 
                                    Type="String" />
                            </SelectParameters>
                        </asp:SqlDataSource>
            </td>
        </tr>
    </table>
    <table style="width:100%;">
        <tr>
            <td class="buttonbackbar">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" RenderMode="Inline">
                    <ContentTemplate>
                        <asp:LinkButton ID="lnkFetch" runat="server" CssClass="buttonc" 
                            onclick="lnkFetch_Click" ValidationGroup="A">Fetch</asp:LinkButton>
                        <asp:LinkButton ID="lnkReset" runat="server" CssClass="buttonc" 
                            onclick="lnkReset_Click">Reset</asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:LinkButton ID="lnkExcel" runat="server" CssClass="buttonc" 
                    onclick="lnkExcel_Click">Excel</asp:LinkButton>
            </td>
        </tr>
    </table>
    <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" 
        runat="server" DisplayAfter="100">
    <ProgressTemplate>
        <asp:Image ID="Image1" runat="server" ImageUrl="~/Image/load.gif" />
    </ProgressTemplate>
    </asp:UpdateProgress>
    <table style="width:100%;">
        <tr>
            <td class="NormalText">
              <div runat="server" id="Div" class="container" style="width: 100%; height: 198px;">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                          <asp:GridView ID="grdSizing" runat="server" Width="100%" 
                            EnableModelValidation="True" onrowcommand="grdSizing_RowCommand" 
                                onrowdatabound="grdSizing_RowDataBound" ShowFooter="True">
                            <AlternatingRowStyle CssClass="GridAI" />
                            <Columns>
                                <asp:TemplateField HeaderText="Select">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkSelect" runat="server" CommandName="Select">Select</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <HeaderStyle CssClass="GridHeader" />
                            <RowStyle CssClass="GridItem" />
                            <SelectedRowStyle CssClass="SelectedRowStyle" />
                        </asp:GridView>
                        
                      
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="lnkFetch" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
                </div>
            </td>
        </tr>
        </table>
    <table style="width:100%;">
        <tr>
            <td class="NormalText" colspan="4">
               <div runat="server" id="Div1" class="container" style="width: 100%; height: 198px;">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                 
                     
                            <asp:GridView ID="grdSizingDetail" runat="server" Width="100%" 
                                onrowdatabound="grdSizingDetail_RowDataBound" ShowFooter="True">
                            <AlternatingRowStyle CssClass="GridAI" />
                            <HeaderStyle CssClass="GridHeader" />
                            <RowStyle CssClass="GridItem" />
                            <SelectedRowStyle CssClass="SelectedRowStyle" />
                        </asp:GridView>
                     
                    
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="grdSizing" EventName="RowCommand" />
                        <asp:AsyncPostBackTrigger ControlID="lnkFetch" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
                </div>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 124px">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 124px">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

