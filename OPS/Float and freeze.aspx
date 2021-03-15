﻿<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true" CodeFile="Float and freeze.aspx.cs" Inherits="OPS_Float_and_freeze" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

 <table style="width: 100%;" class="tableback">
        <tr>
            <td valign="top" class="tableheader">
                <asp:Label ID="Label16" runat="server" Text="Send Request For Authorization"></asp:Label>
            </td>
        </tr>
        <tr>
            <td valign="top" class="NormalText">
                <asp:RadioButtonList ID="rdlst" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="RadioButtonList1_SelectedIndexChanged" 
                    RepeatDirection="Horizontal" CssClass="combobox">
                    <asp:ListItem Selected="True">Non wardrode</asp:ListItem>
                    <asp:ListItem>WardRobe</asp:ListItem>
                    <asp:ListItem Value="Yarn ">Yarn Purchase</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td valign="top" class="NormalText">
                <asp:Panel ID="Panel4" runat="server" ScrollBars="Both" Width="980px">
                    <asp:GridView ID="grdDetail" runat="server" 
    AutoGenerateSelectButton="True" onselectedindexchanged="grdDetail_SelectedIndexChanged" 
                        Width="100%" DataKeyNames="AreaCode,plant,usercode">
                        <AlternatingRowStyle CssClass="GridAI" />
                        <HeaderStyle CssClass="GridHeader" />
                        <PagerStyle CssClass="PageStyle" />
                        <RowStyle CssClass="GridItem" />
                        <SelectedRowStyle CssClass="GridRowGreen" />
                    </asp:GridView>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td valign="top" class="NormalText">
                <asp:Label ID="lbreq" runat="server" Text="Incomplete Request"></asp:Label>
            </td>
        </tr>
        <tr>
            <td valign="top" class="NormalText">
                <asp:GridView ID="grdDetailIn" runat="server" Width="90%" Visible="False">
                    <HeaderStyle CssClass="GridHeader" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td valign="top" class="NormalText">
                <asp:GridView ID="grdDetailyr" runat="server" EnableModelValidation="True">
                    <AlternatingRowStyle CssClass="GridAI" />
                    <HeaderStyle CssClass="GridHeader" />
                    <PagerStyle CssClass="Pagestyle" />
                    <RowStyle CssClass="GridItem" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td valign="top" class="NormalText">
                <asp:Label ID="Label1" runat="server" Font-Size="Small" Text="Authorizing Hierarchy"></asp:Label>
            </td>
        </tr>
        <tr>
            <td valign="top" class="NormalText">
                Add Level
            </td>
        </tr>
        <tr>
            <td valign="top" class="NormalText">
                <table style="width: 100%;">
                    <tr>
                        <td colspan="3" valign="top" class="NormalText">
                            <asp:UpdatePanel ID="UpdatePanel8" runat="server" RenderMode="Inline">
                                <ContentTemplate>
                                    <asp:TextBox ID="txtEmployee" runat="server" CssClass="textbox" Width="200px"></asp:TextBox>
                                    <asp:LinkButton ID="cmdSearch" runat="server" CssClass="searchbluesmall" Height="16px"
                                        Width="16px" onclick="cmdSearch_Click"></asp:LinkButton>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td width="50%" class="NormalText">
                            <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                <ContentTemplate>
                                    <asp:Panel ID="Panel2" runat="server" Height="200px" ScrollBars="Both" Width="450px">
                                        <asp:CheckBoxList ID="ChkEmpList" runat="server" CellPadding="0" CellSpacing="0"
                                            Height="99px" RepeatColumns="1" Width="502px">
                                        </asp:CheckBoxList>
                                    </asp:Panel>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                        <td class="NormalText">
                            <asp:LinkButton ID="btnTransfer" runat="server" onclick="btnTransfer_Click">Level</asp:LinkButton>
                            <br />
                            <br />
                            <%-- <tr>
            <td valign="top" width="120">
                &nbsp;
                Attachment (if any)</td>
            <td>
                <asp:FileUpload ID="FileUpload1" runat="server" CssClass="textbox" 
                    Height="22px" Width="318px" />
                <asp:ImageButton ID="ibtAddFile" runat="server" 
                    ImageUrl="~/Image/Icons/Action/iPhoneAdd.png" ToolTip="Add Item to List" 
                    Width="25px" ValidationGroup="a" />
                    &nbsp;<br />
                <asp:HyperLink ID="ImgNameLbL" runat="server" Visible="False" Width="376px">Image Name</asp:HyperLink>
            </td>
        </tr>--%>
                            <asp:LinkButton ID="cmdCC" runat="server" onclick="cmdCC_Click">Notify</asp:LinkButton>
                            <br />
                            <br />
                            <asp:LinkButton ID="imgRemoveItem" runat="server" Height="21px" ToolTip="Click To Clear All Selected Items"
                                Width="24px" CssClass="btncross" onclick="imgRemoveItem_Click">X</asp:LinkButton>
                            <br />
                        </td>
                        <td valign="top" width="50%" class="NormalText">
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
                        <td class="NormalText">
                            &nbsp;</td>
                        <td class="NormalText">
                            &nbsp;</td>
                        <td class="NormalText">
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table style="width: 100%;" class="tableback">
        <tr>
            <td valign="top" class="NormalText">
                <%-- <tr>
            <td valign="top" width="120">
                &nbsp;
                Attachment (if any)</td>
            <td>
                <asp:FileUpload ID="FileUpload1" runat="server" CssClass="textbox" 
                    Height="22px" Width="318px" />
                <asp:ImageButton ID="ibtAddFile" runat="server" 
                    ImageUrl="~/Image/Icons/Action/iPhoneAdd.png" ToolTip="Add Item to List" 
                    Width="25px" ValidationGroup="a" />
                    &nbsp;<br />
                <asp:HyperLink ID="ImgNameLbL" runat="server" Visible="False" Width="376px">Image Name</asp:HyperLink>
            </td>
        </tr>--%>
                <asp:UpdatePanel ID="UpdatePanel11" runat="server" UpdateMode="always">
                    <ContentTemplate>
                        <asp:Panel ID="Panel3" runat="server" Height="150px" ScrollBars="Vertical" 
                            Width="980px">
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
                        </asp:Panel>
                    </ContentTemplate>
                    
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    <table style="width: 100%; display:none;" class="tableback">
        <tr>
            <td class="tableback">
                Attachments..
            </td>
        </tr>
        <tr>
            <td valign="top" class="NormalText">
                <%-- <tr>
            <td valign="top" width="120">
                &nbsp;
                Attachment (if any)</td>
            <td>
                <asp:FileUpload ID="FileUpload1" runat="server" CssClass="textbox" 
                    Height="22px" Width="318px" />
                <asp:ImageButton ID="ibtAddFile" runat="server" 
                    ImageUrl="~/Image/Icons/Action/iPhoneAdd.png" ToolTip="Add Item to List" 
                    Width="25px" ValidationGroup="a" />
                    &nbsp;<br />
                <asp:HyperLink ID="ImgNameLbL" runat="server" Visible="False" Width="376px">Image Name</asp:HyperLink>
            </td>
        </tr>--%>
                <span style="font-family: Arial">Click to add files</span>&nbsp;&nbsp;
                <input id="Button2" onclick="AddFileUpload()" type="button" value="add" onclick="return Button2_onclick()" />
                <div id="FileUploadContainer">
                    <!--FileUpload Controls will be added here -->
                </div>
                <%-- <tr>
            <td valign="top" width="120">
                &nbsp;
                Attachment (if any)</td>
            <td>
                <asp:FileUpload ID="FileUpload1" runat="server" CssClass="textbox" 
                    Height="22px" Width="318px" />
                <asp:ImageButton ID="ibtAddFile" runat="server" 
                    ImageUrl="~/Image/Icons/Action/iPhoneAdd.png" ToolTip="Add Item to List" 
                    Width="25px" ValidationGroup="a" />
                    &nbsp;<br />
                <asp:HyperLink ID="ImgNameLbL" runat="server" Visible="False" Width="376px">Image Name</asp:HyperLink>
            </td>
        </tr>--%>
            </td>
        </tr>
    </table>
    <table style="width: 100%;" class="tableback">
        <tr>
            <td valign="top" class="buttonbackbar">
                <asp:LinkButton ID="cmdApply" runat="server" BorderStyle="None" CssClass="buttonc"
                    ValidationGroup="GrpApply" onclick="cmdApply_Click">Apply</asp:LinkButton>
                &nbsp;<asp:LinkButton ID="cmdReset" runat="server" BorderStyle="None" 
                    CssClass="buttonc" onclick="cmdReset_Click">Reset</asp:LinkButton>
            </td>
        </tr>
    </table>
    <table style="width: 100%;" class="tableback">
        <tr>
            <td valign="top" colspan="3" class="NormalText">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td valign="top" class="NormalText">
                &nbsp;
            </td>
            <td class="NormalText">
                &nbsp;
            </td>
            <td class="NormalText">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td valign="top" class="NormalText">
                &nbsp;
            </td>
            <td class="NormalText">
                &nbsp;
            </td>
            <td class="NormalText">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td valign="top" colspan="3" class="NormalText">
                &nbsp;
                <asp:FileUpload ID="FileUpload1" runat="server" Height="0px" Width="0px" />
                &nbsp; &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>




