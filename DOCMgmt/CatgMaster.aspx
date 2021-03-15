<%@ Page Language="VB" MasterPageFile="User_Screen.master" AutoEventWireup="false" CodeFile="CatgMaster.aspx.vb" Inherits="CatgMaster" title="Untitled Page" %>
<%@ Register Src="FlashMessage.ascx" TagName="FlashMessage" TagPrefix="uc1" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        <table id="TABLE1" language="javascript"
            width="100%">
            <tr>
                <td class="tableheader" colspan="2">
                    Document Type&nbsp;Master</td>
            </tr>
            <tr>
                <td class="labelcells">
                    <asp:Label ID="Label16" runat="server" Text="Department"></asp:Label>
                </td>
                <td class="textcells">
                    <asp:DropDownList ID="DrpDept" runat="server" CssClass="combobox" Width="244px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="labelcells">
                    <asp:Label ID="Label7" runat="server" Width="126px">Parent Category</asp:Label>
                </td>
                <td class="textcells">
                            <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                <ContentTemplate>
                                    <asp:TextBox ID="TxtParent" runat="server" 
    CssClass="textbox" Enabled="False" 
                                ReadOnly="True"></asp:TextBox>
                                    <cc1:hovermenuextender id="HoverMenu" 
    runat="server" enabled="True" 
                                popupcontrolid="PanelParent" popupposition="Right" 
                                targetcontrolid="TxtParent">
                                    </cc1:hovermenuextender>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td class="labelcells">
                    <asp:Label ID="Label1" runat="server" Width="119px">Type Code</asp:Label>
                </td>
                <td class="textcells">
                    <asp:UpdatePanel ID="Code" runat="server">
                        <contenttemplate>
                            <asp:TextBox ID="TxtCode" runat="server" CssClass="textbox" 
                                MaxLength="2" onclick="javascript:btnClick.click();" Width="26px"></asp:TextBox>
                            &nbsp;
                        </contenttemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td class="labelcells">
                    <asp:Label ID="Label2" runat="server" Width="138px">Short Description</asp:Label>
                </td>
                <td class="textcells">
                    <asp:UpdatePanel ID="Description" runat="server">
                        <contenttemplate>
                            <asp:TextBox ID="TxtShortDesc" runat="server" accessKey="s" CssClass="textbox" 
                                Enabled="False" MaxLength="50" tabIndex="1" Width="195px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="TxtShortDesc" ErrorMessage="*" SetFocusOnError="True" 
                                Width="80px"></asp:RequiredFieldValidator>
                            <br />
                        </contenttemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td class="labelcells">
                    <asp:Label ID="Label6" runat="server" Width="138px">Long Description</asp:Label>
                </td>
                <td class="textcells">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <contenttemplate>
                            <asp:TextBox ID="TxtLongDesc" runat="server" accessKey="s" CssClass="textbox" 
                                Enabled="False" MaxLength="50" tabIndex="2" Width="344px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                ControlToValidate="TxtLongDesc" ErrorMessage="*" SetFocusOnError="True" 
                                Width="55px"></asp:RequiredFieldValidator>
                        </contenttemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td class="labelcells">
                    <asp:Label ID="Label3" runat="server" Width="116px">Effective From</asp:Label>
                </td>
                <td class="textcells">
                    <asp:UpdatePanel ID="From" runat="server" RenderMode="Inline">
                        <contenttemplate>
                            <asp:TextBox ID="TxtEffFrom" runat="server" accessKey="d" CssClass="textbox" 
                                Enabled="False" MaxLength="8" tabIndex="3" Width="70px"></asp:TextBox>
                            <cc1:maskededitvalidator id="MaskedEditValidator1" runat="server" 
                                controlextender="MaskedEditExtender1" controltovalidate="TxtEffFrom" 
                                display="Dynamic" emptyvaluemessage="*" 
                                invalidvaluemessage="The Date is invalid" isvalidempty="False" 
                                tooltipmessage="MM/DD/YYYY" width="114px">
                            &nbsp;
                            </cc1:maskededitvalidator>
                            <cc1:calendarextender id="CalFrom" runat="server" animated="False" 
                                format="MM/dd/yyyy" targetcontrolid="TxtEffFrom">
                            </cc1:calendarextender>
                            <cc1:maskededitextender id="MaskedEditExtender1" runat="server" 
                                mask="99/99/9999" masktype="Date" targetcontrolid="TxtEffFrom">
                            </cc1:maskededitextender>
                            &nbsp;&nbsp;&nbsp;
                        </contenttemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td class="labelcells">
                    <asp:Label ID="Label4" runat="server" Width="82px">Effective To</asp:Label>
                </td>
                <td class="textcells">
                    <asp:UpdatePanel ID="ETo" runat="server" RenderMode="Inline">
                        <ContentTemplate>
                            <asp:TextBox ID="TxtEffTo" runat="server" CssClass="textbox" Enabled="False" 
                                MaxLength="8" tabIndex="4" Width="70px"></asp:TextBox>
                            <cc1:maskededitvalidator id="MaskedEditValidator2" runat="server" 
                                controlextender="MaskedEditExtender2" controltovalidate="TxtEffTo" 
                                display="Dynamic" emptyvaluemessage="*" 
                                invalidvaluemessage="The Date is invalid " isvalidempty="False" 
                                tooltipmessage="MM/DD/YYYY">
                            &nbsp;
                            </cc1:maskededitvalidator>
                            <cc1:calendarextender id="CalTo" runat="server" animated="False" 
                                format="MM/dd/yyyy" targetcontrolid="TxtEffTo">
                            </cc1:calendarextender>
                            <cc1:maskededitextender id="MaskedEditExtender2" runat="server" 
                                mask="99/99/9999" masktype="Date" targetcontrolid="TxtEffTo">
                            </cc1:maskededitextender>
                            &nbsp;
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="height: 21px">
                    <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="10" 
                        DynamicLayout="False">
                        <ProgressTemplate>
                            <asp:Image ID="ProgressBar" runat="server" Height="10px" 
                                ImageUrl="~/Image/loading.gif" Width="70px" />
                            <br />
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                </td>
            </tr>
            <tr>
                <td align="center" class="buttonbackbar" colspan="2">
                    <asp:UpdatePanel ID="Add" runat="server" RenderMode="Inline">
                        <contenttemplate>
                            <asp:LinkButton ID="CmdAdd" runat="server" CausesValidation="False" 
                                CssClass="buttondisable" Enabled="False" 
                                tabIndex="5" BorderStyle="None">Add</asp:LinkButton>
                            <asp:LinkButton ID="CmdEdit" runat="server" CausesValidation="False" 
                                CssClass="buttondisable" Enabled="False" OnClick="CmdEdit_Click" 
                                tabIndex="6" BorderStyle="None">Edit</asp:LinkButton>
                            <asp:LinkButton ID="CmdDelete" runat="server" CausesValidation="False" 
                                CssClass="buttondisable" Enabled="False" 
                                OnClick="CmdDelete_Click" tabIndex="7" BorderStyle="None">Delete</asp:LinkButton>
                            <asp:LinkButton ID="CmdClose" runat="server" CausesValidation="False" 
                                CssClass="buttonc" OnClick="CmdClose_Click" tabIndex="8" 
                                BorderStyle="None">Close</asp:LinkButton>
                            <asp:LinkButton ID="CmdSearch" runat="server" CausesValidation="False" 
                                CssClass="buttonc" onclick="CmdSearch_Click" tabIndex="5" 
                                BorderStyle="None">Search</asp:LinkButton>
                            <cc1:popupcontrolextender id="PopupExp" runat="server" commitproperty="value" 
                                enabled="True" popupcontrolid="Panel2" 
                                targetcontrolid="CmdSearch" OffsetX="-250" OffsetY="-150">
                            </cc1:popupcontrolextender>
                            <cc1:confirmbuttonextender id="ConfirmButtonExtender1" runat="server" 
                                confirmtext="Are You Sure ?" targetcontrolid="CmdDelete">
                            </cc1:confirmbuttonextender>
                        </contenttemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td align="center" class="buttonbackbar" colspan="2">
                    <asp:UpdatePanel ID="Movement" runat="server" RenderMode="Inline">
                        <contenttemplate>
                            <asp:LinkButton ID="CmdFirst" runat="server" CausesValidation="False" 
                                CssClass="buttonc" tabIndex="5" BorderStyle="None">First</asp:LinkButton>
                            <asp:LinkButton ID="CmdPrevious" runat="server" CausesValidation="False" 
                                CssClass="buttonc" tabIndex="7" BorderStyle="None">Move Prev</asp:LinkButton>
                            <asp:LinkButton ID="CmdNext" runat="server" BorderStyle="None" 
                                CausesValidation="False" CssClass="buttonc" tabIndex="6">Move Next</asp:LinkButton>
                            <asp:LinkButton ID="CmdLast" runat="server" CausesValidation="False" 
                                CssClass="buttonc" tabIndex="8" BorderStyle="None">Last</asp:LinkButton>
                        </contenttemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td class="panelcells" colspan="2">
                    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                        <contenttemplate>
                            <asp:Panel ID="Panel2" runat="server" BorderStyle="None" CssClass="panelbg" 
                                Height="186px" ScrollBars="Auto" Width="300px">
                                <asp:GridView ID="GrdHelp" runat="server" BorderStyle="Solid" 
                                    GridLines="Horizontal" Height="62px" HorizontalAlign="Left" 
                                    OnSelectedIndexChanged="grdHelp_SelectedIndexChanged" Width="375px">
                                    <PagerSettings Visible="False" />
                                    <RowStyle HorizontalAlign="Justify" />
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" 
                                                    CommandName="Select"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        &nbsp;<asp:Label ID="Label5" runat="server" Text="No Data Available" Width="118px"></asp:Label>
                                    </EmptyDataTemplate>
                                    <SelectedRowStyle BackColor="Red" />
                                    <HeaderStyle CssClass="gridheader" HorizontalAlign="Left" />
                                </asp:GridView>
                            </asp:Panel>
                        </contenttemplate>
                    </asp:UpdatePanel>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <contenttemplate>
                            &nbsp;
                            <uc1:FlashMessage ID="FMsg" runat="server" EnableTheming="true" 
                                EnableViewState="true" FadeInDuration="2" FadeInSteps="2" FadeOutDuration="4" 
                                FadeOutSteps="2" Visible="true">
                            </uc1:FlashMessage>
                        </contenttemplate>
                    </asp:UpdatePanel>
                    &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp;</td>
            </tr>
            <tr>
                <td class="panelcells" colspan="2">
                    <asp:UpdatePanel ID="UpdatePanelParent" runat="server">
                        <contenttemplate>
                            <asp:Panel ID="PanelParent" runat="server" BorderStyle="None" 
                                CssClass="panelbg" Height="186px" ScrollBars="Auto" Width="300px">
                                <asp:GridView ID="GridViewParent" runat="server" BorderStyle="Solid" 
                                    GridLines="Horizontal" Height="62px" HorizontalAlign="Left" 
                                    OnSelectedIndexChanged="GridViewParent_SelectedIndexChanged" Width="375px">
                                    <PagerSettings Visible="False" />
                                    <RowStyle HorizontalAlign="Justify" />
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="LinkButtonParent" runat="server" CausesValidation="False" 
                                                    CommandName="Select"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        &nbsp;<asp:Label ID="LabelParent" runat="server" Text="No Data Available" 
                                            Width="118px"></asp:Label>
                                    </EmptyDataTemplate>
                                    <SelectedRowStyle BackColor="Red" />
                                    <HeaderStyle CssClass="gridheader" HorizontalAlign="Left" />
                                </asp:GridView>
                            </asp:Panel>
                        </contenttemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td style="width: 204px">
                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                        <contenttemplate>
                            <asp:Button ID="Button1" runat="server" CausesValidation="False" 
                                CssClass="buttondisable" Height="0px" onclick="Button1_Click" Text="Button" 
                                Width="0px" />
                        </contenttemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
    </p>
</asp:Content>

