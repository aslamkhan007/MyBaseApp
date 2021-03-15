<%@ Page Title="" Language="VB" MasterPageFile="~/OPS/MasterPage.master"  AutoEventWireup="false" CodeFile="HoldOrder.aspx.vb" Inherits="OPS_HoldOrder" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <%--</tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                                               
                                                </td>--%>
    <table style="width:100%;">
        <tr>
            <td class="tableheader" colspan="4">
                Hold Orders</td>
        </tr>
        <tr>
            <td width="100px">
                Order No</td>
            <td width="100px" style="width: 120px">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtOrderNo" runat="server" AutoPostBack="True" 
                            CssClass="textbox"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                <ProgressTemplate>
                <asp:Image ID="ImageProg" runat="server" ImageUrl="~/OPS/Image/loadingNew.gif" />
                </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
            <td colspan="2" rowspan="8" valign="top">
                    
                <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="GridView1" runat="server" Width="95%">
                            <HeaderStyle CssClass="GridHeader" />
                            <RowStyle CssClass="GridItem" />
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
                    
                </td>
        </tr>
        <tr>
            <td width="100px">
                SalePerson</td>
            <td width="100px" style="width: 120px">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblSalePerson" runat="server"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td width="100px">
                Customer</td>
            <td width="100px" style="width: 220px">
                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblCustomerName" runat="server" Width="200px"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td width="100px" valign="top">
                Line
                Item</td>
            <td width="100px" style="width: 120px">
                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlItems" runat="server" AutoPostBack="True" 
                            CssClass="combobox">
                        </asp:DropDownList>
                        <asp:Label ID="lblSort" runat="server" Text="."></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td width="100px" valign="top">
                Shade</td>
            <td width="100px" style="width: 120px">
                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblLineNo" runat="server"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td width="100px" valign="top">
                Hold Quantity</td>
            <td width="100px" style="width: 120px">
                <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtHoldMeters" runat="server" CssClass="textbox" 
                            ValidationGroup="ValidGrpSaveDetail"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="txtHoldMeters_FilteredTextBoxExtender" 
                            runat="server" Enabled="True" FilterType="Numbers" 
                            TargetControlID="txtHoldMeters" ValidChars="0123456789">
                        </cc1:FilteredTextBoxExtender>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ErrorMessage="*" ControlToValidate="txtHoldMeters" Display="Dynamic" 
                            SetFocusOnError="True" ValidationGroup="ValidGrpSaveDetail"></asp:RequiredFieldValidator>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td width="100px" style="vertical-align: top">
                <asp:Label ID="Label3" runat="server" Text="Hold / Release"></asp:Label>
            </td>
            <td width="100px" style="width: 120px">
                <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlHoldBy" runat="server" CssClass="combobox" 
                            Width="201px">
                            <asp:ListItem>Processing</asp:ListItem>
                            <asp:ListItem>Marketing</asp:ListItem>
                            <asp:ListItem>Planning</asp:ListItem>
                            <asp:ListItem>Quality Assurance</asp:ListItem>
                            <asp:ListItem>WareHouse</asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td width="100px">
                <asp:Label ID="Label2" runat="server" Text="Reason"></asp:Label>
            </td>
            <td width="100px" style="width: 120px">
                <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtReason" runat="server" CssClass="textbox"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="txtReason" ValidationGroup="ValidGrpSaveDetail" ></asp:RequiredFieldValidator>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Hold At"></asp:Label>
            </td>
            <td style="width: 120px">
                <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="DdlHOldAt" runat="server" CssClass="combobox" 
                            Width="201px">
                            <asp:ListItem>After Greigh</asp:ListItem>
                            <asp:ListItem>Before Dyeing</asp:ListItem>
                            <asp:ListItem>After Dyeing</asp:ListItem>
                            <asp:ListItem>Before Finishing</asp:ListItem>
                            <asp:ListItem>Before Packing</asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                Hold State</td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlHoldState" runat="server" AutoPostBack="True" 
                            CssClass="combobox">
                            <asp:ListItem>Definite</asp:ListItem>
                            <asp:ListItem>Indefinite</asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
                
                                                </td>
        <%--</tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                                               
                                                </td>--%>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Hold  Till Date"></asp:Label>
            </td>
            <td style="width: 120px">
                <asp:UpdatePanel ID="UpdatePanel12" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                <asp:TextBox ID="txtDate" runat="server" CssClass="textbox" Width="65px"
                MaxLength="15" TabIndex="28" ValidationGroup="ValidGrpSaveDetail"></asp:TextBox>
                                                   
                                                   
                                                 <cc1:CalendarExtender ID="CalEfffr" runat="server" Animated="False" Format="MM/dd/yyyy"
                                                   TargetControlID="txtDate">
                                                </cc1:CalendarExtender>
                                                <cc1:MaskedEditExtender ID="MEE6" runat="server" Mask="99/99/9999" MaskType="Date"
                                                    TargetControlID="txtDate">
                                                </cc1:MaskedEditExtender> 
                                                <cc1:MaskedEditValidator ID="MEV6" runat="server" ControlExtender="MEE6" ControlToValidate="txtDate"
                                                    ValidationGroup="ValidGrpSaveDetail" Display="Dynamic" InvalidValueMessage="Invalid" IsValidEmpty="False" EmptyValueMessage="*"
                                                    TooltipMessage="MM/DD/YYYY" Width="114px">
                                                </cc1:MaskedEditValidator>
                </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlHoldState" 
                            EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
                
            </td>
            <td>
                <asp:Label ID="Label5" runat="server" Text="Plant"></asp:Label>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel16" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlPlant" runat="server" CssClass="combobox">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem>Cotton</asp:ListItem>
                            <asp:ListItem>Taffeta</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                            ControlToValidate="ddlPlant" Display="Dynamic" ErrorMessage="*" 
                            SetFocusOnError="True"></asp:RequiredFieldValidator>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="tableback" colspan="4" style="text-align: center" >
                <asp:LinkButton ID="CmdHold" runat="server" CssClass="buttonc" 
                    ValidationGroup="ValidGrpSaveDetail">Hold</asp:LinkButton>
            &nbsp;
                <asp:LinkButton ID="CmdRelease" runat="server" CssClass="buttonc" 
                    ValidationGroup="ValidGrpSaveDetail">Release</asp:LinkButton>
            &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="4" class="tableheader"
                Hold Ordersspan="4">
                <asp:Panel ID="Panel1" runat="server" Height="200px" ScrollBars="Both" 
                    Width="100%">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="GrdSavedOrders" runat="server" EnableModelValidation="True" 
                                DataSourceID="SqlDataSource1" Width="98%">
                                <Columns>
                                    <asp:CommandField ShowSelectButton="True" />
                                </Columns>
                            <HeaderStyle CssClass="GridHeader" />
                            <SelectedRowStyle CssClass="GridRowGreen" />
                        <RowStyle CssClass="GridItem" />
                            </asp:GridView>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:jctdevConnectionString %>" 
                                SelectCommand="SELECT UPPER(OrderNo) AS OrderNo,Item,LINEItem,Shade,Stage,HoldBy AS HeldBy, convert(varchar(10),HoldTillDate,101) as HoldTillDate,convert(varchar(10),HoldDate,101)  AS HeldOn,Reason,b.empname AS HoldRequestBy FROM Jct_Ops_Hold_Orders a,dbo.JCT_EmpMast_Base b WHERE a.UserCode=b.empcode AND b.Active='Y' AND HoldFlag='T' AND ReleaseFlag IS NULL">
                            </asp:SqlDataSource>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="tableheader" colspan="4">
                Release Orders</td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:Panel ID="Panel2" runat="server" Height="200px" Width="100%">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="GrdSavedOrders0" runat="server" DataSourceID="SqlDataSource2" 
                                EnableModelValidation="True" Width="98%">
                            <HeaderStyle CssClass="GridHeader" />
                        <RowStyle CssClass="GridItem" />
                            </asp:GridView>
                            <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:jctdevConnectionString %>" 
                                SelectCommand="SELECT UPPER(OrderNo) AS OrderNo,Item,LINEItem,Shade,Stage,b.empname AS ReleasedBy,ReleasedOn FROM Jct_Ops_Hold_Orders a,dbo.JCT_EmpMast_Base b WHERE a.UserCode=b.empcode AND b.Active='Y' AND HoldFlag='F' AND ReleaseFlag='T'">
                                
                            </asp:SqlDataSource>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </asp:Panel>
            </td>
        </tr>
        <tr style="display:none">
            <td>
                <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                <ContentTemplate>
                    <asp:Button ID="BtnFetch" runat="server"  CausesValidation="false"  Text="Button" OnClick="BtnFetch_Click" />
                </ContentTemplate>
                </asp:UpdatePanel></td>
                
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>


