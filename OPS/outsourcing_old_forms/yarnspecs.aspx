<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true" CodeFile="yarnspecs.aspx.cs" Inherits="OPS_yarnspecs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <table class="mytable">
        <tr>
            <td colspan="4" style="font-weight: bold; font-size: 10pt;" class="tableheader">
                &nbsp;Outsourced Yarn
                Specification</td>
        </tr>
        <tr>
            <td class="NormalText">
                Request ID</td>
            <td class="NormalText">
                <asp:TextBox runat="server" CssClass="textbox" ID="txtreq"></asp:TextBox>
            </td>
            <td class="NormalText">
                <asp:ImageButton ID="ImageButton1" runat="server" 
                    ImageUrl="~/OPS/Image/searchBlueSmall.PNG" Height="16px" 
                    onclick="ImageButton1_Click" style="width: 16px" />
            </td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" colspan="4">
                <asp:Panel ID="Panel1" runat="server">
                    <asp:GridView ID="grdDetail" runat="server" 
    AutoGenerateSelectButton="True" 
    onselectedindexchanged="grdDetail_SelectedIndexChanged">
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
            <td class="NormalText" colspan="4">
                <asp:Label ID="lbtxt" runat="server" 
                    Text="Please select from above grid to fill record"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="NormalText" colspan="4">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText">
                Actual count/Denier</td>
            <td class="NormalText">
                <asp:TextBox ID="txtcount" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td class="NormalText">
                Count Cv%</td>
            <td class="NormalText">
                <asp:TextBox ID="txtcountcv" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                Countname</td>
            <td class="NormalText">
                <asp:TextBox ID="txtcountname" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText">
                Tenacity</td>
            <td class="NormalText">
                <asp:TextBox ID="Txttenacity" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td class="NormalText">
                Elongation</td>
            <td class="NormalText">
                <asp:TextBox ID="txtelongation" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                Lusture</td>
            <td class="NormalText">
                <asp:TextBox ID="txtlust" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText">
                OPU</td>
            <td class="NormalText">
                <asp:TextBox ID="txtOPU" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td class="NormalText">
                Nips/mtr</td>
            <td class="NormalText">
                <asp:TextBox ID="txtnip" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                BWS</td>
            <td class="NormalText">
                <asp:TextBox ID="txtBWS" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td class="NormalText">
                CSP(not 
                less than)</td>
            <td class="NormalText">
                <asp:TextBox ID="txtCSP" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                U%</td>
            <td class="NormalText">
                <asp:TextBox ID="txtu" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td class="NormalText">
                IPI</td>
            <td class="NormalText">
                <asp:TextBox ID="txtIPI" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                Hairiness</td>
            <td class="NormalText">
                <asp:TextBox ID="txtHair" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td class="NormalText">
                TPI</td>
            <td class="NormalText">
                <asp:TextBox ID="txtTPI" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                Blend%</td>
            <td class="NormalText">
                <asp:TextBox ID="txtBlend" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td class="NormalText">
                All faults</td>
            <td class="NormalText">
                <asp:TextBox ID="txtallfaults" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                Classimate Faults<br />
                (as per classimate quantum result)</td>
            <td class="NormalText">
                <asp:TextBox ID="txtclassimate" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td class="NormalText">
                Major Short Thick<br />
                (A4+B4+C3+C4+D3+D4)</td>
            <td class="NormalText">
                <asp:TextBox ID="txtmajorthick" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                Short Thick<br />
                (A3+B3+C2+D2)</td>
            <td class="NormalText">
                <asp:TextBox ID="txtshortthick" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td class="NormalText">
                Long Thick(E+F+G)</td>
            <td class="NormalText">
                <asp:TextBox ID="txtlngthick" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                Thin Faults(H1)</td>
            <td class="NormalText">
                <asp:TextBox ID="txtthinfaults" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td class="NormalText">
                Major Thin(H2+l1+l2)</td>
            <td class="NormalText">
                <asp:TextBox ID="txtmajorthin" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                Lycra/spandex %</td>
            <td class="NormalText">
                <asp:TextBox ID="txtlycrapercnt" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td class="NormalText">
                Lycra/spandex(Denier)</td>
            <td class="NormalText">
                <asp:TextBox ID="txtlycradenier" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="NormalText" colspan="4">
                <asp:Label ID="lbtxt2" runat="server" 
                    Text="Please select from below grid to update record" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="NormalText" colspan="4">
                <asp:Panel ID="Panel2" runat="server" ScrollBars="Both" Width="800px">
                    <asp:GridView ID="grdDetail2" runat="server" Width="100%" 
                        onselectedindexchanged="grdDetail2_SelectedIndexChanged">
                        <AlternatingRowStyle CssClass="GridAI" />
                        <HeaderStyle CssClass="GridHeader" />
                        <PagerStyle CssClass="PageStyle" />
                        <RowStyle CssClass="GridItem" />
                    </asp:GridView>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:LinkButton ID="lnkapply" runat="server" CssClass="buttonc" 
                    onclick="lnksave_Click">Apply</asp:LinkButton>
                <asp:LinkButton ID="lnkclear" runat="server" CssClass="buttonc" 
                    onclick="lnkclear_Click">Clear</asp:LinkButton>
                <asp:LinkButton ID="lnkdel" runat="server" CssClass="buttonc" 
                    onclick="lnkdel_Click" Visible="False">Delete</asp:LinkButton>
                <asp:LinkButton ID="lnkUpt" runat="server" CssClass="buttonc" 
                    onclick="lnkUpt_Click" Visible="False">Update</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="height: 17px">
            </td>
            <td class="NormalText" style="height: 17px">
            </td>
            <td class="NormalText" style="height: 17px">
            </td>
            <td class="NormalText" style="height: 17px">
                <asp:Label ID="lbid" runat="server" Text="Label" Visible="False"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>