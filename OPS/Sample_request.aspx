<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true" CodeFile="Sample_request.aspx.cs" Inherits="OPS_Sample_request" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table  style="width: 100%">
        <tr>
            <td colspan="5" class="tableheader">
                Sample Request</td>
        </tr>
        <tr>
            <td style="width: 203px" >
                Sales Person</td>
            <td style="width: 313px" >
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                </asp:UpdatePanel>
                <asp:DropDownList ID="DdlSalePerson" CssClass="combobox" runat="server">
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 203px" >
                Customer</td>
            <td style="width: 313px" >
                <asp:TextBox ID="txtcustomer" runat="server" CssClass="textbox" Width="200px"></asp:TextBox>
                <cc1:AutoCompleteExtender ID="txtcustomer_AutoCompleteExtender" runat="server" 
                    CompletionInterval="100" 
                    CompletionListCssClass="autocomplete_completionListElement" 
                    MinimumPrefixLength="1" ServiceMethod="OPS_Customer" 
                    ServicePath="~/webservice.asmx" TargetControlID="txtcustomer">
                </cc1:AutoCompleteExtender>
            </td>
            <td class="NormalText">
                Plant</td>
            <td>
                <asp:DropDownList ID="ddlplant" runat="server" CssClass="combobox">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>COTTON</asp:ListItem>
                    <asp:ListItem>TAFFETA</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 203px" >
                Required Meters</td>
            <td style="width: 313px" >
                <asp:TextBox ID="txtReqMtrs" runat="server" CssClass="textbox" Width="50px" 
                    MaxLength="3"></asp:TextBox><cc1:FilteredTextBoxExtender TargetControlID="txtReqMtrs" ValidChars="0123456789"
                    ID="FilteredTextBoxExtender1" runat="server">
                </cc1:FilteredTextBoxExtender>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 203px" >
                No of Shades</td>
            <td style="width: 313px" >
                <asp:TextBox ID="txt_No_of_shades" runat="server" MaxLength="1" CssClass="textbox" Width="50px"></asp:TextBox>
                <cc1:FilteredTextBoxExtender TargetControlID="txt_No_of_shades" ValidChars="0123456789" ID="FilteredTextBoxExtender2" runat="server"></cc1:FilteredTextBoxExtender>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        </table>
    <p>
    </p>
    <table  style="width: 100%">
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
   
    <table  style="width: 100%">
        <tr>
            <td class="NormalText" style="width: 205px" >
                Paid By Client</td>
            <td>
                <asp:DropDownList ID="ddlclient" runat="server">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        </table>
    <table  style="width: 100%" class="tableback">
        <tr>
            <td >
                Subject         <td >
                <asp:TextBox ID="txtsubject" runat="server" CssClass="textbox" Width="250px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtSubject"
                            Display="Dynamic" ErrorMessage="* Required" SetFocusOnError="True" ValidationGroup="GrpApply"></asp:RequiredFieldValidator>
            </td>
            <td>
                Finish</td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                  <asp:DropDownList ID="ddlFinish" runat="server" CssClass="combobox" 
                    DataSourceID="dsFinish" DataTextField="Finish" 
                    DataValueField="recipe_code" AppendDataBoundItems="True" AutoPostBack="True">
                            <asp:ListItem></asp:ListItem>
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="dsFinish" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                            SelectCommand="JCT_OPS_Get_Finishes" SelectCommandType="StoredProcedure">                            
                        </asp:SqlDataSource>
                </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td valign="top" >
                Description</td>
            <td colspan="3" >
                <asp:TextBox ID="txtdescptn" runat="server" CssClass="textbox" Height="200px" 
                    TextMode="MultiLine" Width="80%"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td >
                Sort No/ Enq No</td>
            <td colspan="4" >
                <asp:TextBox ID="txtsort" runat="server" CssClass="textbox" Width="70%"></asp:TextBox>
                <cc1:AutoCompleteExtender ID="txtsort_AutoCompleteExtender" runat="server" 
                    CompletionInterval="100" MinimumPrefixLength="1" 
                    ServiceMethod="OPS_Fabric_Items" ServicePath="~/webservice.asmx" 
                    TargetControlID="txtsort" 
                    CompletionListCssClass="autocomplete_completionListElement">
                </cc1:AutoCompleteExtender>
                <asp:LinkButton ID="CmdSearch" runat="server" 
                   CssClass="searchbluesmall" onclick="CmdSearch_Click" BorderStyle="None" 
                    Height="16px" Width="16px" />
            </td>
        </tr>
    </table>
