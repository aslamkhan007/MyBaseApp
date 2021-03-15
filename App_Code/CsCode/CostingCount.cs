using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for CostingCount
/// </summary>
public class CostingCount
{
    string conStr = string.Empty;
    DBConnect db;
    private SqlConnection conn;
	public CostingCount()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public CostingCount(string connectionstring)
    {
        conStr = connectionstring;
        db = new DBConnect(conStr);
        conn = new SqlConnection(conStr);
    }

    public string _tran_no;
    public string _count_code;
    public string _count_desc;

    public int _count_type;
    public double _actual_type;
    public string _count_usage;
    
    public int _sequence_no;
    public string _eff_from;
    public DateTime _eff_to;
    public string _status;
    public string _userid;

    public string tran_no
    {
        get { return _tran_no; }
        set { _tran_no = value; }
    }

    public string count_code
    {
        get { return _count_code; }
        set { _count_code = value; }
    }

    public string count_desc
    {
        get { return _count_desc; }
        set { _count_desc = value; }
    }

    public int count_type
    {
        get { return _count_type; }
        set { _count_type = value; }
    }

    public double actual_type
    {
        get { return _actual_type; }
        set { _actual_type = value; }
    }

    public string count_usage
    {
        get { return _count_usage; }
        set { _count_usage = value; }
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

    public string eff_from
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
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("jct_costing_count_master_data_entry", conn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@transno", tran_no);
                    cmd.Parameters.AddWithValue("@type", "COUNT MASTER");
                    cmd.Parameters.AddWithValue("@count_code", count_code);
                    cmd.Parameters.AddWithValue("@count_desc", count_desc);
                    cmd.Parameters.AddWithValue("@count_type", count_type);
                    cmd.Parameters.AddWithValue("@actual_count", actual_type);
                    cmd.Parameters.AddWithValue("@count_usage",count_usage);
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
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("jct_costing_count_master_data_entry", conn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@transno", tran_no);
                    cmd.Parameters.AddWithValue("@type", "COUNT MASTER");
                    cmd.Parameters.AddWithValue("@count_code", count_code);
                    cmd.Parameters.AddWithValue("@count_desc", count_desc);
                    cmd.Parameters.AddWithValue("@count_type", count_type);
                    cmd.Parameters.AddWithValue("@actual_count", actual_type);
                    cmd.Parameters.AddWithValue("@count_usage", count_usage);
                    cmd.Parameters.AddWithValue("@sequence_no", sequence_no);
                    cmd.Parameters.AddWithValue("@eff_from", eff_from);
                    cmd.Parameters.AddWithValue("@eff_to", _eff_to);
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@userid", "ABC");
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
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("jct_costing_count_master_data_entry", conn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@transno", tran_no);
                    cmd.Parameters.AddWithValue("@type", "COUNT MASTER");
                    cmd.Parameters.AddWithValue("@count_code", count_code);
                    cmd.Parameters.AddWithValue("@count_desc", count_desc);
                    cmd.Parameters.AddWithValue("@count_type", count_type);
                    cmd.Parameters.AddWithValue("@actual_count", actual_type);
                    cmd.Parameters.AddWithValue("@count_usage", count_usage);
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
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("jct_costing_count_master_data_entry", conn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@transno", tran_no);
                    cmd.Parameters.AddWithValue("@type", "COUNT MASTER");
                    cmd.Parameters.AddWithValue("@count_code", count_code);
                    cmd.Parameters.AddWithValue("@count_desc", count_desc);
                    cmd.Parameters.AddWithValue("@count_type", count_type);
                    cmd.Parameters.AddWithValue("@actual_count", actual_type);
                    cmd.Parameters.AddWithValue("@count_usage", count_usage);
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
                string sql = " SELECT     tran_no, count_code, count_desc, count_type, actual_count, count_usage, sequence_no, ISNULL(CONVERT(VARCHAR(11), eff_from, 110),'') AS eff_from, ISNULL(CONVERT(VARCHAR(11), eff_to, 110),'') AS eff_to, status, userid, hostname, client_ip,company_code, system_date, ISNULL(CONVERT(VARCHAR(11), modify_date, 110),'') AS modify_date, ISNULL(CONVERT(VARCHAR(11), authorize_date, 110),'') AS authorize_date FROM   jct_costing_count_master";
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