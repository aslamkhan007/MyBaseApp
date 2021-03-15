//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.UI;
//using System.Web.UI.WebControls;
//using System.Web.Services;
//using System.Threading;

using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.Services;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Collections;

public partial class Payroll_CascadingDropdownlistWithJquery : System.Web.UI.Page
{
    //public static string strcon = "Data Source=SureshDasari;Initial Catalog=MySampleDB;Integrated Security=true";
    Connection obj = new Connection();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PopulateContinents();
        }

    }

    public void PopulateContinents()
    {
        string qry = ConfigurationManager.ConnectionStrings["misjctdev"].ToString();
        SqlConnection con = new SqlConnection(qry);
        con.Open();
        SqlCommand sqlCmd = new SqlCommand("SELECT plant_code as ID ,  plant_description as ContinentName FROM jct_payroll_Plant_Master WHERE  STATUS='A' ORDER BY ContinentName", con);
        sqlCmd.CommandType = CommandType.Text;
        SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddlContinents.Items.Clear();
        ddlContinents.DataSource = ds;
        ddlContinents.DataTextField = "ContinentName";
        ddlContinents.DataValueField = "ID";
        ddlContinents.DataBind();
        con.Close();
    }

    [System.Web.Services.WebMethod]
    public static ArrayList PopulateCountries(int continentId)
    {
        ArrayList list = new ArrayList();
        String strConnString = ConfigurationManager
            .ConnectionStrings["misjctdev"].ConnectionString;
        //string qry = ConfigurationManager.ConnectionStrings["misjctdev"].ToString();
        //SqlConnection con = new SqlConnection(qry);

        String strQuery = "SELECT Location_code as ID ,Location_description as CountryName FROM  dbo.JCT_payroll_location_master WHERE status = 'A' AND Plant_Code = @ContinentID";
        //String strQuery = "select ID, CountryName from Countries where ContinentID=@ContinentID";
        using (SqlConnection con = new SqlConnection(strConnString))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@ContinentID", continentId);
                cmd.CommandText = strQuery;
                cmd.Connection = con;
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    list.Add(new ListItem(
                   sdr["CountryName"].ToString(),
                   sdr["ID"].ToString()
                    ));
                }
                con.Close();
                return list;
            }
        }
    }


    protected void Submit(object sender, EventArgs e)
    {
        string continent = Request.Form[ddlContinents.UniqueID];
        string country = Request.Form[ddlCountries.UniqueID];
        string city = Request.Form[ddlCities.UniqueID];

        // Repopulate Countries and Cities
        //PopulateDropDownList(PopulateCountries(int.Parse(continent)), ddlCountries);
        //PopulateDropDownList(PopulateCities(int.Parse(country)), ddlCities);
        //ddlCountries.Items.FindByValue(country).Selected = true;
        //ddlCities.Items.FindByValue(city).Selected = true;
    }

}