<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true" CodeFile="classimat_test_2.aspx.cs" Inherits="OPS_classimat_test_2" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%">
        <tr>
            <td class="tableheader" colspan="4">
                Classimate Test Report</td>
        </tr>
        <tr>
            <td class="NormalText">
                DateFrom</td>
            <td class="NormalText">
                <asp:TextBox ID="txtdatefrom" runat="server" CssClass="textbox" 
                    ontextchanged="txtdatefrom_TextChanged"></asp:TextBox>
             
                <cc1:CalendarExtender ID="txtdatefrom_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txtdatefrom">
                </cc1:CalendarExtender>
            </td>
            <td class="NormalText">
                DateTo</td>
            <td class="NormalText">
                <asp:TextBox ID="txtdateto" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txtdateto_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txtdateto">
                </cc1:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                Count</td>
            <td class="NormalText">
                <asp:TextBox ID="txtcount" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:AutoCompleteExtender ID="txtcount_AutoCompleteExtender" runat="server" 
                 FirstRowSelected="True" ServiceMethod="faults" 
                    TargetControlID="txtcount" UseContextKey="True" 
                    CompletionInterval="100" CompletionSetCount="100" 
                    ServicePath="~/webservice.asmx" 
                    CompletionListCssClass="autocomplete_completionListElement">

                </cc1:AutoCompleteExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtcount" ErrorMessage="cannot be blank" 
                    ondatabinding="lnkfetch_Click">*cannot be blank</asp:RequiredFieldValidator>
            </td>
            <td class="NormalText">
                source</td>
            <td class="NormalText">
                <asp:TextBox ID="txtsource" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                Faults</td>
            <td class="NormalText">
                <asp:DropDownList ID="ddlfdfualts" runat="server">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>AllFaults</asp:ListItem>
                    <asp:ListItem>Fd Faults</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:LinkButton ID="lnkfetch" runat="server" CssClass="buttonc" 
                    onclick="lnkfetch_Click">Fetch</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:ImageButton ID="excel1" runat="server" 
                            ImageUrl="~/OPS/Image/excelsmall.jpg" Visible="False" 
                            onclick="excel1_Click" />
                        <br />
                        <asp:GridView ID="grdDetail1" runat="server" Width="100%" 
                            EmptyDataText="No record found">
                            <AlternatingRowStyle CssClass="GridAI" />
                            <EmptyDataTemplate>
                                No Record Found....
                            </EmptyDataTemplate>
                            <HeaderStyle CssClass="GridHeader" />
                            <PagerStyle CssClass="PageStyle" />
                            <RowStyle CssClass="GridItem" />
                        </asp:GridView>
                        
                        <asp:GridView ID="grdDetail2" runat="server" Width="100%" 
                            EmptyDataText="no record found">
                            <AlternatingRowStyle CssClass="GridAI" />
                            <HeaderStyle CssClass="GridHeader" />
                            <PagerStyle CssClass="PageStlye" />
                            <RowStyle CssClass="GridItem" />
                        </asp:GridView>
                        <br />
                        <br />
                        
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="lnkfetch" EventName="Click" />
                        <asp:PostBackTrigger ControlID="excel1" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                    <asp:ImageButton ID="excel2" runat="server" 
                            ImageUrl="~/OPS/Image/excelsmall.jpg" Visible="False" 
                            onclick="excel2_Click" />
                        <br />
                    </ContentTemplate>
                     <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="lnkfetch" EventName="Click" />
                          <asp:PostBackTrigger ControlID="excel2" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional" 
                    ondatabinding="lnkfetch_Click">
                    <ContentTemplate>
                    <asp:ImageButton ID="excel3" runat="server" 
                            ImageUrl="~/OPS/Image/excelsmall.jpg" Visible="False" 
                            onclick="excel3_Click" style="height: 16px" />
                        <asp:GridView ID="grdDetail3" runat="server" Width="100%" 
                            EmptyDataText="no record found">
                            <AlternatingRowStyle CssClass="GridAI" />
                            <HeaderStyle CssClass="GridHeader" />
                            <PagerStyle CssClass="PageStyle" />
                            <RowStyle CssClass="GridItem" />
                        </asp:GridView>
                    </ContentTemplate>
                       <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="lnkfetch" EventName="Click" />
                          <asp:PostBackTrigger ControlID="excel3" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
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
</asp:Content>

