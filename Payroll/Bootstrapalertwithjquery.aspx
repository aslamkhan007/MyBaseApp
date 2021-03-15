<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Bootstrapalertwithjquery.aspx.cs"
    Inherits="Payroll_Bootstrapalertwithjquery" %>

<%--<script src="Scripts/jquery-1.11.0.min.js" type="text/javascript"></script>--%>
<script src="../Scripts/jquery.min.js" type="text/javascript"></script>
<link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" />
<%--<link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" />--%>
<%--<script src="Scripts/Jquery3.3.1.js" type="text/javascript"></script>--%>
<%--<script src="js/bootstrap.min.js" type="text/javascript"></script>--%>
<script src="js/bootstrap.min.js" type="text/javascript"></script>
<html>
<head runat="server">
    <style type="text/css">
        .pattern
        {
            min-height: 200px;
        }
        
        #stripes7
        {
            background-image: repeating-linear-gradient(20deg, #ccc, #ccc 30px, #dbdbdb 30px, #dbdbdb 60px);
        }
    </style>
    <title></title>
    <%-- https://cdnjs.cloudflare.com/ajax/libs/respond.js/1.4.2/respond.min.js--%>
    <%--    <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
      <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>--%>
    <%--    <script src="Scripts/respond.min.js" type="text/javascript"></script>--%>
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <%--  <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
    <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>--%>
    <script src="Scripts/respond.min.js" type="text/javascript"></script>
</head>
<script type="text/javascript">
    function ShowPopup(title, body) {
        $("#MyPopup .modal-title").html(title);
        $("#MyPopup .modal-body").html(body);
        $("#MyPopup").modal("show");
    }
</script>
<body>
    <form id="form1" runat="server">
    <div id="stripes7" class="pattern">
        <h2>
            Sample text</h2>
    </div>
    <div>
        <div id="MyPopup" class="modal fade" role="dialog">
            <div class="modal-dialog">
                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">
                            &times;</button>
                        <h4 class="modal-title">
                        </h4>
                    </div>
                    <div class="modal-body">
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-danger" data-dismiss="modal">
                            Close</button>
                    </div>
                </div>
            </div>
        </div>
        <center>
            <asp:Button ID="btnShowPopup" runat="server" Text="Show Popup" OnClick="ShowPopup"
                CssClass="btn btn-info btn-lg" />
        </center>
    </div>
    </form>
</body>
</html>
