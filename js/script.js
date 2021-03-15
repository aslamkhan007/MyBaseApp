(function(global, undefined) {
    global.OnClientSeriesClicked = function(sender, args) {
        var ajaxManager = global.getAjaxManager();
 
        if (args.get_seriesName() !== "Months") {
            ajaxManager.ajaxRequest(args.get_category());
        }
    }
})(window);