<%@ Control Language="VB" AutoEventWireup="false" CodeFile="FlashMessage.ascx.vb" Inherits="FlashMessage" %>

    <script language="javascript" type="text/javascript">    
    
        //The original javascript came from http://www.sunburnt.com.au/publications/design/javascript-fade-effects
        //I modified it to work with my code

        //set the opacity of the element (between 0.0 and 1.0)       
        function setOpacity(id, level) {            
            var element = document.getElementById(id); 
            element.style.display = 'inline';           
            element.style.zoom = 1;
            element.style.opacity = level;
            element.style.MozOpacity = level;
            element.style.KhtmlOpacity = level;
            element.style.filter = "alpha(opacity=" + (level * 100) + ");";
        }

        function fadeIn(id, steps, duration, interval, fadeOutSteps, fadeOutDuration){  
            var fadeInComplete;      
            for (i = 0; i <= 1; i += (1 / steps)) {
              setTimeout("setOpacity('" + id + "', " + i + ")", i * duration); 
              fadeInComplete = i * duration;             
            }
            //set the timeout to start after the fade in time and the interval to display the 
            //message on the screen have both completed            
            setTimeout("fadeOut('" + id + "', " + fadeOutSteps + ", " + fadeOutDuration + ")", fadeInComplete + interval);           
        }

        function fadeOut(id, steps, duration) {         
            var fadeOutComplete;       
            for (i = 0; i <= 1; i += (1 / steps)) {
              setTimeout("setOpacity('" + id + "', "  + (1 - i) + ")", i * duration);
              fadeOutComplete = i * duration;
            }      
            //completely hide the displayed message after the fade effect is complete              
            setTimeout("hide('" + id + "')", fadeOutComplete);     
        }   

        function hide(id){
            document.getElementById(id).style.display = 'none';     
        }
    </script>
    

    <asp:Label ID="lblMessage" runat="server" style="display:none" />     
    
 