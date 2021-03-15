<%@ Page Title="" Language="C#" MasterPageFile="~/Courier Tracking System/MasterPage.master" AutoEventWireup="true" CodeFile="Courier_Type_Master.aspx.cs" Inherits="Courier_Tracking_System_Courier_Type_Master" %>
<%@ Register src="../FlashMessage.ascx" tagname="FlashMessage" tagprefix="uc1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="tableheader" colspan="4">
                <asp:Label ID="Label18" runat="server" Text="Courier Type Master"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 119px">
                <asp:Label ID="Label22" runat="server" Text="Effective From"></asp:Label>
            </td>
            <td class="NormalText" style="width: 141px">
                <asp:TextBox ID="txtEffecFrom" runat="server" CssClass="NormalText" 
                    MaxLength="20"></asp:TextBox>
                <cc1:CalendarExtender ID="txtEffecFrom_CalendarExtender" runat="server" 
                    TargetControlID="txtEffecFrom">
                </cc1:CalendarExtender>
            </td>
            <td class="NormalText" style="width: 89px">
                <asp:Label ID="Label23" runat="server" Text="Effective To"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtEffecTo" runat="server" CssClass="NormalText" 
                    MaxLength="20"></asp:TextBox>
                <cc1:CalendarExtender ID="txtEffecTo_CalendarExtender" runat="server" 
                    TargetControlID="txtEffecTo">
                </cc1:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 119px">
                <asp:Label ID="Label19" runat="server" Text="Courier Type"></asp:Label>
            </td>
            <td class="NormalText" style="width: 141px">
                <asp:TextBox ID="txtCourierType" runat="server" CssClass="NormalText" 
                    MaxLength="20"></asp:TextBox>
            </td>
            <td class="NormalText" style="width: 89px">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtCourierType" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 119px">
                <asp:Label ID="Label20" runat="server" Text="Short Description"></asp:Label>
            </td>
            <td class="NormalText" style="width: 141px">
                <asp:TextBox ID="txtDescription" runat="server" CssClass="NormalText" 
                    Width="300px"></asp:TextBox>
            </td>
            <td class="NormalText" style="width: 89px">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtDescription" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 119px">
                <asp:Label ID="Label24" runat="server" Text="Long Description"></asp:Label>
            </td>
            <td class="NormalText" colspan="3">
                <asp:TextBox ID="txtLongDescription" runat="server" CssClass="NormalText" 
                    Width="400px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 119px">
                <asp:Label ID="Label21" runat="server" Text="Remarks"></asp:Label>
            </td>
            <td class="NormalText" colspan="3">
                <asp:TextBox ID="txtRemarks" runat="server" CssClass="NormalText" Width="400px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:LinkButton ID="lnkAdd" runat="server" CssClass="buttonc" 
                    onclick="lnkAdd_Click">Add</asp:LinkButton>
                <asp:LinkButton ID="lnkEdit" runat="server" CssClass="buttonc" 
                    onclick="lnkEdit_Click">Edit</asp:LinkButton>
                <asp:LinkButton ID="lnkDelete" runat="server" CssClass="buttonc" 
                    onclick="lnkDelete_Click">Delete</asp:LinkButton>
                <cc1:ConfirmButtonExtender ID="lnkDelete_ConfirmButtonExtender" runat="server" 
                    ConfirmText="Are you sure ?" TargetControlID="lnkDelete">
                </cc1:ConfirmButtonExtender>
            </td>
        </tr>
        <tr>
            <td class="NormalText" colspan="4">
                 <uc1:FlashMessage ID="FMsg" runat="server" EnableTheming="true" EnableViewState="true"
                            FadeInDuration="2" FadeInSteps="2" FadeOutDuration="10" FadeOutSteps="2" Visible="true">
                        </uc1:FlashMessage></td>
        </tr>
    </table>
    <table style="width:100%;">
        <tr>
            <td class="NormalText" colspan="3">
                <asp:Panel ID="Panel1" runat="server" CssClass="panelbg" ScrollBars="Both" 
                    Width="800px">
                  <asp:GridView ID="GridView1" runat="server" CssClass="GridView" 
                        EnableModelValidation="True" AutoGenerateColumns="False" 
                        datakeyTrialNos="Sr_no" EmptyDataText="No records found" 
                        onselectedindexchanged="GridView1_SelectedIndexChanged" AllowPaging="True" 
                        DataKeyNames="Sr_no" DataSourceID="SqlDataSource1" Width="200%">
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" />
                            <asp:BoundField DataField="Sr_no" HeaderText="Sr_no" InsertVisible="False" 
                                ReadOnly="True" SortExpression="Sr_no" />
                            <asp:BoundField DataField="CourierType" HeaderText="CourierType" 
                                SortExpression="CourierType" />
                            <asp:BoundField DataField="DESCRIPTION" HeaderText="DESCRIPTION" 
                                SortExpression="DESCRIPTION" />
                            <asp:BoundField DataField="Remarks" HeaderText="Remarks" 
                                SortExpression="Remarks" />
                            <asp:BoundField DataField="STATUS" HeaderText="STATUS" 
                                SortExpression="STATUS" />
                            <asp:BoundField DataField="EffecFrom" HeaderText="EffecFrom" 
                                SortExpression="EffecFrom" />
                            <asp:BoundField DataField="EffecTo" HeaderText="EffecTo" 
                                SortExpression="EffecTo" />
                            <asp:BoundField DataField="LongDesc" HeaderText="LongDesc" 
                                SortExpression="LongDesc" />
                        </Columns>
                        <HeaderStyle CssClass="HeaderStyle" />
                        <PagerStyle CssClass="PagerStyle" />
                        <RowStyle CssClass="RowStyle" />
                        <SelectedRowStyle CssClass="SelectedRowStyle" />
                    </asp:GridView>

                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                        
                        
                        SelectCommand="SELECT  Sr_no,CourierType, DESCRIPTION, Remarks, STATUS,Convert(varchar, EffecFrom,103) as [EffecFrom],Convert(varchar, EffecTo,103) as [EffecTo], LongDesc FROM jct_courier_Type_Master WHERE (STATUS = @STATUS) order by Sr_no desc">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="A" Name="STATUS" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 172px">
                <asp:HiddenField ID="hd1" runat="server" />
            </td>
            <td class="NormalText" style="width: 141px">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 172px">
                &nbsp;</td>
            <td class="NormalText" style="width: 141px">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 172px">
                &nbsp;</td>
            <td class="NormalText" style="width: 141px">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
    </table>
    <!-- <div id="divGridViewData"></div>
     <div id="divEditBox">
        <table cellpadding="4" width="600" cellspacing="0" border="0" style="background-color:#efefef;border:1px solid #c0c0c0;">
            <tr style="background-color:#b0b0b0;" valign="top">
                <td colspan="3">&nbsp;<label id="lblPopTitle">Modify Record</label></td>
                <td align="right" style="width: 9%;padding-right:10px;">
                    <a id="closeLink"  href="javascript:void(0)" onclick="HideEditBox()" title="Close">Close</a>
                </td>
            </tr>
            <tr>
                <td>Courier Type: </td><td  colspan="3"><input type="text" id="txtCourierType1" />
                </td>                
            </tr>
            <tr>
                <td>Short Desc: </td><td colspan="3">
                <input type="text" id="txtShortDesc" 
                    style="width: 391px" /></td>                
              
            </tr>
            <tr>
                <td>Long Desc: </td><td colspan="3">
                <input type="text" id="txtLongDesc" 
                    size="10" style="width: 395px" /></td>
            </tr>
            <tr>
                <td>Effective From</td><td  style="width: 145px">
                <input type="text" id="txtEffecFrom1" size="10" style="width: 100px" /></td>
                <td style="width: 154px">Effective To:</td><td><input type="text" 
                    id="txtEffecTo1" size="10" style="width: 100px" /></td>
            </tr>
            <tr><td colspan="4" align="center">&nbsp;
            <input type="button" value="Submit" onclick="UpdateInsertData()" />
            <input type="hidden" id="editId" value="0" />
            </td></tr>
        </table>
    </div> -->
  <!--  <script language="javascript" type="text/javascript">
        // Load the gridview page data
        function LoadGridViewData(start, pageNo) {
            $(document).ready(function () {
                $.post("GridViewData.aspx", {
                    startRowIndex: start,
                    thisPage: pageNo
                },
    function (data) {
        $("div#divGridViewData").html(data);
    });
            });
        }
        // insert / update the data
        function UpdateInsertData() {
            $(document).ready(function () {
                $.post("GridViewData.aspx",
        {
            CourierType: $("#txtCourierType1").val(),
            Description: $("#txtShortDesc").val(),
            LongDesc: $("#txtLongDesc").val(),
            EffecFrom: $("#txtEffecFrom1").val(),
            EffecTo: $("#txtEffecTo1").val(),
            editId: $("#editId").val()
        },
        function (data) {
            // $("div#divGridViewData").html(data);
            $("div#dicGridViewData").bind(data);
        });
            });
            // hide the edit box
            HideEditBox();
        }
        // highlight the row when clicked
        $(document).ready(function () {
            $("#divGridView table tbody tr").mouseover(function () {
                $(this).addClass("highlightRow");
            }).mouseout(function () { $(this).removeClass('highlightRow'); })
        });

        // highlight row by clicking it
        $(document).ready(function () {
            $("#divGridView table tbody tr").click(function () {
                $(this).addClass("select");
            })
        });

        // show edit box when edit link is clicked   
        function ShowEditBox(id) {
            $("#divEditBox").slideDown("medium");
            var pid = 'PSr_no' + id;
            var colIndex = 0;

            var $tr = $("#" + pid).parent().parent();
            $tr.find('td').each(function () {

                if (colIndex == 2) {
                    $("#txtCourierType1").val($(this).text());
                }
                else if (colIndex == 3) {
                    $("#txtShortDesc").val($(this).text());
                }
                else if (colIndex == 4) {
                    $("#txtLongDesc").val($(this).text());
                }
                else if (colIndex == 5) {
                    $("#txtEffecFrom").val($(this).text());
                }
                else if (colIndex == 6) {
                    $("#txtLongDesc").val($(this).text());
                }
                colIndex++;
            })
            $("#editId").val(id);
        }

        // Hide the edit/insert box
        function HideEditBox() {
            $("#divEditBox").slideUp("medium");
        }

</script> -->
</asp:Content>

