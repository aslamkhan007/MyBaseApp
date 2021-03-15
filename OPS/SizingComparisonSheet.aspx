<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true" CodeFile="SizingComparisonSheet.aspx.cs" Inherits="OPS_SizingComparisonSheet" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <script type="text/javascript" src="../Scripts/jquery.min.js"></script>
     <script type="text/javascript">
         $("[src*=plus]").live("click", function () {
             $(this).closest("tr").after("<tr><td></td><td colspan = '999'>" + $(this).next().html() + "</td></tr>")
             $(this).attr("src", "../Image/minus.png");
         });
         $("[src*=minus]").live("click", function () {
             $(this).attr("src", "../Image/plus.png");
             $(this).closest("tr").next().remove();
         });
    </script>
    <table style="width: 100%;">
        <tr>
            <td class="tableheader" colspan="4">
                <asp:Label ID="Label16" runat="server" Text="Sizing Comparison Sheet"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 88px">
                <asp:Label ID="Label17" runat="server" Text="Sizing From"></asp:Label>
            </td>
            <td class="NormalText" style="width: 144px">
                <asp:TextBox ID="txtSizingFrom" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txtSizingFrom_CalendarExtender" runat="server" 
                    TargetControlID="txtSizingFrom">
                </cc1:CalendarExtender>
            </td>
            <td class="NormalText" style="width: 98px">
                <asp:Label ID="Label18" runat="server" Text="Sizing To"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtSizingTo" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txtSizingTo_CalendarExtender" runat="server" 
                    TargetControlID="txtSizingTo">
                </cc1:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 88px">
                <asp:Label ID="Label19" runat="server" Text="Sort No"></asp:Label>
            </td>
            <td class="NormalText" style="width: 144px">
                <asp:TextBox ID="txtSortNo" runat="server" Columns="10" CssClass="textbox" 
                    MaxLength="10"></asp:TextBox>
            </td>
            <td class="NormalText" style="width: 98px">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
    </table>
    <table style="width: 100%;">
        <tr>
            <td class="buttonbackbar">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:LinkButton ID="lnkFetch" runat="server" CssClass="buttonc" 
                            onclick="lnkFetch_Click">Fetch</asp:LinkButton>
                        <asp:LinkButton ID="lnkReset" runat="server" CssClass="buttonc">Reset</asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="100">
                    <ProgressTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Image/load.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
        </tr>
    </table>
    <table style="width: 100%;">
        <tr>
            <td class="NormalText" colspan="4">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Panel ID="pnlSizing" runat="server" CssClass="panelbg" Visible="true" 
                            Height="300px" ScrollBars="Vertical" Width="800px">
                             
                            <asp:GridView ID="grdSizing" runat="server" AutoGenerateColumns="False" 
                                DataKeyNames="IssueNo,Split,SortNo" EnableModelValidation="True" 
                                onrowdatabound="grdSizing_RowDataBound" Width="100%">
                                <AlternatingRowStyle CssClass="GridAI" />
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <img id="imageSortID-<%# Eval("IssueNo") %>-<%# Eval("Split") %>" alt="Click to show/hide orders" border="0" src="../Image/plus.png" />
                                            <div ID='SortID-<%# Eval("IssueNo") %>-<%# Eval("Split") %>' 
                                                style="display: none; position: relative; left: 25px;">
                                                <asp:GridView ID="nestedGridView" runat="server" AutoGenerateColumns="False" 
                                                    DataKeyNames="SortNo,BeamNo" 
                                                    EmptyDataText="No Sale Order mapped against these beams." Width="100%">
                                                    <SelectedRowStyle CssClass="SelectedRowStyle" />
                                                    <HeaderStyle CssClass="GridHeader" />
                                                    <RowStyle CssClass="GridItem" />
                                                    <AlternatingRowStyle CssClass="GridAI" />
                                                    <Columns>
                                                        <asp:BoundField DataField="SortNo" HeaderText="SortNo" />
                                                        <asp:BoundField DataField="BeamNo" HeaderText="BeamNo" />
                                                        <asp:BoundField DataField="OrderNo" HeaderText="OrderNo" />
                                                        <asp:BoundField DataField="AllocatedLength" HeaderText="AllocatedLength" />
                                                        <asp:BoundField DataField="BeamLength" HeaderText="BeamLength" />
                                                        <asp:BoundField DataField="User" HeaderText="User" />
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="MachineNo" HeaderText="MachineNo" />
                                    <asp:BoundField DataField="SecCode" HeaderText="SecCode" />
                                    <asp:BoundField DataField="SortNo" HeaderText="SortNo" />
                                    <asp:BoundField DataField="Status" HeaderText="Status" />
                                    <asp:BoundField DataField="IssueNo" HeaderText="IssueNo" />
                                    <asp:BoundField DataField="Split" HeaderText="Split" />
                                    <asp:BoundField DataField="WarpMtrs" HeaderText="WarpMtrs" />
                                    <asp:BoundField DataField="SizeMtrs" HeaderText="SizeMtrs" />
                                    <asp:BoundField DataField="SizingDone" HeaderText="MappingDone (mtrs)" />
                                    <asp:BoundField DataField="RemainingSizing" HeaderText="Remaining" />
                                </Columns>
                                <HeaderStyle CssClass="GridHeader" />
                                <PagerStyle CssClass="PagerStyle" />
                                <RowStyle CssClass="GridItem" />
                            </asp:GridView>
                       
                             
                        </asp:Panel>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="lnkFetch" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="lnkReset" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 88px">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 88px">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 88px">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 88px">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

