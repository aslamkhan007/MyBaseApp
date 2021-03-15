<%@ Page Title="" Language="VB" MasterPageFile="User_Screen.master" AutoEventWireup="false" CodeFile="ParamMaster.aspx.vb" Inherits="ParamMaster" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register src="FlashMessage.ascx" tagname="flashmessage" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table id="TABLE1" 
            width="100%">
        <tr>
            <td class="tableheader" colspan="2">
&nbsp;Parameter&nbsp;Master</td>
        </tr>
        <tr>
            <td class="labelcells">
                <asp:Label ID="Label16" runat="server" Text="File Type"></asp:Label>
            </td>
            <td class="textcells">
                                        <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                            <ContentTemplate>
                                                <asp:TextBox ID="txtFileType" runat="server" 
                    CssClass="textbox" Height="16px" 
                                            Width="260px" AutoPostBack="True"></asp:TextBox>
                                                <cc1:AutoCompleteExtender ID="ACECatg" runat="server" CompletionInterval="100" 
                                                    CompletionListCssClass="autocomplete_ListItem " MinimumPrefixLength="0" 
                                                    ServiceMethod="GetParentCatg" ServicePath="WebService.asmx" 
                                                    TargetControlID="txtFileType">
                                                </cc1:AutoCompleteExtender>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                <asp:Label ID="Label19" runat="server" Text="Stage"></asp:Label>
            </td>
            <td class="textcells">
                                        <asp:TextBox ID="txtStage" runat="server" CssClass="textbox" Enabled="False" 
                                            Width="49px">1</asp:TextBox>
                                    
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Parameter Type</td>
            <td class="textcells">
                <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="DrpParamType" runat="server" CssClass="combobox" 
                    Width="130px" AutoPostBack="True">
                            <asp:ListItem>TextBox</asp:ListItem>
                            <asp:ListItem>DropDownList</asp:ListItem>
                            <asp:ListItem>Date</asp:ListItem>
                            <asp:ListItem>YesNo</asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                <asp:Label ID="Label1" runat="server" Width="119px">Parameter</asp:Label>
            </td>
            <td class="textcells">
                <asp:UpdatePanel ID="Code" runat="server">
                    <contenttemplate>
                        <asp:TextBox ID="TxtParemeter" runat="server" CssClass="textbox" 
                                MaxLength="40"  Width="131px"></asp:TextBox>
                            &nbsp;
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                            ControlToValidate="TxtParemeter" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </contenttemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                <asp:Label ID="Label2" runat="server" Width="138px">Description</asp:Label>
            </td>
            <td class="textcells">
                <asp:UpdatePanel ID="Description" runat="server">
                    <contenttemplate>
                        <asp:TextBox ID="TxtDesc" runat="server" accessKey="s" CssClass="textbox" 
                                Enabled="False" MaxLength="50" tabIndex="1" Width="195px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="TxtDesc" ErrorMessage="*" SetFocusOnError="True" 
                                Width="80px"></asp:RequiredFieldValidator>
                        <br />
                    </contenttemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                <asp:Label ID="Label6" runat="server" Width="138px">Source Procedure</asp:Label>
            </td>
            <td class="textcells">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <contenttemplate>
                        <asp:TextBox ID="TxtStoredProc" runat="server" accessKey="s" CssClass="textbox" 
                                Enabled="False" MaxLength="50" tabIndex="2" Width="344px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqSP" runat="server" 
                            ControlToValidate="TxtStoredProc" ErrorMessage="*" 
                            ToolTip="Give view name " Enabled="False"></asp:RequiredFieldValidator>
                    </contenttemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                <asp:Label ID="Label7" runat="server" Width="126px">Mandatory</asp:Label>
            </td>
            <td class="textcells" style="width: 765px">
                <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="DrpMandatory" runat="server" CssClass="combobox" 
                    Width="51px">
                            <asp:ListItem>Y</asp:ListItem>
                            <asp:ListItem>N</asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                <asp:Label ID="Label17" runat="server" Text="Sequence"></asp:Label>
            </td>
            <td class="textcells" style="width: 765px">
                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="Txtseq" runat="server" CssClass="textbox" Width="38px"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" 
                            TargetControlID="Txtseq" ValidChars="0123456789.">
                        </cc1:FilteredTextBoxExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells" style="height: 15px">
                <asp:Label ID="Label3" runat="server" Width="116px">Effective From</asp:Label>
            </td>
            <td class="textcells" style="height: 15px">
                <asp:UpdatePanel ID="From" runat="server" RenderMode="Inline">
                    <contenttemplate>
                        <asp:TextBox ID="TxtEffFrom" runat="server" accessKey="d" CssClass="textbox" 
                                Enabled="False" MaxLength="8" tabIndex="3" Width="70px"></asp:TextBox>
                        <cc1:maskededitvalidator id="MaskedEditValidator3" runat="server" 
                                controlextender="MaskedEditExtender3" controltovalidate="TxtEffFrom" 
                                display="Dynamic" emptyvaluemessage="*" 
                                invalidvaluemessage="The Date is invalid" isvalidempty="False" 
                                tooltipmessage="MM/DD/YYYY" width="114px"> </cc1:maskededitvalidator>
                        <cc1:calendarextender id="CalFrom" runat="server" animated="False" 
                                format="MM/dd/yyyy" targetcontrolid="TxtEffFrom">
                        </cc1:calendarextender>
                        <cc1:maskededitextender id="MaskedEditExtender3" runat="server" 
                                mask="99/99/9999" masktype="Date" targetcontrolid="txteffFrom">
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
                        <cc1:maskededitvalidator id="MaskedEditValidator4" runat="server" 
                                controlextender="MaskedEditExtender4" controltovalidate="TxtEffTo" 
                                display="Dynamic" emptyvaluemessage="*" 
                                invalidvaluemessage="The Date is invalid " isvalidempty="False" 
                                tooltipmessage="MM/DD/YYYY">
                            &nbsp;
                            </cc1:maskededitvalidator>
                        <cc1:calendarextender id="CalTo" runat="server" animated="False" 
                                format="MM/dd/yyyy" targetcontrolid="TxtEffTo">
                        </cc1:calendarextender>
                        <cc1:maskededitextender id="MaskedEditExtender4" runat="server" 
                                mask="99/99/9999" masktype="Date" targetcontrolid="TxtEffTo">
                        </cc1:maskededitextender>
                            &nbsp;
                        </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                <asp:Label ID="Label18" runat="server" Text="Trans No."></asp:Label>
            </td>
            <td class="textcells">
                <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="Lbltrans" runat="server" Height="0px" 
    Width="0px"></asp:Label>
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
                                CssClass="buttondisable" Enabled="False" onclick="CmdAdd_Click" 
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
                        <cc1:popupcontrolextender id="PopupExp0" runat="server" commitproperty="value" 
                                enabled="True" popupcontrolid="Panel2" 
                                targetcontrolid="CmdSearch" OffsetX="-250" OffsetY="-150">
                        </cc1:popupcontrolextender>
                        <cc1:confirmbuttonextender id="ConfirmButtonExtender2" runat="server" 
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
            <td  colspan="2">
                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                    <contenttemplate>
                        <asp:Panel ID="Panel2" runat="server" BorderStyle="None" CssClass="panelbg" 
                                Height="186px" ScrollBars="None" Width="493px">
                                <div  id = "AdjResultsDiv"> 
                            <asp:GridView ID="GrdHelp" runat="server" BorderStyle="Solid" 
                                    GridLines="Horizontal" Height="62px" HorizontalAlign="Left" 
                                    OnSelectedIndexChanged="grdHelp_SelectedIndexChanged" Width="1100px" 
                                BackColor="#F9F9F7" Font-Names="Tahoma" Font-Size="8pt">
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
                                <SelectedRowStyle BackColor="#999999" />
                                <HeaderStyle CssClass="gridheader" HorizontalAlign="Left" />
                            </asp:GridView>
                            </div>
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
        </table>
</asp:Content>

