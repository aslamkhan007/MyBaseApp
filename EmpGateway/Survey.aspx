<%@ Page Language="VB" MasterPageFile="MasterPage.master" AutoEventWireup="false"
    CodeFile="Survey.aspx.vb" Inherits="Survey" Title="Rate Surveys" MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%">
        <tr class="tableheader">
            <td colspan="2">
                <asp:Label ID="Label6" runat="server" Text="Rate Surveys" Width="120px"></asp:Label>
            </td>
        </tr>
        <tr style="display:none" id="row">
            <td class="labelcells">
                <asp:Label ID="lblSurveyType" runat="server" Text="Survey Type" Width="96px" Visible="False"></asp:Label>
            </td>
            <td class="textcells" style="display:none">
                <asp:DropDownList ID="LstType" runat="server" Width="96px" AutoPostBack="True" Visible="False"
                    CssClass="combobox">
                    <asp:ListItem>Customer</asp:ListItem>
                    <asp:ListItem>Employee</asp:ListItem>
                    <asp:ListItem Enabled="False">Vendor</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                <asp:Label ID="Label7" runat="server" Text="Customer Name Or Customer Code" Width="96px"
                    Visible="False"></asp:Label>
            </td>
            <td class="textcells">
                <asp:TextBox ID="txtSearch" runat="server" AutoPostBack="True" CssClass="textbox" Width="224px" Visible="False"></asp:TextBox>
                <asp:ListBox ID="LstName" runat="server" AutoPostBack="True" TabIndex="3" Visible="False" CssClass="combobox"
                    Width="384px"></asp:ListBox>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                <asp:Label ID="Label1" runat="server" Text="Survey Subject" Width="96px" ></asp:Label>
            </td>
            <td class="textcells">
                <asp:DropDownList ID="SurveyList" runat="server" Width="496px" AutoPostBack="True"
                    CssClass="combobox">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="labelcells" align="center">
                <asp:Label ID="Label16" runat="server" Text="Q.No. "></asp:Label>
                <asp:Label ID="lblQno" runat="server" Text="0"></asp:Label>
                            </td>
            <td class="labelcells">
                <asp:Label ID="LblQuest" runat="server" Text="Questions Comes Here" Width="496px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="labelcells" colspan="2">
                <asp:Label ID="LblRemarks" runat="server" ForeColor="#CC3300" 
                    Text="*Please Select Option to Move these Up or Down by clicking Respective Button Below.. &lt;/br&gt;**You can also directly Move Item at desired location by selecting position and then Clicking Move At Button.." 
                    Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="labelcells" style="height: 82px">
                <asp:Label ID="Label3" runat="server" Text="Your Ratings" Width="96px" Visible="False"></asp:Label>
            </td>
            <td class="labelcells" style="height: 82px">
                <table style="width:100%;">
                    <tr>
                        <td valign="top">
                            <asp:BulletedList ID="BLSeq" runat="server" 
                                BulletImageUrl="~/Image/BlWhite.PNG" BulletStyle="CustomImage" 
                                CssClass="combobox" Width="23px">
                            </asp:BulletedList>
                        </td>
                        <td>
                <asp:RadioButtonList ID="RdoList" runat="server" Width="401px" CssClass="combobox" 
                                Visible="False">
                </asp:RadioButtonList>
                <asp:CheckBoxList ID="ChkList" runat="server" CssClass="combobox" 
                    Visible="False" Width="416px">
                </asp:CheckBoxList>
                        </td>
                    </tr>
                </table>
                <br />
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                &nbsp;</td>
            <td class="labelcells">
                <table style="width:342px;" width="350px">
                    <tr>
                        <td>
                            <asp:LinkButton ID="LnkMoveUp" runat="server" CssClass="buttonc" 
                                Visible="False" 
                                ToolTip="Check Items and click this to Move selected Items Up..">Move Up</asp:LinkButton>
                        </td>
                        <td>
                            <asp:LinkButton ID="LnkMoveDn" runat="server" CssClass="buttonc" 
                                Visible="False" 
                                ToolTip="Check Items and click this to Move selected Items Down..">Move Down</asp:LinkButton>
                        </td>
                        <td>
                            <asp:LinkButton ID="LnkMoveAt" runat="server" CssClass="buttonc" 
                                ToolTip="Click this to Move Selected Items at position defined aside.">Move At</asp:LinkButton>
                            <asp:DropDownList ID="DrpMoveAt" runat="server" CssClass="combobox">
                            </asp:DropDownList>
                        </td>
                        
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="labelcells">
                <asp:Label ID="Label2" runat="server" Text="Question Image" Width="96px" ></asp:Label>
            </td>
            <td rowspan="1" >
                <ew:CollapsablePanel ID="CollapsablePanel1" runat="server" AllowSliding="True" Collapsed="True"
                    CollapseImageUrl="Image/UPARROW.JPG" CollapserAlign="Left" ExpandImageUrl="Image/DNARROW.JPG"
                    Height="88px" ScrollBars="Auto" SlideSpeed="10" Width="500px" 
                    >
                    <asp:Image ID="SurImage" runat="server" /></ew:CollapsablePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells" >
                <asp:Label ID="Label4" runat="server">Comments</asp:Label>
            </td>
            <td class="textcells">
                <asp:TextBox ID="txtComents" runat="server" Height="30px"
                    TextMode="MultiLine" Width="608px" cssclass="textbox"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2" class="buttonbackbar" >
                &nbsp;
                <asp:Button ID="ApplyBtn" runat="server" Text="Submit" CssClass="ButtonBack" 
                    BackColor="Black" />
                &nbsp;
                <asp:Button ID="ResetBtn" runat="server" Text="Reset" CssClass="ButtonBack" 
                    BackColor="Black" Enabled="False" Visible="False" />
            </td>
        </tr>
        <tr>
            <td colspan="2" class="buttonbackbar" >
                <asp:LinkButton ID="LnkFirst" runat="server" CssClass="buttonc">First</asp:LinkButton>
&nbsp;<asp:LinkButton ID="LnkPrevious" runat="server" CssClass="buttonc">Previous</asp:LinkButton>
&nbsp;<asp:LinkButton ID="LnkNext" runat="server" CssClass="buttonc">Next</asp:LinkButton>
&nbsp;<asp:LinkButton ID="LnkLast" runat="server" CssClass="buttonc">Last</asp:LinkButton>
            </td>
        </tr>
    </table>
</asp:Content>
