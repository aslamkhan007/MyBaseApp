<%@ Page Title="" Language="C#" MasterPageFile="~/Payroll/MasterPage.master"  AutoEventWireup="true"
    CodeFile="Testing.aspx.cs" Inherits="Payroll_Testing" %>


    <asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
    <html xmlns='http://www.w3.org/1999/xhtml'>

    <script src="jquery-1.11.3.js" type="text/javascript"></script>
        <script src="jquery.validate.js" type="text/javascript"></script>

<script type="text/javascript">
        $(document).ready(function() {
            $("#aspnetForm").validate({
                rules: {
                    txtName: {
                        minlength: 2,
                        required: true
                    },
                    txtEmail: {                       
                        required: true,
                        email:true
                    }
                }, messages: {}
            });
        });
    </script>
   
    <%--Name: <asp:TextBox ID="txtName" MaxLength="30" runat="server" /><br />
    Email: <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox><br />
    <asp:Button ID="btnSubmit" runat="server" Text="Submit" />--%>

    <form method = "post" action="#">
    <input type = "text" name = "txtName" id = "txtName" />
    <input type = "text" name = "txtEmail" id = "txtEmail" required  />
    <button type = "submit">Save</button>
    </form>



</asp:Content>
