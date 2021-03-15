<%@ Page Title="" Language="VB" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="false"
    CodeFile="Stock_Status_Marking.aspx.vb" Inherits="OPS_Stock_Status_Marking" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <table style="width: 100%;">
        <tr>
            <td class="tableheader">
                Excess Stock Marking (Transfer Bales)
            </td>
        </tr>
    </table>
    <table style="width: 100%;">
        <tr>
            <td colspan="4">
                Search Bales on the basis of :-
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Look In"></asp:Label>
            </td>
            <td colspan="2">
                <asp:UpdatePanel ID="UpdatePanel29" runat="server">
                    <ContentTemplate>
                        <asp:RadioButtonList ID="RdoStotckToSearch" runat="server" RepeatDirection="Horizontal"
                            AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="AreaName" 
                            DataValueField="AreaCode">
                            <asp:ListItem Selected="True">Fresh Stock</asp:ListItem>
                            <asp:ListItem>Transfered Stock</asp:ListItem>
                            <asp:ListItem>Held Stock</asp:ListItem>
                        </asp:RadioButtonList>                      <%--      SelectCommand="SELECT AreaName,AreaCode FROM dbo.Jct_Ops_SanctioNote_Area_Master WHERE AreaCode IN (1051,1050,1049) ORDER BY AreaCode desc  ">--%>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:misjctdev %>" SelectCommand="SELECT CASE CONVERT(VARCHAR(10),areacode) WHEN '1047' THEN 'Fresh Stock' else   AreaName END  AS AreaName,AreaCode FROM dbo.Jct_Ops_SanctioNote_Area_Master WHERE AreaCode IN (1047,1050,1049) ORDER BY AreaName  ">
                        </asp:SqlDataSource>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
            <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                    <ContentTemplate>
                    <asp:Label ID="lblSanctionID" runat="server" Font-Size="Medium" 
                            ForeColor="#CC3300" ></asp:Label>
                    </ContentTemplate>
                    </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Lbl_Search_SaleOrder" runat="server" Text="Sale Order"></asp:Label>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel24" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtSearchSaleOrder" runat="server" CssClass="textbox" ValidationGroup="SearchGroup"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                <asp:Label ID="Lbl_Shade" runat="server" Text="BaleNo"></asp:Label>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel25" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtSearchShade" runat="server" CssClass="textbox" ValidationGroup="SearchGroup"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblValue1" runat="server">Sort</asp:Label>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtSearchSort" runat="server" CssClass="textbox" ValidationGroup="SearchGroup"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                <asp:Label ID="lblValue2" runat="server">Variant</asp:Label>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtSearchVariant" runat="server" CssClass="textbox" ValidationGroup="SearchGroup"></asp:TextBox>
                        <%--   <asp:RequiredFieldValidator ID="ReqdVariant" runat="server" ControlToValidate="txtSearchVariant"
                                            Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="SearchGroup"></asp:RequiredFieldValidator>--%>
                        <asp:LinkButton ID="CmdSearchData" runat="server" CssClass="searchbluesmall" Height="17px"
                            Width="16px" ValidationGroup="SearchGroup"></asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:UpdatePanel ID="UpdatePanel33" runat="server" Visible="false">
                <ContentTemplate>
                 <asp:TextBox ID="txtRequest" runat="server" CssClass="textbox"></asp:TextBox>
                    &nbsp;<asp:LinkButton ID="cmdGetRequestDEtail" runat="server">Search</asp:LinkButton>
                </ContentTemplate>
                </asp:UpdatePanel>
               
            </td>
        </tr>
    </table>
    <table style="width: 100%;">
        <tr>
            <td colspan="2">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                    <ProgressTemplate>
                        <asp:Image ID="ImageProg" runat="server" ImageUrl="~/Image/Progress02.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
        </tr>
        <tr>
            <td style="width: 90%">
                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="Panel5" runat="server" Height="300px" ScrollBars="Both">
                        <asp:GridView ID="GrdPackedForOrder" runat="server" EnableModelValidation="True"
                            ShowFooter="True" Width="100%">
                            <Columns>
                                <asp:TemplateField HeaderText="Sel">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="ChkOrderItems" runat="server" Checked="true" />
                                    </ItemTemplate>
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="ChkOrderSelAll" OnCheckedChanged="ChkOrderSelAll_CheckedChanged"
                                            runat="server" AutoPostBack="True" />
                                    </HeaderTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate>
                                No Bales Packed for&nbsp; Source Order..
                            </EmptyDataTemplate>
                            <HeaderStyle CssClass="GridHeader" />
                        </asp:GridView>
                        </asp:Panel>
                        
                        <asp:GridView ID="GrdTempValuesBaleDEtail" runat="server" 
                            AutoGenerateColumns="true" EnableModelValidation="True" ShowFooter="True" 
                            Width="100%">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="ChkDelete0" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <HeaderStyle CssClass="GridHeader" />
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td align="right" style="width: 2%" valign="top">
                <table style="width: 10%;">
                    <tr>
                        <td>

                <asp:UpdatePanel ID="UpdatePanel27" runat="server">
                    <ContentTemplate>
                        <%--  <asp:LinkButton ID="CmdAddItem" runat="server" Font-Size="Larger">+</asp:LinkButton>--%>
                        <asp:ImageButton ID="imgAddRow" runat="server" CommandName="Add" ImageUrl="~/Image/Icons/Action/iPhoneAdd.png"
                            ToolTip="Click to Add More Rows" ValidationGroup="a" Width="24px" />
                        &nbsp;
                        <br />
                        <asp:ImageButton ID="imgClear" runat="server" CommandName="Add" 
                            ImageUrl="~/Image/Icons/Action/iPhoneCross.png" 
                            ToolTip="Click to Remove all data for this Session" ValidationGroup="a" 
                            Width="24px" />
                    </ContentTemplate>
                </asp:UpdatePanel>

                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                <asp:UpdatePanel ID="UpdatePanel32" runat="server">
                    <ContentTemplate>
                        <%--     <asp:LinkButton ID="cmdDeleteRows" runat="server" CssClass="btncross" Height="21px"
                            ToolTip="Click To Clear All Selected Items" Width="24px"></asp:LinkButton>--%>
                        <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandName="Delete"
                            ImageUrl="~/OPS/Image/iPhone_Delete_icon.png" 
                            ToolTip="Select &amp; Click this buton to remove selected bales from " />
                    </ContentTemplate>
                </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table style="width: 100%;">
        <tr>
            <td>
            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                <ContentTemplate>
   
                    <asp:Panel ID="Panel4" runat="server">
               <table style="width: 100%;" class="tableback">
                    <tr>
                        <td valign="top">
                            <table style="width: 100%;">
                                <tr>
                                    <td>
                                        <asp:Label ID="Label5" runat="server" Text="Subject"></asp:Label>
                                    </td>
                                    <td colspan="3">
                                        <asp:UpdatePanel ID="UpdatePanel31" runat="server">
                                            <ContentTemplate>
                                              <%--  <asp:TextBox ID="txtSubject" runat="server" CssClass="textbox" Width="200px" MaxLength="100"></asp:TextBox>--%>
                                                
                                                <asp:DropDownList ID="ddlSubject" runat="server" CssClass="combobox" 
                                                    DataSourceID="SqlDataSource2" DataTextField="Subject" DataValueField="Subject" 
                                                    ValidationGroup="GrpApply">
                                                </asp:DropDownList>
                                                <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                                                    ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                                                    
                                                    SelectCommand="SELECT  '' AS Subject union SELECT Subjects FROM Jct_Ops_Excess_Stock_Subjects WHERE STATUS='A' and areacode=@Area ORDER BY subject">
                                                    <SelectParameters>
                                                        <asp:ControlParameter ControlID="RdoStotckToSearch" Name="Area" 
                                                            PropertyName="SelectedValue" />
                                                    </SelectParameters>
                                                </asp:SqlDataSource>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlSubject"
                                                    Display="Dynamic" ErrorMessage="* Required" SetFocusOnError="True" 
                                                    ValidationGroup="GrpApply"></asp:RequiredFieldValidator>

                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="middle">
                                        Description
                                    </td>
                                    <td colspan="3">
                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <asp:TextBox ID="txtDescription" runat="server" CssClass="textbox" Height="200px"
                                                    Width="80%" TextMode="MultiLine" MaxLength="2000"></asp:TextBox>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblOffered" runat="server" Text="Offered To Customer"></asp:Label>
                                    </td>
                                    <td>
                                    <asp:DropDownList ID="ddlOfferedToCust" runat="server" CssClass="combobox"  >
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>Yes</asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="reqdOfferedToCust" runat="server" 
                                            ControlToValidate="ddlOfferedToCust" Display="Dynamic" ErrorMessage="*" 
                                            SetFocusOnError="True" ValidationGroup="GrpApply"></asp:RequiredFieldValidator>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" class="GridHeader">
                            <asp:Label ID="Label3" runat="server" Font-Size="Small" Text="Authorizing Hierarchy"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <table style="width: 100%;">
                                <tr>
                                    <td colspan="1" valign="top" class="labelcells_s">
                                        <asp:Label ID="Label4" runat="server" Text="Plant"></asp:Label>
                                    </td>
                                    <td colspan="2" valign="top" class="textcells_s">
                                        <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlplant" runat="server" CssClass="combobox" AutoPostBack="True">
                                                    <asp:ListItem>Cotton</asp:ListItem>
                                                    <asp:ListItem>Taffeta</asp:ListItem>
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="1" valign="top">
                                        Add Level
                                    </td>
                                    <td colspan="2" valign="top">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3" valign="top">
                                        <asp:UpdatePanel ID="UpdatePanel8" runat="server" RenderMode="Inline">
                                            <ContentTemplate>
                                                <asp:TextBox ID="txtEmployee" runat="server" CssClass="textbox" Width="200px"></asp:TextBox>
                                                <asp:LinkButton ID="cmdSearch" runat="server" CssClass="searchbluesmall" Height="16px"
                                                    Width="16px"></asp:LinkButton>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="50%">
                                        <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                            <ContentTemplate>
                                                <asp:Panel ID="Panel3" runat="server" Height="200px" ScrollBars="Both" Width="450px">
                                                    <asp:CheckBoxList ID="ChkEmpList" runat="server" CellPadding="0" CellSpacing="0"
                                                        Height="99px" RepeatColumns="1" Width="502px">
                                                    </asp:CheckBoxList>
                                                </asp:Panel>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                    <td>
                                        <asp:LinkButton ID="btnTransfer" runat="server">Level</asp:LinkButton>
                                        <br />
                                        <br />
                                        <%--<%@ Register Assembly="com.flajaxian.FileUploader" Namespace="com.flajaxian" TagPrefix="cc3" %>--%>
                                        <asp:LinkButton ID="cmdCC" runat="server">Notify</asp:LinkButton>
                                        <br />
                                        <br />
                                        <asp:LinkButton ID="imgRemoveItem" runat="server" Height="21px" ToolTip="Click To Clear All Selected Items"
                                            Width="24px" CssClass="btncross">X</asp:LinkButton>
                                        <br />
                                    </td>
                                    <td valign="top" width="50%">
                                        <asp:UpdatePanel ID="UpdatePanel10" runat="server" RenderMode="Inline" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                Level<br />
                                                <asp:CheckBoxList ID="ChkDynamicListing" runat="server">
                                                </asp:CheckBoxList>
                                                <hr />
                                                Notify<br />
                                                <asp:CheckBoxList ID="chkNotify" runat="server">
                                                </asp:CheckBoxList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <asp:UpdatePanel ID="UpdatePanel30" runat="server">
                                            <ContentTemplate>
                                                <asp:GridView ID="GrdEmployee" runat="server" Width="99%">
                                                    <PagerStyle CssClass="PagerStyle" />
                                                    <AlternatingRowStyle CssClass="GridAI" />
                                                    <EmptyDataTemplate>
                                                        No Data Found...! ! !
                                                    </EmptyDataTemplate>
                                                    <HeaderStyle CssClass="GridHeader" />
                                                    <RowStyle CssClass="GridItem" />
                                                    <SelectedRowStyle CssClass="GridRowGreen" />
                                                </asp:GridView>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
           
                    </asp:Panel>
                



                </ContentTemplate>
                </asp:UpdatePanel>




            </td>
        </tr>
        <tr>
            <td class="buttonbackbar">
                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                    <ContentTemplate>
                        <asp:LinkButton ID="CmdTransfer" runat="server" BorderStyle="None" 
                            CssClass="buttonc" ValidationGroup="GrpApply">Transfer</asp:LinkButton>
                        &nbsp;<asp:LinkButton ID="CmdClear" runat="server" BorderStyle="None" CssClass="buttonc">Clear</asp:LinkButton>
                        &nbsp; <asp:LinkButton ID="cmdSendMail" runat="server" Visible="False">Sendmail</asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="Panel2" runat="server">
                            <table style="width: 100%;" class="tableback">
                                <tr>
                                    <td class="tableheader" colspan="5">
                                        Transfered Bales...
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="5">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="5">
                                        <asp:Panel ID="Panel1" runat="server" Height="300px" ScrollBars="Both" Width="90%">
                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                <ContentTemplate>
                                                    <asp:GridView ID="GrdHeldBales" runat="server" EnableModelValidation="True" ShowFooter="True"
                                                        Width="100%">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Sel">
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="ChkOrderItems0" runat="server" Checked="true" />
                                                                </ItemTemplate>
                                                                <HeaderTemplate>
                                                                    <asp:CheckBox ID="ChkOrderSelAll0" OnCheckedChanged="ChkOrderSelAll0_CheckedChanged"
                                                                        runat="server" AutoPostBack="True" />
                                                                </HeaderTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <EmptyDataTemplate>
                                                            No Record Found....
                                                        </EmptyDataTemplate>
                                                        <HeaderStyle CssClass="GridHeader" />
                                                    </asp:GridView>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label1" runat="server" Text="Action"></asp:Label>
                                    </td>
                                    <td colspan="4">
                                        <%--                <asp:UpdatePanel ID="UpdatePanel26" runat="server">
                    <ContentTemplate>--%>
                                        <asp:DropDownList ID="ddlStatus" runat="server" CssClass="combobox" AutoPostBack="True">
                                            <asp:ListItem>Release</asp:ListItem>
                                            <asp:ListItem>Hold</asp:ListItem>
                                        </asp:DropDownList>
                                        <%--                    </ContentTemplate>
                </asp:UpdatePanel>--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblHold" runat="server" Text="Hold Upto"></asp:Label>
                                    </td>
                                    <td style="height: 15px" colspan="4">
                                        <%--<asp:UpdatePanel ID="UpdatePanel27" runat="server" RenderMode="Inline">
                <ContentTemplate>--%>
                                        <asp:TextBox ID="txtHoldUpto" runat="server" CssClass="textbox" Width="60px" ValidationGroup="GrpRelease"></asp:TextBox>
                                        <cc1:CalendarExtender ID="txtDateFrom_CalendarExtender" runat="server" TargetControlID="txtHoldUpto">
                                        </cc1:CalendarExtender>
                                        <cc1:MaskedEditValidator ID="MEV1" runat="server" ControlExtender="MEE1" ControlToValidate="txtHoldUpto"
                                            Display="Dynamic" InvalidValueMessage="Invalid" IsValidEmpty="False" EmptyValueMessage="*"
                                            TooltipMessage="MM/DD/YYYY" Width="114px" ValidationGroup="GrpRelease"></cc1:MaskedEditValidator>
                                        <cc1:MaskedEditExtender ID="MEE1" runat="server" Mask="99/99/9999" MaskType="Date"
                                            TargetControlID="txtHoldUpto">
                                        </cc1:MaskedEditExtender>
                                        <%-- </ContentTemplate>
                </asp:UpdatePanel>--%>
                                    </td>
                                </tr>
                                <%--<td>

        </td>
            <td colspan="4">
            </td>
        </tr>--%>
                                <tr>
                                    <td style="height: 15px">
                                        <%--         <asp:UpdatePanel ID="UpdHoldLabel0" runat="server" RenderMode="Inline">
            <ContentTemplate>--%>
                                        <asp:Label ID="lblResonForHolding" runat="server" Text="Reason For Holding"></asp:Label>
                                        <%-- </ContentTemplate>
         </asp:UpdatePanel>--%>
                                    </td>
                                    <td style="height: 15px" colspan="4">
                                        <%-- <asp:UpdatePanel ID="UpdatePanel30" runat="server" RenderMode="Inline">
                <ContentTemplate>--%>
                                        <asp:TextBox ID="txtReasonForHolding" runat="server" CssClass="textbox" Width="150px"
                                            ValidationGroup="GrpRelease" MaxLength="150"></asp:TextBox>
                                        <%--</ContentTemplate>
                </asp:UpdatePanel>--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 15px">
                                        Remarks
                                    </td>
                                    <td style="height: 15px" colspan="4">
                                        <asp:TextBox ID="txtRemarks" runat="server" CssClass="textbox" Width="150px" ValidationGroup="GrpRelease"
                                            MaxLength="300"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="5" style="height: 15px">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td class="buttonbackbar" colspan="5">
                                        <%--<asp:UpdatePanel ID="UpdatePanel28" runat="server">
                    <ContentTemplate>--%>
                                        <asp:LinkButton ID="CmdApply" runat="server" BorderStyle="None" CssClass="buttonc"
                                            ValidationGroup="GrpRelease">Apply</asp:LinkButton>
                                        &nbsp;<asp:LinkButton ID="CmdHeldClear" runat="server" BorderStyle="None" CssClass="buttonc">Clear</asp:LinkButton>
                                        <%--</ContentTemplate>
                </asp:UpdatePanel>--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="5">
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
