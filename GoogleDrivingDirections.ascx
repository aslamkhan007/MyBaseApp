<%@ Control Language="C#" ClassName="GoogleDrivingDirections" %>
<%--
Created by: Abu Haider - www.haiders.net
First published: 2/14/2008
Last Update: 2/15/2008 - Changed to Ajax API loader

FileName: GoogleDrivingDirections.ascx
Required files:none
Description:
ASP.NET Wrapper control for Google Driving Directions API.
It loads driving directions in a div element of its own.
Optionally loads a synchronized map showing the route in another div element.

Assign valid addresses to the FromAddress and ToAddress properties.
To load directions on page load automatically, set the AutoLoad Property = True;

No API Key is needed for running on localhost, but must be provided for production Website.
Assign a valid Key to the APIKey property. 
API Keys can be freely obtained from http://code.google.com
API Keys are issued for a specific host name, so you will need a Key
every time you publish the website to a new host.

To display the Map along with directions, create a div element on the page and set width and height through css/style
Then assign the ID of this div element to the MapElementID of this control.

Visit www.haiders.net for more information. Limited support via the blog is available.

*** Use at your own risk and thoroughly test in your production environment ***
 
--%>
<script runat="server">
    private Unit width, height;
    private string fromAddress, toAddress;
    private string mapElementID = string.Empty;
    private bool autoLoad = true;
    
    //Api Key related
    private string apikey = string.Empty;
    const string apikey_localhost = "ABQIAAAAn3Z0cRcS4vYvtWFgxDT-XxQJG1Plr3ELCWOTj1GK3462JN6umRRq3gfzRVjeS1XDH3ssgRa4stz-uA";
    const string api_include = "http://www.google.com/jsapi?key={0}" ;

    public bool AutoLoad
    {
        get { return autoLoad; }
        set { autoLoad = value; }
    }

    public string APIKey
    {
        get { return apikey; }
        set { apikey = value; }
    }
    
    
    public string MapElementID
    {
        get { return mapElementID; }
        set { mapElementID = value; }
    }
    
    public Unit Width
    {
        get { return width; }
        set { width = value; Directions.Style[HtmlTextWriterStyle.Width] = width.ToString(); }    
    }

    public Unit Height
    {
        get { return height; }
        set { height = value; Directions.Style[HtmlTextWriterStyle.Height] = height.ToString(); }
    }

    public string FromAddress
    {
        get { return fromAddress; }
        set { fromAddress = value; }
    }

    public string ToAddress
    {
        get { return toAddress; }
        set { toAddress = value; }
    }
    
    protected override void OnPreRender(EventArgs e)
    {
        string apiURL = null;
        if (Request.Url.IsLoopback)
            apiURL = string.Format(api_include, apikey_localhost);
        else
        {
            if (apikey.Length > 0) //if an api key is specified
                apiURL = string.Format(api_include, apikey);
            else
            {
                Directions.InnerHtml = "You need to specifiy a Google API key for this host: " + Request.Url.Host;
            }
        }
        
        if (apiURL != null)
        {
            Page.ClientScript.RegisterClientScriptInclude(this.GetType(), "API_KEY_REFERENCE", apiURL);

            //if (toAddress.Length > 0 && fromAddress.Length > 0) //We can render directions
            //   Page.ClientScript.RegisterStartupScript(this.GetType(), "DD_LOAD", "_nco_dd.loadDirections();", true);
            
        }
            
        base.OnPreRender(e);
    }
    
</script>
<div runat="server" id="Directions">
<strong>GoogleMaps Driving Directions</strong><br />
No api key is needed for running it on localhost.<br />
But you will need an api key for the production URL.<br />
You may obtain a key from code.google.com<br />
</div>

<script type="text/javascript">
//<![CDATA[
    
    function _nco_gdir()
    {
        this.fromAddress = "<%=fromAddress%>";
        this.toAddress = "<%=toAddress%>";
        this.mapElementID = "<%=mapElementID%>";
        this.autoLoad = "<%=autoLoad.ToString().ToLower() %>";
        this.directions = null;
        var self = this; //don't ask
        google.load("maps","2"); //load version 2 of GoogleMaps API

        this.handleErrors = function()
        {
            
            if(self.divMap) self.divMap.innerHTML = "";
            if (self.directions && self.directions.getStatus().code == G_GEO_UNKNOWN_ADDRESS)
            {
                alert("Driving directions are not available for the address you entered.\nThis may be because the from address is relatively new, or it may be incorrect.");                
            }
            else
            {
                alert("We are currently unable to display directions for the specified addresses.");
            }
        };
                
        this.loadDirections = function()
        {
            if(!self.directions)
            {
                if(self.mapElementID.length>0)
                {
                    self.divMap = document.getElementById(self.mapElementID);
                    
                    if(self.divMap!=null)
                    {
                        self.dirMap = new google.maps.Map2(self.divMap);
                        self.dirMap.addControl(new google.maps.LargeMapControl());					    
                        self.dirMap.addControl(new google.maps.ScaleControl());        
                    }
                    else
                        self.dirMap = null;
                }
                
                self.dirpanel = document.getElementById("<%=Directions.ClientID%>");
                self.directions = new google.maps.Directions(self.dirMap, self.dirpanel);
                google.maps.Event.addListener(self.directions, "error", self.handleErrors);
            }
            
            //Clear Directions, if any
            self.dirpanel.innerHTML = "";

            //if(this.divMap!=null)
               // this.divMap.innerHTML = "Loading Map... Please wait";
            
            var ft = "from: " +  self.fromAddress + " to: " + self.toAddress;
                
            self.directions.load(ft);
            
        };
        
        if(this.fromAddress.length>0 && this.toAddress.length>0 && this.autoLoad)
            google.setOnLoadCallback(this.loadDirections); //The google way to register to window.onload
    }
    
    _nco_dd = new _nco_gdir();
            
//]]>
</script>         
