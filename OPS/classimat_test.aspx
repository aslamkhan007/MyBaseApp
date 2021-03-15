<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true" CodeFile="classimat_test.aspx.cs" Inherits="OPS_classimat_test" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register TagPrefix="uc1" TagName="FMsg" Src="~/FlashMessage.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%">
        <tr>
            <td class="tableheader" colspan="4">
                Classimat Test Entry
                <asp:HyperLink ID="hlnk" runat="server" NavigateUrl="~/OPS/reportsecond.aspx">Fd faults</asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:ImageButton ID="imgadd" runat="server" 
                    ImageUrl="~/Image/Icons/Action/document_add.png" onclick="ImageButton1_Click" 
                    Width="32px" ToolTip="add" />
                <asp:ImageButton ID="imgupdate" runat="server" Height="36px" 
                    ImageUrl="~/Image/Icons/Action/document_save.png" onclick="imgupdate_Click" Width="32px" 
                    ToolTip="update" />
                <asp:ImageButton ID="imgdelete" runat="server" 
                    ImageUrl="~/Image/Icons/Action/document_delete.png" onclick="imgdelete_Click" 
                    style="margin-left: 0px" Width="32px" ToolTip="delete" />
                <asp:ImageButton ID="imgreset" runat="server"
                    ImageUrl="~/Image/Icons/Action/Refresh.png" onclick="imgreset_Click" Width="32px" 
                    ToolTip="refresh" />
                <asp:ImageButton ID="cnf_img" runat="server" 
                    ImageUrl="~/Image/Icons/Action/Authorise.png" onclick="ImageButton1_Click1" 
                    Width="32px" ToolTip="confirm" />
            </td>
        </tr>
        <tr>
            <td>
                </td>
            <td>
                </td>
            <td>
                </td>
            <td>
                <asp:LinkButton ID="lnkreport" runat="server" CssClass="buttonc" 
                    onclick="lnkreport_Click">ViewReport</asp:LinkButton>
                </td>
        </tr>
        <tr>
            <td colspan="4">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" >
                Date</td>
            <td class="NormalText">
                <asp:TextBox ID="txtdate" runat="server" CssClass="textbox" 
                    EnableViewState="False" ToolTip="select date"></asp:TextBox>
                <cc1:CalendarExtender ID="txtdate_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txtdate">
                </cc1:CalendarExtender>
            </td>
            <td class="NormalText">
                Count</td>
            <td class="NormalText">
                <asp:TextBox ID="txtcount" runat="server" CssClass="textbox" 
                    EnableViewState="False" ToolTip="select count "></asp:TextBox>
                <cc1:AutoCompleteExtender ID="txtcount_AutoCompleteExtender" runat="server" 
                   
                    FirstRowSelected="True" ServiceMethod="faults" 
                    TargetControlID="txtcount" UseContextKey="True" 
                    CompletionInterval="100" CompletionSetCount="100" 
                    ServicePath="~/webservice.asmx" 
                    CompletionListCssClass="autocomplete_completionListElement">

       
                </cc1:AutoCompleteExtender>
            </td>
        </tr>
        <tr>
            <td class="NormalText" >
                Source</td>
            <td class="NormalText">
                <asp:TextBox ID="txtsource" runat="server" CssClass="textbox" 
                    EnableViewState="False"></asp:TextBox>
            </td>
            <td class="NormalText">
                Length</td>
            <td class="NormalText">
                <asp:TextBox ID="txtlength" runat="server" CssClass="textbox" 
                    EnableViewState="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="NormalText" >
                Weight</td>
            <td class="NormalText">
                <asp:TextBox ID="txtweight" runat="server" CssClass="textbox" 
                    EnableViewState="False"></asp:TextBox>
                   
            </td>
            <td class="NormalText">
                AllFaultPerKg</td>
            <td class="NormalText">
                <asp:TextBox ID="txtallfault" runat="server" CssClass="textbox" 
                    EnableViewState="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="height: 23px" >
                MajorShotThick</td>
            <td class="NormalText" style="height: 23px">
                <asp:TextBox ID="txtmajorshot" runat="server" CssClass="textbox" 
                    EnableViewState="False"></asp:TextBox>
            </td>
            <td class="NormalText" style="height: 23px">
                ShortThick</td>
            <td class="NormalText" style="height: 23px">
                <asp:TextBox ID="txtshortthick" runat="server" CssClass="textbox" 
                    EnableViewState="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="NormalText" >
                LongThick</td>
            <td class="NormalText">
                <asp:TextBox ID="txtlongthick" runat="server" CssClass="textbox" 
                    EnableViewState="False"></asp:TextBox>
            </td>
            <td class="NormalText">
                ThinFault</td>
            <td class="NormalText">
                <asp:TextBox ID="txtthinfault" runat="server" CssClass="textbox" 
                    EnableViewState="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="NormalText" >
                MajorThinFault</td>
            <td class="NormalText">
                <asp:TextBox ID="txtmajorthin" runat="server" CssClass="textbox" 
                    EnableViewState="False"></asp:TextBox>
            </td>
            <td class="NormalText">
                Remarks</td>
            <td class="NormalText">
                <asp:TextBox ID="txtremarks" runat="server" CssClass="textbox" 
                    EnableViewState="False" 
                    ToolTip="enter remarks not more than 100 characters"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="NormalText" >
                MachineNo</td>
            <td >
                <asp:TextBox ID="txtmachine" runat="server" CssClass="textbox" 
                    ToolTip="select machine no"></asp:TextBox>
                <cc1:AutoCompleteExtender ID="txtmachine_AutoCompleteExtender" runat="server" 
                    CompletionInterval="100" 
                    CompletionListCssClass="autocomplete_completionListElement" 
                    CompletionSetCount="100" MinimumPrefixLength="1" ServiceMethod="machineno" 
                    ServicePath="~/webservice.asmx" TargetControlID="txtmachine">
                </cc1:AutoCompleteExtender>
            </td>
            <td >
                &nbsp;</td>
            <td >
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="4" >
                <asp:Label ID="lbid" runat="server" Visible="False"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </td>
        </tr>
        </table>
    <table style="width: 100%">
        <tr>
            <td colspan="4" >
                <asp:GridView ID="grdDetail" runat="server" AutoGenerateSelectButton="True" 
                    onselectedindexchanged="grdDetail_SelectedIndexChanged" Width="100%" 
                    EmptyDataText="no record found">
                    <AlternatingRowStyle CssClass="GridAI" />
                    <HeaderStyle CssClass="GridHeader" />
                    <PagerStyle CssClass="PageStyle" />
                    <RowStyle CssClass="GridItem" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td >
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

