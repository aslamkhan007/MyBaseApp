<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MRPPCAuthLogisticMail.aspx.cs"
    Inherits="OPS_MRPPCAuthLogisticMail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        table.gridtable
        {
            font-family: verdana,arial,sans-serif;
            font-size: 11px;
            color: #333333;
            border-width: 1px;
            border-color: #666666;
            border-collapse: collapse;
        }
        table.gridtable th
        {
            border-width: 1px;
            padding: 8px;
            border-style: solid;
            border-color: #666666;
            background-color: #dedede;
        }
        table.gridtable td
        {
            border-width: 1px;
            padding: 8px;
            border-style: solid;
            border-color: #666666;
            background-color: #ffffff;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Material Return For MR ID :&nbsp; <b>
            <asp:Label ID="lblSanctionNoteId" runat="server" Text=""></asp:Label>&nbsp; &nbsp;
        </b>&nbsp;
        <p>
            Customer :&nbsp; <b>
                <asp:Label ID="lblCustomer" runat="server" Text=""></asp:Label>
            </b>&nbsp; Saleperson :&nbsp; <b>
                <asp:Label ID="lblSalePerson" runat="server" Text=""></asp:Label>
            </b>&nbsp;</p>
        <p>
            OrderNo :&nbsp; <b>
                <asp:Label ID="lblOrder" runat="server" Text=""></asp:Label>
            </b>&nbsp;</p>
        <p>
            Category :&nbsp; <b>
                <asp:Label ID="lblCategory" runat="server" Text=""></asp:Label>
            </b>&nbsp;</p>
        </p> <b>
            <p>
                Detail:</p>
        </b>
        <table style="width: 100%;">
            <tr>
                <td class="style1">
                    <asp:GridView ID="grdItemDetail" runat="server" CssClass="gridtable">
                    </asp:GridView>
                </td>
                <td class="style2">
                </td>
            </tr>
            <tr>
                <td class="style1">
                    <p>
                    </p>
                </td>
                <td class="style2">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <b>Freight Paid By :</b>
                    <asp:Label ID="lblfreight" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <b>Freight Type :</b>
                    <asp:Label ID="lblfreighttype" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <b>Action To Be Taken :</b>
                    <asp:Label ID="lblAction" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <br />
            <br />
            <tr>
                <td>
                    <b>Freight Value :</b>
                    <asp:Label ID="lblFreightValue" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <b>Tentative Rate :</b>
                    <asp:Label ID="lblTentative" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <b>Description:</b>
                    <asp:Label ID="lblDescription" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <b>Reason:</b>
                    <asp:Label ID="lblReason" runat="server" Text=""></asp:Label>
                </td>
            </tr>
        </table>
        <br />
        <a href='http://testerp/fusionapps/OPS/MRPreview.aspx'>Click here to view details...
        </a>
        <br />
        <p>
            This is a system generated mail and sent through OPS online mail management system.
            Please donot reply.<br />
            Thank You
        </p>
    </div>
    </form>
</body>
</html>
