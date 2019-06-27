using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace bcsweb.Class
{
    public class DBUtility
    {
        private string DBConnection = ConfigurationManager.ConnectionStrings["UPISRConnection"].ConnectionString;
        private SqlConnection conn;
        private string m_query;
        private DataTable dt;
        private SqlCommand com;
        private SqlDataAdapter adap;
        private DataSet ds;

        public DataTable FetchDataTable(string query)
        {
            try
            {
                conn = new SqlConnection(DBConnection);
                dt = new DataTable();
                conn.Open();
                m_query = query;    
                com = new SqlCommand(m_query, conn);
                com.CommandTimeout = 999999;
                adap = new SqlDataAdapter(com);
                adap.Fill(dt);
                conn.Close();
            }
            catch
            {
                conn.Close();
            }

            return dt;
        }

        public bool ExecuteQuery(string query)
        {
            bool state;
            conn = new SqlConnection(DBConnection);
            ds = new DataSet();
            conn.Open();
            SqlTransaction trans = conn.BeginTransaction();
            try
            {
                m_query = query;
                com = new SqlCommand(m_query, conn, trans);
                com.CommandTimeout = 999999;
                com.ExecuteNonQuery();

                trans.Commit();
                state = true;
            }
            catch
            {
                trans.Rollback();
                state = false;
            }
            finally
            {
                conn.Close();
            }
            return state;
        }

        public int fetchSPRetInt(string query,Dictionary<string,dynamic> parameters)
        {
            conn = new SqlConnection(DBConnection);
            conn.Open();

            com = new SqlCommand(query, conn); 
            com.CommandType = CommandType.StoredProcedure;

            SqlParameter returnParameter = com.Parameters.Add("RetVal", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;

            foreach(KeyValuePair<string,dynamic> param in parameters)
            {
                com.Parameters.Add(new SqlParameter(param.Key, param.Value));
            }

            com.ExecuteNonQuery();
            conn.Close();
            
            int id = (int)returnParameter.Value;


            return id;

        }

    }
}