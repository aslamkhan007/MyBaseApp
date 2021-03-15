<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="FabricTestParticulars.aspx.vb" Inherits="FabricTestParticulars" %>

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
                    font-weight: 700;" Text="Fabric Particulars"></asp:Label>
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
                background-repeat: no-repeat; width: 12px">
            </td>
            <td style="vertical-align: top; text-align: left;">
                <table style="width: 100%;" class="tableback">
                    <tr>
                        <td class="labelcells" width="150px">
                            <asp:Label ID="Label8" runat="server" Text="Sort No"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtSortNo" runat="server" CssClass="textbox" AutoPostBack="True"
                                CausesValidation="True"></asp:TextBox>
                            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtSortNo"
                                CssClass="errormsg" Display="Dynamic" ErrorMessage="Sort No. Required" 
                                SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <asp:UpdatePanel ID="UpdatePanel7" runat="server" RenderMode="Inline">
                                <ContentTemplate>
                                    <asp:CustomValidator ID="CustomValidator1" runat="server" 
    Display="Dynamic" ErrorMessage="Invalid Sort" CssClass="errormsg"></asp:CustomValidator>
                                    <asp:CustomValidator ID="CustomValidator2" runat="server" 
    Display="Dynamic" CssClass="errormsg"></asp:CustomValidator>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                        <td class="labelcells" width="150px">
                            <asp:Label ID="Label21" runat="server" Text="Finish"></asp:Label>
                        </td>
                        <td>
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
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
                        <td atomicselection="False" colspan="4" style="text-align: center">
                            <asp:LinkButton ID="cmdView" runat="server" CssClass="buttonc">View</asp:LinkButton>
                        </td>
                    </tr>
                </table>
                <table style="width: 100%;" class="tableback">
                    <tr>
                        <td class="labelcells">
                            <asp:Label ID="Label20" runat="server" Style="font-family: 'Trebuchet MS'; font-size: small;
                                font-weight: 700;" Text="Sort Details"></asp:Label>
                            &nbsp; &nbsp; &nbsp; &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="NormalText">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:GridView ID="grdSearchResults" runat="server" Width="100%">
                                        <EmptyDataTemplate>
                                            <span style="font-family: 'Tahoma'; size: 8pt;">No Data Available</span>
                                        </EmptyDataTemplate>
                                        <HeaderStyle CssClass="GridHeader" />
                                        <RowStyle CssClass="GridItem" />
                                    </asp:GridView>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="cmdView" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="txtSortNo" EventName="TextChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
                <table style="width: 100%;" class="tableback">
                    <tr>
                        <td class="labelcells">
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td class="labelcells">
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="NormalText" colspan="4">
                            <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:GridView ID="grdFabricTestDetails" runat="server" Width="100%">
                                        <EmptyDataTemplate>
                                            <span style="font-family: 'Tahoma'; size: 8pt;">No Data Available</span>
                                        </EmptyDataTemplate>
                                        <HeaderStyle CssClass="GridHeader" />
                                        <RowStyle CssClass="GridItem" />
                                    </asp:GridView>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="cmdView" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="txtSortNo" EventName="TextChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
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
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="NormalText">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:GridView ID="grdWarpWeftDetail" runat="server" Width="100%">
                                        <EmptyDataTemplate>
                                            <span style="font-family: 'Tahoma'; size: 8pt;">No Data Available</span>
                                        </EmptyDataTemplate>
                                        <HeaderStyle CssClass="GridHeader" />
                                        <RowStyle CssClass="GridItem" />
                                    </asp:GridView>
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
                background-repeat: no-repeat; width: 12px">
            </td>
        </tr>
    </table>
</asp:Content>
