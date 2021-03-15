<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="Notice_Board.aspx.vb" Inherits="Notice_Board" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <table style="width: 100%; height: 300px;" cellpadding="0" cellspacing="0">
        <tr>
            <td style="text-align: left; width: 210px; vertical-align: top;" class="NormalText">
                <table cellpadding="0" cellspacing="0" style="width: 210px; height: 440px;" 
                    id="tblMenu">
                    <tr>
                        <td style="background-position: right bottom; background-image: url('Image/Background/Left%20Shadow.png');
                            background-repeat: no-repeat; width: 12px">
                            &nbsp;
                        </td>
                        <td style="background-position: center top; vertical-align: top; background-image: url('Image/Plain_Footer.png');
                            background-repeat: no-repeat; height: 100%;">
                            <asp:Label ID="lblSections" runat="server" Style="font-family: Tahoma; font-size: x-small"
                                Visible="False">Select Topic</asp:Label>
                            <br />
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <asp:TreeView ID="treDept" runat="server" ExpandDepth="1" Width="100%" CollapseImageToolTip="Click to Collapse {0}"
                                        ExpandImageToolTip="Click to Expand {0}">
                                        <HoverNodeStyle CssClass="GridSelectedItem" />
                                        <SelectedNodeStyle CssClass="GridSelectedItem" />
                                        <DataBindings>
                                            <asp:TreeNodeBinding DataMember="MenuItem" TextField="Text" ToolTipField="ToolTip"
                                                NavigateUrlField="NavigateUrl" ValueField="Value" />
                                        </DataBindings>
                                        <NodeStyle ForeColor="#333333" />
                                    </asp:TreeView>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                        <td style="background-position: left bottom; vertical-align: top; background-image: url('Image/background/right_shadow.png');
                            background-repeat: no-repeat; height: 100%; width: 12px;">
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
            <%--<td style="text-align: left; vertical-align: top;">
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
                            <asp:Label ID="Label7" runat="server" Style="font-family: 'Trebuchet MS'; font-size: small;
                                font-weight: 700;" Text="Notice Board"></asp:Label>
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
                        <td style="background-position: left top; vertical-align: top; background-image: url('Image/NoticeBoard_Back.png');">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                 <ContentTemplate>
                                    <asp:Label ID="lblTitle1" runat="server" 
                                        Style="font-family: 'Trebuchet MS'; font-size: small; font-weight: 700;"></asp:Label>
                                    <asp:GridView ID="GridView1" runat="server" Width="100%">
                                        <EmptyDataTemplate>
                                            <span style = "font-family:'Tahoma'; size:8pt;" >No Data Available</span>
                                        </EmptyDataTemplate>
                                        <HeaderStyle CssClass="GridHeader" />
                                        <AlternatingRowStyle CssClass="GridAI" />
                                        <RowStyle CssClass="GridItem" />
                                    </asp:GridView>
                                    &nbsp;<asp:Label ID="lblTitle" runat="server" 
                                        Style="font-family: 'Trebuchet MS'; font-size: small; font-weight: 700; background-color: #FFFFFF;"></asp:Label>
                                    <asp:GridView ID="GridView2" runat="server" Width="100%">
                                        <EmptyDataTemplate>
                                            <span style="font-family:'Tahoma'; size:8pt;">No Data Available</span>
                                        </EmptyDataTemplate>
                                        <HeaderStyle CssClass="GridHeader" />
                                        <AlternatingRowStyle CssClass="GridAI" />
                                        <RowStyle CssClass="GridItem" />
                                    </asp:GridView>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="treDept" EventName="SelectedNodeChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                        <td style="background-position: left bottom; background-image: url('Image/Background/Right_Shadow.png');
                            background-repeat: no-repeat; width: 12px">
                            
                        </td>
                    </tr>
                </table>
            </td>--%>
            
            <td style="text-align: left; vertical-align: top;">
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
                            <asp:Label ID="Label7" runat="server" Style="font-family: 'Trebuchet MS'; font-size: small;
                                font-weight: 700;" Text="Notice Board - "></asp:Label>
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server" RenderMode="Inline" 
                                UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:Label ID="lblTitle" runat="server" Style="font-family: 'Trebuchet MS'; font-size: small;
                                        font-weight: 700;"></asp:Label>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="treDept" EventName="SelectedNodeChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
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
                        <td style="background-position: left top; vertical-align: top; background-image: url('Image/NoticeBoard_Back.png');">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <br />
                                    <asp:GridView ID="GridView1" runat="server" Width="100%">
                                        <EmptyDataTemplate>
                                            <span style="font-family: 'Tahoma'; size: 8pt;">No Data Available</span>
                                        </EmptyDataTemplate>
                                        <HeaderStyle CssClass="GridHeader" />
                                        <AlternatingRowStyle CssClass="GridAI" />
                                        <RowStyle CssClass="GridItem" />
                                    </asp:GridView>
                                    <asp:GridView ID="GridView2" runat="server" Width="100%">
                                        <EmptyDataTemplate>
                                            <span style="font-family: 'Tahoma'; size: 8pt;">No Data Available</span>
                                        </EmptyDataTemplate>
                                        <HeaderStyle CssClass="GridHeader" />
                                        <AlternatingRowStyle CssClass="GridAI" />
                                        <RowStyle CssClass="GridItem" />
                                    </asp:GridView>
                                    &nbsp;
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="treDept" EventName="SelectedNodeChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                        <td style="background-position: left bottom; background-image: url('Image/Background/Right_Shadow.png');
                            background-repeat: no-repeat; width: 12px">
                        </td>
                    </tr>
                </table>
            </td>
            
        </tr>
    </table>
    <table cellpadding="0" cellspacing="0" style="width: 100%;">
        <tr>
            <td style="background-position: left top; height: 20px; background-image: url('Image/Frame/Footer_Frame_Large.png');
                background-repeat: no-repeat; width: 50%;">
                &nbsp;
            </td>
            <td style="background-position: right top; height: 20px; background-image: url('Image/Frame/Footer_Frame_Large.png');
                background-repeat: no-repeat; width: 50%;">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="height: 0px; text-align: center;" class="NormalText" colspan="2">
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx">Back</asp:HyperLink>
                <br />
            </td>
        </tr>
    </table>
</asp:Content>
