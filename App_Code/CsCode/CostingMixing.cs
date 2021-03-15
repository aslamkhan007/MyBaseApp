using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
/// <summary>
/// Summary description for CostingMixing
/// </summary>
public class CostingMixing
{
    string conStr = string.Empty;
    DBConnect db;
    private SqlConnection conn;
    public CostingMixing()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    public CostingMixing(string connectionstring)
    {
        conStr = connectionstring;
        db = new DBConnect(conStr);
        conn = new SqlConnection(conStr);	
    }

    public string _tran_no;
    public string _mixing_code;
    public string _mixing_desc;
    public int _sequence_no;
    public DateTime _eff_from;
    public DateTime _eff_to;
    public string _status;
    public string _userid;


    public string tran_no
    {
        get { return _tran_no; }
        set { _tran_no = value; }
    }

    public string mixing_code
    {
        get { return _mixing_code; }
        set { _mixing_code = value; }
    }

    public string mixing_desc
    {
        get { return _mixing_desc; }
        set { _mixing_desc = value; }
    }

    public int sequence_no
    {
        get { return _sequence_no; }
        set { _sequence_no = value; }
    }

    public string status
    {
        get { return _status; }
        set { _status = value; }
    }

    public DateTime eff_from
    {
        get { return _eff_from; }
        set { _eff_from = value; }
    }
    public DateTime eff_to
    {
        get { return _eff_to; }
        set { _eff_to = value; }
    }
    public string userid
    {
        get { return _userid; }
        set { _userid = value; }
    }


