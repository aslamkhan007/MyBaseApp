﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CascadingDropdownlistWithJquery.aspx.cs"
    Inherits="Payroll_CascadingDropdownlistWithJquery" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%--<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>--%>
<script src="Scripts/jquery.min.js" type="text/javascript"></script>

<script type = "text/javascript">
    var pageUrl = '<%=ResolveUrl("~/CascadingDropdownlistWithJquery.aspx")%>'
    function PopulateContinents() {
        $("#<%=ddlCountries.ClientID%>").attr("disabled", "disabled");
        $("#<%=ddlCities.ClientID%>").attr("disabled", "disabled");
        if ($('#<%=ddlContinents.ClientID%>').val() == "0") {
            $('#<%=ddlCountries.ClientID %>').empty().append('<option selected="selected" value="0">Please select</option>');
            $('#<%=ddlCities.ClientID %>').empty().append('<option selected="selected" value="0">Please select</option>');
        }
        else {
            $('#<%=ddlCountries.ClientID %>').empty().append('<option selected="selected" value="0">Loading...</option>');
            $.ajax({
                type: "POST",
                //                url: pageUrl + '/PopulateCountries',
                url: 'WebService.asmx/PopulateCountries',
                data: '{continentId: ' + $('#<%=ddlContinents.ClientID%>').val() + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnCountriesPopulated,
                failure: function (response) {
                    alert(response.d);
                }
            });
        }
    }

    function OnCountriesPopulated(response) {
        PopulateControl(response.d, $("#<%=ddlCountries.ClientID %>"));
    }
</script>



<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    Continents:<asp:DropDownList ID="ddlContinents" runat="server" AppendDataBoundItems="true"
             onchange = "PopulateContinents();">
    <asp:ListItem Text = "Please select" Value = "0"></asp:ListItem>                
</asp:DropDownList>
<br /><br />
Country:<asp:DropDownList ID="ddlCountries" runat="server"
             onchange = "PopulateCities();">
    <asp:ListItem Text = "Please select" Value = "0"></asp:ListItem>                
</asp:DropDownList>
<br /><br />
City:<asp:DropDownList ID="ddlCities" runat="server">
    <asp:ListItem Text = "Please select" Value = "0"></asp:ListItem>                
</asp:DropDownList>
<br />
<asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick = "Submit" /> 
    </div>
    </form>
</body>
</html>