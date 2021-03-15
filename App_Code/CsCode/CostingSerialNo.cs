using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for CostingSerialNo
/// </summary>
public class CostingSerialNo
{
    string conStr = string.Empty;
    DBConnect db;
    private SqlConnection conn;
    public CostingSerialNo()
    {

    }
    public CostingSerialNo(string connectionstring)
    {
        conStr = connectionstring;
        db = new DBConnect(conStr);
        conn = new SqlConnection(conStr);
    }

    public string _type_code;
    public string _type;
    public string _Prefix;
    public int _count_value;
    public string _Suffix;
    public string _serial_number;
    public DateTime _eff_from;
    public DateTime _eff_to;
    public string _active;




    public string type_code
    {
        get { return _type_code; }
        set { _type_code = value; }
    }

    public string type
    {
        get { return _type; }
        set { _type = value; }
    }


    public string Prefix
    {
        get { return _Prefix; }
        set { _Prefix = value; }
    }

    public int count_value
    {
        get { return _count_value; }
        set { _count_value = value; }
    }

    public string Suffix
    {
        get { return _Suffix; }
        set { _Suffix = value; }
    }

    public string Serial_number
    {
        get { return _serial_number; }
        set { _serial_number = value; }
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
    public string Active
    {
        get { return _active; }
        set { _active = value; }
    }

    public string ExecuteAdd()
    {
        string ConStr = "";
        //cs = new CostingSerialNo(jctdevConnectionString);
        DataTable dt = new DataTable();
        string message = string.Empty;
        conStr = type_code;

        try
        {




            try
            {
                if (db.Connect() == true)
                {
                    // dt= db.ExecuteStoredProcedure(" jct_costing_serial_number_master_Data '" + type_code + "' ,'" + type + "','" + Prefix + "'," + count_value + ",'" + Suffix + "','" + eff_from + "','" + eff_to + "','" + Active + "',null,null,'ADD'");
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("jct_costing_serial_number_master_Data", conn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@typecode", type_code);
                    cmd.Parameters.AddWithValue("@type", "MASTER");
                    cmd.Parameters.AddWithValue("@prefix", Prefix);
                    cmd.Parameters.AddWithValue("@suffix", Suffix);
                    cmd.Parameters.AddWithValue("@eff_from", eff_from);
                    cmd.Parameters.AddWithValue("@eff_to", _eff_to);
                    cmd.Parameters.AddWithValue("@active", Active);
                    cmd.Parameters.AddWithValue("@userid", "ABC");
                    cmd.Parameters.AddWithValue("@clientid", "NULL");
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
        conStr = type_code;

        try
        {
            try
            {
                if (db.Connect() == true)
                {
                    // dt = db.ExecuteStoredProcedure(" jct_costing_serial_number_master_Data '" + type_code + "' ,'" + type + "','" + Prefix + "'," + count_value + ",'" + Suffix + "','" + eff_from + "','" + eff_to + "','" + Active + "',null,null,'MODIFY'");
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("jct_costing_serial_number_master_Data", conn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@typecode", type_code);
                    cmd.Parameters.AddWithValue("@type", "MASTER");
                    cmd.Parameters.AddWithValue("@prefix", Prefix);
                    cmd.Parameters.AddWithValue("@suffix", Suffix);
                    cmd.Parameters.AddWithValue("@eff_from", eff_from);                    
                    cmd.Parameters.AddWithValue("@eff_to", _eff_to);
                    cmd.Parameters.AddWithValue("@active", Active);
                    cmd.Parameters.AddWithValue("@userid", "NULL");
                    cmd.Parameters.AddWithValue("@clientid", "NULL");
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

    public string ExecuteDelete()
    {
        string ConStr = "";
        //cs = new CostingSerialNo(jctdevConnectionString);
        DataTable dt = new DataTable();
        string message = string.Empty;
        conStr = type_code;

        try
        {
            try
            {
                if (db.Connect() == true)
                {
                    // dt = db.ExecuteStoredProcedure(" jct_costing_serial_number_master_Data '" + type_code + "' ,'" + type + "','" + Prefix + "'," + count_value + ",'" + Suffix + "','" + eff_from + "','" + eff_to + "','" + Active + "',null,null,'MODIFY'");
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("jct_costing_serial_number_master_Data", conn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@typecode", type_code);
                    cmd.Parameters.AddWithValue("@type", "MASTER");
                    cmd.Parameters.AddWithValue("@prefix", Prefix);
                    cmd.Parameters.AddWithValue("@suffix", Suffix);
                    cmd.Parameters.AddWithValue("@eff_from", eff_from);
                    cmd.Parameters.AddWithValue("@eff_to", _eff_to);
                    cmd.Parameters.AddWithValue("@active", Active);
                    cmd.Parameters.AddWithValue("@userid", "NULL");
                    cmd.Parameters.AddWithValue("@clientid", "NULL");
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

    public string ExecuteAuthorize()
    {
        string ConStr = "";
        //cs = new CostingSerialNo(jctdevConnectionString);
        DataTable dt = new DataTable();
        string message = string.Empty;
        conStr = type_code;

        try
        {
            try
            {
                if (db.Connect() == true)
                {
                    // dt = db.ExecuteStoredProcedure(" jct_costing_serial_number_master_Data '" + type_code + "' ,'" + type + "','" + Prefix + "'," + count_value + ",'" + Suffix + "','" + eff_from + "','" + eff_to + "','" + Active + "',null,null,'MODIFY'");
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("jct_costing_serial_number_master_Data", conn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@typecode", type_code);
                    cmd.Parameters.AddWithValue("@type", "MASTER");
                    cmd.Parameters.AddWithValue("@prefix", Prefix);
                    cmd.Parameters.AddWithValue("@suffix", Suffix);
                    cmd.Parameters.AddWithValue("@eff_from", eff_from);
                    cmd.Parameters.AddWithValue("@eff_to", _eff_to);
                    cmd.Parameters.AddWithValue("@active", Active);
                    cmd.Parameters.AddWithValue("@userid", "NULL");
                    cmd.Parameters.AddWithValue("@clientid", "NULL");
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

    public DataSet BindData()
    {
        DataSet ds = new DataSet();
        try
        {
            if (db.Connect() == true)
            {
                string sql = " SELECT type_code,type,prefix,count_value,suffix,serial_number,CONVERT(VARCHAR(11),eff_from,110) AS eff_from,CONVERT(VARCHAR(11),eff_to,110) AS eff_to,ISNULL(CONVERT(VARCHAR(11),modify_date,110),'') AS modify_date,ISNULL(CONVERT(VARCHAR(11),authorize_date,110),'') AS authorize_date,Active,Company_code   FROM dbo.jct_costing_serial_number_master  ORDER BY system_date desc";
                ds = db.GetDataSet(ds, sql, "temp");
            }
            return ds;
        }

        catch (Exception ex)
        {
            return null;
        }

    }
    public DataSet FillData()
    {
        DataSet ds = new DataSet();
        try
        {
            if (db.Connect() == true)
            {
                string sql = " SELECT type_code,type,prefix,count_value,suffix,serial_number,CONVERT(VARCHAR(11),eff_from,110) AS eff_from,CONVERT(VARCHAR(11),eff_to,110) AS eff_to,ISNULL(CONVERT(VARCHAR(11),modify_date,103),'') AS modify_date,ISNULL(CONVERT(VARCHAR(11),authorize_date,103),'') AS authorize_date   FROM dbo.jct_costing_serial_number_master where type_code = '" + type_code + "' ";
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