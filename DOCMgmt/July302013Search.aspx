<%@ Page Title="" Language="VB" MasterPageFile="User_Screen.master" AutoEventWireup="false" CodeFile="Search.aspx.vb" Inherits="Search" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register Src="FlashMessage.ascx" TagName="FlashMessage" TagPrefix="uc1"%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%; height: 107px;">
        <tr>
            <td class="tableheader" colspan="4">
                Search File</td>
        </tr>
        <tr>
            <td class="labelcells" style="width: 100px">
                <asp:Label ID="Label1" runat="server" Text="Department"></asp:Label>
            </td>
            <td class="textcells" style="width: 150px">
                <asp:DropDownList ID="DrpDept" runat="server" CssClass="combobox" Width="216px">
                </asp:DropDownList>
            </td>
            <td class="labelcells" style="width: 100px">
                <asp:Label ID="Label17" runat="server" Text="Employee"></asp:Label>
            </td>
            <td class="textcells" style="width: 250px">
                <asp:TextBox ID="txtEmp" runat="server" CssClass="textbox" 
                    Width="121px" Height="16px"></asp:TextBox>
                <cc1:AutoCompleteExtender ID="ACE2" runat="server" CompletionInterval="100" 
                    CompletionListCssClass="autocomplete_ListItem " MinimumPrefixLength="0" 
                    ServiceMethod="GetEmpName" ServicePath="WebService.asmx" 
                    TargetControlID="txtEmp">
                </cc1:AutoCompleteExtender>
            </td>
        </tr>
        <tr>
            <td class="labelcells" style="width: 100px">
                <asp:Label ID="Label3" runat="server" Text="Date Added"></asp:Label>
            </td>
            <td class="textcells" style="width: 150px">
                <asp:TextBox ID="txtDate" runat="server" CssClass="textbox" 
                    Width="71px"></asp:TextBox>
                <cc1:CalendarExtender ID="CC3" runat="server" Format="MM/dd/yyyy" 
                    TargetControlID="txtDate">
                </cc1:CalendarExtender>
            </td>
            <td class="labelcells" style="width: 100px">
                <asp:Label runat="server" Text="File Type" ID="Label19"></asp:Label>
            </td>
            <td class="textcells" style="width: 250px">
                <asp:DropDownList ID="DdlFileType" runat="server" AutoPostBack="True" 
                    CssClass="combobox" Height="17px" Width="203px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="labelcells" colspan="4">
                <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="DdlFileType" 
                            EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells" style="width: 100px">
                <asp:Label ID="Label5" runat="server" Text="Key Info"></asp:Label>
            </td>
            <td class="textcells" colspan="3">
                <asp:TextBox runat="server" TextMode="MultiLine" Rows="2" Width="510px" 
                    ID="txtKeyInfo" Font-Names="Verdana" Font-Size="8pt" Height="50px" 
                    Wrap="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="labelcells" style="width: 100px">
                <asp:Label ID="Label6" runat="server" Text="Pages Count"></asp:Label>
            </td>
            <td class="textcells" style="width: 150px">
                <asp:TextBox runat="server" Width="60px" ID="txtPgNo" CssClass="textbox"></asp:TextBox>
                <asp:TextBox runat="server" CssClass="textbox" Width="64px" 
                    ID="txtAmt" Visible="False"></asp:TextBox>
            </td>
            <td class="labelcells" style="width: 100px">
                <asp:Label ID="Label31" runat="server" Text="Auto File No"></asp:Label>
            </td>
            <td class="textcells" style="width: 250px">
                <asp:TextBox ID="txtAutoFileNo" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="labelcells" style="width: 100px">
                            <asp:Label runat="server" Text="File RefNo." ID="Label23"></asp:Label>
            </td>
            <td class="textcells" style="width: 150px">
                            <asp:TextBox runat="server" CssClass="textbox" ID="txtFileRef"></asp:TextBox>
            </td>
            <td class="labelcells" style="width: 100px">
                            <asp:Label runat="server" Text="File RefDate" ID="Label24"></asp:Label>
            </td>
            <td class="textcells" style="width: 250px">
                            <asp:TextBox runat="server" CssClass="textbox" Width="65px" ID="txtRefDate"></asp:TextBox>
                            <cc1:CalendarExtender ID="CC4" runat="server" 
                                TargetControlID="txtRefDate">
                            </cc1:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td class="labelcells" style="width: 100px">
                            <asp:Label runat="server" Text="File Name" ID="Label25"></asp:Label>
            </td>
            <td class="textcells" style="width: 150px">
                            <asp:TextBox runat="server" CssClass="textbox" ID="txtFileName"></asp:TextBox>
            </td>
            <td class="labelcells" style="width: 100px">
                            <asp:Label runat="server" Text="File Description" ID="Label26"></asp:Label>
            </td>
            <td class="textcells" style="width: 250px">
                            <asp:TextBox ID="txtFileDesc" runat="server" CssClass="textbox" Width="151px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                                                    <asp:LinkButton ID="LnkSearch" runat="server" CssClass="buttonc" 
                                                        BorderStyle="None">Search</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="labelcells" rowspan="2">
                            <asp:Label runat="server" Text="View" ID="Label29" Visible="False"></asp:Label>
            </td>
            <td class="labelcells" colspan="3">
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
                    RepeatDirection="Horizontal" Visible="False">
                    <asp:ListItem>All Files</asp:ListItem>
                    <asp:ListItem Selected="True">Group Wise</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td class="labelcells" colspan="3">
                <asp:RadioButtonList ID="RadioButtonList2" runat="server" 
                    RepeatDirection="Horizontal" Visible="False">
                    <asp:ListItem Selected="True">List View</asp:ListItem>
                    <asp:ListItem>Detail View</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td class="labelcells" colspan="4">
                <asp:Panel ID="PnlSearch" runat="server">
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                            <table style="width:100%;">
                                <tr>
                                    <td colspan="4">
                                        <asp:DataList ID="DataList1" runat="server" BorderStyle="Groove" 
                                            BorderWidth="2px" RepeatColumns="3" RepeatDirection="Horizontal" Width="100%">
                                            <EditItemStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                                            <ItemTemplate>
                                                <table class="panelcells" style="width: 100%; height: 39px;">
                                                    <tr>
                                                        <td align="center">
                                                            <asp:Image ID="Image4" runat="server" ImageUrl='<%# eval("imgurl") %>' 
                                                                Width="16px" />
                                                            <cc1:HoverMenuExtender ID="HoverMenuExtender1" runat="server" PopDelay="5" 
                                                                PopupControlID="Panel3" PopupPosition="Left" TargetControlID="Image4">
                                                            </cc1:HoverMenuExtender>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center">
                                                            <asp:HyperLink ID="LnkFile" runat="server" NavigateUrl='<%# eval("url") %>' 
                                                                Text='<%# eval("name") %>'></asp:HyperLink>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center">
                                                            <asp:Panel ID="Panel3" runat="server" BorderStyle="Groove" BorderWidth="3px" 
                                                                CssClass="panelcells">
                                                                <table style="width:100%;">
                                                                    <tr>
                                                                        <td class="gridheader">
                                                                            <asp:Label ID="Label27" runat="server" Text='<%# eval("name") %>'></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Image ID="Image5" runat="server" ImageUrl='<%# eval("imgurl") %>' />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                        </asp:DataList>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <asp:GridView ID="GrdResult" runat="server" AutoGenerateColumns="False" 
                                            BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" Width="736px">
                                            <Columns>
                                                <asp:TemplateField HeaderText="TransNo">
                                                    <ItemTemplate>
                                                        <table style="width: 100%;">
                                                            <tr>
                                                                <td>
                                                                    <asp:HyperLink ID="LnkTrans" runat="server" ForeColor="#0033CC" 
                                                                        Text='<%# eval("Autofileno") %>'></asp:HyperLink>
                                                                    <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" 
                                                                        BackgroundCssClass="modalBackground" CancelControlID="ImgExit" 
                                                                        PopupControlID="Panel2" RepositionMode="RepositionOnWindowResize" 
                                                                        TargetControlID="LnkTrans">
                                                                    </cc1:ModalPopupExtender>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Panel ID="Panel2" runat="server" BorderColor="#333333" BorderWidth="1px"   
                                                                        CssClass="panelcells"  Width="562px">
                                                                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                                            <ContentTemplate>
                                                                                <table style="width: 100%; height: 3px;">
                                                                                    <tr>
                                                                                        <td class="gridheader" style="height: 1px">
                                                                                            <asp:Label ID="LblFileRef" runat="server" Text='<%# eval("filerefno") %>'></asp:Label>
                                                                                            &nbsp;- TransNo:<asp:Label ID="lblTrans" runat="server" 
                                                                                                Text='<%# eval("TransNo") %>'></asp:Label>
                                                                                        </td>
                                                                                        <td class="gridheader" 
                                                                                            style="border-style: none; padding: 0px; margin: 0px; width: 23px; height: 1px">
                                                                                            <asp:ImageButton ID="ImgExit" runat="server" BorderStyle="None" 
                                                                                                ImageUrl="Image/exit.png" />
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:GridView ID="GrdFileDtl" runat="server" AllowPaging="True" 
                                                                                                AutoGenerateColumns="False" Width="524px">
                                                                                                <Columns>
                                                                                                    <asp:TemplateField HeaderText="FileNo">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:HyperLink ID="LnkFileNo" runat="server" NavigateUrl='<%# eval("flurl") %>' 
                                                                                                                Text='<%# eval("fileno") %>'></asp:HyperLink>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:BoundField DataField="Description" HeaderText="Description" />
                                                                                                    <asp:TemplateField HeaderText="FileName">
                                                                                                        <ItemTemplate>
                                                                                                            <table style="width: 100%;">
                                                                                                                <tr>
                                                                                                                    <td align="center">
                                                                                                                        <asp:Image ID="ImgFileDtl" runat="server" Height="16px" 
                                                                                                                            ImageUrl='<%# eval("url") %>' Width="16px" />
                                                                                                                        <cc1:ModalPopupExtender ID="ModalPopupExtender2" runat="server" 
                                                                                                                            BackgroundCssClass="modalBackground" CancelControlID="Image2" 
                                                                                                                            OkControlID="imgExit1" PopupControlID="PnlHover" ScriptPath="" 
                                                                                                                            TargetControlID="ImgFileDtl">
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
                                                                                                            <asp:Panel ID="PnlHover" runat="server" BorderColor="Black" BorderStyle="Solid" 
                                                                                                                BorderWidth="1px" Width="99%">
                                                                                                                <table style="width: 100%;">
                                                                                                                    <tr>
                                                                                                                        <td align="left" class="gridheader" style="width: 466px; height: 15px;">
                                                                                                                            <asp:Label ID="Label30" runat="server" 
                                                                                                                                Text='<%# "File Name :-  " + eval("filename") %>'></asp:Label>
                                                                                                                        </td>
                                                                                                                        <td align="right" class="tableheader" valign="top" style="height: 15px">
                                                                                                                            <asp:ImageButton ID="ImgExit1" runat="server" BorderStyle="None" 
                                                                                                                                ImageUrl="Image/exit.png" />
                                                                                                                        </td>
                                                                                                                    </tr>
                                                                                                                    <tr>
                                                                                                                        <td align="center" colspan="2" style="height: 7px" valign="top">
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
                                                                            <asp:Label ID="lblName" runat="server" Font-Bold="True" Font-Names="Tahoma" 
                                                                                Font-Size="8pt" Text='<%# eval("filename") %>'></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="center">
                                                                            <asp:Image ID="Image1" runat="server" Height="16px" 
                                                                                ImageUrl='<%# eval("img") %>' Width="16px" />
                                                                            <cc1:HoverMenuExtender ID="HoverMenuExtender2" runat="server" 
                                                                                PopupControlID="Panel1" TargetControlID="Image1">
                                                                            </cc1:HoverMenuExtender>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="center">
                                                                            
                                                                            <asp:Panel ID="Panel1" runat="server" BorderStyle="Groove" BorderWidth="3px" 
                                                                                CssClass="panelcells" >
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
                                                                                                    <asp:HyperLink ID="HyperLink3" runat="server" ImageUrl='<%# eval("img") %>' 
                                                                                                        NavigateUrl='<%# eval("url") %>' Text='<%# eval("filename") %>'></asp:HyperLink>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </ContentTemplate>
                                                                                </asp:UpdatePanel>
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
                                                <asp:BoundField DataField="KeyInfo" HeaderText="KeyValue" />
                                                <asp:TemplateField HeaderText="Update">
                                                    <ItemTemplate>
                                                        <asp:HyperLink ID="HLUpdate" runat="server" Text='<%# eval("Upd") %>' 
                                                            NavigateUrl='<%# eval("UpdLnk") %>'></asp:HyperLink>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Delete">
                                                    <ItemTemplate>
                                                        <asp:HyperLink ID="HLDel" runat="server" NavigateUrl='<%# eval("DelLnk") %>' 
                                                            Text='<%# eval("Del") %>'></asp:HyperLink>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <HeaderStyle CssClass="gridheader" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <table cellpadding="0" cellspacing="0" style="width:100%;">
                                            <tr>
                                                <td class="labelcells" style="width: 24%" align="left">
                                                    &nbsp;</td>
                                                <td width="60%" align="left">
                                                    <uc1:FlashMessage ID="FMsg" runat="server" EnableTheming="True" Message="test" 
                         FadeInDuration="2" FadeInSteps="2" FadeOutDuration="4" FadeOutSteps="2" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                            <ContentTemplate>
                                                <asp:DataList ID="DataList2" runat="server" RepeatColumns="5" 
                                                    RepeatDirection="Horizontal">
                                                    <ItemTemplate>
                                                        <table align="center">
                                                            <tr>
                                                                <td align="center" style="text-align: center">
                                                                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# eval("lnk") %>' 
                                                                        Text='<%# eval("Catg") %>'></asp:HyperLink>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" style="text-align: center">
                                                                    (<asp:HyperLink ID="HyperLink2" runat="server" Text='<%# eval("cnt") %>' 
                                                                        NavigateUrl='<%# eval("lnk") %>'></asp:HyperLink>
                                                                    )</td>
                                                            </tr>
                                                        </table>
                                                    </ItemTemplate>
                                                </asp:DataList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                            ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                                            SelectCommand="select '' as deptname union select deptname from deptmast where company_code='jct00ltd' order by deptname">
                                        </asp:SqlDataSource>
                                    </td>
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
                            <br />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </asp:Panel>
            </td>
        </tr>
        </table>
                </asp:Content>

