<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DynamicLoading.aspx.cs" Inherits="Ajax_DynamicLoading" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div id="myDiv">
	<p>Static data initially rendered.
    1. First parameter is the url to post data
2. Second parameter is the data to be posted. Note that parameter should be specified in the curly braces and key and value should be separated with “:” (colon)
3. Third parameter will be the function to execute after successful request. Here “data” will have all the response string returned by jQueryAjaxData.aspx page.
Demo url: http://localhost:9007/jQueryWeb/Ajax/getpost.aspx
Get()
<input type="button" id="btnGet" value="Load Data using Get" />
<div id="divResult"></div>
$("#btnGet").click(function () {
$.get(
"jQueryAjaxData.aspx",
{ ag: "2", bg: "6" },
function (data) {
$("#divResult").html("<b>The result is: " + data + "</b>");
});
});
This is similar to .ajax method however this guarantees that ajax request will be sent to the server using html form get mechanism. The only difference between Post and Get is the mechanism by which data is submitted to the page.
Here
1. First parameter is the url to post data
2. Second parameter is the data to be posted. Note that parameter should be specified in the curly braces and key and value should be separated with “:” (colon)
3. Third parameter will be the function to execute after successful request. Here “data” will have all the response string returned by jQueryAjaxData.aspx page.
Demo url: http://localhost:9007/jQueryWeb/Ajax/getpost.aspx
How to load JSON data from server? - .getJSON(Url, data, callBack)
To load JSON data from server, getJSON() method can be used. In this way, data is loaded from server using HTTP Get method.
JSON (JavaScript Object Notation) is a lightweight data-interchange format. It is easy for humans to read and write and also easy for machines to parse and generate. Read more about JSON at http://www.json.org/
<input type="button" id="btnJson" value="Load Json data" />
// Get Sample jSon data from http://labs.adobe.com/technologies/spry/samples/data_region/JSONDataSetSample.html
$("#btnJson").click(function () {
$.getJSON("jQueryAjaxData.aspx", { format: "json" }, jsonCallback);
});
function jsonCallback(datas) {
alert(datas[0].FirstName);
44 jQuery how to’s - © Sheo Narayan, IT Funda Corporation.
Visit DotNetFunda.Com for articles, tutorials, forums. Visit ITFunda.Com for online training
44
jQuery How to‟s http://www.ItFundaCorporation.com
}
In the above code snippet, getJSON method is called to get the JSOPN data from server. If the request is successful, the callback method is called where we can retrieve the data.
Server side response code is written below
if (Request.QueryString["format"] != null)
{
string data = " [
{ \"FirstName\": \"Sheo\", \"LastName\": \"Narayan\", \"City\": \"Hyderabad\" }, " +
"{ \"FirstName\": \"Jack\", \"LastName\": \"Jeel\", \"City\": \"NY\" }
]";
Response.Write(data);
}
Here, I have formed two object with FirstName, LastName and City property. In the call back method I am expecting FirstName of the first object that will alert me with “Sheo”.
Demo url: http://localhost:9007/jQueryWeb/Ajax/getJSON.aspx
How to load a page data from the server into a particular element - .load(url, callBack)
To load a page data from server into a particular page element, load() method can be used. An optional callback method can also be specified to catch the returned data.
<input type="button" id="btnLoad" value="Load Simple Page Content" />
<textarea id="txtArea1" name="txtArea1" rows="10" cols="50"></textarea>
// without callback
$("#btnLoad").click(function () {
$("#txtArea1").load('jQueryAjaxData.aspx?format=json');
});
// with callback
$("#btnLoad").click(function () {
$("#txtArea1").load('jQueryAjaxData.aspx?format=json', function (e) {
alert(e);
});
});
In the above code snippet, the first code snippet “without callback” will call the page jQueryAjaxData.aspx and set the response to the “txtArea1” textbox.
Similarly, in the second code snippet “with callback” will call the same page but it will also alert the response from server along with setting the response to “txtArea1” textbox.
Demo url: http://localhost:9007/jQueryWeb/Ajax/load.aspx
How to serialize the form element data that can be submitted to the server - .serialize()
To serialize (URL Encoded notation) the html form element data that can be sent to the server, serialize() method can be used.
<input type="button" id="btnSerialize" value="Serialize data" />
<textarea id="txtArea1" name="txtArea1" rows="10" cols="50"></textarea>
45 jQuery how to’s - © Sheo Narayan, IT Funda Corporation.
Visit DotNetFunda.Com for articles, tutorials, forums. Visit ITFunda.Com for online training
45
jQuery How to‟s http://www.ItFundaCorporation.com
$("#btnSerialize").click(function () {
var data = $("form").serialize();
$("#txtArea1").val(data);
});
In the above code snippet, on click button “btnSerialize”, all the form element of the page is serialized into a string that can be sent to the server.
Demo url: http://localhost:9007/jQueryWeb/Ajax/serialize.aspx
How to register a handler to be called when first ajax request begins? - .ajaxStart()
While working with ajax, how to show “loading …” or “Please wait …” type of message?
To register a handler to be called when first ajax request begins, ajaxStart() method can be used. This can be used to show the loading… or wait …. Messages.
$("#divAjaxStart").ajaxStart(function () {
$("#divAjaxStart").text("Starting ... : ");
});
In the above code snippet, when ajax request starts, “Starting …” is written inside “divAjaxStart” element.
Demo url: http://localhost:9007/jQueryWeb/Ajax/ajaxEvents.aspx
How to perform certain operations when ajax request is about to send? -.ajaxSend()
To perform certain operations when ajax request is about to send, ajaxSend() method can be used.
$("#divAjaxSend").ajaxSend(function () {
$("#divAjaxSend").text("Sending ajax request ...:</p>
</div>



<script language="javascript" type="text/javascript">
    $(document).ready(function () {

        $(window).scroll(function () {
            if ($(window).scrollTop() == $(document).height() - $(window).height()) {
                sendData();
            }
        });

        function sendData() {
            $.ajax(
                {
                    type: "POST",
                    url: "jQueryAjaxData.aspx/GetData",
                    data: "{}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: "true",
                    cache: "false",

                    success: function (msg) {
                        $("#myDiv").append(msg.d);
                    },

                    Error: function (x, e) {
                        alert("Some error");
                    }

                });

        }

    });
</script>
</asp:Content>

