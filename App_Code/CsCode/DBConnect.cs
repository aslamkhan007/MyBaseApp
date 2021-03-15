using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for DBConnect
/// </summary>
public class DBConnect
{
    private SqlConnection conn;
    private SqlCommand command;
    private string connStr;
    public SqlDataAdapter da;

    public DBConnect(string str)
	{
        connStr = str;
        conn = new SqlConnection(connStr);	
	}

    // Database Connection
    public bool Connect()
    {
        try
        {
            //conn = new SqlConnection(connStr);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    // Close Connection
    public bool Close()
    {
        try
        {
            if (conn.State != ConnectionState.Closed)
                conn.Close();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }


    public DataTable ExecuteStoredProcedure(string sqlStr)
    {
        try
        {
            string sql = "Exec " + sqlStr;
            DataTable dt = new DataTable();
            Connect();
            command = new SqlCommand(sql, conn);
            command.CommandTimeout = 0;
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            da.Fill(ds);
            //da.SelectCommand.Connection.Close();
            dt = ds.Tables[0];

            return dt;
        }
        catch (Exception ex)
        {
            return null;
        }

    }


    public DataSet GetDataSet(DataSet ds1, string sql, string tablename)
    {
        Connect();
        da = new SqlDataAdapter(sql, conn);
        da.Fill(ds1, tablename);
        Close();
        return ds1;
    }

  

}