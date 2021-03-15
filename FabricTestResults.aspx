<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="FabricTestResults.aspx.vb" Inherits="FabricTestResults" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="NormalText" cellpadding="0" cellspacing="0" style="width: 100%; height: 37px;"
        __designer:mapid="b6" frame="void">
        <tr __designer:mapid="b7">
            <td rowspan="4" style="background-position: right -4px; width: 24px; background-image: url('Image/Frame/Frame_Left.png');
                background-repeat: no-repeat;" __designer:mapid="b8">
                &nbsp;
            </td>
            <td style="background-position: 0px -4px; background-image: url('Image/Frame/Frame_Vertical_Back.png');
                height: 37px; font-size: 3pt;" valign="middle" __designer:mapid="b9">
                <br __designer:mapid="ba" />
                <asp:ScriptManager ID="ScriptManager1" runat="server" EnableHistory="True" LoadScriptsBeforeUI="False">
                </asp:ScriptManager>
                <asp:Label ID="Label7" runat="server" Style="font-family: 'Trebuchet MS'; font-size: small;
                    font-weight: 700;" Text="Fabric Test Report"></asp:Label>
            </td>
            <td rowspan="4" style="background-image: url('Image/Frame/Frame_Right.png'); background-repeat: no-repeat;
                background-position: left -4px; width: 24px;">
                &nbsp;
            </td>
        </tr>
    </table>
    <table cellpadding="0" cellspacing="0" style="width: 100%; height: 400px;">
        <tr>
            <td style="background-position: right bottom; background-image: url('Image/Background/Left%20Shadow.png');
                background-repeat: repeat-y; width: 12px; height: 510px;">
            </td>
            <td style="vertical-align: top; text-align: left; height: 510px;">
                <table style="width: 100%;" class="tableback">
                    <tr>
                        <td class="labelcells" width="150px">
                            <asp:Label ID="Label8" runat="server" Text="Sort No"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtSortNo" runat="server" CssClass="textbox" AutoPostBack="True"
                                CausesValidation="True" Width="63px"></asp:TextBox>
                            &nbsp;</td>
                        <td class="labelcells" width="150px">
                            <asp:Label ID="Label22" runat="server" Text="Finish"></asp:Label>
                        </td>
                        <td>
                            <asp:UpdatePanel ID="UpdatePanel7" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlFinish" runat="server" CssClass="combobox">
                                    </asp:DropDownList>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="txtSortNo" EventName="TextChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td class="labelcells" width="150px">
                            <asp:Label ID="Label23" runat="server" Text="Customer"></asp:Label>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td class="labelcells" width="150px">
                            <asp:Label ID="Label21" runat="server" Text="Doc Date"></asp:Label>
                        </td>
                        <td>
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional" 
                                RenderMode="Inline">
                                <ContentTemplate>
                                    <asp:TextBox ID="txtDate" runat="server" CssClass="textbox" Width="87px"></asp:TextBox>
                                    <cc1:CalendarExtender ID="txtDate_CalendarExtender" runat="server" 
                                        TargetControlID="txtDate">
                                    </cc1:CalendarExtender>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="txtSortNo" EventName="TextChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td class="labelcells" width="150px">
                            <asp:Label ID="Label24" runat="server" Text="Order No"></asp:Label>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td class="labelcells" width="150px">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    </table>
                <table style="width: 100%;" cellpadding="0" cellspacing="0">
                    <tr>
                        <td atomicselection="False" style="text-align: center" class="buttonbackbar">
                            <asp:LinkButton ID="cmdView" runat="server" CssClass="buttonc">View</asp:LinkButton>
                        </td>
                    </tr>
                </table>
                <table style="width: 100%;" class="tableback">
                    <tr>
                        <td class="labelcells">
                            <asp:Label ID="Label20" runat="server" Style="font-family: 'Trebuchet MS'; font-size: small;
                                font-weight: 700;" Text="Standard Vs Actual"></asp:Label>
                            </td>
                    </tr>
                    <tr>
                        <td class="labelcells">
                            <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                <ProgressTemplate>
                                    <div style="text-align: center; font-family: 'trebuchet MS'; font-size: 13px; font-weight: bold;">
                                        &nbsp; Please Wait <asp:Image ID="Image1" runat="server" ImageUrl="~/Image/loading.gif" />
                                        </div>
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                            </td>
                    </tr>
                    </table>
                <table style="width: 100%; display: none;" class="tableback">
                    <tr>
                        <td class="labelcells">
                            <asp:Label ID="Label14" runat="server">EPI</asp:Label>
                        </td>
                        <td>
                            <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:TextBox ID="txtEPI" runat="server" CssClass="textbox" ReadOnly="True" Enabled="False"></asp:TextBox>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="cmdView" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                        <td class="labelcells">
                            <asp:Label ID="Label17" runat="server">Weight</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtWeight" runat="server" CssClass="textbox" ReadOnly="True" Enabled="False"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="labelcells">
                            <asp:Label ID="Label15" runat="server">PPI</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtPPI" runat="server" CssClass="textbox" ReadOnly="True" Enabled="False"></asp:TextBox>
                        </td>
                        <td class="labelcells">
                            <asp:Label ID="Label18" runat="server">Width</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtWidth" runat="server" CssClass="textbox" ReadOnly="True" Enabled="False"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <table class="tableback" style="width: 100%;">
                    <tr>
                        <td style="font-family: 'Trebuchet MS'; font-size: 14px;">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>                                
                                    <asp:DataList ID="DataList1" runat="server" Width="100%">
                                        <ItemTemplate>
                                            <div>
                                                <asp:ImageButton ID="ImageButton1" runat="server" />
                                                Sort No:
                                                <asp:Label ID="lblSortNo" runat="server" Text='<%# Eval("Item_Code") %>'></asp:Label>
                                                &nbsp;Finish:
                                                <asp:Label ID="lblFinish" runat="server" Text='<%# Eval("Finish") %>'></asp:Label>
                                            </div>
                                            <asp:Panel ID="Panel1" runat="server" Height="295px">
                                                <asp:GridView ID="grdMerged" runat="server" Width="100%">
                                                    <EmptyDataTemplate>
                                                        <span style="font-family: 'Tahoma'; size: 8pt;">No Data Available</span>
                                                    </EmptyDataTemplate>
                                                    <HeaderStyle CssClass="GridHeader" Font-Bold="True" Font-Names="tahoma" 
                                                        Font-Size="8pt" Height="23px" />
                                                    <RowStyle CssClass="GridItem" />
                                                </asp:GridView>                                                
                                                <asp:GridView ID="grdResults" runat="server" Visible="False" Width="100%">
                                                    <EmptyDataTemplate>
                                                        <span style="font-family: 'Tahoma'; size: 8pt;">No Data Available</span>
                                                    </EmptyDataTemplate>
                                                    <HeaderStyle CssClass="GridHeader" Font-Bold="True" Font-Names="tahoma" 
                                                        Font-Size="8pt" Height="23px" />
                                                    <RowStyle CssClass="GridItem" />
                                                </asp:GridView>
                                            </asp:Panel>
                                            <cc1:CollapsiblePanelExtender ID="Panel1_CollapsiblePanelExtender" 
                                                runat="server" CollapseControlID="ImageButton1" 
                                                CollapsedImage="~\Image\Expand.png" Enabled="True" 
                                                ExpandControlID="ImageButton1" ExpandedImage="~\Image\Collapse.png" 
                                                ImageControlID="ImageButton1" TargetControlID="Panel1" Collapsed = "true" >
                                            </cc1:CollapsiblePanelExtender>
                                            <hr />
                                        </ItemTemplate>
                                    </asp:DataList>
                                    
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="txtSortNo" EventName="TextChanged" />
                                    <asp:AsyncPostBackTrigger ControlID="cmdView" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
            </td>
            <td style="background-position: left bottom; background-image: url('Image/Background/Right_Shadow.png');
                background-repeat: repeat-y; width: 12px; height: 510px;">
            </td>
        </tr>
    </table>
</asp:Content>