    public string ExecuteAdd()
    {
        string ConStr = "";
        //cs = new CostingSerialNo(jctdevConnectionString);
        DataTable dt = new DataTable();
        string message = string.Empty;


        try
        {
            try
            {
                if (db.Connect() == true)
                {
                    //dt = db.ExecuteStoredProcedure(" JCT_costing_mixing_master_Data_entry '" + tran_no + "' ,'MASTER','" + mixing_code + "','" + mixing_desc + "'," + sequence_no + ",'" + eff_from + "','" + eff_to + "','" + status + "','" + userid + "',null,'ADD'");
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("JCT_costing_mixing_master_Data_entry", conn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@transno", tran_no);
                    cmd.Parameters.AddWithValue("@type", "MIXING MASTER");
                    cmd.Parameters.AddWithValue("@mixing_code", mixing_code);
                    cmd.Parameters.AddWithValue("@mixing_desc", mixing_desc);
                    cmd.Parameters.AddWithValue("@sequence_no", sequence_no);
                    cmd.Parameters.AddWithValue("@eff_from", eff_from);
                    cmd.Parameters.AddWithValue("@eff_to", _eff_to);
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@userid", "ABC");
                    cmd.Parameters.AddWithValue("@clientip", "NULL");
                    cmd.Parameters.AddWithValue("@action", "ADD");
                    cmd.Parameters.Add("@output", SqlDbType.Char, 500);
                    cmd.Parameters["@output"].Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();

                    message = (string)cmd.Parameters["@output"].Value;
                    conn.Close();
                }
                return message;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        catch (Exception ex)
        {
            return message;
        }
    }

    public string ExecuteModify()
    {       
        DataTable dt = new DataTable();
    string message = string.Empty;
        try
        {
            try
            {
                if (db.Connect() == true)
                {


                         
                   // dt = db.ExecuteStoredProcedure(" JCT_costing_mixing_master_Data_entry '" + tran_no + "' ,'MASTER','" + mixing_code + "','" + mixing_desc + "'," + sequence_no + ",'" + eff_from + "','" + eff_to + "','" + status + "','" + userid + "',null,'MODIFY'");
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("JCT_costing_mixing_master_Data_entry", conn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@transno", tran_no);
                    cmd.Parameters.AddWithValue("@type", "MIXING MASTER");
                    cmd.Parameters.AddWithValue("@mixing_code", mixing_code);
                    cmd.Parameters.AddWithValue("@mixing_desc", mixing_desc);
                    cmd.Parameters.AddWithValue("@sequence_no", sequence_no);
                     cmd.Parameters.AddWithValue("@eff_from", eff_from);
                    cmd.Parameters.AddWithValue("@eff_to", _eff_to);
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@userid","ABC");                   
                    cmd.Parameters.AddWithValue("@clientip", "NULL");
                    cmd.Parameters.AddWithValue("@action", "MODIFY");
                    cmd.Parameters.Add("@output", SqlDbType.Char, 500);
                    cmd.Parameters["@output"].Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();

                    message = (string)cmd.Parameters["@output"].Value;
                    conn.Close();
                }
                return message;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        catch (Exception ex)
        {
            return message;
        }
    }

    public string ExecuteAuthorize()
    {
        string ConStr = "";
        //cs = new CostingSerialNo(jctdevConnectionString);
        DataTable dt = new DataTable();
        string message = string.Empty;


        try
        {
            try
            {
                if (db.Connect() == true)
                {
                    //dt = db.ExecuteStoredProcedure(" JCT_costing_mixing_master_Data_entry '" + tran_no + "' ,'MASTER','" + mixing_code + "','" + mixing_desc + "'," + sequence_no + ",'" + eff_from + "','" + eff_to + "','" + status + "','" + userid + "',null,'AUTHORIZE'");
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("JCT_costing_mixing_master_Data_entry", conn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@transno", tran_no);
                    cmd.Parameters.AddWithValue("@type", "MIXING MASTER");
                    cmd.Parameters.AddWithValue("@mixing_code", mixing_code);
                    cmd.Parameters.AddWithValue("@mixing_desc", mixing_desc);
                    cmd.Parameters.AddWithValue("@sequence_no", sequence_no);
                    cmd.Parameters.AddWithValue("@eff_from", eff_from);
                    cmd.Parameters.AddWithValue("@eff_to", _eff_to);
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@userid", "ABC");
                    cmd.Parameters.AddWithValue("@clientip", "NULL");
                    cmd.Parameters.AddWithValue("@action", "AUTHORIZE");
                    cmd.Parameters.Add("@output", SqlDbType.Char, 500);
                    cmd.Parameters["@output"].Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();

                    message = (string)cmd.Parameters["@output"].Value;
                    conn.Close();
                }
                return message;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        catch (Exception ex)
        {
            return message;
        }
    }

    public string ExecuteDelete()
    {
        string ConStr = "";
        //cs = new CostingSerialNo(jctdevConnectionString);
        DataTable dt = new DataTable();
        string message = string.Empty;


        try
        {
            try
            {
                if (db.Connect() == true)
                {
                   // dt = db.ExecuteStoredProcedure(" JCT_costing_mixing_master_Data_entry '" + tran_no + "' ,'MASTER','" + mixing_code + "','" + mixing_desc + "'," + sequence_no + ",'" + eff_from + "','" + eff_to + "','" + status + "','" + userid + "',null,'DELETE'");
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("JCT_costing_mixing_master_Data_entry", conn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@transno", tran_no);
                    cmd.Parameters.AddWithValue("@type", "MIXING MASTER");
                    cmd.Parameters.AddWithValue("@mixing_code", mixing_code);
                    cmd.Parameters.AddWithValue("@mixing_desc", mixing_desc);
                    cmd.Parameters.AddWithValue("@sequence_no", sequence_no);
                    cmd.Parameters.AddWithValue("@eff_from", eff_from);
                    cmd.Parameters.AddWithValue("@eff_to", _eff_to);
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@userid", "ABC");
                    cmd.Parameters.AddWithValue("@clientip", "NULL");
                    cmd.Parameters.AddWithValue("@action", "DELETE");
                    cmd.Parameters.Add("@output", SqlDbType.Char, 500);
                    cmd.Parameters["@output"].Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();

                    message = (string)cmd.Parameters["@output"].Value;
                    conn.Close();
                }
                return message;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        catch (Exception ex)
        {
            return message;
        }
    }

    public DataSet BindData()
    {
        DataSet ds = new DataSet();
        try
        {
            if (db.Connect() == true)
            {
                string sql = " Select  tran_no ,mixing_code ,mixing_desc ,sequence_no ,ISNULL(CONVERT(VARCHAR(11), eff_from, 101),'') AS eff_from ,ISNULL(CONVERT(VARCHAR(11), eff_to, 101),'') AS eff_to ,status ,userid ,hostname ,client_ip ,company_code ,system_date ,ISNULL(CONVERT(VARCHAR(11), modify_date, 110),'') AS modify_date ,ISNULL(CONVERT(VARCHAR(11), authorize_date, 110),'') AS authorize_date  From jct_costing_mixing_master";
                ds = db.GetDataSet(ds, sql, "temp");
            }
            return ds;
        }

        catch (Exception ex)
        {
            return null;
        }

    }
}