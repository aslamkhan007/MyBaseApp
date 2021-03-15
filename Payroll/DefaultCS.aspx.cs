using System;
using Telerik.Web.UI;


namespace Telerik.Web.Examples.HtmlChart.Functionality.DrillDownChart
{
    public partial class DefaultCS : System.Web.UI.Page
    {
        //public int Plant
        //{
        //    get
        //    {
        //        if (ViewState["Plant"] == null)
        //        {
        //            return 2003;
        //        }
        //        return (int)ViewState["Plant"];
        //    }
        //    set
        //    {
        //        ViewState["Plant"] = value;
        //    }
        //}

        public string Plant
        {
            get
            {
                if (ViewState["Plant"] == null)
                {
                    return "Pln-100";
                }
                return ViewState["Plant"].ToString();
            }
            set
            {
                ViewState["Plant"] = value;
            }
        }


        protected void RadAjaxManager1_AjaxRequest(object sender, AjaxRequestEventArgs e)
        {
         
            //string seriesName = RadHtmlChart1.PlotArea.Series[0].Name;

            //if (seriesName == "Years")
            //{

            //    Year = int.Parse(e.Argument);
            //    SqlDataSource2.SelectParameters[0].DefaultValue = Year.ToString();
            //    RadHtmlChart1.PlotArea.XAxis.DataLabelsField = "Quarter";
            //    RadHtmlChart1.PlotArea.Series[0].DataFieldY = "Rev";
            //    RadHtmlChart1.PlotArea.Series[0].Name = "Quarters";
            //    RadHtmlChart1.DataSourceID = "SqlDataSource2";
            //}
            //else
            //{
            //    if (seriesName == "Quarters")
            //    {
            //        int quarter = int.Parse(e.Argument);
            //        SqlDataSource3.SelectParameters[0].DefaultValue = Year.ToString();
            //        SqlDataSource3.SelectParameters[1].DefaultValue = quarter.ToString();
            //        RadHtmlChart1.PlotArea.XAxis.DataLabelsField = "Month";
            //        RadHtmlChart1.PlotArea.Series[0].DataFieldY = "Rev";
            //        RadHtmlChart1.PlotArea.Series[0].Name = "Months";
            //        RadHtmlChart1.DataSourceID = "SqlDataSource3";
            //    }
            //}


            string seriesName = RadHtmlChart1.PlotArea.Series[0].Name;
            if (seriesName == "Plant")
            {
                //Plant = int.Parse(e.Argument);
                Plant = e.Argument;
                SqlDataSource2.SelectParameters[0].DefaultValue = Plant;
                RadHtmlChart1.PlotArea.XAxis.DataLabelsField = "Location";
                RadHtmlChart1.PlotArea.Series[0].DataFieldY = "Rev";
                RadHtmlChart1.PlotArea.Series[0].Name = "Quarters";
                RadHtmlChart1.DataSourceID = "SqlDataSource2";
            }
            else
            {
                //if (seriesName == "Quarters")
                //{
                //    int quarter = int.Parse(e.Argument);
                //    SqlDataSource3.SelectParameters[0].DefaultValue = Plant.ToString();
                //    SqlDataSource3.SelectParameters[1].DefaultValue = quarter.ToString();
                //    RadHtmlChart1.PlotArea.XAxis.DataLabelsField = "Month";
                //    RadHtmlChart1.PlotArea.Series[0].DataFieldY = "Rev";
                //    RadHtmlChart1.PlotArea.Series[0].Name = "Months";
                //    RadHtmlChart1.DataSourceID = "SqlDataSource3";
                //}

                if (seriesName == "Quarters")
                {
                    string quarter = e.Argument;
                    SqlDataSource3.SelectParameters[0].DefaultValue = Plant.ToString();
                    SqlDataSource3.SelectParameters[1].DefaultValue = quarter.ToString();
                    RadHtmlChart1.PlotArea.XAxis.DataLabelsField = "Month";
                    RadHtmlChart1.PlotArea.Series[0].DataFieldY = "Rev";
                    RadHtmlChart1.PlotArea.Series[0].Name = "Months";
                    RadHtmlChart1.DataSourceID = "SqlDataSource3";
                }

            }

        }

        protected void Refresh_Click(object sender, EventArgs e)
        {
            RadHtmlChart1.PlotArea.XAxis.DataLabelsField = "Plant";
            RadHtmlChart1.PlotArea.Series[0].DataFieldY = "Rev";
            RadHtmlChart1.PlotArea.Series[0].Name = "Plant";
            RadHtmlChart1.DataSourceID = "SqlDataSource1";
        }
    }
}