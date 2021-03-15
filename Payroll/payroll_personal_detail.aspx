<%@ Page Title="" Language="C#" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="true"
    CodeFile="payroll_personal_detail.aspx.cs" Inherits="OPS_payroll_personal_detail" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="mytable">
        <tr>
            <td class="tableheader" colspan="4">
                Address Detail
            </td>
        </tr>
        <tr>
            <td align="center" colspan="4">
                <%--    <td class="tableheader">

                                   <asp:ImageButton ID="lmgbnkdetail" runat="server" 
                                       ImageUrl="~/OPS/Image/plus.png" />

                               </td>--%>
                <%--          <asp:LinkButton ID="lnkbtnbasicdetails" runat="server" CssClass="buttonc" 
                                            ValidationGroup="A" onclick="lnkbtnbasicdetails_Click">basic details</asp:LinkButton>
                                        <asp:LinkButton ID="lnkbtnpersonal" runat="server" CssClass="buttonc" 
                                            ValidationGroup="A" onclick="lnkbtnpersonal_Click">personal </asp:LinkButton>
                                        <asp:LinkButton ID="lnkbtnearning" runat="server" CssClass="buttonc" 
                                            ValidationGroup="A" onclick="lnkbtnearning_Click">Earning </asp:LinkButton>
                                        <asp:LinkButton ID="lnkbtndeduction" runat="server" CssClass="buttonc" 
                                            ValidationGroup="A" onclick="lnkbtndeduction_Click">Deductions</asp:LinkButton>--%>
                <asp:ImageButton ID="ImageOfficial" runat="server" ImageUrl="~/Image/Official_Info.png"
                    OnClick="ImageOfficial_Click" ValidationGroup="A" />
                <asp:ImageButton ID="ImagePersonal" runat="server" ImageUrl="~/Image/Personal_Info_Red.png"
                    OnClick="ImagePersonal_Click" ValidationGroup="A" />
                <asp:ImageButton ID="ImageEarnings" runat="server" ImageUrl="~/Image/Earnings_Info.png"
                    OnClick="ImageEarnings_Click" ValidationGroup="A" />
                <asp:ImageButton ID="ImageDeductions" runat="server" ImageUrl="~/Image/Deductions_Info.png"
                    OnClick="ImageDeductions_Click" ValidationGroup="A" />
            </td>
        </tr>
        <tr>
            <td class="labelcells" style="width: 164px">
                <asp:Label ID="Label54" runat="server" Text="Address Type"></asp:Label>
            </td>
            <td class="textcells" colspan="3">
                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlAddressType" runat="server" CssClass="combobox" AutoPostBack="True"
                            OnSelectedIndexChanged="ddlAddressType_SelectedIndexChanged">
                            <asp:ListItem>Current</asp:ListItem>
                            <asp:ListItem>Permanent</asp:ListItem>
                            <asp:ListItem>Correspondence</asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells" style="width: 164px">
                <asp:Label ID="Label7" runat="server" Text="Address Line No 1"></asp:Label>
            </td>
            <td class="textcells" colspan="3">
                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="TxtAddress1" runat="server" CssClass="textbox" Width="430px"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells" style="width: 164px">
                <asp:Label ID="Label8" runat="server" Text="Address Line No 2"></asp:Label>
            </td>
            <td class="textcells" colspan="3">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="TxtAddress2" runat="server" CssClass="textbox" Width="430px" TabIndex="1"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells" style="width: 164px">
                <asp:Label ID="Label19" runat="server" Text="Address Line No 3"></asp:Label>
            </td>
            <td class="textcells" colspan="3">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="TxtAddress3" runat="server" CssClass="textbox" Width="430px" TabIndex="3"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells" style="width: 164px">
                <asp:Label ID="Label55" runat="server" Text="Country"></asp:Label>
            </td>
            <td class="textcells" style="width: 349px">
                <asp:DropDownList ID="ddlcoutry" runat="server" CssClass="combobox" AppendDataBoundItems="True"
                    AutoPostBack="True">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>India</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="labelcells" style="width: 88px">
                &nbsp;
            </td>
            <td style="width: 14px" class="textcells">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                State
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtstate" runat="server" CssClass="textbox" MaxLength="30"></asp:TextBox>
                <cc1:AutoCompleteExtender ID="txtState_AutoCompleteExtender" runat="server" CompletionInterval="10"
                    CompletionSetCount="20" MinimumPrefixLength="1" ServiceMethod="Jct_Payroll_State_List"
                    CompletionListCssClass="AutoExtender" ServicePath="~/WebService.asmx" CompletionListElementID="divwidth"
                    CompletionListHighlightedItemCssClass="AutoExtenderHighlight" CompletionListItemCssClass="AutoExtenderList"
                    TargetControlID="txtstate">
                </cc1:AutoCompleteExtender>
                <%--<asp:DropDownList ID="ddlstate" runat="server" CssClass="combobox" 
                    AutoPostBack="True" onselectedindexchanged="ddlstate_SelectedIndexChanged" 
                     Height="20px" Width="120px" 
                      >                       
                </asp:DropDownList>--%>
            </td>
            <td class="labelcells" style="width: 88px">
                &nbsp;
            </td>
            <td class="textcells" style="width: 14px">
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:misjctdev %>"
                    SelectCommand="select description,Bank_code  as Bank from JCT_payroll_bank_master where status='a'">
                </asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                City
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtcity" runat="server" CssClass="textbox" MaxLength="30"></asp:TextBox>
                <cc1:AutoCompleteExtender ID="txtCity_AutoCompleteExtender" runat="server" CompletionInterval="10"
                    CompletionSetCount="20" MinimumPrefixLength="1" ServiceMethod="Jct_Payroll_City_List"
                    CompletionListCssClass="AutoExtender" ServicePath="~/WebService.asmx" CompletionListElementID="divwidth"
                    CompletionListHighlightedItemCssClass="AutoExtenderHighlight" CompletionListItemCssClass="AutoExtenderList"
                    TargetControlID="txtcity">
                </cc1:AutoCompleteExtender>
                <%--<asp:DropDownList ID="ddlCity" runat="server" 
                CssClass="combobox" Height="20px" Width="73px" >
                </asp:DropDownList>--%>
            </td>
            <td class="labelcells" style="width: 88px">
                &nbsp;
            </td>
            <td class="textcells" style="width: 14px">
                &nbsp;&nbsp;
            </td>
        </tr>
        <%-- <tr>
            <td class="labelcells" style="width: 164px">
                <asp:Label ID="Label20" runat="server" Text="State"></asp:Label>
            </td>
            <td class="NormalText" style="width: 349px">
                <asp:DropDownList ID="ddlstate" runat="server" AutoPostBack="True" CssClass="combobox"
                    DataSourceID="SqlDataSource1" DataTextField="state" DataValueField="state" Height="30px"
                    OnSelectedIndexChanged="ddlstate_SelectedIndexChanged" AppendDataBoundItems="True">
                    <asp:ListItem></asp:ListItem>
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:misjctdev %>"
                    SelectCommand="SELECT DISTINCT state FROM JCTGEN..JCT_EPOR_STATE_MASTER "></asp:SqlDataSource>
            </td>
          
        </tr>--%>
        <%--<tr>
            <td class="labelcells" style="width: 164px">
                &nbsp;<asp:Label ID="Label21" runat="server" Text="City"></asp:Label>
            </td>
            <td class="NormalText" style="width: 349px">
                <asp:DropDownList ID="ddlcity" size="5" runat="server" CssClass="combobox" Height="20px"
                    Width="100px" AutoPostBack="True" AppendDataBoundItems="True">
                    <asp:ListItem></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="labelcells" style="width: 88px">
                &nbsp;
            </td>
            <td class="textcells" style="width: 14px">
                &nbsp;&nbsp;
            </td>
        </tr>--%>
        <tr>
            <td class="labelcells" style="width: 164px">
                MobileNo.
            </td>
            <td class="textcells" style="width: 349px">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="TxtPri_Mobile" runat="server" CssClass="textbox" TabIndex="7" MaxLength="10"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="TxtPri_Mobile_FilteredTextBoxExtender" runat="server"
                            Enabled="True" TargetControlID="TxtPri_Mobile" ValidChars="0123456789">
                        </cc1:FilteredTextBoxExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells" style="width: 88px">
                &nbsp;
            </td>
            <td class="textcells" style="width: 14px">
                &nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                Primary LandlineNo
            </td>
            <td class="textcells" style="width: 14px">
                <asp:TextBox ID="txtlandline" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="txtlandline_FilteredTextBoxExtender" runat="server"
                    Enabled="True" TargetControlID="txtlandline" ValidChars="0123456789">
                </cc1:FilteredTextBoxExtender>
            </td>
            <td class="labelcells">
                Secondary LandlineNo
            </td>
            <td class="textcells" style="width: 14px">
                <asp:TextBox ID="TxtSecondaryLandline" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" Enabled="True"
                    TargetControlID="TxtSecondaryLandline" ValidChars="0123456789">
                </cc1:FilteredTextBoxExtender>
            </td>
        </tr>
        <tr>
            <td class="labelcells" style="width: 164px;">
                <asp:Label ID="Label53" runat="server" Text="Emai Id"></asp:Label>
            </td>
            <td class="textcells" style="width: 349px">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="TxtEmailID" runat="server" CssClass="textbox" Width="150px" MaxLength="30"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                            ControlToValidate="TxtEmailID" ErrorMessage="Input valid Internet URL!" ValidationGroup="A"></asp:RegularExpressionValidator>
                        <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" WatermarkCssClass="watermark"
                            WatermarkText="local-part@domain" TargetControlID="TxtEmailID">
                        </cc1:TextBoxWatermarkExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="labelcells" style="width: 88px;">
            </td>
            <td class="textcells" style="width: 14px;">
                &nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:LinkButton ID="lnkSave" runat="server" CssClass="buttonc" ValidationGroup="A"
                    OnClick="lnkSave_Click">Save</asp:LinkButton>
            </td>
        </tr>
    </table>
    <table class="mytable">
        <tr>
            <%--    <td class="tableheader">

                                   <asp:ImageButton ID="lmgbnkdetail" runat="server" 
                                       ImageUrl="~/OPS/Image/plus.png" />

                               </td>--%>
            <td class="tableheader" style="color: #008080">
                <asp:Image ID="imgbnk" runat="server" ImageUrl="~/Image/plus.png" Style="margin-right: 5px;" />
                Bank Details<cc1:CollapsiblePanelExtender ID="CollapsiblePanelExtender1" runat="server"
                    AutoExpand="True" CollapseControlID="imgbnk" CollapsedImage="~/Image/plus.png"
                    Collapsed="True" ExpandControlID="imgbnk" ScrollContents="false" AutoCollapse="False"
                    ExpandedImage="~/Image/minus.png" ImageControlID="imgbnk" ExpandDirection="Vertical"
                    TargetControlID="panel4">
                </cc1:CollapsiblePanelExtender>
            </td>
        </tr>
    </table>
    <asp:Panel ID="Panel4" Width="100%" runat="server" BorderStyle="Solid">
        <table class="mytable">
            <tr>
                <td>
                    <asp:GridView ID="grdDetail" runat="server" Width="100%" AutoGenerateColumns="False"
                        EnableModelValidation="True" OnRowDataBound="grdDetail_RowDataBound">
                        <AlternatingRowStyle CssClass="GridAI" />
                        <Columns>
                            <asp:TemplateField HeaderText="Select">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chk" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Bank Category">
                                <ItemTemplate>
                                    <asp:RadioButtonList ID="rblChoices" runat="server">
                                        <asp:ListItem Value="Primary" Text="Primary"></asp:ListItem>
                                        <asp:ListItem Value="Secondary" Text="Secondary"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="BankName" HeaderText="Bank" SortExpression="Bank" />
                            <asp:BoundField DataField="Bankcode" HeaderText="BankCode" SortExpression="BankCode" />
                            <asp:TemplateField HeaderText="AccountNum">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtAccnum" runat="server" CssClass="textbox" Width="150px" ></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="txtAccnum_FilteredTextBoxExtender" runat="server" 
                                        Enabled="True" TargetControlID="txtAccnum" ValidChars="0123456789">
                                    </cc1:FilteredTextBoxExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <HeaderStyle CssClass="GridHeader" />
                        <RowStyle CssClass="GridItem" />
                    </asp:GridView>
                    <tr>
                        <td class="buttonbackbar">
                            <asp:LinkButton ID="lnkbnksave" runat="server" CssClass="buttonc" OnClick="lnkbnksave_Click">Save</asp:LinkButton>
                        </td>
                    </tr>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