<table class="tableback" style="width: 100%">
        <tr>
            <td class="NormalText">
                <asp:Panel ID="Panel2" runat="server" ScrollBars="Both" Width="95%">
                    <asp:GridView ID="grdDetail2" runat="server" Width="90%">
                        <AlternatingRowStyle CssClass="GridAI" />
                        <HeaderStyle CssClass="GridHeader" />
                        <PagerStyle CssClass="PageStyle" />
                        <RowStyle CssClass="GridItem" />
                        <SelectedRowStyle CssClass="GridGreenRow" />
                    </asp:GridView>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                <asp:Panel ID="Panel1" runat="server" ScrollBars="Both" Width="95%">
                    <asp:GridView ID="grdDetail" runat="server" EmptyDataText="No Record Found">
                        <AlternatingRowStyle CssClass="GridAI" />
                        <HeaderStyle CssClass="GridHeader" />
                        <PagerStyle CssClass="PageStyle" />
                        <RowStyle CssClass="GridItem" />
                        <SelectedRowStyle CssClass="GridGreenRow" />
                    </asp:GridView>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        </table>
           <table  style="width: 100%">
        <tr>
            <td class="tableheader" colspan="5" >
                Costing Details</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 145px" >
                Any Order Available</td>
            <td style="width: 163px" >
                <asp:DropDownList ID="ddlAOD" runat="server" CssClass="combobox">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="NormalText" style="width: 147px">
                DNV</td>
            <td>
                <asp:TextBox ID="txtDNV" runat="server" CssClass="textbox" MaxLength="10"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 145px" >
                Sample order </td>
            <td style="width: 163px" >
                <asp:TextBox ID="txtsample" runat="server" CssClass="textbox" MaxLength="10"></asp:TextBox>
                <asp:LinkButton ID="lnksearch" runat="server" CssClass="searchbluesmall"  Height="16px" Width="16px"
                    onclick="lnksearch_Click"></asp:LinkButton>
            </td>
            <td class="NormalText" style="width: 147px">
                Selling Price</td>
            <td>
                <asp:TextBox ID="txtsellinprice" runat="server" CssClass="textbox" 
                    MaxLength="10"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 145px; height: 24px" >
                </td>
            <td style="width: 163px; height: 24px" >
            </td>
            <td style="width: 147px; height: 24px">
                &nbsp;</td>
            <td style="height: 24px">
                &nbsp;</td>
            <td style="height: 24px">
                </td>
        </tr>
        <tr>
            <td class="NormalText" colspan="5" >
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" colspan="5" >
                <asp:Panel ID="Panel3" runat="server" ScrollBars="Both" Width="70%">

                <asp:GridView ID="grdDetail3" runat="server">
                    <AlternatingRowStyle CssClass="GridAI" />
                    <HeaderStyle CssClass="GridHeader" />
                    <RowStyle CssClass="GridItem" />
                </asp:GridView>
               </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 145px" >
                &nbsp;</td>
            <td style="width: 163px" >
                &nbsp;</td>
            <td style="width: 147px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        </table>

    <table class="tableback" style="width: 100%">
        <tr>
            <td class="NormalText" colspan="3">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" colspan="3">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" colspan="3">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="3">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:LinkButton ID="lnkgen" runat="server" CssClass="buttonc" 
                            onclick="lnkgen_Click">Generate</asp:LinkButton>
                        <asp:LinkButton ID="lnkclr" runat="server" CssClass="buttonc" 
                            onclick="lnkclr_Click">Clear</asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="3">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 171px">
             
            </td>
            <td style="width: 149px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>




    <table class="tableback" style="width: 100%">
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                <br />
            </td>
        </tr>
        <tr>
            <td colspan="3">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

