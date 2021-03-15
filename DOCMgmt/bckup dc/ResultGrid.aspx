<%@ Page Title="" Language="VB" MasterPageFile="User_Screen.master" AutoEventWireup="false" Trace="false"
    CodeFile="ResultGrid.aspx.vb" Inherits="ResultGrid" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="FlashMessage.ascx" TagName="FlashMessage" TagPrefix="uc1"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 600px;">
        <tr>
            <td colspan="3" class="tableheader">
                <asp:Label ID="Label20" runat="server" Text="Results"></asp:Label>
                </td>
        </tr>
        <tr>
            <td>
                <asp:LinkButton ID="cmdBack" runat="server" BorderStyle="None" 
                    CssClass="buttonc">&lt;&lt; Back</asp:LinkButton>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="3">
              
                        <asp:Panel ID="Panel3" runat="server" CssClass="panelcells" >
                            <asp:GridView ID="GrdResult" runat="server" 
    AutoGenerateColumns="False" Width="736px" BorderStyle="None" EnableModelValidation="True">
                                <Columns>
                                    <asp:CommandField ShowSelectButton="True" SelectText="download" />
                                    <asp:TemplateField HeaderText="TransNo">
                                        <ItemTemplate>
                                            <table style="width: 100%;">
                                                <tr>
                                                    <td>
                                                        <asp:HyperLink ID="LnkTrans" runat="server" Text='<%# eval("AutoFileno") %>' 
                                                ForeColor="#0033CC" ></asp:HyperLink>
                                                        <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" CancelControlID="ImgExit"
                                                PopupControlID="Panel2" TargetControlID="LnkTrans" RepositionMode="RepositionOnWindowResize" 
                                                BackgroundCssClass="modalBackground">
                                                        </cc1:ModalPopupExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Panel ID="Panel2" runat="server" Width="562px" BorderColor="#333333" 
                                                    BorderWidth="1px" style="display:none"
                                                CssClass="panelcells">
                                                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                                <ContentTemplate>
                                                                    <table style="width: 100%; height: 3px;">
                                                                        <tr>
                                                                            <td class="gridheader" style="height: 1px">
                                                                                <asp:Label ID="LblFileRef" runat="server" Text='<%# eval("filerefno") %>'></asp:Label>
                                                                                &nbsp;- TransNo:<asp:Label ID="lblTrans" runat="server" 
                                                                        Text='<%# eval("TransNo") %>'></asp:Label>
                                                                            </td>
                                                                            <td style="border-style: none; padding: 0px; margin: 0px; width: 23px; height: 1px"
                                                                    class="gridheader">
                                                                                <asp:ImageButton ID="ImgExit" runat="server" ImageUrl="Image/exit.png" 
                                                                        BorderStyle="None" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:GridView ID="GrdFileDtl" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                                        Width="524px">
                                                                                    <Columns>
                                                                                        <asp:TemplateField HeaderText="FileNo">
                                                                                            <ItemTemplate>
                                                                                                <asp:HyperLink ID="LnkFileNo" runat="server" Text='<%# eval("fileno") %>' 
                                                                                        NavigateUrl='<%# eval("flurl") %>'></asp:HyperLink>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:BoundField DataField="Description" HeaderText="Description" />
                                                                                        <asp:TemplateField HeaderText="FileName">
                                                                                            <ItemTemplate>
                                                                                                <table style="width: 100%;">
                                                                                                    <tr>
                                                                                                        <td align="center">
                                                                                                            <asp:Image ID="ImgFileDtl" runat="server" Height="16px" ImageUrl='<%# eval("url") %>'
                                                                                                    Width="16px" />
                                                                                                            <cc1:ModalPopupExtender ID="ModalPopupExtender2" runat="server" BackgroundCssClass="modalBackground"
                                                                                                    CancelControlID="Image2" PopupControlID="PnlHover" TargetControlID="ImgFileDtl"
                                                                                                    ScriptPath="" OkControlID="imgExit1">
                                                                                                            </cc1:ModalPopupExtender>
                                                                                                            <cc1:AnimationExtender ID="AnimationExtender1" runat="server" 
                                                                                                    TargetControlID="ImgFileDtl">
                                                                                                                <Animations>
    <OnClick>
      <Parallel AnimationTarget="pnlHover" 
        Duration=".9" Fps="25">
        <FadeIn />
      </Parallel>                    
    </OnClick>
  </Animations>
                                                                                                            </cc1:AnimationExtender>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                                <asp:Panel ID="PnlHover" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"
                                                                                        Width="99%">
                                                                                                    <table style="width: 100%;">
                                                                                                        <tr>
                                                                                                            <td align="left" class="tableheader" style="width: 466px">
                                                                                                                <asp:Label ID="Label19" runat="server" 
                                                                                                            Text='<%# "File Name :-  " + eval("filename") %>'></asp:Label>
                                                                                                            </td>
                                                                                                            <td align="right" class="tableheader" valign="top">
                                                                                                                <asp:ImageButton ID="ImgExit1" runat="server" BorderStyle="None" 
                                                                                                            ImageUrl="Image/exit.png" />
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td align="center" style="height: 7px" valign="top" colspan="2">
                                                                                                                <asp:Image ID="Image2" runat="server" BorderColor="#666666" BorderStyle="None"
                                                                                                        BorderWidth="2px" ImageUrl='<%# eval("url") %>' 
                                                                                                        ToolTip='<%# "Click To Go Back" %>' />
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </asp:Panel>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                    </Columns>
                                                                                    <HeaderStyle CssClass="buttonbackbar" />
                                                                                </asp:GridView>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </asp:Panel>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="File Name">
                                        <ItemTemplate>
                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                <ContentTemplate>
                                                    <table style="width: 100%;">
                                                        <tr>
                                                            <td align="center">
                                                                <asp:Label ID="lblName" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt"
                                                        Text='<%# eval("filename") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center">
                                                                <asp:Image ID="Image1" runat="server" Height="16px" ImageUrl='<%# eval("img") %>'
                                                        Width="16px" />
                                                                <cc1:HoverMenuExtender ID="HoverMenuExtender1" runat="server" PopupControlID="Panel4"
                                                        TargetControlID="Image1">
                                                                </cc1:HoverMenuExtender>
                                                                <asp:LinkButton ID="LinkButton1" runat="server">LinkButton</asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center">
                                                                <asp:Panel ID="Panel1" runat="server" BorderStyle="Groove" BorderWidth="3px"  style="display:none"
                                                        CssClass="panelcells">
                                                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                                        <ContentTemplate>
                                                                            <table style="width: 100%;">
                                                                                <tr>
                                                                                    <td class="gridheader">
                                                                                        <asp:Label ID="Label16" runat="server" Text='<%# eval("filename") %>'></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:HyperLink ID="HyperLink1" runat="server" ImageUrl='<%# eval("img") %>' NavigateUrl='<%# eval("url") %>'
                                                                                Text='<%# eval("filename") %>'></asp:HyperLink>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </asp:Panel>
                                                                <asp:Panel ID="Panel4" runat="server">
                                                                    <asp:HyperLink ID="HyperLink2" runat="server" ImageUrl='<%# eval("img") %>' 
                                                                        NavigateUrl='<%# eval("url") %>'>[HyperLink2]</asp:HyperLink>
                                                                </asp:Panel>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="FileRefNo" HeaderText="FileRefNo" />
                                    <asp:BoundField DataField="FileRefDate" HeaderText="FileRefDate" />
                                    <asp:BoundField DataField="CreatedDt" HeaderText="CreatedDt" />
                                    <asp:BoundField DataField="UploadBy" HeaderText="UploadBy" />
                                    <asp:BoundField DataField="KeyInfo" HeaderText="KeyInfo" />
                                    <asp:TemplateField HeaderText="Update">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="HyperLink3" runat="server" 
                                                NavigateUrl='<%# eval("UpdLnk") %>' Text='<%# eval("Upd") %>'></asp:HyperLink>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Delete">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="HyperLink4" runat="server" 
                                                NavigateUrl='<%# eval("DelLnk") %>' Text='<%# eval("Del") %>'></asp:HyperLink>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <HeaderStyle CssClass="gridheader" />
                            </asp:GridView>
                        </asp:Panel>
                 
            </td>
        </tr>
        <tr>
            <td>
                 <uc1:FlashMessage ID="FMsg" runat="server" EnableTheming="True" Message="test" 
                         FadeInDuration="2" FadeInSteps="2" FadeOutDuration="4" FadeOutSteps="2" /></td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
