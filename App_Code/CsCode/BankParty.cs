using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Data;
using System.Net;
/// <summary>
/// Summary description for BankParty
/// </summary>
public class BankParty
{
    string conStr = string.Empty;
    DBConnect db;
    private SqlConnection conn;

    public BankParty()
    {

    }
    public BankParty(string connectionstring)
    {
        conStr = connectionstring;
        db = new DBConnect(conStr);
        conn = new SqlConnection(conStr);
    }
    public string _customer;
    public string _segment;
    public string _bankcode;

    public string _collectiontype;

    public string _receiptDate;
    public DateTime _entryDate;
    public double _amount;
    public string _modifyDate;
    public string _strhost;

    public string _FromDate;
    public string _ToDate;

    public string StrHost
    {
        get { return _strhost; }
        set { _strhost = value; }
    }
    public string customer
    {
        get { return _customer; }
        set { _customer = value; }
    }
    public string segment
    {
        get { return _segment; }
        set { _segment = value; }
    }
    public string bankcode
    {
        get { return _bankcode; }
        set { _bankcode = value; }
    }
    public string collectiontype
    {
        get { return _collectiontype; }
        set { _collectiontype = value; }
    }
    public string receiptdate
    {
        get { return _receiptDate; }
        set { _receiptDate = value; }
    }
    public DateTime entrydate
    {
        get { return _entryDate; }
        set { _entryDate = value; }
    }
    public Double amount
    {
        get { return _amount; }
        set { _amount = value; }
    }
    public string ModifyDate
    {
        get { return _modifyDate; }
        set { _modifyDate = value; }
    }
    public string FromDate
    {
        get { return _FromDate; }
        set { _FromDate = value; }
    }
    public string ToDate
    {
        get { return _ToDate; }
        set { _ToDate = value; }
    }


    public string ExecuteAdd(string shost)
    {

        string message = string.Empty;


        try
        {
            if (db.Connect() == true)
            {
                conn.Open();
                string qry = "INSERT  JCT_DAILY_COLLECTION  VALUES('" + customer + "','" + segment + "','" + bankcode + "','" + collectiontype + "','" + receiptdate + "',GETDATE(),'A'," + amount + ",NULL,'" + StrHost + "')";


                SqlCommand cmd = new SqlCommand(qry, conn);
                // con.Open();             
                cmd.ExecuteNonQuery();
                message = "Record Added Successfully";

                return message;

            }
            return null;
        }
        catch (Exception ex)
        {
            return message;
        }
    }
    public string ExecuteModify(string skey)
    {

        string message = string.Empty;

        try
        {
            if (db.Connect() == true)
            {
                conn.Open();
                string qry = "update JCT_DAILY_COLLECTION set Customer='" + customer + "', Segment='" + segment + "',BankCode='" + bankcode + "', CollectionType='" + collectiontype + "',ReceiptDate='" + receiptdate + "',Amount=" + amount + ", ModifyDate=GETDATE() where SerialNo=" + skey;

                SqlCommand cmd = new SqlCommand(qry, conn);

                cmd.ExecuteNonQuery();
                message = "Record Modified Successfully";
                return message;

            }
            return null;
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
                string sql = " SELECT SerialNo, Customer , Segment , BankCode , CollectionType ,CONVERT (VARCHAR(11),ReceiptDate,101) AS ReceiptDate ,CONVERT (VARCHAR(11),EntryDate,101) AS EntryDate ,ISNULL(amount,0.00) AS Amount FROM dbo.JCT_DAILY_COLLECTION WHERE status='A' AND ReceiptDate = CONVERT (SMALLDATETIME, CONVERT (VARCHAR(11), GETDATE() - 1)) ORDER BY SerialNo desc ";

                ds = db.GetDataSet(ds, sql, "temp");
            }
            return ds;
        }

        catch (Exception ex)
        {
            return null;
        }

    }
    public DataSet BindDataafterAddition()
    {
        DataSet ds = new DataSet();
        try
        {
            if (db.Connect() == true)
            {
                string sql = " SELECT SerialNo, Customer , Segment , BankCode , CollectionType ,CONVERT (VARCHAR(11),ReceiptDate,101) AS ReceiptDate ,CONVERT (VARCHAR(11),EntryDate,101) AS EntryDate ,ISNULL(amount,0.00) AS Amount FROM dbo.JCT_DAILY_COLLECTION WHERE status='A' AND ReceiptDate =' " + receiptdate + "' ORDER BY SerialNo desc ";

                ds = db.GetDataSet(ds, sql, "temp");
            }
            return ds;
        }

        catch (Exception ex)
        {
            return null;
        }

    }

    public DataTable BindReportData()
    {
        DataTable dt = new DataTable();
        try
        {
            if (db.Connect() == true)
            {
                conn.Open();
                if (FromDate == null)
                    dt = db.ExecuteStoredProcedure("JCT_Daily_Collection_Report  ");
                else
                dt = db.ExecuteStoredProcedure("JCT_Daily_Collection_Report '" + FromDate + "','" + ToDate + "' ");
            }
            return dt;
        }

        catch (Exception ex)
        {
            return null;
        }

    }
}